namespace Rwm.Studio.Plugins.Collection.Reports
{
   partial class DigitalReport
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

      #region Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DigitalReport));
         this.Detail = new DevExpress.XtraReports.UI.DetailBand();
         this.lblDecoderManufacturer = new DevExpress.XtraReports.UI.XRLabel();
         this.lblTrainManufacturer = new DevExpress.XtraReports.UI.XRLabel();
         this.lblDecoderAddress = new DevExpress.XtraReports.UI.XRLabel();
         this.lblDecoderModel = new DevExpress.XtraReports.UI.XRLabel();
         this.lblTrainName = new DevExpress.XtraReports.UI.XRLabel();
         this.lblTitle = new DevExpress.XtraReports.UI.XRLabel();
         this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
         this.lblProjectName = new DevExpress.XtraReports.UI.XRLabel();
         this.imgLogo = new DevExpress.XtraReports.UI.XRPictureBox();
         this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
         this.Header = new DevExpress.XtraReports.UI.GroupHeaderBand();
         this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
         this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
         this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
         this.xrControlStyle2 = new DevExpress.XtraReports.UI.XRControlStyle();
         ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
         // 
         // Detail
         // 
         this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lblDecoderManufacturer,
            this.lblTrainManufacturer,
            this.lblDecoderAddress,
            this.lblDecoderModel,
            this.lblTrainName});
         this.Detail.HeightF = 17.75004F;
         this.Detail.Name = "Detail";
         this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
         this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
         // 
         // lblDecoderManufacturer
         // 
         this.lblDecoderManufacturer.LocationFloat = new DevExpress.Utils.PointFloat(445.7791F, 0.9999911F);
         this.lblDecoderManufacturer.Name = "lblDecoderManufacturer";
         this.lblDecoderManufacturer.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
         this.lblDecoderManufacturer.SizeF = new System.Drawing.SizeF(123.2207F, 16.75002F);
         this.lblDecoderManufacturer.Text = "lblDecoderManufacturer";
         // 
         // lblTrainManufacturer
         // 
         this.lblTrainManufacturer.LocationFloat = new DevExpress.Utils.PointFloat(151.0291F, 0.9999911F);
         this.lblTrainManufacturer.Name = "lblTrainManufacturer";
         this.lblTrainManufacturer.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
         this.lblTrainManufacturer.SizeF = new System.Drawing.SizeF(150.0291F, 16.75002F);
         this.lblTrainManufacturer.Text = "lblTrainManufacturer";
         // 
         // lblDecoderAddress
         // 
         this.lblDecoderAddress.LocationFloat = new DevExpress.Utils.PointFloat(569F, 1F);
         this.lblDecoderAddress.Name = "lblDecoderAddress";
         this.lblDecoderAddress.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
         this.lblDecoderAddress.SizeF = new System.Drawing.SizeF(57.29163F, 16.75002F);
         this.lblDecoderAddress.StylePriority.UseTextAlignment = false;
         this.lblDecoderAddress.Text = "lblDecoderOutput";
         this.lblDecoderAddress.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
         // 
         // lblDecoderModel
         // 
         this.lblDecoderModel.LocationFloat = new DevExpress.Utils.PointFloat(301.0582F, 1.000023F);
         this.lblDecoderModel.Name = "lblDecoderModel";
         this.lblDecoderModel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
         this.lblDecoderModel.SizeF = new System.Drawing.SizeF(144.7208F, 16.75002F);
         this.lblDecoderModel.Text = "lblDecoderModel";
         // 
         // lblTrainName
         // 
         this.lblTrainName.LocationFloat = new DevExpress.Utils.PointFloat(0.9999593F, 1.000023F);
         this.lblTrainName.Name = "lblTrainName";
         this.lblTrainName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
         this.lblTrainName.SizeF = new System.Drawing.SizeF(150.0291F, 16.75002F);
         this.lblTrainName.Text = "lblTrainName";
         // 
         // lblTitle
         // 
         this.lblTitle.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
         this.lblTitle.BorderWidth = 2F;
         this.lblTitle.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTitle.LocationFloat = new DevExpress.Utils.PointFloat(0.9999593F, 0F);
         this.lblTitle.Name = "lblTitle";
         this.lblTitle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
         this.lblTitle.SizeF = new System.Drawing.SizeF(627F, 34.45834F);
         this.lblTitle.StylePriority.UseBorders = false;
         this.lblTitle.StylePriority.UseBorderWidth = false;
         this.lblTitle.StylePriority.UseFont = false;
         this.lblTitle.Text = "Train digital addresses";
         // 
         // TopMargin
         // 
         this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lblProjectName,
            this.imgLogo});
         this.TopMargin.HeightF = 101.0417F;
         this.TopMargin.Name = "TopMargin";
         this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
         this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
         // 
         // lblProjectName
         // 
         this.lblProjectName.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right;
         this.lblProjectName.Borders = DevExpress.XtraPrinting.BorderSide.None;
         this.lblProjectName.BorderWidth = 2F;
         this.lblProjectName.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblProjectName.LocationFloat = new DevExpress.Utils.PointFloat(222.9167F, 49.37F);
         this.lblProjectName.Name = "lblProjectName";
         this.lblProjectName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
         this.lblProjectName.SizeF = new System.Drawing.SizeF(404.0833F, 23.96167F);
         this.lblProjectName.StylePriority.UseBorders = false;
         this.lblProjectName.StylePriority.UseBorderWidth = false;
         this.lblProjectName.StylePriority.UseFont = false;
         this.lblProjectName.StylePriority.UseTextAlignment = false;
         this.lblProjectName.Text = "lblProjectName";
         this.lblProjectName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
         // 
         // imgLogo
         // 
         this.imgLogo.Image = ((System.Drawing.Image)(resources.GetObject("imgLogo.Image")));
         this.imgLogo.LocationFloat = new DevExpress.Utils.PointFloat(1F, 49.37F);
         this.imgLogo.Name = "imgLogo";
         this.imgLogo.SizeF = new System.Drawing.SizeF(208.3624F, 23.96168F);
         this.imgLogo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.AutoSize;
         // 
         // BottomMargin
         // 
         this.BottomMargin.HeightF = 100F;
         this.BottomMargin.Name = "BottomMargin";
         this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
         this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
         // 
         // Header
         // 
         this.Header.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel3,
            this.xrLabel5,
            this.xrLabel1,
            this.lblTitle});
         this.Header.HeightF = 74.04169F;
         this.Header.Name = "Header";
         // 
         // xrLabel3
         // 
         this.xrLabel3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(568.9998F, 53F);
         this.xrLabel3.Name = "xrLabel3";
         this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
         this.xrLabel3.SizeF = new System.Drawing.SizeF(57.29175F, 20.20836F);
         this.xrLabel3.StylePriority.UseFont = false;
         this.xrLabel3.StylePriority.UseTextAlignment = false;
         this.xrLabel3.Text = "Address";
         this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
         // 
         // xrLabel5
         // 
         this.xrLabel5.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(301.0582F, 53F);
         this.xrLabel5.Name = "xrLabel5";
         this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
         this.xrLabel5.SizeF = new System.Drawing.SizeF(144.7208F, 20.20836F);
         this.xrLabel5.StylePriority.UseFont = false;
         this.xrLabel5.Text = "Decoder";
         // 
         // xrLabel1
         // 
         this.xrLabel1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0.9999593F, 53F);
         this.xrLabel1.Name = "xrLabel1";
         this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
         this.xrLabel1.SizeF = new System.Drawing.SizeF(150.0291F, 20.20836F);
         this.xrLabel1.StylePriority.UseFont = false;
         this.xrLabel1.Text = "Model";
         // 
         // xrControlStyle2
         // 
         this.xrControlStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
         this.xrControlStyle2.Name = "xrControlStyle2";
         this.xrControlStyle2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
         // 
         // DigitalReport
         // 
         this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.Header});
         this.DisplayName = "Digital Report";
         this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.Margins = new System.Drawing.Printing.Margins(100, 100, 101, 100);
         this.PageHeight = 1169;
         this.PageWidth = 827;
         this.PaperKind = System.Drawing.Printing.PaperKind.A4;
         this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.xrControlStyle2});
         this.Version = "17.1";
         this.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.DigitalReport_BeforePrint);
         ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

      }

      #endregion

      private DevExpress.XtraReports.UI.DetailBand Detail;
      private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
      private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
      private DevExpress.XtraReports.UI.GroupHeaderBand Header;
      private DevExpress.XtraReports.UI.XRLabel lblTitle;
      private DevExpress.XtraReports.UI.XRLabel lblDecoderAddress;
      private DevExpress.XtraReports.UI.XRLabel lblDecoderModel;
      private DevExpress.XtraReports.UI.XRLabel lblTrainName;
      private DevExpress.XtraReports.UI.XRLabel xrLabel1;
      private DevExpress.XtraReports.UI.XRControlStyle xrControlStyle2;
      private DevExpress.XtraReports.UI.XRLabel xrLabel3;
      private DevExpress.XtraReports.UI.XRPictureBox imgLogo;
        private DevExpress.XtraReports.UI.XRLabel lblProjectName;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel lblTrainManufacturer;
        private DevExpress.XtraReports.UI.XRLabel lblDecoderManufacturer;
    }
}
