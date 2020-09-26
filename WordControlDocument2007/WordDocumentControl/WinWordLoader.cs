using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.Office.Interop.Word;

namespace Sbn.AdvancedControls.WordControlDocument
{
  
    /// <summary>

    /// Helper class to manage the Word.Application coclass.

    /// </summary>

    public class WinWordLoader : IDisposable
    {
        private  Application wordApp = null;
        private bool isNewApp = false;

        private bool disposed = false;
        
        public WinWordLoader()
        {
            // Check if Word is registered in the ROT.
            
            try
            {
                
                wordApp = (Application)Marshal.
                    GetActiveObject("Word.Application");
            }
            catch
            {
                wordApp = null;
            }
            // Load Word if it's not.

            if(wordApp == null)
            {
                try
                {
                    wordApp = new Application();
                    isNewApp = true;
                }
                catch
                {
                    wordApp = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    // Dispose managed resources.
                    
                }
                
                // Dispose unmanaged resources.

                if(wordApp != null)
                {
                    try
                    {
                        if(isNewApp && wordApp.Documents.Count == 0)
                        {
                            object arg1 = WdSaveOptions.
                                            wdDoNotSaveChanges;
                            object arg2 = null;
                            object arg3 = null;
                            wordApp.Quit(ref arg1, ref arg2, ref arg3);

                            // Wait until Word shuts down.

                            for(;;)
                            {
                                Thread.Sleep(100);
                                try
                                {
                                    // When word shuts down this call 

                                    // throws an exception.

                                    string dummy = wordApp.Version;
                                }
                                catch
                                {
                                    break;
                                }
                            }
                        }
                    }
                    catch {}

                    wordApp = null;
                }
            }
            disposed = true;
        }

        ~WinWordLoader()
        {
            Dispose(false);
        }

        public Application Application
        {
            get
            {
                return wordApp;
            }
        }
    }
}

