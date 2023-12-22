using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ClientesSmartHint.Models;
using ClientesSmartHint.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientesSmartHint.Controllers
{
    [Route("api/[controller]")]
    public class ClientesController : Controller
    {
        //Autenticacao AutenticacaoCliente;  
        //public ClientesController(IHttpContextAccessor context)
        //{
        //    AutenticacaoCliente = new Autenticacao(context);
        //}

       
        [HttpGet]
        [Route("ListaClientes")]
        public List<ClientesModel> ListaClientes()
        {
            return new ClientesModel().ListaClientes();
        }

        
        [HttpGet]
        [Route("Cliente/{id}")]
        public ClientesModel DadosCliente(int id)
        {
            return new ClientesModel().DadosCliente(id);
        }

        [HttpPost]
        [Route("SalvarCliente")]
        public Return SalvarCliente([FromBody]ClientesModel dados)
        {
            Return retorno = new Return();

            try
            {
                dados.SalvarCliente();
                retorno.Result = true;
                retorno.Error = string.Empty;
            }
            catch(Exception ex)
            {
                retorno.Result = false;
                retorno.Error = "Erro ao executar a inserção do cliente: " + ex.Message;
            }
            return retorno;
            
        }

        [HttpPut]
        [Route("AlterarCliente/{id}")]
        public Return AlterarCliente(int id, [FromBody]ClientesModel dados)
        {

            
            Return retorno = new Return();

            try
            {               
                retorno.Result = true;
                retorno.Error = "Alterado com sucesso";
                //AutenticacaoCliente.Autenticar();
                dados.Id = id;
                dados.AlterarCliente();
            }
            catch (Exception ex)
            {
                retorno.Result = false;
                retorno.Error = "Erro ao executar a alteração do cliente: " + ex.Message;
            }
            return retorno;
        }

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //    System.Diagnostics.Debug.WriteLine("Teste Delete: " + id);
        //}
    }
}
