using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wba.MovieRating.Core.Entities
{
    public class MoviesRating
    {
        //Rating has one movie
        public Movie Movie { get; set; }
        public int MovieId { get; set; }
        //Rating has one user
        public User User { get; set; }
        public int UserId { get; set; }
        public int Score { get; set; }
    }
}
