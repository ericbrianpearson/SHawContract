namespace ShawContract.Models.Errors
{
    public class ErrorPageViewModel : IViewModel
    {
        public int ErrorCode { get; set; }

        public string ErrorMessage { get; set; }

        public string InnerErrorMessage { get; set; }
    }
}