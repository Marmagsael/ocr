namespace OcrLibrary.Models;

public class UsersModel
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public string? Email { get; set; }

    public DateTime? EmailVerifiedAt { get; set; }

    public byte[]? Password { get; set; }  
    
    public string? Domain { get; set; }

    public string? RememberToken { get; set; }

    public DateTime? Created { get; set; }

    public string? IdUserCompany { get; set; }
}
