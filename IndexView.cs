using System.Collections.Generic; 

namespace CRUDelicious.Models.Home
{
    public class IndexView
    {
        public List<Chef> AllChefs {get; set; }
        public List<Dish> AllDishes {get; set; }
    }
}