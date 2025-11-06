using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wba.MovieRating.Core.Entities
{
    public class Actor : BasePersonEntity
    {
        //Actor can be in many movies
        public ICollection<ActorMovie> Movies { get; set; }
    }
}
