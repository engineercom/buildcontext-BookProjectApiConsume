using BookProject.WebUI.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookProject.WebUI.Controllers;

public class BookController : Controller
{
    private readonly IHttpClientFactory _factory;

    public BookController(IHttpClientFactory factory)
    {
        _factory = factory;
    }

    public async Task<IActionResult> Index()
    {
        var client = _factory.CreateClient("api");

        var response = await client.GetFromJsonAsync<List<ResponseBookDto>>("api/books");

        return View(response);
    }

    public IActionResult Create()
    {


        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateBookDto request)
    {
        var client = _factory.CreateClient("api");
        var response = await client.PostAsJsonAsync("api/books",request);

    return RedirectToAction("Index");
    }

    public async Task<IActionResult> Edit(int id)
    {
        var client = _factory.CreateClient("api");
        var response = await client.GetFromJsonAsync<EditBookDto>($"api/books/{id}");
        return View(response);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditBookDto request)
    {
        var client = _factory.CreateClient("api");
        var response = await client.PutAsJsonAsync("api/books",request);

        return RedirectToAction("Index");
    }
    [HttpGet]
    public async Task<IActionResult> Delete(int id) {

        var client = _factory.CreateClient("api");

        var response = await client.GetFromJsonAsync<ResponseBookDto>($"api/books/{id}");
        if (response is null) return NotFound();


        return View(response);
    }
    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var client = _factory.CreateClient("api");
        var response = await client.DeleteAsync($"api/books/{id}");
        response.EnsureSuccessStatusCode();
        return RedirectToAction("Index");
    }

}
