using System;

namespace Contatos.CrossCutting
{
    public static class MetodosComuns
    {
        public static string SomenteNumeros(string numeros) => String.Join("", System.Text.RegularExpressions.Regex.Split(string.IsNullOrEmpty(numeros) ? "" : numeros, @"[^\d]"));


    }
}
