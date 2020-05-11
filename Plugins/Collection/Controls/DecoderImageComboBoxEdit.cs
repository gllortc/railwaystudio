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
   [UserRepositoryItem("RegisterDecoderImageComboBoxEdit")]
   public class RepositoryItemDecoderImageComboBoxEdit : RepositoryItemImageComboBox
   {

      #region Constants

      public const string CustomEditName = "DecoderImageComboBoxEdit";

      #endregion

      #region Constructors

      static RepositoryItemDecoderImageComboBoxEdit()
      {
         RepositoryItemDecoderImageComboBoxEdit.RegisterDecoderImageComboBoxEdit();
      }

      public RepositoryItemDecoderImageComboBoxEdit() { }

      #endregion

      #region Properties

      public override string EditorTypeName
      {
         get { return CustomEditName; }
      }

      #endregion

      #region Methods

      public static void RegisterDecoderImageComboBoxEdit()
      {
         Image img = null;
         EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(CustomEditName, typeof(DecoderImageComboBoxEdit), typeof(RepositoryItemDecoderImageComboBoxEdit), typeof(DecoderImageComboBoxEditViewInfo), new DecoderImageComboBoxEditPainter(), true, img));
      }

      public override void Assign(RepositoryItem item)
      {
         BeginUpdate();

         try
         {
            base.Assign(item);
            if (!(item is RepositoryItemDecoderImageComboBoxEdit source)) return;
         }
         finally
         {
            EndUpdate();
         }
      }

      #endregion

   }

   [ToolboxItem(true)]
   public class DecoderImageComboBoxEdit : ImageComboBoxEdit
   {

      #region Constructors

      static DecoderImageComboBoxEdit()
      {
         RepositoryItemDecoderImageComboBoxEdit.RegisterDecoderImageComboBoxEdit();
      }

      /// <summary>
      /// Return a new instance of <see cref="DecoderImageComboBoxEdit"/>.
      /// </summary>
      public DecoderImageComboBoxEdit() { }

      #endregion

      #region Properties

      /// <summary>
      /// Gets the selected item in the list.
      /// </summary>
      public TrainDecoder SelectedDecoder
      {
         get
         {
            if (this.EditValue == null) return null;
            return this.EditValue as TrainDecoder;
         }
      }

      private ImageList ImageList { get; set; }

      [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
      public new RepositoryItemDecoderImageComboBoxEdit Properties
      {
         get { return base.Properties as RepositoryItemDecoderImageComboBoxEdit; }
      }

      public override string EditorTypeName
      {
         get { return RepositoryItemDecoderImageComboBoxEdit.CustomEditName; }
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
      public void SetSelectedElement(TrainDecoder selected)
      {
         this.FillItems(selected);
      }

      protected override PopupBaseForm CreatePopupForm()
      {
         return new DecoderImageComboBoxEditPopupForm(this);
      }

      #endregion

      #region Private Members

      private void FillItems(TrainDecoder selected)
      {
         ImageComboBoxItem item;

         // Create an image collection
         if (this.Properties.SmallImages == null)
         {
            this.ImageList = new ImageList();
            this.ImageList.Images.Add(Collection.Properties.Resources.ICO_DECODER_OFF_16);
            this.ImageList.Images.Add(Collection.Properties.Resources.ICO_DECODER_16);
            this.Properties.SmallImages = this.ImageList;
         }

         this.Properties.Items.Clear();

         if (OTCContext.Project != null)
         {
            item = new ImageComboBoxItem("Not specified", null, 0);
            this.Properties.Items.Add(item);

            foreach (TrainDecoder decoder in TrainDecoder.FindAll())
            {
               item = new ImageComboBoxItem(decoder.Name, decoder, 1);
               this.Properties.Items.Add(item);

               if (selected != null && decoder == selected) 
                  this.EditValue = item;
            }

            if (selected == null || this.EditValue == null) 
               this.EditValue = this.Properties.Items[0];
         }
      }

      #endregion

   }

   #region Nested Classes

   public class DecoderImageComboBoxEditViewInfo : ImageComboBoxEditViewInfo
   {
      public DecoderImageComboBoxEditViewInfo(RepositoryItem item) : base(item) { }
   }

   public class DecoderImageComboBoxEditPainter : ImageComboBoxEditPainter
   {
      public DecoderImageComboBoxEditPainter() { }
   }

   public class DecoderImageComboBoxEditPopupForm : PopupImageComboBoxEditListBoxForm
   {
      public DecoderImageComboBoxEditPopupForm(DecoderImageComboBoxEdit ownerEdit) : base(ownerEdit) { }
   }

   #endregion

}
