using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RITAutomation.Models
{
    public class TransportUnit
    {
        public int? Id;
        public string Name;
        public double Latitude;
        public double Longtitude;

        public TransportUnit(int id, string name, double latitude, double longtitude)
        {
            Id = id;
            Name = name;
            Latitude = latitude;
            Longtitude = longtitude;
        }
        public TransportUnit( string name, double latitude, double longtitude)
        {
            Id = null;
            Name = name;
            Latitude = latitude;
            Longtitude = longtitude;
        }
    }
}
