namespace Rwm.Studio.Plugins.Designer.Reports
{
   partial class DigitalReportBySections
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DigitalReportBySections));
         this.Detail = new DevExpress.XtraReports.UI.DetailBand();
         this.lblSectionTitle = new DevExpress.XtraReports.UI.XRLabel();
         this.imgSwitchboardImage = new DevExpress.XtraReports.UI.XRPictureBox();
         this.lblSectionId = new DevExpress.XtraReports.UI.XRLabel();
         this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
         this.lblProjectName = new DevExpress.XtraReports.UI.XRLabel();
         this.imgLogo = new DevExpress.XtraReports.UI.XRPictureBox();
         this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
         this.SectionHeader = new DevExpress.XtraReports.UI.GroupHeaderBand();
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
         this.xrControlStyle2 = new DevExpress.XtraReports.UI.XRControlStyle();
         this.lblDecoderDescription = new DevExpress.XtraReports.UI.XRLabel();
         this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
         this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
         ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
         // 
         // Detail
         // 
         this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lblSectionTitle,
            this.imgSwitchboardImage,
            this.lblSectionId});
         this.Detail.HeightF = 414.5833F;
         this.Detail.Name = "Detail";
         this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
         this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
         // 
         // lblSectionTitle
         // 
         this.lblSectionTitle.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
         this.lblSectionTitle.BorderWidth = 2F;
         this.lblSectionTitle.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblSectionTitle.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
         this.lblSectionTitle.Name = "lblSectionTitle";
         this.lblSectionTitle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
         this.lblSectionTitle.SizeF = new System.Drawing.SizeF(627F, 34.45834F);
         this.lblSectionTitle.StylePriority.UseBorders = false;
         this.lblSectionTitle.StylePriority.UseBorderWidth = false;
         this.lblSectionTitle.StylePriority.UseFont = false;
         this.lblSectionTitle.Text = "lblSectionTitle";
         // 
         // imgSwitchboardImage
         // 
         this.imgSwitchboardImage.LocationFloat = new DevExpress.Utils.PointFloat(0F, 34.45835F);
         this.imgSwitchboardImage.Name = "imgSwitchboardImage";
         this.imgSwitchboardImage.SizeF = new System.Drawing.SizeF(627F, 365.5417F);
         this.imgSwitchboardImage.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
         this.imgSwitchboardImage.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.ImgSwitchboardImage_BeforePrint);
         // 
         // lblSectionId
         // 
         this.lblSectionId.LocationFloat = new DevExpress.Utils.PointFloat(663.5417F, 11.45833F);
         this.lblSectionId.Name = "lblSectionId";
         this.lblSectionId.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
         this.lblSectionId.SizeF = new System.Drawing.SizeF(33.33337F, 23F);
         this.lblSectionId.Text = "lblSectionId";
         this.lblSectionId.Visible = false;
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
         // SectionHeader
         // 
         this.SectionHeader.HeightF = 0F;
         this.SectionHeader.Name = "SectionHeader";
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
            this.xrLabel5,
            this.lblConnectedTo,
            this.lblDecoderAddress,
            this.lblDecoderOutput});
         this.DigitalConnectionsDetail.EvenStyleName = "xrControlStyle2";
         this.DigitalConnectionsDetail.HeightF = 16.75002F;
         this.DigitalConnectionsDetail.Name = "DigitalConnectionsDetail";
         // 
         // lblConnectedTo
         // 
         this.lblConnectedTo.LocationFloat = new DevExpress.Utils.PointFloat(512.4169F, 0F);
         this.lblConnectedTo.Name = "lblConnectedTo";
         this.lblConnectedTo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
         this.lblConnectedTo.SizeF = new System.Drawing.SizeF(114.5834F, 16.75002F);
         this.lblConnectedTo.StylePriority.UseTextAlignment = false;
         this.lblConnectedTo.Text = "lblDecoderOutput";
         this.lblConnectedTo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
         // 
         // lblDecoderAddress
         // 
         this.lblDecoderAddress.LocationFloat = new DevExpress.Utils.PointFloat(57.29174F, 0F);
         this.lblDecoderAddress.Name = "lblDecoderAddress";
         this.lblDecoderAddress.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
         this.lblDecoderAddress.SizeF = new System.Drawing.SizeF(68.35953F, 16.75002F);
         this.lblDecoderAddress.StylePriority.UseTextAlignment = false;
         this.lblDecoderAddress.Text = "lblDecoderOutput";
         this.lblDecoderAddress.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
         // 
         // lblDecoderOutput
         // 
         this.lblDecoderOutput.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
         this.lblDecoderOutput.Name = "lblDecoderOutput";
         this.lblDecoderOutput.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
         this.lblDecoderOutput.SizeF = new System.Drawing.SizeF(57.29169F, 16.75002F);
         this.lblDecoderOutput.StylePriority.UseTextAlignment = false;
         this.lblDecoderOutput.Text = "lblDecoderOutput";
         this.lblDecoderOutput.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
         // 
         // lblDecoderName
         // 
         this.lblDecoderName.BackColor = System.Drawing.Color.Silver;
         this.lblDecoderName.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
         this.lblDecoderName.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblDecoderName.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
         this.lblDecoderName.Name = "lblDecoderName";
         this.lblDecoderName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
         this.lblDecoderName.SizeF = new System.Drawing.SizeF(626.9999F, 28.20835F);
         this.lblDecoderName.StylePriority.UseBackColor = false;
         this.lblDecoderName.StylePriority.UseBorders = false;
         this.lblDecoderName.StylePriority.UseFont = false;
         this.lblDecoderName.StylePriority.UsePadding = false;
         this.lblDecoderName.StylePriority.UseTextAlignment = false;
         this.lblDecoderName.Text = "lblDecoderName";
         this.lblDecoderName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
         // 
         // lblDecoderModel
         // 
         this.lblDecoderModel.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
         this.lblDecoderModel.LocationFloat = new DevExpress.Utils.PointFloat(0F, 28.20833F);
         this.lblDecoderModel.Name = "lblDecoderModel";
         this.lblDecoderModel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
         this.lblDecoderModel.SizeF = new System.Drawing.SizeF(626.9999F, 20.65627F);
         this.lblDecoderModel.StylePriority.UseBorders = false;
         this.lblDecoderModel.StylePriority.UseTextAlignment = false;
         this.lblDecoderModel.Text = "lblDecoderModel";
         this.lblDecoderModel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
         // 
         // DigitalConnectionsHead
         // 
         this.DigitalConnectionsHead.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1,
            this.lblDecoderDescription,
            this.lblDecoderModel,
            this.lblDecoderName,
            this.xrLabel4,
            this.xrLabel3,
            this.xrLabel2});
         this.DigitalConnectionsHead.HeightF = 119.0261F;
         this.DigitalConnectionsHead.Name = "DigitalConnectionsHead";
         // 
         // xrLabel4
         // 
         this.xrLabel4.BackColor = System.Drawing.Color.Gainsboro;
         this.xrLabel4.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
         this.xrLabel4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(512.4169F, 98.81774F);
         this.xrLabel4.Name = "xrLabel4";
         this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
         this.xrLabel4.SizeF = new System.Drawing.SizeF(114.5834F, 20.20836F);
         this.xrLabel4.StylePriority.UseBackColor = false;
         this.xrLabel4.StylePriority.UseBorders = false;
         this.xrLabel4.StylePriority.UseFont = false;
         this.xrLabel4.StylePriority.UseTextAlignment = false;
         this.xrLabel4.Text = "Accessory";
         this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
         // 
         // xrLabel3
         // 
         this.xrLabel3.BackColor = System.Drawing.Color.Gainsboro;
         this.xrLabel3.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
         this.xrLabel3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(57.29174F, 98.81774F);
         this.xrLabel3.Name = "xrLabel3";
         this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
         this.xrLabel3.SizeF = new System.Drawing.SizeF(68.35953F, 20.20836F);
         this.xrLabel3.StylePriority.UseBackColor = false;
         this.xrLabel3.StylePriority.UseBorders = false;
         this.xrLabel3.StylePriority.UseFont = false;
         this.xrLabel3.StylePriority.UseTextAlignment = false;
         this.xrLabel3.Text = "Address";
         this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
         // 
         // xrLabel2
         // 
         this.xrLabel2.BackColor = System.Drawing.Color.Gainsboro;
         this.xrLabel2.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
         this.xrLabel2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 98.81774F);
         this.xrLabel2.Name = "xrLabel2";
         this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
         this.xrLabel2.SizeF = new System.Drawing.SizeF(57.29175F, 20.20836F);
         this.xrLabel2.StylePriority.UseBackColor = false;
         this.xrLabel2.StylePriority.UseBorders = false;
         this.xrLabel2.StylePriority.UseFont = false;
         this.xrLabel2.StylePriority.UseTextAlignment = false;
         this.xrLabel2.Text = "Output";
         this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
         // 
         // xrControlStyle2
         // 
         this.xrControlStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
         this.xrControlStyle2.Name = "xrControlStyle2";
         this.xrControlStyle2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
         // 
         // lblDecoderDescription
         // 
         this.lblDecoderDescription.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
         this.lblDecoderDescription.LocationFloat = new DevExpress.Utils.PointFloat(7.947285E-05F, 48.8646F);
         this.lblDecoderDescription.Name = "lblDecoderDescription";
         this.lblDecoderDescription.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
         this.lblDecoderDescription.SizeF = new System.Drawing.SizeF(626.9999F, 49.95314F);
         this.lblDecoderDescription.StylePriority.UseBorders = false;
         this.lblDecoderDescription.StylePriority.UseTextAlignment = false;
         this.lblDecoderDescription.Text = "lblDecoderDescription";
         this.lblDecoderDescription.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopJustify;
         // 
         // xrLabel1
         // 
         this.xrLabel1.BackColor = System.Drawing.Color.Gainsboro;
         this.xrLabel1.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
         this.xrLabel1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(125.6513F, 98.81774F);
         this.xrLabel1.Name = "xrLabel1";
         this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
         this.xrLabel1.SizeF = new System.Drawing.SizeF(386.7656F, 20.20836F);
         this.xrLabel1.StylePriority.UseBackColor = false;
         this.xrLabel1.StylePriority.UseBorders = false;
         this.xrLabel1.StylePriority.UseFont = false;
         this.xrLabel1.StylePriority.UseTextAlignment = false;
         this.xrLabel1.Text = "Settings";
         this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
         // 
         // xrLabel5
         // 
         this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(125.6513F, 0F);
         this.xrLabel5.Name = "xrLabel5";
         this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
         this.xrLabel5.SizeF = new System.Drawing.SizeF(386.7656F, 16.75002F);
         this.xrLabel5.StylePriority.UseTextAlignment = false;
         this.xrLabel5.Text = "lblDecoderOutput";
         this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
         // 
         // DigitalReportBySections
         // 
         this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.SectionHeader,
            this.DigitalConnectionsReport});
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
      private DevExpress.XtraReports.UI.GroupHeaderBand SectionHeader;
      private DevExpress.XtraReports.UI.XRLabel lblSectionTitle;
      private DevExpress.XtraReports.UI.XRPictureBox imgSwitchboardImage;
      private DevExpress.XtraReports.UI.DetailReportBand DigitalConnectionsReport;
      private DevExpress.XtraReports.UI.DetailBand DigitalConnectionsDetail;
      private DevExpress.XtraReports.UI.XRLabel lblConnectedTo;
      private DevExpress.XtraReports.UI.XRLabel lblDecoderAddress;
      private DevExpress.XtraReports.UI.XRLabel lblDecoderOutput;
      private DevExpress.XtraReports.UI.XRLabel lblDecoderModel;
      private DevExpress.XtraReports.UI.XRLabel lblDecoderName;
      private DevExpress.XtraReports.UI.ReportHeaderBand DigitalConnectionsHead;
      private DevExpress.XtraReports.UI.XRLabel lblSectionId;
      private DevExpress.XtraReports.UI.XRControlStyle xrControlStyle2;
      private DevExpress.XtraReports.UI.XRLabel xrLabel4;
      private DevExpress.XtraReports.UI.XRLabel xrLabel3;
      private DevExpress.XtraReports.UI.XRLabel xrLabel2;
      private DevExpress.XtraReports.UI.XRPictureBox imgLogo;
      private DevExpress.XtraReports.UI.XRLabel lblProjectName;
      private DevExpress.XtraReports.UI.XRLabel lblDecoderDescription;
      private DevExpress.XtraReports.UI.XRLabel xrLabel1;
      private DevExpress.XtraReports.UI.XRLabel xrLabel5;
   }
}
