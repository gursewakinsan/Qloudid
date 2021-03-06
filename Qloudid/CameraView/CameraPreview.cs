﻿using System;
using Xamarin.Forms;

namespace Qloudid.CameraView
{
	public class CameraPreview : View
	{
		public static readonly BindableProperty CameraProperty = BindableProperty.Create(
			propertyName: "Camera",
			returnType: typeof(CameraOptions),
			declaringType: typeof(CameraPreview),
			defaultValue: CameraOptions.Rear);

		public CameraOptions Camera
		{
			get { return (CameraOptions)GetValue(CameraProperty); }
			set { SetValue(CameraProperty, value); }
		}


		public delegate void DoSomeDelegate(object sender, EventArgs e);
		public DoSomeDelegate OnDoing;

	}
}
