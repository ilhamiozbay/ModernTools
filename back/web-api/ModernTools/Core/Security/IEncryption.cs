using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Security
{
    public interface IEncryption
    {
        string EncryptText(string text, string privateKey = "");
        string DecryptText(string text, string privateKey = "");
    }
}
