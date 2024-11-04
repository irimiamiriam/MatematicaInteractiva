using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
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
            Button button = (Button)sender;
            string tag = button.Tag as string;
            var assembly = Assembly.GetExecutingAssembly();

            // Find all types that are Windows and contain the specified number in their name
            var windowType = assembly.GetTypes()
                                     .Where(t => t.IsSubclassOf(typeof(Window)) && t.Name=="Lectia"+tag)
                                     .FirstOrDefault();
            var windowInstance = (Window)Activator.CreateInstance(windowType);
            this.Hide();
            windowInstance.Show();
            windowInstance.Closed += (s, args) => this.Show();
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

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            var scrollViewer = sender as ScrollViewer;
            if (scrollViewer != null)
            {
                // Adjust this factor to increase or decrease scroll speed
                double scrollSpeedFactor = 1; // Increase this value for faster scrolling

                // Scroll the ScrollViewer by a factor of the delta
                scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - e.Delta * scrollSpeedFactor);
                e.Handled = true; // Mark event as handled to prevent default scrolling
            }
        }
    }
}
