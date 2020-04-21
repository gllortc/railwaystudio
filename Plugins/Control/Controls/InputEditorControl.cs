using System;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using Rwm.Otc.Layout;
using Rwm.Studio.Plugins.Control.Views;

namespace Rwm.Studio.Plugins.Control.Controls
{
   public partial class InputEditorControl : DevExpress.XtraEditors.XtraUserControl
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="InputEditorControl"/>.
      /// </summary>
      /// <remarks>Constructor for design purposes. Don't use in runtime.</remarks>
      public InputEditorControl(Element element)
      {
         InitializeComponent();
         Initialize();

         this.FixedHeight = this.Height;
         this.SelectedInput = null;
         this.SelectedDecoder = null;
         this.Element = element;

         ShowSelectedOutput();
      }

      /// <summary>
      /// Returns a new instance of <see cref="OutputEditorControl"/>.
      /// </summary>
      /// <remarks>Constructor for design purposes. Don't use in runtime.</remarks>
      public InputEditorControl(FeedbackDecoderConnection output)
      {
         InitializeComponent();
         Initialize();

         this.FixedHeight = this.Height;
         this.SelectedInput = output;
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

      public FeedbackDecoderConnection SelectedInput { get; private set; }

      public FeedbackEncoder SelectedDecoder { get; private set; }

      public Element Element { get; private set; }

      public new string Text
      {
         get { return grpConnection.Text; }
         set { grpConnection.Text = value.Trim(); }
      }

      public bool IsConnected
      {
         get { return (this.SelectedInput != null && this.SelectedInput.Address > 0); }
      }

      #endregion

      #region Event Handlers

      private void BlockConnectionEditorControl_Resize(object sender, EventArgs e)
      {
         this.Height = this.FixedHeight;
      }

      private void txtInput_ButtonClick(object sender, ButtonPressedEventArgs e)
      {
         if (e.Button.Index == 0)
         {
            FeedbackConnectionFindView form = new FeedbackConnectionFindView(this.SelectedInput);
            form.ShowDialog(this);

            if (form.DialogResult == DialogResult.OK)
            {
               this.SelectedInput = form.SelectedConnection;
               this.SelectedDecoder = form.SelectedDecoder;

               this.SelectedInput.ElementPinIndex = this.ConnectionIndex;
               this.SelectedInput.Element = this.Element;
               FeedbackDecoderConnection.Save(this.SelectedInput);
            }
         }
         else if (e.Button.Index == 1)
         {
            if (this.SelectedInput == null)
            {
               MessageBox.Show("This connection is not connected to any decoder input.",
                               Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
               return;
            }

            AccessoryDecoderConnection.Delete(this.SelectedInput.ID);

            this.SelectedInput = null;
            this.SelectedDecoder = null;
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
         if (this.SelectedInput == null || this.SelectedDecoder == null)
         {
            txtInput.Text = "Not connected";
         }
         else
         {
            txtInput.Text = string.Format("<b>{0}</b> input <b>{1}</b> (address <b>{2}</b>)",
                                           this.SelectedDecoder.Name,
                                           this.SelectedInput.DecoderInput,
                                           this.SelectedInput.Address);
         }

         // Set disconnect button status
         txtInput.Properties.Buttons[1].Enabled = !(this.SelectedInput == null || this.SelectedDecoder == null);
      }

      #endregion

   }
}
