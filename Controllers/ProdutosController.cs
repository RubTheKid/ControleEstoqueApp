﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ControleEstoqueApp.Models;
using System.Text;

namespace ControleEstoqueApp.Controllers;

public class ProdutosController : Controller
{
    private readonly string apiUrl = "https://localhost:44320/api/Produtos";

    //GET
    public async Task<ActionResult> Index()
    {
        List<Produto> ListaProdutos = new List<Produto>();

        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync(apiUrl))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine(apiResponse);
                ListaProdutos = JsonConvert.DeserializeObject<List<Produto>>(apiResponse);
            }
        }
        return View(ListaProdutos);
    }

    //GET{id}
    public ViewResult GetProduto() => View();
    [HttpPost]
    public async Task<IActionResult> GetProduto(int id)
    {
        Produto produto = new Produto();

        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync(apiUrl + "/" + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                produto = JsonConvert.DeserializeObject<Produto>(apiResponse);
            }

        }
        return View(produto);
    }

    //POST
    public ViewResult AddProduto() => View();

    [HttpPost]
    public async Task<IActionResult> AddProduto(Produto produto)
    {
        Produto produtoAdd = new Produto();

        using (var httpClient = new HttpClient())
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(produto), Encoding.UTF8, "application/json");

            using (var response = await httpClient.PostAsync(apiUrl, content))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();

                produtoAdd = JsonConvert.DeserializeObject<Produto>(apiResponse);
            }
        }
        return View(produtoAdd);
    }

    //PUT
    [HttpGet]
    public async Task<IActionResult> UpdateProduto(int id)
    {
        Produto produto = new Produto();

        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync(apiUrl+"/"+id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                produto = JsonConvert.DeserializeObject<Produto>(apiResponse);
            }
        }
        return View(produto);
    }
    [HttpPost]
    public async Task<IActionResult> UpdateProduto(Produto produto)
    {
        Produto produtoUpdate = new Produto();

        using (var httpClient = new HttpClient())
        {
            var content = new MultipartFormDataContent();
            content.Add(new StringContent(produto.Nome.ToString()), "Nome");
            content.Add(new StringContent(produto.Preco.ToString()), "Preco");

            using (var response = await httpClient.PutAsync(apiUrl, content))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                ViewBag.Result = "Sucesso";
                produtoUpdate = JsonConvert.DeserializeObject<Produto>(apiResponse);
            }
        }

        return View(produto);
    }


}
