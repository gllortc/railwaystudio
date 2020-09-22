using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using Rwm.Otc;
using Rwm.Otc.Trains;

namespace Rwm.Studio.Plugins.Common.Controls
{
   [UserRepositoryItem("RegisterManufacturerImageComboBoxEdit")]
   public class RepositoryItemManufacturerImageComboBoxEdit : RepositoryItemImageComboBox
   {

      #region Constants

      public const string CustomEditName = "ManufacturerImageComboBoxEdit";

      #endregion

      #region Constructors

      static RepositoryItemManufacturerImageComboBoxEdit()
      {
         RepositoryItemManufacturerImageComboBoxEdit.RegisterManufacturerImageComboBoxEdit();
      }

      public RepositoryItemManufacturerImageComboBoxEdit() { }

      #endregion

      #region Properties

      public override string EditorTypeName
      {
         get { return CustomEditName; }
      }

      #endregion

      #region Methods

      public static void RegisterManufacturerImageComboBoxEdit()
      {
         Image img = null;
         EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(CustomEditName, typeof(ManufacturerImageComboBoxEdit), typeof(RepositoryItemManufacturerImageComboBoxEdit), typeof(ManufacturerImageComboBoxEditViewInfo), new ManufacturerImageComboBoxEditPainter(), true, img));
      }

      public override void Assign(RepositoryItem item)
      {
         BeginUpdate();

         try
         {
            base.Assign(item);
            if (!(item is RepositoryItemManufacturerImageComboBoxEdit source)) return;
         }
         finally
         {
            EndUpdate();
         }
      }

      #endregion

   }

   [ToolboxItem(true)]
   public class ManufacturerImageComboBoxEdit : ImageComboBoxEdit
   {

      #region Constructors

      static ManufacturerImageComboBoxEdit()
      {
         RepositoryItemManufacturerImageComboBoxEdit.RegisterManufacturerImageComboBoxEdit();
      }

      /// <summary>
      /// Return a new instance of <see cref="ManufacturerImageComboBoxEdit"/>.
      /// </summary>
      public ManufacturerImageComboBoxEdit() { }

      #endregion

      #region Properties

      /// <summary>
      /// Gets the selected item in the list.
      /// </summary>
      public Manufacturer SelectedManufacturer
      {
         get
         {
            if (this.EditValue == null) return null;
            return this.EditValue as Manufacturer;
         }
      }

      private ImageList ImageList { get; set; }

      [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
      public new RepositoryItemManufacturerImageComboBoxEdit Properties
      {
         get { return base.Properties as RepositoryItemManufacturerImageComboBoxEdit; }
      }

      public override string EditorTypeName
      {
         get { return RepositoryItemManufacturerImageComboBoxEdit.CustomEditName; }
      }

      #endregion

      #region Methods

      /// <summary>
      /// Refresh/Fill the editor list of the selected type of elements.
      /// </summary>
      public void RefreshElementsList()
      {
         this.FillItems(null);
      }

      /// <summary>
      /// Sets the selected element in the editor.
      /// </summary>
      /// <param name="selected">Selected item.</param>
      public void SetSelectedElement(Manufacturer selected)
      {
         this.FillItems(selected);
      }

      protected override PopupBaseForm CreatePopupForm()
      {
         return new ManufacturerImageComboBoxEditPopupForm(this);
      }

      #endregion

      #region Private Members

      private void FillItems(Manufacturer selected)
      {
         ImageComboBoxItem item;

         // Create an image collection
         if (this.Properties.SmallImages == null)
         {
            this.ImageList = new ImageList();
            this.ImageList.Images.Add(Common.Properties.Resources.ICO_MANUFACTURER_OFF_16);
            this.ImageList.Images.Add(Manufacturer.SmallIcon);
            this.Properties.SmallImages = this.ImageList;
         }

         this.Properties.Items.Clear();

         if (OTCContext.Project != null)
         {
            item = new ImageComboBoxItem("Not specified", null, 0);
            this.Properties.Items.Add(item);

            foreach (Manufacturer manufacturer in Manufacturer.FindAll())
            {
               item = new ImageComboBoxItem(manufacturer.Name, manufacturer, 1);
               this.Properties.Items.Add(item);

               if (selected != null && manufacturer == selected) 
                  this.EditValue = item;
            }

            if (selected == null || this.EditValue == null) 
               this.EditValue = this.Properties.Items[0];
         }
      }

      #endregion

   }

   #region Nested Classes

   public class ManufacturerImageComboBoxEditViewInfo : ImageComboBoxEditViewInfo
   {
      public ManufacturerImageComboBoxEditViewInfo(RepositoryItem item) : base(item) { }
   }

   public class ManufacturerImageComboBoxEditPainter : ImageComboBoxEditPainter
   {
      public ManufacturerImageComboBoxEditPainter() { }
   }

   public class ManufacturerImageComboBoxEditPopupForm : PopupImageComboBoxEditListBoxForm
   {
      public ManufacturerImageComboBoxEditPopupForm(ManufacturerImageComboBoxEdit ownerEdit) : base(ownerEdit) { }
   }

   #endregion

}
