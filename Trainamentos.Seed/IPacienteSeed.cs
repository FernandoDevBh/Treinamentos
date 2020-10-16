using Treinamento.Domain;

namespace Trainamentos.Seed
{
  public interface IPacienteSeed
  {
    Paciente CriarNovoPaciente();

    void AlterarDadosPaciente(Paciente paciente);
  }
}
