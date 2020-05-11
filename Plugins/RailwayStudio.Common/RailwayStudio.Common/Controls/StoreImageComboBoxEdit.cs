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
   [UserRepositoryItem("RegisterStoreImageComboBoxEdit")]
   public class RepositoryItemStoreImageComboBoxEdit : RepositoryItemImageComboBox
   {

      #region Constants

      public const string CustomEditName = "StoreImageComboBoxEdit";

      #endregion

      #region Constructors

      static RepositoryItemStoreImageComboBoxEdit()
      {
         RepositoryItemStoreImageComboBoxEdit.RegisterStoreImageComboBoxEdit();
      }

      public RepositoryItemStoreImageComboBoxEdit() { }

      #endregion

      #region Properties

      public override string EditorTypeName
      {
         get { return CustomEditName; }
      }

      #endregion

      #region Methods

      public static void RegisterStoreImageComboBoxEdit()
      {
         Image img = null;
         EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(CustomEditName, typeof(StoreImageComboBoxEdit), typeof(RepositoryItemStoreImageComboBoxEdit), typeof(StoreImageComboBoxEditViewInfo), new StoreImageComboBoxEditPainter(), true, img));
      }

      public override void Assign(RepositoryItem item)
      {
         BeginUpdate();

         try
         {
            base.Assign(item);
            if (!(item is RepositoryItemStoreImageComboBoxEdit source)) return;
         }
         finally
         {
            EndUpdate();
         }
      }

      #endregion

   }

   [ToolboxItem(true)]
   public class StoreImageComboBoxEdit : ImageComboBoxEdit
   {

      #region Constructors

      static StoreImageComboBoxEdit()
      {
         RepositoryItemStoreImageComboBoxEdit.RegisterStoreImageComboBoxEdit();
      }

      /// <summary>
      /// Return a new instance of <see cref="StoreImageComboBoxEdit"/>.
      /// </summary>
      public StoreImageComboBoxEdit() { }

      #endregion

      #region Properties

      /// <summary>
      /// Gets the selected item in the list.
      /// </summary>
      public Store SelectedStore
      {
         get
         {
            if (this.EditValue == null) return null;
            return this.EditValue as Store;
         }
      }

      private ImageList ImageList { get; set; }

      [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
      public new RepositoryItemStoreImageComboBoxEdit Properties
      {
         get { return base.Properties as RepositoryItemStoreImageComboBoxEdit; }
      }

      public override string EditorTypeName
      {
         get { return RepositoryItemStoreImageComboBoxEdit.CustomEditName; }
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
      public void SetSelectedElement(Store selected)
      {
         this.FillItems(selected);
      }

      protected override PopupBaseForm CreatePopupForm()
      {
         return new StoreImageComboBoxEditPopupForm(this);
      }

      #endregion

      #region Private Members

      private void FillItems(Store selected)
      {
         ImageComboBoxItem item;

         // Create an image collection
         if (this.Properties.SmallImages == null)
         {
            this.ImageList = new ImageList();
            this.ImageList.Images.Add(Common.Properties.Resources.ICO_STORE_OFF_16);
            this.ImageList.Images.Add(Common.Properties.Resources.ICO_STORE_16);
            this.Properties.SmallImages = this.ImageList;
         }

         this.Properties.Items.Clear();

         if (OTCContext.Project != null)
         {
            item = new ImageComboBoxItem("Not specified", null, 0);
            this.Properties.Items.Add(item);

            foreach (Store store in Store.FindAll())
            {
               item = new ImageComboBoxItem(store.Name, store, 1);
               this.Properties.Items.Add(item);

               if (selected != null && store == selected) 
                  this.EditValue = item;
            }

            if (selected == null || this.EditValue == null) 
               this.EditValue = this.Properties.Items[0];
         }
      }

      #endregion

   }

   #region Nested Classes

   public class StoreImageComboBoxEditViewInfo : ImageComboBoxEditViewInfo
   {
      public StoreImageComboBoxEditViewInfo(RepositoryItem item) : base(item) { }
   }

   public class StoreImageComboBoxEditPainter : ImageComboBoxEditPainter
   {
      public StoreImageComboBoxEditPainter() { }
   }

   public class StoreImageComboBoxEditPopupForm : PopupImageComboBoxEditListBoxForm
   {
      public StoreImageComboBoxEditPopupForm(StoreImageComboBoxEdit ownerEdit) : base(ownerEdit) { }
   }

   #endregion

}
