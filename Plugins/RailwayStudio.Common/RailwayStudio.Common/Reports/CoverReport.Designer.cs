namespace Rwm.Studio.Plugins.Common.Reports
{
   partial class CoverReport
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CoverReport));
         this.Detail = new DevExpress.XtraReports.UI.DetailBand();
         this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
         this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
         this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
         this.lblReportTop = new DevExpress.XtraReports.UI.XRLabel();
         this.lblReportTitle = new DevExpress.XtraReports.UI.XRLabel();
         this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
         this.imgLogo = new DevExpress.XtraReports.UI.XRPictureBox();
         ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
         // 
         // Detail
         // 
         this.Detail.HeightF = 0F;
         this.Detail.Name = "Detail";
         this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
         this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
         // 
         // TopMargin
         // 
         this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.imgLogo});
         this.TopMargin.HeightF = 100F;
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
         // ReportHeader
         // 
         this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lblReportTop,
            this.lblReportTitle,
            this.xrPictureBox1});
         this.ReportHeader.HeightF = 968.0834F;
         this.ReportHeader.Name = "ReportHeader";
         // 
         // lblReportTop
         // 
         this.lblReportTop.BackColor = System.Drawing.Color.DimGray;
         this.lblReportTop.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
         this.lblReportTop.Name = "lblReportTop";
         this.lblReportTop.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
         this.lblReportTop.SizeF = new System.Drawing.SizeF(727F, 93F);
         this.lblReportTop.StylePriority.UseBackColor = false;
         // 
         // lblReportTitle
         // 
         this.lblReportTitle.BackColor = System.Drawing.Color.DimGray;
         this.lblReportTitle.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblReportTitle.ForeColor = System.Drawing.Color.White;
         this.lblReportTitle.LocationFloat = new DevExpress.Utils.PointFloat(0F, 813.6669F);
         this.lblReportTitle.Name = "lblReportTitle";
         this.lblReportTitle.Padding = new DevExpress.XtraPrinting.PaddingInfo(20, 20, 20, 20, 100F);
         this.lblReportTitle.SizeF = new System.Drawing.SizeF(727F, 154.4166F);
         this.lblReportTitle.StylePriority.UseBackColor = false;
         this.lblReportTitle.StylePriority.UseFont = false;
         this.lblReportTitle.StylePriority.UseForeColor = false;
         this.lblReportTitle.StylePriority.UsePadding = false;
         this.lblReportTitle.Text = "lblReportTitle";
         // 
         // xrPictureBox1
         // 
         this.xrPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("xrPictureBox1.Image")));
         this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 96F);
         this.xrPictureBox1.Name = "xrPictureBox1";
         this.xrPictureBox1.SizeF = new System.Drawing.SizeF(727F, 717.6668F);
         this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
         // 
         // imgLogo
         // 
         this.imgLogo.Image = ((System.Drawing.Image)(resources.GetObject("imgLogo.Image")));
         this.imgLogo.LocationFloat = new DevExpress.Utils.PointFloat(518.6666F, 50F);
         this.imgLogo.Name = "imgLogo";
         this.imgLogo.SizeF = new System.Drawing.SizeF(208.3333F, 23.95833F);
         this.imgLogo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.AutoSize;
         // 
         // CoverReport
         // 
         this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader});
         this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.Margins = new System.Drawing.Printing.Margins(48, 52, 100, 100);
         this.PageHeight = 1169;
         this.PageWidth = 827;
         this.PaperKind = System.Drawing.Printing.PaperKind.A4;
         this.Version = "15.1";
         ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

      }

      #endregion

      private DevExpress.XtraReports.UI.DetailBand Detail;
      private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
      private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
      private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
      private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
      private DevExpress.XtraReports.UI.XRLabel lblReportTitle;
      private DevExpress.XtraReports.UI.XRLabel lblReportTop;
      private DevExpress.XtraReports.UI.XRPictureBox imgLogo;
   }
}
