using System;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using Rwm.Otc;
using Rwm.Otc.Diagnostics;
using Rwm.Otc.Layout;
using Rwm.Otc.Layout.EasyConnect;
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

      #region Constants

      private const string SETTING_LIST_TYPE = "DecoderManagerModule.list.type";

      #endregion

      #region Properties

      public ViewType CurrentViewType { get; private set; } = ViewType.GroupByType;

      #endregion

      #region Methods

      internal void LayoutModuleAdd()
      {
         ModuleEditorView form = new ModuleEditorView();
         if (form.ShowDialog(this) == DialogResult.OK)
         {
            this.RefreshTreeList();
         }
      }

      internal void AccessoryDecoderAdd()
      {
         AccessoryDecoderWizardView wizard = new AccessoryDecoderWizardView();
         if (wizard.ShowDialog(this) == DialogResult.OK)
         {
            wizard.Decoder.Module = (tlsDecoders.Selection.Count > 0 ? tlsDecoders.Selection[0].Tag as Module : null);

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

      internal void RwmEMotionModuleAdd()
      {
         RwmEMotionEditorView form = new RwmEMotionEditorView();
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
            wizard.Encoder.Module = (tlsDecoders.Selection.Count > 0 ? tlsDecoders.Selection[0].Tag as Module : null);

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
         if (node == null) return;

         if (node.Tag is AccessoryDecoder)
         {
            AccessoryDecoder decoder = node.Tag as AccessoryDecoder;
            if (decoder == null) return;

            AccessoryDecoderEditorView form = new AccessoryDecoderEditorView(decoder);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
               this.RefreshTreeList();
            }
         }
         else if (node.Tag is FeedbackEncoder)
         {
            FeedbackEncoder encoder = node.Tag as FeedbackEncoder;
            if (encoder == null) return;

            FeedbackEncoderEditorView form = new FeedbackEncoderEditorView(encoder);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
               this.RefreshTreeList();
            }
         }
         else if (node.Tag is Module)
         {
            Module module = node.Tag as Module;
            if (module == null) return;

            ModuleEditorView form = new ModuleEditorView(module);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
               this.RefreshTreeList();
            }
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
         if (node == null) return;

         try
         {
            if (node.Tag is AccessoryDecoder)
            {
               AccessoryDecoder decoder = node.Tag as AccessoryDecoder;
               if (decoder == null) return;

               if (MessageBox.Show("Are you sure you want to delete the accessory decoder " + decoder.Name + "?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
               {
                  AccessoryDecoder.Delete(decoder);
                  this.RefreshTreeList();
               }
            }
            else if (node.Tag is FeedbackEncoder)
            {
               FeedbackEncoder encoder = node.Tag as FeedbackEncoder;
               if (encoder == null) return;

               if (MessageBox.Show("Are you sure you want to delete the feedback encoder " + encoder.Name + "?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
               {
                  FeedbackEncoder.Delete(encoder);
                  this.RefreshTreeList();
               }
            }
            else if (node.Tag is Module)
            {
               Module module = node.Tag as Module;
               if (module == null) return;

               if (MessageBox.Show("Are you sure you want to remove the layout module " + module.Name + "?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
               {
                  Module.Delete(module);
                  this.RefreshTreeList();
               }
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(Logger.LogError(this, ex), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      internal void DecoderProgram()
      {
         if (tlsDecoders.Selection.Count <= 0)
         {
            MessageBox.Show("No items selected.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         TreeListNode node = tlsDecoders.Selection[0];
         if (node == null) return;

         try
         {
            if (node.Tag is AccessoryDecoder)
            {
               AccessoryDecoder decoder = node.Tag as AccessoryDecoder;
               if (decoder != null)
               {
                  if (decoder.Manufacturer.ID != 0)
                  {
                     MessageBox.Show("Only Railwaymania accessory decoders can be programmed by this command.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     return;
                  }
                  else
                  { 
                     DecoderSketch sketch = new DecoderSketch(decoder);
                     sketch.Create(false);
                     sketch.Build(StudioContext.UI.LogConsoleControl);
                  }
               }
            }
            else if (node.Tag is EmotionModule)
            {
               EmotionModule module = node.Tag as EmotionModule;
               if (module != null)
               {
                  EMotionSketch sketch = new EMotionSketch(module);
                  sketch.Create(false);
                  sketch.Build(StudioContext.UI.LogConsoleControl);
               }
            }
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

         OTCContext.Settings.AddSetting(SETTING_LIST_TYPE, (int)ViewType.GroupByType);
         OTCContext.Settings.SaveSettings();
      }

      internal void SetListByArea()
      {
         this.CurrentViewType = ViewType.GroupByArea;
         this.RefreshTreeList();

         OTCContext.Settings.AddSetting(SETTING_LIST_TYPE, (int)ViewType.GroupByArea);
         OTCContext.Settings.SaveSettings();
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
            node = tlsDecoders.AppendNode(new object[] { accDecoder.Name, "Generic", accDecoder.ModelDescription, accDecoder.Outputs.Count, accDecoder.Outputs.Count }, parentNode);
            node.Tag = accDecoder;
            node.StateImageIndex = (accDecoder.Manufacturer?.ID != 0 ? 2 : 4);
            count++;
         }

         // Create feedback encoders nodes
         parentNode = tlsDecoders.AppendNode(new object[] { "Feedback encoders" }, rootNode);
         parentNode.StateImageIndex = 1;
         parentNode.Expanded = true;

         foreach (FeedbackEncoder fbEncoder in OTCContext.Project.FeedbackEncoders)
         {
            node = tlsDecoders.AppendNode(new object[] { fbEncoder.Name, "Generic", fbEncoder.ModelDescription, fbEncoder.Inputs.Count, fbEncoder.ConnectionsCount }, parentNode);
            node.Tag = fbEncoder;
            node.StateImageIndex = 3;
            count++;
         }

         // Create feedback encoders nodes
         parentNode = tlsDecoders.AppendNode(new object[] { "EasyConnect modules" }, rootNode);
         parentNode.StateImageIndex = 1;
         parentNode.Expanded = true;

         foreach (EmotionModule module in OTCContext.Project.EasyConnectEmotionModules)
         {
            node = tlsDecoders.AppendNode(new object[] { module.Name, "eMotion module", module.ModelDescription, "-", "-" }, parentNode);
            node.Tag = module;
            node.StateImageIndex = 4;
            count++;
         }

         tlsDecoders.Nodes[0].Expanded = true;
         tlsDecoders.Nodes[0].Nodes[0].Expanded = true;
         tlsDecoders.Nodes[0].Nodes[1].Expanded = true;
         tlsDecoders.Nodes[0].Nodes[2].Expanded = true;

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

         foreach (Module module in OTCContext.Project.Modules)
         {
            rootNode = tlsDecoders.AppendNode(new object[] { module.Name }, null);
            rootNode.StateImageIndex = 0;
            rootNode.Tag = module;

            //// Create accessory decoders nodes
            //parentNode = tlsDecoders.AppendNode(new object[] { "Accessory decoders" }, rootNode);
            //parentNode.StateImageIndex = 1;
            //parentNode.Expanded = true;

            foreach (AccessoryDecoder accDecoder in OTCContext.Project.AccessoryDecoders)
            {
               if (accDecoder.Module == module)
               {
                  node = tlsDecoders.AppendNode(new object[] { accDecoder.Name, "Generic", accDecoder.ModelDescription, accDecoder.Outputs.Count, accDecoder.Outputs.Count }, rootNode);
                  node.Tag = accDecoder;
                  node.StateImageIndex = 2;
                  count++;
               }
            }

            //parentNode.Expanded = true;
            //if (!parentNode.HasChildren) rootNode.Nodes.Remove(parentNode);

            //// Create feedback encoders nodes
            //parentNode = tlsDecoders.AppendNode(new object[] { "Feedback encoders" }, rootNode);
            //parentNode.StateImageIndex = 1;
            //parentNode.Expanded = true;

            foreach (FeedbackEncoder fbEncoder in OTCContext.Project.FeedbackEncoders)
            {
               if (fbEncoder.Module == module)
               {
                  node = tlsDecoders.AppendNode(new object[] { fbEncoder.Name, "Generic", fbEncoder.ModelDescription, fbEncoder.Inputs.Count, fbEncoder.ConnectionsCount }, rootNode);
                  node.Tag = fbEncoder;
                  node.StateImageIndex = 3;
                  count++;
               }
            }

            //parentNode.Expanded = true;
            //if (!parentNode.HasChildren) rootNode.Nodes.Remove(parentNode);

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
               node = tlsDecoders.AppendNode(new object[] { accDecoder.Name, "Generic", accDecoder.ModelDescription, accDecoder.Outputs.Count, accDecoder.Outputs.Count }, parentNode);
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
               node = tlsDecoders.AppendNode(new object[] { fbEncoder.Name, fbEncoder.ModelDescription, fbEncoder.Inputs.Count, fbEncoder.ConnectionsCount }, parentNode);
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
