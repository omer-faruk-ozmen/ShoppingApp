﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Infrastructure.Operations
{
    public static class NameOperation
    {
        public static string CharacterRegulatory(string name)

         => name.Replace("\"", "")
            .Replace("!", "")
            .Replace("'", "")
            .Replace("^", "")
            .Replace("+", "")
            .Replace("%", "")
            .Replace("&", "")
                .Replace("/", "")
                .Replace("(", "")
                .Replace(")", "")
                .Replace("=", "")
                .Replace("?", "")
                .Replace("_", "")
                .Replace("@", "")
                .Replace("£", "")
                .Replace("$", "")
                .Replace("#", "")
                .Replace("½", "")
                .Replace("{", "")
                .Replace("[", "")
                .Replace("]", "")
                .Replace("}", "")
                .Replace("|", "")
                .Replace(";", "")
                .Replace(",", "")
                .Replace(".", "-")
                .Replace(":", "")
                .Replace(" ", "-")
                .Replace("Ö", "O")
                .Replace("ö", "o")
                .Replace("Ü", "U")
                .Replace("u", "u")
                .Replace("ı", "i")
                .Replace("İ", "I")
                .Replace("Ğ", "G")
                .Replace("ğ", "g")
                .Replace("æ", "")
                .Replace("ß", "")
                .Replace("~", "")
                .Replace("¨", "")
                .Replace("`", "")
                .Replace("Ç", "C")
                .Replace("ç", "c")
                .Replace("Ş", "S")
                .Replace("ş", "s")
                .Replace("Â", "A")
                .Replace("â", "a")
                .Replace("Î", "I")
                .Replace("î", "i")
                .Replace("<", "")
                .Replace(">", "")
                ;

    }
}