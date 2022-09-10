namespace DonatMain
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.InputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OutputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InputToolStripMenuItem,
            this.MathToolStripMenuItem,
            this.OutputToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // InputToolStripMenuItem
            // 
            this.InputToolStripMenuItem.BackColor = System.Drawing.Color.Firebrick;
            this.InputToolStripMenuItem.Name = "InputToolStripMenuItem";
            this.InputToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.InputToolStripMenuItem.Text = "Модуль ввода";
            this.InputToolStripMenuItem.Click += new System.EventHandler(this.InputToolStripMenuItem_Click);
            // 
            // MathToolStripMenuItem
            // 
            this.MathToolStripMenuItem.BackColor = System.Drawing.Color.Firebrick;
            this.MathToolStripMenuItem.Name = "MathToolStripMenuItem";
            this.MathToolStripMenuItem.Size = new System.Drawing.Size(157, 20);
            this.MathToolStripMenuItem.Text = "Математический модуль";
            this.MathToolStripMenuItem.Click += new System.EventHandler(this.MathToolStripMenuItem_Click);
            // 
            // OutputToolStripMenuItem
            // 
            this.OutputToolStripMenuItem.BackColor = System.Drawing.Color.Firebrick;
            this.OutputToolStripMenuItem.Name = "OutputToolStripMenuItem";
            this.OutputToolStripMenuItem.Size = new System.Drawing.Size(105, 20);
            this.OutputToolStripMenuItem.Text = "Модуль вывода";
            this.OutputToolStripMenuItem.Click += new System.EventHandler(this.OutputToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem InputToolStripMenuItem;
        private ToolStripMenuItem MathToolStripMenuItem;
        private ToolStripMenuItem OutputToolStripMenuItem;
        private ToolStripMenuItem справкаToolStripMenuItem;
        private OpenFileDialog openFileDialog1;
    }
}