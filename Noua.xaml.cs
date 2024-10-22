﻿using System;
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
			panel.Children.Clear();
			if (label.Tag.ToString().Contains("Subcapitol")) showLectiiDinSubcapitol(label);

			foreach (string path in paths)
			{
				if (label.Tag != null)
				{
					if (path.Contains(label.Tag.ToString()))
					{
						using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
						{
							// Try to load the content as a Canvas
							Canvas loadedCanvas = (Canvas)XamlReader.Load(fs);



							// Add the loaded Canvas to the main Canvas (assuming you have a 'mainCanvas' in your window)
							panel.Children.Add(loadedCanvas);
						}

					}
				}
			}
		}

		private void showLectiiDinSubcapitol(Label label)
		{
			string[] all=label.Tag.ToString().Split(' ');
			string tag =all[1];
			switch(Convert.ToInt32(tag))
			{
				case 111:
					{
						if (PanelCapitol1_1.Visibility == Visibility.Collapsed)
							PanelCapitol1_1.Visibility = Visibility.Visible;
						else
							PanelCapitol1_1.Visibility = Visibility.Collapsed;
						break;
					}
				case 112:
					{
						if (PanelCapitol1_2.Visibility == Visibility.Collapsed)
							PanelCapitol1_2.Visibility = Visibility.Visible;
						else
							PanelCapitol1_2.Visibility = Visibility.Collapsed;
						break;
					}
				case 113:
					{
						if (PanelCapitol1_3.Visibility == Visibility.Collapsed)
							PanelCapitol1_3.Visibility = Visibility.Visible;
						else
							PanelCapitol1_3.Visibility = Visibility.Collapsed;
						break;  
					}
			}
		}


	}
}
