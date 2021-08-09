using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Security
{
    public class InvalidTokenException : Exception
    {
        private string _errorCode = "430";

        public override string Message => "Invalid Token Exception";

        public string ErrorCode => _errorCode;
    }
}
