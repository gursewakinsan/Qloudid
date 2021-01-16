using System;
using Android.Views;
using Android.Content;
using Android.Hardware;
using Android.Runtime;
using System.Collections.Generic;

namespace Qloudid.Droid.Renderers
{
	public sealed class CameraPreview_Droid : ViewGroup, ISurfaceHolderCallback//, Camera.IPictureCallback, Camera.IPreviewCallback, Camera.IShutterCallback
	{
		SurfaceView surfaceView;
		ISurfaceHolder holder;
		Camera.Size previewSize;
		IList<Camera.Size> supportedPreviewSizes;
		Camera camera;
		IWindowManager windowManager;

		public bool IsPreviewing { get; set; }

		public Camera Preview
		{
			get { return camera; }
			set
			{
				camera = value;
				if (camera != null)
				{
					supportedPreviewSizes = Preview.GetParameters().SupportedPreviewSizes;
					RequestLayout();
				}
			}
		}

		public CameraPreview_Droid(Context context)
			: base(context)
		{
			surfaceView = new SurfaceView(context);
			AddView(surfaceView);

			windowManager = Context.GetSystemService(Context.WindowService).JavaCast<IWindowManager>();

			IsPreviewing = false;
			holder = surfaceView.Holder;
			holder.AddCallback(this);
		}

		protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
		{
			int width = ResolveSize(SuggestedMinimumWidth, widthMeasureSpec);
			int height = ResolveSize(SuggestedMinimumHeight, heightMeasureSpec);
			SetMeasuredDimension(width, height);

			if (supportedPreviewSizes != null)
			{
				previewSize = GetOptimalPreviewSize(supportedPreviewSizes, width, height);
			}
		}

		protected override void OnLayout(bool changed, int l, int t, int r, int b)
		{
			var msw = MeasureSpec.MakeMeasureSpec(r - l, MeasureSpecMode.Exactly);
			var msh = MeasureSpec.MakeMeasureSpec(b - t, MeasureSpecMode.Exactly);

			surfaceView.Measure(msw, msh);
			surfaceView.Layout(0, 0, r - l, b - t);
		}

		public void SurfaceCreated(ISurfaceHolder holder)
		{
			try
			{
				if (Preview != null)
				{
					Preview.SetPreviewDisplay(holder);
				}
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(@"			ERROR: ", ex.Message);
			}
		}

		public void SurfaceDestroyed(ISurfaceHolder holder)
		{
			if (Preview != null)
			{
				Preview.StopPreview();
			}
		}

		public void SurfaceChanged(ISurfaceHolder holder, Android.Graphics.Format format, int width, int height)
		{
			var parameters = Preview.GetParameters();
			//var supportedFocusModes = Preview.GetParameters().SupportedFocusModes;
			parameters.SetPreviewSize(previewSize.Width, previewSize.Height);
			RequestLayout();

			switch (windowManager.DefaultDisplay.Rotation)
			{
				case SurfaceOrientation.Rotation0:
					camera.SetDisplayOrientation(90);
					break;
				case SurfaceOrientation.Rotation90:
					camera.SetDisplayOrientation(0);
					break;
				case SurfaceOrientation.Rotation270:
					camera.SetDisplayOrientation(180);
					break;
			}

			//=========
			/*parameters.Set("s3d-prv-frame-layout", "none");
			parameters.Set("s3d-cap-frame-layout", "none");
			parameters.Set("iso", "auto");
			parameters.Set("Contrast", 100);
			parameters.Set("Brightness", 50);
			parameters.Set("Saturation", 100);
			parameters.Set("Sharpness", 100);*/
			parameters.Set("jpeg-quality", 100);
			//parameters.SetPictureSize(800, 600);
			//=========
			parameters.FocusMode = Camera.Parameters.FocusModeContinuousPicture;

			Preview.SetParameters(parameters);
			//Preview.SetPreviewCallbackWithBuffer(this);
			Preview.StartPreview();
			IsPreviewing = true;
			//Preview.TakePicture(null,null,null,null);
		}

		public void TakePicture()
		{
			//Preview.TakePicture(this, this, this, null);
			//Preview.TakePicture(null, null, null, null);

			//TODO - Find out how picture clicked using ISurfaceHolderCallback 
		}

		Camera.Size GetOptimalPreviewSize(IList<Camera.Size> sizes, int w, int h)
		{
			const double AspectTolerance = 0.1;
			double targetRatio = (double)w / h;

			if (sizes == null)
			{
				return null;
			}

			Camera.Size optimalSize = null;
			double minDiff = double.MaxValue;

			int targetHeight = h;
			foreach (Camera.Size size in sizes)
			{
				double ratio = (double)size.Width / size.Height;

				if (Math.Abs(ratio - targetRatio) > AspectTolerance)
					continue;
				if (Math.Abs(size.Height - targetHeight) < minDiff)
				{
					optimalSize = size;
					minDiff = Math.Abs(size.Height - targetHeight);
				}
			}

			if (optimalSize == null)
			{
				minDiff = double.MaxValue;
				foreach (Camera.Size size in sizes)
				{
					if (Math.Abs(size.Height - targetHeight) < minDiff)
					{
						optimalSize = size;
						minDiff = Math.Abs(size.Height - targetHeight);
					}
				}
			}

			return optimalSize;
		}

		public void OnPictureTaken(byte[] data, Camera camera)
		{
			//throw new NotImplementedException();
		}

		public void OnPreviewFrame(byte[] data, Camera camera)
		{
			//throw new NotImplementedException();
		}

		public void OnShutter()
		{
			//throw new NotImplementedException();
		}
	}
}