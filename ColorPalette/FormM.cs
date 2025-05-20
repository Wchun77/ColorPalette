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
using Sunny.UI;
using Sunny.UI.Win32;
using HslColor = Cyotek.Windows.Forms.HslColor;

namespace ColorPalette
{
    public partial class FormM : Form
    {
        int R_value, G_value, B_value;
        double H_value, S_value, L_value;

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
            H_value = Settings.Default.memory_H;
            S_value = Settings.Default.memory_S;
            L_value = Settings.Default.memory_L;

            //Color colordefault = Color.FromArgb(R_value, G_value, B_value);
            //colorWheel.Color = colordefault;
            //colorEditor.Color = colordefault;

            HslColor hSLColor = new HslColor(H_value, S_value, L_value);
            colorWheel.HslColor = hSLColor;
            colorEditor.HslColor = hSLColor;

            colorchange(hSLColor);

            ColorChangeLock = false;
        }

        private void colorWheel_ColorChanged(object sender, EventArgs e)
        {
            if (ColorChangeLock) return;

            ColorChangeLock = true; // 標記開始更新

            // 從 Wheel 取得 H 和 S
            double wheelH = colorWheel.HslColor.H;
            double wheelS = colorWheel.HslColor.S;

            // 從 Editor 取得 *目前的* L
            double editorL = colorEditor.HslColor.L;

            // 假設 Editor 的 L 為 100 或 0 將 wheelS 這個變數設為 0 等等組合成 Editor 顏色的時候 S 就會為 0
            if (editorL == 1 || editorL == 0) wheelS = 0;

            // 組合新的 HslColor (Wheel 的 H/S + Editor 的 L)
            HslColor newColorForEditor = new HslColor(wheelH, wheelS, editorL);
            colorEditor.HslColor = newColorForEditor;

            colorchange(colorEditor.HslColor);

            ColorChangeLock = false;
        }

        private void colorEditor_ColorChanged(object sender, EventArgs e)
        {
            if (ColorChangeLock) return;

            ColorChangeLock = true; // 標記開始更新

            // 從 Editor 取得 H 、 S 、 L 值
            double editorH = colorEditor.HslColor.H;
            double editorS = colorEditor.HslColor.S;
            double editorL = colorEditor.HslColor.L;

            // 獲取 Wheel *目前* 的 L 值
            double wheelL = colorWheel.HslColor.L;

            // Editor 的 L 屬性為 100 或 0 時 將自己的 S 固定在 0
            if (editorL == 1 || editorL == 0)
            {
                editorS = 0;
                HslColor newColorForEditor = new HslColor(editorH, editorS, editorL);
                colorEditor.HslColor = newColorForEditor;
            }

            // 組合新的 HslColor(Editor 的 H/S + Wheel 的 L)
            HslColor newColorForWheel = new HslColor(editorH, editorS, wheelL);
            colorWheel.HslColor = newColorForWheel;

            colorchange(colorEditor.HslColor);

            ColorChangeLock = false; // 標記更新結束
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

        private void colorchange(HslColor hSLColor)
        {
            H_value = hSLColor.H;
            S_value = hSLColor.S;
            L_value = hSLColor.L;
            HslColor newColorForPanel = new HslColor(H_value, S_value, L_value);
            panel_color.BackColor = newColorForPanel;
            panel_color.Refresh();
        }
        private void FormM_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.memory_R = R_value;
            Settings.Default.memory_G = G_value;
            Settings.Default.memory_B = B_value;
            Settings.Default.memory_H = H_value;
            Settings.Default.memory_S = S_value;
            Settings.Default.memory_L = L_value;

            Settings.Default.Save();
        }
    }
}
