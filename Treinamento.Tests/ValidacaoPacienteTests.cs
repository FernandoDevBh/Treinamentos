using NUnit.Framework;
using Treinamento.Domain;
using Treinamento.Validacoes;
using FluentValidation.TestHelper;
using System;

namespace Treinamento.Tests
{
  [TestFixture]
  public class ValidacaoPacienteTests
  {
    private ValidacaoPaciente _validacaoPaciente;

    [SetUp]
    public void Setup()
    {
      _validacaoPaciente = new ValidacaoPaciente();
    }

    [Test]
    public void Deve_Ocorrer_Erro_Quando_Nome_Eh_Nulo()
    {
      // Arrange
      var paciente = new Paciente { Nome = null };

      // Act
      var resultado = _validacaoPaciente.TestValidate(paciente);

      //Assert
      resultado.ShouldHaveValidationErrorFor(p => p.Nome);
    }

    [Test]
    public void Nao_Deve_Ocorrer_Erro_Quando_Nome_For_Informado()
    {
      // Arrange
      var paciente = new Paciente { Nome = "Fernando" };

      // Act
      var resultado = _validacaoPaciente.TestValidate(paciente);

      //Assert
      resultado.ShouldNotHaveValidationErrorFor(p => p.Nome);
    }

    [Test]
    public void Deve_Ocorrer_Erro_Quando_Sobrenome_Eh_Nulo()
    {
      // Arrange
      var paciente = new Paciente { Sobrenome = null };

      // Act
      var resultado = _validacaoPaciente.TestValidate(paciente);

      //Assert
      resultado.ShouldHaveValidationErrorFor(p => p.Sobrenome);
    }

    [Test]
    public void Nao_Deve_Ocorrer_Erro_Quando_Sobrenome_For_Informado()
    {
      // Arrange
      var paciente = new Paciente { Sobrenome = "dos Santos Ferreira" };

      // Act
      var resultado = _validacaoPaciente.TestValidate(paciente);

      //Assert
      resultado.ShouldNotHaveValidationErrorFor(p => p.Sobrenome);
    }

    [Test]
    public void Deve_Ocorrer_Error_Quando_DataNascimento_For_Default_Value()
    {
      // Arrange
      var paciente = new Paciente();

      // Act
      var resultado = _validacaoPaciente.TestValidate(paciente);

      //Assert
      resultado.ShouldHaveValidationErrorFor(p => p.DataNascimento);
    }

    [Test]
    public void Nao_Deve_Ocorrer_Error_Quando_DataNascimento_For_Diferente_Default_Value()
    {
      // Arrange
      var paciente = new Paciente { DataNascimento = DateTime.Now};

      // Act
      var resultado = _validacaoPaciente.TestValidate(paciente);

      //Assert
      resultado.ShouldNotHaveValidationErrorFor(p => p.DataNascimento);
    }
  }
}
