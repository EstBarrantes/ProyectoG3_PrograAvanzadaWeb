namespace BackEnd.Services.Interfaces
{
    public interface IApiKeyMiddelware
    { 
        Task InvokeAsync(HttpContext context);
    }
}
