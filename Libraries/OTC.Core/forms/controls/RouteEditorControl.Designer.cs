namespace otc.forms.controls
{
   partial class RouteEditorControl
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RouteEditorControl));
         this.tbrTools = new System.Windows.Forms.ToolStrip();
         this.btnAdd = new System.Windows.Forms.ToolStripButton();
         this.btnEdit = new System.Windows.Forms.ToolStripButton();
         this.btnDelete = new System.Windows.Forms.ToolStripButton();
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this.btnEditStart = new System.Windows.Forms.ToolStripButton();
         this.btnEditEnd = new System.Windows.Forms.ToolStripButton();
         this.lvwRoutes = new System.Windows.Forms.ListView();
         this.tbrTools.SuspendLayout();
         this.SuspendLayout();
         // 
         // tbrTools
         // 
         this.tbrTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnEdit,
            this.btnDelete,
            this.toolStripSeparator1,
            this.btnEditStart,
            this.btnEditEnd});
         this.tbrTools.Location = new System.Drawing.Point(0, 0);
         this.tbrTools.Name = "tbrTools";
         this.tbrTools.Padding = new System.Windows.Forms.Padding(0);
         this.tbrTools.Size = new System.Drawing.Size(250, 25);
         this.tbrTools.TabIndex = 10;
         this.tbrTools.Text = "toolStrip1";
         // 
         // btnAdd
         // 
         this.btnAdd.Image = global::otc.Properties.Resources.IMG_ROUTE_ADD;
         this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.btnAdd.Name = "btnAdd";
         this.btnAdd.Size = new System.Drawing.Size(23, 22);
         this.btnAdd.ToolTipText = "Nueva ruta";
         this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
         // 
         // btnEdit
         // 
         this.btnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.btnEdit.Image = global::otc.Properties.Resources.IMG_ROUTE_EDIT;
         this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.btnEdit.Name = "btnEdit";
         this.btnEdit.Size = new System.Drawing.Size(23, 22);
         this.btnEdit.ToolTipText = "Ver/Editar ruta";
         this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
         // 
         // btnDelete
         // 
         this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.btnDelete.Image = global::otc.Properties.Resources.IMG_ROUTE_DELETE;
         this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.btnDelete.Name = "btnDelete";
         this.btnDelete.Size = new System.Drawing.Size(23, 22);
         this.btnDelete.ToolTipText = "Eliminar ruta";
         this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
         // 
         // toolStripSeparator1
         // 
         this.toolStripSeparator1.Name = "toolStripSeparator1";
         this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
         // 
         // btnEditStart
         // 
         this.btnEditStart.CheckOnClick = true;
         this.btnEditStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.btnEditStart.Image = ((System.Drawing.Image)(resources.GetObject("btnEditStart.Image")));
         this.btnEditStart.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.btnEditStart.Name = "btnEditStart";
         this.btnEditStart.Size = new System.Drawing.Size(23, 22);
         this.btnEditStart.Text = "Inicia la edición de la ruta";
         this.btnEditStart.ToolTipText = "Iniciar edición de ruta";
         this.btnEditStart.Click += new System.EventHandler(this.btnEditStart_Click);
         // 
         // btnEditEnd
         // 
         this.btnEditEnd.Checked = true;
         this.btnEditEnd.CheckOnClick = true;
         this.btnEditEnd.CheckState = System.Windows.Forms.CheckState.Checked;
         this.btnEditEnd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.btnEditEnd.Image = ((System.Drawing.Image)(resources.GetObject("btnEditEnd.Image")));
         this.btnEditEnd.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.btnEditEnd.Name = "btnEditEnd";
         this.btnEditEnd.Size = new System.Drawing.Size(23, 22);
         this.btnEditEnd.ToolTipText = "Detiene edición de ruta";
         this.btnEditEnd.Click += new System.EventHandler(this.btnEditEnd_Click);
         // 
         // lvwRoutes
         // 
         this.lvwRoutes.Dock = System.Windows.Forms.DockStyle.Fill;
         this.lvwRoutes.Location = new System.Drawing.Point(0, 25);
         this.lvwRoutes.Name = "lvwRoutes";
         this.lvwRoutes.Size = new System.Drawing.Size(250, 377);
         this.lvwRoutes.TabIndex = 11;
         this.lvwRoutes.UseCompatibleStateImageBehavior = false;
         this.lvwRoutes.DoubleClick += new System.EventHandler(this.lvwRoutes_DoubleClick);
         // 
         // RouteEditorControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.lvwRoutes);
         this.Controls.Add(this.tbrTools);
         this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.Name = "RouteEditorControl";
         this.Size = new System.Drawing.Size(250, 402);
         this.Load += new System.EventHandler(this.RouteEditorControl_Load);
         this.tbrTools.ResumeLayout(false);
         this.tbrTools.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.ToolStrip tbrTools;
      private System.Windows.Forms.ToolStripButton btnAdd;
      private System.Windows.Forms.ToolStripButton btnEdit;
      private System.Windows.Forms.ToolStripButton btnDelete;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripButton btnEditStart;
      private System.Windows.Forms.ToolStripButton btnEditEnd;
      private System.Windows.Forms.ListView lvwRoutes;
   }
}
