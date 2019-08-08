using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAPIDemo.Models
{
    public class WeatherDataFra
    {
        public int TempFra { get; set; }
        public int Humidity { get; set; }
        public int BroPres { get; set; }
    }


    public class WeatherDataCel
    {
        public int TempCel { get; set; }
        public int Humidity { get; set; }
        public int BroPres { get; set; }
    }

    public class GetData
    {
        public string Type { get; set; }
        public DateTime Date { get; set; }
    }

    public class SendAllData
    {
        public decimal HighTemp { get; set; }
        public decimal LowTemp { get; set; }
        public decimal AvgTemp { get; set; }
        public decimal HighHum { get; set; }
        public decimal LowHum { get; set; }
        public decimal AvgHum { get; set; }
        public decimal HighPres { get; set; }
        public decimal LowPres { get; set; }
        public decimal AvgPres { get; set; }
    }

    public class DataSaved
    {
        public bool Saved { get; set; }
    }
}
