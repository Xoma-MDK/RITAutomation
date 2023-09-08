using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;
using GMap.NET;
using RITAutomation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RITAutomation.Services
{
    public class MarkersService
    {
        public static GMapMarker CreateMarker(TransportUnit transport)
        {
            GMapMarker gMapMarker = new GMarkerGoogle(new PointLatLng(transport.Latitude, transport.Longtitude), GMarkerGoogleType.blue_dot)
            {
                ToolTipText = transport.Name
            };
            return gMapMarker;
        }
        public static List<GMapMarker> CreateMarkers(List<TransportUnit> transports)
        {
            List<GMapMarker> markers = new List<GMapMarker>();
            foreach (var transport in transports)
            {
                GMapMarker gMapMarker = new GMarkerGoogle(new PointLatLng(transport.Latitude, transport.Longtitude), GMarkerGoogleType.blue_dot)
                {
                    ToolTipText = transport.Name
                };
                markers.Add(gMapMarker);
            }

            return markers;
        }

        public static void AddMarkersToOverlay(ref GMapOverlay markersOverlay, List<GMapMarker> markers)
        {
            foreach (var marker in markers)
            {
                markersOverlay.Markers.Add(marker);
            }
        }

        public static void UpdateMarkerInDB(GMapMarker marker)
        {
            TransportService.UpdateTransportUnit(new TransportUnit(
                name:marker.ToolTipText,
                latitude:marker.Position.Lat,
                longtitude:marker.Position.Lng));
        }
    }
}
