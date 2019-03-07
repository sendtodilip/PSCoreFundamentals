using System;
using System.ComponentModel.DataAnnotations;

namespace PSCoreFundamentals.Core
{
    public class Restaurant
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required, MaxLength(50)]
        public string Location { get; set; }
        public CuisineType Cusine { get; set; }
    }
}
