using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wba.MovieRating.Core.Entities
{
    public class ActorMovie : BaseEntity //niet de ideale oplossing => een triple key met character erbij zou ideaal zijn
    {
        //has one movie
        public Movie Movie { get; set; }
        public int MovieId { get; set; }
        //has one actor
        public Actor Actor { get; set; }
        public int ActorId { get; set; }
        public string Character { get; set; }
    }
}
