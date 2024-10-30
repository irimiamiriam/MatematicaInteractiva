using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
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

		string lectiipath;
		string[] paths;

		public Noua()
		{
			InitializeComponent();
			string workingdir = Environment.CurrentDirectory;
			string projectdir = Directory.GetParent(workingdir).Parent.FullName;
			lectiipath =System.IO.Path.Combine(projectdir, "Lectii9");
			paths = Directory.GetFiles(lectiipath);

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
		//	panel.Children.Clear();
			if (label.Tag != null)
			{
				if (label.Tag.ToString().Contains("Subcapitol")) { showLectiiDinSubcapitol(label); }

				else {foreach (string path in paths)
					{
						
							if (path.Contains(label.Tag.ToString()))
							{
								using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
								{
									
									Canvas loadedCanvas = (Canvas)XamlReader.Load(fs);
									//panel.Children.Add(loadedCanvas);
								}

							
						}
					}
				}
			}
		}

		private void showLectiiDinSubcapitol(Label label)
		{
			string[] all=label.Tag.ToString().Split(' ');
			string tag =all[1];

		checkVisibility(tag);


			
		}

		private void checkVisibility(string tag)
		{
            foreach (UIElement element in mainpanelalg.Children)
            {

                if (element is StackPanel panel)
                {
                    foreach (UIElement el in panel.Children)
                    {
                        if (el is StackPanel panel2 && panel2.Tag != null)
                        {
                            if (panel2.Tag.ToString().Contains(tag))
                            {
                                if (panel2.Visibility == Visibility.Visible) { panel2.Visibility = Visibility.Collapsed; }
                                else { panel2.Visibility = Visibility.Visible; }
                            }
                        }
                    }
                }

            }
            foreach (UIElement element in mainpanelgeo.Children)
            {

                if (element is StackPanel panel)
                {
                    foreach (UIElement el in panel.Children)
                    {
                        if (el is StackPanel panel2 && panel2.Tag != null)
                        {
                            if (panel2.Tag.ToString().Contains(tag))
                            {
                                if (panel2.Visibility == Visibility.Visible) { panel2.Visibility = Visibility.Collapsed; }
                                else { panel2.Visibility = Visibility.Visible; }
                            }
                        }
                    }
                }

            }

        }


	}
}
