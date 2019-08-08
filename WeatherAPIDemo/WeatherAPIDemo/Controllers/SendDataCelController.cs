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
    public class SendDataCelController : ApiController
    {
        
        // POST: api/SendDataCel
        public DataSaved Post([FromBody]WeatherDataCel Wdata)
        {
            DataSaved ds;
            try
            {
                int TempInCel = Wdata.TempCel;
                int TempInFra = (TempInCel * 9 / 5) + 32;
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
            catch (Exception ex)
            {
                ds = new DataSaved() { Saved = false };
                return ds;
            }
        }
    }
}
