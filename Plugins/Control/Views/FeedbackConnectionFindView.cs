using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using Rwm.Otc;
using Rwm.Otc.Layout;

namespace Rwm.Studio.Plugins.Control.Views
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

      public FeedbackConnectionFindView(FeedbackDecoderConnection connection)
      {
         InitializeComponent();
         ShowInputs(connection);

         chkShowUnused.Checked = true;
      }

      #endregion

      #region Properties

      public FeedbackDecoderConnection SelectedConnection { get; private set; }

      public FeedbackDecoder SelectedDecoder { get; private set; }

      public bool ShowUsedConnections
      {
         get { return !chkShowUnused.Checked; }
      }

      #endregion

      #region Event Handlers

      private void chkShowUnused_CheckedChanged(object sender, System.EventArgs e)
      {
         this.FilterUsedConnections(tvwConnections.Nodes[0], chkShowUnused.Checked);
      }

      private void cmdOK_Click(object sender, System.EventArgs e)
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

         this.SelectedDecoder = tvwConnections.FocusedNode.ParentNode.Tag as FeedbackDecoder;
         this.SelectedConnection = tvwConnections.FocusedNode.Tag as FeedbackDecoderConnection;

         this.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.Close();
      }

      private void cmdCancel_Click(object sender, System.EventArgs e)
      {
         this.SelectedDecoder = null;
         this.SelectedConnection = null;

         this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.Close();
      }

      #endregion

      #region Private Members

      private void ShowInputs()
      {
         this.ShowInputs(null);
      }

      void ShowInputs(FeedbackDecoderConnection connection)
      {
         TreeListNode root;
         TreeListNode mod;
         TreeListNode output;
         TreeListColumn col;
         Dictionary<int, FeedbackDecoderConnection> connections;

         tvwConnections.BeginUpdate();
         col = tvwConnections.Columns.Add();
         col.Caption = "Name";
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

         foreach (FeedbackDecoder module in OTCContext.Project.FeedbackDecoders)
         {
               mod = tvwConnections.AppendNode(new object[] { module.Name, string.Empty, string.Empty }, root);
               mod.StateImageIndex = 1;
               mod.Tag = module;

               connections = new Dictionary<int, FeedbackDecoderConnection>();

               // Create the non existing connections
               foreach (FeedbackDecoderConnection inputConn in module.Connections)
                  connections.Add(inputConn.DecoderOutput, inputConn);

               for (int inputidx = 1; inputidx <= module.Inputs; inputidx++)
                  if (!connections.ContainsKey(inputidx))
                     connections.Add(inputidx, new FeedbackDecoderConnection() { DecoderOutput = inputidx, 
                                                                                 Address = module.StartAddress + inputidx - 1, 
                                                                                 Device = module, 
                                                                                 Element = null }) ;

               foreach (FeedbackDecoderConnection con in connections.Values)
               {
                  if (con.IsNew || this.ShowUsedConnections)
                  {
                     output = tvwConnections.AppendNode(new object[] { con.DecoderOutput,
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
               FeedbackDecoderConnection output = node.Tag as FeedbackDecoderConnection;
               node.Visible = !unusedOnly || (output?.Element == null);
            }
         }
      }

      #endregion

   }
}