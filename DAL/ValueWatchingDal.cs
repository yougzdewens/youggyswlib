using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Tools;
using YouggySWLib.Model;

namespace YouggySWLib.DAL
{
    public class ValueWatchingDal
    {
        private DatabaseSQLServerManagerTools dbManager = new DatabaseSQLServerManagerTools();

        public void Insert(ValueWatching valueWatching)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("IdSymbol", valueWatching.IdSymbol);
            parameters.Add("BuyOrSell", valueWatching.BuyOrSell);

            dbManager.InsertStoredProcedure("usp_Values_WatchingInsert", parameters);
        }

        public void Remove(ValueWatching valueWatching)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("Id", valueWatching.Id);

            dbManager.InsertStoredProcedure("usp_Values_WatchingDelete", parameters);
        }

        public void RemoveBySymbol(ValueWatching valueWatching)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("IdSymbol", valueWatching.IdSymbol);

            dbManager.InsertStoredProcedure("usp_Values_WatchingDeleteBySymbol", parameters);
        }

        public DataTable GetAllValueWatchings()
        {
            return dbManager.SelectStoredProcedure("usp_Values_WatchingSelectAll", new Dictionary<string, object>());
        }

        public DataTable GetValueWatching(int id)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("Id", id);

            return dbManager.SelectStoredProcedure("usp_Values_WatchingSelect", parameters);
        }
    }
}
