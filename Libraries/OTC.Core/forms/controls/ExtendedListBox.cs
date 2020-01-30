using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace otc.forms.controls
{

   #region class ExtendedListBoxItem

   /// <summary>
   /// Description of ExtendedListBoxItem.
   /// </summary>
   /// <remarks>
   /// Cófigo original: http://www.coryborrow.com/index.php/C5/
   /// </remarks>
   public class ExtendedListBoxItem
   {
      Image _image;
      string _text;
      string _desc;

      /// <summary>
      /// Devuelve una instancia de ExtendedListBoxItem.
      /// </summary>
      public ExtendedListBoxItem()
      {
         // Nothing to do
      }

      /// <summary>
      /// Devuelve una instancia de ExtendedListBoxItem.
      /// </summary>
      public ExtendedListBoxItem(string Text, string Description, Image Image)
      {
         _text = Text;
         _desc = Description;
         _image = Image;
      }

      /// <summary>
      /// Imagen del elemento.
      /// </summary>
      public Image Image
      {
         get { return _image; }
         set { _image = value; }
      }

      /// <summary>
      /// Texto que se muestra en el elemento.
      /// </summary>
      public string Text
      {
         get { return _text; }
         set { _text = value; }
      }

      /// <summary>
      /// Descripción que se muestra en la fila inferior del elemento.
      /// </summary>
      public string Description
      {
         get { return _desc; }
         set { _desc = value; }
      }
   }

   #endregion

   #region class ExtendedListBox : ListBox

   /// <summary>
	/// Implementa un control ListBox con la capacidad de mostrar elementos con imágen y dos filas de texto (título y descripción).
	/// </summary>
   /// <remarks>
   /// Código original: http://www.coryborrow.com/index.php/C5/
   /// </remarks>
	public class ExtendedListBox : ListBox
	{
		/*List<ExtendedListBoxItem> extendedItems = new List<ExtendedListBoxItem>();
		
		public new List<ExtendedListBoxItem> Items {
			get {
				return extendedItems;
			}
		}*/
		
      /// <summary>
      /// Devuelve una instancia de ExtendedListBox.
      /// </summary>
		public ExtendedListBox()
		{
			this.DrawMode = DrawMode.OwnerDrawFixed;
			this.ItemHeight = 100;
		}
		
      /// <summary>
      /// Evento que se lanza al representar un elemento de la lista.
      /// </summary>
		protected override void OnDrawItem(DrawItemEventArgs e)
		{
			if (e.Index < this.Items.Count) 
         {
				ExtendedListBoxItem item = (ExtendedListBoxItem)this.Items[e.Index];

            Font descFont = new Font(this.Font.FontFamily, this.Font.Size, this.Font.Style, GraphicsUnit.Point);
            Font titleFont = new Font(this.Font.FontFamily, this.Font.Size, this.Font.Style | FontStyle.Bold, GraphicsUnit.Point);
            Font sepFont = new Font(this.Font.FontFamily, 4, this.Font.Style, GraphicsUnit.Point);
            Brush brush = SystemBrushes.WindowText;

				Padding padding = new Padding();
				padding.Left = 5;
				padding.Top = 5;
            // padding.Bottom = 100;
				
				if ((e.State & DrawItemState.Selected) == DrawItemState.Selected) 
            {
               brush = SystemBrushes.HighlightText;
				}

				e.DrawBackground();
				e.DrawFocusRectangle();
				
				if (item.Image != null) 
            {
					padding.Left = 40;
					
					if (item.Image.Width != 24 || item.Image.Height != 24) 
               {
						using(Bitmap bmp = new Bitmap(item.Image, 24, 24)) 
                  {
							e.Graphics.DrawImage(bmp, new PointF(5, 7 + e.Bounds.Y));
						}
					}
					else 
               {
						e.Graphics.DrawImage(item.Image, new PointF(5, 7 + e.Bounds.Y));
					}
               e.Graphics.DrawImage(MakeTransparentGif(new Bitmap(1, 5), Color.White), new PointF(5, 7 + e.Bounds.Y + 24));
				}

            e.Graphics.DrawString(item.Text, titleFont, brush, new PointF(padding.Left, padding.Top + e.Bounds.Y));
            e.Graphics.DrawString(item.Description, descFont, brush, new PointF(padding.Left, (padding.Top + 15) + e.Bounds.Y));
            e.Graphics.DrawString(" hola ", sepFont, brush, new PointF(padding.Left, (padding.Top + 30) + e.Bounds.Y));
			}
			
			base.OnDrawItem(e);
		}
		
      /// <summary>  
      /// Returns a transparent background GIF image from the specified Bitmap.  
      /// </summary>  
      /// <param name="bitmap">The Bitmap to make transparent.</param>  
      /// <param name="color">The Color to make transparent.</param>  
      /// <returns>New Bitmap containing a transparent background gif.</returns>  
      private Bitmap MakeTransparentGif(Bitmap bitmap, Color color)  
      {  
          byte R = color.R;  
          byte G = color.G;  
          byte B = color.B;
          MemoryStream fin = new MemoryStream();  
          bitmap.Save(fin, System.Drawing.Imaging.ImageFormat.Gif);  
          MemoryStream fout = new MemoryStream((int)fin.Length);  
          int count = 0;  
          byte[] buf = new byte[256];  
          byte transparentIdx = 0;  
          fin.Seek(0, SeekOrigin.Begin);  
          //header  
          count = fin.Read(buf, 0, 13);  
          if ((buf[0] != 71) || (buf[1] != 73) || (buf[2] != 70)) return null; //GIF  
          fout.Write(buf, 0, 13);  
          int i = 0;  
          if ((buf[10] & 0x80) > 0)  
          {  
              i = 1 << ((buf[10] & 7) + 1) == 256 ? 256 : 0;  
          }  
          for (; i != 0; i--)  
          {  
              fin.Read(buf, 0, 3);  
              if ((buf[0] == R) && (buf[1] == G) && (buf[2] == B))  
              {  
                  transparentIdx = (byte)(256 - i);  
              }  
              fout.Write(buf, 0, 3);  
          }  
          bool gcePresent = false;  
          while (true)  
          {  
              fin.Read(buf, 0, 1);  
              fout.Write(buf, 0, 1);  
              if (buf[0] != 0x21) break;  
              fin.Read(buf, 0, 1);  
              fout.Write(buf, 0, 1);  
              gcePresent = (buf[0] == 0xf9);  
              while (true)  
              {  
                  fin.Read(buf, 0, 1);  
                  fout.Write(buf, 0, 1);  
                  if (buf[0] == 0) break;  
                  count = buf[0];  
                  if (fin.Read(buf, 0, count) != count) return null;  
                  if (gcePresent)  
                  {  
                      if (count == 4)  
                      {  
                          buf[0] |= 0x01;  
                          buf[3] = transparentIdx;  
                      }  
                  }  
                  fout.Write(buf, 0, count);  
              }  
          }  
          while (count > 0)  
          {  
              count = fin.Read(buf, 0, 1);  
              fout.Write(buf, 0, 1);  
          }  
          fin.Close();  
          fout.Flush();  
          return new Bitmap(fout);  
      }

		/*[System.ComponentModel.EditorBrowsableAttribute()]
		protected override void OnPaint(PaintEventArgs e)
		{
			for(int i = 0; i < this.Items.Count; i++) {
				Rectangle itemRect = new Rectangle();
				itemRect.Location = new Point(0, (i * this.ItemHeight));
				itemRect.Size = new Size(this.Width, this.ItemHeight);
				DrawItemState itemState = DrawItemState.None;
				
				if(this.SelectedIndex == i)
					itemState = DrawItemState.Selected;
				
				DrawItemEventArgs drawItemEvent = new DrawItemEventArgs(e.Graphics, this.Font, itemRect, i, itemState);
				OnDrawItem(drawItemEvent);
			}
			
			base.OnPaint(e);
		}*/
   }

   #endregion

}
