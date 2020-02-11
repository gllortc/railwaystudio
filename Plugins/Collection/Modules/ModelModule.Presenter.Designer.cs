using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Rwm.Otc.Data.ORM;
using Rwm.Otc.TrainControl;
using Rwm.Studio.Plugins.Collection.Controls;

namespace Rwm.Studio.Plugins.Collection.Modules
{
   public partial class ModelModule
   {

      #region Properties

      public bool UpdatePicture { get; set; }

      public Train CurrentModel { get; private set; }

      #endregion

      #region Methods

      internal void SetData()
      {
         if (this.CurrentModel == null)
         {
            return;
         }

         this.Text = (!string.IsNullOrEmpty(this.CurrentModel.Name) ? this.CurrentModel.Name : "New model");

         txtName.Text = this.CurrentModel.Name;
         this.SetID(cboCategory, (this.CurrentModel.Category != null ? this.CurrentModel.Category.ID : 0));
         this.SetID(cboAdministration, (this.CurrentModel.Company != null ? this.CurrentModel.Company.ID : 0));
         cboEra.EditValue = this.CurrentModel.Era;
         cboPaintScheme.Text = this.CurrentModel.PaintScheme;
         picImage.Image = this.CurrentModel.Picture;

         this.SetID(cboManufacturer, (this.CurrentModel.Manufacturer != null ? this.CurrentModel.Manufacturer.ID : 0));
         txtItems.EditValue = this.CurrentModel.Units;
         txtReference.EditValue = this.CurrentModel.Reference;
         this.SetID(cboScale, (this.CurrentModel.Gauge != null ? this.CurrentModel.Gauge.ID : 0));

         this.SetID(cboStore, (this.CurrentModel.Store != null ? this.CurrentModel.Store.ID : 0));
         if (this.CurrentModel.BuyDate > DateTime.MinValue) dtePurchaseDate.DateTime = this.CurrentModel.BuyDate; else dtePurchaseDate.EditValue = null;
         txtPurchasePrice.EditValue = this.CurrentModel.BuyPricePurchase;
         txtPriceCatalog.EditValue = this.CurrentModel.BuyPriceCatalogue;
         chkPurchasePending.Checked = this.CurrentModel.BuyIsPending;
         chkLimitedModel.Checked = this.CurrentModel.IsLimited;
         txtLimitedModel.Text = this.CurrentModel.LimitedYear;

         this.SetID(cboDigitalDecoder, (this.CurrentModel.DigitalDecoder != null ? this.CurrentModel.DigitalDecoder.ID : 0));
         txtDigitalAddress.EditValue = this.CurrentModel.DigitalAddress;
         this.SetID(cboDigitalPlug, this.CurrentModel.DigitalConnector);

         this.SetID(cboPropertiesLights, this.CurrentModel.LightFront);
         this.SetID(cboPropertiesIntLights, this.CurrentModel.LightInterior);
         this.SetID(cboPropertiesCouplers, this.CurrentModel.CouplersType);
         this.SetID(cboPropertiesIntEq, this.CurrentModel.InteriorEquipment);

         rtfDescription.RtfText = this.CurrentModel.Description;

         this.UpdatePicture = false;
      }

      internal void Save()
      {
         if (string.IsNullOrWhiteSpace(txtName.Text))
         {
            MessageBox.Show("You must specify the name of the model.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtName.Focus();
            return;
         }
         else if (cboCategory.SelectedItem == null)
         {
            MessageBox.Show("You must specify the category of the model.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cboCategory.Focus();
            return;
         }

         try
         {
            this.CurrentModel.Name = txtName.Text.Trim();
            this.CurrentModel.Category = (cboCategory.SelectedItem as ImageComboBoxItem).Value as Category; // this.GetID(cboCategory.SelectedItem as ImageComboBoxItem);
            this.CurrentModel.Company = (cboAdministration.SelectedItem as ImageComboBoxItem).Value as Company; // this.GetID(cboAdministration.SelectedItem as ImageComboBoxItem);
            this.CurrentModel.Era = (cboEra.SelectedItem != null ? (Train.Epoche)((ImageComboBoxItem)cboEra.SelectedItem).Value : Train.Epoche.NotDefined);
            this.CurrentModel.PaintScheme = cboPaintScheme.Text.Trim();
            this.CurrentModel.Picture = picImage.Image;
            System.Drawing.Imaging.ImageFormat format = DevExpress.XtraEditors.Controls.ByteImageConverter.GetImageFormatByPixelFormat(this.CurrentModel.Picture);

            this.CurrentModel.Manufacturer = (cboManufacturer.SelectedItem as ImageComboBoxItem).Value as Manufacturer; // this.GetID(cboManufacturer.SelectedItem as ImageComboBoxItem);
            this.CurrentModel.Gauge = (cboScale.SelectedItem as ImageComboBoxItem).Value as Gauge; // this.GetID(cboScale.SelectedItem as ImageComboBoxItem);
            this.CurrentModel.Units = Decimal.ToInt32((Decimal)txtItems.EditValue);
            this.CurrentModel.Reference = txtReference.EditValue.ToString().Trim();

            this.CurrentModel.Store = (cboStore.SelectedItem != null ? (cboStore.SelectedItem as ImageComboBoxItem).Value as Store : null); // this.GetID(cboStore.SelectedItem as ImageComboBoxItem);
            this.CurrentModel.BuyDate = dtePurchaseDate.DateTime;
            this.CurrentModel.BuyPricePurchase = Decimal.Parse(txtPurchasePrice.EditValue.ToString());
            this.CurrentModel.BuyPriceCatalogue = Decimal.Parse(txtPriceCatalog.EditValue.ToString());
            this.CurrentModel.BuyIsPending = chkPurchasePending.Checked;
            this.CurrentModel.IsLimited = chkLimitedModel.Checked;
            this.CurrentModel.LimitedYear = txtLimitedModel.Text.Trim();

            this.CurrentModel.DigitalDecoder = (cboDigitalDecoder.SelectedItem != null ? (cboDigitalDecoder.SelectedItem as ImageComboBoxItem).Value as TrainDecoder : null); // this.GetID(cboDigitalDecoder.SelectedItem as ImageComboBoxItem);
            this.CurrentModel.DigitalAddress = Int32.Parse(txtDigitalAddress.EditValue.ToString());
            this.CurrentModel.DigitalConnector = (Train.DigitalConnectorType)this.GetEnum(cboDigitalPlug);

            this.CurrentModel.LightFront = (Train.LightFrontType)this.GetEnum(cboPropertiesLights);
            this.CurrentModel.LightInterior = (Train.LightInteriorType)this.GetEnum(cboPropertiesIntLights);
            this.CurrentModel.CouplersType = (Train.CouplerTypes)this.GetEnum(cboPropertiesCouplers);
            this.CurrentModel.InteriorEquipment = (Train.InteriorEquipmentType)this.GetEnum(cboPropertiesIntEq);

            this.CurrentModel.Description = rtfDescription.RtfText;

            Train.Save(this.CurrentModel);

            // Update document title
            this.Text = this.CurrentModel.Name;
         }
         catch (Exception ex)
         {
            MessageBox.Show("ERROR storing data: " + ex.Message, 
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      #endregion

      #region Private Members

      private long GetID(ImageComboBoxItem item)
      {
         if (item == null)
         {
            return 0;
         }

         ORMIdentifiableEntity obj = item.Value as ORMIdentifiableEntity;
         if (obj != null)
         {
            return obj.ID;
         }

         return 0;
      }

      private object GetEnum(ImageComboBoxEdit ctrl)
      {
         ImageComboBoxItem item = ctrl.SelectedItem as ImageComboBoxItem;

         if (item == null)
         {
            return 0;
         }

         return item.Value;
      }

      private void SetID(ImageComboBoxEdit ctrl, long value)
      {
         ORMIdentifiableEntity obj = null;

         if (value <= 0)
         {
            ctrl.SelectedItem = null;
            return;
         }

         foreach (ImageComboBoxItem item in ctrl.Properties.Items)
         {
            obj = item.Value as ORMIdentifiableEntity;
            if (obj != null && obj.ID == value)
            {
               ctrl.SelectedItem = item;
               return;
            }
         }

         ctrl.SelectedItem = null;
      }

      private void SetID(ImageComboBoxEdit ctrl, object value)
      {
         if (value == null)
         {
            ctrl.SelectedItem = null;
            return;
         }

         foreach (ImageComboBoxItem item in ctrl.Properties.Items)
         {
            if ((int)item.Value == (int)value)
            {
               ctrl.SelectedItem = item;
               return;
            }
         }

         ctrl.SelectedItem = null;
      }

      private void FillLists()
      {
         ImageComboBoxItem item;

         // Clear all lists
         cboCategory.Properties.Items.Clear();

         // Fill categories list
         cboCategory.Properties.Items.BeginUpdate();
         foreach (Category category in Category.FindAll()) // OTCContext.Project.TrainManager.CategoryDAO.GetAll())
         {
            item = new ImageComboBoxItem();
            item.Value = category;
            item.Description = category.Name;
            item.ImageIndex = 0;

            cboCategory.Properties.Items.Add(item);
         }
         cboCategory.Properties.Items.EndUpdate();

         // Fill administrations list
         cboAdministration.Properties.Items.BeginUpdate();
         foreach (Company administration in Company.FindAll()) // OTCContext.Project.TrainManager.AdministrationDAO.GetAll())
         {
            item = new ImageComboBoxItem();
            item.Value = administration;
            item.Description = administration.Name;
            item.ImageIndex = 1;

            cboAdministration.Properties.Items.Add(item);
         }
         cboAdministration.Properties.Items.EndUpdate();

         // Fill epoques list
         cboEra.Properties.Items.BeginUpdate();
         for (int era = 0; era < 6; era++)
         {
            item = new ImageComboBoxItem();
            item.Value = ((Train.Epoche)era + 1);
            item.Description = "Epoche " + (era + 1);
            item.ImageIndex = era;

            cboEra.Properties.Items.Add(item);
         }
         cboEra.Properties.Items.EndUpdate();

         // Fill paint schemes list
         //cboPaintScheme.Properties.Items.BeginUpdate();
         //foreach (string scheme in CollectionModel.GetPaintSchemes())
         //{
         //   cboPaintScheme.Properties.Items.Add(new ComboBoxItem(scheme));
         //}
         //cboPaintScheme.Properties.Items.EndUpdate();

         // Fill manufacturers list
         cboManufacturer.Properties.Items.BeginUpdate();
         foreach (Manufacturer manufacturer in Manufacturer.FindAll()) //  OTCContext.Project.TrainManager.ManufacturerDAO.GetAll())
         {
            item = new ImageComboBoxItem();
            item.Value = manufacturer;
            item.Description = manufacturer.Name;
            item.ImageIndex = 2;

            cboManufacturer.Properties.Items.Add(item);
         }
         cboManufacturer.Properties.Items.EndUpdate();

         // Fill scales list
         cboScale.Properties.Items.BeginUpdate();
         foreach (Gauge scale in Rwm.Otc.TrainControl.Gauge.FindAll()) // OTCContext.Project.TrainManager.ScaleDAO.GetAll())
         {
            item = new ImageComboBoxItem();
            item.Value = scale;
            item.Description = scale.Name + " (" + scale.Notation + ")";
            item.ImageIndex = 3;

            cboScale.Properties.Items.Add(item);
         }
         cboScale.Properties.Items.EndUpdate();

         // Fill stores list
         cboStore.Properties.Items.BeginUpdate();
         foreach (Store store in Store.FindAll()) // OTCContext.Project.TrainManager.StoreDAO.GetAll())
         {
            item = new ImageComboBoxItem();
            item.Value = store;
            item.Description = store.Name;
            item.ImageIndex = 4;

            cboStore.Properties.Items.Add(item);
         }
         cboStore.Properties.Items.EndUpdate();

         // Fill decoders list
         cboDigitalDecoder.Properties.Items.BeginUpdate();
         foreach (TrainDecoder decoder in TrainDecoder.FindAll()) //  OTCContext.Project.TrainManager.DecoderDAO.GetAll())
         {
            item = new ImageComboBoxItem();
            item.Value = decoder;
            item.Description = decoder.Name;
            item.ImageIndex = 5;

            cboDigitalDecoder.Properties.Items.Add(item);
         }
         cboDigitalDecoder.Properties.Items.EndUpdate();

         // Fill decoder connectors list
         this.FillComboBox(cboDigitalPlug, typeof(Train.DigitalConnectorType), this.CurrentModel.DigitalConnector);

         // Fill lights list
         this.FillComboBox(cboPropertiesLights, typeof(Train.LightFrontType), this.CurrentModel.LightFront);

         // Fill interior lights list
         this.FillComboBox(cboPropertiesIntLights, typeof(Train.LightInteriorType), this.CurrentModel.LightInterior);

         // Fill couplers list
         this.FillComboBox(cboPropertiesCouplers, typeof(Train.CouplerTypes), this.CurrentModel.CouplersType);

         // Fill interior equipment type
         this.FillComboBox(cboPropertiesIntEq, typeof(Train.InteriorEquipmentType), this.CurrentModel.InteriorEquipment);
      }

      private void FillComboBox(ImageComboBoxEdit ctrl, Type enumeration, object selectedValue)
      {
         string description;
         string resx;
         object[] attributes = null;
         MemberInfo[] memInfo = null;
         ImageComboBoxItem item = null;

         ctrl.Properties.Items.Clear();
         foreach (var value in Enum.GetValues(enumeration))
         {
            memInfo = enumeration.GetMember(value.ToString());
            attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            description = ((DescriptionAttribute)attributes[0]).Description;
            attributes = memInfo[0].GetCustomAttributes(typeof(EnumItemImage), false);
            resx = (attributes.Length > 0 ? ((EnumItemImage)attributes[0]).Image : null);

            item = new ImageComboBoxItem();
            item.Value = value;
            item.Description = description;
            item.ImageIndex = this.GetItemImage(ctrl, resx);

            ctrl.Properties.Items.Add(item);

            if (value == selectedValue)
            {
               ctrl.SelectedItem = item;
            }
         }
      }

      private int GetItemImage(ImageComboBoxEdit ctrl, string resx)
      {
         int idx = -1;
         Image image = null;

         if (ctrl.Properties.SmallImages == null || string.IsNullOrEmpty(resx))
         {
            return -1;
         }

         idx = ((ImageList)ctrl.Properties.SmallImages).Images.IndexOfKey(resx);
         if (idx >= 0)
         {
            return idx;
         }
         else
         {
            image = Properties.Resources.ResourceManager.GetObject(resx) as Image;
            if (image != null)
            {
               ((ImageList)ctrl.Properties.SmallImages).Images.Add(resx, image);
               return ((ImageList)ctrl.Properties.SmallImages).Images.IndexOfKey(resx); 
            }
         }

         return -1;
      }

      #endregion

   }
}
