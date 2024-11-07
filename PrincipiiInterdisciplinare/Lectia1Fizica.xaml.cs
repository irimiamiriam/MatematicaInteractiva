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

namespace MatematicaInteractiva.PrincipiiInterdisciplinare
{
    /// <summary>
    /// Interaction logic for Lectia1Fizica.xaml
    /// </summary>
    public partial class Lectia1Fizica : Window
    {
        public Lectia1Fizica()
        {
            InitializeComponent();
        }
        private void ButtonRezolvare_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            foreach (UIElement element in MainStackPanel.Children)
            {

                if (element is StackPanel panel)
                {
                    foreach (UIElement el in panel.Children)
                    {
                        if (el is StackPanel panel2)
                        {
                            if (panel2.Name.Split('_').Length == 2)
                                if (panel2.Name.Split('_')[1] == button.Tag.ToString())
                                {
                                    if (panel2.Visibility == Visibility.Visible) { panel2.Visibility = Visibility.Collapsed; panel.Height = 160; }
                                    else { panel2.Visibility = Visibility.Visible; panel.Height += panel2.Height; }

                                }
                        }
                    }
                }

            }
        }
        private void ButtonVerifica_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int tag = int.Parse(button.Tag.ToString());

            // Find the StackPanel that contains the corresponding question
            StackPanel mainStackPanel = new StackPanel();
            Label responseLabel = null;

            // Iterate through the StackPanels in the main StackPanel
            foreach (var child in MainStackPanel.Children)
            {
                if (child is StackPanel stackPanel && stackPanel.Name == $"MainStackPanel_{tag}")
                {
                    mainStackPanel = stackPanel;  // Set the relevant StackPanel
                    break; // Stop searching when found
                }
            }

            // Find the response Label associated with the selected question
            responseLabel = (Label)mainStackPanel.Children.OfType<StackPanel>().FirstOrDefault(lbl => lbl.Name == "").Children.OfType<Label>().FirstOrDefault(lbl => lbl.Name.StartsWith("raspuns"));

            // Find the selected RadioButton in the current StackPanel
            RadioButton selectedRadioButton = null;
            RadioButton correctRadioButton = null;
            foreach (var child in mainStackPanel.Children)
            {
                if (child is RadioButton radioButton && radioButton.IsChecked == true)
                {
                    selectedRadioButton = radioButton;

                }
                if (child is RadioButton radioButton1 && radioButton1.Tag != null)
                {
                    correctRadioButton = radioButton1;
                }
            }
            if (selectedRadioButton != null)
            {
                if (selectedRadioButton.Tag != null) { responseLabel.Content = "Corect!"; }
                else { responseLabel.Content = "Gresit! Raspuns corect: " + correctRadioButton.Content; }
                button.IsEnabled = false;
            }
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
        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }



        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Main.IsShuttingDown = true;
            Application.Current.Shutdown();

        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Lectia1.Button_MouseEnter(sender, e);
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Lectia1.Button_MouseLeave(sender, e);
        }
    }
}
