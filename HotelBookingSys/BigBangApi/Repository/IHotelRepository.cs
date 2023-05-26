using BigBangApi.Models;


namespace BigBangApi.Repository
{
    public interface IHotelRepository
    {



        Task<List<Hotel>> GetAllHotels();
        Task<Hotel> GetHotelById(int Hid);
        Task AddHotel(Hotel hotel);
        Task UpdateHotel(Hotel hotel);
        Task DeleteHotel(int Hid);
        Task<List<Hotel>> GetHotelsByLocation(string location);
        Task<List<Hotel>> GetHotelsByPrice(decimal minPrice, decimal maxPrice);
    }
}
