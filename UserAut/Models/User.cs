using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Objects.DataClasses;

namespace UserAut.Models
{
    public class User
    {
        [Key]
        [Column("id")]
        public int id { get; set; }

        [Column("full_name")]
        [Required, StringLength(150)]
        public string full_name { get; set; }

        [Column("phone")]
        [Required, StringLength(20)]
        public string phone { get; set; }

        [Column("email")]
        [Required, StringLength(150)]
        public string email { get; set; }

        [Column("login")]
        [Required, StringLength(50)]
        public string login { get; set; }

        [Column("pass")]
        [Required, StringLength(255)]
        public string pass { get; set; }

        [Column("is_admin")]
        public bool is_admin { get; set; }
    }
}
