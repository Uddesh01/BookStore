﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.Model
{
    public class ResponceModel<T>
    {
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
