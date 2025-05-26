using Microsoft.EntityFrameworkCore;

namespace Example_FastEndpoints.Api.JobStorage;

// See: https://github.com/FastEndpoints/Job-Queue-EF-Core-Demo/blob/main/src/Storage/JobDbContext.cs

public class JobDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<JobRecord> Jobs { get; set; }
}
