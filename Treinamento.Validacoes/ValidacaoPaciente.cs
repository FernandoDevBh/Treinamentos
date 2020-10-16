using FluentValidation;
using System;
using Treinamento.Domain;

namespace Treinamento.Validacoes
{
  public class ValidacaoPaciente : AbstractValidator<Paciente>
  {
    public ValidacaoPaciente()
    {
      RuleFor(p => p.Nome).NotEmpty().WithMessage("Nome do Paciente é Obrigatório");
      RuleFor(P => P.Sobrenome).NotEmpty().WithMessage("Sobrenome do Paciente é Obrigatório");
      RuleFor(p => p.DataNascimento).Must(EhUmaDataNascimentoValida).WithMessage("Data de Nascimento é obrigatória");
    }

    private bool EhUmaDataNascimentoValida(DateTime dataNascimento) =>
      !dataNascimento.Equals(default(DateTime));

  }
}
