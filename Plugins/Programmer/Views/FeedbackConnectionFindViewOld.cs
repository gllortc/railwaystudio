using System.Collections.Generic;
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

      public FeedbackConnectionFindView()
      {
         InitializeComponent();
         ShowInputs();

         chkShowUnused.Checked = true;
      }

      public FeedbackConnectionFindView(FeedbackEncoderInput connection)
      {
         InitializeComponent();
         ShowInputs(connection);

         chkShowUnused.Checked = true;
      }

      #endregion

      #region Properties

      public FeedbackEncoderInput SelectedConnection { get; private set; }

      public FeedbackEncoder SelectedDecoder { get; private set; }

      public bool ShowUsedConnections
      {
         get { return !chkShowUnused.Checked; }
      }

      #endregion

      #region Event Handlers

      private void ChkShowUnused_CheckedChanged(object sender, System.EventArgs e)
      {
         this.FilterUsedConnections(tvwConnections.Nodes[0], chkShowUnused.Checked);
      }

      private void CmdDecoderNew_Click(object sender, System.EventArgs e)
      {
         FeedbackEncoderEditorView form = new FeedbackEncoderEditorView();
         if (form.ShowDialog() == DialogResult.OK)
         {
            this.ShowInputs(this.SelectedConnection);
         }
      }

      private void CmdOK_Click(object sender, System.EventArgs e)
      {
         if (tvwConnections.FocusedNode == null)
         {
            MessageBox.Show("You must select the control module output you want to connect the element.",
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }
         else if (tvwConnections.FocusedNode.StateImageIndex == 1 || tvwConnections.FocusedNode.StateImageIndex == 4)
         {
            MessageBox.Show("The selected node is not a control module output.",
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }
         else if (tvwConnections.FocusedNode.StateImageIndex == 3)
         {
            if (MessageBox.Show("The selected output is used by another element. Really you want to share this output?",
                                Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
            {
               return;
            }
         }

         this.SelectedDecoder = tvwConnections.FocusedNode.ParentNode.Tag as FeedbackEncoder;
         this.SelectedConnection = tvwConnections.FocusedNode.Tag as FeedbackEncoderInput;

         this.DialogResult = DialogResult.OK;
         this.Close();
      }

      private void CmdCancel_Click(object sender, System.EventArgs e)
      {
         this.SelectedDecoder = null;
         this.SelectedConnection = null;

         this.DialogResult = DialogResult.Cancel;
         this.Close();
      }

      #endregion

      #region Private Members

      private void ShowInputs()
      {
         this.ShowInputs(null);
      }

      void ShowInputs(FeedbackEncoderInput connection)
      {
         TreeListNode root;
         TreeListNode mod;
         TreeListNode output;
         TreeListColumn col;
         Dictionary<int, FeedbackEncoderInput> connections;

         tvwConnections.BeginUpdate();

         tvwConnections.Nodes.Clear();
         tvwConnections.Columns.Clear();

         col = tvwConnections.Columns.Add();
         col.Caption = "Decoder input";
         col.VisibleIndex = 0;
         col = tvwConnections.Columns.Add();
         col.Caption = "Address";
         col.VisibleIndex = 1;
         col = tvwConnections.Columns.Add();
         col.Caption = "Element";
         col.VisibleIndex = 2;
         tvwConnections.EndUpdate();

         tvwConnections.BeginUnboundLoad();

         root = tvwConnections.AppendNode(new object[] { "Modules", string.Empty, string.Empty }, null);
         root.StateImageIndex = 4;
         root.Expanded = true;

         foreach (FeedbackEncoder decoder in OTCContext.Project.FeedbackEncoders)
         {
            mod = tvwConnections.AppendNode(new object[] { decoder.Name, string.Empty, string.Empty }, root);
            mod.StateImageIndex = 1;
            mod.Tag = decoder;

            connections = new Dictionary<int, FeedbackEncoderInput>();

            // Create the non existing connections
            foreach (FeedbackEncoderInput inputConn in decoder.Connections)
               connections.Add(inputConn.DecoderInput, inputConn);

            for (int inputidx = 1; inputidx <= decoder.Inputs; inputidx++)
               if (!connections.ContainsKey(inputidx))
                  connections.Add(inputidx, new FeedbackEncoderInput()
                  {
                     DecoderInput = inputidx,
                     Address = decoder.StartAddress + inputidx - 1,
                     Device = decoder,
                     Element = null
                  });

            foreach (FeedbackEncoderInput con in connections.Values)
            {
               if (con.IsNew || this.ShowUsedConnections)
               {
                  output = tvwConnections.AppendNode(new object[] { con.DecoderInput,
                                                                    con.Address.ToString("D4"),
                                                                    con.Element == null ? "<empty>" : con.Element.Name}, mod);
                  output.StateImageIndex = (con.Element == null ? 2 : 3);
                  output.Tag = con;

                  if (connection?.ID == con.ID)
                  {
                     tvwConnections.FocusedNode = output;
                  }
               }
            }
         }

         if (tvwConnections.FocusedNode != null && tvwConnections.FocusedNode != root)
         {
            tvwConnections.MakeNodeVisible(tvwConnections.FocusedNode);
         }
         else
         {
            root.Expanded = true;
         }

         tvwConnections.EndUnboundLoad();
      }

      private void FilterUsedConnections(TreeListNode root, bool unusedOnly)
      {
         foreach (TreeListNode node in root.Nodes)
         {
            if (node.HasChildren)
            {
               this.FilterUsedConnections(node, unusedOnly);
            }
            else
            {
               FeedbackEncoderInput output = node.Tag as FeedbackEncoderInput;
               node.Visible = !unusedOnly || (output?.Element == null);
            }
         }
      }

      #endregion

   }
}