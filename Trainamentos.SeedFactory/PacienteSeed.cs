using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using Trainamentos.Seed;
using Treinamento.Domain;

namespace Trainamentos.SeedFactory
{
  public class PacienteSeed : IPacienteSeed
  {
    private Dictionary<int, Action<Paciente>> _alteracoes;

    public PacienteSeed()
    {
      _alteracoes = new Dictionary<int, Action<Paciente>>();
      _alteracoes.Add(1, AlteraNome);
      _alteracoes.Add(2, AlteraSobrenome);
      _alteracoes.Add(3, AlteraDataNascimento);
      _alteracoes.Add(4, AlteraNomeMae);
    }    

    public void AlterarDadosPaciente(Paciente paciente)
    {
      var key = ObterKeyAlteracoes();
      _alteracoes[key](paciente);
    }

    public Paciente CriarNovoPaciente() =>
      ObterFakerPaciente().Generate();

    private Faker<Paciente> ObterFakerPaciente() =>
      new Faker<Paciente>()
        .RuleFor(p => p.Nome, (f, p) => f.Name.FirstName())
        .RuleFor(p => p.Sobrenome, (f, p) => f.Name.LastName())
        .RuleFor(p => p.NomeMae, (f, p) => f.Name.FullName(Bogus.DataSets.Name.Gender.Female))
        .RuleFor(p => p.DataNascimento, (f, p) => f.Date.Past(refDate: new System.DateTime(1990, 1, 1)));

    private int ObterKeyAlteracoes() =>
      new Random().Next(_alteracoes.Keys.Min(), (_alteracoes.Keys.Max()));    

    private void AlteraNome(Paciente paciente) =>
      ProcessarFake(fake => paciente.Nome = fake.Nome);

    private void AlteraSobrenome(Paciente paciente) =>
      ProcessarFake(fake => paciente.Sobrenome = fake.Sobrenome);

    private void AlteraDataNascimento(Paciente paciente) =>
      ProcessarFake(fake => paciente.DataNascimento = fake.DataNascimento);
    
    private void AlteraNomeMae(Paciente paciente) =>
      ProcessarFake(fake => paciente.NomeMae = fake.NomeMae);

    private void ProcessarFake(Action<Paciente> processo)
    {
      var fake = ObterFakerPaciente().Generate();
      processo(fake);
    }
  }
}
