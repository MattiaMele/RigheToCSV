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

namespace RigheToCSVUI
{
    /// <summary>
    /// Interaction logic for ucRigheToCSV.xaml
    /// </summary>
    public partial class ucRigheToCSV : UserControl
    {
        public ucRigheToCSV()
        {
            InitializeComponent();
        }

        private void _EseguiOperazione(object sender, RoutedEventArgs e)
        {
            try
            {
                (DataContext as dynamic).AvviaConversione();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRORE");
            }
            
        }
    }
}
