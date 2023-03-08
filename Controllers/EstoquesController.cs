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
        List<ItemEstoques> ListaEstoques = new List<ItemEstoques>();

        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync(apiUrl))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine(apiResponse);
                ListaEstoques = JsonConvert.DeserializeObject<List<ItemEstoques>>(apiResponse);
            }
        }
        return View(ListaEstoques);
    }


    //GET{id}
    public ViewResult GetEstoque() => View();

    [HttpPost]
    public async Task<IActionResult> GetEstoque(int id)
    {
        ItemEstoques estoque = new ItemEstoques();

        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync(apiUrl + "/" + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                estoque = JsonConvert.DeserializeObject<ItemEstoques>(apiResponse);
            }

        }
        return View(estoque);
    }
}
