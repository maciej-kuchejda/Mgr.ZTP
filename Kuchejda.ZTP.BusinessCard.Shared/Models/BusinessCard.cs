namespace Kuchejda.ZTP.BusinessCard.Shared.Models
{
    public class BusinessCard : BusinessCardDTO
    {
        public BusinessCard(BusinessCardDTO cardDto)
        {
            FirstName= cardDto.FirstName;
            LastName= cardDto.LastName;
            Telephone= cardDto.Telephone;
            Email= cardDto.Email;
            WebSite= cardDto.WebSite;
            Company = cardDto.Company;
        }

        public int Id { get; set; }
    }
}
