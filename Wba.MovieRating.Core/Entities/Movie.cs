using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wba.MovieRating.Core.Entities
{
    public class Movie : BaseEntity
    {
        public string Title { get; set; }
        public DateTime? ReleaseDate { get; set; }
        //movie has one company
        public Company Company { get; set; }
        //unshadowed foreign key property !examen!
        public int CompanyId { get; set; }
        //Movies has many ratings
        public ICollection<MoviesRating> Ratings { get; set; }
        //movie can have many directors
        public ICollection<Director> Directors { get; set; }
        //movie can have many actors
        public ICollection<ActorMovie> Actors { get; set; }
    }
}
