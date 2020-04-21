namespace Rwm.Studio.Plugins.Designer.Controls
{
   partial class InputEditorControl
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputEditorControl));
         DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
         DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
         this.imageList = new System.Windows.Forms.ImageList(this.components);
         this.grpConnection = new DevExpress.XtraEditors.GroupControl();
         this.txtInput = new DevExpress.XtraEditors.ButtonEdit();
         this.lblInput = new DevExpress.XtraEditors.LabelControl();
         this.pnlSeparator = new DevExpress.XtraEditors.PanelControl();
         ((System.ComponentModel.ISupportInitialize)(this.grpConnection)).BeginInit();
         this.grpConnection.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtInput.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.pnlSeparator)).BeginInit();
         this.SuspendLayout();
         // 
         // imageList
         // 
         this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
         this.imageList.TransparentColor = System.Drawing.Color.Transparent;
         this.imageList.Images.SetKeyName(0, "ICO_CONNECTION_CON");
         this.imageList.Images.SetKeyName(1, "ICO_CONNECTION_DIS");
         this.imageList.Images.SetKeyName(2, "ICO_ACC");
         this.imageList.Images.SetKeyName(3, "ICO_SENSOR");
         // 
         // grpConnection
         // 
         this.grpConnection.Controls.Add(this.txtInput);
         this.grpConnection.Controls.Add(this.lblInput);
         this.grpConnection.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grpConnection.Location = new System.Drawing.Point(0, 0);
         this.grpConnection.Name = "grpConnection";
         this.grpConnection.Padding = new System.Windows.Forms.Padding(10);
         this.grpConnection.Size = new System.Drawing.Size(403, 70);
         this.grpConnection.TabIndex = 5;
         this.grpConnection.Text = "Connection 1";
         // 
         // txtInput
         // 
         this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtInput.Location = new System.Drawing.Point(105, 33);
         this.txtInput.Name = "txtInput";
         this.txtInput.Properties.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.True;
         this.txtInput.Properties.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold;
         this.txtInput.Properties.Appearance.Options.UseFont = true;
         this.txtInput.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Properties.Resources.ICO_CONNECTION_16, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Connect to output", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Properties.Resources.ICO_CONNECTION_OFF_16, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "Disconnect", null, null, true)});
         this.txtInput.Properties.ReadOnly = true;
         this.txtInput.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
         this.txtInput.Size = new System.Drawing.Size(283, 22);
         this.txtInput.TabIndex = 1;
         this.txtInput.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtInput_ButtonClick);
         // 
         // lblInput
         // 
         this.lblInput.Location = new System.Drawing.Point(15, 36);
         this.lblInput.Name = "lblInput";
         this.lblInput.Size = new System.Drawing.Size(61, 13);
         this.lblInput.TabIndex = 0;
         this.lblInput.Text = "Module input";
         // 
         // pnlSeparator
         // 
         this.pnlSeparator.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
         this.pnlSeparator.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.pnlSeparator.Location = new System.Drawing.Point(0, 70);
         this.pnlSeparator.Name = "pnlSeparator";
         this.pnlSeparator.Size = new System.Drawing.Size(403, 10);
         this.pnlSeparator.TabIndex = 6;
         // 
         // OutputEditorControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.grpConnection);
         this.Controls.Add(this.pnlSeparator);
         this.Name = "OutputEditorControl";
         this.Size = new System.Drawing.Size(403, 80);
         this.Resize += new System.EventHandler(this.BlockConnectionEditorControl_Resize);
         ((System.ComponentModel.ISupportInitialize)(this.grpConnection)).EndInit();
         this.grpConnection.ResumeLayout(false);
         this.grpConnection.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtInput.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.pnlSeparator)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private DevExpress.XtraEditors.GroupControl grpConnection;
      private DevExpress.XtraEditors.PanelControl pnlSeparator;
      private System.Windows.Forms.ImageList imageList;
      private DevExpress.XtraEditors.ButtonEdit txtInput;
      private DevExpress.XtraEditors.LabelControl lblInput;
   }
}
