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
using RITAutomation.Services;

namespace RITAutomation
{
    public partial class MainWindow : Form
    {
        GMapOverlay _markersOverlay;
        GMapMarker _dragMarker;
        GMapMarker _markerUnderMouse;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            GMCMap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMCMap.MinZoom = 2;
            GMCMap.MaxZoom = 16;
            GMCMap.Zoom = 4;
            GMCMap.Position = new PointLatLng(66.4169575018027, 94.25025752215694);
            GMCMap.MouseWheelZoomType = MouseWheelZoomType.MousePositionAndCenter;
            GMCMap.CanDragMap = true;
            GMCMap.DragButton = MouseButtons.Left;
            GMCMap.ShowCenter = false;
            GMCMap.ShowTileGridLines = false;
            _markersOverlay = new GMapOverlay();
            List <TransportUnit> transportUnits = TransportService.GetTransportUnits();
            List<GMapMarker> markers = MarkersService.CreateMarkers(transportUnits);
            MarkersService.AddMarkersToOverlay( ref _markersOverlay, markers );
            GMCMap.Overlays.Add(_markersOverlay);
        }



        private void GMCMap_OnMarkerEnter(GMapMarker item)
        {
            _markerUnderMouse = item;
        }

        private void GMCMap_OnMarkerLeave(GMapMarker item)
        {
            _markerUnderMouse = null;
        }

        private void GMCMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (_markerUnderMouse == null)
                return;
            _dragMarker = _markerUnderMouse;
        }

        private void GMCMap_MouseUp(object sender, MouseEventArgs e)
        {
            if (_dragMarker == null)
                return;
            var lat = GMCMap.FromLocalToLatLng(e.X, e.Y).Lat;
            var lng = GMCMap.FromLocalToLatLng(e.X, e.Y).Lng;
            _dragMarker.Position = new PointLatLng(lat, lng);
            MarkersService.UpdateMarkerInDB(_dragMarker);
            _dragMarker = null;
        }

        private void GMCMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragMarker == null)
                return;
            var lat = GMCMap.FromLocalToLatLng(e.X, e.Y).Lat;
            var lng = GMCMap.FromLocalToLatLng(e.X, e.Y).Lng;
            _dragMarker.Position = new PointLatLng(lat, lng);
        }

    }
}
