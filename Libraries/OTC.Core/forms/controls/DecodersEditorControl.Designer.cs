namespace otc.forms.controls
{
   partial class DecodersEditorControl
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
         this.lvwDecoders = new System.Windows.Forms.ListView();
         this.tbrTools = new System.Windows.Forms.ToolStrip();
         this.btnAdd = new System.Windows.Forms.ToolStripButton();
         this.btnEdit = new System.Windows.Forms.ToolStripButton();
         this.btnDelete = new System.Windows.Forms.ToolStripButton();
         this.tbrTools.SuspendLayout();
         this.SuspendLayout();
         // 
         // lvwDecoders
         // 
         this.lvwDecoders.Dock = System.Windows.Forms.DockStyle.Fill;
         this.lvwDecoders.Location = new System.Drawing.Point(0, 25);
         this.lvwDecoders.Name = "lvwDecoders";
         this.lvwDecoders.Size = new System.Drawing.Size(288, 410);
         this.lvwDecoders.TabIndex = 13;
         this.lvwDecoders.UseCompatibleStateImageBehavior = false;
         this.lvwDecoders.DoubleClick += new System.EventHandler(this.lvwDecoders_DoubleClick);
         // 
         // tbrTools
         // 
         this.tbrTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnEdit,
            this.btnDelete});
         this.tbrTools.Location = new System.Drawing.Point(0, 0);
         this.tbrTools.Name = "tbrTools";
         this.tbrTools.Padding = new System.Windows.Forms.Padding(0);
         this.tbrTools.Size = new System.Drawing.Size(288, 25);
         this.tbrTools.TabIndex = 12;
         this.tbrTools.Text = "toolStrip1";
         // 
         // btnAdd
         // 
         this.btnAdd.Image = global::otc.Properties.Resources.IMG_DECODER_ADD;
         this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.btnAdd.Name = "btnAdd";
         this.btnAdd.Size = new System.Drawing.Size(23, 22);
         this.btnAdd.ToolTipText = "Nueva ruta";
         this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
         // 
         // btnEdit
         // 
         this.btnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.btnEdit.Image = global::otc.Properties.Resources.IMG_DECODER_EDIT;
         this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.btnEdit.Name = "btnEdit";
         this.btnEdit.Size = new System.Drawing.Size(23, 22);
         this.btnEdit.ToolTipText = "Ver/Editar ruta";
         this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
         // 
         // btnDelete
         // 
         this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.btnDelete.Image = global::otc.Properties.Resources.IMG_DECODER_DELETE;
         this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.btnDelete.Name = "btnDelete";
         this.btnDelete.Size = new System.Drawing.Size(23, 22);
         this.btnDelete.ToolTipText = "Eliminar ruta";
         this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
         // 
         // DecodersEditorControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.lvwDecoders);
         this.Controls.Add(this.tbrTools);
         this.Name = "DecodersEditorControl";
         this.Size = new System.Drawing.Size(288, 435);
         this.Load += new System.EventHandler(this.DecodersEditorControl_Load);
         this.tbrTools.ResumeLayout(false);
         this.tbrTools.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.ListView lvwDecoders;
      private System.Windows.Forms.ToolStrip tbrTools;
      private System.Windows.Forms.ToolStripButton btnAdd;
      private System.Windows.Forms.ToolStripButton btnEdit;
      private System.Windows.Forms.ToolStripButton btnDelete;
   }
}
