using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Taxi.Web.Data.Entities
{
    public class TaxiEntity
    {
        public int Id { get; set; }

        [StringLength(7, MinimumLength = 7, ErrorMessage = " El campo {0} debe tener {1} caracteres ")]
        [RegularExpression(@"^([TtPp]{1}\d{6})$", ErrorMessage = " El campo {0} debe comenzar con un caracter y terminar con números ")]
        [Required(ErrorMessage = " El campo {0} es obligatorio ")]
        [Display (Name ="Placa")]
        public string Plaque { get; set; }


        public ICollection<TripEntity> Trips { get; set; }

       // public UserEntity User { get; set; }
    }
}
 