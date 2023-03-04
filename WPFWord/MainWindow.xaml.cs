using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace WPFWord
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string location = "";

        private void copyBtn_Click(object sender, RoutedEventArgs e)
        {
            contentTxtb.Copy();
        }

        private void selectAllBtn_Click(object sender, RoutedEventArgs e)
        {
            contentTxtb.SelectAll();
            contentTxtb.Focus();
        }

        private void openBtn_Click(object sender, RoutedEventArgs e)
        {
            var openDialog = new OpenFileDialog();
            openDialog.Filter = "All Files(*.*)|*.*|Text Files(*.txt)| *.txt";
            openDialog.FilterIndex = 2;


            if (openDialog.ShowDialog() == true)
            {
                using (var sr = File.OpenText(openDialog.FileName))
                {
                    contentTxtb.Text = sr.ReadToEnd();
                    location=Path.GetFullPath(openDialog.FileName);
                    sourceTxtbl.Text = location;
                }
            }
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Succesfully","Saved",MessageBoxButton.OK,MessageBoxImage.Information);
            File.WriteAllText(location, contentTxtb.Text);
            contentTxtb.Text = "";
            location = "";
            sourceTxtbl.Text = "";
        }

        private void cutBtn_Click(object sender, RoutedEventArgs e)
        {
            contentTxtb.Cut();
        }

        private void pasteBtn_Click(object sender, RoutedEventArgs e)
        {
            contentTxtb.Paste();
        }
    }
}
