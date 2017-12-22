namespace HealthyMe.Services.Html
{
    public interface IHtmlService
    {
        string Sanitize(string htmlContent);
    }
}