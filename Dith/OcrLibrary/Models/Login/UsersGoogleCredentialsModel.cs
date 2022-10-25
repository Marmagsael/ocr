namespace OcrLibrary.Models.Login;

public class UsersGoogleCredentialsModel
{
    public int Id { get; set; }
    public string? NameIdentifier { get; set; }
    public string? Name { get; set; }
    public string? GiveName { get; set; }
    public string? SurName { get; set; }
    public string? Email { get; set; }
    public string? PictureAddress { get; set; }
}
