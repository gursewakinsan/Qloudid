using System;
using Xamarin.Forms;
using Android.Content;
using Android.Hardware;
using Qloudid.CameraView;
using Qloudid.Droid.Renderers;
using Xamarin.Forms.Platform.Android;
using static Android.Hardware.Camera;

[assembly: ExportRenderer(typeof(CameraPreview), typeof(CameraPreviewRenderer))]
namespace Qloudid.Droid.Renderers
{
    [Obsolete]
    public class CameraPreviewRenderer : ViewRenderer<CameraPreview, CameraPreview_Droid>, IPictureCallback, Android.Hardware.Camera.IShutterCallback
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
                cameraPreview.IsPreviewing = false;
                try
                {
                    cameraPreview.Preview.TakePicture(this, this, this);
                }
                catch (Exception x)
                {
                    string str = x.Message;
                }
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
               // Control.Preview.Release();
                cameraPreview.Preview.StopPreview();
            }
            base.Dispose(disposing);
        }

        public void onPictureTaken(byte[] data, Camera camera)
        {
            if (data != null)
            {
                App.CroppedImage = data;
            }
        }

		public void OnPictureTaken(byte[] data, Camera camera)
		{
            if (data != null)
            {
                App.CroppedImage = data;
            }
        }

		public void OnShutter()
		{
		}
	}
}