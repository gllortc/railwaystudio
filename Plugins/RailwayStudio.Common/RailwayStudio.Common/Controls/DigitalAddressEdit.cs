using System;
using System.ComponentModel;
using DevExpress.XtraEditors;
using Rwm.Otc;

namespace Rwm.Studio.Plugins.Common.Controls
{
   public partial class DigitalAddressEdit : SpinEdit
   {
      public DigitalAddressEdit()
      {
         InitializeComponent();
         Initialize();
      }

      public DigitalAddressEdit(IContainer container)
      {
         container.Add(this);

         InitializeComponent();
         Initialize();
      }

      //protected override void OnValidated(EventArgs e)
      //{
      //   base.OnValidated(e);

      //   this.Properties.Increment = 1;
      //   this.Properties.MinValue = 0; ; // OTCContext.Project.DigitalSystem.AccessoryAddressRange.Minimum;
      //   this.Properties.MaxValue = OTCContext.Project.DigitalSystem.AccessoryAddressRange.Maximum;

      //   this.Properties.Buttons.Clear();
      //   this.Properties.Buttons.Add(new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph,
      //                                                                                Common.Properties.Resources.ICO_FIND_16,
      //                                                                                null));
      //} 

      protected override void OnCreateControl()
      {
         base.OnCreateControl();

         this.Properties.Increment = 1;
         this.Properties.MinValue = 0; ; // OTCContext.Project.DigitalSystem.AccessoryAddressRange.Minimum;
         this.Properties.MaxValue = OTCContext.Project.DigitalSystem.AccessoryAddressRange.Maximum;

         this.Properties.Buttons.Clear();
         this.Properties.Buttons.Add(new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph,
                                                                                      Common.Properties.Resources.ICO_FIND_16,
                                                                                      null));
      }

      private void Initialize()
      {
         
      }
   }
}
