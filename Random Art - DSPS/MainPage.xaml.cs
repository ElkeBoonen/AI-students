using Newtonsoft.Json.Linq;
using RandomOrg.CoreApi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.AccessCache;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Random_Art___DSPS
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void _switch_Toggled(object sender, RoutedEventArgs e)
        {

        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            RandomOrgClient roc = RandomOrgClient.GetRandomOrgClient("API key");

            Random random = new Random();
            int[] x_values = roc.GenerateIntegers((int) slider.Value, 0, (int)canvas.Width-100);
            int[] y_values = roc.GenerateIntegers((int)slider.Value, 0, (int)canvas.Height-100);
            int[] x_lengths = roc.GenerateIntegers((int)slider.Value, -50, 50);
            int[] y_lengths = roc.GenerateIntegers((int)slider.Value, -50, 50);


            for (int i = 0; i < (int)slider.Value; i++)
            {
                Line line = new Line();

                line.X1 = x_values[i];
                line.Y1 = y_values[i]; 

                line.X2 = line.X1 + x_lengths[i]; 
                line.Y2 = line.Y1 + y_lengths[i]; 

                line.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
                line.StrokeThickness = Math.Abs(x_lengths[i]%4);

                canvas.Children.Add(line);
                //Thread.Sleep(10);
            }

            
        }

        private void reset_Click(object sender, RoutedEventArgs e)
        {
            canvas.Children.Clear();
        }

        private void slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {

        }
    }
}
