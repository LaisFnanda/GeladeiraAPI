using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("Usuarios")]
    public class Usuario    {
        
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string SenhaSalt { get; set; }
        public string SenhaHash { get; set; }

    }
}
