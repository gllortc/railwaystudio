namespace Rwm.Studio.Plugins.Control.Controls
{
   partial class OutputEditorControl
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OutputEditorControl));
         DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
         DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
         this.imageList = new System.Windows.Forms.ImageList(this.components);
         this.grpConnection = new DevExpress.XtraEditors.GroupControl();
         this.txtOutput = new DevExpress.XtraEditors.ButtonEdit();
         this.lblOutput = new DevExpress.XtraEditors.LabelControl();
         this.pnlSeparator = new DevExpress.XtraEditors.PanelControl();
         ((System.ComponentModel.ISupportInitialize)(this.grpConnection)).BeginInit();
         this.grpConnection.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtOutput.Properties)).BeginInit();
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
         this.grpConnection.Controls.Add(this.txtOutput);
         this.grpConnection.Controls.Add(this.lblOutput);
         this.grpConnection.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grpConnection.Location = new System.Drawing.Point(0, 0);
         this.grpConnection.Name = "grpConnection";
         this.grpConnection.Padding = new System.Windows.Forms.Padding(10);
         this.grpConnection.Size = new System.Drawing.Size(403, 70);
         this.grpConnection.TabIndex = 5;
         this.grpConnection.Text = "Connection 1";
         // 
         // txtOutput
         // 
         this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtOutput.Location = new System.Drawing.Point(105, 33);
         this.txtOutput.Name = "txtOutput";
         this.txtOutput.Properties.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.True;
         this.txtOutput.Properties.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold;
         this.txtOutput.Properties.Appearance.Options.UseFont = true;
         this.txtOutput.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_CONNECT_16, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Connect to output", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::Rwm.Studio.Plugins.Control.Properties.Resources.ICO_DISCONNECT_16, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "Disconnect", null, null, true)});
         this.txtOutput.Properties.ReadOnly = true;
         this.txtOutput.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
         this.txtOutput.Size = new System.Drawing.Size(283, 22);
         this.txtOutput.TabIndex = 1;
         this.txtOutput.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtOutput_ButtonClick);
         // 
         // lblOutput
         // 
         this.lblOutput.Location = new System.Drawing.Point(15, 36);
         this.lblOutput.Name = "lblOutput";
         this.lblOutput.Size = new System.Drawing.Size(69, 13);
         this.lblOutput.TabIndex = 0;
         this.lblOutput.Text = "Module output";
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
         // BlockConnectionEditorControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.grpConnection);
         this.Controls.Add(this.pnlSeparator);
         this.Name = "BlockConnectionEditorControl";
         this.Size = new System.Drawing.Size(403, 80);
         this.Resize += new System.EventHandler(this.BlockConnectionEditorControl_Resize);
         ((System.ComponentModel.ISupportInitialize)(this.grpConnection)).EndInit();
         this.grpConnection.ResumeLayout(false);
         this.grpConnection.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtOutput.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.pnlSeparator)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private DevExpress.XtraEditors.GroupControl grpConnection;
      private DevExpress.XtraEditors.PanelControl pnlSeparator;
      private System.Windows.Forms.ImageList imageList;
      private DevExpress.XtraEditors.ButtonEdit txtOutput;
      private DevExpress.XtraEditors.LabelControl lblOutput;
   }
}
