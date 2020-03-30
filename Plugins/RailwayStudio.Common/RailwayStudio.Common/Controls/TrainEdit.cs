using System.ComponentModel;
using System.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using Rwm.Otc.Trains;

namespace Rwm.Studio.Plugins.Common.Controls
{
   [UserRepositoryItem("RegisterTrainEdit")]
   public class RepositoryItemTrainEdit : RepositoryItemButtonEdit
   {

      #region Constants

      public const string CustomEditName = "TrainEdit";

      #endregion

      #region Constructors

      static RepositoryItemTrainEdit()
      {
         RegisterTrainEdit();
      }

      public RepositoryItemTrainEdit() { }

      #endregion

      #region Properties

      public override string EditorTypeName
      {
         get { return CustomEditName; }
      }

      #endregion

      public static void RegisterTrainEdit()
      {
         Image img = null;
         EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(CustomEditName, typeof(TrainEdit), typeof(RepositoryItemTrainEdit), typeof(TrainEditViewInfo), new TrainEditPainter(), true, img));
      }

      public override void Assign(RepositoryItem item)
      {
         this.BeginUpdate();

         try
         {
            base.Assign(item);
            RepositoryItemTrainEdit source = item as RepositoryItemTrainEdit;
            if (source == null) return;
            //
         }
         finally
         {
            this.EndUpdate();
         }
      }
   }

   [ToolboxItem(true)]
   public class TrainEdit : ButtonEdit
   {
      static TrainEdit()
      {
         RepositoryItemTrainEdit.RegisterTrainEdit();
      }

      public TrainEdit()
      {
         this.FindDialogTitle = "Select train";
      }

      protected override void OnLoaded()
      {
         this.ReadOnly = true;
         this.Properties.Buttons.Clear();
         this.Properties.Buttons.Add(new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, Common.Properties.Resources.ICO_FIND_16, null));

         base.OnLoaded();
      }

      public string FindDialogTitle { get; set; } 

      public Train SelectedTrain { get; private set; }

      protected override void OnClickButton(EditorButtonObjectInfoArgs buttonInfo)
      {
         this.SelectedTrain = StudioContext.Find.Train(this.FindDialogTitle);
         this.Text = this.SelectedTrain.ToString();
      }

      [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
      public new RepositoryItemTrainEdit Properties
      {
         get { return base.Properties as RepositoryItemTrainEdit; }
      }

      public override string EditorTypeName
      {
         get { return RepositoryItemTrainEdit.CustomEditName; }
      }
   }

   public class TrainEditViewInfo : ButtonEditViewInfo
   {
      public TrainEditViewInfo(RepositoryItem item)
         : base(item)
      {
      }
   }

   public class TrainEditPainter : ButtonEditPainter
   {
      public TrainEditPainter()
      {
      }
   }
}
