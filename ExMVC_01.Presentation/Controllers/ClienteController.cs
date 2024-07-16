using ExMVC_01.Presentation.Models;
using ExMVC_01.Repository.Entities;
using ExMVC_01.Repository.Entities.Enums;
using ExMVC_01.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ExMVC_01.Presentation.Controllers
{
    public class ClienteController : Controller
    {
        //abrir a página de cadastro /Cliente/Cadastro
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(ClienteCadastroViewModel model,
            [FromServices] ClienteRepository clienteRepository)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (clienteRepository.ObterPorEmail(model.Email) != null)
                        throw new Exception("O Email informado já encontra-se cadastrado. ");

                    if (clienteRepository.ObterPorCpf(model.Cpf) != null)
                        throw new Exception("O CPF informado já encontra-se cadastrado. ");

                    var cliente = new Cliente
                    {
                        Nome = model.Nome,
                        Cpf = model.Cpf,
                        Email = model.Email,
                        DataNascimento = DateTime.Parse(model.DataNascimento),
                        Sexo = (Sexo)char.Parse(model.Sexo)
                    };

                    clienteRepository.Inserir(cliente);
                }

                TempData["MensagemSucesso"] = $"Cliente '{model.Nome}', cadastro com sucesso!";

                ModelState.Clear();
            }
            catch (Exception e)
            {

                TempData["MensagemErro"] = "Ocorreu um erro: " + e.Message;
            }

            return View();

        }

        public IActionResult Consulta()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Consulta(ClienteConsultaViewModel model,
            [FromServices] ClienteRepository clienteRepository)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = clienteRepository.ConsultarPorNome(model.Nome);

                    if (result.Count() > 0)
                    {
                        model.Clientes = result;

                        TempData["MensagemSucesso"] = $"{result.Count()} Cliente(s) obtidos com sucesso. ";
                    }
                    else
                    {
                        TempData["MensagemAlerta"] = "Nenhum cliente foi encontrado. ";
                    }
                }
                catch (Exception e)
                {
                    TempData["MensagemErro"] = e.Message;
                }
            }

            return View(model);
        }
       
        public IActionResult Edicao(Guid id,
        [FromServices] ClienteRepository clienteRepository)
        {
            var model = new ClienteEdicaoViewModel();
            try
            {
                //buscar no banco de dados o cliente atraves do seu id..
                var cliente = clienteRepository.ObterPorId(id);
                model.Id = cliente.Id;
                model.Nome = cliente.Nome;
                model.DataNascimento = cliente.DataNascimento.ToString
               ("yyyy-MM-dd");
                model.Sexo = cliente.Sexo.ToString();
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = e.Message;
            }
            return View(model);

        }

        [HttpPost]
        public IActionResult Edicao(ClienteEdicaoViewModel model,
        [FromServices] ClienteRepository clienteRepository)
        {
            try
            {
                //verificar se todos os campos da model 
                //passaram nas regras de validação..
                if (ModelState.IsValid)
                {
                    //criando um objeto para a classe de entidade Cliente..
                    var cliente = new Cliente
                    {
                        Id = model.Id,
                        Nome = model.Nome,
                        DataNascimento = DateTime.Parse(model.DataNascimento),
                        Sexo = (Sexo)char.Parse(model.Sexo)
                    };
                    //atualizando no banco de dados
                    clienteRepository.Alterar(cliente);
                    TempData["MensagemSucesso"] = $"Cliente '{model.Nome}', atualizado com sucesso!";
                }
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = e.Message;
            }
            return View();
        }

    }
}