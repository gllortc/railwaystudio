using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Rwm.Otc;
using Rwm.Otc.Layout;
using System.Windows.Forms;

namespace Rwm.Studio.Plugins.Control.Controls
{
   public partial class OutputStatusEditorControl : DevExpress.XtraEditors.XtraUserControl
   {

      #region Constructors

      public OutputStatusEditorControl()
      {
         InitializeComponent();
      }

      public OutputStatusEditorControl(Element element)
      {
         InitializeComponent();

         this.SetBlock(element);
      }

      #endregion

      #region Properties

      internal Element Element { get; private set; }

      #endregion

      #region Methods

      public void SetBlock(Element element)
      {
         this.Element = element;

         this.Refresh();
      }

      public override void Refresh()
      {
         try
         {
            this.ShowData();
         }
         catch (System.Exception ex)
         {
            MessageBox.Show("ERROR laoding data: " + ex.Message,
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }

         base.Refresh();
      }

      #endregion

      #region Events

      // A delegate type for hooking up change notifications.
      public delegate void MapChangedEventHandler(object sender, MapChangedEventArgs e);

      // An event that clients can use to be notified whenever the elements of the list change.
      public event MapChangedEventHandler MapChanged;

      #endregion

      #region Event Handlers

      void statusRadio_EditValueChanged(object sender, System.EventArgs e)
      {
         int connIndex = -1;
         int blockStatus = -1;
         string[] nameParts = null;
         RadioGroup statusRadio = null;
         DeviceConnection connection = null;

         statusRadio = sender as RadioGroup;
         if (statusRadio == null)
         {
            return;
         }

         connection = statusRadio.Tag as DeviceConnection;
         if (connection == null)
         {
            return;
         }

         nameParts = statusRadio.Name.Split('_');
         connIndex = int.Parse(nameParts[1].Replace("C", string.Empty));
         blockStatus = int.Parse(nameParts[2].Replace("S", string.Empty));

         connection.OutputMap.SetOutput(blockStatus, (int)statusRadio.EditValue);

         if (this.MapChanged != null)
         {
            this.MapChanged(this, new MapChangedEventArgs(connection));
         }
      }

      #endregion

      #region Private Members

      private void ShowData()
      {
         bool showWarn = false;
         int conIndex = 0;
         int statusIndex = 0;
         PictureBox statusImage = null;
         LabelControl statusLabel = null;
         RadioGroup statusRadio = null;

         // Clear all controls
         this.Controls.Clear();

         // Configure output labels
         conIndex = 0;
         foreach (DeviceConnection connection in this.Element.Connections)
         {
            statusLabel = new LabelControl();
            statusLabel.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            statusLabel.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold;
            statusLabel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            statusLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            statusLabel.Location = new System.Drawing.Point(this.Width - 84 - 3 - (conIndex * (84 + 6)), 3);
            statusLabel.Name = "connectionLabel" + conIndex;
            statusLabel.Size = new System.Drawing.Size(84, 13);
            statusLabel.Text = "Output " + (conIndex + 1);
            this.Controls.Add(statusLabel);

            conIndex++;
         }

         foreach (int status in this.Element.GetAllAccessoryStatusValues())
         {
            if (status > 0)   // Remove undefined status
            {
               statusImage = new PictureBox();
               statusImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
               statusImage.SizeMode = PictureBoxSizeMode.StretchImage;
               statusImage.Image = this.Element.GetImage(OTCContext.Project.Theme, status);
               statusImage.Location = new System.Drawing.Point(3, 22 + (statusIndex * (6 + 32)));  // 60
               statusImage.Name = "statusImage" + status;
               statusImage.Size = new System.Drawing.Size(32, 32);
               statusImage.TabStop = false;
               this.Controls.Add(statusImage);

               statusLabel = new LabelControl();
               statusLabel.Location = new System.Drawing.Point(41, 31 + (statusIndex * (6 + 32)));
               statusLabel.Name = "statusLabel" + status;
               statusLabel.Size = new System.Drawing.Size(32, 13);
               statusLabel.TabStop = false;
               statusLabel.Text = status.ToString(); // TODO: Transfor numeric status in text
               this.Controls.Add(statusLabel);

               conIndex = 0;
               foreach (DeviceConnection connection in this.Element.Connections)
               {
                  statusRadio = new RadioGroup();
                  statusRadio.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
                  statusRadio.Location = new System.Drawing.Point(this.Width - 84 - 3 - (conIndex * (84 + 6)), 
                                                                  22 + (statusIndex * (6 + 32)));
                  statusRadio.Name = "statusRadio_C" + conIndex + "_S" + status;
                  statusRadio.Properties.Columns = 2;
                  statusRadio.Properties.Items.AddRange(new RadioGroupItem[] {
                     new RadioGroupItem(1, "T1"),
                     new RadioGroupItem(2, "T2")});
                  statusRadio.Size = new System.Drawing.Size(84, 32);
                  statusRadio.Enabled = (connection != null);
                  statusRadio.Tag = connection;
                  if (connection != null) statusRadio.EditValue = connection.OutputMap.GetOutput(status);
                  if (connection == null) showWarn = true;

                  statusRadio.EditValueChanged += statusRadio_EditValueChanged;

                  this.Controls.Add(statusRadio);

                  conIndex++;
               }

               statusIndex++;
            }
         }

         if (showWarn)
         {
            LabelControl label = new LabelControl();
            label.Appearance.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
            label.Appearance.BorderColor = System.Drawing.Color.FromArgb(192, 192, 0);
            label.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            label.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            label.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            label.Dock = System.Windows.Forms.DockStyle.Bottom;
            label.Name = "lblDisabledControls";
            label.Padding = new System.Windows.Forms.Padding(7);
            label.Text = "To enable the accessory wiring setup you must set all connections to a module output(s).";

            this.Controls.Add(label);
         }
      }

      #endregion

   }
}
