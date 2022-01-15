using DemoFluentApiExamples.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoFluentApiExamples.Data.Mappings;
public class ProdutoMapping : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable(nameof(Produto));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Nome)
            .HasMaxLength(Produto.TamanhoNome)
            .IsRequired()
            .HasColumnName("Nome")
            .HasColumnType($"varchar({Produto.TamanhoNome})");
        builder.Property(x => x.Departamento)
            .HasMaxLength(Produto.TamanhoDepartamento)
            .IsRequired()
            .HasColumnName("Descricao")
            .HasColumnType($"varchar({Produto.TamanhoDepartamento})");
        builder.Property(x => x.Preco)
            .IsRequired()
            .HasColumnName("Preco")
            .HasPrecision(15, 2);
    }
}