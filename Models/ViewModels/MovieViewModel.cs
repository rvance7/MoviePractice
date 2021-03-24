using System;
using System.Collections.Generic;
using Assignment3.Models;

namespace Assignment3.Models.ViewModels
{
    public class MovieViewModel
    {
        public IEnumerable<MoviesResponse> Movies { get; set; }

    }
}