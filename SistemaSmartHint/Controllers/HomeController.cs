using Microsoft.AspNetCore.Mvc;
using SistemaSmartHint.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using PagedList;
using Microsoft.AspNetCore.Mvc.Infrastructure;
namespace SistemaSmartHint.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(int? page)
        {
            ClienteModel objCliente = new ClienteModel();
            //ViewBag.ListaClientes = objCliente.ListaClientes();


            var clientes = from s in objCliente.ListaClientes() select s;

            int pageSize = 20;
            int pageNumber = (page ?? 1);

            return View(clientes.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public IActionResult CadastrarCliente(int? id)
        {
            if(id != null)
            {
                ViewBag.Dados = new ClienteModel().DadosCliente(id);
            }
            
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarCliente(ClienteModel dados)
        {
            dados.InserirCliente();
            return Redirect("/Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
