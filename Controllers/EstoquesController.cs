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

    //POST
    public ViewResult AddEstoque() => View();

    [HttpPost]
    public async Task<IActionResult> AddEstoque(ItemEstoques estoque)
    {
        ItemEstoques estoqueAdd = new ItemEstoques();

        using (var httpClient = new HttpClient())
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(estoque), Encoding.UTF8, "application/json");

            using (var response = await httpClient.PostAsync(apiUrl, content))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();

                estoqueAdd = JsonConvert.DeserializeObject<ItemEstoques>(apiResponse);
            }
        }
        return View(estoqueAdd);
    }

    //PUT




    [HttpGet]
    public async Task<IActionResult> UpdateEstoque(int id)
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


    [HttpPost]
    public async Task<IActionResult> UpdateEstoque(ItemEstoques estoque)
    {
        ItemEstoques UpdateEstoque = new ItemEstoques();

        using (var httpClient = new HttpClient())
        {

            var content = JsonContent.Create<ItemEstoques>(estoque);

            using (var response = await httpClient.PutAsync(apiUrl, content))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                ViewBag.Result = "Sucesso";
                UpdateEstoque = JsonConvert.DeserializeObject<ItemEstoques>(apiResponse);
            }
        }

        return View(UpdateEstoque);
    }


    //DELETE
    [HttpPost]
    public async Task<IActionResult> DeleteEstoque(int Id)
    {
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.DeleteAsync(apiUrl + "/" + Id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
            }
        }
        return RedirectToAction("Index");
    }

}
