using System.ComponentModel.DataAnnotations;
using WebApplicationwithScrapping.enums;

namespace WebApplicationwithScrapping.Models
{
    public class Class
    {

        [Key]
        public int Id { get; set; }
        
        public string? marka { get; set; }
        public string? model { get; set; }
        public string? modelno { get; set; }
        public string? fiyat { get; set; }

        public string? işletimsist { get; set; }

        public string? wind { get; set; }
        public string? ssd { get; set; }
        public string? ram { get; set; }
        public string? resim { get; set; }
        public string? puan { get; set; }


    }
}
