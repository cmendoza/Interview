﻿using System;

namespace Interview.Web.Utils
{
    public class Envelope<T>
    {
        public T        Result        { get; set; }
        public string   ErrorMessage  { get; set; }
        public DateTime TimeGenerated { get; set; }
        public bool HasError { get; set; }
    }
}
