using System.Drawing;
using System.Windows.Forms;

namespace NightDrive.Helpers.Interface
{
    /// <summary>
    /// Customized color table used for renderer
    /// </summary>
    internal class DarkColorTable : ProfessionalColorTable
    {
        public override Color ButtonCheckedGradientBegin => MainForm.GetGrayColorVariantFromInt(45);

        public override Color ButtonCheckedGradientEnd => MainForm.GetGrayColorVariantFromInt(45);

        public override Color ButtonCheckedGradientMiddle => MainForm.GetGrayColorVariantFromInt(45);

        public override Color ButtonCheckedHighlight => MainForm.GetGrayColorVariantFromInt(45);

        public override Color ButtonCheckedHighlightBorder => MainForm.GetGrayColorVariantFromInt(45);

        public override Color ButtonPressedBorder => MainForm.GetGrayColorVariantFromInt(45);

        public override Color ButtonPressedGradientBegin => MainForm.GetGrayColorVariantFromInt(45);

        public override Color ButtonPressedGradientEnd => MainForm.GetGrayColorVariantFromInt(45);

        public override Color ButtonPressedGradientMiddle => MainForm.GetGrayColorVariantFromInt(45);

        public override Color ButtonPressedHighlight => MainForm.GetGrayColorVariantFromInt(45);

        public override Color ButtonPressedHighlightBorder => MainForm.GetGrayColorVariantFromInt(45);

        public override Color ButtonSelectedBorder => MainForm.GetGrayColorVariantFromInt(100);

        public override Color ButtonSelectedGradientBegin => MainForm.GetGrayColorVariantFromInt(100);

        public override Color ButtonSelectedGradientEnd => MainForm.GetGrayColorVariantFromInt(100);

        public override Color ButtonSelectedGradientMiddle => MainForm.GetGrayColorVariantFromInt(100);

        public override Color ButtonSelectedHighlight => MainForm.GetGrayColorVariantFromInt(100);

        public override Color ButtonSelectedHighlightBorder => MainForm.GetGrayColorVariantFromInt(75);

        public override Color CheckBackground => MainForm.GetGrayColorVariantFromInt(45);

        public override Color CheckPressedBackground => MainForm.GetGrayColorVariantFromInt(45);

        public override Color CheckSelectedBackground => MainForm.GetGrayColorVariantFromInt(45);

        public override Color GripDark => MainForm.GetGrayColorVariantFromInt(100);

        public override Color GripLight => MainForm.GetGrayColorVariantFromInt(45);

        public override Color ImageMarginGradientBegin => MainForm.GetGrayColorVariantFromInt(45);

        public override Color ImageMarginGradientEnd => MainForm.GetGrayColorVariantFromInt(45);

        public override Color ImageMarginGradientMiddle => MainForm.GetGrayColorVariantFromInt(45);

        public override Color ImageMarginRevealedGradientBegin => MainForm.GetGrayColorVariantFromInt(45);

        public override Color ImageMarginRevealedGradientEnd => MainForm.GetGrayColorVariantFromInt(45);

        public override Color ImageMarginRevealedGradientMiddle => MainForm.GetGrayColorVariantFromInt(45);

        public override Color MenuBorder => MainForm.GetGrayColorVariantFromInt(100); //added for changing the menu border

        public override Color MenuItemBorder => MainForm.GetGrayColorVariantFromInt(100);

        public override Color MenuItemPressedGradientBegin => MainForm.GetGrayColorVariantFromInt(100);

        public override Color MenuItemPressedGradientEnd => MainForm.GetGrayColorVariantFromInt(100);

        public override Color MenuItemPressedGradientMiddle => MainForm.GetGrayColorVariantFromInt(100);

        public override Color MenuItemSelected => MainForm.GetGrayColorVariantFromInt(100);

        public override Color MenuItemSelectedGradientBegin => MainForm.GetGrayColorVariantFromInt(100);

        public override Color MenuItemSelectedGradientEnd => MainForm.GetGrayColorVariantFromInt(100);

        public override Color MenuStripGradientBegin => MainForm.GetGrayColorVariantFromInt(100);

        public override Color MenuStripGradientEnd => MainForm.GetGrayColorVariantFromInt(100);

        public override Color OverflowButtonGradientBegin => MainForm.GetGrayColorVariantFromInt(45);

        public override Color OverflowButtonGradientEnd => MainForm.GetGrayColorVariantFromInt(45);

        public override Color OverflowButtonGradientMiddle => MainForm.GetGrayColorVariantFromInt(45);

        public override Color RaftingContainerGradientBegin => MainForm.GetGrayColorVariantFromInt(45);

        public override Color RaftingContainerGradientEnd => MainForm.GetGrayColorVariantFromInt(45);

        public override Color SeparatorDark => Color.White;

        public override Color SeparatorLight => MainForm.GetGrayColorVariantFromInt(45);

        public override Color StatusStripGradientBegin => MainForm.GetGrayColorVariantFromInt(45);

        public override Color StatusStripGradientEnd => MainForm.GetGrayColorVariantFromInt(45);

        public override Color ToolStripBorder => MainForm.GetGrayColorVariantFromInt(45);

        public override Color ToolStripContentPanelGradientBegin => MainForm.GetGrayColorVariantFromInt(45);

        public override Color ToolStripContentPanelGradientEnd => MainForm.GetGrayColorVariantFromInt(45);

        public override Color ToolStripDropDownBackground => MainForm.GetGrayColorVariantFromInt(45);

        public override Color ToolStripGradientBegin => MainForm.GetGrayColorVariantFromInt(45);

        public override Color ToolStripGradientEnd => MainForm.GetGrayColorVariantFromInt(45);

        public override Color ToolStripGradientMiddle => MainForm.GetGrayColorVariantFromInt(45);

        public override Color ToolStripPanelGradientBegin => MainForm.GetGrayColorVariantFromInt(45);

        public override Color ToolStripPanelGradientEnd => MainForm.GetGrayColorVariantFromInt(45);
    }
}
