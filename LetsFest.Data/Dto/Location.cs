using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LetsFest.Data.Dto
{
    public class Location
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } // e.g., "Grand Ballroom" or "Main Stage"

        public string? Description { get; set; }

        // Physical Address
        [Required]
        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }

        [Required]
        public string City { get; set; }
        public string? StateProvince { get; set; }
        public string? PostalCode { get; set; }
        public string Country { get; set; }

        // Capacity & Logistics
        public int? MaxCapacity { get; set; }
        public bool IsAccessible { get; set; } // Wheelchair access, etc.

        // Geospatial (Great for Map integrations)
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        // Virtual Support (For Hybrid/Online Events)
        public string? VirtualUrl { get; set; }
        public string? VirtualPlatform { get; set; } // Zoom, Teams, etc.

        // Relationship: One location can host many events
        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}
