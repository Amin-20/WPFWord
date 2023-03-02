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

        private void contentTxtb_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                //contentTxtb.SelectAll();
            }
        }

        private void copyBtn_Click(object sender, RoutedEventArgs e)
        {
            DataObjectCopyingEventArgs eventArgs=contentTxtb.DataContext as DataObjectCopyingEventArgs;
        }

        private void selectAllBtn_Click(object sender, RoutedEventArgs e)
        {
            contentTxtb.SelectAll();
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
                }
            }
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            if (save.ShowDialog() == true)
            {
                using (var sw = new StreamWriter(save.FileName))
                {
                    sw.Write(contentTxtb.Text);
                    contentTxtb.Text = String.Empty;
                }
            }
        }
    }
}
