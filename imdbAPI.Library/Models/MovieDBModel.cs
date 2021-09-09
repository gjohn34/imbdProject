using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imbdAPI.Library.Models
{
    public class MovieDBModel
    {
        public int Id { get; set; }
        public int DirectorId { get; set; }
        public string Title { get; set; } = "";
        public int ReleaseYear { get; set; }
    }
}
