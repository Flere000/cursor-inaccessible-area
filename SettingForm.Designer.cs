namespace CursorInaccessibleArea
{
    partial class SettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            this.xTextBox = new System.Windows.Forms.MaskedTextBox();
            this.yTextBox = new System.Windows.Forms.MaskedTextBox();
            this.labelx = new System.Windows.Forms.Label();
            this.labely = new System.Windows.Forms.Label();
            this.labelw = new System.Windows.Forms.Label();
            this.labelh = new System.Windows.Forms.Label();
            this.wTextBox = new System.Windows.Forms.MaskedTextBox();
            this.hTextBox = new System.Windows.Forms.MaskedTextBox();
            this.addnotch = new System.Windows.Forms.Button();
            this.NotchGenerator = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.設定画面表示 = new System.Windows.Forms.ToolStripMenuItem();
            this.disableNotchs = new System.Windows.Forms.ToolStripMenuItem();
            this.終了 = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.deletenotch = new System.Windows.Forms.Button();
            this.ColorButton = new System.Windows.Forms.Button();
            this.HideNotchs = new System.Windows.Forms.CheckBox();
            this.EditMode = new System.Windows.Forms.CheckBox();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // xTextBox
            // 
            this.xTextBox.Location = new System.Drawing.Point(34, 6);
            this.xTextBox.Name = "xTextBox";
            this.xTextBox.Size = new System.Drawing.Size(50, 19);
            this.xTextBox.TabIndex = 0;
            this.xTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.xTextBox.ValidatingType = typeof(int);
            // 
            // yTextBox
            // 
            this.yTextBox.Location = new System.Drawing.Point(113, 6);
            this.yTextBox.Name = "yTextBox";
            this.yTextBox.Size = new System.Drawing.Size(50, 19);
            this.yTextBox.TabIndex = 1;
            this.yTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.yTextBox.ValidatingType = typeof(int);
            // 
            // labelx
            // 
            this.labelx.AutoSize = true;
            this.labelx.Location = new System.Drawing.Point(11, 9);
            this.labelx.Name = "labelx";
            this.labelx.Size = new System.Drawing.Size(17, 12);
            this.labelx.TabIndex = 2;
            this.labelx.Text = "x :";
            // 
            // labely
            // 
            this.labely.AutoSize = true;
            this.labely.Location = new System.Drawing.Point(90, 9);
            this.labely.Name = "labely";
            this.labely.Size = new System.Drawing.Size(17, 12);
            this.labely.TabIndex = 3;
            this.labely.Text = "y :";
            // 
            // labelw
            // 
            this.labelw.AutoSize = true;
            this.labelw.Location = new System.Drawing.Point(169, 9);
            this.labelw.Name = "labelw";
            this.labelw.Size = new System.Drawing.Size(38, 12);
            this.labelw.TabIndex = 4;
            this.labelw.Text = "width :";
            // 
            // labelh
            // 
            this.labelh.AutoSize = true;
            this.labelh.Location = new System.Drawing.Point(269, 9);
            this.labelh.Name = "labelh";
            this.labelh.Size = new System.Drawing.Size(42, 12);
            this.labelh.TabIndex = 5;
            this.labelh.Text = "height :";
            // 
            // wTextBox
            // 
            this.wTextBox.Location = new System.Drawing.Point(213, 6);
            this.wTextBox.Name = "wTextBox";
            this.wTextBox.Size = new System.Drawing.Size(50, 19);
            this.wTextBox.TabIndex = 6;
            this.wTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // hTextBox
            // 
            this.hTextBox.Location = new System.Drawing.Point(317, 6);
            this.hTextBox.Name = "hTextBox";
            this.hTextBox.Size = new System.Drawing.Size(50, 19);
            this.hTextBox.TabIndex = 7;
            this.hTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // addnotch
            // 
            this.addnotch.Location = new System.Drawing.Point(216, 74);
            this.addnotch.Name = "addnotch";
            this.addnotch.Size = new System.Drawing.Size(75, 23);
            this.addnotch.TabIndex = 8;
            this.addnotch.Text = "領域追加";
            this.addnotch.UseVisualStyleBackColor = true;
            this.addnotch.Click += new System.EventHandler(this.ClickAddNotch);
            // 
            // NotchGenerator
            // 
            this.NotchGenerator.ContextMenuStrip = this.contextMenu;
            this.NotchGenerator.Icon = ((System.Drawing.Icon)(resources.GetObject("NotchGenerator.Icon")));
            this.NotchGenerator.Text = "NotchGenerator";
            this.NotchGenerator.Visible = true;
            this.NotchGenerator.Click += new System.EventHandler(this.Settings_Click);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.設定画面表示,
            this.disableNotchs,
            this.終了});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(147, 70);
            // 
            // 設定画面表示
            // 
            this.設定画面表示.Name = "設定画面表示";
            this.設定画面表示.Size = new System.Drawing.Size(180, 22);
            this.設定画面表示.Text = "設定画面表示";
            this.設定画面表示.Click += new System.EventHandler(this.Settings_Click);
            // 
            // disableNotchs
            // 
            this.disableNotchs.CheckOnClick = true;
            this.disableNotchs.Name = "disableNotchs";
            this.disableNotchs.Size = new System.Drawing.Size(180, 22);
            this.disableNotchs.Text = "領域無効";
            this.disableNotchs.Click += new System.EventHandler(this.ChangeHideNotchs);
            // 
            // 終了
            // 
            this.終了.Name = "終了";
            this.終了.Size = new System.Drawing.Size(180, 22);
            this.終了.Text = "終了";
            this.終了.Click += new System.EventHandler(this.Exit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "label1";
            // 
            // deletenotch
            // 
            this.deletenotch.Location = new System.Drawing.Point(297, 74);
            this.deletenotch.Name = "deletenotch";
            this.deletenotch.Size = new System.Drawing.Size(75, 23);
            this.deletenotch.TabIndex = 10;
            this.deletenotch.Text = "領域削除";
            this.deletenotch.UseVisualStyleBackColor = true;
            this.deletenotch.Click += new System.EventHandler(this.ClickDeleteNotch);
            // 
            // ColorButton
            // 
            this.ColorButton.Location = new System.Drawing.Point(135, 74);
            this.ColorButton.Name = "ColorButton";
            this.ColorButton.Size = new System.Drawing.Size(75, 23);
            this.ColorButton.TabIndex = 11;
            this.ColorButton.Text = "色設定";
            this.ColorButton.UseVisualStyleBackColor = true;
            this.ColorButton.Click += new System.EventHandler(this.ClickColorButton);
            // 
            // HideNotchs
            // 
            this.HideNotchs.AutoSize = true;
            this.HideNotchs.Location = new System.Drawing.Point(300, 45);
            this.HideNotchs.Name = "HideNotchs";
            this.HideNotchs.Size = new System.Drawing.Size(72, 16);
            this.HideNotchs.TabIndex = 12;
            this.HideNotchs.Text = "領域無効";
            this.HideNotchs.UseVisualStyleBackColor = true;
            this.HideNotchs.CheckedChanged += new System.EventHandler(this.ChangeHideNotchs);
            // 
            // EditMode
            // 
            this.EditMode.AutoSize = true;
            this.EditMode.Location = new System.Drawing.Point(211, 45);
            this.EditMode.Name = "EditMode";
            this.EditMode.Size = new System.Drawing.Size(76, 16);
            this.EditMode.TabIndex = 13;
            this.EditMode.Text = "編集モード";
            this.EditMode.UseVisualStyleBackColor = true;
            this.EditMode.Click += new System.EventHandler(this.ClickEditMode);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 109);
            this.Controls.Add(this.EditMode);
            this.Controls.Add(this.HideNotchs);
            this.Controls.Add(this.ColorButton);
            this.Controls.Add(this.deletenotch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addnotch);
            this.Controls.Add(this.hTextBox);
            this.Controls.Add(this.wTextBox);
            this.Controls.Add(this.labelh);
            this.Controls.Add(this.labelw);
            this.Controls.Add(this.labely);
            this.Controls.Add(this.labelx);
            this.Controls.Add(this.yTextBox);
            this.Controls.Add(this.xTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "設定画面";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingForm_FormClosing);
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox xTextBox;
        private System.Windows.Forms.MaskedTextBox yTextBox;
        private System.Windows.Forms.Label labelx;
        private System.Windows.Forms.Label labely;
        private System.Windows.Forms.Label labelw;
        private System.Windows.Forms.Label labelh;
        private System.Windows.Forms.MaskedTextBox wTextBox;
        private System.Windows.Forms.MaskedTextBox hTextBox;
        private System.Windows.Forms.Button addnotch;
        private System.Windows.Forms.NotifyIcon NotchGenerator;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem 設定画面表示;
        private System.Windows.Forms.ToolStripMenuItem 終了;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button deletenotch;
        private System.Windows.Forms.Button ColorButton;
        private System.Windows.Forms.CheckBox HideNotchs;
        private System.Windows.Forms.ToolStripMenuItem disableNotchs;
        private System.Windows.Forms.CheckBox EditMode;
    }
}