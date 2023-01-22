using Zay.Business.Services.Interfaces;
using Zay.DAL;
using Zay.DAL.Repository.Implementations;

namespace Zay.Business.Services.Implementations
{
    public class SettingService : SettingRepository, ISettingService
    {
        public SettingService(AppDbContext db) : base(db) { }
    }
}
