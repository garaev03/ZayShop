namespace Zay.Entities.Concrets
{
    public class Setting
    {
        public int Id { get; set; }
        public string Logo { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<SocialMedia> SocialMedias { get; set; }
        public List<SpecialService> SpecialServices { get; set; }
        public Setting()
        {
            SocialMedias = new();
            SpecialServices = new();
        }
    }
}
