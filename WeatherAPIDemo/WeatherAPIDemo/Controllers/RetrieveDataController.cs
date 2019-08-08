using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WeatherAPIDemo.Config;
using WeatherAPIDemo.Models;

namespace WeatherAPIDemo.Controllers
{
    public class RetrieveDataController : ApiController
    {
        // POST: api/SendDataCel
        public SendAllData Post([FromBody] GetData Gdata)
        {
            DataSet ds = new Connections().GetAllData(Gdata.Date, Gdata.Type);
            SendAllData psd = new SendAllData()
            {
                HighTemp = Convert.ToDecimal(ds.Tables[0].Rows[0][0].ToString()),
                LowTemp = Convert.ToDecimal(ds.Tables[0].Rows[0][1].ToString()),
                AvgTemp = Convert.ToDecimal(ds.Tables[0].Rows[0][2].ToString()),
                HighHum = Convert.ToDecimal(ds.Tables[0].Rows[0][3].ToString()),
                LowHum = Convert.ToDecimal(ds.Tables[0].Rows[0][4].ToString()),
                AvgHum = Convert.ToDecimal(ds.Tables[0].Rows[0][5].ToString()),
                HighPres = Convert.ToDecimal(ds.Tables[0].Rows[0][6].ToString()),
                LowPres = Convert.ToDecimal(ds.Tables[0].Rows[0][7].ToString()),
                AvgPres = Convert.ToDecimal(ds.Tables[0].Rows[0][8].ToString())
            };
            return psd;
        }
    }
}

