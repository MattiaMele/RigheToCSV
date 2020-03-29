using RigheToCSVPresenter;
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

        public RigheToCSV Presenter
        {
            get
            {
                return DataContext as RigheToCSV;
            }
            
        }
        public ucRigheToCSV()
        {
            InitializeComponent();
        }

        private void _EseguiOperazione(object sender, RoutedEventArgs e)
        {
            try
            {
                Presenter.AvviaConversione();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRORE");
            }
            
        }

        private void _DropHappened(object sender, DragEventArgs e)
        {
            try
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                Presenter.ImpostaFilePath(files);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRORE");
            }
            
        }

        private void TextBox_PreviewDragOver(object sender, DragEventArgs e)
        {
            e.Handled = true;
        }
    }
}
