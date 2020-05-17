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
using Rwm.Otc.Layout;

namespace Rwm.Studio.Plugins.Common.Controls
{
   [UserRepositoryItem("RegisterBlockImageComboBoxEdit")]
   public class RepositoryItemBlockImageComboBoxEdit : RepositoryItemImageComboBox
   {

      #region Constants

      public const string CustomEditName = "BlockImageComboBoxEdit";

      #endregion

      #region Constructors

      static RepositoryItemBlockImageComboBoxEdit()
      {
         RepositoryItemBlockImageComboBoxEdit.RegisterBlockImageComboBoxEdit();
      }

      public RepositoryItemBlockImageComboBoxEdit() { }

      #endregion

      #region Properties

      public override string EditorTypeName
      {
         get { return CustomEditName; }
      }

      #endregion

      #region Methods

      public static void RegisterBlockImageComboBoxEdit()
      {
         Image img = null;
         EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(CustomEditName, typeof(BlockImageComboBoxEdit), typeof(RepositoryItemBlockImageComboBoxEdit), typeof(BlockImageComboBoxEditViewInfo), new BlockImageComboBoxEditPainter(), true, img));
      }

      public override void Assign(RepositoryItem item)
      {
         BeginUpdate();

         try
         {
            base.Assign(item);
            RepositoryItemBlockImageComboBoxEdit source = item as RepositoryItemBlockImageComboBoxEdit;
            if (source == null) return;
         }
         finally
         {
            EndUpdate();
         }
      }

      #endregion

   }

   [ToolboxItem(true)]
   public class BlockImageComboBoxEdit : ImageComboBoxEdit
   {

      #region Constructors

      static BlockImageComboBoxEdit()
      {
         RepositoryItemBlockImageComboBoxEdit.RegisterBlockImageComboBoxEdit();
      }

      /// <summary>
      /// Return a new instance of <see cref="BlockImageComboBoxEdit"/>.
      /// </summary>
      public BlockImageComboBoxEdit() { }

      #endregion

      #region Properties

      /// <summary>
      /// Gets the selected item in the list.
      /// </summary>
      public Element SelectedBlock
      {
         get
         {
            if (this.EditValue == null) return null;
            return this.EditValue as Element;
         }
      }

      private ImageList ImageList { get; set; }

      [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
      public new RepositoryItemBlockImageComboBoxEdit Properties
      {
         get { return base.Properties as RepositoryItemBlockImageComboBoxEdit; }
      }

      public override string EditorTypeName
      {
         get { return RepositoryItemBlockImageComboBoxEdit.CustomEditName; }
      }

      #endregion

      #region Methods

      /// <summary>
      /// Refresh/Fill the editor list of the selected type of elements.
      /// </summary>
      public void RefreshBlocksList()
      {
         this.FillItems(null);
      }

      /// <summary>
      /// Sets the selected element in the editor.
      /// </summary>
      /// <param name="selected">Selected item.</param>
      public void SetSelectedBlock(Element selected)
      {
         this.FillItems(selected);
      }

      protected override PopupBaseForm CreatePopupForm()
      {
         return new BlockImageComboBoxEditPopupForm(this);
      }

      #endregion

      #region Private Members

      private void FillItems(Element selected)
      {

         // Create an image collection
         this.ImageList = new ImageList();
         this.Properties.SmallImages = this.ImageList;

         this.EditValue = null;
         this.Properties.Items.Clear();

         if (Otc.OTCContext.Project != null)
         {
            foreach (Element eb in Element.FindAll())
            {
               if (eb.Properties.ID == 40)
               {
                  // Adds the type image if necessary
                  if (!this.ImageList.Images.ContainsKey(eb.Properties.ID.ToString()))
                  {
                     this.ImageList.Images.Add(eb.Properties.ID.ToString(), eb.Properties.TypeIcon);
                  }

                  ImageComboBoxItem item = new ImageComboBoxItem(eb.ToString(), eb);
                  item.ImageIndex = this.ImageList.Images.IndexOfKey(eb.Properties.ID.ToString());

                  this.Properties.Items.Add(item);

                  if (selected != null && eb == selected) this.EditValue = item;
               }
            }
         }
      }

      #endregion

   }

   #region Nested Classes

   public class BlockImageComboBoxEditViewInfo : ImageComboBoxEditViewInfo
   {
      public BlockImageComboBoxEditViewInfo(RepositoryItem item) : base(item) { }
   }

   public class BlockImageComboBoxEditPainter : ImageComboBoxEditPainter
   {
      public BlockImageComboBoxEditPainter() { }
   }

   public class BlockImageComboBoxEditPopupForm : PopupImageComboBoxEditListBoxForm
   {
      public BlockImageComboBoxEditPopupForm(BlockImageComboBoxEdit ownerEdit) : base(ownerEdit) { }
   }

   #endregion

}
