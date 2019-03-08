using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PSCoreFundamentals.Core;
using PSCoreFundamentals.Data;

namespace PSCoreFundamentals.Pages.Restaurants
{
    public class DeleteModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        public Restaurant restaurant { get; set; }

        public DeleteModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        public IActionResult OnGet(int restaurantID)
        {
            restaurant = restaurantData.GetRestaurantByID(restaurantID);
            if (restaurant == null)
            {
                return RedirectToPage("./PageNotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int restaurantId)
        {
            var rest = restaurantData.Delete(restaurantId);
            restaurantData.Commit();
            if (rest == null)
            {
                return RedirectToPage("./PageNotFound");
            }
            TempData["message"] = $"{rest.Name} deleted.";
            return RedirectToPage("./List");
        }
    }
}