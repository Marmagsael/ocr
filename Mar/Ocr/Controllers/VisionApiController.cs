using Google.Cloud.Vision.V1;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace Ocr.Controllers
{
    public class VisionApiController : Controller
    {

        private readonly IConfiguration _config;

        public VisionApiController(IConfiguration config)
        {
            _config = config;
        }

        public IActionResult Index()
        {
            ViewBag.Vision = AnalyzeImage(); 
            return View();
        }

        // GET: api/ImageAnalysis
        [HttpGet]
        public IActionResult AnalyzeImage()
        {

            ImageAnnotatorClient client = CreateClient();
            Image image = Image.FromFile("/Simpacc/2022/ocr/Mar/Ocr/wwwroot/images/bill-meralco.png");
            //Image image = Image.FromFile("/Simpacc/2022/ocr/Mar/Ocr/wwwroot/images/sample1.jpg");
            //Image image = Image.FromFile("/Simpacc/2022/ocr/Mar/Ocr/wwwroot/images/invoice.jpg");


            AnnotateImageRequest request = new AnnotateImageRequest
            {
                Image = image,
                Features =
                {
                    new Feature { Type = Feature.Types.Type.LogoDetection },
                    // By default, no limits are put on the number of results per annotation.
                    // Use the MaxResults property to specify a limit.
                    new Feature { Type = Feature.Types.Type.TextDetection},
                }
            };
            AnnotateImageResponse response = client.Annotate(request);
            string logo = DetectLogo(response);
            string amount = DetectAmount(response);
            return Ok(new { logo, amount, response });
        }

       

            private ImageAnnotatorClient CreateClient()
        {
            Dictionary<string, string> credentials = _config.GetSection("GoogleApplicationCredentials").Get<Dictionary<string, string>>();
            string jsonCredentials = Newtonsoft.Json.JsonConvert.SerializeObject(credentials);

            return new ImageAnnotatorClientBuilder { JsonCredentials = jsonCredentials }.Build();
        }

        private string DetectLogo(AnnotateImageResponse response)
        {
            IReadOnlyList<EntityAnnotation> logos = response.LogoAnnotations;
            if (logos.Count != 0)
            {
                return logos[0].Description;
            }
            return "None";
        }
        private string DetectAmount(AnnotateImageResponse response)
        {
            /* This method assumes the following:
            a.) the keyword, total is detected by Vision API before the amount
            b.) the detected text beside the keyword, total can be the amount or another keyword like "amount" or "due"
            c.) to detect the text that's aligned to the keyword, total, the following requirements must be met:
                - the total keyword must be already found and its coordinates must already been stored for conditions
                - the minimum Y coordinate of the text must be less than the maximum Y coordinate of the keyword, total
                - the maximum Y coordinate of the text must be greater than the minimum Y coordinate of the keyword, total
                - the maximum Y coordinate of the text must be greater than the minimum Y coordinate of the keyword, total
            d.) the amount is at the right side of the keyword, total if it matches the pattern for total
            e.) another keyword is at the right side of the keyword, total if it does not match the pattern for total
            d.) if another keyword is detected at the right side of the keyword, total, the minimum and maximum coordinates of the keywords will
                overwrite the stored coordinates for the keyword
            */

            string keyword = "total";
            IDictionary<string, int> keywordBoundingBox = new Dictionary<string, int>
            {
                { "minY", 0 },
                { "maxY", 0 },
                { "minX", 0 },
                { "maxX", 0 }
            };
            IReadOnlyList<EntityAnnotation> textAnnotations = response.TextAnnotations;


            bool keywordIsFound = false;

            foreach (var text in textAnnotations)
            {
                var word = text.Description;
                var minY = text.BoundingPoly.Vertices.Select(v => v.Y).Min();
                var maxY = text.BoundingPoly.Vertices.Select(v => v.Y).Max();
                var minX = text.BoundingPoly.Vertices.Select(v => v.X).Min();
                var maxX = text.BoundingPoly.Vertices.Select(v => v.X).Max();

                //if word is equal to keyword then get its coordinates
                if (word.ToLower().Equals(keyword))
                {
                    keywordBoundingBox["minY"] = minY;
                    keywordBoundingBox["maxY"] = maxY;
                    keywordBoundingBox["minX"] = minX;
                    keywordBoundingBox["maxX"] = maxX;
                    keywordIsFound = true;
                }
                else
                {
                    if (keywordIsFound && minY < keywordBoundingBox["maxY"] && maxY > keywordBoundingBox["minY"] && minX > keywordBoundingBox["maxX"])
                    {
                        if (Regex.IsMatch(word, @".*\d+.*\d+\.\d+")) { return word; }
                        else
                        {
                            keywordBoundingBox["minY"] = Math.Min(keywordBoundingBox["minY"], minY);
                            keywordBoundingBox["maxY"] = Math.Max(keywordBoundingBox["maxY"], maxY);
                            keywordBoundingBox["minX"] = Math.Min(keywordBoundingBox["minX"], minX);
                            keywordBoundingBox["maxX"] = Math.Max(keywordBoundingBox["maxX"], maxX);
                        }
                    }
                }
            }
            return "None";
        }

    }
}
