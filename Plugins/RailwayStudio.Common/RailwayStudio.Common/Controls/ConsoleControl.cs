using System;
using System.Drawing;
using DevExpress.XtraRichEdit.API.Native;

namespace Rwm.Studio.Plugins.Common.Controls
{
   public partial class ConsoleControl : DevExpress.XtraEditors.XtraUserControl
   {

      #region Constructors

      public ConsoleControl()
      {
         InitializeComponent();

         recConsole.Text = string.Empty;
      }

      #endregion

      #region Properties

      public string MessageIndicator { get; set; } = ">";

      public Color InformationForeColor { get; set; } = Color.White;

      public Color WarningForeColor { get; set; } = Color.LightYellow;

      public Color ErrorForeColor { get; set; } = Color.OrangeRed;

      public Color DebugForeColor { get; set; } = Color.LimeGreen;

      #endregion

      #region Methods

      public void Information(string message)
      {
         if (recConsole.InvokeRequired)
         {
            recConsole.Invoke((Action)delegate
            {
               this.AppendText(this.MessageIndicator + " " + message, this.InformationForeColor);
            });
         }
         else
            this.AppendText(this.MessageIndicator + " " + message, this.InformationForeColor);
      }

      public void Warning(string message)
      {
         if (recConsole.InvokeRequired)
         {
            recConsole.Invoke((Action)delegate
            {
               this.AppendText(this.MessageIndicator + " WARN - " + message, this.WarningForeColor);
            });
         }
         else
            this.AppendText(this.MessageIndicator + " WARN - " + message, this.WarningForeColor);
      }

      public void Error(string message)
      {
         if (recConsole.InvokeRequired)
         {
            recConsole.Invoke((Action)delegate
            {
               this.AppendText(this.MessageIndicator + " ERROR - " + message, this.ErrorForeColor);
            });
         }
         else
            this.AppendText(this.MessageIndicator + " ERROR - " + message, this.ErrorForeColor);
      }

      public void Debug(string message)
      {
         if (recConsole.InvokeRequired)
         {
            recConsole.Invoke((Action)delegate
            {
               this.AppendText(this.MessageIndicator + " DEBUG - " + message, this.DebugForeColor);
            });
         }
         else
            this.AppendText(this.MessageIndicator + " DEBUG - " + message, this.DebugForeColor);
      }

      #endregion

      #region Event Handlers

      private void CmdClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         recConsole.Text = String.Empty;
      }

      #endregion

      #region Private Members

      private void AppendText(string message, Color color)
      {
         DocumentRange range = recConsole.Document.Paragraphs[recConsole.Document.Paragraphs.Count - 1].Range;
         CharacterProperties cp = recConsole.Document.BeginUpdateCharacters(range);
         cp.ForeColor = color;
         recConsole.Document.EndUpdateCharacters(cp);

         recConsole.Document.BeginUpdate();
         recConsole.Document.AppendText(message + Environment.NewLine);
         recConsole.Document.CaretPosition = recConsole.Document.Range.End;
         recConsole.Document.EndUpdate();

         recConsole.ScrollToCaret();
      }

        #endregion

    }
}
