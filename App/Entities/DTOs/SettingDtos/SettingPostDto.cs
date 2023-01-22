namespace Zay.Entities.DTOs.SettingDtos;

public class SettingPostDto
{
    public string Logo { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public List<string> SocialMediaLinks { get; set; }
    public List<string> SocialMediaIcons { get; set; }
    public List<int> SocialMediaIds { get; set; }
    public List<string> SpecialServiceNames { get; set; }
    public List<string> SpecialServiceLogos { get; set; }
    public List<int> SpecialServiceIds { get; set; }
    public SettingPostDto()
    {
        SocialMediaLinks = new();
        SocialMediaIcons = new();
        SpecialServiceNames = new();
        SpecialServiceLogos = new();
        SocialMediaIds = new();
        SpecialServiceIds = new();
    }
}
