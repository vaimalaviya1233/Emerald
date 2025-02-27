using Emerald.Core.Store.Results;
using Emerald.WinUI.Models;
using Microsoft.UI.Xaml.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Emerald.WinUI.Views.Store
{
    public sealed partial class InstallerPage : Page
    {
        public StoreItem Item { get; set; }
        private ObservableCollection<Version> Versions = new();
        public InstallerPage()
        {
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            var vers = await Item.GetDownloadVersionsAsync();
            Versions.Clear();
            foreach (var version in vers)
                Versions.Add(version);

            cmbxVers.SelectedIndex = 0;
            cmbxVers_SelectionChanged(null, null);
        }

        private void cmbxVers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var version in Versions)
            {
                version.IsDetailsVisible = false;
                version.InvokePropertyChanged();
            }
            var i = cmbxVers.SelectedIndex > -1?  cmbxVers.SelectedIndex: 0;
            Versions[i].IsDetailsVisible = true;
            Versions[i].InvokePropertyChanged();
        }
    }
}
