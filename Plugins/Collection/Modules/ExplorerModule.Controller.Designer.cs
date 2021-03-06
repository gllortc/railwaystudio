﻿using System;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using Rwm.Otc.Data;
using Rwm.Otc.Trains;
using Rwm.Studio.Plugins.Collection.Model;
using Rwm.Studio.Plugins.Collection.Reports;
using Rwm.Studio.Plugins.Collection.Views;
using Rwm.Studio.Plugins.Common;
using Rwm.Studio.Plugins.Common.Reports;
using static Rwm.Otc.Trains.Train;

namespace Rwm.Studio.Plugins.Collection.Modules
{
   public partial class ExplorerModule
   {

      #region Enumerations

      public enum FileType : int
      {
         Unknown = -1,
         Manufacturers = 0,
         Stores = 1,
         Gauges = 2,
         RailwayCompanies = 3,
         Decoders = 4,
         Categories = 5
      }

      #endregion

      #region Properties

      public FileType CurrentFileType { get; private set; }

      public Category CurrentCategory { get; private set; }

      #endregion

      #region Methods

      internal void AddItem()
      {
         if (this.CurrentFileType != FileType.Unknown)
         {
            switch (this.CurrentFileType)
            {
               case FileType.Categories:
                  CategoryEditorView formCategory = new CategoryEditorView();
                  formCategory.ShowDialog();
                  break;

               case FileType.Manufacturers:
                  ManufacturerEditorView formManufacturer = new ManufacturerEditorView();
                  formManufacturer.ShowDialog();
                  break;

               case FileType.Stores:
                  StoreEditorView formStore = new StoreEditorView();
                  formStore.ShowDialog();
                  break;

               case FileType.Gauges:
                  GaugeEditorView formScale = new GaugeEditorView();
                  formScale.ShowDialog();
                  break;

               case FileType.Decoders:
                  DecoderEditorView formDecoder = new DecoderEditorView();
                  formDecoder.ShowDialog();
                  break;

               case FileType.RailwayCompanies:
                  CompanyEditorView formAdmin = new CompanyEditorView();
                  formAdmin.ShowDialog();
                  break;

               default:
                  break;
            }
         }
         else if (this.CurrentCategory != null)
         {
            StudioContext.OpenPluginModule(ModelModuleDescriptor.MODULE_GUID, null);
         }

         this.Refresh();
      }

      internal void EditItem()
      {
         if (grdDataView.SelectedRowsCount <= 0)
         {
            MessageBox.Show("You must select the row you want to edit.",
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         // Get the current row
         int[] rows = grdDataView.GetSelectedRows();
         ORMIdentifiableEntity row = grdDataView.GetRow(rows[0]) as ORMIdentifiableEntity;
         if (row == null)
         {
            return;
         }

         if (this.CurrentFileType != FileType.Unknown)
         {
            switch (this.CurrentFileType)
            {
               case FileType.Categories:
                  Category category = Category.Get(row.ID);
                  if (category != null)
                  {
                     CategoryEditorView formCategoryEditor = new CategoryEditorView(category);
                     formCategoryEditor.ShowDialog();
                  }
                  break;

               case FileType.Manufacturers:
                  Manufacturer manufacturer = Manufacturer.Get(row.ID);
                  if (manufacturer != null)
                  {
                     ManufacturerEditorView formStore = new ManufacturerEditorView(manufacturer);
                     formStore.ShowDialog();
                  }
                  break;

               case FileType.Stores:
                  Store store = Store.Get(row.ID);
                  if (store != null)
                  {
                     StoreEditorView formStore = new StoreEditorView(store);
                     formStore.ShowDialog();
                  }
                  break;

               case FileType.Gauges:
                  Rwm.Otc.Trains.Gauge scale = Rwm.Otc.Trains.Gauge.Get(row.ID);
                  if (scale != null)
                  {
                     GaugeEditorView formScale = new GaugeEditorView(scale);
                     formScale.ShowDialog();
                  }
                  break;

               case FileType.Decoders:
                  TrainDecoder decoder = TrainDecoder.Get(row.ID);
                  if (decoder != null)
                  {
                     DecoderEditorView formDecoder = new DecoderEditorView(decoder);
                     formDecoder.ShowDialog();
                  }
                  break;

               case FileType.RailwayCompanies:
                  Company admin = Company.Get(row.ID);
                  if (admin != null)
                  {
                     CompanyEditorView formAdmin = new CompanyEditorView(admin);
                     formAdmin.ShowDialog();
                  }
                  break;

               default:
                  break;
            }
         }
         else if (this.CurrentCategory != null)
         {
            StudioContext.OpenPluginModule(ModelModuleDescriptor.MODULE_GUID, row.ID);
         }

         this.Refresh();
      }

      internal void DeleteItem()
      {
         if (grdDataView.SelectedRowsCount <= 0)
         {
            MessageBox.Show("You must select the row you want to delete.",
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         if (MessageBox.Show("Are you sure you want to delete the selected record?",
                             Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
         {
            return;
         }

         // Get the current row
         int[] rows = grdDataView.GetSelectedRows();
         ORMIdentifiableEntity row = grdDataView.GetRow(rows[0]) as ORMIdentifiableEntity;
         if (row == null)
         {
            return;
         }

         if (this.CurrentFileType != FileType.Unknown)
         {
            switch (this.CurrentFileType)
            {
               case FileType.Categories:
                  Category.Delete(row.ID);
                  break;

               case FileType.Manufacturers:
                  Manufacturer.Delete(row.ID);
                  break;

               case FileType.Stores:
                  Store.Delete(row.ID);
                  break;

               case FileType.Gauges:
                  Gauge.Delete(row.ID);
                  break;

               case FileType.Decoders:
                  TrainDecoder.Delete(row.ID);
                  break;

               case FileType.RailwayCompanies:
                  Company.Delete(row.ID);
                  break;

               default:
                  break;
            }
         }
         else if (this.CurrentCategory != null)
         {
            Train.Delete(row.ID);
         }

         this.Refresh();
      }

      internal void ReportsDigitalAddresses()
      {
         // Generate the report
         DigitalReport rpt = new DigitalReport();
         rpt.DisplayName = "Rolling Stock Addresses";
         rpt.CreateDocument();

         // Generate the cover
         CoverReport cover = new CoverReport(rpt.DisplayName);
         cover.CreateDocument();

         // Merge the documents
         rpt.Pages.Insert(0, cover.Pages[0]);

         // Open the document into the repport viewer plug-in
         StudioContext.MainView.OpenPluginModule(PluginManager.PLUGIN_REPORTVIEWER, rpt);
      }

      internal void Print()
      {
         StudioContext.MainView.OpenPluginModule(PluginManager.PLUGIN_REPORTVIEWER, 
                                                 grdData,
                                                 tlsFolders.Selection[0].GetDisplayText(tlsFolders.Columns[0]));
      }

      public override void Refresh()
      {
         try
         {
            Cursor.Current = Cursors.WaitCursor;

            // Clear list data
            grdData.BeginUpdate();
            grdData.DataSource = null;
            grdDataView.Columns.Clear();

            this.CurrentFileType = FileType.Unknown;
            this.CurrentCategory = null;

            if (tlsFolders.Selection.Count <= 0)
            {
               return;
            }
            else if (tlsFolders.Selection[0].ParentNode == null)
            {
               return;
            }
            else if (tlsFolders.Selection[0].Tag?.GetType() == typeof(FileType))
            {
               this.CurrentFileType = (FileType)tlsFolders.Selection[0].Tag;

               grdDataView.RowHeight = -1;

               switch (this.CurrentFileType)
               {
                  case FileType.Categories:
                     grdDataView.OptionsBehavior.AutoPopulateColumns = false;
                     grdDataView.Columns.Add(new GridColumn() { Caption = "ID", Visible = false, FieldName = "ID" });
                     grdDataView.Columns.Add(new GridColumn() { Caption = "Name", Visible = true, FieldName = "Name", Width = 250 });
                     grdDataView.Columns.Add(new GridColumn() { Caption = "Maintenance", Visible = true, FieldName = "HaveMaintenance", Width = 90 });
                     grdData.DataSource = Category.FindAll();
                     break;

                  case FileType.Manufacturers:
                     grdDataView.OptionsBehavior.AutoPopulateColumns = false;
                     grdDataView.Columns.Add(new GridColumn() { Caption = "ID", Visible = false, FieldName = "ID" });
                     grdDataView.Columns.Add(new GridColumn() { Caption = "Name", Visible = true, FieldName = "Name", Width = 250 });
                     grdDataView.Columns.Add(new GridColumn() { Caption = "URL", Visible = true, FieldName = "URL", Width = 350 });
                     grdData.DataSource = Manufacturer.FindAll();
                     break;

                  case FileType.Stores:
                     grdDataView.OptionsBehavior.AutoPopulateColumns = false;
                     grdDataView.Columns.Add(new GridColumn() { Caption = "ID", Visible = false, FieldName = "ID" });
                     grdDataView.Columns.Add(new GridColumn() { Caption = "Name", Visible = true, FieldName = "Name", Width = 250 });
                     grdDataView.Columns.Add(new GridColumn() { Caption = "Adress", Visible = true, FieldName = "Adress", Width = 250 });
                     grdDataView.Columns.Add(new GridColumn() { Caption = "URL", Visible = true, FieldName = "URL", Width = 350 });
                     grdData.DataSource = Store.FindAll();
                     break;

                  case FileType.Gauges:
                     grdDataView.OptionsBehavior.AutoPopulateColumns = false;
                     grdDataView.Columns.Add(new GridColumn() { Caption = "ID", Visible = false, FieldName = "ID" });
                     grdDataView.Columns.Add(new GridColumn() { Caption = "Name", Visible = true, FieldName = "Name", Width = 100 });
                     grdDataView.Columns.Add(new GridColumn() { Caption = "Notation", Visible = true, FieldName = "ScaleNotation", Width = 100 });
                     grdData.DataSource = Rwm.Otc.Trains.Gauge.FindAll();
                     break;

                  case FileType.RailwayCompanies:
                     grdDataView.RowHeight = 35;
                     grdDataView.OptionsBehavior.AutoPopulateColumns = false;
                     grdDataView.Columns.Add(new GridColumn() { Caption = "ID", Visible = false, FieldName = "ID" });
                     grdDataView.Columns.Add(new GridColumn() { Caption = "Logo", Visible = true, FieldName = "LogoImage", Width = 100 });
                     grdDataView.Columns.Add(new GridColumn() { Caption = "Name", Visible = true, FieldName = "Name", Width = 300 });
                     grdDataView.Columns.Add(new GridColumn() { Caption = "Acronym", Visible = true, FieldName = "Acronym", Width = 100 });
                     grdDataView.Columns.Add(new GridColumn() { Caption = "URL", Visible = true, FieldName = "URL", Width = 350 });
                     grdData.DataSource = Company.FindAll();
                     break;

                  case FileType.Decoders:
                     grdDataView.OptionsBehavior.AutoPopulateColumns = false;
                     grdDataView.Columns.Add(new GridColumn() { Caption = "ID", Visible = false, FieldName = "ID" });
                     grdDataView.Columns.Add(new GridColumn() { Caption = "Name", Visible = true, FieldName = "Name", Width = 250 });
                     grdDataView.Columns.Add(new GridColumn() { Caption = "URL", Visible = true, FieldName = "URL", Width = 350 });
                     grdData.DataSource = TrainDecoder.FindAll();
                     break;
               }
            }
            else if (tlsFolders.Selection[0].Tag?.GetType() == typeof(Category))
            {
               this.CurrentCategory = (Category)tlsFolders.Selection[0].Tag;

               grdDataView.RowHeight = 35;
               grdDataView.OptionsBehavior.AutoPopulateColumns = false;
               grdDataView.Columns.Add(new GridColumn() { Caption = "ID", Visible = false, FieldName = "ID" });
               grdDataView.Columns.Add(new GridColumn() { Caption = "Image", Visible = true, FieldName = "Picture", Width = 130 });
               grdDataView.Columns.Add(new GridColumn() { Caption = "Name", Visible = true, FieldName = "Name", Width = 150 });
               grdDataView.Columns.Add(new GridColumn() { Caption = "Company", Visible = true, FieldName = "Company.Name", Width = 220 });
               grdDataView.Columns.Add(new GridColumn() { Caption = "Manufacturer", Visible = true, FieldName = "Manufacturer.Name", Width = 120 });
               grdDataView.Columns.Add(new GridColumn() { Caption = "Art.No.", Visible = true, FieldName = "Reference", Width = 100 });
               grdDataView.Columns.Add(new GridColumn() { Caption = "Units", Visible = true, FieldName = "Units", Width = 50 });
               grdDataView.Columns.Add(new GridColumn() { Caption = "Properties", Visible = true, FieldName = "Pictograms", Width = 200 });

               grdDataView.Columns[6].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
               grdDataView.Columns[6].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
               grdDataView.Columns[7].AppearanceCell.Font = new System.Drawing.Font("Maerklin Piktos", 20);

               if (this.CurrentCategory.ID > 0)
                  grdData.DataSource = Train.FindBy("Category", this.CurrentCategory);
               else
                  grdData.DataSource = Train.FindAll();
            }
         }
         catch (Exception ex)
         {
            Cursor.Current = Cursors.Default;

            MessageBox.Show("ERROR retrieving data: " + Environment.NewLine + Environment.NewLine + ex.Message,
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
         finally
         {
            grdData.EndUpdate();
         }

         base.Refresh();

         Cursor.Current = Cursors.Default;
      }

      #endregion

      #region Private Members

      private Folder CreateFolders()
      {
         Folder root = new Folder("Collection");
         Folder collection = root.AddFolder("Models", true);

         foreach (Category cat in Category.FindAll())
            collection.AddFolder(cat.Name, false, true, cat);
         collection.AddFolder("All");

         Folder data = root.AddFolder("Data", false, true, new Category());
         data.AddFolder("Categories", false, true, FileType.Categories);
         data.AddFolder("Manufacturers", false, true, FileType.Manufacturers);
         data.AddFolder("Stores", false, true, FileType.Stores);
         data.AddFolder("Railway companies", false, true, FileType.RailwayCompanies);
         data.AddFolder("Decoders", false, true, FileType.Decoders);
         data.AddFolder("Scales / Gauges", false, true, FileType.Gauges);

         return root;
      }

      private void FillTreeList(Folder folder, Folder root)
      {
         // Configure the list columns
         if (root == null)
         {
            tlsFolders.BeginUpdate();
            TreeListColumn col = tlsFolders.Columns.Add();
            col.Caption = "Folder";
            col.VisibleIndex = 0;
            tlsFolders.EndUpdate();
         }

         tlsFolders.BeginUnboundLoad();



         tlsFolders.EndUnboundLoad();
      }

      private void CreateTreeList()
      {
         TreeListColumn col = null;
         TreeListNode rootNode = null;
         TreeListNode parentNode = null;
         TreeListNode node = null;

         tlsFolders.BeginUpdate();

         // Configure the columns
         col = tlsFolders.Columns.Add();
         col.Caption = "Folder";
         col.VisibleIndex = 0;

         tlsFolders.EndUpdate();
         tlsFolders.BeginUnboundLoad();

         // Create a root node .
         rootNode = tlsFolders.AppendNode(new object[] { "My Collection" }, null);
         rootNode.StateImageIndex = 0;
         rootNode.Expanded = true;

         // Create models nodes
         parentNode = tlsFolders.AppendNode(new object[] { "Models" }, rootNode);
         //parentNode.Tag = "col";
         parentNode.StateImageIndex = 0;
         parentNode.Expanded = true;

         node = tlsFolders.AppendNode(new object[] { "All" }, parentNode);
         node.Tag = new Category();
         node.StateImageIndex = 0;

         foreach (Category cat in Category.FindAll())
         {
            node = tlsFolders.AppendNode(new object[] { cat.Name }, parentNode);
            node.Tag = cat;
            node.StateImageIndex = 0;
         }

         // Create categories nodes
         parentNode = tlsFolders.AppendNode(new object[] { "Data" }, rootNode);
         parentNode.Tag = "dat";
         parentNode.StateImageIndex = 1;

         node = tlsFolders.AppendNode(new object[] { "Categories" }, parentNode);
         node.Tag = FileType.Categories;
         node.StateImageIndex = 2;
         node = tlsFolders.AppendNode(new object[] { "Scales" }, parentNode);
         node.Tag = FileType.Gauges;
         node.StateImageIndex = 6;
         node = tlsFolders.AppendNode(new object[] { "Railway companies" }, parentNode);
         node.Tag = FileType.RailwayCompanies;
         node.StateImageIndex = 7;
         node = tlsFolders.AppendNode(new object[] { "Manufacturers" }, parentNode);
         node.Tag = FileType.Manufacturers;
         node.StateImageIndex = 4;
         node = tlsFolders.AppendNode(new object[] { "Stores" }, parentNode);
         node.Tag = FileType.Stores;
         node.StateImageIndex = 3;
         node = tlsFolders.AppendNode(new object[] { "Decoders" }, parentNode);
         node.Tag = FileType.Decoders;
         node.StateImageIndex = 5;

         tlsFolders.Nodes[0].Expanded = true;
         tlsFolders.Nodes[0].Nodes[0].Expanded = true;

         tlsFolders.EndUnboundLoad();
      }

      #endregion

   }
}
