using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Rwm.Otc.LayoutControl;
using Rwm.Otc.LayoutControl.Blocks;

namespace Rwm.Studio.Plugins.Control.Views
{
   public partial class FrmConnectionEditor : DevExpress.XtraEditors.XtraForm
   {
      public FrmConnectionEditor(int index, BlockBase block)
      {
         InitializeComponent();
         Initialize();

         this.ConnectionIndex = index;
         this.Block = block;
         this.Connection = new ControlModuleConnection(block);
      }

      public FrmConnectionEditor(int connectionIndex, BlockBase block, ControlModuleConnection connection)
      {
         InitializeComponent();
         Initialize();

         this.ConnectionIndex = connectionIndex;
         this.Block = block;
         this.Connection = connection;
      }

      public int ConnectionIndex { get; private set; }

      internal BlockBase Block { get; private set; }

      public ControlModuleConnection Connection { get; private set; }

      public ControlModule Decoder { get; private set; }

      private void txtOutput_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
      {
         FrmConnectionFinder form = new FrmConnectionFinder(ControlModule.ModuleType.Sensor, this.Connection);
         form.ShowDialog(this);

         if (form.DialogResult == DialogResult.OK)
         {
            this.Connection = form.SelectedConnection;
            this.Decoder = form.SelectedDecoder;

            Project.ControlModuleConnectionManager.Assign(this.Connection.ID, 
                                                          this.ConnectionIndex, 
                                                          this.Block.ID);

            ShowSelectedOutput();
         }
      }

      #region Private Members

      private void Initialize()
      {
         this.Block = null;
         this.Connection = null;
         this.Decoder = null;
      }

      private void ShowSelectedOutput()
      {
         if (this.Connection == null || this.Decoder == null)
         {
            txtOutput.Text = "Not connected";
         }
         else
         {
            txtOutput.Text = string.Format("<b>{0}</b> input <b>{1}</b> (address <b>{2}</b>)",
                                           this.Decoder.Name,
                                           this.Connection.Output,
                                           this.Connection.Address);
         }
      }

      #endregion
   }
}