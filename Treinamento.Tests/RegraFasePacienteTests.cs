using NUnit.Framework;
using System;
using Treinamento.Domain;
using Treinamentos.Regras;
using Treinamentos.RegrasPaciente;

namespace Treinamento.Tests
{
  [TestFixture]
  public class RegraFasePacienteTests
  {
    [Test]
    public void Se_Ano_Nascimento_Igual_2003_Paciente_Nao_EhAdulto()
    {
      // Arrange
      var paciente = new Paciente { DataNascimento = new DateTime(2003, 2, 15) };
      IRegraFasePaciente regraFasePaciente = new FasePaciente();            

      // Act & Assert
      Assert.AreEqual(regraFasePaciente.DefinirFasePaciente(paciente), Fase.Crianca);
    }

    [Test]
    public void Se_Ano_Nascimento_Igual_2000_Paciente_Eh_Adulto()
    {
      // Arrange
      var paciente = new Paciente { DataNascimento = new DateTime(2000, 2, 15) };
      IRegraFasePaciente regraFasePaciente = new FasePaciente();

      // Act & Assert
      Assert.AreEqual(regraFasePaciente.DefinirFasePaciente(paciente), Fase.Adulto);
    }
  }
}
