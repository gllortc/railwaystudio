using System;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using Rwm.Otc.Layout;
using Rwm.Studio.Plugins.Designer.Views;

namespace Rwm.Studio.Plugins.Designer.Controls
{
   public partial class OutputEditorControl : DevExpress.XtraEditors.XtraUserControl
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="OutputEditorControl"/>.
      /// </summary>
      /// <remarks>Constructor for design purposes. Don't use in runtime.</remarks>
      public OutputEditorControl(Element element)
      {
         InitializeComponent();
         Initialize();

         this.FixedHeight = this.Height;
         this.SelectedConnection = null;
         this.Element = element;

         ShowSelectedOutput();
      }

      /// <summary>
      /// Returns a new instance of <see cref="OutputEditorControl"/>.
      /// </summary>
      /// <remarks>Constructor for design purposes. Don't use in runtime.</remarks>
      public OutputEditorControl(AccessoryDecoderConnection output)
      {
         InitializeComponent();
         Initialize();

         this.FixedHeight = this.Height;
         this.SelectedConnection = output;
         this.Element = output.Element;

         ShowSelectedOutput();
      }

      #endregion

      #region Fields

      private int FixedHeight { get; set; }

      #endregion

      #region Properties

      public int ConnectionIndex { get; set; }

      public AccessoryDecoderConnection SelectedConnection { get; private set; }

      public Element Element { get; private set; }

      public new string Text
      {
         get { return grpConnection.Text; }
         set { grpConnection.Text = value.Trim(); }
      }

      public bool IsConnected
      {
         get { return (this.SelectedConnection != null && this.SelectedConnection.DecoderOutput.Address > 0); }
      }

      #endregion

      #region Events

      // A delegate type for hooking up change notifications.
      public delegate void ConnectionChangedEventHandler(object sender, ConnectionChangedEventArgs e);

      // An event that clients can use to be notified whenever the elements of the list change.
      public event ConnectionChangedEventHandler ConnectionChanged;

      #endregion

      #region Event Handlers

      private void BlockConnectionEditorControl_Resize(object sender, EventArgs e)
      {
         this.Height = this.FixedHeight;
      }

      private void TxtOutput_ButtonClick(object sender, ButtonPressedEventArgs e)
      {
         if (e.Button.Index == 0)
         {
            AccesoryConnectionFindView form = new AccesoryConnectionFindView(this.SelectedConnection);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
               // Remove existing connection
               if (form.SelectedOutput.AccessoryConnection != null)
               {
                  AccessoryDecoderConnection.Delete(form.SelectedOutput.AccessoryConnection);
               }

               // Create new connection
               this.SelectedConnection = new AccessoryDecoderConnection();
               this.SelectedConnection.DecoderOutput = form.SelectedOutput;
               this.SelectedConnection.Element = this.Element;
               this.SelectedConnection.ElementPinIndex = this.ConnectionIndex;
               AccessoryDecoderConnection.Save(this.SelectedConnection);

               form.SelectedOutput.AccessoryConnection = this.SelectedConnection;

               this.ConnectionChanged?.Invoke(this, new ConnectionChangedEventArgs(this.ConnectionIndex, this.SelectedConnection));
            }
         }
         else if (e.Button.Index == 1)
         {
            if (this.SelectedConnection == null)
            {
               MessageBox.Show("Current element input is not connected to any decoder output.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
               return;
            }

            AccessoryDecoderConnection.Delete(this.SelectedConnection);

            this.SelectedConnection = null;

            this.ConnectionChanged?.Invoke(this, new ConnectionChangedEventArgs(this.ConnectionIndex, this.SelectedConnection));
         }

         ShowSelectedOutput();
      }

      #endregion

      #region Private Members

      private void Initialize()
      {
         this.ConnectionIndex = 0;
      }

      private void ShowSelectedOutput()
      {
         if (this.SelectedConnection == null || this.Element == null)
         {
            txtOutput.Text = "Not connected";
         }
         else
         {
            txtOutput.Text = string.Format("<b>{0}</b> output <b>{1}</b> (address <b>{2}</b>)",
                                           this.SelectedConnection.DecoderOutput.AccessoryDecoder.Name,
                                           this.SelectedConnection.DecoderOutput.Index,
                                           this.SelectedConnection.DecoderOutput.Address.ToString("D4"));
         }

         // Set disconnect button status
         txtOutput.Properties.Buttons[1].Enabled = !(this.SelectedConnection == null || this.Element == null);
      }

      #endregion

   }
}
