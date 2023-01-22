using Zay.Entities.Concrets;

namespace Zay.Entities.DTOs.SettingDtos
{
    public class SettingGetDto
    {
        public string? Logo { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public List<SocialMedia> SocialMedias { get; set; }
        public List<SpecialService> SpecialServices { get; set; }
        public SettingGetDto()
        {
            SocialMedias = new();
            SpecialServices = new();
        }
    }
}
