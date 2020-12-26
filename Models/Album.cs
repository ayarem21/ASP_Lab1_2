using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ArtsNamespace.Models
{
    public class Album
    {
        public int AlbumId { get; set; }
        public string Name { get; set; }
        public List<Art> Arts { get; } = new List<Art>();
    }
}

