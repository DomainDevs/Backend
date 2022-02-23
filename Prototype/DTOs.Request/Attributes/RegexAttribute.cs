using System;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace DTOs.Request.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class RegexAttribute : ValidationAttribute
    {
        public string Pattern { get; set; }
        public RegexOptions Options { get; set; }
        public RegexAttribute(string patterns, RegexOptions options = RegexOptions.None)
        {
            Pattern = patterns;
            Options = options;
        }
        public override bool IsValid(object value)
        {
            return IsValid(value as string);
        }
        public bool IsValid(string value)
        {
            return string.IsNullOrEmpty(value) ? true : new Regex(Pattern, Options).IsMatch(value);
        }
    }
}
