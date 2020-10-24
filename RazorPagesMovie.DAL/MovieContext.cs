using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Domain.Entities;

namespace RazorPagesMovie.DAL
{

	public class MovieContext
		: DbContext
	{
		public DbSet<Movie> Movie { get; set; }

		public MovieContext(
			DbContextOptions<MovieContext> options)
			: base(options)
		{
		}
	}

}
