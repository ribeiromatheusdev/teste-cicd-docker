using AppMvcTeste.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppMvcTeste.Controllers;

public class ProdutosController(AppDbContext context) : Controller
{
    private readonly AppDbContext _context = context;

    public async Task<IActionResult> Index()
    {
        var produtos = await _context.Produtos.ToListAsync();
        return View(produtos);
    }

    public IActionResult Criar() => View();

    [HttpPost]
    public async Task<IActionResult> Criar(Produto produto)
    {
        if (ModelState.IsValid)
        {
            _context.Add(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(produto);
    }
}