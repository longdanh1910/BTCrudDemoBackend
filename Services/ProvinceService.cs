using System.Collections.Generic;
using System.Threading.Tasks;
using TourWebApi.Models;
using TourWebApi.Repositories;
using TourWebApi.DTOs;
using TourWebApi.Services;
 public class ProvinceService : IProvinceService
    {
        private readonly IProvinceRepository _provinceRepository;

        public ProvinceService(IProvinceRepository provinceRepository)
        {
            _provinceRepository = provinceRepository;
        }

        public async Task<IEnumerable<ProvinceDTO>> GetAllProvincesAsync()
        {
            var provinces = await _provinceRepository.GetAllProvincesAsync();
            return provinces.Select(p => new ProvinceDTO { Id = p.Id, Name = p.Name });
        }

        public async Task<ProvinceDTO?> GetProvinceByIdAsync(int id)
        {
            var province = await _provinceRepository.GetProvinceByIdAsync(id);
            return province != null ? new ProvinceDTO { Id = province.Id, Name = province.Name } : null;
        }

        public async Task<ProvinceDTO> AddProvinceAsync(ProvinceDTO provinceDto)
        {
            var province = new Province { Name = provinceDto.Name };
            var newProvince = await _provinceRepository.AddProvinceAsync(province);
            return new ProvinceDTO { Id = newProvince.Id, Name = newProvince.Name };
        }

        public async Task<ProvinceDTO?> UpdateProvinceAsync(int id, ProvinceDTO provinceDto)
        {
            var province = new Province { Id = id, Name = provinceDto.Name };
            var updatedProvince = await _provinceRepository.UpdateProvinceAsync(province);
            return updatedProvince != null ? new ProvinceDTO { Id = updatedProvince.Id, Name = updatedProvince.Name } : null;
        }

        public async Task<bool> DeleteProvinceAsync(int id)
        {
            return await _provinceRepository.DeleteProvinceAsync(id);
        }
    }