using Microsoft.AspNetCore.Http;
using System;

namespace ClientesSmartHint.Util
{
    public class Autenticacao
    {
        public static string token = "AutTeste";
        public static string erro_token = "Erro na autenticação!";
        IHttpContextAccessor contextAccessor;

        public Autenticacao(IHttpContextAccessor context)
        {
            contextAccessor = context;
        }

        public void Autenticar()
        {
            try
            {
                string token_cliente = contextAccessor.HttpContext.Request.Headers["token"].ToString();

                if (string.Equals(token, token_cliente) == false)
                {
                    throw new Exception(erro_token);
                }                

            }
            catch
            {
                throw new Exception(erro_token);
            }
        }
    }
}
