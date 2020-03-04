using System.Collections.Generic;

namespace ShawContract.Models.Product
{
    public static class TrycicleInstallsParameters
    {
        public static Dictionary<string, int> ParametersMapping => new Dictionary<string, int> {
            {"stagger9x36", 72},
            {"parquet9x36" , 83},
            {"monolithic9x36", 14},
            {"herringbone9x36",17},
            {"brick9x36", 15},
            {"ashlar9x36", 16},
            {"herringbone6x48", 81},
            {"random24x24", 6},
            {"quarterturn24x24", 2},
            {"monolithic24x24", 5},
            {"brick24x24", 18},
            {"ashlar24x24", 19},
            {"stagger18x36", 74},
            {"random18x36", 80},
            {"monolithic18x36", 56},
            {"herringbone18x36", 48},
            {"halfbasketweave18x36", 49},
            {"boxedin18x36", 51},
            {"basketweave18x36", 47},
            {"ashlar18x36", 57},
            {"herringbone12x24", 82}
        };
    }
}