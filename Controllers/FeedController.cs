

using Lumin.Contexts;
using Lumin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("[controller]")]
public class FeedController : Controller
{
    private readonly LuminContext _context;

    public FeedController()
    {
        _context = new LuminContext();
    }

    // GET: /Feed
    [HttpGet]
    public IActionResult Index()
    {
        var posts = _context.Postagems.Include(x => x.Midia)
            .OrderByDescending(p => p.Id)
            .ToList();

        return View(posts);
    }

    // POST: /Feed/Create
    [HttpPost]
    [Route("Create")]
    public IActionResult Create(IFormCollection form)
    {
        if (string.IsNullOrEmpty(form["Descricao"]))
            return RedirectToAction("Index");

        Postagem postagem = new Postagem()
        {
            Descricao = form["Descricao"],
            UsuarioId = int.Parse(HttpContext.Session.GetString("Usuario")),
            DataPostagem = DateTime.Now,
        };

        _context.Postagems.Add(postagem);

        _context.SaveChanges();

        // Cadastrando dados das midias
        if (form.Files.Count > 0)
        {
            foreach (var file in form.Files)
            {
                //Recebendo  o arquivo anexado
                var arquivoAnexado = file;/* Dentro da possibilidade de receber varios arquivos estamos recebendo apenas o primeiro.(unico) */

                var pastaArmazenamento = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagem");
                /* o Directory.GetCurrentDirectory - uma função que pega a localização da pasta do projeto */
                /* Cria a pasta wwwroot pois é o local para acessar arquivos do navegador */

                /* Verifique se a Pasta não existe */
                if (!Directory.Exists(pastaArmazenamento))
                {
                    /* Caso não exista - o projeto fica responsavel por criar essa pasta */
                    Directory.CreateDirectory(pastaArmazenamento);
                }

                /* Passando a localização da pasta de armazenamento + o nome do arquivo a ser salvo */
                var arquivoArmazenado = Path.Combine(pastaArmazenamento, arquivoAnexado.FileName);

                /* Chamamos uma funcao do C# Para criação de arquivo - dentro da pasta de armazenamento */
                using (var stream = new FileStream(arquivoArmazenado, FileMode.Create))
                {
                    // para esse novo arquivo copiamos o conteudo do arquibvo anexado 
                    arquivoAnexado.CopyTo(stream);
                }

                // Salvando as midias do post
                Midium media = new Midium()
                {
                    Imagem = arquivoAnexado.FileName,
                    PostagemId = postagem.Id,
                };

                _context.Add(media);

            }

            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }
}