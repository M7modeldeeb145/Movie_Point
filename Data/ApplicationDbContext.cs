using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Movie_Point.Models;
using Movie_Point.ViewModel;

namespace Movie_Point.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Cinema> cinemas { get; set; }
        //public DbSet<ActorMovie> ActorMovies { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build()
                .GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(builder);
        }
		public ApplicationDbContext()
		{
		}
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		: base(options)
		{
		}
		public DbSet<Movie_Point.ViewModel.ApplicationUserVM> ApplicationUserVM { get; set; } = default!;
		public DbSet<Movie_Point.ViewModel.UserLoginVM> UserLoginVM { get; set; } = default!;
		public DbSet<Movie_Point.ViewModel.UserRoleVM> UserRoleVM { get; set; } = default!;
		public DbSet<Movie_Point.ViewModel.ActorViewModel> ActorViewModel { get; set; } = default!;
	}
}
