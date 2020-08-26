using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace Api.Data
{
    class DataContextFactory :  IDesignTimeDbContextFactory<DataContext>
    {
         public DataContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("SqlConnectionString"));

        return new DataContext(optionsBuilder.Options);
    }
}
}
