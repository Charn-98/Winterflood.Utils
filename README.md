# Winterflood.Utils

General notes:
- I implemented a minimal API that would call a booking service to perform operations in "Waterflood.Booking.API"
- Unit tests can be found in "Waterflood.Booking.Tests"
- Note: with minimal API I can't seem to 'rename' the API call. I'm not sure if this is a limitation of minimal API or something I'm missing.

What improvements would I make with more time?
- Add a basic UI, perhaps with Blazor for simplicity 
- Add a BookingService Interface. In a real-world each type of booking would likely have it's own implmentation of the service.
- Persist the data to a database