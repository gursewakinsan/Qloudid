using System;
using Xamarin.Forms;

namespace Qloudid.Controls
{
	public class CustomOtpEntry : Entry
	{
		public delegate void BackspaceEventHandler(object sender, EventArgs e);

		public event BackspaceEventHandler OnBackspace;
		public void OnBackspacePressed()
		{
			if (OnBackspace != null)
				OnBackspace(null, null);
		}
	}
}
