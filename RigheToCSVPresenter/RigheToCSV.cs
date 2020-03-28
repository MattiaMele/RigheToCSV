using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RigheToCSVPresenter
{
    public class RigheToCSV : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        string[] _righeFile;

        string _filePathInput;
        public string FilePathInput
        {
            get
            {
                return _filePathInput;
            }
            set
            {
                if (_filePathInput != value)
                {
                    _filePathInput = value;
                    OnPropertyChanged(nameof(FilePathInput));
                }
            }
        }
        string _filePathOutput;
        public string FilePathOutput
        {
            get
            {
                return _filePathOutput;
            }
            set
            {
                if (_filePathOutput != value)
                {
                    _filePathOutput = value;
                    OnPropertyChanged(nameof(FilePathOutput));
                }
            }
        }
        int _righeInizialiDaSaltare = 0;
        public int RigheInizialiDaSaltare
        {
            get
            {
                return _righeInizialiDaSaltare;
            }
            set
            {
                if (_righeInizialiDaSaltare != value)
                {
                    _righeInizialiDaSaltare = value;
                    OnPropertyChanged(nameof(RigheInizialiDaSaltare));
                }
            }
        }

        int _numeroColonne;
        public int NumeroColonne
        {
            get
            {
                return _numeroColonne;
            }
            set
            {
                if (_numeroColonne != value)
                {
                    _numeroColonne = value;
                    OnPropertyChanged(nameof(NumeroColonne));
                }
            }
        }

        string _nuovoPuntoEVirgola = ",";
        public string NuovoPuntoEVirgola
        {
            get
            {
                return _nuovoPuntoEVirgola;
            }
            set
            {
                if (_nuovoPuntoEVirgola != value)
                {
                    _nuovoPuntoEVirgola = value;
                    OnPropertyChanged(nameof(NuovoPuntoEVirgola));
                    OnPropertyChanged(nameof(NumeroCaratteriSostitutivi));
                }
            }
        }

        public int NumeroCaratteriSostitutivi
        {
            get
            {
                return NuovoPuntoEVirgola.Length;
            }
            
        }

        


        public void AvviaConversione()
        {
            try
            {
                _ControlliLogici();

                _righeFile = File.ReadAllLines(FilePathInput);

                using (StreamWriter newfile = new StreamWriter(FilePathOutput))
                {
                    int j = 0;
                    StringBuilder rigaOutput = new StringBuilder();

                    for (int i = RigheInizialiDaSaltare; i < _righeFile.Length; i++)
                    {

                        rigaOutput.Append(_righeFile[i].Trim().Replace(";",NuovoPuntoEVirgola));
                        j++;

                        if (j >= NumeroColonne)
                        {
                            newfile.WriteLine(rigaOutput.ToString());
                            j = 0;
                            rigaOutput = new StringBuilder();
                        }
                        else
                        {
                            rigaOutput.Append(';');
                        }

                    }


                }

                MessageBox.Show($"Operazione completata, nuovo file creato in {FilePathOutput}");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool _ControlliLogici()
        {
            try
            {
                if(NumeroColonne <= 0) { throw new Exception("Inserire un numero di colonne"); }
                if(RigheInizialiDaSaltare < 0) { RigheInizialiDaSaltare = 0; }
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void OnPropertyChanged(string propieta)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propieta));
        }
    }
}
