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

namespace RITAutomation
{
    public partial class Form1 : Form
    {
        GMapOverlay markersOverlay;
        GMapMarker dragMarker;
        GMapMarker markerUnderMouse;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            gMapControl1.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            gMapControl1.MinZoom = 2;
            gMapControl1.MaxZoom = 16;
            gMapControl1.Zoom = 4;
            gMapControl1.Position = new GMap.NET.PointLatLng(66.4169575018027, 94.25025752215694);
            gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            gMapControl1.CanDragMap = true;
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.ShowCenter = false;
            gMapControl1.ShowTileGridLines = false;
            markersOverlay = new GMapOverlay("Маркеры");
            gMapControl1.Overlays.Add(markersOverlay);
            CreateMarker(22, 22, "Точка");
        }

        public void CreateMarker(double x, double y, string desc)
        {
            GMapMarker gMapMarker = new GMarkerGoogle(new PointLatLng(x, y), GMarkerGoogleType.blue_dot);
            markersOverlay.Markers.Add(gMapMarker);
            gMapMarker.ToolTipText = desc;
        }

        private void gMapControl1_OnMarkerEnter(GMapMarker item)
        {
            markerUnderMouse = item;
        }

        private void gMapControl1_OnMarkerLeave(GMapMarker item)
        {
            markerUnderMouse = null;
        }

        private void gMapControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (markerUnderMouse == null)
                return;
            dragMarker = markerUnderMouse;
        }

        private void gMapControl1_MouseUp(object sender, MouseEventArgs e)
        {
            if (dragMarker == null)
                return;
            var lat = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lat;
            var lng = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lng;
            dragMarker.Position = new PointLatLng(lat, lng);
            dragMarker = null;
        }

        private void gMapControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragMarker == null)
                return;
            var lat = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lat;
            var lng = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lng;
            dragMarker.Position = new PointLatLng(lat, lng);
        }

    }
}
