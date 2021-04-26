using System;
using System.Collections.Generic;
using System.Text;

namespace YouggySWLib.Model
{
    public class Symbol
    {
        public int IdSymbol { get; set; }

        public int IdExchange { get; set; }

        public string Name { get; set; }

        public bool Has_IntradayMSack { get; set; }

        public bool Has_EodMSack { get; set; }

        public string SymbolText { get; set; }
    }
}