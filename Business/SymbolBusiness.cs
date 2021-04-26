using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using YouggySWLib.DAL;

namespace YouggySWLib.Business
{
    public class SymbolBusiness
    {
        private SymbolDal dayValuesDal = new SymbolDal();

        // TODO FAIRE ECHANGE DANS AUTRES PROJETS
        public List<Model.Symbol> GetSymbol(string symbol, string exchangeMic = "")
        {
            DataTable table = dayValuesDal.GetSymbole(symbol, exchangeMic);

            List<Model.Symbol> symbols = new List<Model.Symbol>();

            foreach (DataRow dayValueRow in table.Rows)
            {
                Model.Symbol symbolModel = new Model.Symbol();
                symbolModel.IdExchange = int.Parse(dayValueRow["IdExchange"].ToString());
                symbolModel.IdSymbol = int.Parse(dayValueRow["IdSymbole"].ToString());
                symbolModel.Name = dayValueRow["Name"].ToString();
                symbolModel.Has_EodMSack = bool.Parse(dayValueRow["Has_EodMSack"].ToString());
                symbolModel.Has_IntradayMSack = bool.Parse(dayValueRow["Has_IntradayMSack"].ToString());
                symbolModel.SymbolText = dayValueRow["Symbol"].ToString();

                symbols.Add(symbolModel);
            }

            return symbols;
        }

        public List<Model.Symbol> GetSymbolById(int idSymbol)
        {
            DataTable table = dayValuesDal.GetSymbolById(idSymbol);

            List<Model.Symbol> symbols = new List<Model.Symbol>();

            foreach (DataRow dayValueRow in table.Rows)
            {
                Model.Symbol symbolModel = new Model.Symbol();
                symbolModel.IdExchange = int.Parse(dayValueRow["IdExchange"].ToString());
                symbolModel.IdSymbol = int.Parse(dayValueRow["IdSymbole"].ToString());
                symbolModel.Name = dayValueRow["Name"].ToString();
                symbolModel.Has_EodMSack = bool.Parse(dayValueRow["Has_EodMSack"].ToString());
                symbolModel.Has_IntradayMSack = bool.Parse(dayValueRow["Has_IntradayMSack"].ToString());
                symbolModel.SymbolText = dayValueRow["Symbol"].ToString();

                symbols.Add(symbolModel);
            }

            return symbols;
        }

        public float GetPercentageValueFor(int nbDayBefore, int idSymbol)
        {
            DataTable table = dayValuesDal.GetPercentageValueFor(DateTime.Now.AddDays(nbDayBefore*-1), idSymbol);

            foreach (DataRow dayValueRow in table.Rows)
            {
                return float.Parse(dayValueRow["percentage"].ToString());
            }

            return 0;
        }

        public void InsertSymbol(Model.Symbol symbolModel)
        {
            dayValuesDal.InsertSymbol(symbolModel);
        }
    }
}
