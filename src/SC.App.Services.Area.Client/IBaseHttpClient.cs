namespace SC.App.Services.Area.Client
{
    public interface IBaseHttpClient
    {
        void SetAuthorization(string authorization);

        void SetAcceptLanguage(string acceptLanguage);
    }
}