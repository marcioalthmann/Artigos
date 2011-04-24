using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using SLARToolKit;

namespace RealidadeAumentada
{
    public partial class MainPage : UserControl
    {
        private CaptureSource captureSource;
        private CaptureSourceMarkerDetector markerDetector;

        public MainPage()
        {
            InitializeComponent();
            Loaded += MainPage_Loaded;
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            
            captureSource = new CaptureSource
                                {
                                    VideoCaptureDevice = CaptureDeviceConfiguration.GetDefaultVideoCaptureDevice()
                                };

            var videoBrush = new VideoBrush();
            videoBrush.SetSource(captureSource);
            Viewport.Fill = videoBrush;

            markerDetector = new CaptureSourceMarkerDetector();
            var marker = Marker.LoadFromResource("Bola.pat", 64, 64, 80);
            markerDetector.Initialize(captureSource, 1d, 4000d, marker);

            markerDetector.MarkersDetected += (obj, args) =>
                                                  {
                                                      Dispatcher.BeginInvoke(() =>
                                                                                 {
                                                                                     var results = args.DetectionResults;
                                                                                     if (results.HasResults)
                                                                                     {
                                                                                         var centerAtOrigin =
                                                                                             Matrix3DFactory.
                                                                                                 CreateTranslation(
                                                                                                     -Imagem.ActualWidth*
                                                                                                     0.5,
                                                                                                     -Imagem.
                                                                                                          ActualHeight*
                                                                                                     0.5, 0);
                                                                                         var scale =
                                                                                             Matrix3DFactory.CreateScale
                                                                                                 (0.5, -0.5, 0.5);
                                                                                         var world = centerAtOrigin*
                                                                                                     scale*
                                                                                                     results[0].
                                                                                                         Transformation;
                                                                                         var vp =
                                                                                             Matrix3DFactory.
                                                                                                 CreateViewportTransformation
                                                                                                 (Viewport.ActualWidth,
                                                                                                  Viewport.ActualHeight);
                                                                                         var m =
                                                                                             Matrix3DFactory.
                                                                                                 CreateViewportProjection
                                                                                                 (world,
                                                                                                  Matrix3D.Identity,
                                                                                                  markerDetector.
                                                                                                      Projection, vp);
                                                                                         Imagem.Projection =
                                                                                             new Matrix3DProjection
                                                                                                 {ProjectionMatrix = m};
                                                                                     }
                                                                                 });
                                                  };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(CaptureDeviceConfiguration.RequestDeviceAccess())
                captureSource.Start();
        }
    }
}
