﻿namespace Qloudid.Models
{
	public class AddressesRequest
	{
		public int UserId { get; set; }

		[Newtonsoft.Json.JsonProperty(PropertyName = "user_address")]
		public int UserAddress { get; set; }
	}
}
