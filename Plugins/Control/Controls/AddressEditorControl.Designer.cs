namespace Rwm.Studio.Plugins.Control.Controls
{
   partial class AddressEditorControl
   {
      /// <summary> 
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary> 
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.components = new System.ComponentModel.Container();
         DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
         DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
         DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
         DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
         DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
         this.txtAddress = new DevExpress.XtraEditors.SpinEdit();
         this.toolTipController = new DevExpress.Utils.ToolTipController(this.components);
         ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).BeginInit();
         this.SuspendLayout();
         // 
         // txtAddress
         // 
         this.txtAddress.Dock = System.Windows.Forms.DockStyle.Top;
         this.txtAddress.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
         this.txtAddress.Location = new System.Drawing.Point(0, 0);
         this.txtAddress.Name = "txtAddress";
         this.txtAddress.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_FIND_16, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Find next free", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_CHECK_16, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "Check address", null, null, true)});
         this.txtAddress.Size = new System.Drawing.Size(109, 22);
         toolTipTitleItem1.Appearance.Image = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_ERROR_16;
         toolTipTitleItem1.Appearance.Options.UseImage = true;
         toolTipTitleItem1.Image = global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_ERROR_16;
         toolTipTitleItem1.Text = "TITLE";
         toolTipItem1.LeftIndent = 6;
         toolTipItem1.Text = "CONTENTS";
         superToolTip1.Items.Add(toolTipTitleItem1);
         superToolTip1.Items.Add(toolTipItem1);
         this.txtAddress.SuperTip = superToolTip1;
         this.txtAddress.TabIndex = 0;
         this.txtAddress.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtAddress_ButtonClick);
         // 
         // AddressEditorControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.txtAddress);
         this.Name = "AddressEditorControl";
         this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
         this.Size = new System.Drawing.Size(109, 20);
         ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private DevExpress.XtraEditors.SpinEdit txtAddress;
      private DevExpress.Utils.ToolTipController toolTipController;
   }
}
