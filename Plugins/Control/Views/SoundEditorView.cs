using Rwm.Otc.Layout;
using System;
using System.IO;
using System.Windows.Forms;

namespace Rwm.Studio.Plugins.Control.Views
{
   public partial class SoundEditorView : DevExpress.XtraEditors.XtraForm
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="SoundEditorView"/>.
      /// </summary>
      public SoundEditorView()
      {
         InitializeComponent();

         this.Sound = new Sound();
         this.UpdateSoundFile = false;
      }

      /// <summary>
      /// Returns a new instance of <see cref="SoundEditorView"/>.
      /// </summary>
      /// <param name="sound">Sound to edit.</param>
      public SoundEditorView(Sound sound)
      {
         InitializeComponent();

         this.Sound = sound;
         this.UpdateSoundFile = false;

         txtName.Text = sound.Name;
         txtFilename.Text = sound.Filename;
      }

      #endregion

      #region Properties

      internal bool UpdateSoundFile { get; private set; }

      public Sound Sound { get; private set; }

      #endregion

      #region Event Handlers

      private void txtFilename_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
      {
         OpenFileDialog dialog = new OpenFileDialog();
         dialog.Title = "Select sound file";
         dialog.Filter = "WAV sound files|*.wav|All files|*.*";

         if (dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
         {
            txtFilename.Text = Path.GetFileName(dialog.FileName);
            txtFilename.Tag = dialog.FileName;
            this.UpdateSoundFile = true;
         }
      }

      private void cmdOK_Click(object sender, EventArgs e)
      {
         try
         {
            // Store the element properties
            this.Sound.Name = txtName.Text.Trim();
            this.Sound.Filename = txtFilename.Text;

            if (this.Sound.ID <= 0)
            {
               this.Sound.Filename = txtFilename.Tag.ToString();
            }
            else
            {
               if (this.UpdateSoundFile) this.Sound.Filename = txtFilename.Tag.ToString();
            }

            Rwm.Otc.Layout.Sound.Save(this.Sound);
            
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
         }
         catch (Exception ex)
         {
            MessageBox.Show("ERROR storing data:" + Environment.NewLine + Environment.NewLine + ex.Message, 
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void cmdCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.Close();
      }

      #endregion

   }
}