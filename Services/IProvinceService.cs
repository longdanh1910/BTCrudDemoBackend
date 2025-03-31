using TourWebApi.Repositories;
using TourWebApi.Models;
using TourWebApi.DTOs;
namespace TourWebApi.Services
{
    public interface IProvinceService
    {
        Task<IEnumerable<ProvinceDTO>> GetAllProvincesAsync();
        Task<ProvinceDTO?> GetProvinceByIdAsync(int id);
        Task<ProvinceDTO> AddProvinceAsync(ProvinceDTO provinceDto);
        Task<ProvinceDTO?> UpdateProvinceAsync(int id, ProvinceDTO provinceDto);
        Task<bool> DeleteProvinceAsync(int id);
    }
}