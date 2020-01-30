using System;
using System.Drawing;
using System.Windows.Forms;

namespace otc.forms.controls
{
   /// <summary>
   /// Enumera los tipos de mensaje que puede mostrar el control.
   /// </summary>
   public enum MessageTypes
   {
      /// <summary>Mensaje informativo.</summary>
      Information,
      /// <summary>Mensaje de advertencia.</summary>
      Warning,
      /// <summary>Mensaje de error.</summary>
      Error
   }

   /// <summary>
   /// Implementa un control para mostrar información de texto similar a una consola.
   /// </summary>
   public partial class OutputConsoleControl : UserControl
   {
      private bool _showToolbar;
      private bool _showInfos;
      private bool _showWarns;
      private bool _showErrs;
      private Color _infomationColor = Color.Black;
      private Color _warningColor = Color.Blue;
      private Color _errorColor = Color.Red;
      private Color _backColor = Color.White;

      /// <summary>
      /// Devuelve una instancia de OutputControl.
      /// </summary>
      public OutputConsoleControl()
      {
         InitializeComponent();

         rtfOutput.BackColor = _backColor;
         rtfOutput.ForeColor = _infomationColor;
         CheckForIllegalCrossThreadCalls = false;

         _showInfos = true;
         _showWarns = true;
         _showErrs = true;
      }

      /// <summary>
      /// Establece o devuelve el color del texto para mensajes informativos.
      /// </summary>
      public Color TextBackColor
      {
         get { return _backColor; }
         set 
         { 
            _backColor = value;
            rtfOutput.BackColor = value;
         }
      }

      /// <summary>
      /// Establece o devuelve el color del texto para mensajes informativos.
      /// </summary>
      public Color TextColorInformation
      {
         get { return _infomationColor; }
         set { _infomationColor = value; }
      }

      /// <summary>
      /// Establece o devuelve el color del texto para mensajes de adverténcia.
      /// </summary>
      public Color TextColorWarning
      {
         get { return _warningColor; }
         set { _warningColor = value; }
      }

      /// <summary>
      /// Establece o devuelve el color del texto para mensajes de error.
      /// </summary>
      public Color TextColorError
      {
         get { return _errorColor; }
         set { _errorColor = value; }
      }

      /// <summary>
      /// Indica si se debe mostrar la barra de herramientas.
      /// </summary>
      public bool ToolbarVisible
      {
         get { return _showToolbar; }
         set 
         { 
            _showToolbar = value;
            tbrOutput.Visible = value;
         }
      }

      /// <summary>
      /// Limpia el contenido del control.
      /// </summary>
      public void Clear()
      {
         rtfOutput.Text = "";
      }

      /// <summary>
      /// Copia el texto seleccionado (o todo si no existe selección) al Portapapeles.
      /// </summary>
      public void Copy()
      {
         if (rtfOutput.SelectionLength > 0)
         {
            rtfOutput.Copy();
         }
         else
         {
            rtfOutput.SelectionStart = 0;
            rtfOutput.SelectionLength = rtfOutput.Text.Length;
            rtfOutput.Copy();
            rtfOutput.SelectionLength = 0;
         }
      }

      /// <summary>
      /// Guarda el contenido completo del control a un archivo RTF.
      /// </summary>
      /// <param name="filename"></param>
      public void Save(string filename)
      {
         rtfOutput.SaveFile(filename);
      }

      /// <summary>
      /// Muestra el texto especificado en el control.
      /// </summary>
      /// <param name="Text">Texto a mostrar.</param>
      /// <param name="Type">Tipo de mensaje.</param>
      public void ShowMessage(string Text, MessageTypes Type)
      {
         switch (Type)
         {
            case MessageTypes.Information:
               if (!_showInfos) return;
               rtfOutput.SelectionColor = _infomationColor; 
               break;
            case MessageTypes.Warning:
               if (!_showWarns) return;
               rtfOutput.SelectionColor = _warningColor; 
               break;
            case MessageTypes.Error:
               if (!_showErrs) return;
               rtfOutput.SelectionColor = _errorColor; 
               break;
         }

         if (!Text.Equals("")) Text += "\n";

         // Establece la selección al último carácter
         rtfOutput.SelectionStart = rtfOutput.Text.Length;
         rtfOutput.SelectionLength = 0;
         rtfOutput.SelectedText = "> " + Text;
         rtfOutput.ScrollToCaret();
      }

      /// <summary>
      /// Muestra el texto especificado en el control.
      /// </summary>
      /// <param name="Text">Texto a mostrar.</param>
      /// <param name="Color">Color a usar para representar el texto.</param>
      public void ShowMessage(string Text, Color Color)
      {
         rtfOutput.SelectionColor = Color;
         if (!Text.Equals("")) Text += "\n";

         // Establece la selección al último carácter
         rtfOutput.SelectionStart = rtfOutput.Text.Length;
         rtfOutput.SelectionLength = 0;
         rtfOutput.SelectedText = "> " + Text;
         rtfOutput.ScrollToCaret();
      }

      #region Event Handlers

      private void btnSave_Click(object sender, EventArgs e)
      {
         SaveFileDialog save = new SaveFileDialog();
         save.Title = "Guardar a archivo";
         save.Filter = "Archivo de texto enriquecido|*.rtf|Archivo de texto|*.txt";
         
         if (save.ShowDialog() == DialogResult.Cancel) return;

         this.Save(save.FileName);
      }

      private void btnCopy_Click(object sender, EventArgs e)
      {
         this.Copy();
      }

      private void btnClear_Click(object sender, EventArgs e)
      {
         this.Clear();
      }

      private void rtfOutput_KeyDown(object sender, KeyEventArgs e)
      {
         e.SuppressKeyPress = true;
      }

      private void btnShowInfo_CheckedChanged(object sender, EventArgs e)
      {
         _showInfos = btnShowInfo.Checked;
      }

      private void btnShowWarn_CheckedChanged(object sender, EventArgs e)
      {
         _showWarns = btnShowWarn.Checked;
      }

      private void btnShowErr_CheckedChanged(object sender, EventArgs e)
      {
         _showErrs = btnShowErr.Checked;
      }

      #endregion

   }
}
