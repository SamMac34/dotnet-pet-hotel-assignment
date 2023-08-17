using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace pet_hotel
{
    public class PetOwner 
    {
        public int Id {get; set;}
        [Required]
        public string Name {get; set;}

        public string EmailAddress {get; set;}

        public int PetCount {get; set;}
    }
}
