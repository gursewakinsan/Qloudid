namespace Qloudid.Models
{
    public class SaveCompanyDetailsRequest
    {
        public int booking_id { get; set; }
        public string company_name { get; set; }
        public string cid_number { get; set; }
        public string d_address { get; set; }
        public string dcity { get; set; }
        public string dzip { get; set; }
        public string dpo_number { get; set; }
        public string card_number { get; set; }
        public string cvv { get; set; }
        public string expiry_month { get; set; }
        public string expiry_year { get; set; }
        public string name_on_card { get; set; }
    }
}