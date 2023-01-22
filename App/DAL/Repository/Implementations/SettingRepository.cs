using Microsoft.EntityFrameworkCore;
using Zay.DAL.Repository.Interfaces;
using Zay.Entities.Concrets;

namespace Zay.DAL.Repository.Implementations
{
    public class SettingRepository : ISettingRepository
    {
        private readonly AppDbContext _db;
        public SettingRepository(AppDbContext db)
        {
            _db = db;
        }

        public string GetAddress()
        => _db.Settings.FirstOrDefault().Address;

        public string GetEmail()
         => _db.Settings.FirstOrDefault().Email;

        public string GetLogo()
        => _db.Settings.FirstOrDefault().Logo;

        public string GetPhoneNumber()
       => _db.Settings.FirstOrDefault().PhoneNumber;

        public List<SocialMedia> GetSocialMedias()
        => _db.Settings.Include(s=>s.SocialMedias).FirstOrDefault().SocialMedias;

        public List<SpecialService> GetSpecialServices()
        => _db.Settings.Include(s=>s.SpecialServices).FirstOrDefault().SpecialServices;

        public Task Update()
        {
            throw new NotImplementedException();
        }
    }
}
