using ControleEstoqueApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ControleEstoqueApp.Controllers;

public class EstoquesController : Controller
{

    private readonly string apiUrl = "https://localhost:44320/api/ItemEstoques";

    //GET
    public async Task<ActionResult> Index()
    {
        List<Estoque> ListaEstoques = new List<Estoque>();

        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync(apiUrl))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine(apiResponse);
                ListaEstoques = JsonConvert.DeserializeObject<List<Estoque>>(apiResponse);
            }
        }
        return View(ListaEstoques);
    }
}
