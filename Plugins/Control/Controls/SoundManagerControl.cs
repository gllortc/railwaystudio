using System;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using Rwm.Otc.Layout;
using Rwm.Studio.Plugins.Common;
using Rwm.Studio.Plugins.Control.Modules;
using Rwm.Studio.Plugins.Control.Views;

namespace Rwm.Studio.Plugins.Control.Controls
{
   public partial class SoundManagerControl : DevExpress.XtraEditors.XtraUserControl
   {

      #region Constructors

      /// <summary>
      /// Do not use this constructor. 
      /// It is only for design pourposes.
      /// </summary>
      public SoundManagerControl()
      {
         InitializeComponent();
      }

      /// <summary>
      /// Returns a new instance of <see cref="RouteManagerControl"/>.
      /// </summary>
      /// <param name="settings"></param>
      /// <param name="control"></param>
      public SoundManagerControl(Form ownerView)
      {
         InitializeComponent();

         this.OwnerView = ownerView as DesignModule;
         this.Refresh();
      }

      #endregion

      #region Properties

      public DesignModule OwnerView { get; private set; }

      #endregion

      #region Methods

      public override void Refresh()
      {
         try
         {
            grdData.BeginUpdate();
            grdDataView.Columns.Clear();
            grdDataView.Columns.Add(new GridColumn() { Caption = "Name", Visible = true, FieldName = "Name" });
            grdData.DataSource = Sound.FindAll(); // OTCContext.Project.FindSounds();
            grdData.EndUpdate();
         }
         catch (Exception ex)
         {
            MessageBox.Show("ERROR loading sounds:" + Environment.NewLine + Environment.NewLine + ex.Message,
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }

         base.Refresh();
      }

      #endregion

      #region Event Handlers

      private void grdDataView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
      {
         StudioContext.UI.DrawRowIcon(Properties.Resources.ICO_SOUND_16, e);
      }

      private void cmdSoundPlay_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         if (grdDataView.SelectedRowsCount <= 0)
         {
            return;
         }

         try
         {
            Sound sound = (Sound)grdDataView.GetRow(grdDataView.GetSelectedRows()[0]);
            if (sound != null) sound.Play();
         }
         catch (Exception ex)
         {
            MessageBox.Show("ERROR playing sound: " + ex.Message,
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void cmdSoundAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         SoundEditorView form = new SoundEditorView();
         form.ShowDialog(this);

         if (form.DialogResult == System.Windows.Forms.DialogResult.OK)
         {
            this.Refresh();
         }
      }

      private void cmdSoundDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
      {
         if (grdDataView.SelectedRowsCount <= 0)
         {
            MessageBox.Show("No sound selected.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         try
         {
            Sound sound = (Sound)grdDataView.GetRow(grdDataView.GetSelectedRows()[0]);
            if (sound != null)
            {
               if (MessageBox.Show("Are you sure you want to remove the sound " + sound.Name + "?",
                                   Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
               {
                  Sound.Delete(sound.ID);
                  this.Refresh();
               }
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show("ERROR removing sound: " + ex.Message,
                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      #endregion

   }
}
