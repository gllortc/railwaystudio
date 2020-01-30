using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Media;
using System.Threading;
using System.Windows.Forms;

namespace otc.forms.controls
{

   #region class NotificationBar : Control

   /// <summary>
	/// Implementa un control para mostrar notificaciones al estilo de IE.
	/// </summary>
   /// <remarks>
   /// Cófigo original: http://www.coryborrow.com/index.php/C5/
   /// </remarks>
	public class NotificationBarControl : Control
	{
		Padding padding = new Padding();
		
		bool _animateOnVisiblityChange = false;
		bool _resizeToFitText = true;
		bool _playChimeOnVisible = true;
		int _originalHeight = 0;
		int _textYOffset = 5;

      /// <summary>
      /// Devuelve una instancia de NotificationBar.
      /// </summary>
      public NotificationBarControl()
      {
         SetStyle(ControlStyles.AllPaintingInWmPaint, true);
         SetStyle(ControlStyles.DoubleBuffer, true);

         padding.Left = 2;
         padding.Top = 0;
         padding.Bottom = 0;
         padding.Right = 12;

         this.Padding = padding;
         this.BackColor = SystemColors.Info;
         this.ForeColor = SystemColors.InfoText;
         this.AutoSize = _resizeToFitText;
      }

      /// <summary>
      /// Sets wheter or not to animate when the control is shown / hidden.
      /// </summary>
		[Category("Behavior")]
		[Description("Sets wheter or not to animate when the control is shown / hidden")]
		public bool AnimateOnVisibilityChange 
      {
			get { return _animateOnVisiblityChange; }
			set { _animateOnVisiblityChange = value; }
		}
		
      /// <summary>
      /// Sets a value to allow the control to resize to accomidate the text.
      /// </summary>
		[Category("Behavior")]
		[Description("Sets a value to allow the control to resize to accomidate the text")]
		public bool ResizeToFitText 
      {
			get { return _resizeToFitText; }
			set { 
            _resizeToFitText = value;
				this.AutoSize = _resizeToFitText;
			}
		}
		
      /// <summary>
      /// Plays a chime / sound when the control is shown.
      /// </summary>
		[Category("Behavior")]
		[Description("Plays a chime / sound when the control is shown")]
		public bool PlayChimeOnVisible 
      {
			get { return _playChimeOnVisible; }
			set { _playChimeOnVisible = value; }
		}
		
      /// <summary>
      /// Muestra la barra de notificaciones.
      /// </summary>
      /// <param name="useAnimation">Indica si se debe activar la animación.</param>
		public void Show(bool useAnimation) 
      {
			if (!useAnimation) 
         {
				this.Show();
			}
			else 
         {
				_originalHeight = this.Height;
				this.Height = 0;
				this.Show();
				
				for (int i = 0; i < _originalHeight; i += 2) 
            {
					this.Height = i;
					_textYOffset += 2;
					this.Refresh();
					Thread.Sleep(5);
				}
				_textYOffset = 5;
				this.Height = _originalHeight;
			}
			
			foreach(Control c in this.Controls) 
         {
				c.Show();
			}
			
			if(_playChimeOnVisible)
				SystemSounds.Exclamation.Play();
		}
		
      /// <summary>
      /// Oculta la barra de notificación.
      /// </summary>
      /// <param name="useAnimation">Indica si se debe activar la animación.</param>
		public void Hide(bool useAnimation) 
      {
			foreach (Control c in this.Controls)
            c.Hide();
			
			if (!useAnimation) 
         {
				this.Hide();
			}
			else 
         {
				_originalHeight = this.Height;
				
				for (int i = _originalHeight; i > 0; i -= 2) 
            {
					this.Height = i;
					_textYOffset -= 2;
					this.Refresh();
					Thread.Sleep(5);
				}
				
				this.Hide();
				this.Height = _originalHeight;
			}
		}
		
      /// <summary>
      /// Devuelve el ancho máximo.
      /// </summary>
		protected int GetLargestWidth() 
      {
			int totalWidth = this.Width;
			
			foreach(Control c in this.Controls) 
         {
				if ((c.Location.X - 5) < totalWidth) 
				   totalWidth = (c.Location.X - 5);
			}
			
			if (totalWidth == this.Width) 
				totalWidth = this.Width - 22;
			
			return totalWidth;
		}
		
		/*[EditorBrowsableAttribute()]
		protected override void OnControlAdded(ControlEventArgs e)
		{
			foreach(Control c in this.Controls) {
				int index = this.Controls.IndexOf(c);
				this.Controls.Remove(c);
				
				c.Anchor = AnchorStyles.Top | AnchorStyles.Right;
				this.Controls.Add(c);
			}
			
			base.OnControlAdded(e);
		}*/
		
      /// <summary>
      /// Evento que se lanza al redimensionar el formulario que muestra la barra de notificación.
      /// </summary>
		[EditorBrowsableAttribute()]
		protected override void OnResize(EventArgs e)
		{
			this.Refresh();
			base.OnResize(e);
		}

      /// <summary>
      /// Evento que se lanza al hacer clic en la barra de notificación.
      /// </summary>
		[EditorBrowsableAttribute()]
		protected override void OnMouseClick(MouseEventArgs e)
		{
			Rectangle mouseRect = new Rectangle();
			mouseRect.Location = new Point(e.X, e.Y);
			mouseRect.Size = new Size(1, 1);
			
			Rectangle closeButtonRect = new Rectangle();
			closeButtonRect.Location = new Point(this.Width - 14, 2);
			closeButtonRect.Size = new Size(10, 10);
			
			if(mouseRect.IntersectsWith(closeButtonRect))
				this.Hide(true);
			
			base.OnMouseClick(e);
		}

      /// <summary>
      /// Evento que se lanza al situarse el mouse encima de la barra de notificación.
      /// </summary>
		[EditorBrowsableAttribute()]
		protected override void OnMouseEnter(EventArgs e)
		{
			this.ForeColor = SystemColors.HighlightText;
			this.BackColor = SystemColors.Highlight;
			this.Refresh();
			
			base.OnMouseEnter(e);
		}

      /// <summary>
      /// Evento que se lanza al situarse el mouse fuera de la barra de notificación.
      /// </summary>
		[EditorBrowsableAttribute()]
		protected override void OnMouseLeave(EventArgs e)
		{
			this.ForeColor = SystemColors.InfoText;
			this.BackColor = SystemColors.Info;
			this.Refresh();
			
			base.OnMouseLeave(e);
		}

		/// <summary>
		/// Representa el botón para cerrar la barra de notificaciones.
		/// </summary>
		protected void DrawCloseButton(PaintEventArgs e) 
      {
			Pen linePen = new Pen(this.ForeColor, 2);
			Pen dotLinePen = new Pen(Color.DarkGray, 1);
			dotLinePen.DashStyle = DashStyle.Dot;
			
			e.Graphics.DrawLine(linePen, this.Width - 14, 2, this.Width - 4, 12);
			e.Graphics.DrawLine(linePen, this.Width - 4, 2, this.Width - 14, 12);
			e.Graphics.DrawLine(dotLinePen, this.Width - 18, 0, this.Width - 18, this.Height);
			linePen.Dispose();
			dotLinePen.Dispose();
		}
		
      /// <summary>
      /// Representa el texto en la barra de notificaciones.
      /// </summary>
		protected void DrawText(PaintEventArgs e) 
      {
			Size textSize = TextRenderer.MeasureText(e.Graphics, this.Text, this.Font, new Size(GetLargestWidth(), this.Height), TextFormatFlags.Top | TextFormatFlags.Left | TextFormatFlags.WordBreak);
			Rectangle textRect = new Rectangle();
			textRect.Location = new Point(5, _textYOffset);
			textRect.Size = new Size(GetLargestWidth(), textSize.Height);
			
			if (_resizeToFitText) 
         {
				TextRenderer.DrawText(e.Graphics, this.Text, this.Font, textRect, this.ForeColor, this.BackColor, TextFormatFlags.Top | TextFormatFlags.Left | TextFormatFlags.WordBreak);
				this.Height = (textRect.Height + 6) + _textYOffset;
			}
			else 
         {
				textRect.Height = 23;
				this.Height = 20 + _textYOffset;
				TextRenderer.DrawText(e.Graphics, this.Text, this.Font, textRect, this.ForeColor, this.BackColor, TextFormatFlags.Top | TextFormatFlags.Left | TextFormatFlags.WordEllipsis);
			}
		}

      /// <summary>
      /// Evento que se lanza al pintarse la barra de notificación.
      /// </summary>
		[EditorBrowsableAttribute()]
		protected override void OnPaint(PaintEventArgs e)
		{
			DrawText(e);
			DrawCloseButton(e);
			
			base.OnPaint(e);
		}
   }

   #endregion

}