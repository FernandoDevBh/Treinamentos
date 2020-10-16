using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Trainamentos.Seed;
using Treinamento.Domain;
using Treinamentos.Persistencia;
using Treinamentos.Regras;
using Treinamentos.View.Models;

namespace Treinamentos.View.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;
    private readonly TreinamentosContext _context;
    private readonly IValidator<Paciente> _validator;
    private readonly IPacienteSeed _pacienteSeed;
    private readonly IRegraFasePaciente _regraFasePaciente;

    public HomeController(ILogger<HomeController> logger,
                          TreinamentosContext context,
                          IValidator<Paciente> validator,
                          IPacienteSeed pacienteSeed,
                          IRegraFasePaciente regraFasePaciente)
    {
      _logger = logger;
      _context = context;
      _validator = validator;
      _pacienteSeed = pacienteSeed;
      _regraFasePaciente = regraFasePaciente;
    }

    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Privacy()
    {
      return View();
    }

    [HttpGet]
    public IActionResult ObterPacientes()
    {
      return PartialView("_Pacientes", _context.Pacientes);
    }

    [HttpPost]
    public IActionResult IncluirPaciente()
    {
      var paciente = _pacienteSeed.CriarNovoPaciente();
      if(_validator.Validate(paciente).IsValid)
      {
        paciente.Fase = _regraFasePaciente.DefinirFasePaciente(paciente);
        _context.Pacientes.Add(paciente);
        _context.SaveChanges();
      }
      return Redirect("/");
    }

    [HttpPost]
    public IActionResult EditarPaciente()
    {
      var ids = BuscarMenorIdEMaiorIdPacientes();
      var paciente = BuscarPacientePorId(new Random().Next(ids.Item1, ids.Item2));
      _pacienteSeed.AlterarDadosPaciente(paciente);
      paciente.Fase = _regraFasePaciente.DefinirFasePaciente(paciente);
      _context.SaveChanges();
      return Redirect("/");
    }

    [HttpPost]
    public IActionResult ExcluiPaciente()
    {
      var paciente = _context.Pacientes.FirstOrDefault();
      if(paciente != null)
      {
        _context.Pacientes.Remove(paciente);
        _context.SaveChanges();
      }      
      return Redirect("/");
    }

    private Paciente BuscarPacientePorId(int id) =>
      _context.Pacientes.Find(id);

    private (int, int) BuscarMenorIdEMaiorIdPacientes() =>
      (_context.Pacientes.Min(p => p.Id), _context.Pacientes.Max(p => p.Id));  
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
