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
using static Rwm.Otc.Trains.Train;

namespace Rwm.Studio.Plugins.Collection.Controls
{
   [UserRepositoryItem("RegisterEraImageComboBoxEdit")]
   public class RepositoryItemEraImageComboBoxEdit : RepositoryItemImageComboBox
   {

      #region Constants

      public const string CustomEditName = "EraImageComboBoxEdit";

      #endregion

      #region Constructors

      static RepositoryItemEraImageComboBoxEdit()
      {
         RepositoryItemEraImageComboBoxEdit.RegisterEraImageComboBoxEdit();
      }

      public RepositoryItemEraImageComboBoxEdit() { }

      #endregion

      #region Properties

      public override string EditorTypeName
      {
         get { return CustomEditName; }
      }

      #endregion

      #region Methods

      public static void RegisterEraImageComboBoxEdit()
      {
         Image img = null;
         EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(CustomEditName, typeof(EraImageComboBoxEdit), typeof(RepositoryItemEraImageComboBoxEdit), typeof(EraImageComboBoxEditViewInfo), new EraImageComboBoxEditPainter(), true, img));
      }

      public override void Assign(RepositoryItem item)
      {
         BeginUpdate();

         try
         {
            base.Assign(item);
            if (!(item is RepositoryItemEraImageComboBoxEdit source)) return;
         }
         finally
         {
            EndUpdate();
         }
      }

      #endregion

   }

   [ToolboxItem(true)]
   public class EraImageComboBoxEdit : ImageComboBoxEdit
   {

      #region Constructors

      static EraImageComboBoxEdit()
      {
         RepositoryItemEraImageComboBoxEdit.RegisterEraImageComboBoxEdit();
      }

      /// <summary>
      /// Return a new instance of <see cref="EraImageComboBoxEdit"/>.
      /// </summary>
      public EraImageComboBoxEdit() { }

      #endregion

      #region Properties

      /// <summary>
      /// Gets the selected item in the list.
      /// </summary>
      public Epoche SelectedEra
      {
         get
         {
            if (this.EditValue == null)
               return Epoche.NotDefined;
            else if (!(this.EditValue is Epoche))
               return Epoche.NotDefined;
            else
            {
               try
               {
                  return (Epoche)this.EditValue;
               }
               catch
               {
                  return Epoche.NotDefined;
               }
            }
         }
      }

      private ImageList ImageList { get; set; }

      [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
      public new RepositoryItemEraImageComboBoxEdit Properties
      {
         get { return base.Properties as RepositoryItemEraImageComboBoxEdit; }
      }

      public override string EditorTypeName
      {
         get { return RepositoryItemEraImageComboBoxEdit.CustomEditName; }
      }

      #endregion

      #region Methods

      /// <summary>
      /// Refresh/Fill the editor list of the selected type of elements.
      /// </summary>
      public void RefreshElementsList()
      {
         this.FillItems(Epoche.NotDefined);
      }

      /// <summary>
      /// Sets the selected element in the editor.
      /// </summary>
      /// <param name="selected">Selected item.</param>
      public void SetSelectedElement(Epoche selected)
      {
         this.FillItems(selected);
      }

      protected override PopupBaseForm CreatePopupForm()
      {
         return new EraImageComboBoxEditPopupForm(this);
      }

      #endregion

      #region Private Members

      private void FillItems(Epoche selected)
      {
         ImageComboBoxItem item;

         // Create an image collection
         if (this.Properties.SmallImages == null)
         {
            this.ImageList = new ImageList();
            this.ImageList.Images.Add(Collection.Properties.Resources.PICTO_EPOCHE_OFF_16);
            this.ImageList.Images.Add(Collection.Properties.Resources.PICTO_EPOCHE_I_16);
            this.ImageList.Images.Add(Collection.Properties.Resources.PICTO_EPOCHE_II_16);
            this.ImageList.Images.Add(Collection.Properties.Resources.PICTO_EPOCHE_III_16);
            this.ImageList.Images.Add(Collection.Properties.Resources.PICTO_EPOCHE_IV_16);
            this.ImageList.Images.Add(Collection.Properties.Resources.PICTO_EPOCHE_V_16);
            this.ImageList.Images.Add(Collection.Properties.Resources.PICTO_EPOCHE_VI_16);
            this.Properties.SmallImages = this.ImageList;
         }

         this.Properties.Items.Clear();

         if (OTCContext.Project != null)
         {
            item = new ImageComboBoxItem("Not specified", Epoche.NotDefined, (int)Epoche.NotDefined);
            this.Properties.Items.Add(item);
            if (selected == Epoche.NotDefined) this.EditValue = item;

            item = new ImageComboBoxItem("Era I", Epoche.EpocheI, (int)Epoche.EpocheI);
            this.Properties.Items.Add(item);
            if (selected == Epoche.EpocheI) this.EditValue = item;

            item = new ImageComboBoxItem("Era II", Epoche.EpocheII, (int)Epoche.EpocheII);
            this.Properties.Items.Add(item);
            if (selected == Epoche.EpocheII) this.EditValue = item;

            item = new ImageComboBoxItem("Era III", Epoche.EpocheIII, (int)Epoche.EpocheIII);
            this.Properties.Items.Add(item);
            if (selected == Epoche.EpocheIII) this.EditValue = item;

            item = new ImageComboBoxItem("Era IV", Epoche.EpocheIV, (int)Epoche.EpocheIV);
            this.Properties.Items.Add(item);
            if (selected == Epoche.EpocheIV) this.EditValue = item;

            item = new ImageComboBoxItem("Era V", Epoche.EpocheV, (int)Epoche.EpocheV);
            this.Properties.Items.Add(item);
            if (selected == Epoche.EpocheV) this.EditValue = item;

            item = new ImageComboBoxItem("Era VI", Epoche.EpocheVI, (int)Epoche.EpocheVI);
            this.Properties.Items.Add(item);
            if (selected == Epoche.EpocheVI) this.EditValue = item;

            if (this.EditValue == null) this.EditValue = this.Properties.Items[0];
         }
      }

      #endregion

   }

   #region Nested Classes

   public class EraImageComboBoxEditViewInfo : ImageComboBoxEditViewInfo
   {
      public EraImageComboBoxEditViewInfo(RepositoryItem item) : base(item) { }
   }

   public class EraImageComboBoxEditPainter : ImageComboBoxEditPainter
   {
      public EraImageComboBoxEditPainter() { }
   }

   public class EraImageComboBoxEditPopupForm : PopupImageComboBoxEditListBoxForm
   {
      public EraImageComboBoxEditPopupForm(EraImageComboBoxEdit ownerEdit) : base(ownerEdit) { }
   }

   #endregion

}
