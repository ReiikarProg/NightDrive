using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NightDrive.Helpers.Interface
{
    /// <summary>
    /// Color table used for default (light renderer).
    /// </summary>
    internal class LightColorTable : ProfessionalColorTable
    {
        public override Color ToolStripBorder => Color.White;

        public override Color ToolStripContentPanelGradientBegin => Color.White;

        public override Color ToolStripContentPanelGradientEnd => Color.White;

        public override Color ToolStripDropDownBackground => Color.White;

        public override Color ToolStripGradientBegin => Color.White;

        public override Color ToolStripGradientEnd => Color.White;

        public override Color ToolStripGradientMiddle => Color.White;

        public override Color ToolStripPanelGradientBegin => Color.White;

        public override Color ToolStripPanelGradientEnd => Color.White;
    }
}
