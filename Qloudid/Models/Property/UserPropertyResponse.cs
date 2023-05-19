namespace Qloudid.Models
{
    public class UserPropertyResponse : BaseModel
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "property_nickname")]
        public string PropertyNickname { get; set; }

        private bool isSelected;
        public bool IsSelected
        {
            get => isSelected;
            set
            {
                isSelected = value;
                OnPropertyChanged(nameof(IsSelected));
            }
        }
        

        /*public int user_id { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }
        public string port_number { get; set; }
        public string invoice_address { get; set; }
        public string invoice_city { get; set; }
        public string invoice_zipcode { get; set; }
        public string invoice_port_number { get; set; }
        public int is_name_same { get; set; }
        public int is_invoice_same { get; set; }
        public string name_on_house { get; set; }
        public int is_personal_address { get; set; }
        public string created_on { get; set; }
        public object entry_code { get; set; }
        public int property_layout { get; set; }
        public int property_type { get; set; }
        public int floors_available { get; set; }
        public int apartment_floor { get; set; }
        public int entrance_floor { get; set; }
        public int private_entrance { get; set; }
        public int elevator { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string arrival_time { get; set; }
        public string departure_time { get; set; }
        public int children_allowed { get; set; }
        public int infants_allowed { get; set; }
        public int smoking_allowed { get; set; }
        public int events_allowed { get; set; }
        public int pets_allowed { get; set; }
        public int cleening_fee_applicable { get; set; }
        public int cleening_fee { get; set; }
        public int security_fee_applicable { get; set; }
        public int security_fee { get; set; }
        public string property_heading { get; set; }
        public int heading_type { get; set; }
        public int booking_notice { get; set; }
        public string apartment_description { get; set; }
        public int is_published { get; set; }
        public object state { get; set; }
        public string sale_price { get; set; }
        public int publish_dstrict_rent { get; set; }
        public int publish_dstrict_long_rent { get; set; }
        public int publish_dstrict_sale { get; set; }
        public int publish_airnub { get; set; }
        public int publish_booking { get; set; }
        public int publish_vrbo { get; set; }
        public int publish_trip { get; set; }
        public int publish_exptd { get; set; }
        public int publish_tui { get; set; }
        public int total_channels { get; set; }
        public string monthly_price { get; set; }
        public int contract_length { get; set; }
        public int security_fee_applicable_long { get; set; }
        public int security_fee_months { get; set; }
        public int district_rent { get; set; }
        public int district_short_rent { get; set; }
        public int district_long_rent { get; set; }
        public int district_sale { get; set; }
        public int floor_id { get; set; }
        public int building_id { get; set; }
        public int apartment_id { get; set; }
        public string sale_price_per_m { get; set; }
        public int bedroom_updated { get; set; }
        public int bathroom_updated { get; set; }
        public int wifi_available { get; set; }
        public string wifi_username { get; set; }
        public string wifi_password { get; set; }
        public int quite_hrs { get; set; }
        public int quite_hrs_mon_fri { get; set; }
        public int quite_hrs_sat_sun { get; set; }
        public object quite_hrs_mon_fri_open { get; set; }
        public object quite_hrs_mon_fri_close { get; set; }
        public object quite_hrs_sat_sun_open { get; set; }
        public object quite_hrs_sat_sun_close { get; set; }
        public int wi_fi_updated { get; set; }
        public int pricing_updated { get; set; }
        public int arrival_departure_updated { get; set; }
        public int fee_updated { get; set; }
        public int other_room_updated { get; set; }
        public int property_composition_updated { get; set; }
        public int nickname_updated { get; set; }
        public int headline_updated { get; set; }
        public int description_updated { get; set; }
        public int house_rules_updated { get; set; }
        public int security_fee_updated { get; set; }
        public int currency_updated { get; set; }
        public string cancellation_policy { get; set; }
        public int policy_updated { get; set; }
        public int tourist_tax_updated { get; set; }
        public int tourist_tax_applicable { get; set; }
        public int tourist_tax { get; set; }
        public int get_started_updated { get; set; }
        public int channels_updated { get; set; }
        public int ownership_detail { get; set; }
        public int bought_by_you { get; set; }
        public int bought_rent_allowed { get; set; }
        public int rent_contract_on_you { get; set; }
        public int allowed_to_rent_out { get; set; }
        public int ownership_updated { get; set; }
        public int cleening_by_whom { get; set; }
        public int whether_it_is_cleen { get; set; }
        public int if_damaged { get; set; }
        public int if_rentable { get; set; }
        public int key_available { get; set; }
        public object key_description { get; set; }
        public int total_keys { get; set; }
        public int key_updated { get; set; }*/
    }
}
