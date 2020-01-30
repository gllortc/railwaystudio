using System;
using System.Drawing;
using System.Windows.Forms;

namespace otc.forms.controls
{

   #region class ComboBoxItem

   /// <summary>
   /// Implementa un elemento de un control ComboBox
   /// </summary>
   public class ComboBoxItem
   {
      private string _name;
      private object _value;

      /// <summary>
      /// Devuelve una instancia de ComboBoxItem.
      /// </summary>
      public ComboBoxItem()
      {
         _name = "";
         _value = 0;
      }

      /// <summary>
      /// Devuelve una instancia de ComboBoxItem.
      /// </summary>
      /// <param name="name">Nombre a mostrar en la lista</param>
      /// <param name="value">Valor interno asociado a la opción de la lista</param>
      public ComboBoxItem(string name, object value)
      {
         _name = name;
         _value = value;
      }

      /// <summary>
      /// Convierte el elemento a un String
      /// </summary>
      /// <returns>Develve el atributo Name del objeto</returns>
      public override string ToString()
      {
         return _name;
      }

      /// <summary>
      /// Valor que contiene la opción de la lista
      /// </summary>
      public object Value
      {
         get { return _value; }
         set { _value = value; }
      }

      /// <summary>
      /// Nombre a mostrar en la lista desplegable
      /// </summary>
      public string Name
      {
         get { return _name; }
         set { _name = value; }
      }

      /// <summary>
      /// Permite seleccionar un elemento en un control ComboBox.
      /// </summary>
      /// <param name="combo">Control que contiene la lista de elementos.</param>
      /// <param name="value">Valor del elemento a seleccionar.</param>
      public static bool SetComboItem(System.Windows.Forms.ComboBox combo, object value)
      {
         try
         {
            foreach (ComboBoxItem item in combo.Items)
            {
               if (typeof(bool) == value.GetType())
               {
                  if ((bool)item.Value == (bool)value)
                  {
                     combo.SelectedItem = item;
                     return true;
                  }
               }
               else if (typeof(int) == value.GetType())
               {
                  if ((int)item.Value == (int)value)
                  {
                     combo.SelectedItem = item;
                     return true;
                  }
               }
               else if (typeof(string) == value.GetType())
               {
                  if ((string)item.Value == (string)value)
                  {
                     combo.SelectedItem = item;
                     return true;
                  }
               }
            }
         }
         catch
         {
            // No hace nada y deja el elemento sin seleccionar
         }

         return false;
      }
   }

   #endregion

   #region class ImageComboBox

   /// <summary>
   /// Implementa un control ComboBox que permite mostrar iconos en los elementos d ela lista usando la clase ComboBoxItem
   /// </summary>
   public class ImageComboBox : System.Windows.Forms.ComboBox
   {
      private Size _size = new Size(16, 16);

      /// <summary>
      /// Devuelve una instancia de ImageComboBox.
      /// </summary>
      public ImageComboBox()
      {
         // Agrega el evento personalizado para dibujar los iconos
         this.DrawMode = DrawMode.OwnerDrawFixed;
         this.DrawItem += new DrawItemEventHandler(OnDrawItem);

         DropDownStyle = ComboBoxStyle.DropDownList;

         this.SelectedIndexChanged += new System.EventHandler(OnSelectedIndexChanged);
         this.DropDown += new System.EventHandler(OnDropDown);
      }

      /// <summary>
      /// Devuelve o establece el tamaño que tendrán las imagenes de los elementos que se añadirán después de actualizar esta propiedad.
      /// </summary>
      public Size ImageSize
      {
         get { return _size; }
         set { _size = value; }
      }

      /// <summary>
      /// Devuelve la imagen del elemento seleccionado
      /// </summary>
      public Image SelectedImage
      {
         get { return ((ImageComboBoxItem)this.SelectedItem).Image; }
      }

      /// <summary>
      /// Preselecciona un elemento de la lista a partir de su valor.
      /// </summary>
      /// <param name="value">Valor del elemento a preseleccionar.</param>
      public void SelectItem(int value)
      {
         int idx = 0;

         foreach (ImageComboBoxItem item in this.Items)
         {
            if (value == item.Value)
            {
               this.SelectedIndex = idx;
               return;
            }
            idx++;
         }
      }

      private void OnDrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
      {
         int iWidth;
         Graphics grfx = e.Graphics;
         Rectangle rect;

         e.DrawBackground();
         e.DrawFocusRectangle();

         if (e.Index >= 0)
         {
            rect = e.Bounds;
            iWidth = rect.Width;
            rect.X += 5;
            rect.Y += 1;
            rect.Height -= 1;
            rect.Width = _size.Width;
            rect.Height = _size.Height;
            if (((ImageComboBoxItem)this.Items[e.Index]).Image != null)
               grfx.DrawImage(((ImageComboBoxItem)this.Items[e.Index]).Image, rect);
            rect.Offset(rect.Width + 5, 0);
            rect.Width = iWidth;
            if (((ImageComboBoxItem)this.Items[e.Index]).Name != null)
               grfx.DrawString(((ImageComboBoxItem)this.Items[e.Index]).Name, e.Font, Brushes.Black, rect);
         }
      }

      private void OnSelectedIndexChanged(object sender, System.EventArgs e) { }
      private void OnDropDown(object sender, System.EventArgs e) { }
      private void ImageComboBox_MouseHover(object sender, EventArgs e) { }
      private void ImageComboBox_MouseMove(object sender, MouseEventArgs e) { }

      private void InitializeComponent()
      {
         this.SuspendLayout();

         // 
         // ImageComboBox
         // 
         this.MouseHover += new System.EventHandler(this.ImageComboBox_MouseHover);
         this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ImageComboBox_MouseMove);

         this.ResumeLayout(false);
      }
   }

   #endregion

   #region class ImageComboBoxItem

   /// <summary>
   /// Implementa un elemento del control ImageComboBox que permite disponer de texto, valor e imagen
   /// </summary>
   public class ImageComboBoxItem
   {
      private string _name;
      private int _value;
      private Image _image;

      /// <summary>
      /// Devuelve una instancia de ImageComboBoxItem.
      /// </summary>
      public ImageComboBoxItem()
      {
         _name = "";
         _value = 0;
         _image = null;
      }

      /// <summary>
      /// Devuelve una instancia de ImageComboBoxItem.
      /// </summary>
      public ImageComboBoxItem(string Name, int Value)
      {
         _name = Name;
         _value = Value;
         _image = null;
      }

      /// <summary>
      /// Devuelve una instancia de ImageComboBoxItem.
      /// </summary>
      public ImageComboBoxItem(string Name, int Value, Image Image)
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
