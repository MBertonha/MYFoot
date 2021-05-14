using Modelo.Dominio.Localizacao;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Tnf.Notifications;

namespace Modelo.Servico.Utilitarios
{
    public class Criptografar
    {
        public static string CriptografarSenha(string senhaAntiga)
        {
            try
            {
                string senhaNova = "";

                MD5 md5Hash = MD5.Create();
                // Converter a String para array de bytes, que é como a biblioteca trabalha.
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(senhaAntiga));

                // Cria-se um StringBuilder para recompôr a string.
                StringBuilder sBuilder = new StringBuilder();

                // Loop para formatar cada byte como uma String em hexadecimal
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                senhaNova = sBuilder.ToString();

                return senhaNova;
            }
            catch(Exception ex)
                {
                return ex.Message;
            } 
        }

        public static string DescriptografarSenha(string senhaBanco)
        {
            using (MD5 md5Hash = MD5.Create())
            {

                try
                {
                    string senhaNova = "";

                    byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(senhaBanco));

                    StringBuilder sBuilder = new StringBuilder();

                    for (int i = 0; i < data.Length; i++)
                    {
                        sBuilder.Append(data[i].ToString("x2"));
                    }

                    senhaNova = sBuilder.ToString();

                    return senhaNova;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                
            }

           
        }
    }
}
