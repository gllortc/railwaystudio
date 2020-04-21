using DevExpress.XtraBars;
using RailwayStudio.Common;
using Rwm.Otc;
using Rwm.Studio.Plugins.Collection.Data;
using Rwm.Studio.Plugins.Collection.Views;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Rwm.Studio.Plugins.Collection.Modules
{
   public partial class DataModule : DevExpress.XtraBars.Ribbon.RibbonForm, IPluginModule
   {
      private const string MODULE_GUID = "C400486F-0F20-441B-939A-E9C07470C730";

      #region Enumerations

      public enum FileType : int
      {
         Manufacturers = 0,
         Stores = 1,
         Scales = 2,
         Administrations = 3,
         Decoders = 4,
         Categories = 5
      }

      #endregion

      #region Constructors

      public DataModule()
      {
         InitializeComponent();
      }

      #endregion

      #region IPluginModule Implementation

      public string ModuleID
      {
         get { return MODULE_GUID; }
      }

      public object StartupRibbonPage
      {
         get { return ribbon.Pages[0]; }
      }

      public object RibbonStatusBar
      {
         get { return ribbonStatusBar; }
      }

      public Image LargeIcon
      {
         get { return global::Rwm.Studio.Plugins.Collection.Properties.Resources.ICO_DATAMANAGER_32; }
      }

      public Image SmallIcon
      {
         get { return global::Rwm.Studio.Plugins.Collection.Properties.Resources.ICO_DATAMANAGER_16; }
      }

      public string ModuleName
      {
         get { return "Collection Data Management"; }
      }

      public string DocumentName
      {
         get { return string.Empty; }
      }

      public bool IsMultiInstance
      {
         get { return false; }
      }

      public bool UseProject
      {
         get { return true; }
      }

      public void Initialize(params object[] args)
      {
         // Check the database version
         //CollectionDataEntity cde = new CollectionDataEntity(OTCContext.Settings);
         //cde.CheckDatabase();
      }

      /// <summary>
      /// Add docable panels to environment.
      /// </summary>
      public void CreatePanels()
      {
         // Nothing to do
      }

      /// <summary>
      /// Remove all dockable panels created when the module was loaded.
      /// </summary>
      public void DestoryPanels()
      {
         // Nothing to do
      }

      #endregion

      #region Event Handlers

      private void FileCheck_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         UncheckFiles(e.Item as BarCheckItem);

         switch (e.Item.Name)
         {
            case "cmdDataCategories":
               this.CurrentFileType = FileType.Categories;
               break;

            case "cmdDataManufacturers":
               this.CurrentFileType = FileType.Manufacturers;
               break;

            case "cmdDataStores":
               this.CurrentFileType = FileType.Stores;
               break;

            case "cmdDataScales":
               this.CurrentFileType = FileType.Scales;
               break;

            case "cmdDataDecoders":
               this.CurrentFileType = FileType.Decoders;
               break;

            case "cmdDataAdmins":
               this.CurrentFileType = FileType.Administrations;
               break;

            default:
               break;
         }

         ShowData(this.CurrentFileType);
      }

      private void cmdDataAdd_ItemClick(object sender, ItemClickEventArgs e)
      {
         switch (this.CurrentFileType)
         {
            case FileType.Categories:
               FrmCategoryEditor formCategory = new FrmCategoryEditor();
               formCategory.ShowDialog();
               break;

            case FileType.Manufacturers:
               FrmManufacturerEditor formManufacturer = new FrmManufacturerEditor();
               formManufacturer.ShowDialog();
               break;

            case FileType.Stores:
               FrmStoreEditor formStore = new FrmStoreEditor();
               formStore.ShowDialog();
               break;

            case FileType.Scales:
               FrmScaleEditor formScale = new FrmScaleEditor();
               formScale.ShowDialog();
               break;

            case FileType.Decoders:
               FrmDecoderEditor formDecoder = new FrmDecoderEditor();
               formDecoder.ShowDialog();
               break;

            case FileType.Administrations:
               FrmAdministrationEditor formAdmin = new FrmAdministrationEditor();
               formAdmin.ShowDialog();
               break;

            default:
               break;
         }
      }

      private void cmdDataEdit_ItemClick(object sender, ItemClickEventArgs e)
      {
         if (grdDataView.SelectedRowsCount <= 0)
         {
            MessageBox.Show("You must select the row you want to edit.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         // Get the current row
         int[] rows = grdDataView.GetSelectedRows();
         DataRowView row = grdDataView.GetRow(rows[0]) as DataRowView;
         if (row == null)
         {
            return;
         }

         switch (this.CurrentFileType)
         {
            case FileType.Categories:
               Category category = CollectionContext.CategoryDAO.GetByID((Int64)row.Row[0]);
               if (category != null)
               {
                  FrmCategoryEditor formCategoryEditor = new FrmCategoryEditor(category);
                  formCategoryEditor.ShowDialog();
               }
               break;

            case FileType.Manufacturers:
               Manufacturer manufacturer = CollectionContext.ManufacturerDAO.GetByID((Int64)row.Row[0]);
               if (manufacturer != null)
               {
                  FrmManufacturerEditor formStore = new FrmManufacturerEditor(manufacturer);
                  formStore.ShowDialog();
               }
               break;

            case FileType.Stores:
               Store store = CollectionContext.StoreDAO.GetByID((Int64)row.Row[0]);
               if (store != null)
               {
                  FrmStoreEditor formStore = new FrmStoreEditor(store);
                  formStore.ShowDialog();
               }
               break;

            case FileType.Scales:
               Scale scale = CollectionContext.ScaleDAO.GetByID((Int64)row.Row[0]);
               if (scale != null)
               {
                  FrmScaleEditor formScale = new FrmScaleEditor(scale);
                  formScale.ShowDialog();
               }
               break;

            case FileType.Decoders:
               Decoder decoder = CollectionContext.DecoderDAO.GetByID((Int64)row.Row[0]);
               if (decoder != null)
               {
                  FrmDecoderEditor formDecoder = new FrmDecoderEditor(decoder);
                  formDecoder.ShowDialog();
               }
               break;

            case FileType.Administrations:
               Administration admin = CollectionContext.AdministrationDAO.GetByID((Int64)row.Row[0]);
               if (admin != null)
               {
                  FrmAdministrationEditor formAdmin = new FrmAdministrationEditor(admin);
                  formAdmin.ShowDialog();
               }
               break;

            default:
               break;
         }
      }

      #endregion

      #region Properties

      public FileType CurrentFileType { get; private set; }

      #endregion

      #region Private Members

      private void ShowData(FileType fileType)
      {
         try
         {
            grdData.BeginUpdate();
            grdData.DataSource = null;
            grdDataView.Columns.Clear();

            switch (fileType)
            {
               case FileType.Categories:
                  grdData.DataSource = CollectionContext.CategoryDAO.GetAllAsDataSource();
                  break;

               case FileType.Manufacturers:
                  grdData.DataSource = CollectionContext.ManufacturerDAO.GetAllAsDataSource();
                  break;

               case FileType.Stores:
                  grdData.DataSource = CollectionContext.StoreDAO.GetAllAsDataTable();
                  break;

               case FileType.Scales:
                  grdData.DataSource = CollectionContext.ScaleDAO.GetAllAsDataTable();
                  break;

               case FileType.Administrations:
                  grdData.DataSource = CollectionContext.AdministrationDAO.GetAllAsDataTable();
                  break;

               case FileType.Decoders:
                  grdData.DataSource = CollectionContext.DecoderDAO.GetAllAsDataTable();
                  break;
            }

            grdDataView.Columns[0].Visible = false;
         }
         catch (Exception ex)
         {
            MessageBox.Show("ERROR retrieving data: " + Environment.NewLine + Environment.NewLine + ex.Message,
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
         finally
         {
            grdData.EndUpdate();
         }
      }

      private void UncheckFiles(BarCheckItem checkedItem)
      {
         BarCheckItem item;

         foreach (BarCheckItemLink link in rpgFiles.ItemLinks)
         {
            item = link.Item as BarCheckItem;
            item.Checked = (checkedItem == link.Item);
         }
      }

      #endregion

   }
}