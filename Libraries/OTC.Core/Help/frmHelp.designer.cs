namespace otc.help
{
   partial class frmHelp
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHelp));
         this.stbStatus = new System.Windows.Forms.StatusStrip();
         this.stbActivity = new System.Windows.Forms.ToolStripStatusLabel();
         this.stbURL = new System.Windows.Forms.ToolStripStatusLabel();
         this.imlIcons = new System.Windows.Forms.ImageList(this.components);
         this.clkStatus = new System.Windows.Forms.Timer(this.components);
         this.tvwTree = new System.Windows.Forms.TreeView();
         this.webContent = new System.Windows.Forms.WebBrowser();
         this.panel2 = new System.Windows.Forms.Panel();
         this.splitHelp = new System.Windows.Forms.SplitContainer();
         this.pnlWebBrowser = new System.Windows.Forms.Panel();
         this.toolStrip1 = new System.Windows.Forms.ToolStrip();
         this.tbrExit = new System.Windows.Forms.ToolStripButton();
         this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
         this.tbrPrint = new System.Windows.Forms.ToolStripButton();
         this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
         this.tbrBrowserPrev = new System.Windows.Forms.ToolStripButton();
         this.tbrBrowseNext = new System.Windows.Forms.ToolStripButton();
         this.pnlTitle = new System.Windows.Forms.Panel();
         this.lblTitle = new System.Windows.Forms.Label();
         this.picWizard = new System.Windows.Forms.PictureBox();
         this.stbStatus.SuspendLayout();
         this.panel2.SuspendLayout();
         this.splitHelp.Panel1.SuspendLayout();
         this.splitHelp.Panel2.SuspendLayout();
         this.splitHelp.SuspendLayout();
         this.pnlWebBrowser.SuspendLayout();
         this.toolStrip1.SuspendLayout();
         this.pnlTitle.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.picWizard)).BeginInit();
         this.SuspendLayout();
         // 
         // stbStatus
         // 
         this.stbStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stbActivity,
            this.stbURL});
         this.stbStatus.Location = new System.Drawing.Point(0, 501);
         this.stbStatus.Name = "stbStatus";
         this.stbStatus.Size = new System.Drawing.Size(682, 22);
         this.stbStatus.TabIndex = 1;
         this.stbStatus.Text = "statusStrip1";
         // 
         // stbActivity
         // 
         this.stbActivity.AutoSize = false;
         this.stbActivity.Name = "stbActivity";
         this.stbActivity.Size = new System.Drawing.Size(100, 17);
         this.stbActivity.Text = "Listo";
         this.stbActivity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // stbURL
         // 
         this.stbURL.Name = "stbURL";
         this.stbURL.Size = new System.Drawing.Size(567, 17);
         this.stbURL.Spring = true;
         this.stbURL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // imlIcons
         // 
         this.imlIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlIcons.ImageStream")));
         this.imlIcons.TransparentColor = System.Drawing.Color.Transparent;
         this.imlIcons.Images.SetKeyName(0, "ICO_ROOT");
         this.imlIcons.Images.SetKeyName(1, "ICO_ALL");
         this.imlIcons.Images.SetKeyName(2, "ICO_DOC");
         this.imlIcons.Images.SetKeyName(3, "ICO_EXT");
         this.imlIcons.Images.SetKeyName(4, "ICO_THEME");
         this.imlIcons.Images.SetKeyName(5, "ICO_ACTIVE");
         // 
         // clkStatus
         // 
         this.clkStatus.Enabled = true;
         this.clkStatus.Interval = 300;
         this.clkStatus.Tick += new System.EventHandler(this.clkStatus_Tick);
         // 
         // tvwTree
         // 
         this.tvwTree.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this.tvwTree.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tvwTree.HideSelection = false;
         this.tvwTree.ImageIndex = 0;
         this.tvwTree.ImageList = this.imlIcons;
         this.tvwTree.Location = new System.Drawing.Point(0, 0);
         this.tvwTree.Name = "tvwTree";
         this.tvwTree.SelectedImageIndex = 0;
         this.tvwTree.Size = new System.Drawing.Size(227, 408);
         this.tvwTree.TabIndex = 3;
         this.tvwTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwTree_AfterSelect);
         // 
         // webContent
         // 
         this.webContent.Dock = System.Windows.Forms.DockStyle.Fill;
         this.webContent.Location = new System.Drawing.Point(0, 0);
         this.webContent.MinimumSize = new System.Drawing.Size(20, 20);
         this.webContent.Name = "webContent";
         this.webContent.ScriptErrorsSuppressed = true;
         this.webContent.Size = new System.Drawing.Size(449, 406);
         this.webContent.TabIndex = 3;
         this.webContent.Url = new System.Uri("http://www.railwaymania.com/", System.UriKind.Absolute);
         // 
         // panel2
         // 
         this.panel2.Controls.Add(this.splitHelp);
         this.panel2.Controls.Add(this.toolStrip1);
         this.panel2.Controls.Add(this.pnlTitle);
         this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panel2.Location = new System.Drawing.Point(0, 0);
         this.panel2.Name = "panel2";
         this.panel2.Size = new System.Drawing.Size(682, 501);
         this.panel2.TabIndex = 7;
         // 
         // splitHelp
         // 
         this.splitHelp.Dock = System.Windows.Forms.DockStyle.Fill;
         this.splitHelp.Location = new System.Drawing.Point(0, 93);
         this.splitHelp.Name = "splitHelp";
         // 
         // splitHelp.Panel1
         // 
         this.splitHelp.Panel1.Controls.Add(this.tvwTree);
         // 
         // splitHelp.Panel2
         // 
         this.splitHelp.Panel2.Controls.Add(this.pnlWebBrowser);
         this.splitHelp.Size = new System.Drawing.Size(682, 408);
         this.splitHelp.SplitterDistance = 227;
         this.splitHelp.TabIndex = 13;
         // 
         // pnlWebBrowser
         // 
         this.pnlWebBrowser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.pnlWebBrowser.Controls.Add(this.webContent);
         this.pnlWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlWebBrowser.Location = new System.Drawing.Point(0, 0);
         this.pnlWebBrowser.Name = "pnlWebBrowser";
         this.pnlWebBrowser.Size = new System.Drawing.Size(451, 408);
         this.pnlWebBrowser.TabIndex = 4;
         // 
         // toolStrip1
         // 
         this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbrExit,
            this.toolStripSeparator3,
            this.tbrPrint,
            this.toolStripSeparator4,
            this.tbrBrowserPrev,
            this.tbrBrowseNext});
         this.toolStrip1.Location = new System.Drawing.Point(0, 68);
         this.toolStrip1.Name = "toolStrip1";
         this.toolStrip1.Size = new System.Drawing.Size(682, 25);
         this.toolStrip1.TabIndex = 12;
         this.toolStrip1.Text = "toolStrip1";
         // 
         // tbrExit
         // 
         this.tbrExit.Image = global::otc.Properties.Resources.ICO_EXIT;
         this.tbrExit.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.tbrExit.Name = "tbrExit";
         this.tbrExit.Size = new System.Drawing.Size(59, 22);
         this.tbrExit.Text = "Cerrar";
         this.tbrExit.ToolTipText = "Cierra la ventana de ayuda";
         this.tbrExit.Click += new System.EventHandler(this.tbrExit_Click);
         // 
         // toolStripSeparator3
         // 
         this.toolStripSeparator3.Name = "toolStripSeparator3";
         this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
         // 
         // tbrPrint
         // 
         this.tbrPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.tbrPrint.Image = global::otc.Properties.Resources.ICO_PRINT;
         this.tbrPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.tbrPrint.Name = "tbrPrint";
         this.tbrPrint.Size = new System.Drawing.Size(23, 22);
         this.tbrPrint.ToolTipText = "Imprime el contenido actual de la ventana de ayuda";
         this.tbrPrint.Click += new System.EventHandler(this.tbrPrint_Click);
         // 
         // toolStripSeparator4
         // 
         this.toolStripSeparator4.Name = "toolStripSeparator4";
         this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
         // 
         // tbrBrowserPrev
         // 
         this.tbrBrowserPrev.Image = global::otc.Properties.Resources.ICO_NAV_PREV;
         this.tbrBrowserPrev.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.tbrBrowserPrev.Name = "tbrBrowserPrev";
         this.tbrBrowserPrev.Size = new System.Drawing.Size(54, 22);
         this.tbrBrowserPrev.Text = "Atrás";
         this.tbrBrowserPrev.ToolTipText = "Retrocede al documento o página web anterior";
         this.tbrBrowserPrev.Click += new System.EventHandler(this.tbrBrowserPrev_Click);
         // 
         // tbrBrowseNext
         // 
         this.tbrBrowseNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.tbrBrowseNext.Image = global::otc.Properties.Resources.ICO_NAV_FORWARD;
         this.tbrBrowseNext.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.tbrBrowseNext.Name = "tbrBrowseNext";
         this.tbrBrowseNext.Size = new System.Drawing.Size(23, 22);
         this.tbrBrowseNext.ToolTipText = "Adelante";
         this.tbrBrowseNext.Click += new System.EventHandler(this.tbrBrowseNext_Click);
         // 
         // pnlTitle
         // 
         this.pnlTitle.BackColor = System.Drawing.Color.White;
         this.pnlTitle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlTitle.BackgroundImage")));
         this.pnlTitle.Controls.Add(this.lblTitle);
         this.pnlTitle.Controls.Add(this.picWizard);
         this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
         this.pnlTitle.Location = new System.Drawing.Point(0, 0);
         this.pnlTitle.Name = "pnlTitle";
         this.pnlTitle.Size = new System.Drawing.Size(682, 68);
         this.pnlTitle.TabIndex = 9;
         // 
         // lblTitle
         // 
         this.lblTitle.AutoSize = true;
         this.lblTitle.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTitle.Location = new System.Drawing.Point(13, 13);
         this.lblTitle.Name = "lblTitle";
         this.lblTitle.Size = new System.Drawing.Size(144, 23);
         this.lblTitle.TabIndex = 1;
         this.lblTitle.Text = "Ayuda de OTC";
         // 
         // picWizard
         // 
         this.picWizard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.picWizard.Image = global::otc.Properties.Resources.WIZARD_OTC;
         this.picWizard.Location = new System.Drawing.Point(606, 0);
         this.picWizard.Name = "picWizard";
         this.picWizard.Size = new System.Drawing.Size(75, 66);
         this.picWizard.TabIndex = 0;
         this.picWizard.TabStop = false;
         // 
         // frmHelp
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(682, 523);
         this.Controls.Add(this.panel2);
         this.Controls.Add(this.stbStatus);
         this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.Name = "frmHelp";
         this.Text = "Railwayamnia.com - Ayuda";
         this.Load += new System.EventHandler(this.frmHelp_Load);
         this.stbStatus.ResumeLayout(false);
         this.stbStatus.PerformLayout();
         this.panel2.ResumeLayout(false);
         this.panel2.PerformLayout();
         this.splitHelp.Panel1.ResumeLayout(false);
         this.splitHelp.Panel2.ResumeLayout(false);
         this.splitHelp.ResumeLayout(false);
         this.pnlWebBrowser.ResumeLayout(false);
         this.toolStrip1.ResumeLayout(false);
         this.toolStrip1.PerformLayout();
         this.pnlTitle.ResumeLayout(false);
         this.pnlTitle.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.picWizard)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.StatusStrip stbStatus;
      private System.Windows.Forms.ImageList imlIcons;
      private System.Windows.Forms.ToolStripStatusLabel stbActivity;
      private System.Windows.Forms.ToolStripStatusLabel stbURL;
      private System.Windows.Forms.Timer clkStatus;
      private System.Windows.Forms.TreeView tvwTree;
      private System.Windows.Forms.WebBrowser webContent;
      private System.Windows.Forms.Panel panel2;
      private System.Windows.Forms.Panel pnlTitle;
      private System.Windows.Forms.Label lblTitle;
      private System.Windows.Forms.PictureBox picWizard;
      private System.Windows.Forms.ToolStrip toolStrip1;
      private System.Windows.Forms.ToolStripButton tbrExit;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
      private System.Windows.Forms.ToolStripButton tbrPrint;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
      private System.Windows.Forms.ToolStripButton tbrBrowserPrev;
      private System.Windows.Forms.ToolStripButton tbrBrowseNext;
      private System.Windows.Forms.SplitContainer splitHelp;
      private System.Windows.Forms.Panel pnlWebBrowser;

   }
}