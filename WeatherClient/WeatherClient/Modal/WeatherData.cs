using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherClient.Modal
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

    public class DataSaved
    {
        public bool Saved { get; set; }
    }
}
