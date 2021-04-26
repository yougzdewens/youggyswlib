using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using YouggySWLib.DAL;
using YouggySWLib.Model;

namespace YouggySWLib.Business
{
    public class ExchangeBusiness
    {
        private ExchangeDal exchangeDal = new ExchangeDal();

        public Model.Exchange GetExchange(string exchangeMic)
        {
            DataTable table = exchangeDal.GetExchange(exchangeMic);

            foreach (DataRow dayValueRow in table.Rows)
            {
                Model.Exchange exchangeModel = new Model.Exchange();
                exchangeModel.IdExchange = int.Parse(dayValueRow["IdExchange"].ToString());
                exchangeModel.Name = dayValueRow["Name"].ToString();
                exchangeModel.Acronym = dayValueRow["Acronym"].ToString();
                exchangeModel.Country = dayValueRow["Country"].ToString();
                exchangeModel.Mic = dayValueRow["Mic"].ToString();
                exchangeModel.Country_Code = dayValueRow["Country_Code"].ToString();
                exchangeModel.City = dayValueRow["City"].ToString();
                exchangeModel.Website = dayValueRow["Website"].ToString();

                return exchangeModel;
            }

            return null;
        }

        public int InsertExchange(Model.Exchange exchangeModel)
        {
            DataTable table = exchangeDal.InsertExchange(exchangeModel);

            foreach (DataRow dayValueRow in table.Rows)
            {
                return int.Parse(dayValueRow["IdExchange"].ToString());
            }

            return -1;
        }

        public Exchange GetExchangeById(int idExchange)
        {
            DataTable table = exchangeDal.GetExchangeById(idExchange);

            foreach (DataRow dayValueRow in table.Rows)
            {
                Model.Exchange exchangeModel = new Model.Exchange();
                exchangeModel.IdExchange = int.Parse(dayValueRow["IdExchange"].ToString());
                exchangeModel.Name = dayValueRow["Name"].ToString();
                exchangeModel.Acronym = dayValueRow["Acronym"].ToString();
                exchangeModel.Country = dayValueRow["Country"].ToString();
                exchangeModel.Mic = dayValueRow["Mic"].ToString();
                exchangeModel.Country_Code = dayValueRow["Country_Code"].ToString();
                exchangeModel.City = dayValueRow["City"].ToString();
                exchangeModel.Website = dayValueRow["Website"].ToString();

                return exchangeModel;
            }

            return null;
        }
    }
}
