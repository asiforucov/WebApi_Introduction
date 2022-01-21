using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.DTOs.Book
{
    public class BookPostDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
    }
}
