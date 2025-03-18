using Microsoft.Win32;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace fuggohidak
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Fuggohid> hidak = new();
        public MainWindow()
        {
            InitializeComponent();

            using (StreamReader sr = new StreamReader(
                    path: @"..\..\..\src\fuggohidak.csv",
                    encoding: Encoding.UTF8))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    hidak.Add(new Fuggohid(sr.ReadLine()));
                }
            }

            foreach (var item in hidak)
            {
                hidakNevei.Items.Add(item.Nev);

            }
        }
        private void MenuItemNew_Click(object sender, RoutedEventArgs e)
        {
            NewWindow newWindow = new NewWindow();
            newWindow.Owner = this;
            newWindow.Show();
        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MenuItemDialog_Click(object sender, RoutedEventArgs e)
        {
            NewWindow newWindow = new();
            newWindow.Owner = this;
            this.Visibility = Visibility.Hidden;
            newWindow.Closed += (s, args) => this.Visibility = Visibility.Visible;
            newWindow.ShowDialog();
        }

        private void Kilepes_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MenuItemOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new();
            if (openFileDialog.ShowDialog() == true)
            {
                //előzetesen elhelyezzük a forrásfájlt a szokott helyen
                string filePath = openFileDialog.FileName; //ide bekerül a fájl abszolút elérési útja
                                                           //feldolgozzuk a forrásfájlt a szokott módon
            }
        }
        private void hidakNevei_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = hidakNevei.SelectedIndex;
            if (index != -1)
            {
                hely.Text = $"{hidak[index].Hely}";
                orszag.Text = $"{hidak[index].Orszag}";
                hossz.Text = $"{hidak[index].Hossza}";
                ev.Text = $"{hidak[index].AtadasiEv}";

            }
            else
            {
                MessageBox.Show("hiba");
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            //elött
            int szam = 0;
            foreach (var item in hidak)
            {
                if (item.AtadasiEv < 2000)
                {
                    szam++;
                }
            }
            negyedik.Text = $"{szam}";
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            //után
            int szam = 0;
            foreach (var item in hidak)
            {
                if (item.AtadasiEv > 2000)
                {
                    szam++;
                }
            }
            negyedik.Text = $"{szam}";
        }
    }
}