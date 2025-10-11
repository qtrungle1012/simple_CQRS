namespace StockApi.WebApi.Contracts.Common
{
    public enum ErrorCode
    {
        SUCCESS = 1000,
        VALIDATION_ERROR = 2000,
        NOT_FOUND = 2001,
        BUSINESS_ERROR = 2002,
        UNAUTHORIZED  = 401,
        FORBIDDEN = 403,
        INTERNAL_SERVER_ERROR = 500
    }
}