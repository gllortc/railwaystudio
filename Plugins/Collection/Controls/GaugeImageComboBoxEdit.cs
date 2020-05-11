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
   [UserRepositoryItem("RegisterGaugeImageComboBoxEdit")]
   public class RepositoryItemGaugeImageComboBoxEdit : RepositoryItemImageComboBox
   {

      #region Constants

      public const string CustomEditName = "GaugeImageComboBoxEdit";

      #endregion

      #region Constructors

      static RepositoryItemGaugeImageComboBoxEdit()
      {
         RepositoryItemGaugeImageComboBoxEdit.RegisterGaugeImageComboBoxEdit();
      }

      public RepositoryItemGaugeImageComboBoxEdit() { }

      #endregion

      #region Properties

      public override string EditorTypeName
      {
         get { return CustomEditName; }
      }

      #endregion

      #region Methods

      public static void RegisterGaugeImageComboBoxEdit()
      {
         Image img = null;
         EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(CustomEditName, typeof(GaugeImageComboBoxEdit), typeof(RepositoryItemGaugeImageComboBoxEdit), typeof(GaugeImageComboBoxEditViewInfo), new GaugeImageComboBoxEditPainter(), true, img));
      }

      public override void Assign(RepositoryItem item)
      {
         BeginUpdate();

         try
         {
            base.Assign(item);
            if (!(item is RepositoryItemGaugeImageComboBoxEdit source)) return;
         }
         finally
         {
            EndUpdate();
         }
      }

      #endregion

   }

   [ToolboxItem(true)]
   public class GaugeImageComboBoxEdit : ImageComboBoxEdit
   {

      #region Constructors

      static GaugeImageComboBoxEdit()
      {
         RepositoryItemGaugeImageComboBoxEdit.RegisterGaugeImageComboBoxEdit();
      }

      /// <summary>
      /// Return a new instance of <see cref="GaugeImageComboBoxEdit"/>.
      /// </summary>
      public GaugeImageComboBoxEdit() { }

      #endregion

      #region Properties

      /// <summary>
      /// Gets the selected item in the list.
      /// </summary>
      public Gauge SelectedGauge
      {
         get
         {
            if (this.EditValue == null) return null;
            return this.EditValue as Gauge;
         }
      }

      private ImageList ImageList { get; set; }

      [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
      public new RepositoryItemGaugeImageComboBoxEdit Properties
      {
         get { return base.Properties as RepositoryItemGaugeImageComboBoxEdit; }
      }

      public override string EditorTypeName
      {
         get { return RepositoryItemGaugeImageComboBoxEdit.CustomEditName; }
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
      public void SetSelectedElement(Gauge selected)
      {
         this.FillItems(selected);
      }

      protected override PopupBaseForm CreatePopupForm()
      {
         return new GaugeImageComboBoxEditPopupForm(this);
      }

      #endregion

      #region Private Members

      private void FillItems(Gauge selected)
      {
         ImageComboBoxItem item;

         // Create an image collection
         if (this.Properties.SmallImages == null)
         {
            this.ImageList = new ImageList();
            this.ImageList.Images.Add(Collection.Properties.Resources.ICO_GAUGE_OFF_16);
            this.ImageList.Images.Add(Collection.Properties.Resources.ICO_GAUGE_16);
            this.Properties.SmallImages = this.ImageList;
         }

         this.Properties.Items.Clear();

         if (OTCContext.Project != null)
         {
            item = new ImageComboBoxItem("Not specified", null, 0);
            this.Properties.Items.Add(item);

            foreach (Gauge company in Gauge.FindAll())
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

   public class GaugeImageComboBoxEditViewInfo : ImageComboBoxEditViewInfo
   {
      public GaugeImageComboBoxEditViewInfo(RepositoryItem item) : base(item) { }
   }

   public class GaugeImageComboBoxEditPainter : ImageComboBoxEditPainter
   {
      public GaugeImageComboBoxEditPainter() { }
   }

   public class GaugeImageComboBoxEditPopupForm : PopupImageComboBoxEditListBoxForm
   {
      public GaugeImageComboBoxEditPopupForm(GaugeImageComboBoxEdit ownerEdit) : base(ownerEdit) { }
   }

   #endregion

}
