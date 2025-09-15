using System.Text.Json.Serialization;

namespace Winterflood.Bookings.API.Models
{
    public class Booking
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public BookingTypeEnum BookingType { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
    }
}
