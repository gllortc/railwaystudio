namespace otc.forms.controls
{
   partial class NetworkClientControl
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
         Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
         Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup2 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
         this.ebcNetwork = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
         this.lstViwUsers = new System.Windows.Forms.ListView();
         this.ebcMessages = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
         this.btnSend = new System.Windows.Forms.Button();
         this.txtNewMessage = new System.Windows.Forms.TextBox();
         this.txtMessages = new System.Windows.Forms.RichTextBox();
         this.colIcon = new System.Windows.Forms.ColumnHeader();
         this.colUserName = new System.Windows.Forms.ColumnHeader();
         this.pnlLogin = new System.Windows.Forms.Panel();
         this.btnEnter = new System.Windows.Forms.Button();
         this.txtUsetName = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.uebContainer = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar();
         this.udaNotifications = new Infragistics.Win.Misc.UltraDesktopAlert(this.components);
         this.ebcNetwork.SuspendLayout();
         this.ebcMessages.SuspendLayout();
         this.pnlLogin.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.uebContainer)).BeginInit();
         this.uebContainer.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.udaNotifications)).BeginInit();
         this.SuspendLayout();
         // 
         // ebcNetwork
         // 
         this.ebcNetwork.Controls.Add(this.lstViwUsers);
         this.ebcNetwork.Location = new System.Drawing.Point(0, 25);
         this.ebcNetwork.Name = "ebcNetwork";
         this.ebcNetwork.Size = new System.Drawing.Size(285, 267);
         this.ebcNetwork.TabIndex = 0;
         // 
         // lstViwUsers
         // 
         this.lstViwUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this.lstViwUsers.Dock = System.Windows.Forms.DockStyle.Fill;
         this.lstViwUsers.FullRowSelect = true;
         this.lstViwUsers.Location = new System.Drawing.Point(0, 0);
         this.lstViwUsers.Name = "lstViwUsers";
         this.lstViwUsers.Size = new System.Drawing.Size(285, 267);
         this.lstViwUsers.TabIndex = 1;
         this.lstViwUsers.UseCompatibleStateImageBehavior = false;
         // 
         // ebcMessages
         // 
         this.ebcMessages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)));
         this.ebcMessages.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
         this.ebcMessages.Controls.Add(this.btnSend);
         this.ebcMessages.Controls.Add(this.txtNewMessage);
         this.ebcMessages.Controls.Add(this.txtMessages);
         this.ebcMessages.Location = new System.Drawing.Point(-10000, -10000);
         this.ebcMessages.Name = "ebcMessages";
         this.ebcMessages.Size = new System.Drawing.Size(285, 267);
         this.ebcMessages.TabIndex = 2;
         this.ebcMessages.Visible = false;
         // 
         // btnSend
         // 
         this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnSend.Location = new System.Drawing.Point(207, 241);
         this.btnSend.Name = "btnSend";
         this.btnSend.Size = new System.Drawing.Size(75, 23);
         this.btnSend.TabIndex = 5;
         this.btnSend.Text = "Enviar";
         this.btnSend.UseVisualStyleBackColor = true;
         this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
         // 
         // txtNewMessage
         // 
         this.txtNewMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.txtNewMessage.Location = new System.Drawing.Point(3, 243);
         this.txtNewMessage.Name = "txtNewMessage";
         this.txtNewMessage.Size = new System.Drawing.Size(198, 21);
         this.txtNewMessage.TabIndex = 4;
         // 
         // txtMessages
         // 
         this.txtMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.txtMessages.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this.txtMessages.Location = new System.Drawing.Point(3, 3);
         this.txtMessages.Name = "txtMessages";
         this.txtMessages.Size = new System.Drawing.Size(279, 232);
         this.txtMessages.TabIndex = 2;
         this.txtMessages.Text = "";
         // 
         // colIcon
         // 
         this.colIcon.Text = "";
         this.colIcon.Width = 23;
         // 
         // colUserName
         // 
         this.colUserName.Text = "";
         this.colUserName.Width = 85;
         // 
         // pnlLogin
         // 
         this.pnlLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
         this.pnlLogin.BackgroundImage = global::otc.Properties.Resources.BG_NETWORK_CLIENT;
         this.pnlLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
         this.pnlLogin.Controls.Add(this.btnEnter);
         this.pnlLogin.Controls.Add(this.txtUsetName);
         this.pnlLogin.Controls.Add(this.label2);
         this.pnlLogin.Location = new System.Drawing.Point(17, 412);
         this.pnlLogin.Name = "pnlLogin";
         this.pnlLogin.Size = new System.Drawing.Size(268, 207);
         this.pnlLogin.TabIndex = 6;
         // 
         // btnEnter
         // 
         this.btnEnter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.btnEnter.Location = new System.Drawing.Point(130, 178);
         this.btnEnter.Name = "btnEnter";
         this.btnEnter.Size = new System.Drawing.Size(89, 23);
         this.btnEnter.TabIndex = 2;
         this.btnEnter.Text = "Iniciar sesión";
         this.btnEnter.UseVisualStyleBackColor = true;
         this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
         // 
         // txtUsetName
         // 
         this.txtUsetName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.txtUsetName.Location = new System.Drawing.Point(42, 151);
         this.txtUsetName.Name = "txtUsetName";
         this.txtUsetName.Size = new System.Drawing.Size(177, 21);
         this.txtUsetName.TabIndex = 1;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.BackColor = System.Drawing.Color.Transparent;
         this.label2.Location = new System.Drawing.Point(39, 135);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(32, 13);
         this.label2.TabIndex = 0;
         this.label2.Text = "Login";
         // 
         // uebContainer
         // 
         this.uebContainer.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
         this.uebContainer.Controls.Add(this.ebcNetwork);
         this.uebContainer.Controls.Add(this.ebcMessages);
         ultraExplorerBarGroup1.Container = this.ebcNetwork;
         ultraExplorerBarGroup1.Key = "ID_NETWORK";
         ultraExplorerBarGroup1.Settings.ContainerHeight = 105;
         ultraExplorerBarGroup1.Settings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.ControlContainer;
         ultraExplorerBarGroup1.Text = "Estaciones de red";
         ultraExplorerBarGroup2.Container = this.ebcMessages;
         ultraExplorerBarGroup2.Key = "ID_MESSAGES";
         ultraExplorerBarGroup2.Settings.ContainerHeight = 186;
         ultraExplorerBarGroup2.Settings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.ControlContainer;
         ultraExplorerBarGroup2.Text = "Mensajes";
         this.uebContainer.Groups.AddRange(new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup[] {
            ultraExplorerBarGroup1,
            ultraExplorerBarGroup2});
         this.uebContainer.GroupSettings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.ControlContainer;
         this.uebContainer.Location = new System.Drawing.Point(0, 0);
         this.uebContainer.Name = "uebContainer";
         this.uebContainer.Size = new System.Drawing.Size(285, 374);
         this.uebContainer.Style = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarStyle.OutlookNavigationPane;
         this.uebContainer.TabIndex = 7;
         this.uebContainer.ViewStyle = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarViewStyle.Office2007;
         // 
         // NetworkClientControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
         this.Controls.Add(this.pnlLogin);
         this.Controls.Add(this.uebContainer);
         this.DoubleBuffered = true;
         this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.Name = "NetworkClientControl";
         this.Size = new System.Drawing.Size(288, 643);
         this.ebcNetwork.ResumeLayout(false);
         this.ebcMessages.ResumeLayout(false);
         this.ebcMessages.PerformLayout();
         this.pnlLogin.ResumeLayout(false);
         this.pnlLogin.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.uebContainer)).EndInit();
         this.uebContainer.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.udaNotifications)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.ColumnHeader colIcon;
      private System.Windows.Forms.ColumnHeader colUserName;
      private System.Windows.Forms.ListView lstViwUsers;
      private System.Windows.Forms.RichTextBox txtMessages;
      private System.Windows.Forms.TextBox txtNewMessage;
      private System.Windows.Forms.Button btnSend;
      private System.Windows.Forms.Panel pnlLogin;
      private System.Windows.Forms.Button btnEnter;
      private System.Windows.Forms.TextBox txtUsetName;
      private System.Windows.Forms.Label label2;
      private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar uebContainer;
      private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ebcNetwork;
      private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ebcMessages;
      private Infragistics.Win.Misc.UltraDesktopAlert udaNotifications;
   }
}
