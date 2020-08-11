namespace Face_Recognition
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureCapture = new System.Windows.Forms.PictureBox();
            this.buttonDetect = new System.Windows.Forms.Button();
            this.buttonCapture = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCapture)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureCapture
            // 
            this.pictureCapture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureCapture.Location = new System.Drawing.Point(12, 12);
            this.pictureCapture.Name = "pictureCapture";
            this.pictureCapture.Size = new System.Drawing.Size(989, 549);
            this.pictureCapture.TabIndex = 0;
            this.pictureCapture.TabStop = false;
            // 
            // buttonDetect
            // 
            this.buttonDetect.Location = new System.Drawing.Point(275, 638);
            this.buttonDetect.Name = "buttonDetect";
            this.buttonDetect.Size = new System.Drawing.Size(187, 49);
            this.buttonDetect.TabIndex = 1;
            this.buttonDetect.Text = "Detect";
            this.buttonDetect.UseVisualStyleBackColor = true;
            this.buttonDetect.Click += new System.EventHandler(this.buttonDetect_Click_1);
            // 
            // buttonCapture
            // 
            this.buttonCapture.Location = new System.Drawing.Point(82, 638);
            this.buttonCapture.Name = "buttonCapture";
            this.buttonCapture.Size = new System.Drawing.Size(187, 49);
            this.buttonCapture.TabIndex = 2;
            this.buttonCapture.Text = "Capture";
            this.buttonCapture.UseVisualStyleBackColor = true;
            this.buttonCapture.Click += new System.EventHandler(this.buttonCapture_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox1.Location = new System.Drawing.Point(82, 583);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(919, 27);
            this.textBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 590);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Rtsp Url :";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(814, 638);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(187, 49);
            this.button1.TabIndex = 5;
            this.button1.Text = "WebCam";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(468, 638);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(187, 49);
            this.button2.TabIndex = 6;
            this.button2.Text = "Stop the Video";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 719);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonCapture);
            this.Controls.Add(this.buttonDetect);
            this.Controls.Add(this.pictureCapture);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureCapture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureCapture;
        private System.Windows.Forms.Button buttonDetect;
        private System.Windows.Forms.Button buttonCapture;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

