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

namespace EventParser
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

        private void ParseBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String inputPath = InputFileTxt.Text;
                // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(inputPath))
                {
                    // Read the stream to a string, and write the string to the console.
                    String line = sr.ReadToEnd();
                    Console.WriteLine(line);
                }
            }
            catch (Exception ee)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(ee.Message);
            }
        }
    }
}
