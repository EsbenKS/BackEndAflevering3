using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AfleveringUge8.Models
{
    public class Translation
    {
        [Key]
        public int TranslationID { get; set; }

        [DisplayName("Danish")]
        [Column(TypeName = "nvarchar(50)")]
        public string Danish { get; set; }

        [DisplayName("Swedish")]
        [Column(TypeName = "nvarchar(50)")]
        public string Swedish { get; set; }

        [DisplayName("Norwegian")]
        [Column(TypeName = "nvarchar(50)")]
        public string Norwegian{ get; set; }

        [DisplayName("English")]
        [Column(TypeName = "nvarchar(50)")]
        public string English{ get; set; }

        [DisplayName("German")]
        [Column(TypeName = "nvarchar(50)")]
        public string German { get; set; }

        [DisplayName("Spanish")]
        [Column(TypeName = "nvarchar(50)")]
        public string Spanish { get; set; }

        [DisplayName("Italian")]
        [Column(TypeName = "nvarchar(50)")]
        public string Italian { get; set; }

        [DisplayName("Croatian")]
        [Column(TypeName = "nvarchar(50)")]
        public string Croatian { get; set; }
    }
}