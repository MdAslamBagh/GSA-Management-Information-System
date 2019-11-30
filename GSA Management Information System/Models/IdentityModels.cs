using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace GSA_Management_Information_System.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
       
        public string Status { get; internal set; }
        public string FullName { get; internal set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            userIdentity.AddClaim(new Claim("GSA_Management_Information_System.Models.RegisterViewModel.UserName", UserName));
            userIdentity.AddClaim(new Claim("GSA_Management_Information_System.Models.RegisterViewModel.Email", Email));
            // Add custom user claims here


            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("ApplicationDbContext")
        {
        }
        public System.Data.Entity.DbSet<GSA_Management_Information_System.Models.CompanyInformation> CompanyInformations { get; set; }
        public System.Data.Entity.DbSet<GSA_Management_Information_System.Models.UserInformation> UserInformations { get; set; }
        public System.Data.Entity.DbSet<GSA_Management_Information_System.Models.CustomerTypeInformation> CustomerTypeInformations { get; set; }
        public System.Data.Entity.DbSet<GSA_Management_Information_System.Models.Employee> Employees { get; set; }

        public System.Data.Entity.DbSet<GSA_Management_Information_System.Models.CustomerGroupInformation> CustomerGroupInformations { get; set; }

        public System.Data.Entity.DbSet<GSA_Management_Information_System.Models.ConsigneeInformation> ConsigneeInformations { get; set; }
        public System.Data.Entity.DbSet<GSA_Management_Information_System.Models.ConsignorInformation> ConsignorInformations { get; set; }

        public System.Data.Entity.DbSet<GSA_Management_Information_System.Models.OriginInformation> OriginInformations { get; set; }

        public System.Data.Entity.DbSet<GSA_Management_Information_System.Models.CargoTypeInformation> CargoTypeInformations { get; set; }

        public System.Data.Entity.DbSet<GSA_Management_Information_System.Models.AirlinesInformation> AirlinesInformations { get; set; }

        public System.Data.Entity.DbSet<GSA_Management_Information_System.Models.CargoFreightPaymodeInformation> CargoFreightPaymodeInformations { get; set; }

        public System.Data.Entity.DbSet<GSA_Management_Information_System.Models.PaymentModeInformation> PaymentModeInformations { get; set; }

        public System.Data.Entity.DbSet<GSA_Management_Information_System.Models.CurrencyInformation> CurrencyInformations { get; set; }

        public System.Data.Entity.DbSet<GSA_Management_Information_System.Models.StockTypeInformation> StockTypeInformations { get; set; }

        public System.Data.Entity.DbSet<GSA_Management_Information_System.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<GSA_Management_Information_System.Models.UplimentTypeInformation> UplimentTypeInformations { get; set; }

        public System.Data.Entity.DbSet<GSA_Management_Information_System.Models.FreighterInformation> FreighterInformations { get; set; }

        public System.Data.Entity.DbSet<GSA_Management_Information_System.Models.RouteInformation> RouteInformations { get; set; }

        public System.Data.Entity.DbSet<GSA_Management_Information_System.Models.ExchangeInformation> ExchangeInformations { get; set; }

        public System.Data.Entity.DbSet<GSA_Management_Information_System.Models.ContinentInformation> ContinentInformations { get; set; }

        public System.Data.Entity.DbSet<GSA_Management_Information_System.Models.CountryInformation> CountryInformations { get; set; }

        public System.Data.Entity.DbSet<GSA_Management_Information_System.Models.CityInformation> CityInformations { get; set; }

        public System.Data.Entity.DbSet<GSA_Management_Information_System.Models.DestinationInformation> DestinationInformations { get; set; }

        public System.Data.Entity.DbSet<GSA_Management_Information_System.Models.CustomerInformation> CustomerInformations { get; set; }

        public System.Data.Entity.DbSet<GSA_Management_Information_System.Models.CommonSetupInformation> CommonSetupInformations { get; set; }

        public System.Data.Entity.DbSet<GSA_Management_Information_System.Models.StockRecieveInformation> StockRecieveInformations { get; set; }

        public System.Data.Entity.DbSet<GSA_Management_Information_System.Models.StockIssueInformation> StockIssueInformations { get; set; }

        public System.Data.Entity.DbSet<GSA_Management_Information_System.Models.StockIssueDetailInformations> StockIssueDetailInformations { get; set; }

        public System.Data.Entity.DbSet<GSA_Management_Information_System.Models.StockIssueConfirmation> StockIssueConfirmations { get; set; }

        public System.Data.Entity.DbSet<GSA_Management_Information_System.Models.CargoSalesInformation> CargoSalesInformations { get; set; }

        public System.Data.Entity.DbSet<GSA_Management_Information_System.Models.BaseModuleInformation> BaseModuleLists { get; set; }

        public System.Data.Entity.DbSet<GSA_Management_Information_System.Models.AccessListInformation> AccessLists { get; set; }

        public System.Data.Entity.DbSet<GSA_Management_Information_System.Models.LoginInformation> LoginInformations { get; set; }

        public System.Data.Entity.DbSet<GSA_Management_Information_System.Models.TicketSalesInformation> TicketSalesInformations { get; set; }

        public System.Data.Entity.DbSet<GSA_Management_Information_System.Models.Cargo_Debit_Credit_Note> Cargo_Debit_Credit_Note { get; set; }
        public System.Data.Entity.DbSet<GSA_Management_Information_System.Models.BankInformation> BankInformations { get; set; }
        public System.Data.Entity.DbSet<GSA_Management_Information_System.Models.CourierInboundSalesInformation> CourierInboundSalesInformations { get; set; }
        public System.Data.Entity.DbSet<GSA_Management_Information_System.Models.CourierOutboundSalesInformation> CourierOutboundSalesInformations { get; set; }
        public System.Data.Entity.DbSet<GSA_Management_Information_System.Models.AccessInformation> AccessInformations { get; set; }
        public System.Data.Entity.DbSet<GSA_Management_Information_System.Models.MenuItemInformation> MenuInformations { get; set; }
        public System.Data.Entity.DbSet<GSA_Management_Information_System.Models.SubMenuInformation> SubMenuInformations { get; set; }




        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<GSA_Management_Information_System.Models.EditUserViewModel> EditUserViewModels { get; set; }
    }
}




    