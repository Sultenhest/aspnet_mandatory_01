using System.ComponentModel.DataAnnotations;

namespace _1_mandatory_movies.Models.Entities
{
    public class Movie
    {
        public int Id{ get; set; }

        public string Name{ get; set; }

        public string Director{ get; set; }

        public int Year{ get; set; }

        public string Description{ get; set; }
    }
}