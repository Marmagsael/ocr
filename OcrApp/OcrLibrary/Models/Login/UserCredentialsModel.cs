namespace OcrLibrary.Models.Login;

public class UserCredentialsModel
{
    public int Id { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? Domain { get; set; }
    public string? RememberToken { get; set; }
}
