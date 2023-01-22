using Zay.Entities.Concrets;

namespace Zay.DAL.Repository.Interfaces
{
    public interface ISettingRepository
    {
        string GetLogo();
        string GetAddress();
        string GetPhoneNumber();
        string GetEmail();
        Task Update();
        List<SocialMedia> GetSocialMedias();
        List<SpecialService> GetSpecialServices();
    }
}
