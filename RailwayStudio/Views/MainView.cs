using DevExpress.Utils;
using DevExpress.XtraBars;
using RailwayStudio.Common;
using Rwm.Otc;
using Rwm.Studio.Views.Controllers;
using System;
using System.Windows.Forms;

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

         // Create main controller
         this.Controller = new MainController(this);
         this.Controller.LoadToolbox(nbcPlugins);

         // Set the form title
         this.Text = Application.ProductName + " " + Application.ProductVersion;

         StudioContext.LogInformation("{0} v{1} started", Application.ProductName, Application.ProductVersion);
      }

      #endregion

      #region Properties

      internal MainController Controller { get; private set; }

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

      #region Methods

      public void OpenPluginModule(string className, params object[] args)
      {
         this.Controller.OpenPluginModule(className, args);
      }

      #endregion

      #region Event Handlers

      private void FrmMain_Load(object sender, System.EventArgs e)
      {
         StudioContext.LoadLastProject();

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

            bsiProjectInfo.SuperTip = stp;
            bsiProjectInfo.Caption = OTCContext.Project.Name;

            nbcPlugins.Enabled = true;
         }
         else
         {
            bsiProjectInfo.Caption = "<no project>";
         }
      }

      private void MainView_Shown(object sender, EventArgs e)
      {
         this.Show();
      }

      /// <summary>
      /// Select the appropriate ribbon tab page for the active module.
      /// </summary>
      private void docManager_DocumentActivate(object sender, DevExpress.XtraBars.Docking2010.Views.DocumentEventArgs e)
      {
         try
         {
            if (e.Document != null)
            {
               IPluginModule module = e.Document.Control as IPluginModule;
               if (module != null)
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

      private void cmdFileExit_ItemClick(object sender, ItemClickEventArgs e)
      {
         this.Controller.Exit();
      }

      private void cmdFileSettings_ItemClick(object sender, ItemClickEventArgs e)
      {
         this.Controller.Configure();
      }

      private void cmdFileAbout_ItemClick(object sender, ItemClickEventArgs e)
      {
         this.Controller.About();
      }

      private void cmdProjectsOpen_ItemClick(object sender, ItemClickEventArgs e)
      {
         if (this.Controller.OpenProject())
         {
            bsiProjectInfo.Caption = OTCContext.Project.Name;
            nbcPlugins.Enabled = true;
         }
      }

      private void cmdProjectsAdd_ItemClick(object sender, ItemClickEventArgs e)
      {
         if (this.Controller.CreateProject())
         {
            bsiProjectInfo.Caption = OTCContext.Project.Name;
            nbcPlugins.Enabled = true;
         }
      }

      private void dpToolbox_ClosedPanel(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
      {
         chkViewToolbox.Checked = false;
      }

      private void dockPanelConsole_ClosedPanel(object sender, DevExpress.XtraBars.Docking.DockPanelEventArgs e)
      {
         chkViewConsole.Checked = false;
      }

      private void chkViewToolbox_CheckedChanged(object sender, ItemClickEventArgs e)
      {
         if (((BarCheckItem)e.Item).Checked)
         {
            dpToolbox.Show();
         }
      }

      private void chkViewConsole_CheckedChanged(object sender, ItemClickEventArgs e)
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
         this.Controller = null;

         nbcPlugins.Enabled = false;
         chkViewToolbox.Checked = true;
      }

      #endregion

   }
}