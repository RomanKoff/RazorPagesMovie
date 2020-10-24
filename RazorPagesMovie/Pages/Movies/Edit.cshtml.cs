﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.DAL;
using RazorPagesMovie.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesMovie.Pages.Movies
{

	public class EditModel
		: PageModel
	{

		private readonly MovieContext _context;


		public EditModel(
			MovieContext context)
		{
			_context = context;
		}


		[BindProperty]
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


		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
				return Page();
			_context.Attach(Movie).State = EntityState.Modified;
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!MovieExists(Movie.ID))
					return NotFound();
				throw;
			}
			return RedirectToPage("./Index");
		}


		private bool MovieExists(
			int id)
		{
			return _context.Movie.Any(e => e.ID == id);
		}

	}

}
