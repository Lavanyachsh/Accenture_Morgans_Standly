using Accenture_Morgans_Standly.Dtos;
using Accenture_Morgans_Standly.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Accenture_Morgans_Standly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewBookingController : ControllerBase
    {
        INewBookingServices _bookingservice;
        public NewBookingController(INewBookingServices bookingservice)
        {
            _bookingservice = bookingservice;
        }
        [HttpGet(Name = "GetBookings")]
        public async Task<IActionResult> GetBookings()
        {
            try
            {
                var bookingData = await _bookingservice.GetAllBookingDetails();
                if (bookingData != null)
                {
                    return StatusCode(StatusCodes.Status200OK, bookingData);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Bad input request");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }
        [HttpPost]
        [Route("AddBookingDetails")]
        public async Task<IActionResult> Post([FromBody] NewBookingDto bookingdtoobj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                var bookingData = await _bookingservice.AddBookingDetails(bookingdtoobj);
                return StatusCode(StatusCodes.Status201Created, "Booking  Added Succesfully");
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }

        [HttpGet]
        [Route("GetBookingDetailsById/{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            if (Id < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Bad input request");
            }
            try
            {
                var bookingData = await _bookingservice.GetBookingDetailsById(Id);
                if (bookingData == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "BookingID Id not found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, bookingData);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }

        [HttpDelete]
        [Route("DeleteBookingDetilsById/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            if (Id < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Bad input request");
            }

            try
            {
                var countryData = await _bookingservice.DeleteBookingDetilsById(Id);
                if (countryData == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Booking Id not found");
                }
                else
                {
                    var Data = await _bookingservice.DeleteBookingDetilsById(Id);
                    return StatusCode(StatusCodes.Status204NoContent, "booking details deleted successfully");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }

        [HttpPut]
        [Route("UpdateBookingDetils")]
        public async Task<IActionResult> PUT([FromBody] NewBookingDto bookingdtoobj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                var countryData = await _bookingservice.UpdateBookingDetils(bookingdtoobj);
                return StatusCode(StatusCodes.Status201Created, "booking Details Updated Succesfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }
    }
}

