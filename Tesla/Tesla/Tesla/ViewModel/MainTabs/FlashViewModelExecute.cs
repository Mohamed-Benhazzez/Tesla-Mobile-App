﻿using Exrin.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeslaDefinition.Interfaces.Model;

namespace Tesla.ViewModel.MainTabs
{
    public class FlashViewModelExecute : BaseViewModelExecute
    {
        public FlashViewModelExecute(IControlModel model)
        {
            TimeoutMilliseconds = 10000;
            Operations.Add(new FlashOperation(model));
        }
    }
}
