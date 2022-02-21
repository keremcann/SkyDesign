using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkyDesign.Core.Base
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public abstract class BaseType
    {
        [NotMapped]
        public bool Success { get; set; }
        [NotMapped]
        public string InfoMessage { get; set; }
        [NotMapped]
        public string ErrorMessage { get; set; }
    }
}
