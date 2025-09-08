namespace MeteoStats
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            checkBoxRain = new CheckBox();
            checkBoxTemp = new CheckBox();
            checkBoxUv = new CheckBox();
            ville = new Label();
            checkBoxCelsius = new CheckBox();
            checkBoxFahr = new CheckBox();
            graphicPlot = new ScottPlot.WinForms.FormsPlot();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(46, 22);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(45, 41);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(94, 22);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(45, 41);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(138, 22);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(45, 41);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            // 
            // checkBoxRain
            // 
            checkBoxRain.AutoSize = true;
            checkBoxRain.Location = new Point(60, 71);
            checkBoxRain.Name = "checkBoxRain";
            checkBoxRain.Size = new Size(15, 14);
            checkBoxRain.TabIndex = 3;
            checkBoxRain.UseVisualStyleBackColor = true;
            checkBoxRain.CheckedChanged += CheckBoxRain_CheckedChanged;
            // 
            // checkBoxTemp
            // 
            checkBoxTemp.AutoSize = true;
            checkBoxTemp.Location = new Point(106, 71);
            checkBoxTemp.Name = "checkBoxTemp";
            checkBoxTemp.Size = new Size(15, 14);
            checkBoxTemp.TabIndex = 4;
            checkBoxTemp.UseVisualStyleBackColor = true;
            checkBoxTemp.CheckedChanged += checkBoxTemp_CheckedChanged;
            // 
            // checkBoxUv
            // 
            checkBoxUv.AutoSize = true;
            checkBoxUv.Location = new Point(153, 71);
            checkBoxUv.Name = "checkBoxUv";
            checkBoxUv.Size = new Size(15, 14);
            checkBoxUv.TabIndex = 5;
            checkBoxUv.UseVisualStyleBackColor = true;
            checkBoxUv.CheckedChanged += checkBoxUv_CheckedChanged;
            // 
            // ville
            // 
            ville.AutoSize = true;
            ville.Font = new Font("Segoe UI", 12F);
            ville.Location = new Point(396, 22);
            ville.Name = "ville";
            ville.Size = new Size(47, 21);
            ville.TabIndex = 6;
            ville.Text = "Ville :";
            // 
            // checkBoxCelsius
            // 
            checkBoxCelsius.AutoSize = true;
            checkBoxCelsius.Font = new Font("Segoe UI", 11F);
            checkBoxCelsius.Location = new Point(915, 39);
            checkBoxCelsius.Name = "checkBoxCelsius";
            checkBoxCelsius.Size = new Size(43, 24);
            checkBoxCelsius.TabIndex = 7;
            checkBoxCelsius.Text = "C°";
            checkBoxCelsius.UseVisualStyleBackColor = true;
            checkBoxCelsius.CheckedChanged += checkBoxCelsius_CheckedChanged;
            // 
            // checkBoxFahr
            // 
            checkBoxFahr.AutoSize = true;
            checkBoxFahr.Font = new Font("Segoe UI", 11F);
            checkBoxFahr.Location = new Point(986, 39);
            checkBoxFahr.Name = "checkBoxFahr";
            checkBoxFahr.Size = new Size(41, 24);
            checkBoxFahr.TabIndex = 8;
            checkBoxFahr.Text = "F°";
            checkBoxFahr.UseVisualStyleBackColor = true;
            checkBoxFahr.CheckedChanged += checkBoxFahr_CheckedChanged;
            // 
            // graphicPlot
            // 
            graphicPlot.DisplayScale = 1F;
            graphicPlot.Location = new Point(27, 114);
            graphicPlot.Name = "graphicPlot";
            graphicPlot.Size = new Size(1126, 615);
            graphicPlot.TabIndex = 9;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 961);
            Controls.Add(graphicPlot);
            Controls.Add(checkBoxFahr);
            Controls.Add(checkBoxCelsius);
            Controls.Add(ville);
            Controls.Add(checkBoxUv);
            Controls.Add(checkBoxTemp);
            Controls.Add(checkBoxRain);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Name = "MainWindow";
            Text = "MeteoStats";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private CheckBox checkBoxRain;
        private CheckBox checkBoxTemp;
        private CheckBox checkBoxUv;
        private Label ville;
        private CheckBox checkBoxCelsius;
        private CheckBox checkBoxFahr;
        private ScottPlot.WinForms.FormsPlot graphicPlot;
    }
}
