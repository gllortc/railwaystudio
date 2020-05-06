using System;
using System.ComponentModel;
using System.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using Rwm.Otc;

namespace Rwm.Studio.Plugins.Common.Controls
{
   [UserRepositoryItem("RegisterAddressEdit")]
   public class RepositoryItemAddressEdit : RepositoryItemSpinEdit
   {

      #region Constants

      public const string CustomEditName = "AddressEdit";

      #endregion

      #region Constructors

      static RepositoryItemAddressEdit()
      {
         RegisterAddressEdit();
      }

      public RepositoryItemAddressEdit() { }

      #endregion

      #region Properties

      public override string EditorTypeName
      {
         get { return CustomEditName; }
      }

      #endregion

      public static void RegisterAddressEdit()
      {
         Image img = null;
         EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(CustomEditName, 
                                                                        typeof(AddressEdit), 
                                                                        typeof(RepositoryItemAddressEdit), 
                                                                        typeof(AddressEditViewInfo), 
                                                                        new AddressEditPainter(), 
                                                                        true, 
                                                                        img));
      }

      public override void Assign(RepositoryItem item)
      {
         BeginUpdate();

         try
         {
            base.Assign(item);
            if (!(item is RepositoryItemAddressEdit source)) return;
         }
         finally
         {
            EndUpdate();
         }
      }

      //public override void CreateDefaultButton()
      //{
      //   base.CreateDefaultButton();

      //   //this.Increment = 1;
      //   //this.MinValue = 0; ; // OTCContext.Project.DigitalSystem.AccessoryAddressRange.Minimum;
      //   //this.MaxValue = OTCContext.Project.DigitalSystem.AccessoryAddressRange.Maximum;

      //   this.Buttons.Add(new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph,
      //                                                                     Common.Properties.Resources.ICO_FIND_16,
      //                                                                     null));
      //}

      protected override void OnLoaded()
      {
         base.OnLoaded();

         this.Buttons.Add(new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph,
                                                                           Common.Properties.Resources.ICO_FIND_16,
                                                                           null));
      }

   }

   [ToolboxItem(true)]
   public class AddressEdit : SpinEdit
   {

      #region Constructors

      static AddressEdit()
      {
         RepositoryItemAddressEdit.RegisterAddressEdit();
      }

      public AddressEdit() { }

      #endregion

      #region Properties

      [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
      public new RepositoryItemAddressEdit Properties
      {
         get { return base.Properties as RepositoryItemAddressEdit; }
      }

      public override string EditorTypeName
      {
         get { return RepositoryItemAddressEdit.CustomEditName; }
      }

      #endregion

      #region Methods

      protected override PopupBaseForm CreatePopupForm()
      {
         return new AddressEditPopupForm(this);
      }

      #endregion

      #region Event Handlers

      protected override void OnLoaded()
      {
         base.OnLoaded();

         this.Properties.Buttons.Add(new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph,
                                                                           Common.Properties.Resources.ICO_FIND_16,
                                                                           null));
      }

      #endregion

   }

   public class AddressEditViewInfo : BaseSpinEditViewInfo
   {
      public AddressEditViewInfo(RepositoryItem item) : base(item) { }
   }

   public class AddressEditPainter : ButtonEditPainter
   {
      public AddressEditPainter() { }
   }

   public class AddressEditPopupForm : PopupBaseForm
   {
      public AddressEditPopupForm(AddressEdit ownerEdit) : base(ownerEdit) { }

      protected override Size CalcFormSizeCore()
      {
         throw new NotImplementedException();
      }

      public override object ResultValue
      {
         get { throw new NotImplementedException(); }
      }
   }
}
