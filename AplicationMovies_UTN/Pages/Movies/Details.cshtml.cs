﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AplicationMovies_UTN.Data;
using AplicationMovies_UTN.Model;

namespace AplicationMovies_UTN.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly AplicationMovies_UTN.Data.AplicationMovies_UTNContext _context;

        public DetailsModel(AplicationMovies_UTN.Data.AplicationMovies_UTNContext context)
        {
            _context = context;
        }

        public Movie Movie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                Movie = movie;
            }
            return Page();
        }
    }
}
