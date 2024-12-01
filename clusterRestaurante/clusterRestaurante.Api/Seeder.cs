
using clusterRestaurante.Api.Helpers;
using clusterRestaurante.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace clusterRestaurante.Api
{
    public class Seeder
    {
        private readonly DataContext dataContext;
        private readonly IUserHelper userHelper;

        public Seeder(DataContext dataContext, IUserHelper userHelper)
        {
            this.dataContext = dataContext;
            this.userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await dataContext.Database.EnsureCreatedAsync();
            await CheckRestaurantsAsync();
            await CheckEmployeesAsync();
            await CheckMenusAsync();
            await CheckDishesAsync();
            //Agregamos roles
            await CheckRolesAsync();
            await CheckUserAsync("Eduardo", "Fong", "dubong@gmail.com", "233256789", "fong.jpeg", UserType.Admin);
            await CheckUserAsync("Naomi", "Diaz", "naomi@gmail.com", "2212345634", "naomi.jpeg", UserType.User);
            await CheckUserAsync("Salma", "Hayek", "salmita@gmail.com", "2234561346", "sal.jpeg", UserType.User);
        }

        private async Task<User> CheckUserAsync(string firstName, string lastName, string email, string phoneNumber, string photo, UserType userType)
        {
            var user = await userHelper.GetUserAsync(email);
            if (user == null)
            {
                var employee = await dataContext.Employees.FirstOrDefaultAsync(x => x.roleRestaurant == "Mesero");
                if(employee == null)
                {
                    employee = await dataContext.Employees.FirstOrDefaultAsync();
                }
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phoneNumber,
                    Photo = photo,
                    Employee = employee
                };
                await userHelper.AddUserAsync(user, "123456");
                await userHelper.AddUserToRoleAsync(user, userType.ToString());
            }
            return user;
        }

        private async Task CheckRolesAsync()
        {
            await userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await userHelper.CheckRoleAsync(UserType.User.ToString());
        }

        private async Task CheckDishesAsync()
        {
            if (!dataContext.Dishes.Any())
            {
                //Necesito por lo menos poner 1 restaurante porque ya existe en la relacion
                var menu = await dataContext.Menus.FirstOrDefaultAsync(x => x.Name == "Menu del dia");
                if (menu != null)
                {
                    dataContext.Dishes.Add(new Dish { Name = "Ensalada Cesar", Description = "Rica ensalada cesar", Price = 12, Category = "Ensaladas", Menu = menu });

                }
                await dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckMenusAsync()
        {
            if (!dataContext.Menus.Any())
            {
                //Necesito por lo menos poner 1 restaurante porque ya existe en la relacion
                var employee = await dataContext.Employees.FirstOrDefaultAsync(x => x.Name == "Jose");
                if (employee != null)
                {
                    dataContext.Menus.Add(new Menu { Name = "Menu del dia", Description = "Rico menu del dia", Employee = employee });

                }
                await dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckEmployeesAsync()
        {
            if (!dataContext.Employees.Any())
            {
                //Necesito por lo menos poner 1 restaurante porque ya existe en la relacion
                var restaurant = await dataContext.Restaurants.FirstOrDefaultAsync(x => x.Name == "Kampai");
                if (restaurant != null)
                {
                    dataContext.Employees.Add(new Employee { Name = "Jose", Age = 30, Telephone = 2332, Email = "jose@gmail.com", roleRestaurant= "Mesero", Restaurant = restaurant });
                    dataContext.Employees.Add(new Employee { Name = "Antonia", Age = 27, Telephone = 22390, Email = "an@gmail.com", roleRestaurant = "Bartender", Restaurant = restaurant });

                }
                await dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckRestaurantsAsync()
        {
            if (!dataContext.Restaurants.Any()) 
            {
                dataContext.Restaurants.Add(new Restaurant { Name = "Kampai", Address = "Calle 2", Location = "Puebla", Telephone = 23234 });
                await dataContext.SaveChangesAsync();
            }

        }
    }
}
