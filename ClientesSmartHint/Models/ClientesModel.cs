using ClientesSmartHint.Util;
using Microsoft.Extensions.Logging.Abstractions;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.Data;

namespace ClientesSmartHint.Models
{
    public class ClientesModel
    {
        public int Id { get; set; }
        public string Nome_Razao { get; set; }
        public string Email { get; set; }
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

        public void SalvarCliente()
        {
            ConexaoBD objConexaoBD = new ConexaoBD();

            if (Genero == null)
            {
                Genero = string.Empty;
            }

            if (Data_Nascimento == null)
            {
                Data_Nascimento = string.Empty;
            }
            else
            {
                Data_Nascimento = DateTime.Parse(Data_Nascimento).ToString("yyyy-MM-dd");
            }

            if (Isento == null)
            {
                Isento = string.Empty;
            }

            if (Bloqueado == null)
            {
                Bloqueado = string.Empty;
            }

            string sql = "INSERT INTO clientes(nome_razao,email,telefone,tipo_pessoa,cpf_cnpj,inscricao_estadual,genero,data_nascimento,isento,bloqueado,senha,data_cadastro)" +
                         $"values('{Nome_Razao}','{Email}','{Telefone}','{Tipo_Pessoa}','{Cpf_Cnpj}','{Inscricao_Estadual}','{Genero}','{Data_Nascimento}','{Isento}','{Bloqueado}','{Senha}',DATE(NOW()));";

            objConexaoBD.ExecutarSQL(sql);
        }


        public void AlterarCliente()
        {
            ConexaoBD objConexaoBD = new ConexaoBD();


            if (Genero == null)
            {
                Genero = string.Empty;
            }

            if (Data_Nascimento == null)
            {
                Data_Nascimento = string.Empty;
            }
            else
            {
                Data_Nascimento = DateTime.Parse(Data_Nascimento).ToString("yyyy-MM-dd");
            }

            if (Isento == null)
            {
                Isento = string.Empty;
            }

            if (Bloqueado == null)
            {
                Bloqueado = string.Empty;
            }

            string sql = "UPDATE clientes SET " +
                         $"nome_razao = '{Nome_Razao}', " +
                         $"email = '{Email}', " +
                         $"telefone = '{Telefone}', " +
                         $"tipo_pessoa = '{Tipo_Pessoa}', " +
                         $"cpf_cnpj = '{Cpf_Cnpj}', " +
                         $"inscricao_estadual = '{Inscricao_Estadual}', " +
                         $"genero = '{Genero}', " +
                         $"data_nascimento = '{Data_Nascimento}'," +
                         $"isento = '{Isento}'," +
                         $"bloqueado = '{Bloqueado}', " +
                         //$"senha = AES_ENCRYPT('{Senha}','EncryptKey') " +
                         $"senha = '{Senha}' " +
                         $"WHERE id = '{Id}';";

            objConexaoBD.ExecutarSQL(sql);
        }

        public List<ClientesModel> ListaClientes()
        {
            List<ClientesModel> lista = new List<ClientesModel>();
            ClientesModel item;

            ConexaoBD objConexaoBD = new ConexaoBD();

            string sql = "Select * FROM clientes ORDER BY Nome_Razao ASC";
            DataTable dados = objConexaoBD.RetornoDataTable(sql);

            for (int i = 0; i < dados.Rows.Count; i++)
            {
                string Data_Nascimento_2 = string.Empty;

                if (dados.Rows[i]["Data_Nascimento"].ToString() != null && dados.Rows[i]["Data_Nascimento"].ToString() != "" && dados.Rows[i]["Data_Nascimento"].ToString() != "0000-00-00")
                {
                    Data_Nascimento_2 = DateTime.Parse(dados.Rows[i]["Data_Nascimento"].ToString()).ToString("dd/MM/yyyy");
                    }
                else
                {
                    Data_Nascimento_2 = "";
                    }
                item = new ClientesModel()
                {
                    Id = int.Parse(dados.Rows[i]["Id"].ToString()),
                    Nome_Razao = dados.Rows[i]["Nome_Razao"].ToString(),
                    Email = dados.Rows[i]["Email"].ToString(),
                    Telefone = dados.Rows[i]["Telefone"].ToString(),
                    Tipo_Pessoa = dados.Rows[i]["Tipo_Pessoa"].ToString(),
                    Cpf_Cnpj = dados.Rows[i]["Cpf_Cnpj"].ToString(),
                    Inscricao_Estadual = dados.Rows[i]["Inscricao_Estadual"].ToString(),
                    Genero = dados.Rows[i]["Genero"].ToString(),
                    Data_Nascimento = Data_Nascimento_2,
                    Isento = dados.Rows[i]["Isento"].ToString(),
                    Bloqueado = dados.Rows[i]["Bloqueado"].ToString(),
                    Senha = dados.Rows[i]["Senha"].ToString(),
                    Data_Cadastro = DateTime.Parse(dados.Rows[i]["Data_Cadastro"].ToString()).ToString("dd/MM/yyyy"),
                };
                lista.Add(item);
            }
            return lista;
        }


        public ClientesModel DadosCliente(int id)
        {
            
            ClientesModel item;

            ConexaoBD objConexaoBD = new ConexaoBD();

            //string sql = $"Select id, nome_razao, email, telefone, tipo_pessoa, cpf_cnpj, inscricao_estadual, genero, data_nascimento, isento, bloqueado, AES_DECRYPT(senha, 'EncryptKey') as senha FROM clientes WHERE ID = {id}";
            string sql = $"Select * FROM clientes WHERE ID = {id}";
            DataTable dados = objConexaoBD.RetornoDataTable(sql);



            string Data_Nascimento_2 = string.Empty;

            if (dados.Rows[0]["Data_Nascimento"].ToString() != null && dados.Rows[0]["Data_Nascimento"].ToString() != "" && dados.Rows[0]["Data_Nascimento"].ToString() != "0000-00-00")
            {
                Data_Nascimento_2 = DateTime.Parse(dados.Rows[0]["Data_Nascimento"].ToString()).ToString("yyyy-MM-dd");
            }
            else
            {
                Data_Nascimento_2 = "";
            }

            item = new ClientesModel()
            {
                Id = int.Parse(dados.Rows[0]["Id"].ToString()),
                Nome_Razao = dados.Rows[0]["Nome_Razao"].ToString(),
                Email = dados.Rows[0]["Email"].ToString(),
                Telefone = dados.Rows[0]["Telefone"].ToString(),
                Tipo_Pessoa = dados.Rows[0]["Tipo_Pessoa"].ToString(),
                Cpf_Cnpj = dados.Rows[0]["Cpf_Cnpj"].ToString(),
                Inscricao_Estadual = dados.Rows[0]["Inscricao_Estadual"].ToString(),
                Genero = dados.Rows[0]["Genero"].ToString(),
                Data_Nascimento = Data_Nascimento_2,
                Isento = dados.Rows[0]["Isento"].ToString(),
                Bloqueado = dados.Rows[0]["Bloqueado"].ToString(),
                Senha = dados.Rows[0]["Senha"].ToString(),
                Data_Cadastro = DateTime.Parse(dados.Rows[0]["Data_Cadastro"].ToString()).ToString("dd/MM/yyyy")
            };
           
            return item;
        }
    }
}
