using Accenture_Morgans_Standly.hotelmanagement_DBModel;

namespace Accenture_Morgans_Standly.Interfaces
{
    public interface INewBookingRepository
    {
        Task<List<NewBooking>> GetAllBookingDetails();
        Task<NewBooking> GetBookingDetailsById(int Id);
        Task<bool> AddBookingDetails(NewBooking bookingDetail);
        Task<bool> UpdateBookingDetils(NewBooking bookingDetail);
        Task<bool> DeleteBookingDetilsById(int Id);
    }
}
