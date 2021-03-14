using System.Collections.Generic;

namespace Учёт_аренды.Models
{
    public enum ClsRoots
    {
        ClsRoot = 0,
        GaugeResourceType = 1,
        SubjectType = 2,
        PaymentPurpose = 3
    }
    interface IClsItem
    {
        ClsRoots Root { get; set; }
        string Name { get; set; }
    }
}
