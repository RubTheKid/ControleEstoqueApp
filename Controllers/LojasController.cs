using ControleEstoqueApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ControleEstoqueApp.Controllers;

public class LojasController : Controller
{
    private readonly string apiUrl = "https://localhost:44320/api/Lojas";

    //GET
    public async Task<ActionResult> Index()
    {
        List<Loja> ListaLojas = new List<Loja>();

        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync(apiUrl))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine(apiResponse);
                ListaLojas = JsonConvert.DeserializeObject<List<Loja>>(apiResponse);
            }
        }
        return View(ListaLojas);
    }

    //GET{id}
    public ViewResult GetLoja() => View();
    [HttpPost]
    public async Task<IActionResult> GetLoja(int id)
    {
        Loja loja = new Loja();

        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync(apiUrl + "/" + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                loja = JsonConvert.DeserializeObject<Loja>(apiResponse);
            }

        }
        return View(loja);
    }

    //POST
    public ViewResult AddLoja() => View();

    [HttpPost]
    public async Task<IActionResult> AddLoja(Loja loja)
    {
        Loja lojaAdd = new Loja();

        using (var httpClient = new HttpClient())
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(loja), Encoding.UTF8, "application/json");

            using (var response = await httpClient.PostAsync(apiUrl, content))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();

                lojaAdd = JsonConvert.DeserializeObject<Loja>(apiResponse);
            }
        }
        return View(lojaAdd);
    }

    //PUT
    [HttpGet]
    public async Task<IActionResult> UpdateLoja(int id)
    {
        Loja loja = new Loja();

        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync(apiUrl + "/" + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                loja = JsonConvert.DeserializeObject<Loja>(apiResponse);
            }
        }
        return View(loja);
    }
    [HttpPost]
    public async Task<IActionResult> UpdateLoja(Loja loja)
    {
        Loja UpdateLoja = new Loja();

        using (var httpClient = new HttpClient())
        {

            var content = JsonContent.Create<Loja>(loja);

            using (var response = await httpClient.PutAsync(apiUrl, content))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                ViewBag.Result = "Sucesso";
                UpdateLoja = JsonConvert.DeserializeObject<Loja>(apiResponse);
            }
        }

        return View(UpdateLoja);
    }





    //DELETE
    [HttpPost]
    public async Task<IActionResult> DeleteLoja(int LojaId)
    {
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.DeleteAsync(apiUrl + "/" + LojaId))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
            }
        }
        return RedirectToAction("Index");
    }

}
