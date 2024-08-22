using Accenture_Morgans_Standly.Dtos;
using Accenture_Morgans_Standly.hotelmanagement_DBModel;
using Accenture_Morgans_Standly.Interfaces;

namespace Accenture_Morgans_Standly.Services
{
    public class NewBookingServices : INewBookingServices
    {
        INewBookingRepository _bookingRepository;
        public NewBookingServices(INewBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;

        }
        public async Task<bool> AddBookingDetails(NewBookingDto bookingDetail)
        {
            NewBooking obj = new NewBooking();
            // obj.id = bookingDetail.id; because of identity we cant pass here
            obj.CustomerName = bookingDetail.CustomerName;
            obj.Country = bookingDetail.Country;
            obj.City = bookingDetail.City;
            obj.Email = bookingDetail.Email;


            await _bookingRepository.AddBookingDetails(obj);
            return true;
        }

        public async Task<bool> DeleteBookingDetilsById(int Id)
        {
            await _bookingRepository.DeleteBookingDetilsById(Id);
            return true;
        }

        public async Task<List<NewBookingDto>> GetAllBookingDetails()
        {
            List<NewBookingDto> objBookingDto = new List<NewBookingDto>();
            var result = await _bookingRepository.GetAllBookingDetails();
            foreach (NewBooking bookingobj in result)
            {
                NewBookingDto obj = new NewBookingDto();
                obj.Id = bookingobj.Id;
                obj.CustomerName = bookingobj.CustomerName;
                obj.Country = bookingobj.Country;
                obj.City = bookingobj.City;
                obj.Email = bookingobj.Email;
                objBookingDto.Add(obj);
            }
            return objBookingDto;
        }

        public async Task<NewBookingDto> GetBookingDetailsById(int Id)
        {
            var bkobj = await _bookingRepository.GetBookingDetailsById(Id);

            NewBookingDto bookingdtoobj = new NewBookingDto();
            bookingdtoobj.Id = bkobj.Id;
            bookingdtoobj.CustomerName = bkobj.CustomerName;
            bookingdtoobj.Email = bkobj.Email;
            bookingdtoobj.City = bkobj.City;
            bookingdtoobj.Country = bkobj.Country;

            return bookingdtoobj;
        }

        public async Task<bool> UpdateBookingDetils(NewBookingDto bookingDetail)
        {
            NewBooking obj = new NewBooking();
            obj.Id = bookingDetail.Id;
            obj.CustomerName = bookingDetail.CustomerName;
            obj.City = bookingDetail.City;
            obj.Country = bookingDetail.Country;
            obj.Email = bookingDetail.Email;

            await _bookingRepository.UpdateBookingDetils(obj);
            return true;
        }
    }
}

