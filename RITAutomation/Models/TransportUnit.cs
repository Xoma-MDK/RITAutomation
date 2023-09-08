using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RITAutomation.Models
{
    public class TransportUnit
    {
        public int Id;
        public string Name;
        public double Latitude;
        public double Longitude;

        public TransportUnit(int id, string name, double latitude, double longitude)
        {
            Id = id;
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
