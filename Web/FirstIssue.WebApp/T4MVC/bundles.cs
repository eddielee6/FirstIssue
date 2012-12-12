using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Links
{
    public static partial class bundles
    {
        public static partial class scripts
        {            
            public const string common = "~/Scripts/bundle-common";
            public const string jquery = "~/Scripts/bundle-jquery";            
        }

        public static partial class styles
        {
            public const string common = "~/content/stylesheets/bundle-css";
        }
    }
}