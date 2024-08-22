using Accenture_Morgans_Standly.hotelmanagement_DBModel;
using Accenture_Morgans_Standly.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Accenture_Morgans_Standly.Repositores
{
    public class NewBookingRepository : INewBookingRepository
    {
        public HotelmanagementContext _htlmancon;
        public NewBookingRepository(HotelmanagementContext htlmancon)
        {
            this._htlmancon = htlmancon;
        }
        public async Task<bool> AddBookingDetails(NewBooking bookingDetail)
        {
            await _htlmancon.NewBookings.AddAsync(bookingDetail);
            _htlmancon.SaveChanges();
            return true;
        }

        public async Task<bool> DeleteBookingDetilsById(int Id)
        {
            NewBooking nb = _htlmancon.NewBookings.SingleOrDefault(e => e.Id == Id);
            if (nb != null)
            {
                _htlmancon.NewBookings.Remove(nb);
                _htlmancon.SaveChanges();
                return true;
            }
            else return false;
        }

        public async Task<List<NewBooking>> GetAllBookingDetails()
        {
            var rm =  _htlmancon.NewBookings.ToList();
            if (rm.Count == 0)
                return null;
            else return rm;
        }

        public async Task<NewBooking> GetBookingDetailsById(int Id)
        {
            var rm = await _htlmancon.NewBookings.Where(e => e.Id == Id).FirstOrDefaultAsync();

            if (rm == null)
                return null;
            else
                return rm;
        }

        public async Task<bool> UpdateBookingDetils(NewBooking bookingDetail)
        {
            _htlmancon.Update(bookingDetail);
            await _htlmancon.SaveChangesAsync();
            return true;
        }
    }
}
