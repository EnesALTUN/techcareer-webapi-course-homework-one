namespace AuthApi.Infrastructure
{
    public interface IJwtAuthenticationManager
    {
        dynamic TokenHandler(string email);
    }
}