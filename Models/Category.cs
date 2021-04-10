using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace testeef.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Este campo é obrgatório")]
        [MaxLength(60, ErrorMessage = "Este campo edve conter entre 3 e 60 caracteres")]
        [MiniLength(3, ErrorMessage = "Este campo deve conter entre  e 60 caracteres")]

        public string Title { get; set; }
    }
}