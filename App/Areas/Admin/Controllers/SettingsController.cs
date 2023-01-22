using Microsoft.AspNetCore.Mvc;
using NuGet.Configuration;
using Zay.Business.Services.Interfaces;
using Zay.Entities.Concrets;
using Zay.Entities.DTOs.SettingDtos;

namespace Zay.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SettingsController : Controller
    {
        private readonly ISettingService _settingService;
        public SettingsController(ISettingService settingService)
        {
            _settingService = settingService;
        }

        public IActionResult Index()
        {
            SettingGetDto settingGet = new SettingGetDto()
            {
                Address = _settingService.GetAddress(),
                Email = _settingService.GetEmail(),
                Logo = _settingService.GetLogo(),
                PhoneNumber = _settingService.GetPhoneNumber(),
                SocialMedias = _settingService.GetSocialMedias(),
                SpecialServices = _settingService.GetSpecialServices()
            };
            return View(settingGet);
        }
        public IActionResult Update()
        {
            SettingUpdateDto settingUpdate = new()
            {
                settingGet = new SettingGetDto()
                {
                    Address = _settingService.GetAddress(),
                    Email= _settingService.GetEmail(),
                    Logo= _settingService.GetLogo(),
                    PhoneNumber= _settingService.GetPhoneNumber(),
                    SocialMedias= _settingService.GetSocialMedias(),
                    SpecialServices = _settingService.GetSpecialServices()
                }
            };
            return View(settingUpdate);
        }
    }
}
