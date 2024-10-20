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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;



namespace MatematicaInteractiva
{
    /// <summary>
    /// Interaction logic for Noua.xaml
    /// </summary>
    public partial class Noua : Window
    {
        public Noua()
        {
            InitializeComponent();
        }

        private void Label_MouseEnter(object sender, MouseEventArgs e)
        {
            Label label = sender as Label;
            label.Foreground = Brushes.Gray;

        }

        private void Label_MouseLeave(object sender, MouseEventArgs e)
        {
            Label label = sender as Label;
            label.Foreground = Brushes.Black;
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Label label = sender as Label;
            if(Convert.ToInt16(label.Tag) == 1)
            {
                if (PanelCapitol1.Visibility == Visibility.Collapsed)
                {
                    PanelCapitol1.Visibility = Visibility.Visible;
                }
                else
                {
                    PanelCapitol1.Visibility = Visibility.Collapsed;
                }
            }
        }
    }
}
