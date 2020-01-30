using DevExpress.XtraBars.Docking;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraPrinting;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace RailwayStudio.Common
{
   public class UI
   {

      /// <summary>
      /// Add a new dockable panel showing a control.
      /// </summary>
      /// <param name="name">Panel name.</param>
      /// <param name="text">Text shown in the panel caption.</param>
      /// <param name="control">Control to be shown in the panel.</param>
      /// <param name="icon">Icon (16x16) for the panel tab.</param>
      /// <param name="position">Docking position.</param>
      public DockPanel AddDockPanel(string name, string text, Control control, Image icon, DockingStyle dockStyle)
      {
         DockPanel panel;

         // Initializations
         control.Dock = DockStyle.Fill;

         if (StudioContext.MainView.DockManager == null)
         {
            return null;
         }

         // Check if the panel is created
         foreach (DockPanel pnl in StudioContext.MainView.DockManager.Panels)
         {
            if (pnl.Name.Equals(name))
            {
               return pnl;
            }
         }

         StudioContext.MainView.DockManager.BeginUpdate();

         panel = StudioContext.MainView.DockManager.AddPanel(dockStyle);
         panel.Name = name;
         panel.Image = icon;
         panel.Text = text;
         panel.ControlContainer.Controls.Add(control);

         StudioContext.MainView.DockManager.EndUpdate();

         return panel;
      }

      /// <summary>
      /// Remove the specified dockable panel.
      /// </summary>
      /// <param name="name">Panel name.</param>
      public void RemoveDockPanel(string name)
      {
         // Check if the panel is created
         foreach (DockPanel pnl in StudioContext.MainView.DockManager.Panels)
         {
            if (pnl.Name.Equals(name))
            {
               StudioContext.MainView.DockManager.RemovePanel(pnl);
               return;
            }
         }
      }

      /// <summary>
      /// Draw an icon in the first column of a <see cref="GridControl"/>.
      /// </summary>
      /// <param name="icon">Icon to draw.</param>
      /// <param name="e">An instance of <see cref="RowCellCustomDrawEventArgs"/> provided by the event <c>CustomDrawCell</c>.</param>
      public void DrawRowIcon(Image icon, RowCellCustomDrawEventArgs e)
      {
         if (e.Column.VisibleIndex > 0)
         {
            return;
         }

         // calculate the indentation of the icon based on the grid cell size
         int iconYIndent = (e.Bounds.Height - icon.Height) / 2;
         e.Graphics.DrawImageUnscaled(icon, e.Bounds.X + 1, e.Bounds.Y + iconYIndent);

         // always indent the text even if no icon for this cell - so all columns are aligned
         Rectangle bounds = e.Bounds;
         bounds.Width -= 20;
         bounds.X += 20;

         e.Appearance.DrawString(e.Cache, e.DisplayText, bounds);
         e.Handled = true;
      }

      public long GetSelectedGridItemID(DevExpress.XtraGrid.Views.Grid.GridView view)
      {
         int[] rows = view.GetSelectedRows();
         DataRowView drv = view.GetRow(rows[0]) as DataRowView;
         if (drv != null)
         {
            return (long)drv[0];
         }

         return 0;
      }

      /// <summary>
      /// Show a print preview document for a <see cref="GridControl"/> and adds a standard header.
      /// </summary>
      /// <param name="title">Document title.</param>
      /// <param name="grid">Grid control.</param>
      public void PrintPreview(string title, DevExpress.XtraPrinting.Preview.DocumentViewer docViewer, DevExpress.XtraGrid.GridControl grid)
      {
         if (grid == null) return;

         PrintableComponentLink link = new PrintableComponentLink(new DevExpress.XtraPrinting.PrintingSystem());
         link.Component = grid;
         link.Images.Add(Properties.Resources.IMG_LOGO_PRINT);

         PageHeaderFooter phf = link.PageHeaderFooter as PageHeaderFooter;
         phf.Header.Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold);
         phf.Header.Content.Clear();
         phf.Header.Content.AddRange(new string[] { title, "", "[Image 0]" });
         phf.Header.LineAlignment = BrickAlignment.Center;

         phf.Footer.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Regular);
         phf.Footer.Content.Clear();
         phf.Footer.Content.AddRange(new string[] { "[Date Printed] [Time Printed]", "", "Page [Page # of Pages #]" });
         phf.Footer.LineAlignment = BrickAlignment.Center;

         PrintingSystem ps = new PrintingSystem();
         ps.Links.Add(link);

         link.CreateDocument();

         docViewer.DocumentSource = ps;
      }
   }
}
