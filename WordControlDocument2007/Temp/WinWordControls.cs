// Type: WinWordControl.StandAloneWordControl
// Assembly: WinWordControl, Version=3.8.8.6910, Culture=neutral, PublicKeyToken=null
// MVID: 41A01B65-1D68-40AA-B6CA-471043A9CB86
// Assembly location: C:\Users\madadi\Desktop\WinWordControl.dll

using Baridsoft.EOrg.Automation.BusinessObject;
using Baridsoft.EOrg.Framework.BusinessObject;
using Baridsoft.EOrg.Workflow.BusinessObject;
using Baridsoft.Utility;
using Microsoft.Office.Interop.Word;
using Office;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WinWordControl
{
  public class StandAloneWordControl : UserControl
  {
    private const int MF_BYPOSITION = 1024;
    private const int MF_REMOVE = 4096;
    private const int SWP_DRAWFRAME = 32;
    private const int SWP_NOMOVE = 2;
    private const int SWP_NOSIZE = 1;
    private const int SWP_NOZORDER = 4;
    private const string cstPassword = "WordDrivePass";
    public Document WordDocument;
    public ApplicationClass InternalWordApp;
    public int WordHwnd;
    public string FileName;
    private Container components;
    private bool DeactivateEvents;

    public bool ReadOnly { get; set; }

    public bool IsSign { get; set; }

    public bool Protect { get; set; }

    public string FullFilePath { get; set; }

    public string SignName { get; set; }

    public string EmptySignName { get; set; }

    public bool ShowSignature { get; set; }

    public bool AccessToSaveAndAssignParameters { get; set; }

    public StandAloneWordControl()
    {
      this.InitializeComponent();
    }

    [DllImport("user32.dll")]
    public static int FindWindow(string strclassName, string strWindowName);

    [DllImport("user32.dll")]
    private static int SetParent(int hWndChild, int hWndNewParent);

    [DllImport("user32.dll")]
    private static bool SetWindowPos(int hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

    [DllImport("user32.dll")]
    private static bool MoveWindow(int hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

    [DllImport("user32.dll")]
    private static int DrawMenuBar(int hWnd);

    [DllImport("user32.dll")]
    private static int GetMenuItemCount(int hMenu);

    [DllImport("user32.dll")]
    private static int GetSystemMenu(int hWnd, bool bRevert);

    [DllImport("user32.dll")]
    private static int RemoveMenu(int hMenu, int nPosition, int wFlags);

    protected override void Dispose(bool disposing)
    {
      this.CloseControl();
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.Name = "StandAloneWordControl";
      this.Size = new Size(440, 336);
      this.Resize += new EventHandler(this.OnResize);
    }

    public void CloseControl()
    {
      this.ReleaseWordApp();
    }

    private void OnClose(Document doc, ref bool cancel)
    {
    }

    private void OnOpenDoc(Document doc)
    {
      this.OnNewDoc(doc);
    }

    private void OnNewDoc(Document doc)
    {
      if (this.DeactivateEvents)
        return;
      this.DeactivateEvents = true;
      object obj = (object) null;
      doc.Close(ref obj, ref obj, ref obj);
      this.DeactivateEvents = false;
    }

    private void OnQuit()
    {
      if (!this.DeactivateEvents)
        this.CloseControl();
      this.InternalWordApp = (ApplicationClass) null;
    }

    private void UnregisterWordEvents()
    {
      try
      {
        if (this.InternalWordApp == null)
          return;
        // ISSUE: method pointer
        this.InternalWordApp.remove_DocumentBeforeClose(new ApplicationEvents4_DocumentBeforeCloseEventHandler((object) this, (UIntPtr) __methodptr(OnClose)));
        // ISSUE: method pointer
        this.InternalWordApp.remove_DocumentBeforeSave(new ApplicationEvents4_DocumentBeforeSaveEventHandler((object) this, (UIntPtr) __methodptr(InternalWordApp_DocumentBeforeSave)));
        // ISSUE: method pointer
        this.InternalWordApp.remove_DocumentOpen(new ApplicationEvents4_DocumentOpenEventHandler((object) this, (UIntPtr) __methodptr(OnOpenDoc)));
        // ISSUE: method pointer
        this.InternalWordApp.ApplicationEvents2_Event_remove_Quit(new ApplicationEvents2_QuitEventHandler((object) this, (UIntPtr) __methodptr(OnQuit)));
      }
      catch
      {
      }
    }

    private void RegisterWordEvents()
    {
      try
      {
        if (this.InternalWordApp == null)
          return;
        this.InternalWordApp.CommandBars.AdaptiveMenus = false;
        // ISSUE: method pointer
        this.InternalWordApp.add_DocumentBeforeClose(new ApplicationEvents4_DocumentBeforeCloseEventHandler((object) this, (UIntPtr) __methodptr(OnClose)));
        // ISSUE: method pointer
        this.InternalWordApp.add_NewDocument(new ApplicationEvents4_NewDocumentEventHandler((object) this, (UIntPtr) __methodptr(OnNewDoc)));
        // ISSUE: method pointer
        this.InternalWordApp.add_DocumentBeforeSave(new ApplicationEvents4_DocumentBeforeSaveEventHandler((object) this, (UIntPtr) __methodptr(InternalWordApp_DocumentBeforeSave)));
        // ISSUE: method pointer
        this.InternalWordApp.add_DocumentOpen(new ApplicationEvents4_DocumentOpenEventHandler((object) this, (UIntPtr) __methodptr(OnOpenDoc)));
        // ISSUE: method pointer
        this.InternalWordApp.add_Quit(new ApplicationEvents4_QuitEventHandler((object) this, (UIntPtr) __methodptr(OnQuit)));
      }
      catch
      {
      }
    }

    private void InternalWordApp_DocumentBeforeSave(Document Doc, ref bool SaveAsUI, ref bool Cancel)
    {
      if (this.AccessToSaveAndAssignParameters)
        return;
      Cancel = SaveAsUI;
    }

    private void ReleaseDocument()
    {
      object obj = Type.Missing;
      try
      {
        if (this.WordDocument != null)
          this.WordDocument.Close(ref obj, ref obj, ref obj);
      }
      catch
      {
      }
      this.WordDocument = (Document) null;
    }

    private void PrepareWordApp()
    {
      object Template = (object) this.FileName;
      object NewTemplate = (object) false;
      object DocumentType = (object) 0;
      object Visible = (object) true;
      object obj1 = (object) false;
      object obj2 = (object) "WordDrivePass";
      WdProtectionType wdProtectionType = WdProtectionType.wdAllowOnlyFormFields;
      try
      {
        string caption = this.InternalWordApp.Caption;
        this.InternalWordApp.Caption = "Barid-Word-Instance" + (object) DateTime.Now.Ticks;
        if (this.WordHwnd == 0)
          this.WordHwnd = StandAloneWordControl.FindWindow("Opusapp", this.InternalWordApp.Caption);
        this.InternalWordApp.Caption = caption;
        if (this.WordHwnd == 0)
          return;
        StandAloneWordControl.SetParent(this.WordHwnd, this.Handle.ToInt32());
        if (this.InternalWordApp != null)
        {
          if (this.InternalWordApp.Documents != null)
          {
            this.WordDocument = this.InternalWordApp.Documents.Add(ref Template, ref NewTemplate, ref DocumentType, ref Visible);
            if (this.Protect)
            {
              Document document = this.WordDocument;
              int num = (int) wdProtectionType;
              // ISSUE: explicit reference operation
              // ISSUE: variable of a reference type
              object& NoReset = @obj1;
              // ISSUE: explicit reference operation
              // ISSUE: variable of a reference type
              object& Password = @obj2;
              object obj3 = (object) Missing.Value;
              // ISSUE: explicit reference operation
              // ISSUE: variable of a reference type
              object& UseIRM = @obj3;
              object obj4 = (object) Missing.Value;
              // ISSUE: explicit reference operation
              // ISSUE: variable of a reference type
              object& EnforceStyleLock = @obj4;
              document.Protect((WdProtectionType) num, NoReset, Password, UseIRM, EnforceStyleLock);
            }
          }
        }
        try
        {
          this.InternalWordApp.ActiveWindow.ActivePane.DisplayRulers = true;
          this.InternalWordApp.ActiveWindow.DisplayRightRuler = true;
          this.InternalWordApp.ActiveWindow.DisplayScreenTips = true;
          this.InternalWordApp.ActiveWindow.DisplayVerticalRuler = true;
          this.InternalWordApp.ActiveWindow.DisplayRightRuler = true;
          this.InternalWordApp.ActiveWindow.ActivePane.DisplayRulers = true;
          this.InternalWordApp.ActiveWindow.ActivePane.View[] = WdViewType.wdPrintView;
        }
        catch
        {
        }
      }
      catch
      {
      }
    }

    private bool ShouldDisableItem(string xCaption)
    {
      bool flag = false;
      string str = xCaption.ToLower().Replace("&", "");
      if (str.Contains("exit") || str.Contains("open") || (str.Contains("new") || str.Contains("close")))
        flag = true;
      return flag;
    }

    private void PrepareCommandBars()
    {
      try
      {
        if (this.WordHwnd == 0)
          return;
        int count1 = this.InternalWordApp.ActiveWindow.Application.CommandBars.Count;
        for (int index1 = 1; index1 <= count1; ++index1)
        {
          try
          {
            string name = this.InternalWordApp.ActiveWindow.Application.CommandBars[(object) index1].Name;
            if (name == "Standard")
            {
              for (int index2 = 1; index2 <= 2; ++index2)
                this.InternalWordApp.ActiveWindow.Application.CommandBars[(object) index1].Controls[(object) index2].Enabled = false;
            }
            try
            {
              if (name == "Menu Bar")
              {
                int count2 = this.InternalWordApp.ActiveWindow.Application.CommandBars[(object) index1].Controls.Count;
                for (int index2 = 1; index2 <= count2; ++index2)
                {
                  if (this.InternalWordApp.ActiveWindow.Application.CommandBars[(object) index1].Controls[(object) index2].Caption.ToLower().Contains("file"))
                  {
                    IEnumerator enumerator = ((CommandBarPopup) this.InternalWordApp.ActiveWindow.Application.CommandBars[(object) index1].Controls[(object) index2]).get_Controls().GetEnumerator();
                    try
                    {
                      while (enumerator.MoveNext())
                      {
                        CommandBarControl commandBarControl = (CommandBarControl) enumerator.Current;
                        if (this.ShouldDisableItem(commandBarControl.get_Caption()))
                          commandBarControl.set_Enabled(false);
                      }
                      break;
                    }
                    finally
                    {
                      IDisposable disposable = enumerator as IDisposable;
                      if (disposable != null)
                        disposable.Dispose();
                    }
                  }
                }
              }
            }
            catch (Exception ex)
            {
            }
          }
          catch (Exception ex)
          {
            int num = (int) MessageBox.Show(ex.ToString());
          }
        }
      }
      catch
      {
      }
    }

    private void ReleaseWordApp()
    {
      try
      {
        if (this.InternalWordApp == null)
          return;
        this.DeactivateEvents = true;
        object obj = (object) false;
        object SaveChanges = (object) false;
        if (this.WordDocument != null)
          this.WordDocument.Close(ref obj, ref obj, ref obj);
        this.WordDocument = (Document) null;
        if (this.InternalWordApp.Documents.Count == 0)
        {
          this.UnregisterWordEvents();
          this.InternalWordApp.Quit(ref SaveChanges, ref obj, ref obj);
        }
        this.DeactivateEvents = false;
      }
      catch (Exception ex)
      {
      }
      finally
      {
        this.InternalWordApp = (ApplicationClass) null;
      }
    }

    public void LoadDocument(string x_filename)
    {
      this.DeactivateEvents = true;
      this.FileName = x_filename;
      this.ReleaseDocument();
      this.ReleaseWordApp();
      this.InternalWordApp = new ApplicationClass();
      this.PrepareWordApp();
      if (this.WordHwnd != 0)
      {
        this.PrepareCommandBars();
        try
        {
          this.InternalWordApp.Visible = true;
          StandAloneWordControl.SetWindowPos(this.WordHwnd, this.Handle.ToInt32(), 0, 0, this.Bounds.Width, this.Bounds.Height, 39U);
          this.OnResize();
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show("Error: do not load the document into the control until the parent window is shown!");
        }
        try
        {
          int systemMenu = StandAloneWordControl.GetSystemMenu(this.WordHwnd, false);
          if (systemMenu > 0)
          {
            int menuItemCount = StandAloneWordControl.GetMenuItemCount(systemMenu);
            StandAloneWordControl.RemoveMenu(systemMenu, menuItemCount - 1, 5120);
            StandAloneWordControl.RemoveMenu(systemMenu, menuItemCount - 2, 5120);
            StandAloneWordControl.RemoveMenu(systemMenu, menuItemCount - 3, 5120);
            StandAloneWordControl.RemoveMenu(systemMenu, menuItemCount - 4, 5120);
            StandAloneWordControl.RemoveMenu(systemMenu, menuItemCount - 5, 5120);
            StandAloneWordControl.RemoveMenu(systemMenu, menuItemCount - 6, 5120);
            StandAloneWordControl.RemoveMenu(systemMenu, menuItemCount - 7, 5120);
            StandAloneWordControl.RemoveMenu(systemMenu, menuItemCount - 8, 5120);
            StandAloneWordControl.DrawMenuBar(this.WordHwnd);
          }
        }
        catch
        {
        }
        this.Parent.Focus();
      }
      this.RegisterWordEvents();
      this.DeactivateEvents = false;
    }

    public void RestoreWord()
    {
      try
      {
        int count = this.InternalWordApp.ActiveWindow.Application.CommandBars.Count;
        for (int index = 0; index < count; ++index)
        {
          try
          {
            this.InternalWordApp.ActiveWindow.Application.CommandBars[(object) index].Enabled = true;
          }
          catch
          {
          }
        }
      }
      catch
      {
      }
    }

    private void OnResize()
    {
      int width = SystemInformation.Border3DSize.Width;
      int height = SystemInformation.Border3DSize.Height;
      int captionHeight = SystemInformation.CaptionHeight;
      int windowCaptionHeight = SystemInformation.ToolWindowCaptionHeight;
        StandAloneWordControl.MoveWindow(this.WordHwnd, -2*width, -2*height - captionHeight ,
            this.Bounds.Width + 4*width, this.Bounds.Height + captionHeight + 4*height + windowCaptionHeight - 18, true);
    }

    private void OnResize(object sender, EventArgs e)
    {
      this.OnResize();
    }

    public void RestoreCommandBars()
    {
      try
      {
        int count1 = this.InternalWordApp.ActiveWindow.Application.CommandBars.Count;
        for (int index1 = 1; index1 <= count1; ++index1)
        {
          try
          {
            string name = this.InternalWordApp.ActiveWindow.Application.CommandBars[(object) index1].Name;
            if (name == "Standard")
            {
              int count2 = this.InternalWordApp.ActiveWindow.Application.CommandBars[(object) index1].Controls.Count;
              for (int index2 = 1; index2 <= 2; ++index2)
                this.InternalWordApp.ActiveWindow.Application.CommandBars[(object) index1].Controls[(object) index2].Enabled = true;
            }
            try
            {
              if (name == "Menu Bar")
              {
                int count2 = this.InternalWordApp.ActiveWindow.Application.CommandBars[(object) index1].Controls.Count;
                for (int index2 = 1; index2 <= count2; ++index2)
                {
                  if (this.InternalWordApp.ActiveWindow.Application.CommandBars[(object) index1].Controls[(object) index2].Caption.ToLower().Contains("file"))
                  {
                    IEnumerator enumerator = ((CommandBarPopup) this.InternalWordApp.ActiveWindow.Application.CommandBars[(object) index1].Controls[(object) index2]).get_Controls().GetEnumerator();
                    try
                    {
                      while (enumerator.MoveNext())
                      {
                        CommandBarControl commandBarControl = (CommandBarControl) enumerator.Current;
                        if (this.ShouldDisableItem(commandBarControl.get_Caption()))
                          commandBarControl.set_Enabled(true);
                      }
                      break;
                    }
                    finally
                    {
                      IDisposable disposable = enumerator as IDisposable;
                      if (disposable != null)
                        disposable.Dispose();
                    }
                  }
                }
              }
            }
            catch (Exception ex)
            {
            }
          }
          catch (Exception ex)
          {
            int num = (int) MessageBox.Show(ex.ToString());
          }
        }
      }
      catch
      {
      }
    }

    public void NewBlankDocument(Document document1)
    {
      try
      {
        object SaveChanges = (object) true;
        object obj = (object) false;
        XmlUtility xmlUtility = new XmlUtility();
        string str = (string) xmlUtility.EOrgDir + (object) "\\" + (string) (object) xmlUtility.GetCurrentProcess().Id + "\\" + document1.get_Name() + ".doc";
        object Template = (object) "";
        object NewTemplate = (object) false;
        object DocumentType = (object) WdDocumentType.wdTypeDocument;
        object Visible = (object) true;
        try
        {
          ApplicationClass applicationClass = new ApplicationClass();
          Document document = applicationClass.Documents.Add(ref Template, ref NewTemplate, ref DocumentType, ref Visible);
          this.SaveAsDoc(document, str);
          this.Close(document);
          if (applicationClass.Documents.Count == 0)
            applicationClass.Quit(ref SaveChanges, ref obj, ref obj);
        }
        catch
        {
        }
        this.LoadDocument(str);
      }
      catch
      {
      }
    }

    private Document Open(ApplicationClass wordApp, string fileName, bool readOnly)
    {
      object obj1 = (object) fileName;
      object obj2 = (object) false;
      object obj3 = (object) (bool) (readOnly ? 1 : 0);
      object obj4 = (object) false;
      object obj5 = (object) "";
      object obj6 = (object) "";
      object obj7 = (object) false;
      object obj8 = (object) "";
      object obj9 = (object) "";
      object obj10 = (object) WdOpenFormat.wdOpenFormatAuto;
      object obj11 = (object) "";
      object obj12 = (object) true;
      object obj13 = (object) false;
      object obj14 = (object) "WordDrivePass";
      WdProtectionType wdProtectionType = WdProtectionType.wdAllowOnlyFormFields;
      Documents documents = wordApp.Documents;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      object& FileName = @obj1;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      object& ConfirmConversions = @obj2;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      object& ReadOnly = @obj3;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      object& AddToRecentFiles = @obj4;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      object& PasswordDocument = @obj5;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      object& PasswordTemplate = @obj6;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      object& Revert = @obj7;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      object& WritePasswordDocument = @obj8;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      object& WritePasswordTemplate = @obj9;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      object& Format = @obj10;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      object& Encoding = @obj11;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      object& Visible = @obj12;
      object obj15 = (object) Missing.Value;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      object& OpenAndRepair = @obj15;
      object obj16 = (object) Missing.Value;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      object& DocumentDirection = @obj16;
      object obj17 = (object) Missing.Value;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      object& NoEncodingDialog = @obj17;
      object obj18 = (object) Missing.Value;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      object& XMLTransform = @obj18;
      Document document1 = documents.Open(FileName, ConfirmConversions, ReadOnly, AddToRecentFiles, PasswordDocument, PasswordTemplate, Revert, WritePasswordDocument, WritePasswordTemplate, Format, Encoding, Visible, OpenAndRepair, DocumentDirection, NoEncodingDialog, XMLTransform);
      if (readOnly && document1 != null)
      {
        Document document2 = document1;
        int num = (int) wdProtectionType;
        // ISSUE: explicit reference operation
        // ISSUE: variable of a reference type
        object& NoReset = @obj13;
        // ISSUE: explicit reference operation
        // ISSUE: variable of a reference type
        object& Password = @obj14;
        object obj19 = (object) Missing.Value;
        // ISSUE: explicit reference operation
        // ISSUE: variable of a reference type
        object& UseIRM = @obj19;
        object obj20 = (object) Missing.Value;
        // ISSUE: explicit reference operation
        // ISSUE: variable of a reference type
        object& EnforceStyleLock = @obj20;
        document2.Protect((WdProtectionType) num, NoReset, Password, UseIRM, EnforceStyleLock);
      }
      return document1;
    }

    public void ShowWithoutSignature(string fileName, LetterInvolvedPersonList otherSignList, bool isMainSignLetterPrepare, bool isRegisteredLP)
    {
      object SaveChanges = (object) true;
      object obj = (object) false;
      XmlUtility xmlUtility = new XmlUtility();
      string str = string.Concat(new object[4]
      {
        (object) string.Concat(new object[4]
        {
          (object) (string) xmlUtility.EOrgDir,
          (object) "\\",
          (object) xmlUtility.GetCurrentProcess().Id,
          (object) "\\"
        }),
        (object) "\\newFileName",
        (object) DateTime.Now.Ticks,
        (object) ".doc"
      });
      try
      {
        this.InternalWordApp = new ApplicationClass();
        Document document = this.Open(this.InternalWordApp, fileName, false);
        this.ClearSign((Microsoft.Office.Interop.Word.Application) this.InternalWordApp, isMainSignLetterPrepare, otherSignList);
        this.SaveAsDoc(document, str);
        if (document != null)
          this.Close(document);
        if (this.InternalWordApp.Documents.Count == 0)
          this.InternalWordApp.Quit(ref SaveChanges, ref obj, ref obj);
        this.InternalWordApp = (ApplicationClass) null;
      }
      catch
      {
      }
      this.LoadDocument(str);
    }

    private void SaveAsDoc(Document document1, string fileName)
    {
      object obj1 = (object) fileName;
      object obj2 = (object) WdSaveFormat.wdFormatTemplate;
      object obj3 = (object) false;
      object obj4 = (object) "";
      object obj5 = (object) false;
      object obj6 = (object) "";
      object obj7 = (object) false;
      object obj8 = (object) false;
      object obj9 = (object) false;
      object obj10 = (object) false;
      object obj11 = (object) false;
      Document document = document1;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      object& FileName = @obj1;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      object& FileFormat = @obj2;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      object& LockComments = @obj3;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      object& Password = @obj4;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      object& AddToRecentFiles = @obj5;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      object& WritePassword = @obj6;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      object& ReadOnlyRecommended = @obj7;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      object& EmbedTrueTypeFonts = @obj8;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      object& SaveNativePictureFormat = @obj9;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      object& SaveFormsData = @obj10;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      object& SaveAsAOCELetter = @obj11;
      object obj12 = (object) Missing.Value;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      object& Encoding = @obj12;
      object obj13 = (object) Missing.Value;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      object& InsertLineBreaks = @obj13;
      object obj14 = (object) Missing.Value;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      object& AllowSubstitutions = @obj14;
      object obj15 = (object) Missing.Value;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      object& LineEnding = @obj15;
      object obj16 = (object) Missing.Value;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      object& AddBiDiMarks = @obj16;
      document.SaveAs(FileName, FileFormat, LockComments, Password, AddToRecentFiles, WritePassword, ReadOnlyRecommended, EmbedTrueTypeFonts, SaveNativePictureFormat, SaveFormsData, SaveAsAOCELetter, Encoding, InsertLineBreaks, AllowSubstitutions, LineEnding, AddBiDiMarks);
    }

    public void Close(Document activeDocument)
    {
      object OriginalFormat = (object) false;
      object RouteDocument = (object) false;
      object SaveChanges = (object) false;
      object Password = (object) "WordDrivePass";
      if (activeDocument == null)
        return;
      try
      {
        if (activeDocument.ProtectionType != WdProtectionType.wdNoProtection)
          activeDocument.Unprotect(ref Password);
        activeDocument.Close(ref SaveChanges, ref OriginalFormat, ref RouteDocument);
      }
      catch (Exception ex)
      {
      }
    }

    private void ClearSign(Microsoft.Office.Interop.Word.Application myApp, bool isMainSign, LetterInvolvedPersonList otherSignList)
    {
      try
      {
        List<Bookmark> list1 = new List<Bookmark>();
        foreach (Bookmark bookmark in myApp.ActiveDocument.Bookmarks)
          list1.Add(bookmark);
        for (int index = 0; index < list1.Count; ++index)
        {
          Bookmark bookmark = list1[index];
          string str;
          try
          {
            str = bookmark[];
          }
          catch
          {
            continue;
          }
          if (str.StartsWith(((object) (Bookmarks) 2).ToString()))
          {
            bookmark.Select();
            if (isMainSign)
              myApp.Selection[] = "";
            object Range = (object) myApp.Selection.Range;
            myApp.ActiveDocument.Bookmarks.Add(((object) (Bookmarks) 2).ToString(), ref Range);
          }
        }
        ((BusinessObjectList) otherSignList).SetSort((BusinessObjectList.SortOrderType) 0, new string[1]
        {
          "SignIndex"
        });
        List<Bookmark> list2 = new List<Bookmark>();
        foreach (Bookmark bookmark in list1)
        {
          try
          {
            if (bookmark[].StartsWith(((object) (Bookmarks) 8).ToString()))
              list2.Add(bookmark);
          }
          catch
          {
          }
        }
        IEnumerator enumerator = ((BusinessObjectList) otherSignList).GetEnumerator();
        try
        {
          while (enumerator.MoveNext())
          {
            LetterInvolvedPerson letterInvolvedPerson = (LetterInvolvedPerson) enumerator.Current;
            for (int index = 0; index < list2.Count; ++index)
            {
              Bookmark bookmark = list2[index];
              string Name;
              try
              {
                Name = bookmark[];
              }
              catch
              {
                continue;
              }
              if (letterInvolvedPerson.get_IsSign())
              {
                bookmark.Select();
                if (isMainSign)
                  myApp.Selection[] = "";
                list2.Remove(bookmark);
                object Range = (object) myApp.Selection.Range;
                myApp.ActiveDocument.Bookmarks.Add(Name, ref Range);
              }
            }
          }
        }
        finally
        {
          IDisposable disposable = enumerator as IDisposable;
          if (disposable != null)
            disposable.Dispose();
        }
      }
      catch (Exception ex)
      {
      }
    }
  }
}
