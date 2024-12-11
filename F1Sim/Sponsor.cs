using System.Security.Cryptography;

namespace SponsorSpace
{
    public class Sponsor
    {
        public string companyName { get; set; }
        public CompanyType companyType { get; set; }
        public int revenue { get; set; } //In tenthounands

        public Sponsor(string companyName, CompanyType type, int revenue)
        {
            this.companyName = companyName;
            this.companyType = companyType;
            this.revenue = revenue;
        }
    }

    public enum CompanyType { Retail, OilNGas, Clothes, Mobile, ComputerParts, VideoGames, VideoFilm, SocialMedia, Computers, Toys, Planes, Resturants, Logistics, Travling, Food, Finance }
}