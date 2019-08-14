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
            ((System.ComponentModel.ISupportInitialize)(this.PicImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicCoefs)).BeginInit();
            this.SuspendLayout();
            // 
            // PicImage
            // 
            this.PicImage.Location = new System.Drawing.Point(69, 12);
            this.PicImage.Name = "PicImage";
            this.PicImage.Size = new System.Drawing.Size(640, 480);
            this.PicImage.TabIndex = 0;
            this.PicImage.TabStop = false;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(12, 12);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(51, 23);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // PicCoefs
            // 
            this.PicCoefs.Location = new System.Drawing.Point(739, 12);
            this.PicCoefs.Name = "PicCoefs";
            this.PicCoefs.Size = new System.Drawing.Size(256, 256);
            this.PicCoefs.TabIndex = 2;
            this.PicCoefs.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 606);
            this.Controls.Add(this.PicCoefs);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.PicImage);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.PicImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicCoefs)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.PictureBox PicImage;
    private System.Windows.Forms.Button buttonStart;
    private System.Windows.Forms.PictureBox PicCoefs;
  }
}

