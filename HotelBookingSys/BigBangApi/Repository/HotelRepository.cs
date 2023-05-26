
using System.Security.Cryptography;
using BigBangApi.Models;
using BigBangApi.Repository;
using Microsoft.EntityFrameworkCore;

public class HotelRepository : IHotelRepository
{

    private readonly HotelDbContext _context;

    public HotelRepository(HotelDbContext context)
    {
        _context = context;
    }

    public async Task<List<Hotel>> GetAllHotels()
    {
        return await _context.Hotels.ToListAsync();
    }



    public async Task<Hotel> GetHotelById(int Hid)
    {
        return await _context.Hotels.FindAsync(Hid);
    }


    public  async Task AddHotel(Hotel hotel)
        {

            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();
        }

    public  async Task DeleteHotel(int Hid)
    {
            var hotel = await _context.Hotels.FindAsync(Hid);
            if (hotel != null)
            {
            _context.Hotels.Remove(hotel);
                await _context.SaveChangesAsync();
            }
        }

   

    public async Task UpdateHotel(Hotel hotel)
    {

        _context.Hotels.Update(hotel);
            await _context.SaveChangesAsync();
        }


  public async Task<List<Hotel>> GetHotelsByLocation(string location)
    {
        return await _context.Hotels.Where(h => h.Hlocation.Contains(location)).ToListAsync();
    }

    public async Task<List<Hotel>> GetHotelsByPrice(decimal minPrice, decimal maxPrice)
    {
        return await _context.Hotels.Where(h => h.Hprice >= minPrice && h.Hprice <= maxPrice).ToListAsync();
    }
}






