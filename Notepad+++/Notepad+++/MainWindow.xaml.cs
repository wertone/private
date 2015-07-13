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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
namespace Notepad___
{
   
    public partial class MainWindow : Window
    {
        string plik = "";
        public MainWindow()
        {
            InitializeComponent();
        }
        private MessageBoxResult czyzapisac()
        {
            MessageBoxResult result = MessageBox.Show("Czy chcesz zapisać zmiany?", "Notepad+++", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
                save_Click(null,null);

            return result;
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            if (plik != "")
            {
                StreamWriter f = new StreamWriter(plik);
                f.Write(textField.Text);
                f.Close();
            }
            else save2_Click(sender, e);
        }

        private void new_Click(object sender, RoutedEventArgs e)
        {
            if (textField.Text != "") 
            { 
                MessageBoxResult result = czyzapisac();
                    if(result == MessageBoxResult.Cancel)
                        return;
                    plik = "";
                    textField.Clear();
            }
        }

        private void open_Click(object sender, RoutedEventArgs e)
        {
            if(textField.Text != ""){
                MessageBoxResult result = czyzapisac();
                if(result == MessageBoxResult.Cancel)
                    return;
                plik = "";
                textField.Clear();
            }
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Plik tekstowy (*.txt)|*.txt";
            dialog.Multiselect = false;
            dialog.ShowDialog();
            if (dialog.FileName != "")
            {
                plik = dialog.FileName;
                StreamReader f = new StreamReader(plik);
                textField.Text = f.ReadToEnd();
                f.Close();
            }
        }

        private void save2_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Plik tekstowy (*.txt)|*.txt";
            dialog.ShowDialog();
            if (dialog.FileName != "")
            {
                plik = dialog.FileName;
                StreamWriter f = new StreamWriter(plik);
                f.Write(textField.Text);
                f.Close();
            }
        }
    }
}
