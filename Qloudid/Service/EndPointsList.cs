namespace Qloudid.Service
{
	public class EndPointsList
	{
		public const string LoginUrl = "https://www.qloudid.com/user/index.php/QloudidApp/checkConnect/{0}";
		public const string CheckPasswordUrl = "https://www.qloudid.com/user/index.php/QloudidApp/checkPassword/{0}";
		public const string CheckQrValidityUrl = "https://www.qloudid.com/user/index.php/QloudidApp/checkValidity/{0}";
		public const string UpdateLoginIpUrl = "http://www.qloudid.com/user/index.php/QloudidApp/updateLoginIp/{0}/{1}";
		public const string VerifyPasswordUrl = "http://www.qloudid.com/user/index.php/QloudidApp/verifyPassword/{0}/{1}";
	}
}
