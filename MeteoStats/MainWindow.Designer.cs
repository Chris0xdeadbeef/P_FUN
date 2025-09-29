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
            checkBoxFahrenheit = new CheckBox();
            graphicPlot = new ScottPlot.WinForms.FormsPlot();
            fonctionLabel = new Label();
            functionInput = new TextBox();
            label1 = new Label();
            beginDateInput = new TextBox();
            endDateInput = new TextBox();
            label2 = new Label();
            timeBeginInput = new TextBox();
            timeEndInput = new TextBox();
            importButton = new Button();
            exportButton = new Button();
            titleHorizon = new Label();
            titleVertical = new Label();
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
            checkBoxRain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
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
            checkBoxTemp.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            checkBoxTemp.AutoSize = true;
            checkBoxTemp.Location = new Point(109, 71);
            checkBoxTemp.Name = "checkBoxTemp";
            checkBoxTemp.Size = new Size(15, 14);
            checkBoxTemp.TabIndex = 4;
            checkBoxTemp.UseVisualStyleBackColor = true;
            checkBoxTemp.CheckedChanged += CheckBoxTemp_CheckedChanged;
            // 
            // checkBoxUv
            // 
            checkBoxUv.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            checkBoxUv.AutoSize = true;
            checkBoxUv.Location = new Point(154, 71);
            checkBoxUv.Name = "checkBoxUv";
            checkBoxUv.Size = new Size(15, 14);
            checkBoxUv.TabIndex = 5;
            checkBoxUv.UseVisualStyleBackColor = true;
            checkBoxUv.CheckedChanged += CheckBoxUv_CheckedChanged;
            // 
            // ville
            // 
            ville.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
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
            checkBoxCelsius.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            checkBoxCelsius.AutoSize = true;
            checkBoxCelsius.Font = new Font("Segoe UI", 11F);
            checkBoxCelsius.Location = new Point(916, 39);
            checkBoxCelsius.Name = "checkBoxCelsius";
            checkBoxCelsius.Size = new Size(43, 24);
            checkBoxCelsius.TabIndex = 7;
            checkBoxCelsius.Text = "C°";
            checkBoxCelsius.UseVisualStyleBackColor = true;
            checkBoxCelsius.CheckedChanged += CheckBoxCelsius_CheckedChanged;
            // 
            // checkBoxFahrenheit
            // 
            checkBoxFahrenheit.AutoSize = true;
            checkBoxFahrenheit.Font = new Font("Segoe UI", 11F);
            checkBoxFahrenheit.Location = new Point(986, 39);
            checkBoxFahrenheit.Name = "checkBoxFahrenheit";
            checkBoxFahrenheit.Size = new Size(41, 24);
            checkBoxFahrenheit.TabIndex = 8;
            checkBoxFahrenheit.Text = "F°";
            checkBoxFahrenheit.UseVisualStyleBackColor = true;
            // 
            // graphicPlot
            // 
            graphicPlot.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            graphicPlot.DisplayScale = 1F;
            graphicPlot.Location = new Point(27, 114);
            graphicPlot.Name = "graphicPlot";
            graphicPlot.Size = new Size(1126, 615);
            graphicPlot.TabIndex = 9;
            // 
            // fonctionLabel
            // 
            fonctionLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            fonctionLabel.AutoSize = true;
            fonctionLabel.BackColor = SystemColors.ActiveCaption;
            fonctionLabel.Font = new Font("Segoe UI", 12F);
            fonctionLabel.Location = new Point(56, 763);
            fonctionLabel.Name = "fonctionLabel";
            fonctionLabel.Size = new Size(35, 21);
            fonctionLabel.TabIndex = 10;
            fonctionLabel.Text = "f(x):";
            // 
            // functionInput
            // 
            functionInput.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            functionInput.BackColor = SystemColors.ActiveCaption;
            functionInput.Font = new Font("Segoe UI", 12F);
            functionInput.Location = new Point(94, 760);
            functionInput.Name = "functionInput";
            functionInput.Size = new Size(1044, 29);
            functionInput.TabIndex = 12;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveBorder;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(46, 824);
            label1.Name = "label1";
            label1.Size = new Size(86, 21);
            label1.TabIndex = 13;
            label1.Text = "Date début";
            // 
            // beginDateInput
            // 
            beginDateInput.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            beginDateInput.BackColor = SystemColors.ActiveCaption;
            beginDateInput.Location = new Point(132, 823);
            beginDateInput.Name = "beginDateInput";
            beginDateInput.Size = new Size(85, 23);
            beginDateInput.TabIndex = 14;
            // 
            // endDateInput
            // 
            endDateInput.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            endDateInput.BackColor = SystemColors.ActiveCaption;
            endDateInput.Location = new Point(132, 852);
            endDateInput.Name = "endDateInput";
            endDateInput.Size = new Size(85, 23);
            endDateInput.TabIndex = 16;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ActiveBorder;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(68, 853);
            label2.Name = "label2";
            label2.Size = new Size(64, 21);
            label2.TabIndex = 15;
            label2.Text = "Date fin";
            // 
            // timeBeginInput
            // 
            timeBeginInput.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            timeBeginInput.BackColor = SystemColors.ActiveCaption;
            timeBeginInput.Location = new Point(239, 822);
            timeBeginInput.Name = "timeBeginInput";
            timeBeginInput.Size = new Size(85, 23);
            timeBeginInput.TabIndex = 17;
            // 
            // timeEndInput
            // 
            timeEndInput.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            timeEndInput.BackColor = SystemColors.ActiveCaption;
            timeEndInput.Location = new Point(239, 853);
            timeEndInput.Name = "timeEndInput";
            timeEndInput.Size = new Size(85, 23);
            timeEndInput.TabIndex = 18;
            // 
            // importButton
            // 
            importButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            importButton.Location = new Point(1013, 824);
            importButton.Name = "importButton";
            importButton.Size = new Size(92, 35);
            importButton.TabIndex = 19;
            importButton.Text = "Import";
            importButton.UseVisualStyleBackColor = true;
            importButton.Click += ImportButton_Click;
            // 
            // exportButton
            // 
            exportButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            exportButton.Location = new Point(1013, 865);
            exportButton.Name = "exportButton";
            exportButton.Size = new Size(92, 35);
            exportButton.TabIndex = 20;
            exportButton.Text = "Export";
            exportButton.UseVisualStyleBackColor = true;
            // 
            // titleHorizon
            // 
            titleHorizon.AutoSize = true;
            titleHorizon.Location = new Point(533, 732);
            titleHorizon.Name = "titleHorizon";
            titleHorizon.Size = new Size(38, 15);
            titleHorizon.TabIndex = 21;
            titleHorizon.Text = "label3";
            // 
            // titleVertical
            // 
            titleVertical.AutoSize = true;
            titleVertical.Location = new Point(12, 379);
            titleVertical.Name = "titleVertical";
            titleVertical.Size = new Size(38, 15);
            titleVertical.TabIndex = 22;
            titleVertical.Text = "label3";
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 961);
            Controls.Add(titleVertical);
            Controls.Add(titleHorizon);
            Controls.Add(exportButton);
            Controls.Add(importButton);
            Controls.Add(timeEndInput);
            Controls.Add(timeBeginInput);
            Controls.Add(endDateInput);
            Controls.Add(label2);
            Controls.Add(beginDateInput);
            Controls.Add(label1);
            Controls.Add(functionInput);
            Controls.Add(fonctionLabel);
            Controls.Add(graphicPlot);
            Controls.Add(checkBoxFahrenheit);
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
            Resize += MainWindow_Resize;
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
        private CheckBox checkBoxFahrenheit;
        private ScottPlot.WinForms.FormsPlot graphicPlot;
        private Label fonctionLabel;
        private TextBox functionInput;
        private Label label1;
        private TextBox beginDateInput;
        private TextBox endDateInput;
        private Label label2;
        private TextBox timeBeginInput;
        private TextBox timeEndInput;
        private Button importButton;
        private Button exportButton;
        private Label titleHorizon;
        private Label titleVertical;
    }
}
