using System;

namespace SkyDesign.Core.Base
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CommonResponse<T> : BaseType
    {
        public T Value { get; set; }
    }
}
