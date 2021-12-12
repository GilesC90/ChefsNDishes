using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRUDelicious.Models.Home
{
    public class Chef
    {
        [Key]
        public int ChefId {get; set; }

        [Required(ErrorMessage = "Please provide a name")]
        [MinLength(2, ErrorMessage = "Please provide a name with at least 5 characters")]
        public string FirstName {get; set; }

        [Required(ErrorMessage = "Please provide a first name")]
        [MinLength(3, ErrorMessage = "Please provide a first name with at least 5 characters")]
        public string LastName {get; set; }

        [Required(ErrorMessage = "Please provide a DOB")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-DD-YYY}", ApplyFormatInEditMode = true)]

        public DateTime DateOfBirth {get; set; }

        public DateTime CreatedAt {get; set; } = DateTime.Now;
        public DateTime UpdatedAt {get; set; } = DateTime.Now;

        // Nav Properties
        public List<Dish> CreatedDishes {get; set;}
    }
}