using MicaWPF.Controls;
using System;
using System.Windows;

namespace FSR3ModSetupUtilityEnhanced.View
{
    public partial class MainWindow : MicaWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            SidebarControl.NavigationRequested += OnNavigationRequested;
            MainFrame.Navigate(new HomeView());
        }

        private void OnNavigationRequested(Type pageType)
        {
            if (MainFrame.Content?.GetType() != pageType)
            {
                MainFrame.Navigate(Activator.CreateInstance(pageType));
            }
        }
    }
}