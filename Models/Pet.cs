using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace pet_hotel
{
    public enum PetBreedType 
    {
        Shepard,
        Poodle,
        Beagle,
        Bulldog,
        Terrier,
        Boxer,
        Labrador,
        Retriever
    }

    public enum PetColorType 
    {
        White,
        Black,
        Golden,
        TriColor,
        Spotted
    }
    public class Pet 
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string PetBreedType { get; set; }

        public string PetColorType { get; set; }

        public DateTime? CheckedInAt { get; set; }

        [ForeignKey("petOwner")]
        public int PetOwnerId { get; set; }
        public PetOwner petOwner { get; set; }
    }
}
