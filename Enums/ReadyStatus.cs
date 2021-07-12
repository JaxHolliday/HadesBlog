using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace HadesBlog.Enums
{
    public enum ReadyStatus
    {
        [Description("Incomplete")]
        Incomplete,
        [Description("Production Ready")]
        ProductionReady, 
        [Description("Preview Ready")]
        PreviewReady
    }
}
