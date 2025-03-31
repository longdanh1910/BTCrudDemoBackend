using TourWebApi.Repositories;
using TourWebApi.Models;
namespace TourWebApi.Repositories
{
    public interface IProvinceRepository
    {
        Task<IEnumerable<Province>> GetAllProvincesAsync();
        Task<Province?> GetProvinceByIdAsync(int id);
        Task<Province> AddProvinceAsync(Province province);
        Task<Province?> UpdateProvinceAsync(Province province);
        Task<bool> DeleteProvinceAsync(int id);
    }
}