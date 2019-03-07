using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using PSCoreFundamentals.Core;
using PSCoreFundamentals.Data;

namespace PSCoreFundamentals.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurentData;

        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants;
        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration config, 
                         IRestaurantData restaurentData)
        {
            this.config = config;
            this.restaurentData = restaurentData;
        }

        public void OnGet()
        {
            Message = config["Message"];
            Restaurants = restaurentData.GetRestaurantsByName(SearchTerm);
        }
    }
}