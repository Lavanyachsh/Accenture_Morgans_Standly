using Accenture_Morgans_Standly.Dtos;

namespace Accenture_Morgans_Standly.Interfaces
{
    public interface INewBookingServices
    {
        Task<List<NewBookingDto>> GetAllBookingDetails();
        Task<NewBookingDto> GetBookingDetailsById(int Id);
        Task<bool> AddBookingDetails(NewBookingDto bookingDetail);
        Task<bool> UpdateBookingDetils(NewBookingDto bookingDetail);
        Task<bool> DeleteBookingDetilsById(int Id);
    }
}
