using Microsoft.EntityFrameworkCore;
using TourWebApi.Data;
using TourWebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TourWebApi.Repositories
{
     public class ProvinceRepository : IProvinceRepository
    {
        private readonly AppDbContext _context;

        public ProvinceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Province>> GetAllProvincesAsync()
        {
            return await _context.Provinces.ToListAsync();
        }

        public async Task<Province?> GetProvinceByIdAsync(int id)
        {
            return await _context.Provinces.FindAsync(id);
        }

        public async Task<Province> AddProvinceAsync(Province province)
        {
            _context.Provinces.Add(province);
            await _context.SaveChangesAsync();
            return province;
        }

        public async Task<Province?> UpdateProvinceAsync(Province province)
        {
            var existingProvince = await _context.Provinces.FindAsync(province.Id);
            if (existingProvince == null) return null;
            existingProvince.Name = province.Name;
            await _context.SaveChangesAsync();
            return existingProvince;
        }

        public async Task<bool> DeleteProvinceAsync(int id)
        {
            var province = await _context.Provinces.FindAsync(id);
            if (province == null) return false;
            _context.Provinces.Remove(province);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}