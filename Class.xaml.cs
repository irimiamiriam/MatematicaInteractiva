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
    /// Interaction logic for Class.xaml
    /// </summary>
    public partial class Class : Window
    {
        public Class()
        {
            InitializeComponent();
        }

        private void noua_Click(object sender, RoutedEventArgs e)
        {
            Noua noua = new Noua();
            this.Hide();
            noua.ShowDialog();
            this.Show();
        }

        private void zece_Click(object sender, RoutedEventArgs e)
        {
            Zece zece = new Zece();
            this.Hide();
            zece.ShowDialog();
            this.Show();
        }
    }
}
