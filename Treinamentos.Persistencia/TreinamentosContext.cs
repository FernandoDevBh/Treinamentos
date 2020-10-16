using Microsoft.EntityFrameworkCore;
using Treinamento.Domain;

namespace Treinamentos.Persistencia
{
  public class TreinamentosContext : DbContext
  {
    public TreinamentosContext(DbContextOptions contextOptions) : base(contextOptions)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {

    }

    public DbSet<Paciente> Pacientes { get; set; }    
  }
}
