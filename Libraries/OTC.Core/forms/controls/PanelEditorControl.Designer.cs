namespace otc.forms.controls
{
   partial class PanelEditorControl
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
         Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
         this.tabSchemas = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
         this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
         ((System.ComponentModel.ISupportInitialize)(this.tabSchemas)).BeginInit();
         this.tabSchemas.SuspendLayout();
         this.SuspendLayout();
         // 
         // tabSchemas
         // 
         appearance1.BorderColor = System.Drawing.Color.Transparent;
         appearance1.BorderColor2 = System.Drawing.Color.Transparent;
         this.tabSchemas.Appearance = appearance1;
         this.tabSchemas.Controls.Add(this.ultraTabSharedControlsPage1);
         this.tabSchemas.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tabSchemas.Location = new System.Drawing.Point(0, 0);
         this.tabSchemas.Name = "tabSchemas";
         this.tabSchemas.SharedControlsPage = this.ultraTabSharedControlsPage1;
         this.tabSchemas.Size = new System.Drawing.Size(412, 282);
         this.tabSchemas.TabIndex = 1;
         this.tabSchemas.TabPadding = new System.Drawing.Size(3, 2);
         this.tabSchemas.TabPageMargins.Bottom = 2;
         this.tabSchemas.TabPageMargins.Left = 2;
         this.tabSchemas.TabPageMargins.Right = 2;
         this.tabSchemas.TabPageMargins.Top = 2;
         this.tabSchemas.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007;
         this.tabSchemas.SelectedTabChanged += new Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventHandler(this.tabSchemas_SelectedTabChanged);
         // 
         // ultraTabSharedControlsPage1
         // 
         this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(3, 22);
         this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
         this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(406, 257);
         // 
         // ControlPanelEditor
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.tabSchemas);
         this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.Name = "ControlPanelEditor";
         this.Size = new System.Drawing.Size(412, 282);
         ((System.ComponentModel.ISupportInitialize)(this.tabSchemas)).EndInit();
         this.tabSchemas.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private Infragistics.Win.UltraWinTabControl.UltraTabControl tabSchemas;
      private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;


   }
}
