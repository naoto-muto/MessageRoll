namespace WindowsFormsApp
{
    partial class Main
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.ScrollTimer = new System.Windows.Forms.Timer(this.components);
            this.MessagePictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.MessagePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ScrollTimer
            // 
            this.ScrollTimer.Interval = 50;
            this.ScrollTimer.Tick += new System.EventHandler(this.ScrollTimer_Tick);
            // 
            // MessagePictureBox
            // 
            resources.ApplyResources(this.MessagePictureBox, "MessagePictureBox");
            this.MessagePictureBox.Name = "MessagePictureBox";
            this.MessagePictureBox.TabStop = false;
            // 
            // Main
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MessagePictureBox);
            this.Name = "Main";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MessagePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer ScrollTimer;
        private System.Windows.Forms.PictureBox MessagePictureBox;
    }
}

