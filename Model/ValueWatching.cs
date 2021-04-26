using System;
using System.Collections.Generic;
using System.Text;

namespace YouggySWLib.Model
{
    public class ValueWatching
    {
        public int Id { get; set; }

        public int IdSymbol { get; set; }

        public string BuyOrSell { get; set; }

        public DateTime DateCreation { get; set; }
    }
}
