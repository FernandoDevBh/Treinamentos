using Treinamento.Domain;

namespace Treinamentos.Regras
{
  public interface IRegraFasePaciente
  {
    Fase DefinirFasePaciente(Paciente paciente);
  }
}
