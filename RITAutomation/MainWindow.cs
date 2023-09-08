using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;
using GMap.NET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RITAutomation.Models;

namespace RITAutomation
{
    public partial class MainWindow : Form
    {
        GMapOverlay markersOverlay;
        GMapMarker dragMarker;
        GMapMarker markerUnderMouse;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            GMCMap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMCMap.MinZoom = 2;
            GMCMap.MaxZoom = 16;
            GMCMap.Zoom = 4;
            GMCMap.Position = new GMap.NET.PointLatLng(66.4169575018027, 94.25025752215694);
            GMCMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            GMCMap.CanDragMap = true;
            GMCMap.DragButton = MouseButtons.Left;
            GMCMap.ShowCenter = false;
            GMCMap.ShowTileGridLines = false;
            markersOverlay = new GMapOverlay("Маркеры");
            GMCMap.Overlays.Add(markersOverlay);
            CreateMarker(new TransportUnit(
                id: 0,
                name: "",
                latitude: 0.0,
                longitude: 0.0
                ));
        }

        public void CreateMarker(TransportUnit transport)
        {
            GMapMarker gMapMarker = new GMarkerGoogle(new PointLatLng(transport.Latitude, transport.Longitude), GMarkerGoogleType.blue_dot);
            markersOverlay.Markers.Add(gMapMarker);
            gMapMarker.ToolTipText = transport.Name;
        }

        private void GMCMap_OnMarkerEnter(GMapMarker item)
        {
            markerUnderMouse = item;
        }

        private void GMCMap_OnMarkerLeave(GMapMarker item)
        {
            markerUnderMouse = null;
        }

        private void GMCMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (markerUnderMouse == null)
                return;
            dragMarker = markerUnderMouse;
        }

        private void GMCMap_MouseUp(object sender, MouseEventArgs e)
        {
            if (dragMarker == null)
                return;
            var lat = GMCMap.FromLocalToLatLng(e.X, e.Y).Lat;
            var lng = GMCMap.FromLocalToLatLng(e.X, e.Y).Lng;
            dragMarker.Position = new PointLatLng(lat, lng);
            dragMarker = null;
        }

        private void GMCMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragMarker == null)
                return;
            var lat = GMCMap.FromLocalToLatLng(e.X, e.Y).Lat;
            var lng = GMCMap.FromLocalToLatLng(e.X, e.Y).Lng;
            dragMarker.Position = new PointLatLng(lat, lng);
        }

    }
}
