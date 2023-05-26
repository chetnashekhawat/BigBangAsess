using BigBangApi.Models;
using BigBangApi.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigBangApi.Controllers
{

    
    [Route("api/hotels")]
    [ApiController]

 
    public class ManageHotelController : ControllerBase
    {
       
            private readonly IHotelRepository _hotelRepository;

            public ManageHotelController(IHotelRepository hotelRepository)
            {
                _hotelRepository = hotelRepository;
            }

            [HttpGet]
            public async Task<ActionResult<List<Hotel>>> FetchHotels()
            {
                var hotels = await _hotelRepository.GetAllHotels();
                return Ok(hotels);
            }

            [HttpGet("{Hid}")]
            public async Task<ActionResult<Hotel>> FetchById(int Hid)
            {
                var hotel = await _hotelRepository.GetHotelById(Hid);
                if (hotel == null)
                {
                    return NotFound();
                }
                return Ok(hotel);
            }
            [Authorize]
            [HttpPost]
            public async Task<IActionResult> InsertHotel(Hotel hotel)
            {
                await _hotelRepository.AddHotel(hotel);
                return Ok();
            }

            [HttpPut("{Hid}")]
            public async Task<IActionResult> PutHotel(int Hid, Hotel hotel)
            {
                if (Hid != hotel.Hid)
                {
                    return BadRequest();
                }

                await _hotelRepository.UpdateHotel(hotel);
                return Ok();
            }

            [HttpDelete("{Hid}")]
            public async Task<IActionResult> RemoveHotel(int Hid)
            {
                await _hotelRepository.DeleteHotel(Hid);
                return Ok();
            }


        [HttpGet("{location}")]
        public async Task<ActionResult<List<Hotel>>> FetchByLocation(string location)
        {
            var hotels = await _hotelRepository.GetHotelsByLocation(location);
            return Ok(hotels);
        }

        [HttpGet("price")]
        public async Task<ActionResult<List<Hotel>>> FetchByPrice(decimal minPrice, decimal maxPrice)
        {
            var hotels = await _hotelRepository.GetHotelsByPrice(minPrice, maxPrice);
            return Ok(hotels);
        }
    }




    }

