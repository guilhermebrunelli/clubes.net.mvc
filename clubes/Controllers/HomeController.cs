using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using clubes.Models;

namespace clubes.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Clube> clubes = GetClubes();
        List<Pais> paises = GetPaises();
        ViewData["Paises"] = paises;
        return View(clubes);
    }

    public IActionResult Details(int id)
    {
        List<Clube> clubes = GetClubes();
        List<Pais> paises = GetPaises();
        DetailsVM details = new() {
            Paises = paises,
            Atual = clubes.FirstOrDefault(p => p.Numero == id),
            Anterior = clubes.OrderByDescending(p => p.Numero).FirstOrDefault(p => p.Numero < id),
            Proximo = clubes.OrderBy(p => p.Numero).FirstOrDefault(p => p.Numero > id),
        };
        return View(details);
    }

    private List<Clube> GetClubes()
    {
        using (StreamReader leitor = new("Data\\clubes.json"))
        {
            string dados = leitor.ReadToEnd();
            return JsonSerializer.Deserialize<List<Clube>>(dados);
        }
    }

        private List<Pais> GetPaises()
    {
        using (StreamReader leitor = new("Data\\paises.json"))
        {
            string dados = leitor.ReadToEnd();
            return JsonSerializer.Deserialize<List<Pais>>(dados);
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
