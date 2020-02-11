using System;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using Rwm.Otc.Layout;
using Rwm.Studio.Plugins.Control.Views;

namespace Rwm.Studio.Plugins.Control.Controls
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
         this.SelectedOutput = null;
         this.SelectedDecoder = null;
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
         this.SelectedOutput = output;
         this.SelectedDecoder = output.Device;
         this.Element = output.Element;

         ShowSelectedOutput();
      }

      #endregion

      #region Fields

      private int FixedHeight { get; set; }

      #endregion

      #region Properties

      public int ConnectionIndex { get; set; }

      public AccessoryDecoderConnection SelectedOutput { get; private set; }

      public AccessoryDecoder SelectedDecoder { get; private set; }

      public Element Element { get; private set; }

      public new string Text
      {
         get { return grpConnection.Text; }
         set { grpConnection.Text = value.Trim(); }
      }

      public bool IsConnected
      {
         get { return (this.SelectedOutput != null && this.SelectedOutput.Address > 0); }
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
            AccesoryConnectionFindView form = new AccesoryConnectionFindView(this.SelectedOutput);
            form.ShowDialog(this);

            if (form.DialogResult == DialogResult.OK)
            {
               this.SelectedOutput = form.SelectedConnection;
               this.SelectedDecoder = form.SelectedDecoder;

               this.SelectedOutput.ElementPinIndex = this.ConnectionIndex;
               this.SelectedOutput.Element = this.Element;
               AccessoryDecoderConnection.Save(this.SelectedOutput);

               this.ConnectionChanged?.Invoke(this, new ConnectionChangedEventArgs(this.ConnectionIndex, this.SelectedOutput));
            }
         }
         else if (e.Button.Index == 1)
         {
            if (this.SelectedOutput == null)
            {
               MessageBox.Show("This connection is not connected to any decoder output.",
                               Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
               return;
            }

            AccessoryDecoderConnection.Delete(this.SelectedOutput.ID);

            this.SelectedOutput = null;
            this.SelectedDecoder = null;

            this.ConnectionChanged?.Invoke(this, new ConnectionChangedEventArgs(this.ConnectionIndex, this.SelectedOutput));
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
         if (this.SelectedOutput == null || this.SelectedDecoder == null)
         {
            txtOutput.Text = "Not connected";
         }
         else
         {
            txtOutput.Text = string.Format("<b>{0}</b> output <b>{1}</b> (address <b>{2}</b>)",
                                           this.SelectedDecoder.Name,
                                           this.SelectedOutput.Name,
                                           this.SelectedOutput.Address.ToString("D4"));
         }

         // Set disconnect button status
         txtOutput.Properties.Buttons[1].Enabled = !(this.SelectedOutput == null || this.SelectedDecoder == null);
      }

      #endregion

   }
}
