using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Printing;
using System.Printing;
using System.Windows.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Sbn.AdvancedControls.WordControlDocument
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class WCSettingViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the WCSettingViewModel class.
        /// </summary>
        public WCSettingViewModel()
        {
            SaveCommand = new RelayCommand(Save,CanSave);
            PrinterSettingCommand = new RelayCommand(PrinterSetting,CanPrinterSetting);
        }

        private bool CanPrinterSetting()
        {

            if (CurrentPrinter == null)
                return false;
            return true;
        }

        private void PrinterSetting()
        {
          

            PrintDialog pp = new PrintDialog();
            pp.PrintQueue = CurrentPrinter;
            pp.ShowDialog();
          
            
            //CurrentPrinter.QueuePrintProcessor.
        }

        private bool CanSave()
        {

            if (string.IsNullOrEmpty(PrinterName) || string.IsNullOrWhiteSpace(PrinterName))
                return false;

            return true;
        }

        private void Save()
        {
            Properties.Settings.Default.ImagePrinter = PrinterName;
            Properties.Settings.Default.Extention = Extention;
            Properties.Settings.Default.Save();

        }


        private string _printerName;

        public string PrinterName
        {
            get { return _printerName; }
            set
            {
                _printerName = value;
                RaisePropertyChanged("PrinterName");
            }
        }


        private PrintQueue _currentPrinter;

        public PrintQueue CurrentPrinter
        {
            get
            {
                
                foreach (var printQueue in AllPrinter)
                {
                    if (printQueue.FullName == PrinterName)
                    {
                        _currentPrinter = printQueue;
                        break;
                    }
                }


                return _currentPrinter;
            }
            set
            {
                _currentPrinter = value;
                if (_currentPrinter != null)
                {
                    PrinterName = _currentPrinter.FullName;
                }
                else
                {
                    PrinterName = "";
                }
                RaisePropertyChanged("CurrentPrinter");
            }
        }

        private string _extention;

        public string Extention
        {
            get { return _extention; }
            set
            {
                _extention = value;
                RaisePropertyChanged("Extention");
            }
        }


        private Collection<PrintQueue> _allPrinter;
        public Collection<PrintQueue> AllPrinter
        {
            get
            {
                if (_allPrinter == null)
                    _allPrinter = GetAllPrinter();
                return _allPrinter;
            }
        }


        public Collection<PrintQueue> GetAllPrinter()
        {
            PrintQueue printQueue1 = null;
            LocalPrintServer localPrintServer1 = new LocalPrintServer();


            // Retrieving collection of local printer on user machine
            PrintQueueCollection localPrinterCollection1 =
                localPrintServer1.GetPrintQueues();


            //printQueue = localPrintServer.DefaultPrintQueue;



            IEnumerator<PrintQueue> all = localPrinterCollection1.GetEnumerator();
            Collection<PrintQueue> AllPrinter = new Collection<PrintQueue>();

            while (all.MoveNext())
            {
                printQueue1 = all.Current;
                //  this.comboBox1.Items.Add(printQueue.FullName);
                AllPrinter.Add(all.Current);
            }

            return AllPrinter;
        }



        public RelayCommand SaveCommand { get; set; }
        public RelayCommand PrinterSettingCommand { get; set; }


    }
}