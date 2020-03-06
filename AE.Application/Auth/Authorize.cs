using Google.Apis.AndroidManagement.v1;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Microsoft.Extensions.Configuration;

namespace AE.Application.Auth
{
    public static class AppAuthorization
    {
        private static GoogleCredential Credentials { get;set; }
        private static AndroidManagementService Service { get;set; }
        public static void Execute(IConfiguration config)
        {
            var credentials = config.GetSection("Google_Credential").Value;
            var googleCredentials = GoogleCredential.FromFile(credentials);

            Credentials = googleCredentials.IsCreateScopedRequired
                ? googleCredentials.CreateScoped(AndroidManagementService.Scope.Androidmanagement)
                : googleCredentials;


            Service = new AndroidManagementService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = Credentials,
                ApplicationName = "Android Enterprise Management App",
                GZipEnabled = true
            });
        }

        public static GoogleCredential GetCredentials(this IConfiguration config) => Credentials;

        public static AndroidManagementService GetAndroidService(this IConfiguration config) => Service;
       
    }
}
