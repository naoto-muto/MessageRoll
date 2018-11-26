namespace MessageRoll.Operate
{
    partial class OperateForm
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
            this.Submit = new System.Windows.Forms.Button();
            this.MessageTextField = new System.Windows.Forms.TextBox();
            this.ColorDialog = new System.Windows.Forms.ColorDialog();
            this.ColorButton = new System.Windows.Forms.Button();
            this.FontColorPictureBox = new System.Windows.Forms.PictureBox();
            this.FontDialog = new System.Windows.Forms.FontDialog();
            this.FontSizeTextField = new System.Windows.Forms.TextBox();
            this.FontFamilyButton = new System.Windows.Forms.Button();
            this.FontFamilyTextField = new System.Windows.Forms.TextBox();
            this.ResetButton = new System.Windows.Forms.Button();
            this.ChromakeyButton = new System.Windows.Forms.Button();
            this.ChromakeyPictureBox = new System.Windows.Forms.PictureBox();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.ConstRadio = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.RandomRadio = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.FontColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChromakeyPictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Submit
            // 
            this.Submit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Submit.Location = new System.Drawing.Point(377, 221);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(75, 23);
            this.Submit.TabIndex = 0;
            this.Submit.Text = "テスト";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // MessageTextField
            // 
            this.MessageTextField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MessageTextField.Location = new System.Drawing.Point(12, 223);
            this.MessageTextField.Name = "MessageTextField";
            this.MessageTextField.Size = new System.Drawing.Size(359, 19);
            this.MessageTextField.TabIndex = 1;
            // 
            // ColorButton
            // 
            this.ColorButton.Location = new System.Drawing.Point(93, 70);
            this.ColorButton.Name = "ColorButton";
            this.ColorButton.Size = new System.Drawing.Size(75, 23);
            this.ColorButton.TabIndex = 2;
            this.ColorButton.Text = "色を選択";
            this.ColorButton.UseVisualStyleBackColor = true;
            this.ColorButton.Click += new System.EventHandler(this.ColorButton_Click);
            // 
            // FontColorPictureBox
            // 
            this.FontColorPictureBox.BackColor = System.Drawing.Color.White;
            this.FontColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.FontColorPictureBox.Location = new System.Drawing.Point(174, 70);
            this.FontColorPictureBox.Name = "FontColorPictureBox";
            this.FontColorPictureBox.Size = new System.Drawing.Size(38, 23);
            this.FontColorPictureBox.TabIndex = 3;
            this.FontColorPictureBox.TabStop = false;
            // 
            // FontSizeTextField
            // 
            this.FontSizeTextField.Location = new System.Drawing.Point(405, 72);
            this.FontSizeTextField.Name = "FontSizeTextField";
            this.FontSizeTextField.ReadOnly = true;
            this.FontSizeTextField.Size = new System.Drawing.Size(38, 19);
            this.FontSizeTextField.TabIndex = 5;
            this.FontSizeTextField.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // FontFamilyButton
            // 
            this.FontFamilyButton.Location = new System.Drawing.Point(218, 70);
            this.FontFamilyButton.Name = "FontFamilyButton";
            this.FontFamilyButton.Size = new System.Drawing.Size(75, 23);
            this.FontFamilyButton.TabIndex = 6;
            this.FontFamilyButton.Text = "フォント";
            this.FontFamilyButton.UseVisualStyleBackColor = true;
            this.FontFamilyButton.Click += new System.EventHandler(this.FontFamilyButton_Click);
            // 
            // FontFamilyTextField
            // 
            this.FontFamilyTextField.AcceptsReturn = true;
            this.FontFamilyTextField.Location = new System.Drawing.Point(299, 72);
            this.FontFamilyTextField.Name = "FontFamilyTextField";
            this.FontFamilyTextField.ReadOnly = true;
            this.FontFamilyTextField.Size = new System.Drawing.Size(100, 19);
            this.FontFamilyTextField.TabIndex = 7;
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(12, 12);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(75, 23);
            this.ResetButton.TabIndex = 8;
            this.ResetButton.Text = "リセット";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // ChromakeyButton
            // 
            this.ChromakeyButton.Location = new System.Drawing.Point(12, 41);
            this.ChromakeyButton.Name = "ChromakeyButton";
            this.ChromakeyButton.Size = new System.Drawing.Size(75, 23);
            this.ChromakeyButton.TabIndex = 9;
            this.ChromakeyButton.Text = "クロマキー";
            this.ChromakeyButton.UseVisualStyleBackColor = true;
            this.ChromakeyButton.Click += new System.EventHandler(this.ChromakeyButton_Click);
            // 
            // ChromakeyPictureBox
            // 
            this.ChromakeyPictureBox.BackColor = System.Drawing.Color.Lime;
            this.ChromakeyPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ChromakeyPictureBox.Location = new System.Drawing.Point(93, 41);
            this.ChromakeyPictureBox.Name = "ChromakeyPictureBox";
            this.ChromakeyPictureBox.Size = new System.Drawing.Size(38, 23);
            this.ChromakeyPictureBox.TabIndex = 10;
            this.ChromakeyPictureBox.TabStop = false;
            // 
            // UpdateButton
            // 
            this.UpdateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateButton.Location = new System.Drawing.Point(377, 12);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(75, 23);
            this.UpdateButton.TabIndex = 11;
            this.UpdateButton.Text = "更新";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // ConstRadio
            // 
            this.ConstRadio.AutoSize = true;
            this.ConstRadio.Checked = true;
            this.ConstRadio.Location = new System.Drawing.Point(3, 3);
            this.ConstRadio.Name = "ConstRadio";
            this.ConstRadio.Size = new System.Drawing.Size(47, 16);
            this.ConstRadio.TabIndex = 12;
            this.ConstRadio.TabStop = true;
            this.ConstRadio.Text = "固定";
            this.ConstRadio.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.RandomRadio);
            this.panel1.Controls.Add(this.ConstRadio);
            this.panel1.Location = new System.Drawing.Point(12, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(75, 47);
            this.panel1.TabIndex = 13;
            // 
            // RandomRadio
            // 
            this.RandomRadio.AutoSize = true;
            this.RandomRadio.Location = new System.Drawing.Point(3, 25);
            this.RandomRadio.Name = "RandomRadio";
            this.RandomRadio.Size = new System.Drawing.Size(59, 16);
            this.RandomRadio.TabIndex = 14;
            this.RandomRadio.TabStop = true;
            this.RandomRadio.Text = "ランダム";
            this.RandomRadio.UseVisualStyleBackColor = true;
            // 
            // OperateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 256);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.ChromakeyPictureBox);
            this.Controls.Add(this.ChromakeyButton);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.FontFamilyTextField);
            this.Controls.Add(this.FontFamilyButton);
            this.Controls.Add(this.FontSizeTextField);
            this.Controls.Add(this.FontColorPictureBox);
            this.Controls.Add(this.ColorButton);
            this.Controls.Add(this.MessageTextField);
            this.Controls.Add(this.Submit);
            this.Name = "OperateForm";
            this.Text = "管理ウィンドウ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OperateForm_FormClosing);
            this.Load += new System.EventHandler(this.OperateForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FontColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChromakeyPictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.TextBox MessageTextField;
        private System.Windows.Forms.ColorDialog ColorDialog;
        private System.Windows.Forms.Button ColorButton;
        private System.Windows.Forms.PictureBox FontColorPictureBox;
        private System.Windows.Forms.FontDialog FontDialog;
        private System.Windows.Forms.TextBox FontSizeTextField;
        private System.Windows.Forms.Button FontFamilyButton;
        private System.Windows.Forms.TextBox FontFamilyTextField;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Button ChromakeyButton;
        private System.Windows.Forms.PictureBox ChromakeyPictureBox;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.RadioButton ConstRadio;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton RandomRadio;
    }
}