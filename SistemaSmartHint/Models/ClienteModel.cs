using SistemaSmartHint.Util;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SistemaSmartHint.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public string Nome_Razao { get; set; }
        public string Email { get; set; }
        public string Nome_Razao2 { get; set; }
        public string Email2 { get; set; }
        public string Telefone { get; set; }
        public string Tipo_Pessoa { get; set; }
        public string Cpf_Cnpj { get; set; }
        public string Inscricao_Estadual { get; set; }
        public string Genero { get; set; }
        public string Data_Nascimento { get; set; }
        public string Isento { get; set; }
        public string Bloqueado { get; set; }
        public string Data_Cadastro { get; set; }
        public string Senha { get; set; }

        public List<ClienteModel> ListaClientes()
        {
            List<ClienteModel> retorno = new List<ClienteModel>();
            string json = APIClientesSmartHint.RequestGET("ListaClientes", string.Empty);
            retorno = JsonConvert.DeserializeObject<List<ClienteModel>>(json);

            return retorno;
            
        }

        public void InserirCliente()
        {

            string jsonData = JsonConvert.SerializeObject(this);
            string json = string.Empty;

            if(Id == 0)
            {
                json = APIClientesSmartHint.RequestPOST("SalvarCliente", jsonData);
            }
            else
            {
                json = APIClientesSmartHint.RequestPUT("AlterarCliente/"+Id, jsonData);

            }

        }


        public ClienteModel DadosCliente(int? id)
        {
            ClienteModel retorno = new ClienteModel();
            string json = APIClientesSmartHint.RequestGET("Cliente", id.ToString());
            retorno = JsonConvert.DeserializeObject<ClienteModel>(json);
            return retorno;
        }
    }
}
