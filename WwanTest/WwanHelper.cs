using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Connectivity;

namespace WwanTest
{
    public class WwanHelper
    {
        public WwanHelper()
        {
            NetworkInformation.NetworkStatusChanged += NetworkInformation_NetworkStatusChanged;
        }

        private async void NetworkInformation_NetworkStatusChanged(object sender)
        {
            //var filter = new ConnectionProfileFilter { IsWlanConnectionProfile = true };
            var filter = new ConnectionProfileFilter { IsWwanConnectionProfile = true };
            var wwanProfiles =
                await NetworkInformation.FindConnectionProfilesAsync(filter);
            var wlanProfileList = wwanProfiles.ToList();
            foreach (var item in wlanProfileList)
            {
                Console.WriteLine($"WWAN name: {item.ProfileName}");
                Console.WriteLine($"AccessPointName: {item.WwanConnectionProfileDetails.AccessPointName}");
                Console.WriteLine($"CurrentDataClass: {item.WwanConnectionProfileDetails.GetCurrentDataClass()}");
                Console.WriteLine($"HomeProviderId: {item.WwanConnectionProfileDetails.HomeProviderId}");
                Console.WriteLine($"NetworkRegistrationState: {item.WwanConnectionProfileDetails.GetNetworkRegistrationState()}");
            }
        }
    }
}
