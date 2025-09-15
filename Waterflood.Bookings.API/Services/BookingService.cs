using Waterflood.Bookings.API.Models;

namespace Waterflood.Bookings.API.Services
{
    /// <summary>
    /// Service for managing bookings. Add normal CRUD operations here. 
    /// NB: If vehicles, apartments etc. need different booking logic, create a booking service interface that can be overwritten
    /// </summary>
    public class BookingService
    {
        private readonly List<Booking> bookings = new();

        public Booking CreateBooking(Booking booking)
        {
            booking.Id = Guid.NewGuid();
            bookings.Add(booking);
            return booking;
        }

        public Booking? UpdateBooking(Guid bookingId, Booking booking)
        {
            booking.Id = bookingId;

            var existingBooking = bookings.FirstOrDefault(x => x.Id == booking.Id);
            if (existingBooking is null)
                return null;

            existingBooking.CustomerName = booking.CustomerName;
            existingBooking.BookingType = booking.BookingType;
            existingBooking.StartDate = booking.StartDate;
            existingBooking.EndDate = booking.EndDate;

            return existingBooking;
        }

        public bool DeleteBooking(Guid id)
        {
            var existingBooking = bookings.FirstOrDefault(x => x.Id == id);
            if (existingBooking is null)
                return false;

            bookings.Remove(existingBooking);

            return true;
        }

        public List<Booking> GetAllBookings() => bookings;

        public Booking? GetBooking(Guid id) => bookings.FirstOrDefault(x => x.Id == id);
    }
}
