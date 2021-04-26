using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Tools;
using YouggySWLib.Model;

namespace YouggySWLib.DAL
{
    public class ExchangeDal
    {
        /// <summary>
        /// The database manager
        /// </summary>
        private DatabaseSQLServerManagerTools dbManager = new DatabaseSQLServerManagerTools();

        public DataTable GetExchange(string exchangeMic)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("ExchangeMic", exchangeMic);

            return dbManager.SelectStoredProcedure("usp_ExchangesSelectWithMic", parameters);
        }

        internal DataTable InsertExchange(Exchange exchangeModel)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("Name", exchangeModel.Name);
            parameters.Add("Acronym", exchangeModel.Acronym);
            parameters.Add("Country", exchangeModel.Country);
            parameters.Add("Mic", exchangeModel.Mic);
            parameters.Add("Country_Code", exchangeModel.Country_Code);
            parameters.Add("City", exchangeModel.City);
            parameters.Add("Website", exchangeModel.Website);

            return dbManager.SelectStoredProcedure("usp_ExchangesInsert", parameters);
        }

        internal DataTable GetExchangeById(int idExchange)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("IdExchange", idExchange);

            return dbManager.SelectStoredProcedure("usp_ExchangesSelect", parameters);
        }
    }
}
