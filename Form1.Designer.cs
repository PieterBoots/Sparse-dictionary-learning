namespace WindowsFormsApplication1
{
  partial class Form1
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
            this.PicImage = new System.Windows.Forms.PictureBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.PicCoefs = new System.Windows.Forms.PictureBox();
            this.coefs_zero = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cbDepth = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbQuant = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.PicImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicCoefs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coefs_zero)).BeginInit();
            this.SuspendLayout();
            // 
            // PicImage
            // 
            this.PicImage.Location = new System.Drawing.Point(95, 12);
            this.PicImage.Name = "PicImage";
            this.PicImage.Size = new System.Drawing.Size(1280, 960);
            this.PicImage.TabIndex = 0;
            this.PicImage.TabStop = false;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(6, 41);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(83, 23);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Start ksvd";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // PicCoefs
            // 
            this.PicCoefs.Location = new System.Drawing.Point(1407, 12);
            this.PicCoefs.Name = "PicCoefs";
            this.PicCoefs.Size = new System.Drawing.Size(256, 256);
            this.PicCoefs.TabIndex = 2;
            this.PicCoefs.TabStop = false;
            // 
            // coefs_zero
            // 
            this.coefs_zero.Location = new System.Drawing.Point(1407, 294);
            this.coefs_zero.Name = "coefs_zero";
            this.coefs_zero.Size = new System.Drawing.Size(276, 240);
            this.coefs_zero.TabIndex = 3;
            this.coefs_zero.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Start basic";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbDepth
            // 
            this.cbDepth.FormattingEnabled = true;
            this.cbDepth.Items.AddRange(new object[] {
            "2",
            "4",
            "8",
            "16",
            "32"});
            this.cbDepth.Location = new System.Drawing.Point(27, 90);
            this.cbDepth.Name = "cbDepth";
            this.cbDepth.Size = new System.Drawing.Size(62, 21);
            this.cbDepth.TabIndex = 5;
            this.cbDepth.Text = "64";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Depth";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Quantize";
            // 
            // cbQuant
            // 
            this.cbQuant.FormattingEnabled = true;
            this.cbQuant.Items.AddRange(new object[] {
            "1",
            "2",
            "4",
            "8",
            "16",
            "32",
            "64"});
            this.cbQuant.Location = new System.Drawing.Point(27, 130);
            this.cbQuant.Name = "cbQuant";
            this.cbQuant.Size = new System.Drawing.Size(62, 21);
            this.cbQuant.TabIndex = 8;
            this.cbQuant.Text = "1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1735, 1005);
            this.Controls.Add(this.cbQuant);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbDepth);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.coefs_zero);
            this.Controls.Add(this.PicCoefs);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.PicImage);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.PicImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicCoefs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coefs_zero)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox PicImage;
    private System.Windows.Forms.Button buttonStart;
    private System.Windows.Forms.PictureBox PicCoefs;
        private System.Windows.Forms.PictureBox coefs_zero;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbDepth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbQuant;
    }
}

