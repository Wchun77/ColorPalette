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

        // 防止開啟初始化時 觸發 colorchange
        // 防止改變 A 物件時 -> 變動 B 物件並重複觸發 colorchange
        bool ColorChangeLock = true;

        public FormM()
        {
            InitializeComponent();
            Icon = Resources.rgb;
            resetcolor();
        }

        private void resetcolor()
        {
            R_value = Settings.Default.memory_R;
            G_value = Settings.Default.memory_G;
            B_value = Settings.Default.memory_B;

            Color colordefault = Color.FromArgb(R_value, G_value, B_value);

            colorWheel.Color = colordefault;
            colorEditor.Color = colordefault;
            colorchange(colordefault);

            ColorChangeLock = false;
        }

        private void colorWheel_ColorChanged(object sender, EventArgs e)
        {
            if (ColorChangeLock) return;

            try
            {
                ColorChangeLock = true; // 標記開始更新

                // 1. 從 Wheel 取得 H 和 S
                double wheelH = colorWheel.HslColor.H;
                double wheelS = colorWheel.HslColor.S;

                // 2. 從 Editor 取得 *目前的* L
                double editorL = colorEditor.HslColor.L;

                // 3. 組合新的 HslColor (Wheel 的 H/S + Editor 的 L)
                var newColorForEditor = new Cyotek.Windows.Forms.HslColor(wheelH, wheelS, editorL);

                // 4. 更新 Editor
                colorEditor.HslColor = newColorForEditor;

                colorchange(colorWheel.Color);
            }
            finally
            {
                ColorChangeLock = false;
            }
        }

        private void colorEditor_ColorChanged(object sender, EventArgs e)
        {
            if (ColorChangeLock) return;

            try
            {
                ColorChangeLock = true; // 標記開始更新

                // 1. 從 Editor 取得 H 和 S 值
                double editorH = colorEditor.HslColor.H;
                double editorS = colorEditor.HslColor.S;

                // 2. 獲取 Wheel *目前* 的 L 值
                double wheelL = colorWheel.HslColor.L;

                // 3. 組合新的 HslColor(Editor 的 H/S + Wheel 的 L)
                var newColorForWheel = new Cyotek.Windows.Forms.HslColor(editorH, editorS, wheelL);

                // 4. 更新 Wheel
                colorWheel.HslColor = newColorForWheel;

                colorchange(colorEditor.Color);
            }
            finally
            {
                ColorChangeLock = false; // 標記更新結束
            }
        }

        private void uiButton_CopyHex_Click(object sender, EventArgs e)
        {
            // 不用物件的顏色作參考是避免直接出現文字 -> Black
            copytxt.Text = RgbToHex(Color.FromArgb(R_value, G_value, B_value));
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

        private void colorchange(Color color)
        {
            R_value = color.R;
            G_value = color.G;
            B_value = color.B;
            panel_color.BackColor = color;
            panel_color.Refresh();
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
