using Microsoft.Extensions.Configuration;

namespace DotnetCase.Business
{
    static class Configuration
    {
        static public string ConnectionString
        {
            get
            {
                var connectionString = string.Empty;

                ConfigurationManager configurationManager = new ConfigurationManager();
                configurationManager.AddJsonFile("appsettings.json");

                if (configurationManager != null)
                    connectionString = configurationManager.GetConnectionString("MSSQL") ?? "";

                return connectionString;
            }
        }

    }
}
