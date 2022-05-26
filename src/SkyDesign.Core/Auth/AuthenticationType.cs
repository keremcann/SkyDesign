using System;

namespace SkyDesign.Core.Auth
{
    [Serializable]
    public class AuthenticationType
    {
        public bool Success { get; set; }
        public string Value { get; set; }
    }
}
