namespace PI.Application.Models.Responses
{
    public class CashWithdrawalResponse
    {
        public CashWithdrawalResponse(bool isSuccess, string message = null)
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
