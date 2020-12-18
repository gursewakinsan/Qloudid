using System;
using AVFoundation;
using Qloudid.CameraView;
using Qloudid.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CameraPreview), typeof(CameraPreviewRenderer))]
namespace Qloudid.iOS.Renderers
{
    public class CameraPreviewRenderer : ViewRenderer<CameraPreview, UICameraPreview>
    {
        UICameraPreview uiCameraPreview;
        private AVCaptureOutput cameraOutput;
        private AVCaptureStillImageOutput stillImageOutput;

        protected override void OnElementChanged(ElementChangedEventArgs<CameraPreview> e)
        {
            base.OnElementChanged(e);
            CameraPreview cameraClicked = e.NewElement as CameraPreview;
            if (e.OldElement != null)
            {
                // Unsubscribe
                uiCameraPreview.Tapped -= OnCameraPreviewTapped;
                if (cameraClicked != null)
                    cameraClicked.OnDoing -= OnCameraPreviewTapped;
            }
            if (e.NewElement != null)
            {
                if (cameraClicked != null)
                    cameraClicked.OnDoing += OnCameraPreviewTapped;

                if (Control == null)
                {
                    uiCameraPreview = new UICameraPreview(e.NewElement.Camera);
                    SetNativeControl(uiCameraPreview);
                }
                // Subscribe
                uiCameraPreview.Tapped += OnCameraPreviewTapped;
            }
        }

        async void OnCameraPreviewTapped(object sender, EventArgs e)
        {
            if (uiCameraPreview.IsPreviewing)
            {
                var videoConnection = uiCameraPreview.stillImageOutput.ConnectionFromMediaType(AVMediaType.Video);
                var sampleBuffer = await uiCameraPreview.stillImageOutput.CaptureStillImageTaskAsync(videoConnection);
                var jpegImageAsNsData = AVCaptureStillImageOutput.JpegStillToNSData(sampleBuffer);
                App.CroppedImage = jpegImageAsNsData.ToArray();
                uiCameraPreview.CaptureSession.StopRunning();
                uiCameraPreview.IsPreviewing = false;
            }
            else
            {
                uiCameraPreview.CaptureSession.StartRunning();
                uiCameraPreview.IsPreviewing = true;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Control.CaptureSession.Dispose();
                Control.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}