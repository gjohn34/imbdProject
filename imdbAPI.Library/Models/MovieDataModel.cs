using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace imbdAPI.Library.Models
{
    public class MovieDataModel
    {
        public int Id { get; set; }
        //public int DirectorId { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DirectorDataModel Director { get; set;}
    }
}
