
using System;
using System.Collections.Generic;
using System.Linq;
using PlatformService.Models;

namespace PlatformService.Data
{
    public class PlatformRepo : IPlatformRepo
    {
        private readonly AppDbContext _context;

        public PlatformRepo(AppDbContext context)
        {
            _context = context;
        }
        public void CreatePlatform(Platform platform)
        {
            if(platform != null)
            {
                _context.Platforms.Add(platform);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Platform can not be empty");
            }
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _context.Platforms.OrderBy(p => p.Id);
        }

        public Platform GetPlatformById(int id)
        {
            return _context.Platforms.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}