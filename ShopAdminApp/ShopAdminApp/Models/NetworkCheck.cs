using System;
using Plugin.Connectivity;

namespace ShopAdminApp.Models
{
	public class NetworkCheck
	{
        public static bool IsInternet()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                return true;
            }
            else
            {
                // write your code if there is no Internet available      
                return false;
            }
        }
    }
}

