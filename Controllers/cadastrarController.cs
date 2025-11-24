using Lumin.Contexts;
using Lumin.Models;
using Microsoft.AspNetCore.Mvc;

public interface ICadastrarController
{
    IActionResult CadastrarUsuario(Usuario usuario);
    IActionResult Index();
}

[Route("[controller]")]

<<<<<<< HEAD
public class CadastrarController : Controller, ICadastrarController
=======
public class CadastrarController : Controller
>>>>>>> 854552f55778b271b87f3ff03b323bdd1c6f63c4
{
    // Criar uma referência (instância) sobre a comunicação do meu banco de dados
    LuminContext _context = new LuminContext();

    public IActionResult Index()
    {
        // include();//- trago os dados das tabelas relacionadas;
        var listaUsuario = _context.Usuarios.ToList();

        ViewBag.listaUsuario = listaUsuario;

        return View();
    }

    [Route("cadastrar")]
    public IActionResult CadastrarUsuario(Usuario usuario)
    {
<<<<<<< HEAD
        // Armazenar a equipe no banco de dados
        _context.Add(usuario);
=======
>>>>>>> 854552f55778b271b87f3ff03b323bdd1c6f63c4

        // Registrar as alterações no banco de dados
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
<<<<<<< HEAD

    // Na rota de excluir, vamos capturar o id que vem na url
    /*  [Route("ExcluirUsuario/{idUsuario}")]

      public IActionResult ExcluirEquipe(int idJogador)
      {
          //Pegar o id de referência, e vou procurar a equipe no banco de dados
         List<> listaJogadores = _context.Jogadors.Where(x => x.IdEquipe == idJogador).ToList();

          if (listaJogadores.Count > 0)
          {
              //Remover Todos os jogadoresvinculados
              foreach (Jogador jgd in listaJogadores)
              {
                  _context.Remove(jgd);
              }

              //Salvando a remoção dos jogadores
              _context.SaveChanges();
          }
          //Pegar o id de referência, e vou procurar a equipe no banco de dados
              Jogador jogador = _context.Jogadors.FirstOrDefault(x => x.Id == idJogador); // select * from EQUIPE where id == (valor da equipe da tabela)


          _context.Remove(jogador);

          _context.SaveChanges();

          return RedirectToAction("Index");
      }

      [Route("Atualizar/{idUsuario}")]
      public IActionResult Atualizar(int idUsuario)
      {
          Usuario usuario = _context.Usuario.FirstOrDefault(x => x.Id == idUsuario);

          ViewBag.Usuario = usuario;

          return View();
      }

      [Route("AtualizarUsuario")]
      public IActionResult AtualizarJogador(Usuario usuario)
      {
          _context.Usuario.Update(usuario);

          _context.SaveChanges();

          return RedirectToAction("Index");
      }
      */
}
=======
}





    
>>>>>>> 854552f55778b271b87f3ff03b323bdd1c6f63c4
