using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ArtsNamespace.Models
{
    public class Art
    {
        public int ArtId { get; set; }
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AlbumId { get; set; }
        public int CategoryId { get; set; }
    }
}