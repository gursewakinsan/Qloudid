namespace Qloudid.Models
{
	public class DependentResponse
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
		public string FirstLetterName => System.Globalization.StringInfo.GetNextTextElement(Name, 0).ToUpper();
		public string DisplayDependentType => GetDependentType();
		string GetDependentType()
		{
			string type = string.Empty;
			if (DependentType == 1)
				type = "Child";
			else if (DependentType == 2)
				type = "Elder";
			else if(DependentType == 3)
				type = "Disabled";
			return type;
		}
	}
}
