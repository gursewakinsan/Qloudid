using System;
using Xamarin.Forms;
using Android.Content;
using Android.Hardware;
using Qloudid.CameraView;
using Qloudid.Droid.Renderers;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CameraPreview), typeof(CameraPreviewRenderer))]
namespace Qloudid.Droid.Renderers
{
    public class CameraPreviewRenderer : ViewRenderer<CameraPreview, CameraPreview_Droid>
    {
        CameraPreview_Droid cameraPreview;
        CameraPreview CameraPreviewPage;
        public CameraPreviewRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<CameraPreview> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                // Unsubscribe
                cameraPreview.Click -= OnCameraPreviewClicked;
                CameraPreviewPage.OnDoing -= OnCameraPreviewClicked;
            }
            if (e.NewElement != null)
            {
                if (Control == null)
                {
                    cameraPreview = new CameraPreview_Droid(Context);
                    SetNativeControl(cameraPreview);
                }
                Control.Preview = Camera.Open((int)e.NewElement.Camera);
                CameraPreviewPage = e.NewElement as CameraPreview;
                // Subscribe
                cameraPreview.Click += OnCameraPreviewClicked;
                CameraPreviewPage.OnDoing += OnCameraPreviewClicked;
            }
        }

        void OnCameraPreviewClicked(object sender, EventArgs e)
        {
            if (cameraPreview.IsPreviewing)
            {
               // App.CroppedImage = new byte[100];
               //cameraPreview.TakePicture();
                cameraPreview.IsPreviewing = false;
                cameraPreview.Preview.StopPreview();
            }
            else
            {
                cameraPreview.Preview.StartPreview();
                cameraPreview.IsPreviewing = true;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Control.Preview.Release();
            }
            base.Dispose(disposing);
        }

        public void onPictureTaken(byte[] data, Camera camera)
        {
        }
    }
}