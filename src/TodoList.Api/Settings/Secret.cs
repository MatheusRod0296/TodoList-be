namespace TodoList.Api.Settings;

public class Secret
{
    private readonly IConfiguration _configuration;
    public Secret(IConfiguration configuration)
    {
        _configuration = configuration;
        SecretCode = configuration["secret"];
    }

    public string SecretCode { get; }
}