namespace otc.forms.controls
{
   partial class MessengerControl
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
         this.rtfMessages = new System.Windows.Forms.RichTextBox();
         this.label1 = new System.Windows.Forms.Label();
         this.txtMessage = new System.Windows.Forms.TextBox();
         this.btnSend = new System.Windows.Forms.Button();
         this.lvwClients = new System.Windows.Forms.ListView();
         this.label2 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.imlIcons = new System.Windows.Forms.ImageList(this.components);
         this.udaAlerts = new Infragistics.Win.Misc.UltraDesktopAlert(this.components);
         this.pnlLogin = new System.Windows.Forms.Panel();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.btnLogin = new System.Windows.Forms.Button();
         this.txtLogin = new System.Windows.Forms.TextBox();
         this.label4 = new System.Windows.Forms.Label();
         ((System.ComponentModel.ISupportInitialize)(this.udaAlerts)).BeginInit();
         this.pnlLogin.SuspendLayout();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         // 
         // rtfMessages
         // 
         this.rtfMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.rtfMessages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.rtfMessages.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.rtfMessages.Location = new System.Drawing.Point(3, 133);
         this.rtfMessages.Name = "rtfMessages";
         this.rtfMessages.Size = new System.Drawing.Size(278, 243);
         this.rtfMessages.TabIndex = 0;
         this.rtfMessages.Text = "";
         // 
         // label1
         // 
         this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(3, 379);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(51, 13);
         this.label1.TabIndex = 1;
         this.label1.Text = "Mensaje:";
         // 
         // txtMessage
         // 
         this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.txtMessage.Location = new System.Drawing.Point(3, 395);
         this.txtMessage.Multiline = true;
         this.txtMessage.Name = "txtMessage";
         this.txtMessage.Size = new System.Drawing.Size(278, 45);
         this.txtMessage.TabIndex = 2;
         // 
         // btnSend
         // 
         this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnSend.Location = new System.Drawing.Point(206, 446);
         this.btnSend.Name = "btnSend";
         this.btnSend.Size = new System.Drawing.Size(75, 23);
         this.btnSend.TabIndex = 3;
         this.btnSend.Text = "Enviar";
         this.btnSend.UseVisualStyleBackColor = true;
         // 
         // lvwClients
         // 
         this.lvwClients.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.lvwClients.Location = new System.Drawing.Point(3, 16);
         this.lvwClients.Name = "lvwClients";
         this.lvwClients.Size = new System.Drawing.Size(278, 98);
         this.lvwClients.TabIndex = 4;
         this.lvwClients.UseCompatibleStateImageBehavior = false;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(3, 0);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(107, 13);
         this.label2.TabIndex = 5;
         this.label2.Text = "Estaciones en la red:";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(3, 117);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(101, 13);
         this.label3.TabIndex = 6;
         this.label3.Text = "Mensajes recibidos:";
         // 
         // imlIcons
         // 
         this.imlIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
         this.imlIcons.ImageSize = new System.Drawing.Size(16, 16);
         this.imlIcons.TransparentColor = System.Drawing.Color.Transparent;
         // 
         // pnlLogin
         // 
         this.pnlLogin.Controls.Add(this.groupBox1);
         this.pnlLogin.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlLogin.Location = new System.Drawing.Point(0, 0);
         this.pnlLogin.Name = "pnlLogin";
         this.pnlLogin.Padding = new System.Windows.Forms.Padding(10);
         this.pnlLogin.Size = new System.Drawing.Size(284, 472);
         this.pnlLogin.TabIndex = 7;
         // 
         // groupBox1
         // 
         this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox1.Controls.Add(this.btnLogin);
         this.groupBox1.Controls.Add(this.txtLogin);
         this.groupBox1.Controls.Add(this.label4);
         this.groupBox1.Location = new System.Drawing.Point(13, 133);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Padding = new System.Windows.Forms.Padding(10);
         this.groupBox1.Size = new System.Drawing.Size(258, 90);
         this.groupBox1.TabIndex = 0;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Iniciar sesión";
         // 
         // btnLogin
         // 
         this.btnLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnLogin.Location = new System.Drawing.Point(155, 54);
         this.btnLogin.Name = "btnLogin";
         this.btnLogin.Size = new System.Drawing.Size(90, 23);
         this.btnLogin.TabIndex = 2;
         this.btnLogin.Text = "Iniciar sesión";
         this.btnLogin.UseVisualStyleBackColor = true;
         this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
         // 
         // txtLogin
         // 
         this.txtLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.txtLogin.Location = new System.Drawing.Point(51, 27);
         this.txtLogin.Name = "txtLogin";
         this.txtLogin.Size = new System.Drawing.Size(194, 21);
         this.txtLogin.TabIndex = 1;
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(13, 30);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(32, 13);
         this.label4.TabIndex = 0;
         this.label4.Text = "Login";
         // 
         // MessengerControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.pnlLogin);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.lvwClients);
         this.Controls.Add(this.btnSend);
         this.Controls.Add(this.txtMessage);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.rtfMessages);
         this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.Name = "MessengerControl";
         this.Size = new System.Drawing.Size(284, 472);
         this.Load += new System.EventHandler(this.MessengerControl_Load);
         ((System.ComponentModel.ISupportInitialize)(this.udaAlerts)).EndInit();
         this.pnlLogin.ResumeLayout(false);
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.RichTextBox rtfMessages;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox txtMessage;
      private System.Windows.Forms.Button btnSend;
      private System.Windows.Forms.ListView lvwClients;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.ImageList imlIcons;
      private Infragistics.Win.Misc.UltraDesktopAlert udaAlerts;
      private System.Windows.Forms.Panel pnlLogin;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.Button btnLogin;
      private System.Windows.Forms.TextBox txtLogin;
      private System.Windows.Forms.Label label4;
   }
}
