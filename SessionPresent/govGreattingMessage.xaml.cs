using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SessionPresent.ViewModel;
using System.Windows.Threading;

namespace SessionPresent
{
    /// <summary>
    /// Interaction logic for govGreattingMessage.xaml
    /// </summary>
    public partial class govGreattingMessage : Window
    {
        public govGreattingMessage()
        {
            InitializeComponent();
            //this.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Closing -= Window_Closing;
            e.Cancel = true;
            var anim = new DoubleAnimation(0, (Duration)TimeSpan.FromSeconds(1));
            anim.Completed += (s, _) => this.Close();
            this.BeginAnimation(UIElement.OpacityProperty, anim);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();

        }

        DispatcherTimer dt = new DispatcherTimer();

        private void govGreatingMessage_Loaded(object sender, RoutedEventArgs e)
        {
            dt.Tick += Dt_Tick;
            dt.Interval = new TimeSpan(0,0,3);
            dt.Start();
        }

        private void Dt_Tick(object sender, EventArgs e)
        {
            dt.Stop();
            this.Close();
           // throw new NotImplementedException();
        }
    }
}
