﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Modelo.Servico.Utilitarios
{
    public class RegistraLog
    {
        private static string caminhoExe = string.Empty;

        public static bool Log(string strMensagem, string strNomeArquivo = "ArquivoLog")
        {
            try
            {
                caminhoExe = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string caminhoArquivo = Path.Combine(caminhoExe, strNomeArquivo);

                    if (!File.Exists(caminhoArquivo))
                {
                    FileStream arquivo = File.Create(caminhoArquivo);
                    arquivo.Close();
                }

                using (StreamWriter w = File.AppendText(caminhoArquivo))
                {
                    AppendLog(strMensagem, w);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static void AppendLog(string logMensagem, TextWriter txtWriter)
        {
            try
            {
                txtWriter.WriteLine("------------------------------------------------------------------------");
                txtWriter.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
                txtWriter.WriteLine($"ERRO ->  :{logMensagem}");
                txtWriter.WriteLine("------------------------------------------------------------------------");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
