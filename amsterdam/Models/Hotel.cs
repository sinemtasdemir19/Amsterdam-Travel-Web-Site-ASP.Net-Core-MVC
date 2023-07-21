using System.ComponentModel.DataAnnotations;

namespace amsterdam.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? CheckIn { get; set; }
        public string? CheckOut { get; set; }
        public int? NumberOfPerson { get; set; }
        public string? RoomTypes { get; set; }

    }
}
