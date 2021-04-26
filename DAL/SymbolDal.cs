using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Tools;
using YouggySWLib.Model;

namespace YouggySWLib.DAL
{
    public class SymbolDal
    {
        /// <summary>
		/// The database manager
		/// </summary>
		private DatabaseSQLServerManagerTools dbManager = new DatabaseSQLServerManagerTools();

        public DataTable GetSymbole(string symbol, string exchangeMic)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            if (exchangeMic != string.Empty)
            {
                parameters.Add("ExchangeMic", exchangeMic);
            }

            parameters.Add("Symbol", symbol);

            return dbManager.SelectStoredProcedure("usp_SymbolesSelectWithName", parameters);
        }

        internal void InsertSymbol(Symbol symbolModel)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("IdExchange", symbolModel.IdExchange);
            parameters.Add("Name", symbolModel.Name);
            parameters.Add("Has_IntradayMSack", symbolModel.Has_IntradayMSack);
            parameters.Add("Has_EodMSack", symbolModel.Has_EodMSack);
            parameters.Add("Symbol", symbolModel.SymbolText);

            dbManager.InsertStoredProcedure("usp_SymbolesInsert", parameters);
        }

        internal DataTable GetPercentageValueFor(DateTime dateToSearch, int idSymbol)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("IdSymbol", idSymbol);
            parameters.Add("DateToSearch", dateToSearch);

            return dbManager.SelectStoredProcedure("usp_SymbolesSelectPercentageVariationBetweenADayAndNow", parameters);
        }

        internal DataTable GetSymbolById(int idSymbol)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("IdSymbole", idSymbol);

            return dbManager.SelectStoredProcedure("usp_SymbolesSelect", parameters);
        }
    }
}
