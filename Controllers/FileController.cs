﻿namespace TextFilesMvc;
using Microsoft.AspNetCore.Mvc;

public class FileController : Controller
{
    private readonly ILogger<FileController> _logger;

    private readonly IWebHostEnvironment _env;

    public FileController(ILogger<FileController> logger, IWebHostEnvironment env)
    {
        _logger = logger;
        _env = env;
    }

    public IActionResult Index()
    {
        var path = Path.Combine(_env.ContentRootPath, "TextFiles");
        ViewBag.Files = Directory.GetFiles(path);

        return View();
    }

    public IActionResult Details(int id)
    {
        var path = Path.Combine(_env.ContentRootPath, "TextFiles", $"File{id}.txt");
        var text = System.IO.File.ReadAllText(path);
        ViewBag.Text = text;

        return View();
    }
}
