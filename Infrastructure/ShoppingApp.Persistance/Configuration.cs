using Microsoft.Extensions.Configuration;

namespace ShoppingApp.Persistence
{
    static class Configuration
    {
        public static string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/ShoppingApp.Presentation"));
                configurationManager.AddJsonFile("appsettings.json");

                return configurationManager.GetConnectionString("ShoppingApp");
            }
        }
    }
}
