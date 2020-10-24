using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.DAL;
using RazorPagesMovie.Domain.Entities;
using System.Threading.Tasks;

namespace RazorPagesMovie.Pages.Movies
{

	public class DetailsModel
		: PageModel
	{

		private readonly MovieContext _context;


		public DetailsModel(
			MovieContext context)
		{
			_context = context;
		}


		public Movie Movie { get; set; }


		public async Task<IActionResult> OnGetAsync(
			int? id)
		{
			if (id == null)
				return NotFound();
			Movie = await _context.Movie
				.FirstOrDefaultAsync(m => m.ID == id);
			if (Movie == null)
				return NotFound();
			return Page();
		}

	}

}
