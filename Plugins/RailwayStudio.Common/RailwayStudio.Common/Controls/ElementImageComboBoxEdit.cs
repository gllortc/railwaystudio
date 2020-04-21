﻿using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using Rwm.Otc.Layout;

namespace Rwm.Studio.Plugins.Common.Controls
{
   [UserRepositoryItem("RegisterElementImageComboBoxEdit")]
   public class RepositoryItemElementImageComboBoxEdit : RepositoryItemImageComboBox
   {

      #region Constants

      public const string CustomEditName = "ElementImageComboBoxEdit";

      #endregion

      #region Constructors

      static RepositoryItemElementImageComboBoxEdit()
      {
         RepositoryItemElementImageComboBoxEdit.RegisterElementImageComboBoxEdit();
      }

      public RepositoryItemElementImageComboBoxEdit() { }

      #endregion

      #region Properties

      public override string EditorTypeName
      {
         get { return CustomEditName; }
      }

      #endregion

      #region Methods

      public static void RegisterElementImageComboBoxEdit()
      {
         Image img = null;
         EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(CustomEditName, typeof(ElementImageComboBoxEdit), typeof(RepositoryItemElementImageComboBoxEdit), typeof(ElementImageComboBoxEditViewInfo), new ElementImageComboBoxEditPainter(), true, img));
      }

      public override void Assign(RepositoryItem item)
      {
         BeginUpdate();

         try
         {
            base.Assign(item);
            RepositoryItemElementImageComboBoxEdit source = item as RepositoryItemElementImageComboBoxEdit;
            if (source == null) return;
         }
         finally
         {
            EndUpdate();
         }
      }

      #endregion

   }

   [ToolboxItem(true)]
   public class ElementImageComboBoxEdit : ImageComboBoxEdit
   {

      #region Constructors

      static ElementImageComboBoxEdit()
      {
         RepositoryItemElementImageComboBoxEdit.RegisterElementImageComboBoxEdit();
      }

      /// <summary>
      /// Return a new instance of <see cref="ElementImageComboBoxEdit"/>.
      /// </summary>
      public ElementImageComboBoxEdit() { }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the type of element shown in the editor (<c>null</c> for all).
      /// </summary>
      public ElementType ElementType { get; set; } = null;

      /// <summary>
      /// Gets the selected item in the list.
      /// </summary>
      public Element SelectedElement
      {
         get
         {
            if (this.EditValue == null) return null;
            return this.EditValue as Element;
         }
      }

      private ImageList ImageList { get; set; }

      [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
      public new RepositoryItemElementImageComboBoxEdit Properties
      {
         get { return base.Properties as RepositoryItemElementImageComboBoxEdit; }
      }

      public override string EditorTypeName
      {
         get { return RepositoryItemElementImageComboBoxEdit.CustomEditName; }
      }

      #endregion

      #region Methods

      /// <summary>
      /// Refresh/Fill the editor list of the selected type of elements.
      /// </summary>
      public void RefreshElementsList()
      {
         this.FillItems(null);
      }

      /// <summary>
      /// Sets the selected element in the editor.
      /// </summary>
      /// <param name="selected">Selected item.</param>
      public void SetSelectedElement(Element selected)
      {
         this.FillItems(selected);
      }

      protected override PopupBaseForm CreatePopupForm()
      {
         return new ElementImageComboBoxEditPopupForm(this);
      }

      #endregion

      #region Private Members

      private void FillItems(Element selected)
      {

         // Create an image collection
         this.ImageList = new ImageList();
         this.Properties.SmallImages = this.ImageList;

         this.Properties.Items.Clear();

         if (Otc.OTCContext.Project != null)
         {
            foreach (Element eb in Element.FindAll())
            {
               if (eb.Properties == this.ElementType)
               {
                  // Adds the type image if necessary
                  if (!this.ImageList.Images.ContainsKey(eb.Properties.ID.ToString()))
                  {
                     this.ImageList.Images.Add(eb.Properties.ID.ToString(), eb.Properties.TypeIcon);
                  }

                  ImageComboBoxItem item = new ImageComboBoxItem(eb.ToString(), eb);
                  item.ImageIndex = this.ImageList.Images.IndexOfKey(eb.Properties.ID.ToString());

                  this.Properties.Items.Add(item);

                  if (selected != null && eb == selected) this.EditValue = item;
               }
            }
         }
      }

      #endregion

   }

   #region Nested Classes

   public class ElementImageComboBoxEditViewInfo : ImageComboBoxEditViewInfo
   {
      public ElementImageComboBoxEditViewInfo(RepositoryItem item) : base(item) { }
   }

   public class ElementImageComboBoxEditPainter : ImageComboBoxEditPainter
   {
      public ElementImageComboBoxEditPainter() { }
   }

   public class ElementImageComboBoxEditPopupForm : PopupImageComboBoxEditListBoxForm
   {
      public ElementImageComboBoxEditPopupForm(ElementImageComboBoxEdit ownerEdit) : base(ownerEdit) { }
   }

   #endregion

}