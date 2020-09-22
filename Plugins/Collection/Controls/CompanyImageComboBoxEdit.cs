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
   [UserRepositoryItem("RegisterCompanyImageComboBoxEdit")]
   public class RepositoryItemCompanyImageComboBoxEdit : RepositoryItemImageComboBox
   {

      #region Constants

      public const string CustomEditName = "CompanyImageComboBoxEdit";

      #endregion

      #region Constructors

      static RepositoryItemCompanyImageComboBoxEdit()
      {
         RepositoryItemCompanyImageComboBoxEdit.RegisterCompanyImageComboBoxEdit();
      }

      public RepositoryItemCompanyImageComboBoxEdit() { }

      #endregion

      #region Properties

      public override string EditorTypeName
      {
         get { return CustomEditName; }
      }

      #endregion

      #region Methods

      public static void RegisterCompanyImageComboBoxEdit()
      {
         Image img = null;
         EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(CustomEditName, typeof(CompanyImageComboBoxEdit), typeof(RepositoryItemCompanyImageComboBoxEdit), typeof(CompanyImageComboBoxEditViewInfo), new CompanyImageComboBoxEditPainter(), true, img));
      }

      public override void Assign(RepositoryItem item)
      {
         BeginUpdate();

         try
         {
            base.Assign(item);
            if (!(item is RepositoryItemCompanyImageComboBoxEdit source)) return;
         }
         finally
         {
            EndUpdate();
         }
      }

      #endregion

   }

   [ToolboxItem(true)]
   public class CompanyImageComboBoxEdit : ImageComboBoxEdit
   {

      #region Constructors

      static CompanyImageComboBoxEdit()
      {
         RepositoryItemCompanyImageComboBoxEdit.RegisterCompanyImageComboBoxEdit();
      }

      /// <summary>
      /// Return a new instance of <see cref="CompanyImageComboBoxEdit"/>.
      /// </summary>
      public CompanyImageComboBoxEdit() { }

      #endregion

      #region Properties

      /// <summary>
      /// Gets the selected item in the list.
      /// </summary>
      public Company SelectedCompany
      {
         get
         {
            if (this.EditValue == null) return null;
            return this.EditValue as Company;
         }
      }

      private ImageList ImageList { get; set; }

      [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
      public new RepositoryItemCompanyImageComboBoxEdit Properties
      {
         get { return base.Properties as RepositoryItemCompanyImageComboBoxEdit; }
      }

      public override string EditorTypeName
      {
         get { return RepositoryItemCompanyImageComboBoxEdit.CustomEditName; }
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
      public void SetSelectedElement(Company selected)
      {
         this.FillItems(selected);
      }

      protected override PopupBaseForm CreatePopupForm()
      {
         return new CompanyImageComboBoxEditPopupForm(this);
      }

      #endregion

      #region Private Members

      private void FillItems(Company selected)
      {
         ImageComboBoxItem item;

         // Create an image collection
         if (this.Properties.SmallImages == null)
         {
            this.ImageList = new ImageList();
            this.ImageList.Images.Add(Collection.Properties.Resources.ICO_ADMIN_OFF_16);
            this.ImageList.Images.Add(Company.SmallIcon);
            this.Properties.SmallImages = this.ImageList;
         }

         this.Properties.Items.Clear();

         if (OTCContext.Project != null)
         {
            item = new ImageComboBoxItem("Not specified", null, 0);
            this.Properties.Items.Add(item);

            foreach (Company company in Company.FindAll())
            {
               item = new ImageComboBoxItem(company.Name, company, 1);
               this.Properties.Items.Add(item);

               if (selected != null && company == selected) 
                  this.EditValue = item;
            }

            if (selected == null || this.EditValue == null) 
               this.EditValue = this.Properties.Items[0];
         }
      }

      #endregion

   }

   #region Nested Classes

   public class CompanyImageComboBoxEditViewInfo : ImageComboBoxEditViewInfo
   {
      public CompanyImageComboBoxEditViewInfo(RepositoryItem item) : base(item) { }
   }

   public class CompanyImageComboBoxEditPainter : ImageComboBoxEditPainter
   {
      public CompanyImageComboBoxEditPainter() { }
   }

   public class CompanyImageComboBoxEditPopupForm : PopupImageComboBoxEditListBoxForm
   {
      public CompanyImageComboBoxEditPopupForm(CompanyImageComboBoxEdit ownerEdit) : base(ownerEdit) { }
   }

   #endregion

}
