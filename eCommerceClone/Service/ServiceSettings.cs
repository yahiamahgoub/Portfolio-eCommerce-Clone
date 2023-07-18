namespace eCommerceClone.Service
{
	public class HttpsClientHandlerService
	{
		public HttpMessageHandler GetPlatformMessageHandler()
		{
#if ANDROID
			var handler = new Xamarin.Android.Net.AndroidMessageHandler();
			handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
			{
				if (cert != null && cert.Issuer.Equals("CN=localhost"))
					return true;
				return errors == System.Net.Security.SslPolicyErrors.None;
			};
			return handler;
#elif IOS
        var handler = new NSUrlSessionHandler
        {
            TrustOverrideForUrl = IsHttpsLocalhost
        };
        return handler;
#else
     throw new PlatformNotSupportedException("Only Android and iOS supported.");
#endif
		}

#if IOS
    public bool IsHttpsLocalhost(NSUrlSessionHandler sender, string url, Security.SecTrust trust)
    {
        if (url.StartsWith("https://localhost"))
            return true;
        return false;
    }
#endif
	}

	public class ServiceSettings
	{

		//static public string URL = "https://192.168.137.135";
		//static public string PORT = "44361";

		//static public string URL = "http://192.168.137.135";
		//static public string PORT = "7071";
		public static string URL
		{
			get
			{
				//for simulator
				//DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5000" : "http://localhost:5000";				
				if (DeviceInfo.Platform == DevicePlatform.Android)
				{
					return "http://192.168.137.135:7071";
					//return "https://192.168.137.135:44361";
				}
				//return "http://192.168.137.135:7071";
				return "http://localhost:7071";
			}
		}
	}
}
