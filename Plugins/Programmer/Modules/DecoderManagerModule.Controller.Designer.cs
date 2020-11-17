using System;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using Rwm.Otc;
using Rwm.Otc.Diagnostics;
using Rwm.Otc.Layout;
using Rwm.Studio.Plugins.Common;
using Rwm.Studio.Plugins.Designer.Arduino;
using Rwm.Studio.Plugins.Designer.Views;

namespace Rwm.Studio.Plugins.Designer.Modules
{
   public partial class DecoderManagerModule
   {

      #region Enumerations

      public enum ViewType : int
      {
         GroupByType = 0,
         GroupByArea = 1
      }

      #endregion

      #region Properties

      public ViewType CurrentViewType { get; private set; } = ViewType.GroupByType;

      #endregion

      #region Methods

      internal void AccessoryDecoderAdd()
      {
         AccessoryDecoderWizardView wizard = new AccessoryDecoderWizardView();
         if (wizard.ShowDialog(this) == DialogResult.OK)
         {
            AccessoryDecoderEditorView editor = new AccessoryDecoderEditorView(wizard.Decoder);
            if (editor.ShowDialog(this) == DialogResult.OK)
            {
               this.RefreshTreeList();
            }
         }
      }

      internal void RwmAccessoryDecoderAdd()
      {
         RwmDecoderEditorView form = new RwmDecoderEditorView();
         if (form.ShowDialog(this) == DialogResult.OK)
         {
            this.RefreshTreeList();
         }
      }

      internal void FeedbackEncoderAdd()
      {
         FeedbackEncoderWizardView wizard = new FeedbackEncoderWizardView();
         if (wizard.ShowDialog(this) == DialogResult.OK)
         {
            FeedbackEncoderEditorView editor = new FeedbackEncoderEditorView(wizard.Encoder);
            if (editor.ShowDialog(this) == DialogResult.OK)
            {
               this.RefreshTreeList();
            }
         }
      }

      internal void EditItem()
      {
         if (tlsDecoders.Selection.Count <= 0)
         {
            MessageBox.Show("No items selected.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         TreeListNode node = tlsDecoders.Selection[0];
         if (node.Tag is AccessoryDecoder)
         {
            AccessoryDecoderEditorView form = new AccessoryDecoderEditorView((AccessoryDecoder)node.Tag);
            form.ShowDialog(this);
         }
         else if (node.Tag is FeedbackEncoder)
         {
            FeedbackEncoderEditorView form = new FeedbackEncoderEditorView((FeedbackEncoder)node.Tag);
            form.ShowDialog(this);
         }
      }

      internal void DeleteItem()
      {
         if (tlsDecoders.Selection.Count <= 0)
         {
            MessageBox.Show("No items selected.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         TreeListNode node = tlsDecoders.Selection[0];

         if (node == null)
         {
            return;
         }
         else if (MessageBox.Show("Are you sure you want to delete the device " + node[tlsDecoders.Columns[0]] + "?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
         {
            return;
         }

         try
         {
            if (node.Tag is AccessoryDecoder)
            {
               AccessoryDecoder.Delete((AccessoryDecoder)node.Tag);
            }
            else if (node.Tag is FeedbackEncoder)
            {
               FeedbackEncoder.Delete((FeedbackEncoder)node.Tag);
            }

            this.RefreshTreeList();
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
         }
      }

      internal void DecoderProgram()
      {
         try
         {
            Sketch sketch = new Sketch(new Otc.Layout.AccessoryDecoder());
            sketch.Create(false);
            sketch.Build(StudioContext.UI.LogConsoleControl);
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      internal void SetListByType()
      {
         this.CurrentViewType = ViewType.GroupByType;
         this.RefreshTreeList();
      }

      internal void SetListByArea()
      {
         this.CurrentViewType = ViewType.GroupByArea;
         this.RefreshTreeList();
      }

      internal void RefreshTreeList()
      {
         int count;

         tlsDecoders.ClearNodes();

         switch (this.CurrentViewType)
         {
            case ViewType.GroupByArea:
               count = this.ListByArea();
               break;

            default:
               count = this.ListByType();
               break;
         }

         bsiElementCounter.Caption = string.Format("{0} device(s) listed", count);
      }

      internal void ReportsDigitalAddresses()
      {

      }

      #endregion

      #region Private Members

      private void InitializeTreeList()
      {
         TreeListColumn col = null;

         tlsDecoders.BeginUpdate();

         tlsDecoders.Columns.Clear();

         // Configure the columns
         col = tlsDecoders.Columns.Add();
         col.Caption = "Name";
         col.VisibleIndex = 0;

         col = tlsDecoders.Columns.Add();
         col.Caption = "Type";
         col.VisibleIndex = 1;

         col = tlsDecoders.Columns.Add();
         col.Caption = "Model";
         col.VisibleIndex = 2;

         col = tlsDecoders.Columns.Add();
         col.Caption = "Connections";
         col.VisibleIndex = 3;

         col = tlsDecoders.Columns.Add();
         col.Caption = "Used";
         col.VisibleIndex = 4;

         tlsDecoders.EndUpdate();
      }

      private int ListByType()
      {
         int count = 0;
         TreeListNode rootNode = null;
         TreeListNode parentNode = null;
         TreeListNode node = null;

         tlsDecoders.BeginUnboundLoad();

         // Create a root node
         rootNode = tlsDecoders.AppendNode(new object[] { "Digital modules" }, null);
         rootNode.StateImageIndex = 0;
         rootNode.Expanded = true;

         // Create accessory decoders nodes
         parentNode = tlsDecoders.AppendNode(new object[] { "Accessory decoders" }, rootNode);
         parentNode.StateImageIndex = 1;
         parentNode.Expanded = true;

         foreach (AccessoryDecoder accDecoder in OTCContext.Project.AccessoryDecoders)
         {
            node = tlsDecoders.AppendNode(new object[] { accDecoder.Name, "Generic", accDecoder.Model, accDecoder.Outputs.Count, accDecoder.Outputs.Count }, parentNode);
            node.Tag = accDecoder;
            node.StateImageIndex = 2;
            count++;
         }

         // Create feedback encoders nodes
         parentNode = tlsDecoders.AppendNode(new object[] { "Feedback encoders" }, rootNode);
         parentNode.StateImageIndex = 1;
         parentNode.Expanded = true;

         foreach (FeedbackEncoder fbEncoder in OTCContext.Project.FeedbackEncoders)
         {
            node = tlsDecoders.AppendNode(new object[] { fbEncoder.Name, "Generic", fbEncoder.Model, fbEncoder.Inputs.Count, fbEncoder.ConnectionsCount }, parentNode);
            node.Tag = fbEncoder;
            node.StateImageIndex = 3;
            count++;
         }

         tlsDecoders.Nodes[0].Expanded = true;
         tlsDecoders.Nodes[0].Nodes[0].Expanded = true;
         tlsDecoders.Nodes[0].Nodes[1].Expanded = true;

         tlsDecoders.EndUnboundLoad();

         return count;
      }

      private int ListByArea()
      {
         int count = 0;
         TreeListNode rootNode = null;
         TreeListNode parentNode = null;
         TreeListNode node = null;

         tlsDecoders.BeginUnboundLoad();

         foreach (Module area in OTCContext.Project.Sections)
         {
            rootNode = tlsDecoders.AppendNode(new object[] { area.Name }, null);
            rootNode.StateImageIndex = 0;

            // Create accessory decoders nodes
            parentNode = tlsDecoders.AppendNode(new object[] { "Accessory decoders" }, rootNode);
            parentNode.StateImageIndex = 1;
            parentNode.Expanded = true;

            foreach (AccessoryDecoder accDecoder in OTCContext.Project.AccessoryDecoders)
            {
               if (accDecoder.Module == area)
               {
                  node = tlsDecoders.AppendNode(new object[] { accDecoder.Name, "Generic", accDecoder.Model, accDecoder.Outputs.Count, accDecoder.Outputs.Count }, parentNode);
                  node.Tag = accDecoder;
                  node.StateImageIndex = 2;
                  count++;
               }
            }

            parentNode.Expanded = true;
            if (!parentNode.HasChildren) rootNode.Nodes.Remove(parentNode);

            // Create feedback encoders nodes
            parentNode = tlsDecoders.AppendNode(new object[] { "Feedback encoders" }, rootNode);
            parentNode.StateImageIndex = 1;
            parentNode.Expanded = true;

            foreach (FeedbackEncoder fbEncoder in OTCContext.Project.FeedbackEncoders)
            {
               if (fbEncoder.Module == area)
               {
                  node = tlsDecoders.AppendNode(new object[] { fbEncoder.Name, "Generic", fbEncoder.Model, fbEncoder.Inputs.Count, fbEncoder.ConnectionsCount }, parentNode);
                  node.Tag = fbEncoder;
                  node.StateImageIndex = 3;
                  count++;
               }
            }

            parentNode.Expanded = true;
            if (!parentNode.HasChildren) rootNode.Nodes.Remove(parentNode);

            rootNode.Expanded = true;
         }

         rootNode = tlsDecoders.AppendNode(new object[] { "Unspecified zone" }, null);
         rootNode.StateImageIndex = 0;
         rootNode.Expanded = true;

         // Create accessory decoders nodes
         parentNode = tlsDecoders.AppendNode(new object[] { "Accessory decoders" }, rootNode);
         parentNode.StateImageIndex = 1;
         parentNode.Expanded = true;

         foreach (AccessoryDecoder accDecoder in OTCContext.Project.AccessoryDecoders)
         {
            if (accDecoder.Module == null)
            {
               node = tlsDecoders.AppendNode(new object[] { accDecoder.Name, "Generic", accDecoder.Model, accDecoder.Outputs.Count, accDecoder.Outputs.Count }, parentNode);
               node.Tag = accDecoder;
               node.StateImageIndex = 2;
               count++;
            }
         }

         parentNode.Expanded = true;
         if (!parentNode.HasChildren) rootNode.Nodes.Remove(parentNode);

         rootNode.Expanded = true;

         // Create feedback encoders nodes
         parentNode = tlsDecoders.AppendNode(new object[] { "Feedback encoders" }, rootNode);
         parentNode.StateImageIndex = 1;
         parentNode.Expanded = true;

         foreach (FeedbackEncoder fbEncoder in OTCContext.Project.FeedbackEncoders)
         {
            if (fbEncoder.Module == null)
            {
               node = tlsDecoders.AppendNode(new object[] { fbEncoder.Name, fbEncoder.Model, fbEncoder.Inputs.Count, fbEncoder.ConnectionsCount }, parentNode);
               node.Tag = fbEncoder;
               node.StateImageIndex = 3;
               count++;
            }
         }

         parentNode.Expanded = true;
         if (!parentNode.HasChildren) rootNode.Nodes.Remove(parentNode);

         //tlsDecoders.Nodes[0].Expanded = true;
         //tlsDecoders.Nodes[0].Nodes[0].Expanded = true;
         //tlsDecoders.Nodes[0].Nodes[1].Expanded = true;

         tlsDecoders.EndUnboundLoad();

         return count;
      }

      #endregion

   }
}
