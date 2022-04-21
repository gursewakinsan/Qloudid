using Xamarin.Forms;

namespace Qloudid.Models
{
	public class DependentsListForCheckinDstrictResponse : BaseModel
	{
		[Newtonsoft.Json.JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "ssn")]
		public string Ssn { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "first_name")]
		public string FirstName { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "email")]
		public string Email { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "dependent_type")]
		public int DependentType { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "created_on")]
		public string CreatedOn { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "image_path")]
		public string ImagePath { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "address")]
		public string Address { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "child_image")]
		public string ChildImage { get; set; }

		public bool IsSelect { get; set; } = false;

		private Color frameBorderColor = Color.FromHex("#2A2A31");
		public Color FrameBorderColor
		{
			get => frameBorderColor;
			set
			{
				frameBorderColor = value;
				OnPropertyChanged("FrameBorderColor");
			}
		}
	}
}
