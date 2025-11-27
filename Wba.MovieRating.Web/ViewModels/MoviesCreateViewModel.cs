using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Wba.MovieRating.Web.ViewModels
{
    public class MoviesCreateViewModel
    {
        [Required]
        [Display(Name = "Title:")]
        public string Title { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date released:")]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Select actors:")]
        public IEnumerable<int> ActorIds { get; set; }
        [Display(Name = "Select directors:")]
        public IEnumerable<int> DirectorIds { get; set; }
        public IEnumerable<SelectListItem> Actors { get; set; }
        public IEnumerable<SelectListItem> Directors { get; set; }
        [Required]
        public int CompanyId { get; set; }
        [Display(Name = "Company:")]
        public IEnumerable<SelectListItem> Companies { get; set; }
        //file upload
        public IFormFile Image { get; set; }
    }
}
