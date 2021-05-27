namespace PhotomathDesktop
{
    partial class MathForma
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblispis = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.tbunos = new System.Windows.Forms.TextBox();
            this.btnracunaj = new System.Windows.Forms.Button();
            this.FLP = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkRed;
            this.panel1.Controls.Add(this.lblispis);
            this.panel1.Location = new System.Drawing.Point(12, 525);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(616, 100);
            this.panel1.TabIndex = 0;
            // 
            // lblispis
            // 
            this.lblispis.AutoSize = true;
            this.lblispis.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblispis.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblispis.Location = new System.Drawing.Point(29, 35);
            this.lblispis.Name = "lblispis";
            this.lblispis.Size = new System.Drawing.Size(0, 31);
            this.lblispis.TabIndex = 3;
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(12, 9);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(171, 31);
            this.lbl1.TabIndex = 1;
            this.lbl1.Text = "Upisite izraz:";
            // 
            // tbunos
            // 
            this.tbunos.Location = new System.Drawing.Point(18, 52);
            this.tbunos.Name = "tbunos";
            this.tbunos.Size = new System.Drawing.Size(303, 20);
            this.tbunos.TabIndex = 2;
            // 
            // btnracunaj
            // 
            this.btnracunaj.Location = new System.Drawing.Point(18, 78);
            this.btnracunaj.Name = "btnracunaj";
            this.btnracunaj.Size = new System.Drawing.Size(303, 39);
            this.btnracunaj.TabIndex = 4;
            this.btnracunaj.Text = "Izracunaj";
            this.btnracunaj.UseVisualStyleBackColor = true;
            this.btnracunaj.Click += new System.EventHandler(this.btnracunaj_Click);
            // 
            // FLP
            // 
            this.FLP.AutoScroll = true;
            this.FLP.AutoScrollMinSize = new System.Drawing.Size(20, 20);
            this.FLP.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.FLP.Location = new System.Drawing.Point(339, 52);
            this.FLP.Name = "FLP";
            this.FLP.Size = new System.Drawing.Size(289, 449);
            this.FLP.TabIndex = 5;
            this.FLP.WrapContents = false;
            // 
            // MathForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 637);
            this.Controls.Add(this.FLP);
            this.Controls.Add(this.btnracunaj);
            this.Controls.Add(this.tbunos);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.panel1);
            this.Name = "MathForma";
            this.Text = "PhotomathD";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.TextBox tbunos;
        private System.Windows.Forms.Label lblispis;
        private System.Windows.Forms.Button btnracunaj;
        private System.Windows.Forms.FlowLayoutPanel FLP;
    }
}

