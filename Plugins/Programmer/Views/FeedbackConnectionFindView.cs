using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using Rwm.Otc;
using Rwm.Otc.Layout;

namespace Rwm.Studio.Plugins.Designer.Views
{
    public partial class FeedbackConnectionFindView : DevExpress.XtraEditors.XtraForm
   {

      #region Constructors

      public FeedbackConnectionFindView(FeedbackEncoderConnection connection = null)
      {
         InitializeComponent();

         this.SelectedInput = connection?.EncoderInput;

         this.RefreshOutputsList(chkShowAll.Checked);
      }

      #endregion

      #region Properties

      public FeedbackEncoderInput SelectedInput { get; private set; } = null;

      #endregion

      #region Event Handlers

      private void TvwOutputs_NodeCellStyle(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
      {
         if (e.Node.Tag is FeedbackEncoderInput input)
         {
            if (input.FeedbackConnection != null)
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
            this.SelectedInput = null;
         }
         else if (tvwOutputs.Selection[0].Tag is FeedbackEncoderInput selected)
         {
            this.SelectedInput = selected;
         }

         cmdOK.Enabled = (this.SelectedInput != null);
      }

      private void ChkShowAll_CheckedChanged(object sender, EventArgs e)
      {
         this.RefreshOutputsList(chkShowAll.Checked);
      }

      private void CmdOK_Click(object sender, EventArgs e)
      {
         if (this.SelectedInput == null)
         {
            MessageBox.Show("You must select a non connected input.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         this.DialogResult = DialogResult.OK;
         this.Close();
      }

      private void CmdCancel_Click(object sender, EventArgs e)
      {
         this.SelectedInput = null;

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
            column.Caption = "Encoder";
            column.Width = 100;
            column.VisibleIndex = 0;
            // column.FieldName = "AccessoryDecoder.Name";

            column = tvwOutputs.Columns.Add();
            column.Caption = "Input";
            column.Width = 55;
            column.VisibleIndex = 1;
            // column.FieldName = "Index";

            column = tvwOutputs.Columns.Add();
            column.Caption = "Address";
            column.Width = 80;
            column.VisibleIndex = 2;
            // column.FieldName = "DisplayAddress";

            column = tvwOutputs.Columns.Add();
            column.Caption = "Point";
            column.Width = 200;
            column.VisibleIndex = 3;
            // column.FieldName = "DisplayConfiguration";

            tvwOutputs.EndUpdate();
         }

         tvwOutputs.BeginUnboundLoad();

         tvwOutputs.Nodes.Clear();

         nodeSection = tvwOutputs.AppendNode(new object[] { "Global area" }, null);
         nodeSection.Tag = null;

         foreach (FeedbackEncoder encoder in OTCContext.Project.FeedbackEncoders)
         {
            if (encoder.Module == null)
            {
               foreach (FeedbackEncoderInput input in encoder.Inputs)
               {
                  if (showAll || input.FeedbackConnection == null)
                  {
                     nodeOutput = tvwOutputs.AppendNode(new object[] { encoder.Name, input.Index, input.Address, input.PointAddress }, nodeSection);
                     nodeOutput.Tag = input;
                  }
               }
            }
         }

         foreach (Module section in OTCContext.Project.Sections)
         {
            nodeSection = tvwOutputs.AppendNode(new object[] { section.Name }, null);
            nodeSection.Tag = section;

            foreach (FeedbackEncoder encoder in OTCContext.Project.FeedbackEncoders)
            {
               if (encoder.Module == section)
               {
                  foreach (FeedbackEncoderInput inputs in encoder.Inputs)
                  {
                     if (showAll || inputs.FeedbackConnection == null)
                     {
                        nodeOutput = tvwOutputs.AppendNode(new object[] { encoder.Name, inputs.Index, inputs.Address, inputs.PointAddress }, nodeSection);
                        nodeOutput.Tag = inputs;
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