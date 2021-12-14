using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Services.Config
{
    public class DbConnector
    {
        private readonly string _connectionString = string.Empty;

        public DbConnector(string configPath)
        {
            /* nuget
             Microsoft.Extensions.Configuration 2.0.2
             Microsoft.Extensions.Configuration.Abstractions 2.0.2
             Microsoft.Extensions.Configuration.Json 2.0.2
            */
            var configBuilder = new ConfigurationBuilder();
            configBuilder.AddJsonFile(configPath, false);

            // _connectionString =
            // configBuilder.Build()
            //.GetSection("ConnectionStrings")
            //.GetSection("DefaultConnection")
            //.Value
            _connectionString = configBuilder.Build()["ConnectionStrings:DefaultConnection"];
        }

        public string GetConnectionString()
        {
            return _connectionString;
        }
    }
}
