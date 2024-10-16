using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ApplicationSetting_НовосЗах.Pages
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        public MainWindow mainWindow;
        System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
        System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
        ColorDialog colorDialog = new ColorDialog();
        FontDialog fontDialog = new FontDialog();

        public Settings(MainWindow _mainWindow)
        {
            InitializeComponent();

            mainWindow = _mainWindow;

            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "Access files (*.accdb)|*.accdb|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            saveFileDialog.InitialDirectory = "c:\\";
            saveFileDialog.Filter = "Access files (*.accdb)|*.accdb|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;

            colorDialog.AllowFullOpen = true;
            colorDialog.ShowHelp = false;

            fontDialog.ShowHelp = false;

            var fontFamily = t2.FontFamily.ToString();
            var fontSize = t2.FontSize * 72.0 / 96.0;
            var isBold = (t2.FontWeight == FontWeights.Bold);
            var isItalic = (t2.FontStyle == FontStyles.Italic);
            System.Drawing.Font font = new System.Drawing.Font(fontFamily, (float)fontSize,
                (isBold ? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular) |
                (isItalic ? System.Drawing.FontStyle.Italic : System.Drawing.FontStyle.Regular));

            fontDialog.Font = font;


        }
        private void OpenDataBase(object sender, RoutedEventArgs e)
        {
            if(openFileDialog.ShowDialog() == DialogResult.OK & File.Exists(openFileDialog.FileName))
            {
                tb_database.Text = openFileDialog.FileName;
                StreamReader sr = new StreamReader(tb_database.Text);
                string[] colors = sr.ReadLine().Split(';');

                string[] settings = sr.ReadLine().Split(';');
                fontDialog.Font = new System.Drawing.Font(settings[0], float.Parse(settings[1]),
                    (settings[2] == "Bold" ? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular) |
                    (settings[3] == "Italic" ? System.Drawing.FontStyle.Italic : System.Drawing.FontStyle.Regular));

                gr_header.Background = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(colors[0]));
                gr_appliacation.Background = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(colors[0]));

                t2.Foreground = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(colors[1]));
                t3.Foreground = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(colors[1]));
                t4.Foreground = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(colors[1]));
                t5.Foreground = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(colors[1]));
                t6.Foreground = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(colors[1]));
                t7.Foreground = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(colors[1]));
                t8.Foreground = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(colors[1]));

                System.Windows.Controls.Label[] arr = { t2, t3, t4, t5, t6, t7, t8 };
                foreach (var item in arr)
                {
                    item.FontFamily = new System.Windows.Media.FontFamily(fontDialog.Font.Name);
                    item.FontSize = fontDialog.Font.Size * 96.0 / 72.0; // Преобразование размера шрифта из пунктов в пиксели
                    item.FontWeight = fontDialog.Font.Bold ? FontWeights.Bold : FontWeights.Regular;
                    item.FontStyle = fontDialog.Font.Italic ? FontStyles.Italic : FontStyles.Normal;
                }
            }
        }
        
        private void SelectColorApplication(object sender, RoutedEventArgs e)
        {
            if(colorDialog.ShowDialog() == DialogResult.OK)
            {
                System.Drawing.Color color = colorDialog.Color;

                gr_gr.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B));
                gr_appliacation.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B));
            }
        }

        private void SelectScreenResolution(object sender, SelectionChangedEventArgs e)
        {
            System.Windows.Controls.ComboBox Resolutions = sender as System.Windows.Controls.ComboBox;
            TextBlock textBlock = Resolutions.SelectedValue as TextBlock;
            string resolution = textBlock.Text;

            string[] separator = new string[1] { " x " };

    
            mainWindow.Width = int.Parse(resolution.Split(separator, System.StringSplitOptions.None)[0]);
            mainWindow.Height = int.Parse(resolution.Split(separator, System.StringSplitOptions.None)[1]);

        }

        private void SelectColorText(object sender, RoutedEventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                System.Drawing.Color color = colorDialog.Color;

                gr_grid.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B));

                t2.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B));
                t3.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B));
                t4.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B));
                t5.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B));
                t6.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B));
                t7.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B));
                t8.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B));
            }
        }

        private void SelectFonts(object sender, RoutedEventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                System.Windows.Controls.Label[] arr = { t2, t3, t4, t5, t6, t7, t8 };
                foreach (var item in arr)
                {
                    item.FontFamily = new System.Windows.Media.FontFamily(fontDialog.Font.Name);
                    item.FontSize = fontDialog.Font.Size * 96.0 / 72.0; // Преобразование размера шрифта из пунктов в пиксели
                    item.FontWeight = fontDialog.Font.Bold ? FontWeights.Bold : FontWeights.Regular;
                    item.FontStyle = fontDialog.Font.Italic ? FontStyles.Italic : FontStyles.Normal;
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var color = ((SolidColorBrush)gr_header.Background).Color;
                var colorF = ((SolidColorBrush)t2.Foreground).Color;

                StreamWriter f = new StreamWriter(saveFileDialog.FileName);
                f.WriteLine($"#{color.R:X2}{color.G:X2}{color.B:X2};" + $"#{colorF.R:X2}{colorF.G:X2}{colorF.B:X2}");
                f.WriteLine($"{fontDialog.Font.Name};{fontDialog.Font.Size * 96.0 / 72.0};{(fontDialog.Font.Bold ? "Bold" : "Regular")};{(fontDialog.Font.Italic ? "Italic" : "Normal")}");
                f.Close();

                tb_database.Text = saveFileDialog.FileName;
            }
        }
    }
}
