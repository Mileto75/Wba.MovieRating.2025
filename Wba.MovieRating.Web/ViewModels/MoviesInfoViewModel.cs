namespace Wba.MovieRating.Web.ViewModels
{
    public class MoviesInfoViewModel : BaseViewModel
    {
        //actors
        public IEnumerable<BaseViewModel> Actors { get; set; }
        //directors
        public IEnumerable<BaseViewModel> Directors { get; set; }
        //company
        public BaseViewModel Company { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double AverageRating { get; set; }
        public string Image { get; set; }
    }
}
