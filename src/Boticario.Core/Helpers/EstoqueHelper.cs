using System;
using System.Collections.Generic;
using System.Text;

namespace Boticario.Core.Helpers
{
    public static class EstoqueHelper
    {
        public static bool ValidaTipo(string tipo)
        {
            switch (tipo)
            {
                case "ECOMMERCE":
                    return true;
                case "PHYSICAL_STORE":
                    return true;
                default:
                    return false;
            }
        }
    }
}
