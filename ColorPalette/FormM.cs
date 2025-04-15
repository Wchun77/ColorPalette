using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ColorPalette.Properties;


namespace ColorPalette
{
    public partial class FormM : Form
    {
        int R_value, G_value, B_value;
        TextBox copytxt = new TextBox();

        bool ColorChangeLock = true;

        public FormM()
        {
            InitializeComponent();

            Icon = Resources.rgb;

            R_value = Settings.Default.memory_R;
            G_value = Settings.Default.memory_G;
            B_value = Settings.Default.memory_B;

            resetcolor();
            colorchange(R_value, G_value, B_value);
        }

        private void resetcolor()
        {
            colorWheel.Color = Color.FromArgb(R_value, G_value, B_value);
            colorEditor.Color = Color.FromArgb(R_value, G_value, B_value);
            ColorChangeLock = false;
        }

        private void colorWheel_ColorChanged(object sender, EventArgs e)
        {
            if (ColorChangeLock) return;

            var color = colorWheel.Color;
            R_value = color.R;
            G_value = color.G;
            B_value = color.B;

            colorchange(R_value, G_value, B_value);
        }

        private void colorEditor_ColorChanged(object sender, EventArgs e)
        {
            if (ColorChangeLock) return;

            var color = colorEditor.Color;
            R_value = color.R;
            G_value = color.G;
            B_value = color.B;

            colorchange(R_value, G_value, B_value);
        }

        private void uiButton_CopyHex_Click(object sender, EventArgs e)
        {
            copytxt.Text = RgbToHex(colorEditor.Color);
            copytxt.SelectAll();
            copytxt.Copy();
        }

        public static string RgbToHex(Color color)
        {
            // 使用 ColorTranslator 轉換為 HTML Hex 格式 (#RRGGBB)
            return ColorTranslator.ToHtml(color);
        }

        private void uiButton_CopyRGB_Click(object sender, EventArgs e)
        {
            copytxt.Text = $"{R_value}, {G_value}, {B_value}";
            copytxt.SelectAll();
            copytxt.Copy();
        }

        private void colorchange(int R, int G, int B)
        {
            panel_color.BackColor = Color.FromArgb(R, G, B);
            panel_color.Invalidate();
            panel_color.Update();
        }

        private void FormM_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.memory_R = R_value;
            Settings.Default.memory_G = G_value;
            Settings.Default.memory_B = B_value;

            Settings.Default.Save();
        }
    }
}
