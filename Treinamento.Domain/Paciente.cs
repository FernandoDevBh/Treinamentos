using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Treinamento.Domain
{
  public class Paciente
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string NomeMae { get; set; }
    public Fase Fase { get; set; }    
  }
}