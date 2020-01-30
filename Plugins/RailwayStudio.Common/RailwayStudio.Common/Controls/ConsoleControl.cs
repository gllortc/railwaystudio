using DevExpress.XtraRichEdit.API.Native;
using System;
using System.Drawing;

namespace RailwayStudio.Common.Controls
{
   public partial class ConsoleControl : DevExpress.XtraEditors.XtraUserControl
   {

      #region Constructors

      public ConsoleControl()
      {
         InitializeComponent();
         
         this.Initialize();
      }

      #endregion

      #region Properties

      public string MessageIndicator { get; set; }

      public Color InformationForeColor { get; set; }

      public Color WarningForeColor { get; set; }

      public Color ErrorForeColor { get; set; }

      #endregion

      #region Methods

      public void Information(string message)
      {
         this.AppendText(this.MessageIndicator + " " + message,
                         this.InformationForeColor);
      }

      public void Warning(string message)
      {
         this.AppendText(this.MessageIndicator + " WARN - " + message,
                         this.WarningForeColor);
      }

      public void Error(string message)
      {
         this.AppendText(this.MessageIndicator + " ERROR - " + message,
                         this.ErrorForeColor);
      }

      #endregion

      #region Private Members

      private void Initialize()
      {
         recConsole.Text = string.Empty;

         this.MessageIndicator = ">";

         this.InformationForeColor = Color.White;
         this.WarningForeColor = Color.LightYellow;
         this.ErrorForeColor = Color.Salmon;
      }

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
