using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Networking.Connectivity;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UwpPlayground
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        private bool isWwanEnabled;

        public bool IsWwanEnabled
        {
            get { return isWwanEnabled; }
            set
            {
                isWwanEnabled = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsWwanEnabled)));
            }
        }

        public MainPage()
        {
            this.InitializeComponent();
            NetworkInformation.NetworkStatusChanged += NetworkInformation_NetworkStatusChanged;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private async void NetworkInformation_NetworkStatusChanged(object sender)
        {
            var filter = new ConnectionProfileFilter { IsWwanConnectionProfile = true };
            var wwanProfiles =
                await NetworkInformation.FindConnectionProfilesAsync(filter);
            var wlanProfileList = wwanProfiles.ToList();
            foreach (var item in wlanProfileList)
            {
                listView.Items.Add(item.ProfileName);
                //listView.Items.Add(item.NetworkAdapter)
            }


        }
    }
}
