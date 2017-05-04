using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ColrorsBrushes
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SolidColorBrush couleur;
        LinearGradientBrush degrade;
        Byte a, r, g, b;

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            degrade.GradientStops[0].Color = (Color)ColorConverter.ConvertFromString(
       comboBox1.SelectedItem.ToString());

            rectangle.Fill = degrade;
        }

        private void comboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            degrade.GradientStops[1].Color = (Color)ColorConverter.ConvertFromString(
            comboBox2.SelectedItem.ToString());




            rectangle.Fill = degrade;
        }

        public MainWindow()
        {

            degrade = new LinearGradientBrush();
            degrade.StartPoint = new Point(0, 0);
            degrade.EndPoint = new Point(1.0, 1.0);
            GradientStop GStop1 = new GradientStop();

            GStop1.Color = Colors.White;

            GStop1.Offset = 0.0;
            degrade.GradientStops.Add(GStop1);
            GradientStop GStop2 = new GradientStop();

            GStop2.Color = Colors.White;

            GStop2.Offset = 1.0;
            degrade.GradientStops.Add(GStop2);


            InitializeComponent();

            Type typecouleur = typeof(Colors);
            foreach (PropertyInfo propriete in typecouleur.GetProperties())
            {
                comboBox1.Items.Add(propriete.Name);
                comboBox2.Items.Add(propriete.Name);
            }

            comboBox1.SelectedItem = comboBox1.Items[0];
            comboBox2.SelectedItem = comboBox2.Items[0];
            


        }


        private void Colorer()
        {
            
            couleur = new SolidColorBrush(Color.FromArgb(a, r, g, b));
            rectangle.Fill = couleur;
        }
       

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Byte valeur = (Byte)e.NewValue;
            Slider s = (Slider)sender;

            if (s.Name == "sliderA")
                a = (Byte)sliderA.Value;

            if (s.Name == "sliderR")
                r = (Byte)sliderR.Value;

            if (s.Name == "sliderG")
                g = (Byte)sliderG.Value;

            if (s.Name == "sliderB")
                b = (Byte)sliderB.Value;

            Colorer();

        }
    }
}
