using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CompaniesAPI.Models
{
    public class CompanyModel
    {
        [Required]
        [JsonIgnore]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Exchange { get; set; }

        [Required]
        public string Ticker { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z]{2}.*", ErrorMessage = "The first two characters of an ISIN must be letters / non numeric.")]
        public string Isin { get; set; }

        public string Website { get; set; }
    }


}
