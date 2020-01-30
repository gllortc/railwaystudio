namespace otc
{
    partial class ctlEditConection2S
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
           this.components = new System.ComponentModel.Container();
           System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlEditConection2S));
           this.imlIcons = new System.Windows.Forms.ImageList(this.components);
           this.label1 = new System.Windows.Forms.Label();
           this.lstOptions = new otc.forms.controls.ImageListBox();
           this.SuspendLayout();
           // 
           // imlIcons
           // 
           this.imlIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlIcons.ImageStream")));
           this.imlIcons.TransparentColor = System.Drawing.Color.Transparent;
           this.imlIcons.Images.SetKeyName(0, "signal_2s_connection1.png");
           this.imlIcons.Images.SetKeyName(1, "signal_2s_connection2.png");
           // 
           // label1
           // 
           this.label1.Location = new System.Drawing.Point(2, 5);
           this.label1.Name = "label1";
           this.label1.Size = new System.Drawing.Size(132, 30);
           this.label1.TabIndex = 1;
           this.label1.Text = "Conexión a la salida del decoder de accesorios:";
           // 
           // lstOptions
           // 
           this.lstOptions.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
           this.lstOptions.FormattingEnabled = true;
           this.lstOptions.Location = new System.Drawing.Point(8, 38);
           this.lstOptions.Name = "lstOptions";
           this.lstOptions.Size = new System.Drawing.Size(123, 95);
           this.lstOptions.TabIndex = 2;
           // 
           // ctlEditConection2S
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.Controls.Add(this.lstOptions);
           this.Controls.Add(this.label1);
           this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           this.Name = "ctlEditConection2S";
           this.Padding = new System.Windows.Forms.Padding(5);
           this.Size = new System.Drawing.Size(139, 142);
           this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imlIcons;
        private System.Windows.Forms.Label label1;
        private otc.forms.controls.ImageListBox lstOptions;

    }
}
