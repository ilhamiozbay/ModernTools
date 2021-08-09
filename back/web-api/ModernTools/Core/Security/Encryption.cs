using Core.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Security
{
    public class Encryption : IEncryption
    {
        public readonly IOptions<ModernToolsConfig> _modernToolsConfig;

        public Encryption(IOptions<ModernToolsConfig> modernToolsConfig)
        {
            _modernToolsConfig = modernToolsConfig;
        }

        public string DecryptText(string text, string privateKey = "")
        {
            throw new NotImplementedException();
        }

        public string EncryptText(string text, string privateKey = "")
        {
            throw new NotImplementedException();
        }
    }
}
