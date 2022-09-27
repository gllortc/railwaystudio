using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using Rwm.Otc;
using Rwm.Otc.Layout;

namespace Rwm.Studio.Plugins.Designer.Views
{
    public partial class AccesoryConnectionFindView : DevExpress.XtraEditors.XtraForm
   {

      #region Constructors

      public AccesoryConnectionFindView(AccessoryDecoderConnection connection = null)
      {
         InitializeComponent();

         this.SelectedOutput = connection?.DecoderOutput;

         this.RefreshOutputsList(chkShowAll.Checked);
      }

      #endregion

      #region Properties

      public AccessoryDecoderOutput SelectedOutput { get; private set; } = null;

      #endregion

      #region Event Handlers

      private void TvwOutputs_NodeCellStyle(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
      {
         if (e.Node.Tag is AccessoryDecoderOutput output)
         {
            if (output.AccessoryConnection != null)
            {
               e.Appearance.BackColor = Color.LightSalmon;
               e.Appearance.BackColor2 = Color.LightSalmon;
            }
         }
         else if (e.Node.Tag == null || e.Node.Tag is Module)
         {
            e.Appearance.FontStyleDelta = FontStyle.Bold;
         }
      }

      private void TvwOutputs_Click(object sender, EventArgs e)
      {
         if (tvwOutputs.Selection.Count <= 0)
         {
            this.SelectedOutput = null;
         }
         else if (tvwOutputs.Selection[0].Tag is AccessoryDecoderOutput selected)
         {
            this.SelectedOutput = selected;
         }

         cmdOK.Enabled = (this.SelectedOutput != null);
      }

      private void ChkShowAll_CheckedChanged(object sender, EventArgs e)
      {
         this.RefreshOutputsList(chkShowAll.Checked);
      }

      private void CmdOK_Click(object sender, EventArgs e)
      {
         if (this.SelectedOutput == null)
         {
            MessageBox.Show("You must select a non connected output.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         this.DialogResult = DialogResult.OK;
         this.Close();
      }

      private void CmdCancel_Click(object sender, EventArgs e)
      {
         this.SelectedOutput = null;

         this.DialogResult = DialogResult.Cancel;
         this.Close();
      }

      #endregion

      #region Private Members

      private void RefreshOutputsList(bool showAll = true)
      {
         TreeListColumn column;
         TreeListNode nodeSection, nodeOutput;

         if (tvwOutputs.Columns.Count <= 0)
         {
            tvwOutputs.BeginUpdate();

            column = tvwOutputs.Columns.Add();
            column.Caption = "Decoder";
            column.Width = 100;
            column.VisibleIndex = 0;
            // column.FieldName = "AccessoryDecoder.Name";

            column = tvwOutputs.Columns.Add();
            column.Caption = "Output";
            column.Width = 55;
            column.VisibleIndex = 1;
            // column.FieldName = "Index";

            column = tvwOutputs.Columns.Add();
            column.Caption = "Address";
            column.Width = 80;
            column.VisibleIndex = 2;
            // column.FieldName = "DisplayAddress";

            column = tvwOutputs.Columns.Add();
            column.Caption = "Mode";
            column.Width = 200;
            column.VisibleIndex = 3;
            // column.FieldName = "DisplayConfiguration";

            tvwOutputs.EndUpdate();
         }

         tvwOutputs.BeginUnboundLoad();

         tvwOutputs.Nodes.Clear();

         nodeSection = tvwOutputs.AppendNode(new object[] { "Global area" }, null);
         nodeSection.Tag = null;

         foreach (AccessoryDecoder decoder in OTCContext.Project.AccessoryDecoders)
         {
            if (decoder.Module == null)
            {
               foreach (AccessoryDecoderOutput output in decoder.Outputs)
               {
                  if (showAll || output.AccessoryConnection == null)
                  {
                     nodeOutput = tvwOutputs.AppendNode(new object[] { decoder.Name, output.Index, output.DisplayAddress, output.DisplayConfiguration }, nodeSection);
                     nodeOutput.Tag = output;
                  }
               }
            }
         }

         foreach (Module section in OTCContext.Project.Modules)
         {
            nodeSection = tvwOutputs.AppendNode(new object[] { section.Name }, null);
            nodeSection.Tag = section;

            foreach (AccessoryDecoder decoder in OTCContext.Project.AccessoryDecoders)
            {
               if (decoder.Module == section)
               {
                  foreach (AccessoryDecoderOutput output in decoder.Outputs)
                  {
                     if (showAll || output.AccessoryConnection == null)
                     {
                        nodeOutput = tvwOutputs.AppendNode(new object[] { decoder.Name, output.Index, output.DisplayAddress, output.DisplayConfiguration }, nodeSection);
                        nodeOutput.Tag = output;
                     }
                  }
               }
            }
         }

         foreach (TreeListNode node in tvwOutputs.Nodes)
         {
            if (!node.HasChildren)
               node.Visible = false;
            else
               node.Expanded = true;
         }

         tvwOutputs.EndUnboundLoad();
      }

      #endregion

   }
}