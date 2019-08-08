using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WeatherAPIDemo.Config;
using WeatherAPIDemo.Models;

namespace WeatherAPIDemo.Controllers
{
    public class SendDataFraController : ApiController
    {
        // POST: api/SendDataFra
        public DataSaved Post([FromBody] WeatherDataFra Wdata)
        {
            DataSaved ds;
            try
            {
                int TempInFra = Wdata.TempFra;
                int TempInCel = (TempInFra - 32) * 5 / 9;
                string query = "insert into [data] values (" + TempInFra + ", " + TempInCel + ", " + Wdata.Humidity + ", " + Wdata.BroPres + ", GETDATE());";
                if (new Connections().ExeCmd(query))
                {
                    ds = new DataSaved() { Saved = true };
                }
                else
                {
                    ds = new DataSaved() { Saved = false };
                }
                return ds;
            }
            catch(Exception ex)
            {
                ds = new DataSaved() { Saved = false };
                return ds;
            }
        }
    }
}
