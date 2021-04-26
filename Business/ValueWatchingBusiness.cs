using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Tools;
using YouggySWLib.DAL;
using YouggySWLib.Model;

namespace YouggySWLib.Business
{
    public class ValueWatchingBusiness
    {
        private ValueWatchingDal valueWatchingDal = new ValueWatchingDal();

        public void Insert(ValueWatching valueWatching)
        {
            valueWatchingDal.Insert(valueWatching);
        }

        public List<ValueWatching> GetAllValueWatchings()
        {
            DataTable getAllValueWatchings = valueWatchingDal.GetAllValueWatchings();

            List<ValueWatching> valuesWatching = new List<ValueWatching>();

            foreach (DataRow valueWatchingRow in getAllValueWatchings.Rows)
            {
                ValueWatching valueWatching = new ValueWatching();
                valueWatching.Id = int.Parse(valueWatchingRow["Id"].ToString());
                valueWatching.IdSymbol = int.Parse(valueWatchingRow["IdSymbol"].ToString());
                valueWatching.BuyOrSell = valueWatchingRow["BuyOrSell"].ToString();
                valueWatching.DateCreation = DateTime.Parse(valueWatchingRow["DateCreation"].ToString());

                valuesWatching.Add(valueWatching);
            }

            return valuesWatching;
        }

        public ValueWatching GetValueWatching(int id)
        {
            DataTable getValueWatchings = valueWatchingDal.GetValueWatching(id);

            List<ValueWatching> valuesWatching = new List<ValueWatching>();

            foreach (DataRow valueWatchingRow in getValueWatchings.Rows)
            {
                ValueWatching valueWatching = new ValueWatching();
                valueWatching.Id = int.Parse(valueWatchingRow["Id"].ToString());
                valueWatching.IdSymbol = int.Parse(valueWatchingRow["IdSymbol"].ToString());
                valueWatching.BuyOrSell = valueWatchingRow["BuyOrSell"].ToString();
                valueWatching.DateCreation = DateTime.Parse(valueWatchingRow["DateCreation"].ToString());

                return valueWatching;
            }

            return null;
        }        

        public void Remove(ValueWatching valueWatching)
        {
            valueWatchingDal.Remove(valueWatching);
        }

        public void RemoveBySymbol(ValueWatching valueWatching)
        {
            valueWatchingDal.RemoveBySymbol(valueWatching);
        }
    }
}
