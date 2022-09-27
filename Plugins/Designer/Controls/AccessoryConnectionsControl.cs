using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using Rwm.Otc.Layout;
using Rwm.Studio.Plugins.Designer.Views;

namespace Rwm.Studio.Plugins.Designer.Controls
{
   public partial class AccessoryConnectionsControl : DevExpress.XtraEditors.XtraUserControl
   {

      #region Constructors

      public AccessoryConnectionsControl()
      {
         InitializeComponent();
      }

      #endregion

      #region Properties

      public Element Element { get; private set; }

      #endregion

      #region Methods

      public void SetElement(Element element)
      {
         this.MapModelToView(element);
      }

      public void RefreshConnectionList()
      {
         grdConnect.BeginUpdate();

         if (grdConnectView.Columns.Count <= 0)
         {
            RepositoryItemButtonEdit buttonsEdit = new RepositoryItemButtonEdit();
            buttonsEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            buttonsEdit.ButtonClick += Edit_ButtonClick;
            buttonsEdit.Buttons.Clear();
            buttonsEdit.Buttons.Add(new DevExpress.XtraEditors.Controls.EditorButton());
            buttonsEdit.Buttons[0].Caption = "Connect";
            buttonsEdit.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            buttonsEdit.Buttons[0].ImageOptions.Image = Otc.Layout.AccessoryDecoderConnection.SmallIcon;
            buttonsEdit.Buttons.Add(new DevExpress.XtraEditors.Controls.EditorButton());
            buttonsEdit.Buttons[1].Caption = "Disconnect";
            buttonsEdit.Buttons[1].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            buttonsEdit.Buttons[1].ImageOptions.Image = Properties.Resources.ICO_CONNECTION_OFF_16;

            grdConnectView.Columns.Clear();
            grdConnectView.OptionsBehavior.AutoPopulateColumns = false;
            grdConnectView.Columns.Add(new GridColumn() { Caption = "Connection", Visible = false, FieldName = "Connection" });
            grdConnectView.Columns.Add(new GridColumn() { Caption = "Input", Visible = true, FieldName = "Input", Width = 45, UnboundType = UnboundColumnType.Integer });
            grdConnectView.Columns.Add(new GridColumn() { Caption = "Decoder", Visible = true, FieldName = "Decoder", Width = 150 });
            grdConnectView.Columns.Add(new GridColumn() { Caption = "Output", Visible = true, FieldName = "Output", Width = 45 });
            grdConnectView.Columns.Add(new GridColumn() { Caption = "Address", Visible = true, FieldName = "Address", Width = 50 });
            grdConnectView.Columns.Add(new GridColumn() { Caption = " ", Visible = true, FieldName = "Connect", Width = 50 });

            grdConnectView.Columns["Input"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdConnectView.Columns["Input"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdConnectView.Columns["Input"].OptionsColumn.AllowEdit = false;

            grdConnectView.Columns["Decoder"].OptionsColumn.AllowEdit = false;

            grdConnectView.Columns["Output"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdConnectView.Columns["Output"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdConnectView.Columns["Output"].OptionsColumn.AllowEdit = false;

            grdConnectView.Columns["Address"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdConnectView.Columns["Address"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            grdConnectView.Columns["Address"].OptionsColumn.AllowEdit = false;

            grdConnectView.Columns["Connect"].ColumnEdit = buttonsEdit;
            grdConnectView.Columns["Connect"].OptionsColumn.AllowEdit = true;
         }

         DataTable dt = new DataTable("Connections");
         dt.Columns.Add("Connection", typeof(AccessoryDecoderConnection));
         dt.Columns.Add("Input", typeof(int));
         dt.Columns.Add("Decoder", typeof(string));
         dt.Columns.Add("Output", typeof(int));
         dt.Columns.Add("Address", typeof(string));

         for (int input = 1; input <= this.Element.Properties.NumberOfAccessoryConnections; input++)
         {
            AccessoryDecoderConnection connection = AccessoryDecoderConnection.GetByIndex(this.Element, input);
            if (connection == null)
            {
               dt.Rows.Add(new object[] { null, input });
            }
            else
            {
               dt.Rows.Add(new object[] { connection,
                                          input, 
                                          connection.DecoderOutput.AccessoryDecoder.Name, 
                                          connection.DecoderOutput.Index, 
                                          connection.DecoderOutput.Address.ToString("0000") });
            }
         }

         grdConnect.DataSource = dt;

         grdConnect.EndUpdate();
      }

      #endregion

      #region Event Handlers

      private void Edit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
      {
         int[] selectedRows = grdConnectView.GetSelectedRows();
         if (selectedRows.Length <= 0) return;

         if (!(grdConnectView.GetRow(selectedRows[0]) is DataRowView drv)) return;

         AccessoryDecoderConnection connection = drv["Connection"] as AccessoryDecoderConnection;
         int pinIndex = (int)drv["Input"];

         switch (e.Button.Index)
         {
            case 0: this.Connect(pinIndex, connection); break;
            case 1: this.Disconnect(connection); break;
         }
      }

      #endregion

      #region Private members

      private void MapModelToView(Element element)
      {
         this.Element = element;

         this.RefreshConnectionList();
      }

      private void Connect(int inputPin, AccessoryDecoderConnection connection)
      {
         try
         {
            if (connection != null)
            {
               if (MessageBox.Show("The selected input is currently connected. Are you sure you want to connect the input to another decoder output?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                  return;
            }

            AccesoryConnectionFindView form = new AccesoryConnectionFindView(connection);
            if (form.ShowDialog(this) == DialogResult.Cancel) return;

            // Delete the existing connection
            if (connection != null)
            {
               AccessoryDecoderConnection.Delete(connection);

               connection.DecoderOutput.AccessoryConnection = null;
               connection.Element.AccessoryConnections.Remove(connection);
            }

            AccessoryDecoderConnection newconnection = new AccessoryDecoderConnection();
            newconnection.DecoderOutput = form.SelectedOutput;
            newconnection.Element = this.Element;
            newconnection.ElementPinIndex = inputPin;
            newconnection.Inverted = false;
            AccessoryDecoderConnection.Save(newconnection);

            form.SelectedOutput.AccessoryConnection = newconnection;
            this.Element.AccessoryConnections.Add(newconnection);
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
         finally
         {
            this.RefreshConnectionList();
         }
      }

      private void Disconnect(AccessoryDecoderConnection connection)
      {
         if (connection == null)
         {
            MessageBox.Show("This accessory input is not connected.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         try
         {
            // Delete the connection
            AccessoryDecoderConnection.Delete(connection);

            // Remove both links from the element and the output
            connection.DecoderOutput.AccessoryConnection = null;
            connection.Element.AccessoryConnections.Remove(connection);
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
         finally
         {
            this.RefreshConnectionList();
         }
      }

      #endregion

   }
}
