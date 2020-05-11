using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Rwm.Otc.Trains;
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

      /// <summary>
      /// Save current model.
      /// </summary>
      public void Save()
      {
         if (!this.MapViewToModel()) 
            return;

         try
         {
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

      private void MapModelToView(Train train)
      {
         this.CurrentModel = train;
         if (this.CurrentModel == null) return;

         this.FillComboBox(cboDigitalPlug, typeof(Train.DigitalConnectorType), this.CurrentModel.DigitalConnector);
         this.FillComboBox(cboPropertiesLights, typeof(Train.LightFrontType), this.CurrentModel.LightFront);
         this.FillComboBox(cboPropertiesIntLights, typeof(Train.LightInteriorType), this.CurrentModel.LightInterior);
         this.FillComboBox(cboPropertiesCouplers, typeof(Train.CouplerTypes), this.CurrentModel.CouplersType);
         this.FillComboBox(cboPropertiesIntEq, typeof(Train.InteriorEquipmentType), this.CurrentModel.InteriorEquipment);

         this.Text = (!string.IsNullOrEmpty(this.CurrentModel.Name) ? this.CurrentModel.Name : "New model");

         txtName.Text = this.CurrentModel.Name;
         cboCategory.SetSelectedElement(this.CurrentModel.Category);
         cboCompany.SetSelectedElement(this.CurrentModel.Company);
         cboEra.SetSelectedElement(this.CurrentModel.Era);
         cboPaintScheme.Text = this.CurrentModel.PaintScheme;
         picImage.Image = this.CurrentModel.Picture;

         cboManufacturer.SetSelectedElement(this.CurrentModel.Manufacturer);
         txtItems.EditValue = this.CurrentModel.Units;
         txtReference.EditValue = this.CurrentModel.Reference;
         cboGauge.SetSelectedElement(this.CurrentModel.Gauge);

         cboStore.SetSelectedElement(this.CurrentModel.Store);
         if (this.CurrentModel.BuyDate > DateTime.MinValue) dtePurchaseDate.DateTime = this.CurrentModel.BuyDate; else dtePurchaseDate.EditValue = null;
         txtPurchasePrice.EditValue = this.CurrentModel.BuyPricePurchase;
         txtPriceCatalog.EditValue = this.CurrentModel.BuyPriceCatalogue;
         chkPurchasePending.Checked = this.CurrentModel.BuyIsPending;
         chkLimitedModel.Checked = this.CurrentModel.IsLimited;
         txtLimitedModel.Text = this.CurrentModel.LimitedYear;

         cboDigitalDecoder.SetSelectedElement(this.CurrentModel.DigitalDecoder);
         txtDigitalAddress.EditValue = this.CurrentModel.DigitalAddress;
         this.SetID(cboDigitalPlug, this.CurrentModel.DigitalConnector);

         this.SetID(cboPropertiesLights, this.CurrentModel.LightFront);
         this.SetID(cboPropertiesIntLights, this.CurrentModel.LightInterior);
         this.SetID(cboPropertiesCouplers, this.CurrentModel.CouplersType);
         this.SetID(cboPropertiesIntEq, this.CurrentModel.InteriorEquipment);

         rtfDescription.RtfText = this.CurrentModel.Description;

         this.UpdatePicture = false;
      }

      private bool MapViewToModel()
      {
         if (string.IsNullOrWhiteSpace(txtName.Text))
         {
            MessageBox.Show("You must specify the name of the model.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtName.Focus();
            return false;
         }
         else if (cboCategory.SelectedCategory == null)
         {
            MessageBox.Show("You must specify the category of the model.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cboCategory.Focus();
            return false;
         }

         try
         {
            this.CurrentModel.Name = txtName.Text.Trim();
            this.CurrentModel.Category = cboCategory.SelectedCategory;
            this.CurrentModel.Company = cboCompany.SelectedCompany;
            this.CurrentModel.Era = cboEra.SelectedEra;
            this.CurrentModel.PaintScheme = cboPaintScheme.Text.Trim();
            this.CurrentModel.Picture = picImage.Image;
            System.Drawing.Imaging.ImageFormat format = DevExpress.XtraEditors.Controls.ByteImageConverter.GetImageFormatByPixelFormat(this.CurrentModel.Picture);

            this.CurrentModel.Manufacturer = cboManufacturer.SelectedManufacturer;
            this.CurrentModel.Gauge = cboGauge.SelectedGauge;
            this.CurrentModel.Units = Decimal.ToInt32((Decimal)txtItems.EditValue);
            this.CurrentModel.Reference = txtReference.EditValue.ToString().Trim();

            this.CurrentModel.Store = cboStore.SelectedStore;
            this.CurrentModel.BuyDate = dtePurchaseDate.DateTime;
            this.CurrentModel.BuyPricePurchase = Decimal.Parse(txtPurchasePrice.EditValue.ToString());
            this.CurrentModel.BuyPriceCatalogue = Decimal.Parse(txtPriceCatalog.EditValue.ToString());
            this.CurrentModel.BuyIsPending = chkPurchasePending.Checked;
            this.CurrentModel.IsLimited = chkLimitedModel.Checked;
            this.CurrentModel.LimitedYear = txtLimitedModel.Text.Trim();

            this.CurrentModel.DigitalDecoder = cboDigitalDecoder.SelectedDecoder;
            this.CurrentModel.DigitalAddress = Int32.Parse(txtDigitalAddress.EditValue.ToString());
            this.CurrentModel.DigitalConnector = (Train.DigitalConnectorType)this.GetEnum(cboDigitalPlug);

            this.CurrentModel.LightFront = (Train.LightFrontType)this.GetEnum(cboPropertiesLights);
            this.CurrentModel.LightInterior = (Train.LightInteriorType)this.GetEnum(cboPropertiesIntLights);
            this.CurrentModel.CouplersType = (Train.CouplerTypes)this.GetEnum(cboPropertiesCouplers);
            this.CurrentModel.InteriorEquipment = (Train.InteriorEquipmentType)this.GetEnum(cboPropertiesIntEq);

            this.CurrentModel.Description = rtfDescription.RtfText;

            return true;
         }
         catch (Exception ex)
         {
            MessageBox.Show("ERROR collecting data: " + ex.Message,
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

            return false;
         }
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
