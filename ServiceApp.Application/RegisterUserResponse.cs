namespace ServiceApp.Application;
public class RegisterUserResponse
{
    public bool Succeeded { get; set; }
    public List<string> Errors { get; set; } = new();
}
