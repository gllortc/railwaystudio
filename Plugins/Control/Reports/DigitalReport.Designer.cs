namespace Rwm.Studio.Plugins.Control.Reports
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
         this.lblSwitchboardTitle = new DevExpress.XtraReports.UI.XRLabel();
         this.imgSwitchboardImage = new DevExpress.XtraReports.UI.XRPictureBox();
         this.lblSwitchboardId = new DevExpress.XtraReports.UI.XRLabel();
         this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
         this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
         this.SwitchboardHeader = new DevExpress.XtraReports.UI.GroupHeaderBand();
         this.DigitalConnectionsReport = new DevExpress.XtraReports.UI.DetailReportBand();
         this.DigitalConnectionsDetail = new DevExpress.XtraReports.UI.DetailBand();
         this.lblConnectedTo = new DevExpress.XtraReports.UI.XRLabel();
         this.lblDecoderAddress = new DevExpress.XtraReports.UI.XRLabel();
         this.lblDecoderOutput = new DevExpress.XtraReports.UI.XRLabel();
         this.lblDecoderName = new DevExpress.XtraReports.UI.XRLabel();
         this.lblDecoderModel = new DevExpress.XtraReports.UI.XRLabel();
         this.DigitalConnectionsHead = new DevExpress.XtraReports.UI.ReportHeaderBand();
         this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
         this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
         this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
         this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
         this.xrControlStyle2 = new DevExpress.XtraReports.UI.XRControlStyle();
         this.imgLogo = new DevExpress.XtraReports.UI.XRPictureBox();
         ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
         // 
         // Detail
         // 
         this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lblSwitchboardTitle,
            this.imgSwitchboardImage,
            this.lblSwitchboardId});
         this.Detail.HeightF = 400F;
         this.Detail.Name = "Detail";
         this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
         this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
         // 
         // lblSwitchboardTitle
         // 
         this.lblSwitchboardTitle.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
         this.lblSwitchboardTitle.BorderWidth = 2F;
         this.lblSwitchboardTitle.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblSwitchboardTitle.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
         this.lblSwitchboardTitle.Name = "lblSwitchboardTitle";
         this.lblSwitchboardTitle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
         this.lblSwitchboardTitle.SizeF = new System.Drawing.SizeF(627F, 34.45834F);
         this.lblSwitchboardTitle.StylePriority.UseBorders = false;
         this.lblSwitchboardTitle.StylePriority.UseBorderWidth = false;
         this.lblSwitchboardTitle.StylePriority.UseFont = false;
         this.lblSwitchboardTitle.Text = "lblSwitchboardTitle";
         // 
         // imgSwitchboardImage
         // 
         this.imgSwitchboardImage.LocationFloat = new DevExpress.Utils.PointFloat(0F, 34.45835F);
         this.imgSwitchboardImage.Name = "imgSwitchboardImage";
         this.imgSwitchboardImage.SizeF = new System.Drawing.SizeF(627F, 365.5417F);
         this.imgSwitchboardImage.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
         this.imgSwitchboardImage.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.imgSwitchboardImage_BeforePrint);
         // 
         // lblSwitchboardId
         // 
         this.lblSwitchboardId.LocationFloat = new DevExpress.Utils.PointFloat(663.5417F, 11.45833F);
         this.lblSwitchboardId.Name = "lblSwitchboardId";
         this.lblSwitchboardId.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
         this.lblSwitchboardId.SizeF = new System.Drawing.SizeF(33.33337F, 23F);
         this.lblSwitchboardId.Text = "lblSwitchboardId";
         this.lblSwitchboardId.Visible = false;
         // 
         // TopMargin
         // 
         this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.imgLogo});
         this.TopMargin.HeightF = 101.0417F;
         this.TopMargin.Name = "TopMargin";
         this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
         this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
         // 
         // BottomMargin
         // 
         this.BottomMargin.HeightF = 100F;
         this.BottomMargin.Name = "BottomMargin";
         this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
         this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
         // 
         // SwitchboardHeader
         // 
         this.SwitchboardHeader.HeightF = 0F;
         this.SwitchboardHeader.Name = "SwitchboardHeader";
         // 
         // DigitalConnectionsReport
         // 
         this.DigitalConnectionsReport.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.DigitalConnectionsDetail,
            this.DigitalConnectionsHead});
         this.DigitalConnectionsReport.Level = 0;
         this.DigitalConnectionsReport.Name = "DigitalConnectionsReport";
         this.DigitalConnectionsReport.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand;
         this.DigitalConnectionsReport.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.DigitalConnectionsReport_BeforePrint);
         // 
         // DigitalConnectionsDetail
         // 
         this.DigitalConnectionsDetail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lblConnectedTo,
            this.lblDecoderAddress,
            this.lblDecoderOutput,
            this.lblDecoderName,
            this.lblDecoderModel});
         this.DigitalConnectionsDetail.EvenStyleName = "xrControlStyle2";
         this.DigitalConnectionsDetail.HeightF = 16.75002F;
         this.DigitalConnectionsDetail.Name = "DigitalConnectionsDetail";
         // 
         // lblConnectedTo
         // 
         this.lblConnectedTo.LocationFloat = new DevExpress.Utils.PointFloat(533.2501F, 0F);
         this.lblConnectedTo.Name = "lblConnectedTo";
         this.lblConnectedTo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
         this.lblConnectedTo.SizeF = new System.Drawing.SizeF(93.75F, 16.75002F);
         this.lblConnectedTo.StylePriority.UseTextAlignment = false;
         this.lblConnectedTo.Text = "lblDecoderOutput";
         this.lblConnectedTo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
         // 
         // lblDecoderAddress
         // 
         this.lblDecoderAddress.LocationFloat = new DevExpress.Utils.PointFloat(475.9584F, 0F);
         this.lblDecoderAddress.Name = "lblDecoderAddress";
         this.lblDecoderAddress.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
         this.lblDecoderAddress.SizeF = new System.Drawing.SizeF(57.29163F, 16.75002F);
         this.lblDecoderAddress.StylePriority.UseTextAlignment = false;
         this.lblDecoderAddress.Text = "lblDecoderOutput";
         this.lblDecoderAddress.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
         // 
         // lblDecoderOutput
         // 
         this.lblDecoderOutput.LocationFloat = new DevExpress.Utils.PointFloat(418.6667F, 0F);
         this.lblDecoderOutput.Name = "lblDecoderOutput";
         this.lblDecoderOutput.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
         this.lblDecoderOutput.SizeF = new System.Drawing.SizeF(57.29169F, 16.75002F);
         this.lblDecoderOutput.StylePriority.UseTextAlignment = false;
         this.lblDecoderOutput.Text = "lblDecoderOutput";
         this.lblDecoderOutput.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
         // 
         // lblDecoderName
         // 
         this.lblDecoderName.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
         this.lblDecoderName.Name = "lblDecoderName";
         this.lblDecoderName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
         this.lblDecoderName.SizeF = new System.Drawing.SizeF(151.0417F, 16.75002F);
         this.lblDecoderName.Text = "lblDecoderName";
         // 
         // lblDecoderModel
         // 
         this.lblDecoderModel.LocationFloat = new DevExpress.Utils.PointFloat(151.0417F, 0F);
         this.lblDecoderModel.Name = "lblDecoderModel";
         this.lblDecoderModel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
         this.lblDecoderModel.SizeF = new System.Drawing.SizeF(267.6251F, 16.75002F);
         this.lblDecoderModel.Text = "lblDecoderModel";
         // 
         // DigitalConnectionsHead
         // 
         this.DigitalConnectionsHead.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel4,
            this.xrLabel3,
            this.xrLabel2,
            this.xrLabel1});
         this.DigitalConnectionsHead.HeightF = 20.20836F;
         this.DigitalConnectionsHead.Name = "DigitalConnectionsHead";
         // 
         // xrLabel4
         // 
         this.xrLabel4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(533.2499F, 0F);
         this.xrLabel4.Name = "xrLabel4";
         this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
         this.xrLabel4.SizeF = new System.Drawing.SizeF(93.75006F, 20.20836F);
         this.xrLabel4.StylePriority.UseFont = false;
         this.xrLabel4.StylePriority.UseTextAlignment = false;
         this.xrLabel4.Text = "Connected to";
         this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
         // 
         // xrLabel3
         // 
         this.xrLabel3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(475.9583F, 0F);
         this.xrLabel3.Name = "xrLabel3";
         this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
         this.xrLabel3.SizeF = new System.Drawing.SizeF(57.29175F, 20.20836F);
         this.xrLabel3.StylePriority.UseFont = false;
         this.xrLabel3.StylePriority.UseTextAlignment = false;
         this.xrLabel3.Text = "Address";
         this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
         // 
         // xrLabel2
         // 
         this.xrLabel2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(418.6666F, 0F);
         this.xrLabel2.Name = "xrLabel2";
         this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
         this.xrLabel2.SizeF = new System.Drawing.SizeF(57.29175F, 20.20836F);
         this.xrLabel2.StylePriority.UseFont = false;
         this.xrLabel2.StylePriority.UseTextAlignment = false;
         this.xrLabel2.Text = "Output";
         this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
         // 
         // xrLabel1
         // 
         this.xrLabel1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
         this.xrLabel1.Name = "xrLabel1";
         this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
         this.xrLabel1.SizeF = new System.Drawing.SizeF(418.6666F, 20.20836F);
         this.xrLabel1.StylePriority.UseFont = false;
         this.xrLabel1.Text = "Digital connections";
         // 
         // xrControlStyle2
         // 
         this.xrControlStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
         this.xrControlStyle2.Name = "xrControlStyle2";
         this.xrControlStyle2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
         // 
         // imgLogo
         // 
         this.imgLogo.Image = ((System.Drawing.Image)(resources.GetObject("imgLogo.Image")));
         this.imgLogo.LocationFloat = new DevExpress.Utils.PointFloat(418.6668F, 49.95834F);
         this.imgLogo.Name = "imgLogo";
         this.imgLogo.SizeF = new System.Drawing.SizeF(208.3333F, 23.95833F);
         this.imgLogo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.AutoSize;
         // 
         // DigitalReport
         // 
         this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.SwitchboardHeader,
            this.DigitalConnectionsReport});
         this.DisplayName = "Digital Report";
         this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.Margins = new System.Drawing.Printing.Margins(100, 100, 101, 100);
         this.PageHeight = 1169;
         this.PageWidth = 827;
         this.PaperKind = System.Drawing.Printing.PaperKind.A4;
         this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.xrControlStyle2});
         this.Version = "15.1";
         this.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.DigitalReport_BeforePrint);
         ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

      }

      #endregion

      private DevExpress.XtraReports.UI.DetailBand Detail;
      private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
      private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
      private DevExpress.XtraReports.UI.GroupHeaderBand SwitchboardHeader;
      private DevExpress.XtraReports.UI.XRLabel lblSwitchboardTitle;
      private DevExpress.XtraReports.UI.XRPictureBox imgSwitchboardImage;
      private DevExpress.XtraReports.UI.DetailReportBand DigitalConnectionsReport;
      private DevExpress.XtraReports.UI.DetailBand DigitalConnectionsDetail;
      private DevExpress.XtraReports.UI.XRLabel lblConnectedTo;
      private DevExpress.XtraReports.UI.XRLabel lblDecoderAddress;
      private DevExpress.XtraReports.UI.XRLabel lblDecoderOutput;
      private DevExpress.XtraReports.UI.XRLabel lblDecoderModel;
      private DevExpress.XtraReports.UI.XRLabel lblDecoderName;
      private DevExpress.XtraReports.UI.ReportHeaderBand DigitalConnectionsHead;
      private DevExpress.XtraReports.UI.XRLabel xrLabel1;
      private DevExpress.XtraReports.UI.XRLabel lblSwitchboardId;
      private DevExpress.XtraReports.UI.XRControlStyle xrControlStyle2;
      private DevExpress.XtraReports.UI.XRLabel xrLabel4;
      private DevExpress.XtraReports.UI.XRLabel xrLabel3;
      private DevExpress.XtraReports.UI.XRLabel xrLabel2;
      private DevExpress.XtraReports.UI.XRPictureBox imgLogo;
   }
}
