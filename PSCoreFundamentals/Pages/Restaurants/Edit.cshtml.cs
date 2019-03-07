using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PSCoreFundamentals.Core;
using PSCoreFundamentals.Data;

namespace PSCoreFundamentals.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        private readonly IHtmlHelper htmlHelper;
        [BindProperty]
        public Restaurant restaurant { get; set; }
        public IEnumerable<SelectListItem> cuisine;

        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? restaurantId)
        {
            cuisine = htmlHelper.GetEnumSelectList<CuisineType>();
            if (restaurantId.HasValue)
            {
                restaurant = restaurantData.GetRestaurantByID(restaurantId);
            }
            else
            {
                restaurant = new Restaurant();
            }
            if (restaurant == null)
            {
                return RedirectToPage("./PageNotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                cuisine = htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();              
            }

            if (restaurant.Id>0)
            {
                restaurantData.Update(restaurant);
                restaurantData.Commit();
            }
            else
            {
                restaurantData.Add(restaurant);
                restaurantData.Commit();
            }

            TempData["Message"] = "Details have been saved.";
            return RedirectToPage("./Details", new { restaurantId = restaurant.Id });

        }
    }
}