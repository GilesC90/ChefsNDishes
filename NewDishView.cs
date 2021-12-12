using System.Collections.Generic;

namespace CRUDelicious.Models.Home
{
    public class NewDishView
    {
        public Dish Form {get; set; }
        public List<Chef> AvailableChefs {get; set; }
    }
}