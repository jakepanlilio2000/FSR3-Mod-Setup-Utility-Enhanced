using System;
using System.Windows;
using System.Windows.Controls;

namespace FSR3ModSetupUtilityEnhanced.View
{
    public partial class SideBarView : UserControl
    {
        public event Action<Type>? NavigationRequested;

        private bool _isSettingsSubMenuVisible = false;

        public SideBarView()
        {
            InitializeComponent();
            VersionLabel.Text = $"v{System.Reflection.Assembly.GetExecutingAssembly().GetName().Version?.ToString(3)}";
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationRequested?.Invoke(typeof(HomeView));
        }
        private void ModsSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            //  NavigationRequested?.Invoke(typeof(ModsSettingsView));
        }

        private void LibraryButton_Click(object sender, RoutedEventArgs e)
        {
            //  NavigationRequested?.Invoke(typeof(LibraryView));
        }

        private void GuideButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationRequested?.Invoke(typeof(GuideView));
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            if (SidebarGrid.Width > 60)
            {
                _isSettingsSubMenuVisible = !_isSettingsSubMenuVisible;
                SettingsSubMenu.Visibility = _isSettingsSubMenuVisible ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}