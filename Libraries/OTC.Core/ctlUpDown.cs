/*
 * 
 * See http://www.akadia.com/services/dotnet_user_controls.html
 */
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace RailwayCommon.Controls
{
    public partial class UpDown : UserControl
    {
        private int m_iValue, m_iStep;

        public delegate void ButtonClickedHandler();

        [Category("Action")]
        [Description("Fires when the up/down button is clicked.")]
        public event ButtonClickedHandler Change;

        protected virtual void OnButtonClicked()
        {
            // If an event has no subscribers registerd, it will
            // evaluate to null. The test checks that the value is not
            // null, ensuring that there are subsribers before
            // calling the event itself.
            if (Change != null)
            {
                Change();  // Notify Subscribers
            }
        }

        public UpDown()
        {
            InitializeComponent();
            m_iValue = 0;
            m_iStep = 1;
        }

        private void UpDown_Resize(object sender, EventArgs e)
        {
            int intMidPoint;

            intMidPoint = Height / 2;

            btnUp.Top = 0;
            btnUp.Left = 0;
            btnUp.Width = Width;
            btnUp.Height = intMidPoint;

            btnDown.Top = intMidPoint;
            btnDown.Left = 0;
            btnDown.Width = Width;
            btnDown.Height = intMidPoint;
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            m_iValue = m_iStep;
            OnButtonClicked();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            m_iValue = -m_iStep;
            OnButtonClicked();
        }

        [Description("Set at run time to be +/- Interval.")]
        public int Value
        {
            get { return m_iValue; }
        }

        //[Category("")]
        [Description("Gets or sets the interval or step to be returned by the Value property.")]
        public int Interval
        {
            set { m_iStep = value; }
            get { return m_iStep; }
        }
    }
}
