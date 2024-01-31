﻿namespace PI.Application.Models.Responses
{
    public class BuyStockResponse
    {
        public BuyStockResponse(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
