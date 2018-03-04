namespace Saper
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
            this.components = new System.ComponentModel.Container();
            this.textBoxRozmiarX = new System.Windows.Forms.TextBox();
            this.textBoxRozimarY = new System.Windows.Forms.TextBox();
            this.textBoxLiczbaBomb = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxRozmiarX
            // 
            this.textBoxRozmiarX.Location = new System.Drawing.Point(12, 4);
            this.textBoxRozmiarX.Name = "textBoxRozmiarX";
            this.textBoxRozmiarX.Size = new System.Drawing.Size(80, 20);
            this.textBoxRozmiarX.TabIndex = 0;
            this.textBoxRozmiarX.Text = "10";
            // 
            // textBoxRozimarY
            // 
            this.textBoxRozimarY.Location = new System.Drawing.Point(98, 4);
            this.textBoxRozimarY.Name = "textBoxRozimarY";
            this.textBoxRozimarY.Size = new System.Drawing.Size(80, 20);
            this.textBoxRozimarY.TabIndex = 1;
            this.textBoxRozimarY.Text = "10";
            // 
            // textBoxLiczbaBomb
            // 
            this.textBoxLiczbaBomb.Location = new System.Drawing.Point(184, 4);
            this.textBoxLiczbaBomb.Name = "textBoxLiczbaBomb";
            this.textBoxLiczbaBomb.Size = new System.Drawing.Size(80, 20);
            this.textBoxLiczbaBomb.TabIndex = 2;
            this.textBoxLiczbaBomb.Text = "20";
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.LightGray;
            this.buttonStart.Location = new System.Drawing.Point(270, 3);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(80, 20);
            this.buttonStart.TabIndex = 3;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(665, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(267, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "label3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 71);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.textBoxLiczbaBomb);
            this.Controls.Add(this.textBoxRozimarY);
            this.Controls.Add(this.textBoxRozmiarX);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxRozmiarX;
        private System.Windows.Forms.TextBox textBoxRozimarY;
        private System.Windows.Forms.TextBox textBoxLiczbaBomb;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

