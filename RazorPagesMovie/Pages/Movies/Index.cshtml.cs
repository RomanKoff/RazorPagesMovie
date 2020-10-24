using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.DAL;
using RazorPagesMovie.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesMovie.Pages.Movies
{

	public class IndexModel
		: PageModel
	{

		private readonly MovieContext _context;

		public IList<Movie> Movie { get; set; }

		[BindProperty(SupportsGet = true)]
		public string SearchString { get; set; }

		public SelectList Genres { get; set; }

		[BindProperty(SupportsGet = true)]
		public string MovieGenre { get; set; }


		public IndexModel(
			MovieContext context)
		{
			_context = context;
		}


		public async Task OnGetAsync()
		{
			var movies =
				from x in _context.Movie
				select x;
			IQueryable<string> genreQuery =
				from x in _context.Movie
				orderby x.Genre
				select x.Genre;
			if (!string.IsNullOrEmpty(SearchString))
				movies = movies.Where(
					x => x.Title.Contains(SearchString));
			if (!string.IsNullOrEmpty(MovieGenre))
				movies = movies.Where(
					x => x.Genre == MovieGenre);
			Genres = new SelectList(
				await genreQuery.Distinct().ToListAsync());
			Movie = await movies.ToListAsync();
		}

	}

}
