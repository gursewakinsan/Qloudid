using System.Collections.Generic;

namespace Qloudid.Models
{
    public class GetServiceInvoiceDetailResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "total_price")]
        public int TotalPrice { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "service_list")]
        public List<ServiceList> ServiceList { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "company_name")]
        public string CompanyName { get; set; }
    }

    public class ServiceList
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "dish_name")]
        public string DishName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "dish_price")]
        public int DishPrice { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "company_name")]
        public string CompanyName { get; set; }
    }
}
