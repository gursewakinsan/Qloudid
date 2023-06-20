namespace Qloudid.Models
{
    public class TicketSubTitleIssueInfoResponse : BaseModel
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "home_repair_issue")]
        public string HomeRepairIssue { get; set; }

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
    }
}
