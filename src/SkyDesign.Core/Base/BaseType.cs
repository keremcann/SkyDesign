﻿using System;

namespace SkyDesign.Core.Base
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseType
    {
        public bool Success { get; set; }
        public string InfoMessage { get; set; }
        public string ErrorMessage { get; set; }
    }
}
