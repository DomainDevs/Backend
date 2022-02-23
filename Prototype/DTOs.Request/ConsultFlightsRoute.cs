using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using DTOs.Request.Attributes;

namespace DTOs.Request
{
    public class ConsultFlightsRoute
    {
        /// <summary>
        /// 1. Origin Descripcion del campo
        /// </summary>
        [DataMember(Name = "Origin")]
        [Required(ErrorMessage = "Campo {0} obligatorio!")]
        [StringLength(3, ErrorMessage = "El campo {0} no acepta más de {1} caractere(s).")]
        [InvalidCharacters(ErrorMessage = "Ingreso de caracteres invalidos en el campo: {0}")]
        public string Origin { get; set; }

        /// <summary>
        /// 2. Destination Descripcion del campo
        /// </summary>
        [DataMember(Name = "Destination")]
        [Required(ErrorMessage = "Campo {0} obligatorio!")]
        [StringLength(3, ErrorMessage = "El campo {0} no acepta más de {1} caractere(s).")]
        [InvalidCharacters(ErrorMessage = "Ingreso de caracteres invalidos en el campo: {0}")]
        public string Destination { get; set; }
    }
}
