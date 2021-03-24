using System;
using System.Collections.Generic;

namespace Assignment3.Models
{
    public class TempStorage
    {
        private static List<MoviesResponse> applications = new List<MoviesResponse>();
        public static IEnumerable<MoviesResponse> Applications => applications;
        public static void AddMovie(MoviesResponse application)
        {
            applications.Add(application);
        }
    }
}
