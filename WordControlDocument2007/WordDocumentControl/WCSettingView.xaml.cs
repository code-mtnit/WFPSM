using System.Windows;

namespace Sbn.AdvancedControls.WordControlDocument
{
    /// <summary>
    /// Description for WCSettingView.
    /// </summary>
    public partial class WCSettingView : Window
    {
        /// <summary>
        /// Initializes a new instance of the WCSettingView class.
        /// </summary>
        public WCSettingView()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        
    }
}