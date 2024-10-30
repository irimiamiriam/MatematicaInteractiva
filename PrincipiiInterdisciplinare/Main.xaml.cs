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

namespace MatematicaInteractiva.PrincipiiInterdisciplinare
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Lectia1 lectie = new Lectia1();
            this.Hide();
            lectie.ShowDialog();
            this.Show();
        }
        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;

            // Create a scale transform and set it to the button
            ScaleTransform scaleTransform = new ScaleTransform(1.05, 1.05);
            button.RenderTransform = scaleTransform;
            button.RenderTransformOrigin = new Point(0.5, 0.5);

            // Create an animation for the scale transform
            DoubleAnimation scaleUpAnimation = new DoubleAnimation(1.05, TimeSpan.FromMilliseconds(100));
            scaleTransform.BeginAnimation(ScaleTransform.ScaleXProperty, scaleUpAnimation);
            scaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, scaleUpAnimation);
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            ScaleTransform scaleTransform = button.RenderTransform as ScaleTransform;

            // Create an animation to return to the original size
            DoubleAnimation scaleDownAnimation = new DoubleAnimation(1, TimeSpan.FromMilliseconds(100));
            scaleTransform.BeginAnimation(ScaleTransform.ScaleXProperty, scaleDownAnimation);
            scaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, scaleDownAnimation);
        }
    }
}
