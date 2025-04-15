namespace ColorPalette
{
    partial class FormM
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_color = new System.Windows.Forms.Panel();
            this.uiButton_CopyHex = new Sunny.UI.UIButton();
            this.uiButton_CopyRGB = new Sunny.UI.UIButton();
            this.colorWheel = new Cyotek.Windows.Forms.ColorWheel();
            this.colorEditor = new Cyotek.Windows.Forms.ColorEditor();
            this.colorEditorManager = new Cyotek.Windows.Forms.ColorEditorManager();
            this.lightnessColorSlider = new Cyotek.Windows.Forms.LightnessColorSlider();
            this.SuspendLayout();
            // 
            // panel_color
            // 
            this.panel_color.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_color.Location = new System.Drawing.Point(433, 269);
            this.panel_color.Name = "panel_color";
            this.panel_color.Size = new System.Drawing.Size(80, 86);
            this.panel_color.TabIndex = 6;
            // 
            // uiButton_CopyHex
            // 
            this.uiButton_CopyHex.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton_CopyHex.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.uiButton_CopyHex.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.uiButton_CopyHex.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.uiButton_CopyHex.Font = new System.Drawing.Font("Segoe Script", 12F);
            this.uiButton_CopyHex.Location = new System.Drawing.Point(312, 322);
            this.uiButton_CopyHex.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton_CopyHex.Name = "uiButton_CopyHex";
            this.uiButton_CopyHex.RectColor = System.Drawing.Color.Black;
            this.uiButton_CopyHex.RectHoverColor = System.Drawing.Color.Black;
            this.uiButton_CopyHex.RectPressColor = System.Drawing.Color.Black;
            this.uiButton_CopyHex.RectSelectedColor = System.Drawing.Color.Black;
            this.uiButton_CopyHex.Size = new System.Drawing.Size(100, 26);
            this.uiButton_CopyHex.TabIndex = 11;
            this.uiButton_CopyHex.Text = "Hex";
            this.uiButton_CopyHex.TipsFont = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.uiButton_CopyHex.Click += new System.EventHandler(this.uiButton_CopyHex_Click);
            // 
            // uiButton_CopyRGB
            // 
            this.uiButton_CopyRGB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton_CopyRGB.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.uiButton_CopyRGB.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.uiButton_CopyRGB.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.uiButton_CopyRGB.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.uiButton_CopyRGB.Font = new System.Drawing.Font("Segoe Script", 12F);
            this.uiButton_CopyRGB.Location = new System.Drawing.Point(312, 290);
            this.uiButton_CopyRGB.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton_CopyRGB.Name = "uiButton_CopyRGB";
            this.uiButton_CopyRGB.RectColor = System.Drawing.Color.Black;
            this.uiButton_CopyRGB.RectHoverColor = System.Drawing.Color.Black;
            this.uiButton_CopyRGB.RectPressColor = System.Drawing.Color.Black;
            this.uiButton_CopyRGB.RectSelectedColor = System.Drawing.Color.Black;
            this.uiButton_CopyRGB.Size = new System.Drawing.Size(100, 26);
            this.uiButton_CopyRGB.TabIndex = 12;
            this.uiButton_CopyRGB.Text = "RGB";
            this.uiButton_CopyRGB.TipsFont = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.uiButton_CopyRGB.Click += new System.EventHandler(this.uiButton_CopyRGB_Click);
            // 
            // colorWheel
            // 
            this.colorWheel.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.colorWheel.Location = new System.Drawing.Point(330, 21);
            this.colorWheel.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.colorWheel.Name = "colorWheel";
            this.colorWheel.Size = new System.Drawing.Size(183, 192);
            this.colorWheel.TabIndex = 13;
            this.colorWheel.ColorChanged += new System.EventHandler(this.colorWheel_ColorChanged);
            // 
            // colorEditor
            // 
            this.colorEditor.Font = new System.Drawing.Font("Segoe Print", 9.5F);
            this.colorEditor.Location = new System.Drawing.Point(12, 12);
            this.colorEditor.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.colorEditor.Name = "colorEditor";
            this.colorEditor.Padding = new System.Windows.Forms.Padding(5);
            this.colorEditor.ShowAlphaChannel = false;
            this.colorEditor.Size = new System.Drawing.Size(288, 346);
            this.colorEditor.TabIndex = 14;
            this.colorEditor.ColorChanged += new System.EventHandler(this.colorEditor_ColorChanged);
            // 
            // colorEditorManager
            // 
            this.colorEditorManager.ColorEditor = this.colorEditor;
            this.colorEditorManager.ColorWheel = this.colorWheel;
            this.colorEditorManager.LightnessColorSlider = this.lightnessColorSlider;
            // 
            // lightnessColorSlider
            // 
            this.lightnessColorSlider.Location = new System.Drawing.Point(542, 12);
            this.lightnessColorSlider.Name = "lightnessColorSlider";
            this.lightnessColorSlider.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.lightnessColorSlider.Size = new System.Drawing.Size(45, 346);
            this.lightnessColorSlider.TabIndex = 0;
            // 
            // FormM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 367);
            this.Controls.Add(this.colorEditor);
            this.Controls.Add(this.colorWheel);
            this.Controls.Add(this.uiButton_CopyRGB);
            this.Controls.Add(this.uiButton_CopyHex);
            this.Controls.Add(this.panel_color);
            this.Controls.Add(this.lightnessColorSlider);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.Name = "FormM";
            this.Text = "Color Palette";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormM_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel_color;
        private Sunny.UI.UIButton uiButton_CopyHex;
        private Sunny.UI.UIButton uiButton_CopyRGB;
        private Cyotek.Windows.Forms.ColorWheel colorWheel;
        private Cyotek.Windows.Forms.ColorEditor colorEditor;
        private Cyotek.Windows.Forms.ColorEditorManager colorEditorManager;
        private Cyotek.Windows.Forms.LightnessColorSlider lightnessColorSlider;
    }
}

