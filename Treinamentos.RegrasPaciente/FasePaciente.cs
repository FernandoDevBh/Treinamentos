
using System;
using Treinamento.Domain;
using Treinamentos.Regras;

namespace Treinamentos.RegrasPaciente
{
  public class FasePaciente : IRegraFasePaciente
  {
    public Fase DefinirFasePaciente(Paciente paciente) =>
      CalcularIdade(paciente) >= 18 ? Fase.Adulto : Fase.Crianca;

    private bool EhAdulto(Paciente paciente) =>
        CalcularIdade(paciente) > 18;

    private int CalcularIdade(Paciente paciente)
    {
      var diff = DateTime.Now.Subtract(paciente.DataNascimento);
      return diff.Days / 365;
    }
  }
}
