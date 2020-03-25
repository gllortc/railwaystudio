using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraBars;
using RailwayStudio.Common;
using Rwm.Otc;

namespace Rwm.Studio.Views
{
   public partial class MainView : DevExpress.XtraBars.Ribbon.RibbonForm, IContainerView
   {

      #region Constructors

      public MainView()
      {
         this.Hide();

         InitializeComponent();
         Initialize();

         try
         {
            OTCContext.Initialize();
            StudioContext.Initialize(this);
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }

         // Enable application visual styles
         DevExpress.Skins.SkinManager.EnableFormSkins();
         DevExpress.LookAndFeel.UserLookAndFeel.Default.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
         DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = StudioContext.SkinName;

         this.LoadToolbox(nbcPlugins);

         // Set the form title
         this.Text = Application.ProductName + " " + Application.ProductVersion;

         StudioContext.LogInformation("{0} v{1} started", Application.ProductName, Application.ProductVersion);
      }

      #endregion

      #region Properties

      public new DevExpress.XtraBars.Ribbon.RibbonForm ParentForm
      {
         get { return this; }
      }

      public DevExpress.XtraBars.Docking.DockManager DockManager
      {
         get { return dockManager; }
      }

      public DevExpress.XtraBars.Ribbon.RibbonControl RibbonControl
      {
         get { return ribbon; }
      }

      public RailwayStudio.Common.Controls.ConsoleControl LogConsole
      {
         get { return logConsole; }
      }

      public IWin32Window HwndHandle
      {
         get { return this; }
      }

      #endregion

      #region Event Handlers

      private void FrmMain_Load(object sender, System.EventArgs e)
      {
         this.ProjectOpenLast();

         if (OTCContext.Project != null)
         {
            ToolTipTitleItem ttti = new ToolTipTitleItem();
            ttti.Appearance.Image = Properties.Resources.ICO_PROJECT_16;
            ttti.Appearance.Options.UseImage = true;
            ttti.Image = Properties.Resources.ICO_PROJECT_16;
            ttti.Text = OTCContext.Project.Name;

            ToolTipItem tti = new ToolTipItem();
            tti.LeftIndent = 6;
            tti.Text = string.Format("File: <i>{0}</i><br>Location: <i>{1}</i>",
                                     System.IO.Path.GetFileName(OTCContext.Project.Filename),
                                     System.IO.Path.GetDirectoryName(OTCContext.Project.Filename));

            SuperToolTip stp = new SuperToolTip();
            stp.AllowHtmlText = DefaultBoolean.True;
            stp.Items.Add(ttti);
            stp.Items.Add(tti);

            cmdBarButtonProject.SuperTip = stp;
            cmdBarButtonProject.Caption = OTCContext.Project.Name;

            nbcPlugins.Enabled = true;
         }
         else
         {
            cmdBarButtonProject.Caption = "<no project>";
         }
      }

      private void MainView_Shown(object sender, EventArgs e)
      {
         this.Show();
      }

      /// <summary>
      /// Select the appropriate ribbon tab page for the active module.
      /// </summary>
      private void DocManager_DocumentActivate(object sender, DevExpress.XtraBars.Docking2010.Views.DocumentEventArgs e)
      {
         try
         {
            if (e.Document != null)
            {
               if (e.Document.Control is IPluginModule module)
               {
                  e.Document.Image = module.SmallIcon;
                  ribbon.SelectedPage = (DevExpress.XtraBars.Ribbon.RibbonPage)module.StartupRibbonPage;
               }
            }
            else
            {
               // Activate the main page when there are no loaded modules
               ribbon.SelectedPage = rbpMain;
            }
         }
         catch
         {
            // Activate the main page when there are no loaded modules
            ribbon.SelectedPage = rbpMain;
         }
      }

      private void DpToolbox_ClosedPanel(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
      {
         chkViewToolbox.Checked = false;
      }

      private void DockPanelConsole_ClosedPanel(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
      {
         chkViewConsole.Checked = false;
      }

      private void CmdFileExit_ItemClick(object sender, ItemClickEventArgs e)
      {
         this.Exit();
      }

      private void CmdFileSettings_ItemClick(object sender, ItemClickEventArgs e)
      {
         this.Settings();
      }

      private void CmdFileAbout_ItemClick(object sender, ItemClickEventArgs e)
      {
         this.About();
      }

      private void CmdProjectsOpen_ItemClick(object sender, ItemClickEventArgs e)
      {
         this.ProjectOpen();
      }

      private void CmdProjectsAdd_ItemClick(object sender, ItemClickEventArgs e)
      {
         this.ProjectCreate();
      }

      private void CmdProjectEdit_ItemClick(object sender, ItemClickEventArgs e)
      {
         this.ProjectEdit();
      }

      private void CmdProjectClose_ItemClick(object sender, ItemClickEventArgs e)
      {
         this.ProjectClose();
      }

      private void ChkViewToolbox_CheckedChanged(object sender, ItemClickEventArgs e)
      {
         if (((BarCheckItem)e.Item).Checked)
         {
            dockPanelToolbox.Show();
         }
      }

      private void ChkViewConsole_CheckedChanged(object sender, ItemClickEventArgs e)
      {
         if (((BarCheckItem)e.Item).Checked)
         {
            dockPanelConsole.Show();
         }
      }

      #endregion

      #region Private Members

      /// <summary>
      /// Initialize the instance data.
      /// </summary>
      private void Initialize()
      {
         this.Modules = new List<PluginModule>();

         nbcPlugins.Enabled = false;
         chkViewToolbox.Checked = true;
      }

      #endregion

   }
}