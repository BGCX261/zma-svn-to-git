using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Zicore.MinecraftAdmin
{
    public class EnhancedSplitContainer : SplitContainer
    {
        private Color splitterColor = SystemColors.Control;

        [Description("The color of the splitter portion of the EnhancedSplitContainer.")]
        [Category("Appearance")]
        public Color SplitterColor
        {
            get
            {
                return splitterColor;
            }
            set
            {
                splitterColor = value;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (SolidBrush brush = new SolidBrush(splitterColor))
            {
                e.Graphics.FillRectangle(brush, SplitterRectangle);
            }

            base.OnPaint(e);
        }

        public bool ShouldSerializeSplitterColor()
        {
            return splitterColor != SystemColors.Control;
        }

        public void ResetSplitterColor()
        {
            splitterColor = SystemColors.Control;
        }
    }

}
