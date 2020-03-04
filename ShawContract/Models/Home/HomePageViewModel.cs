using ShawContract.Application.Models;

namespace ShawContract.Models.Home
{
    public class HomePageViewModel : IViewModel
    {
        public HomePage HomePage { get; set; }

        public HomePageViewModel(HomePage homePage)
        {
            this.HomePage = homePage;
        }
    }
}