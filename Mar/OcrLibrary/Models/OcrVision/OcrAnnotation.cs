using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcrLibrary.Models.OcrVision
{
    public class OcrAnnotation
    {
        public string? Annotation { get; set; }
        public string? Description { get; set; }
        public string? BoundingPoly { get; set; }

        public int? x1 { get; set; }
        public int? y1 { get; set; }
        public int? x2 { get; set; }
        public int? y2 { get; set; }
        public int? x3 { get; set; }
        public int? y3 { get; set; }
        public int? x4 { get; set; }
        public int? y4 { get; set; }

    }
}
