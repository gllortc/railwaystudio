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
using Rwm.Otc.Layout;

namespace Rwm.Studio.Plugins.Common.Controls
{
   [UserRepositoryItem("RegisterSectionImageComboBoxEdit")]
   public class RepositoryItemSectionImageComboBoxEdit : RepositoryItemImageComboBox
   {

      #region Constants

      public const string CustomEditName = "SectionImageComboBoxEdit";

      #endregion

      #region Constructors

      static RepositoryItemSectionImageComboBoxEdit()
      {
         RepositoryItemSectionImageComboBoxEdit.RegisterSectionImageComboBoxEdit();
      }

      public RepositoryItemSectionImageComboBoxEdit() { }

      #endregion

      #region Properties

      public override string EditorTypeName
      {
         get { return CustomEditName; }
      }

      #endregion

      #region Methods

      public static void RegisterSectionImageComboBoxEdit()
      {
         Image img = null;
         EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(CustomEditName, typeof(SectionImageComboBoxEdit), typeof(RepositoryItemSectionImageComboBoxEdit), typeof(SectionImageComboBoxEditViewInfo), new SectionImageComboBoxEditPainter(), true, img));
      }

      public override void Assign(RepositoryItem item)
      {
         BeginUpdate();

         try
         {
            base.Assign(item);
            if (!(item is RepositoryItemSectionImageComboBoxEdit source)) return;
         }
         finally
         {
            EndUpdate();
         }
      }

      #endregion

   }

   [ToolboxItem(true)]
   public class SectionImageComboBoxEdit : ImageComboBoxEdit
   {

      #region Constructors

      static SectionImageComboBoxEdit()
      {
         RepositoryItemSectionImageComboBoxEdit.RegisterSectionImageComboBoxEdit();
      }

      /// <summary>
      /// Return a new instance of <see cref="SectionImageComboBoxEdit"/>.
      /// </summary>
      public SectionImageComboBoxEdit() { }

      #endregion

      #region Properties

      /// <summary>
      /// Gets the selected item in the list.
      /// </summary>
      public Module SelectedSection
      {
         get
         {
            if (this.EditValue == null) return null;
            return this.EditValue as Module;
         }
      }

      private ImageList ImageList { get; set; }

      [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
      public new RepositoryItemSectionImageComboBoxEdit Properties
      {
         get { return base.Properties as RepositoryItemSectionImageComboBoxEdit; }
      }

      public override string EditorTypeName
      {
         get { return RepositoryItemSectionImageComboBoxEdit.CustomEditName; }
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
      public void SetSelectedElement(Module selected)
      {
         this.FillItems(selected);
      }

      protected override PopupBaseForm CreatePopupForm()
      {
         return new SectionImageComboBoxEditPopupForm(this);
      }

      #endregion

      #region Private Members

      private void FillItems(Module selected)
      {
         ImageComboBoxItem item;

         // Create an image collection
         if (this.Properties.SmallImages == null)
         {
            this.ImageList = new ImageList();
            this.ImageList.Images.Add(Module.GlobalSmallIcon);
            this.ImageList.Images.Add(Module.SmallIcon);
            this.Properties.SmallImages = this.ImageList;
         }

         this.Properties.Items.Clear();

         if (OTCContext.Project != null)
         {
            item = new ImageComboBoxItem("Not specified", null, 0);
            this.Properties.Items.Add(item);

            foreach (Module section in OTCContext.Project.Sections)
            {
               item = new ImageComboBoxItem(section.Name, section, 1);
               this.Properties.Items.Add(item);

               if (selected != null && section == selected) 
                  this.EditValue = item;
            }

            if (selected == null || this.EditValue == null) 
               this.EditValue = this.Properties.Items[0];
         }
      }

      #endregion

   }

   #region Nested Classes

   public class SectionImageComboBoxEditViewInfo : ImageComboBoxEditViewInfo
   {
      public SectionImageComboBoxEditViewInfo(RepositoryItem item) : base(item) { }
   }

   public class SectionImageComboBoxEditPainter : ImageComboBoxEditPainter
   {
      public SectionImageComboBoxEditPainter() { }
   }

   public class SectionImageComboBoxEditPopupForm : PopupImageComboBoxEditListBoxForm
   {
      public SectionImageComboBoxEditPopupForm(SectionImageComboBoxEdit ownerEdit) : base(ownerEdit) { }
   }

   #endregion

}
