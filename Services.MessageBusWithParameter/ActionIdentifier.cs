﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.MessageBusWithParameter
{
    public class ActionIdentifier
    {
        public WeakReferenceAction Action { get; set; }
        public string IdentificationCode { get; set; }
    }
}