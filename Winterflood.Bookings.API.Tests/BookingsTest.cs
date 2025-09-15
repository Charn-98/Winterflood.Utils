using Waterflood.Bookings.API.Models;
using Waterflood.Bookings.API.Services;

namespace Winterflood.Bookings.API.Tests
{
    public class BookingsTest
    {
        private readonly BookingService _bookingService;

        public BookingsTest()
        {
            _bookingService = new BookingService();
        }

        [Fact]
        public void CreateBooking_Should_AddNewBooking()
        {
            //arrange
            var booking = new Booking
            {
                CustomerName = "John Doe",
                BookingType = BookingTypeEnum.APARTMENT,
                StartDate = DateTimeOffset.Now,
                EndDate = DateTimeOffset.Now.AddDays(3)
            };

            //act
            var result = _bookingService.CreateBooking(booking);

            //assert
            Assert.NotNull(result);
            Assert.Equal(booking.CustomerName, result.CustomerName);
            Assert.Equal(booking.BookingType, result.BookingType);
        }

        [Fact]
        public void UpdateBooking_Should_ModifyExistingBooking()
        {
            //arrange
            var booking = new Booking
            {
                CustomerName = "John Doe",
                BookingType = BookingTypeEnum.APARTMENT,
                StartDate = DateTimeOffset.Now,
                EndDate = DateTimeOffset.Now.AddDays(3)
            };
            //for the sake of not having data persisted, create for test
            booking = _bookingService.CreateBooking(booking);

            var updateBooking = new Booking
            {
                CustomerName = "Johnanne Doe",
                BookingType = BookingTypeEnum.VEHICLE,
                StartDate = DateTimeOffset.Now,
                EndDate = DateTimeOffset.Now.AddDays(30)
            };

            //act
            var result = _bookingService.UpdateBooking(booking.Id, updateBooking);

            //assert
            Assert.NotNull(result);
            Assert.Equal(result.CustomerName, updateBooking.CustomerName);
            Assert.Equal(result.BookingType, updateBooking.BookingType);
        }

        [Fact]
        public void DeleteBooking_Should_RemoveExistingBooking()
        {
            //arrange
            var booking = new Booking
            {
                CustomerName = "John Doe",
                BookingType = BookingTypeEnum.APARTMENT,
                StartDate = DateTimeOffset.Now,
                EndDate = DateTimeOffset.Now.AddDays(3)
            };
            //for the sake of not having data persisted, create for test
            booking = _bookingService.CreateBooking(booking);

            //act
            var result = _bookingService.DeleteBooking(booking.Id);

            //assert
            Assert.True(result);
        }

        [Fact]
        public void UpdateBooking_Should_ReturnBookingNotFound()
        {
            //arrange
            var booking = new Booking
            {
                Id = Guid.NewGuid(),
                CustomerName = "Jacob",
                BookingType = BookingTypeEnum.APARTMENT,
                StartDate = DateTimeOffset.Now,
                EndDate = DateTimeOffset.Now.AddDays(3)
            };

            //act
            var result = _bookingService.UpdateBooking(booking.Id, booking);

            //assert
            Assert.Null(result);
        }

        [Fact]
        public void DeleteBooking_Should_ReturnBookingNotFound()
        {
            //arrange
            var booking = new Booking
            {
                Id = Guid.NewGuid(),
                CustomerName = "Jacob",
                BookingType = BookingTypeEnum.APARTMENT,
                StartDate = DateTimeOffset.Now,
                EndDate = DateTimeOffset.Now.AddDays(3)
            };

            //act
            var result = _bookingService.DeleteBooking(booking.Id);

            //assert
            Assert.False(result);
        }
    }
}