using System;
using System.Drawing;
using System.Windows.Forms;

namespace otc.forms.controls
{

   #region class ImageListBox

   /// <summary>
   /// Two column combobox for image and text
   /// </summary>
   [System.Drawing.ToolboxBitmap(@"C:\Documents and Settings\Administrador\Mis documentos\Visual Studio 2008\Projects\RC2008\RailwayCommon\Resources\ImageListBox.bmp")]
   public class ImageListBox : System.Windows.Forms.ListBox
   {
      /// <summary>
      /// Devuelve una instancia de ImageListBox.
      /// </summary>
      public ImageListBox()
      {
         // Subscribe los eventos del control original
         this.DrawMode = DrawMode.OwnerDrawFixed;
         this.DrawItem += new DrawItemEventHandler(OnDrawItem);
         this.SelectedIndexChanged += new System.EventHandler(OnSelectedIndexChanged);
      }

      /// <summary>
      /// Devuelve la imagen de un determinado elemento de la lista.
      /// </summary>
      /// <param name="Index">Índice del elemento para el que se desea obtener la imagen.</param>
      public Image GetImage(int Index)
      {
         return ((ImageListBoxItem)this.Items[Index]).Image;
      }

      private void OnDrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
      {
         Graphics grfx = e.Graphics;
         Rectangle rect;
         int iWidth;

         if (this.Items.Count > 0 && e.Index < this.Items.Count)
         {
            e.DrawBackground();
            e.DrawFocusRectangle();

            if (e.Index >= 0)
            {
               rect = e.Bounds;
               iWidth = rect.Width;
               rect.X += 5;
               rect.Y += 1;
               rect.Height -= 1;
               rect.Width = rect.Height;
               if (((ImageListBoxItem)this.Items[e.Index]).Image != null)
                  grfx.DrawImage(((ImageListBoxItem)this.Items[e.Index]).Image, rect);
               rect.Offset(15, 0);
               rect.Width = iWidth;
               if (((ImageListBoxItem)this.Items[e.Index]).Name != null)
                  grfx.DrawString(((ImageListBoxItem)this.Items[e.Index]).Name, e.Font, Brushes.Black, rect);
            }
         }
      }

      private void OnSelectedIndexChanged(object sender, System.EventArgs e) { }
      private void ImageListBox_MouseHover(object sender, EventArgs e) { }
      private void ImageListBox_MouseMove(object sender, MouseEventArgs e) { }

      private void InitializeComponent()
      {
         this.SuspendLayout();

         // ImageListBox
         this.MouseHover += new System.EventHandler(this.ImageListBox_MouseHover);
         this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ImageListBox_MouseMove);

         this.ResumeLayout(false);
      }
   }

   #endregion

   #region class ImageListBoxItem

   /// <summary>
   /// Implementa un elemento del control ImageListBox que permite disponer de texto, valor e imagen
   /// </summary>
   public class ImageListBoxItem
   {
      private string _name;
      private int _value;
      private Image _image;

      /// <summary>
      /// Devuelve una imagen de ImageListBoxItem.
      /// </summary>
      public ImageListBoxItem()
      {
         _name = "";
         _value = 0;
         _image = null;
      }

      /// <summary>
      /// Devuelve una imagen de ImageListBoxItem.
      /// </summary>
      public ImageListBoxItem(string Name, int Value)
      {
         _name = Name;
         _value = Value;
         _image = null;
      }

      /// <summary>
      /// Devuelve una imagen de ImageListBoxItem.
      /// </summary>
      public ImageListBoxItem(string Name, int Value, Image Image)
      {
         _name = Name;
         _value = Value;
         _image = Image;
      }

      /// <summary>
      /// Devuelve o establece el texto que muestra el elemento en la lista
      /// </summary>
      public string Name
      {
         get { return _name; }
         set { _name = value; }
      }

      /// <summary>
      /// Devuelve o establece el valor que identifica el elemento
      /// </summary>
      public int Value
      {
         get { return _value; }
         set { _value = value; }
      }

      /// <summary>
      /// Devuelve o establece el icono a mostrar junto al elemento
      /// </summary>
      public Image Image
      {
         get { return _image; }
         set { _image = value; }
      }
   }

   #endregion

}
