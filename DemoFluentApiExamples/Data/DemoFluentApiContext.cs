using DemoFluentApiExamples.Model;
using Microsoft.EntityFrameworkCore;

namespace DemoFluentApiExamples.Data;

public class DemoFluentApiContext : DbContext
{
    public DemoFluentApiContext(DbContextOptions<DemoFluentApiContext> options)
    : base(options)
    { }

    public DbSet<Produto> Produtos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DemoFluentApiContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}