namespace Rwm.Studio.Plugins.Designer.Views
{
   partial class AccessoryDecoderWizardView
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

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccessoryDecoderWizardView));
         this.imageList = new System.Windows.Forms.ImageList(this.components);
         this.wizardControl = new DevExpress.XtraWizard.WizardControl();
         this.wzpOutputs = new DevExpress.XtraWizard.WelcomeWizardPage();
         this.spnOutputs = new DevExpress.XtraEditors.SpinEdit();
         this.rdgOutputs = new DevExpress.XtraEditors.RadioGroup();
         this.lblIntro = new DevExpress.XtraEditors.LabelControl();
         this.wzpAddress = new DevExpress.XtraWizard.WizardPage();
         this.spnAddress = new DevExpress.XtraEditors.SpinEdit();
         this.rdgAddress = new DevExpress.XtraEditors.RadioGroup();
         this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
         this.wzpEnd = new DevExpress.XtraWizard.CompletionWizardPage();
         this.lblSummary = new DevExpress.XtraEditors.LabelControl();
         this.wzpMode = new DevExpress.XtraWizard.WizardPage();
         this.lblModeServo = new DevExpress.XtraEditors.LabelControl();
         this.lblModeFlasher = new DevExpress.XtraEditors.LabelControl();
         this.lblModeShot = new DevExpress.XtraEditors.LabelControl();
         this.lblModeContinuous = new DevExpress.XtraEditors.LabelControl();
         this.rdoModeServo = new DevExpress.XtraEditors.CheckEdit();
         this.rdoModeFlasher = new DevExpress.XtraEditors.CheckEdit();
         this.rdoModeOneShot = new DevExpress.XtraEditors.CheckEdit();
         this.rdoModeContinuous = new DevExpress.XtraEditors.CheckEdit();
         ((System.ComponentModel.ISupportInitialize)(this.wizardControl)).BeginInit();
         this.wizardControl.SuspendLayout();
         this.wzpOutputs.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.spnOutputs.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.rdgOutputs.Properties)).BeginInit();
         this.wzpAddress.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.spnAddress.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.rdgAddress.Properties)).BeginInit();
         this.wzpEnd.SuspendLayout();
         this.wzpMode.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.rdoModeServo.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.rdoModeFlasher.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.rdoModeOneShot.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.rdoModeContinuous.Properties)).BeginInit();
         this.SuspendLayout();
         // 
         // imageList
         // 
         this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
         this.imageList.TransparentColor = System.Drawing.Color.Transparent;
         this.imageList.Images.SetKeyName(0, "ICO_OUTPUT");
         this.imageList.Images.SetKeyName(1, "ICO_MANUFACTURER");
         this.imageList.Images.SetKeyName(2, "ICO_MODEL");
         // 
         // wizardControl
         // 
         this.wizardControl.CancelText = "Cancel";
         this.wizardControl.Controls.Add(this.wzpOutputs);
         this.wizardControl.Controls.Add(this.wzpAddress);
         this.wizardControl.Controls.Add(this.wzpEnd);
         this.wizardControl.Controls.Add(this.wzpMode);
         this.wizardControl.Dock = System.Windows.Forms.DockStyle.Fill;
         this.wizardControl.FinishText = "Finish";
         this.wizardControl.Image = global::Rwm.Studio.Plugins.Designer.Properties.Resources._1__16_2;
         this.wizardControl.ImageLayout = System.Windows.Forms.ImageLayout.Center;
         this.wizardControl.Location = new System.Drawing.Point(0, 0);
         this.wizardControl.Name = "wizardControl";
         this.wizardControl.NextText = "&Next >";
         this.wizardControl.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[] {
            this.wzpOutputs,
            this.wzpAddress,
            this.wzpMode,
            this.wzpEnd});
         this.wizardControl.PreviousText = "< &Previous";
         this.wizardControl.Size = new System.Drawing.Size(514, 347);
         this.wizardControl.Text = "New accessory decoder wizard";
         this.wizardControl.WizardStyle = DevExpress.XtraWizard.WizardStyle.WizardAero;
         this.wizardControl.CancelClick += new System.ComponentModel.CancelEventHandler(this.WizardControl_CancelClick);
         this.wizardControl.FinishClick += new System.ComponentModel.CancelEventHandler(this.WizardControl_FinishClick);
         this.wizardControl.NextClick += new DevExpress.XtraWizard.WizardCommandButtonClickEventHandler(this.WizardControl_NextClick);
         // 
         // wzpOutputs
         // 
         this.wzpOutputs.AllowFinish = false;
         this.wzpOutputs.Controls.Add(this.spnOutputs);
         this.wzpOutputs.Controls.Add(this.rdgOutputs);
         this.wzpOutputs.Controls.Add(this.lblIntro);
         this.wzpOutputs.IntroductionText = "Specify the number of decoder outputs :";
         this.wzpOutputs.Name = "wzpOutputs";
         this.wzpOutputs.ProceedText = "";
         this.wzpOutputs.Size = new System.Drawing.Size(454, 179);
         this.wzpOutputs.Text = "Decoder outputs setup";
         // 
         // spnOutputs
         // 
         this.spnOutputs.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
         this.spnOutputs.Location = new System.Drawing.Point(98, 101);
         this.spnOutputs.Name = "spnOutputs";
         this.spnOutputs.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.spnOutputs.Size = new System.Drawing.Size(58, 20);
         this.spnOutputs.TabIndex = 2;
         this.spnOutputs.EditValueChanged += new System.EventHandler(this.SpnOutputs_EditValueChanged);
         // 
         // rdgOutputs
         // 
         this.rdgOutputs.Dock = System.Windows.Forms.DockStyle.Top;
         this.rdgOutputs.EditValue = ((short)(4));
         this.rdgOutputs.Location = new System.Drawing.Point(0, 13);
         this.rdgOutputs.Name = "rdgOutputs";
         this.rdgOutputs.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
         this.rdgOutputs.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(4)), "4 outputs"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(6)), "6 outputs"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(8)), "8 outputs"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(0)), "Other number")});
         this.rdgOutputs.Size = new System.Drawing.Size(454, 116);
         this.rdgOutputs.TabIndex = 1;
         // 
         // lblIntro
         // 
         this.lblIntro.Dock = System.Windows.Forms.DockStyle.Top;
         this.lblIntro.Location = new System.Drawing.Point(0, 0);
         this.lblIntro.Name = "lblIntro";
         this.lblIntro.Size = new System.Drawing.Size(192, 13);
         this.lblIntro.TabIndex = 3;
         this.lblIntro.Text = "Specify the number of decoder outputs:";
         // 
         // wzpAddress
         // 
         this.wzpAddress.Controls.Add(this.spnAddress);
         this.wzpAddress.Controls.Add(this.rdgAddress);
         this.wzpAddress.Controls.Add(this.labelControl1);
         this.wzpAddress.DescriptionText = "";
         this.wzpAddress.Name = "wzpAddress";
         this.wzpAddress.Size = new System.Drawing.Size(454, 179);
         this.wzpAddress.Text = "Digital address assignment";
         // 
         // spnAddress
         // 
         this.spnAddress.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
         this.spnAddress.Location = new System.Drawing.Point(155, 48);
         this.spnAddress.Name = "spnAddress";
         this.spnAddress.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.spnAddress.Properties.DisplayFormat.FormatString = "0000";
         this.spnAddress.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
         this.spnAddress.Properties.Mask.EditMask = "0000";
         this.spnAddress.Size = new System.Drawing.Size(75, 20);
         this.spnAddress.TabIndex = 2;
         // 
         // rdgAddress
         // 
         this.rdgAddress.Dock = System.Windows.Forms.DockStyle.Top;
         this.rdgAddress.EditValue = ((short)(0));
         this.rdgAddress.Location = new System.Drawing.Point(0, 13);
         this.rdgAddress.Name = "rdgAddress";
         this.rdgAddress.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
         this.rdgAddress.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(0)), "Don\'t assign addresses"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(1)), "Assign consecutively from")});
         this.rdgAddress.Size = new System.Drawing.Size(454, 63);
         this.rdgAddress.TabIndex = 1;
         this.rdgAddress.EditValueChanged += new System.EventHandler(this.RdgAddress_EditValueChanged);
         // 
         // labelControl1
         // 
         this.labelControl1.Dock = System.Windows.Forms.DockStyle.Top;
         this.labelControl1.Location = new System.Drawing.Point(0, 0);
         this.labelControl1.Name = "labelControl1";
         this.labelControl1.Size = new System.Drawing.Size(188, 13);
         this.labelControl1.TabIndex = 7;
         this.labelControl1.Text = "Select the desired address assignment:";
         // 
         // wzpEnd
         // 
         this.wzpEnd.Controls.Add(this.lblSummary);
         this.wzpEnd.Name = "wzpEnd";
         this.wzpEnd.Size = new System.Drawing.Size(454, 179);
         this.wzpEnd.Text = "Finishing up";
         // 
         // lblSummary
         // 
         this.lblSummary.AllowHtmlString = true;
         this.lblSummary.Appearance.Options.UseTextOptions = true;
         this.lblSummary.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
         this.lblSummary.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
         this.lblSummary.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
         this.lblSummary.Dock = System.Windows.Forms.DockStyle.Fill;
         this.lblSummary.Location = new System.Drawing.Point(0, 0);
         this.lblSummary.Name = "lblSummary";
         this.lblSummary.Size = new System.Drawing.Size(454, 179);
         this.lblSummary.TabIndex = 0;
         this.lblSummary.Text = "Decoder summary:\r\nKKK";
         // 
         // wzpMode
         // 
         this.wzpMode.Controls.Add(this.lblModeServo);
         this.wzpMode.Controls.Add(this.lblModeFlasher);
         this.wzpMode.Controls.Add(this.lblModeShot);
         this.wzpMode.Controls.Add(this.lblModeContinuous);
         this.wzpMode.Controls.Add(this.rdoModeServo);
         this.wzpMode.Controls.Add(this.rdoModeFlasher);
         this.wzpMode.Controls.Add(this.rdoModeOneShot);
         this.wzpMode.Controls.Add(this.rdoModeContinuous);
         this.wzpMode.Name = "wzpMode";
         this.wzpMode.Size = new System.Drawing.Size(454, 179);
         this.wzpMode.Text = "Default ouputs working mode setup";
         // 
         // lblModeServo
         // 
         this.lblModeServo.Location = new System.Drawing.Point(22, 144);
         this.lblModeServo.Name = "lblModeServo";
         this.lblModeServo.Size = new System.Drawing.Size(190, 13);
         this.lblModeServo.TabIndex = 7;
         this.lblModeServo.Text = "The active output interact with a servo ";
         // 
         // lblModeFlasher
         // 
         this.lblModeFlasher.Location = new System.Drawing.Point(22, 104);
         this.lblModeFlasher.Name = "lblModeFlasher";
         this.lblModeFlasher.Size = new System.Drawing.Size(325, 13);
         this.lblModeFlasher.TabIndex = 6;
         this.lblModeFlasher.Text = "The active output alternate high and low for a programmable period";
         // 
         // lblModeShot
         // 
         this.lblModeShot.Location = new System.Drawing.Point(22, 63);
         this.lblModeShot.Name = "lblModeShot";
         this.lblModeShot.Size = new System.Drawing.Size(296, 13);
         this.lblModeShot.TabIndex = 5;
         this.lblModeShot.Text = "The active output remains high during the specified time lapse";
         // 
         // lblModeContinuous
         // 
         this.lblModeContinuous.Location = new System.Drawing.Point(22, 22);
         this.lblModeContinuous.Name = "lblModeContinuous";
         this.lblModeContinuous.Size = new System.Drawing.Size(203, 13);
         this.lblModeContinuous.TabIndex = 4;
         this.lblModeContinuous.Text = "The active output remains high all the time";
         // 
         // rdoModeServo
         // 
         this.rdoModeServo.Location = new System.Drawing.Point(3, 126);
         this.rdoModeServo.Name = "rdoModeServo";
         this.rdoModeServo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
         this.rdoModeServo.Properties.Appearance.Options.UseFont = true;
         this.rdoModeServo.Properties.Caption = "Servo";
         this.rdoModeServo.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
         this.rdoModeServo.Properties.RadioGroupIndex = 1;
         this.rdoModeServo.Size = new System.Drawing.Size(75, 19);
         this.rdoModeServo.TabIndex = 3;
         this.rdoModeServo.TabStop = false;
         // 
         // rdoModeFlasher
         // 
         this.rdoModeFlasher.Location = new System.Drawing.Point(3, 85);
         this.rdoModeFlasher.Name = "rdoModeFlasher";
         this.rdoModeFlasher.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
         this.rdoModeFlasher.Properties.Appearance.Options.UseFont = true;
         this.rdoModeFlasher.Properties.Caption = "Flasher";
         this.rdoModeFlasher.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
         this.rdoModeFlasher.Properties.RadioGroupIndex = 1;
         this.rdoModeFlasher.Size = new System.Drawing.Size(75, 19);
         this.rdoModeFlasher.TabIndex = 2;
         this.rdoModeFlasher.TabStop = false;
         // 
         // rdoModeOneShot
         // 
         this.rdoModeOneShot.EditValue = true;
         this.rdoModeOneShot.Location = new System.Drawing.Point(3, 44);
         this.rdoModeOneShot.Name = "rdoModeOneShot";
         this.rdoModeOneShot.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
         this.rdoModeOneShot.Properties.Appearance.Options.UseFont = true;
         this.rdoModeOneShot.Properties.Caption = "Shot";
         this.rdoModeOneShot.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
         this.rdoModeOneShot.Properties.RadioGroupIndex = 1;
         this.rdoModeOneShot.Size = new System.Drawing.Size(75, 19);
         this.rdoModeOneShot.TabIndex = 1;
         // 
         // rdoModeContinuous
         // 
         this.rdoModeContinuous.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.rdoModeContinuous.Location = new System.Drawing.Point(3, 3);
         this.rdoModeContinuous.Name = "rdoModeContinuous";
         this.rdoModeContinuous.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
         this.rdoModeContinuous.Properties.Appearance.Options.UseFont = true;
         this.rdoModeContinuous.Properties.Caption = "Continuous";
         this.rdoModeContinuous.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
         this.rdoModeContinuous.Properties.RadioGroupIndex = 1;
         this.rdoModeContinuous.Size = new System.Drawing.Size(448, 19);
         this.rdoModeContinuous.TabIndex = 0;
         this.rdoModeContinuous.TabStop = false;
         // 
         // AccessoryDecoderWizardView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(514, 347);
         this.Controls.Add(this.wizardControl);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "AccessoryDecoderWizardView";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "New accessory decoder";
         ((System.ComponentModel.ISupportInitialize)(this.wizardControl)).EndInit();
         this.wizardControl.ResumeLayout(false);
         this.wzpOutputs.ResumeLayout(false);
         this.wzpOutputs.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.spnOutputs.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.rdgOutputs.Properties)).EndInit();
         this.wzpAddress.ResumeLayout(false);
         this.wzpAddress.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.spnAddress.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.rdgAddress.Properties)).EndInit();
         this.wzpEnd.ResumeLayout(false);
         this.wzpMode.ResumeLayout(false);
         this.wzpMode.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.rdoModeServo.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.rdoModeFlasher.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.rdoModeOneShot.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.rdoModeContinuous.Properties)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion
      private System.Windows.Forms.ImageList imageList;
        private DevExpress.XtraWizard.WizardControl wizardControl;
        private DevExpress.XtraWizard.WelcomeWizardPage wzpOutputs;
        private DevExpress.XtraEditors.SpinEdit spnOutputs;
        private DevExpress.XtraEditors.RadioGroup rdgOutputs;
        private DevExpress.XtraWizard.WizardPage wzpAddress;
        private DevExpress.XtraEditors.SpinEdit spnAddress;
        private DevExpress.XtraEditors.RadioGroup rdgAddress;
        private DevExpress.XtraWizard.CompletionWizardPage wzpEnd;
        private DevExpress.XtraWizard.WizardPage wzpMode;
        private DevExpress.XtraEditors.LabelControl lblIntro;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckEdit rdoModeOneShot;
        private DevExpress.XtraEditors.CheckEdit rdoModeContinuous;
        private DevExpress.XtraEditors.LabelControl lblModeContinuous;
        private DevExpress.XtraEditors.CheckEdit rdoModeServo;
        private DevExpress.XtraEditors.CheckEdit rdoModeFlasher;
        private DevExpress.XtraEditors.LabelControl lblModeShot;
        private DevExpress.XtraEditors.LabelControl lblModeServo;
        private DevExpress.XtraEditors.LabelControl lblModeFlasher;
        private DevExpress.XtraEditors.LabelControl lblSummary;
    }
}