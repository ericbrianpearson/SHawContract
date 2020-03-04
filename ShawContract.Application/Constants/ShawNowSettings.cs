namespace ShawContract.Application.Constants
{
    public static class ShawNowSettings
    {
        public static readonly string StockCheckPrivateCode = "PHS";
        public static readonly string StockCheckApplicationID = "SCWS";
        public static readonly string StockCheckCustomerNumber = "0227428"; //confirmed
        public static readonly string StockCheckLocation = "01"; //check
        public static readonly string StockCheckCustomerReferenceNumber = "102"; //confirmed
        public static readonly string StockCheckProductType = "A";//confirmed
        public static readonly string StockCheckUserID = "vpetrov"; //confirmed
        public static readonly string StockFunction = "LIST";

        public static readonly int OrderAccountNumberUS = 2006; //default number for US
        public static readonly string OrderRequester = "SCG"; // order requester provided by Shaw
        public static readonly string OrderUserName = "FluidMedia";
        public static readonly string OrderPassword = "shaw2013";
    }
}