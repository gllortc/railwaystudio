namespace otc.forms.controls
{
   partial class OutputConsoleControl
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
         this.tbrOutput = new System.Windows.Forms.ToolStrip();
         this.btnSave = new System.Windows.Forms.ToolStripButton();
         this.btnCopy = new System.Windows.Forms.ToolStripButton();
         this.btnClear = new System.Windows.Forms.ToolStripButton();
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this.btnShowInfo = new System.Windows.Forms.ToolStripButton();
         this.btnShowWarn = new System.Windows.Forms.ToolStripButton();
         this.btnShowErr = new System.Windows.Forms.ToolStripButton();
         this.rtfOutput = new System.Windows.Forms.RichTextBox();
         this.tbrOutput.SuspendLayout();
         this.SuspendLayout();
         // 
         // tbrOutput
         // 
         this.tbrOutput.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.btnCopy,
            this.btnClear,
            this.toolStripSeparator1,
            this.btnShowInfo,
            this.btnShowWarn,
            this.btnShowErr});
         this.tbrOutput.Location = new System.Drawing.Point(0, 0);
         this.tbrOutput.Name = "tbrOutput";
         this.tbrOutput.Size = new System.Drawing.Size(342, 25);
         this.tbrOutput.TabIndex = 0;
         this.tbrOutput.Text = "toolStrip1";
         // 
         // btnSave
         // 
         this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.btnSave.Image = global::otc.Properties.Resources.IMG_FILE_SAVE;
         this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.btnSave.Name = "btnSave";
         this.btnSave.Size = new System.Drawing.Size(23, 22);
         this.btnSave.Text = "Guardar";
         this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
         // 
         // btnCopy
         // 
         this.btnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.btnCopy.Image = global::otc.Properties.Resources.IMG_EDIT_COPY;
         this.btnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.btnCopy.Name = "btnCopy";
         this.btnCopy.Size = new System.Drawing.Size(23, 22);
         this.btnCopy.Text = "Copiar";
         this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
         // 
         // btnClear
         // 
         this.btnClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.btnClear.Image = global::otc.Properties.Resources.IMG_EDIT_CLEAR;
         this.btnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.btnClear.Name = "btnClear";
         this.btnClear.Size = new System.Drawing.Size(23, 22);
         this.btnClear.Text = "Limpiar";
         this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
         // 
         // toolStripSeparator1
         // 
         this.toolStripSeparator1.Name = "toolStripSeparator1";
         this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
         // 
         // btnShowInfo
         // 
         this.btnShowInfo.Checked = true;
         this.btnShowInfo.CheckOnClick = true;
         this.btnShowInfo.CheckState = System.Windows.Forms.CheckState.Checked;
         this.btnShowInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.btnShowInfo.Image = global::otc.Properties.Resources.IMG_LOG_INFO;
         this.btnShowInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.btnShowInfo.Name = "btnShowInfo";
         this.btnShowInfo.Size = new System.Drawing.Size(23, 22);
         this.btnShowInfo.ToolTipText = "Mostrar mensajes informativos";
         this.btnShowInfo.CheckedChanged += new System.EventHandler(this.btnShowInfo_CheckedChanged);
         // 
         // btnShowWarn
         // 
         this.btnShowWarn.Checked = true;
         this.btnShowWarn.CheckOnClick = true;
         this.btnShowWarn.CheckState = System.Windows.Forms.CheckState.Checked;
         this.btnShowWarn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.btnShowWarn.Image = global::otc.Properties.Resources.IMG_LOG_WARN;
         this.btnShowWarn.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.btnShowWarn.Name = "btnShowWarn";
         this.btnShowWarn.Size = new System.Drawing.Size(23, 22);
         this.btnShowWarn.ToolTipText = "Mostrar mensajes de adverténcia";
         this.btnShowWarn.CheckedChanged += new System.EventHandler(this.btnShowWarn_CheckedChanged);
         // 
         // btnShowErr
         // 
         this.btnShowErr.Checked = true;
         this.btnShowErr.CheckOnClick = true;
         this.btnShowErr.CheckState = System.Windows.Forms.CheckState.Checked;
         this.btnShowErr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.btnShowErr.Image = global::otc.Properties.Resources.IMG_LOG_ERR;
         this.btnShowErr.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.btnShowErr.Name = "btnShowErr";
         this.btnShowErr.Size = new System.Drawing.Size(23, 22);
         this.btnShowErr.ToolTipText = "Mostrar mensajes de error";
         this.btnShowErr.CheckedChanged += new System.EventHandler(this.btnShowErr_CheckedChanged);
         // 
         // rtfOutput
         // 
         this.rtfOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this.rtfOutput.Dock = System.Windows.Forms.DockStyle.Fill;
         this.rtfOutput.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.rtfOutput.Location = new System.Drawing.Point(0, 25);
         this.rtfOutput.Name = "rtfOutput";
         this.rtfOutput.ReadOnly = true;
         this.rtfOutput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
         this.rtfOutput.Size = new System.Drawing.Size(342, 180);
         this.rtfOutput.TabIndex = 1;
         this.rtfOutput.Text = "";
         this.rtfOutput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtfOutput_KeyDown);
         // 
         // OutputControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.rtfOutput);
         this.Controls.Add(this.tbrOutput);
         this.Name = "OutputControl";
         this.Size = new System.Drawing.Size(342, 205);
         this.tbrOutput.ResumeLayout(false);
         this.tbrOutput.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.ToolStrip tbrOutput;
      private System.Windows.Forms.ToolStripButton btnSave;
      private System.Windows.Forms.ToolStripButton btnCopy;
      private System.Windows.Forms.ToolStripButton btnClear;
      private System.Windows.Forms.RichTextBox rtfOutput;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripButton btnShowInfo;
      private System.Windows.Forms.ToolStripButton btnShowWarn;
      private System.Windows.Forms.ToolStripButton btnShowErr;
   }
}
