using Waterflood.Bookings.API.Models;
using Waterflood.Bookings.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<BookingService>(); //will need to be scoped lifetime for real-world applications 

//this is used for displaying enums as strings 
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

#region MINIMAL API
//note: first time implementing minimal APIs so any feedback welcome here. 
app.MapPost("/bookings", (Booking booking, BookingService bookingService) =>
{
    return Results.Ok(bookingService.CreateBooking(booking));
})
.WithName("AddBooking"); ///mmm, this does not seem to be working for minimal API's (?)


app.MapPut("/bookings/{bookingModel}", (Guid bookingId, Booking booking, BookingService bookingService) =>
{
    var updatedBooking = bookingService.UpdateBooking(bookingId, booking);

    return updatedBooking is null
           ? Results.NotFound()
           : Results.Ok(updatedBooking);
})
.WithName("EditBooking");

app.MapDelete("/bookings/{id}", (Guid bookingId, BookingService bookingService) =>
{
    var deleteStatus = bookingService.DeleteBooking(bookingId);

    return !deleteStatus
           ? Results.NotFound()
           : Results.Ok(deleteStatus);
})
.WithName("DeleteBooking");

app.MapGet("/bookings/{id}", (Guid bookingId, BookingService bookingService) =>
{
    var existingBooking = bookingService.GetBooking(bookingId);

    return existingBooking is null
           ? Results.NotFound()
           : Results.Ok(existingBooking);
})
.WithName("GetBooking");

app.MapGet("/bookings", (BookingService bookingService) =>
{
    var existingBookings = bookingService.GetAllBookings();
    return Results.Ok(existingBookings);
})
.WithName("GetAllBookings");
#endregion

app.Run();
