using GMap.NET.WindowsForms;
using GMap.NET;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RITAutomation.Models;
using RITAutomation.Services;
using RITAutomation.Utils;

namespace RITAutomation
{
    public partial class MainWindow : Form
    {
        private GMapOverlay _markersOverlay;
        private GMapMarker _dragMarker;
        private GMapMarker _markerUnderMouse;
        public MainWindow()
        {
            InitializeComponent();


        }

        private void InitializeMap()
        {
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            GMCMap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMCMap.MinZoom = 2;
            GMCMap.MaxZoom = 16;
            GMCMap.Zoom = 11;
            GMCMap.Position = new PointLatLng(55.008111, 82.921768);
            GMCMap.MouseWheelZoomType = MouseWheelZoomType.MousePositionAndCenter;
            GMCMap.CanDragMap = true;
            GMCMap.DragButton = MouseButtons.Left;
            GMCMap.ShowCenter = false;
            GMCMap.ShowTileGridLines = false;
        }

        private void InitializeMarkers()
        {
            try
            {
                _markersOverlay = new GMapOverlay();
                List<TransportUnit> transportUnits = TransportService.GetTransportUnits();
                List<GMapMarker> markers = MarkersService.CreateMarkers(transportUnits);
                GMCMap.Overlays.Add(_markersOverlay);
                MarkersService.AddMarkersToOverlay(ref _markersOverlay, markers);
                GMCMap.Update();
            }
            catch (NoRecordsInDatabase ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            try
            {
                if (_dragMarker == null)
                    return;
                var lat = GMCMap.FromLocalToLatLng(e.X, e.Y).Lat;
                var lng = GMCMap.FromLocalToLatLng(e.X, e.Y).Lng;
                _dragMarker.Position = new PointLatLng(lat, lng);
                MarkersService.UpdateMarkerInDB(_dragMarker);
                _dragMarker = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void GMCMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragMarker == null)
                return;
            var lat = GMCMap.FromLocalToLatLng(e.X, e.Y).Lat;
            var lng = GMCMap.FromLocalToLatLng(e.X, e.Y).Lng;
            _dragMarker.Position = new PointLatLng(lat, lng);
        }


        private void MainWindow_Shown(object sender, EventArgs e)
        {
            InitializeMap();
            InitializeMarkers();
        }
    }
}
