using System;
using System.Reflection;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace otc.forms.controls
{

   #region class ColorComboBox : System.Windows.Forms.ComboBox

   /// <summary>
   /// Desplegable para la selección de color.
   /// </summary>
   public class ColorComboBox : System.Windows.Forms.ComboBox
   {
      private bool _hideText;
      private SolidBrush _blackBrush;
      private SolidBrush _whiteBrush;
      private Color _colorSelected;

      /// <summary>
      /// Devuelve una instancia de ColorComboBox.
      /// </summary>
      public ColorComboBox()
      {
         _blackBrush = new SolidBrush(Color.Black);
         _whiteBrush = new SolidBrush(Color.White);

         this.Items.Clear();

         int index = 0;
         string[] allColors = Enum.GetNames(typeof(System.Drawing.KnownColor));
         string[] systemColors = new string[(typeof(System.Drawing.SystemColors)).GetProperties().Length];

         foreach (MemberInfo member in (typeof(System.Drawing.SystemColors)).GetProperties())
         {
            systemColors[index++] = member.Name;
         }

         foreach (string colorName in allColors)
         {
            if (Array.IndexOf(systemColors, colorName) < 0)
            {
               this.Items.Add(new ColorComboBoxItem(colorName, GetColorFromString(colorName)));
            }
            else
            {
               index++;
            }
         }

         this.Text = "Black";
         this.BackColor = Color.White;
         _colorSelected = Color.Black;

         this.DrawMode = DrawMode.OwnerDrawFixed;

         DropDownStyle = ComboBoxStyle.DropDownList;

         // Registra los eventos
         this.DrawItem += new DrawItemEventHandler(OnDrawItem);
         this.SelectedIndexChanged += new System.EventHandler(OnSelectedIndexChanged);
         this.DropDown += new System.EventHandler(OnDropDown);

         _hideText = true;
      }

      /// <summary>
      /// Devuelve una instancia de ColorComboBox.
      /// </summary>
      public ColorComboBox(bool hideText) : this()
      {
         _hideText = hideText;
      }

      /// <summary>
      /// Get the selected color from the combo box
      /// </summary>
      public Color SelectedColor
      {
         get { return _colorSelected; }
         set 
         { 
            _colorSelected = value; 

            // Preselecciona el elemento
            for (int i=0; i<Items.Count; i++)
            {
               if (((ColorComboBoxItem)this.Items[i]).Color.R == _colorSelected.R &&
                   ((ColorComboBoxItem)this.Items[i]).Color.G == _colorSelected.G &&
                   ((ColorComboBoxItem)this.Items[i]).Color.B == _colorSelected.B)
               {
                  this.SelectedIndex = i;
                  break;
               }
            }
         }
      }

      /// <summary>
      /// Devuelve el nombre de un color
      /// </summary>
      /// <param name="color">Color</param>
      /// <returns>Devuelve el nombre de un color</returns>
      public string GetStringFromColor(Color color)
      {
         return color.ToString();
      }

      /// <summary>
      /// Transforma un nombre de color a su valor lógico
      /// </summary>
      /// <param name="strColorName">Nombre del color</param>
      /// <returns>Color</returns>
      public Color GetColorFromString(string strColorName)
      {
         return Color.FromName(strColorName);
      }

      private void OnDrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
      {
         try
         {
            Graphics grfx = e.Graphics;
            Color brushColor = ((ColorComboBoxItem)this.Items[e.Index]).Color;
            SolidBrush brush = new SolidBrush(brushColor);
            Rectangle rect;
            //Pen pen= new Pen(blackBrush);

            e.DrawBackground();
            e.DrawFocusRectangle();

            rect = e.Bounds;
            rect.X += 5;
            rect.Y += 2;
            rect.Width = 50;
            rect.Height = 10;

            //grfx.FillRectangle( whiteBrush, e.Bounds );     // fill entire back ground
            grfx.FillRectangle(brush, rect);
            grfx.DrawRectangle(Pens.Black, rect);
            rect.Offset(60, 0);
            rect.Height = 15;
            rect.Width = 150;
            grfx.DrawString(((ColorComboBoxItem)this.Items[e.Index]).Name, e.Font, _blackBrush, rect);
            /*
            if (_hideText == false)
            {
               if (brushColor == Color.Black || brushColor == Color.MidnightBlue
                  || brushColor == Color.DarkBlue || brushColor == Color.Indigo
                  || brushColor == Color.MediumBlue || brushColor == Color.Maroon
                  || brushColor == Color.Navy || brushColor == Color.Purple)
               {
                  //grfx.DrawString( ( string )this.Items[ e.Index ], e.Font, whiteBrush, e.Bounds );
               }
               else
               {
                  //grfx.DrawString( ( string )this.Items[ e.Index ], e.Font, blackBrush, e.Bounds );
               }

               this.SelectionStart = 0;
               this.SelectionLength = 0;
            }
            else
            {
               //grfx.DrawString( ( string )this.Items[ e.Index ], e.Font, new SolidBrush( GetColorFromString( ( string )this.Items[ e.Index ] ) ), e.Bounds );
            }*/
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message);
         }
      }

      private void OnSelectedIndexChanged(object sender, System.EventArgs e)
      {
         _colorSelected = ((ColorComboBoxItem)this.SelectedItem).Color;

         if (_hideText == true)
         {
            this.ForeColor = this.BackColor;
            this.SelectionStart = 0;
            this.SelectionLength = 0;
         }

      }

      /// <summary>
      /// prevents the hightlighted text being shown when drop down.
      /// </summary>
      private void OnDropDown(object sender, System.EventArgs e)
      {
         _colorSelected = ((ColorComboBoxItem)this.SelectedItem).Color;

         if (_hideText == true)
         {
            this.ForeColor = this.BackColor;
            this.SelectionStart = 0;
            this.SelectionLength = 0;
         }
      }
   }

   #endregion

   #region class ColorComboBoxItem

   /// <summary>
   /// Implementa un elemento de la lista de colores (ColorComboBox).
   /// </summary>
   public class ColorComboBoxItem
   {
      Color _color;
      string _name;

      /// <summary>
      /// Devuelve una instancia de ColorComboBox.
      /// </summary>
      public ColorComboBoxItem()
      {
         // Nothing to do
      }

      /// <summary>
      /// Devuelve una instancia de ColorComboBox.
      /// </summary>
      public ColorComboBoxItem(string name, Color color)
      {
         _name = name;
         _color = color;
      }

      /// <summary>
      /// Color del elemento.
      /// </summary>
      public Color Color
      {
         get { return _color; }
         set { _color = value; }
      }

      /// <summary>
      /// Nombre del color.
      /// </summary>
      public string Name
      {
         get { return _name; }
         set { _name = value; }
      }
   }

   #endregion

}
