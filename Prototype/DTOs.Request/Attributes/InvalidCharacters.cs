using System;
using System.Text.RegularExpressions;

namespace DTOs.Request.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class InvalidCharacters : RegexAttribute
    {
        public InvalidCharacters() : base(@"^[a-zA-Z]+$", RegexOptions.IgnoreCase)
        {
            ErrorMessage = "Caracteres invalidos.";
        }
    }
}
