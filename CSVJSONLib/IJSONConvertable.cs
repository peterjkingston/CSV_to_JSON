﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVJSONLib
{
    public interface IJSONConvertable
    {
        JToken AsJObject();
    }
}
