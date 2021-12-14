using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using NetCore.Services.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Services.Data
{
    public class CodeFirstDbContextFactory : IDesignTimeDbContextFactory<CodeFirstDbContext>
    {
        private const string _configPath = @"D:\repo\0. GIT\StudyASPNetCore\NetCore.Web\appsettings.json";

        public CodeFirstDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CodeFirstDbContext>();
            optionsBuilder.UseSqlServer(new DbConnector(_configPath).GetConnectionString());

            return new CodeFirstDbContext(optionsBuilder.Options);
        }
    }
}
