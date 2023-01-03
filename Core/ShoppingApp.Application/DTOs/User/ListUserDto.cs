namespace ShoppingApp.Application.DTOs.User;

public class ListUserDto
{
    public string Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public bool TwoFactorEnabled { get; set; }
}