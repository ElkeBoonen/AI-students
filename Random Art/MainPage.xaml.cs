using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Random_Art
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

        private void MakeSomeArt()
        { 

            Random rd = new Random();

            for (int i = 0; i < sldSlider.Value; i++)
            {
                Line line = new Line();

                line.X1 = rd.Next(0, (int)cnvArtBoard.Width); ;
                line.X2 = line.X1;

                if ((line.X1 <= (int)cnvArtBoard.Width/9) || (line.X1 >= 8*(int)cnvArtBoard.Width / 9)) line.Y1 = rd.Next((int)cnvArtBoard.Height/9, 8*(int)cnvArtBoard.Height / 9);
                else line.Y1 = rd.Next(0, (int)cnvArtBoard.Height); 
                
                line.Y2 = line.Y1;

                if (rd.Next(0, 2) == 0) line.X2 += rd.Next(-25, 25);
                else line.Y2 += rd.Next(-25, 25);

                byte r = 0, g = 0, b = 0;

                if (tglColor.IsOn)
                {
                    r = (byte)rd.Next(0, 256);
                    g = (byte)rd.Next(0, 256);
                    b = (byte)rd.Next(0, 256);
                }
                line.Stroke = new SolidColorBrush(Windows.UI.Color.FromArgb(255,r,g,b));
                line.StrokeThickness = rd.Next(3,10);
              
                cnvArtBoard.Children.Add(line);
            }

         

        }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            MakeSomeArt();        
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            cnvArtBoard.Children.Clear();
        }
    }
}
