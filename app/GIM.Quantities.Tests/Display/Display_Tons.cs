using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GIM.Quantities.Tests.Display
{
    public class Display_Tons : Display_Unit
    {
        public Display_Tons()
            : base(
                () => MassUnit.Tons,
                new DisplayForms("ton", "tons", "short ton", "short tons")
                ) { }
    }

}
