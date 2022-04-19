using System;
using System.Collections.Generic;

namespace DBLab3.Db
{
    public partial class Track
    {
        public int TrackId { get; set; }
        public string Name { get; set; } = null!;
        public int? AlbumId { get; set; }
        public int MediaTypeId { get; set; }
        public int? GenreId { get; set; }
        public string? Composer { get; set; }
        public int Milliseconds { get; set; }
        public int? Bytes { get; set; }
        public double UnitPrice { get; set; }
    }
}
