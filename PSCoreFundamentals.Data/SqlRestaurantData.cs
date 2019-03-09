using System.Collections.Generic;
using PSCoreFundamentals.Core;
using System.Linq;
 
namespace PSCoreFundamentals.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly CoreFundaDbContext coreFundaDbContext;

        public SqlRestaurantData(CoreFundaDbContext coreFundaDbContext)
        {
            this.coreFundaDbContext = coreFundaDbContext;
        }
        public Restaurant Add(Restaurant newRestaurant)
        {
            coreFundaDbContext.Add(newRestaurant);
            return newRestaurant;
        }

        public int Commit()
        {
            return coreFundaDbContext.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetRestaurantByID(id);
            if (restaurant != null)
            {
                coreFundaDbContext.Restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public int GetCountOfRestaurants()
        {
            return coreFundaDbContext.Restaurants.Count();
        }

        public Restaurant GetRestaurantByID(int? id)
        {
            return coreFundaDbContext.Restaurants.Find(id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            var query = from r in coreFundaDbContext.Restaurants
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        select r;

            return query;
        }

        public Restaurant Update(Restaurant restaurant)
        {
            var entity = coreFundaDbContext.Attach(restaurant);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return restaurant;
        }
    }
}
