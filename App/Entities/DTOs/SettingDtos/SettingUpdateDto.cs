namespace Zay.Entities.DTOs.SettingDtos;

public class SettingUpdateDto
{
    public SettingGetDto settingGet { get; set; }
    public SettingPostDto settingPost { get; set; }
    public SettingUpdateDto()
    {
        settingGet = new();
        settingPost = new();
    }
}
