using System;

namespace Core.CustomException
{
    public class RedisNotAvailableException : Exception
    {
        private string _errorCode = "431";

        public override string Message => "Redis is not available.";

        public string ErrorCode
        {
            get
            {
                return _errorCode;
            }
        }
    }
}
