namespace otc.forms.controls
{
    partial class ctlEditSignalStatus3S
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlEditSignalStatus3S));
            this.imgCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.lstStates = new DevExpress.XtraEditors.ImageListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.imgCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstStates)).BeginInit();
            this.SuspendLayout();
            // 
            // imgCollection
            // 
            this.imgCollection.ImageSize = new System.Drawing.Size(54, 33);
            this.imgCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgCollection.ImageStream")));
            // 
            // lstStates
            // 
            this.lstStates.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lstStates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstStates.ImageList = this.imgCollection;
            this.lstStates.ItemHeight = 40;
            this.lstStates.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageListBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageListBoxItem("Verde", 0),
            new DevExpress.XtraEditors.Controls.ImageListBoxItem("Amarillo", 2),
            new DevExpress.XtraEditors.Controls.ImageListBoxItem("Rojo", 2),
            new DevExpress.XtraEditors.Controls.ImageListBoxItem("Sin definir", 1)});
            this.lstStates.Location = new System.Drawing.Point(5, 5);
            this.lstStates.Name = "lstStates";
            this.lstStates.Padding = new System.Windows.Forms.Padding(5);
            this.lstStates.ShowToolTips = false;
            this.lstStates.Size = new System.Drawing.Size(158, 168);
            this.lstStates.TabIndex = 1;
            this.lstStates.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstStates_MouseClick);
            // 
            // ctlEditSignalStatus3S
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.Controls.Add(this.lstStates);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ctlEditSignalStatus3S";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(168, 178);
            ((System.ComponentModel.ISupportInitialize)(this.imgCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstStates)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.ImageCollection imgCollection;
        private DevExpress.XtraEditors.ImageListBoxControl lstStates;

    }
}
