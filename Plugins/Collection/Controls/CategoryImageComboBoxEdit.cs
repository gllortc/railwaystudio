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

namespace Rwm.Studio.Plugins.Collection.Controls
{
   [UserRepositoryItem("RegisterCategoryImageComboBoxEdit")]
   public class RepositoryItemCategoryImageComboBoxEdit : RepositoryItemImageComboBox
   {

      #region Constants

      public const string CustomEditName = "CategoryImageComboBoxEdit";

      #endregion

      #region Constructors

      static RepositoryItemCategoryImageComboBoxEdit()
      {
         RepositoryItemCategoryImageComboBoxEdit.RegisterCategoryImageComboBoxEdit();
      }

      public RepositoryItemCategoryImageComboBoxEdit() { }

      #endregion

      #region Properties

      public override string EditorTypeName
      {
         get { return CustomEditName; }
      }

      #endregion

      #region Methods

      public static void RegisterCategoryImageComboBoxEdit()
      {
         Image img = null;
         EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(CustomEditName, typeof(CategoryImageComboBoxEdit), typeof(RepositoryItemCategoryImageComboBoxEdit), typeof(CategoryImageComboBoxEditViewInfo), new CategoryImageComboBoxEditPainter(), true, img));
      }

      public override void Assign(RepositoryItem item)
      {
         BeginUpdate();

         try
         {
            base.Assign(item);
            if (!(item is RepositoryItemCategoryImageComboBoxEdit source)) return;
         }
         finally
         {
            EndUpdate();
         }
      }

      #endregion

   }

   [ToolboxItem(true)]
   public class CategoryImageComboBoxEdit : ImageComboBoxEdit
   {

      #region Constructors

      static CategoryImageComboBoxEdit()
      {
         RepositoryItemCategoryImageComboBoxEdit.RegisterCategoryImageComboBoxEdit();
      }

      /// <summary>
      /// Return a new instance of <see cref="CategoryImageComboBoxEdit"/>.
      /// </summary>
      public CategoryImageComboBoxEdit() { }

      #endregion

      #region Properties

      /// <summary>
      /// Gets the selected item in the list.
      /// </summary>
      public Category SelectedCategory
      {
         get
         {
            if (this.EditValue == null) return null;
            return this.EditValue as Category;
         }
      }

      private ImageList ImageList { get; set; }

      [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
      public new RepositoryItemCategoryImageComboBoxEdit Properties
      {
         get { return base.Properties as RepositoryItemCategoryImageComboBoxEdit; }
      }

      public override string EditorTypeName
      {
         get { return RepositoryItemCategoryImageComboBoxEdit.CustomEditName; }
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
      public void SetSelectedElement(Category selected)
      {
         this.FillItems(selected);
      }

      protected override PopupBaseForm CreatePopupForm()
      {
         return new CategoryImageComboBoxEditPopupForm(this);
      }

      #endregion

      #region Private Members

      private void FillItems(Category selected)
      {
         ImageComboBoxItem item;

         // Create an image collection
         if (this.Properties.SmallImages == null)
         {
            this.ImageList = new ImageList();
            this.ImageList.Images.Add(Collection.Properties.Resources.ICO_CATEGORY_16);
            this.Properties.SmallImages = this.ImageList;
         }

         this.Properties.Items.Clear();

         if (OTCContext.Project != null)
         {
            foreach (Category category in Category.FindAll())
            {
               item = new ImageComboBoxItem(category.Name, category, 0);
               this.Properties.Items.Add(item);

               if (selected != null && category == selected) 
                  this.EditValue = item;
            }

            if (selected == null || this.EditValue == null) 
               this.EditValue = this.Properties.Items[0];
         }
      }

      #endregion

   }

   #region Nested Classes

   public class CategoryImageComboBoxEditViewInfo : ImageComboBoxEditViewInfo
   {
      public CategoryImageComboBoxEditViewInfo(RepositoryItem item) : base(item) { }
   }

   public class CategoryImageComboBoxEditPainter : ImageComboBoxEditPainter
   {
      public CategoryImageComboBoxEditPainter() { }
   }

   public class CategoryImageComboBoxEditPopupForm : PopupImageComboBoxEditListBoxForm
   {
      public CategoryImageComboBoxEditPopupForm(CategoryImageComboBoxEdit ownerEdit) : base(ownerEdit) { }
   }

   #endregion

}
