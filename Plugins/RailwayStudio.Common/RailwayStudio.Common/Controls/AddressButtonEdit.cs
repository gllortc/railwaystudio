using System.ComponentModel;
using System.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using Rwm.Otc.Trains;

namespace Rwm.Studio.Plugins.Common.Controls
{
   [UserRepositoryItem("RegisterAddressButtonEdit")]
   public class RepositoryItemAddressButtonEdit : RepositoryItemButtonEdit
   {

      #region Constants

      public const string CustomEditName = "AddressButtonEdit";

      #endregion

      #region Constructors

      static RepositoryItemAddressButtonEdit()
      {
         RegisterAddressButtonEdit();
      }

      public RepositoryItemAddressButtonEdit() { }

      #endregion

      #region Properties

      public override string EditorTypeName
      {
         get { return CustomEditName; }
      }

      #endregion

      #region Methods

      public static void RegisterAddressButtonEdit()
      {
         Image img = null;
         EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(CustomEditName, typeof(AddressButtonEdit), typeof(RepositoryItemAddressButtonEdit), typeof(AddressButtonEditViewInfo), new AddressButtonEditPainter(), true, img));
      }

      public override void Assign(RepositoryItem item)
      {
         this.BeginUpdate();

         try
         {
            base.Assign(item);
            if (!(item is RepositoryItemAddressButtonEdit source)) return;
         }
         finally
         {
            this.EndUpdate();
         }
      }

      protected override void OnLoaded()
      {
         base.OnLoaded();
         
         // this.Properties.Buttons.Clear();
         this.Buttons.Add(new EditorButton(ButtonPredefines.Glyph, Common.Properties.Resources.ICO_FIND_16, null));
         this.Buttons.Add(new EditorButton(ButtonPredefines.Glyph, Common.Properties.Resources.ICO_CLEAN_16, null));
      }

      #endregion

   }

   [ToolboxItem(true)]
   public class AddressButtonEdit : ButtonEdit
   {

      #region Constructors

      static AddressButtonEdit()
      {
         RepositoryItemAddressButtonEdit.RegisterAddressButtonEdit();
      }

      public AddressButtonEdit()
      {
         this.FindDialogTitle = "Select train";
      }

      #endregion

      #region Properties

      public override string EditorTypeName
      {
         get { return RepositoryItemAddressButtonEdit.CustomEditName; }
      }

      [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
      public new RepositoryItemAddressButtonEdit Properties
      {
         get { return base.Properties as RepositoryItemAddressButtonEdit; }
      }

      public string FindDialogTitle { get; set; }

      public int SelectedAddress { get; private set; }

      #endregion

      #region Event Handlers

      //protected override void OnLoaded()
      //{
      //   // this.Properties.Buttons.Clear();
      //   this.Properties.Buttons.Add(new EditorButton(ButtonPredefines.Glyph, Common.Properties.Resources.ICO_FIND_16, null));

      //   this.EditValue = 15;

      //   base.OnLoaded();
      //}

      protected override void OnClickButton(EditorButtonObjectInfoArgs buttonInfo)
      {
         this.SelectedAddress = 1;
         this.Text = this.SelectedAddress.ToString("3d");
      }

      #endregion

   }

   public class AddressButtonEditViewInfo : ButtonEditViewInfo
   {
      public AddressButtonEditViewInfo(RepositoryItem item) : base(item) { }
   }

   public class AddressButtonEditPainter : ButtonEditPainter
   {
      public AddressButtonEditPainter() { }
   }
}
