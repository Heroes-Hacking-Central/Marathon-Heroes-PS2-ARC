namespace Marathon.Toolkit.Forms
{
    partial class FileConverter
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
            this.MenuStripDark_Main = new Marathon.Toolkit.Components.MenuStripDark();
            this.MenuStripDark_Main_Tools = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStripDark_Main_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.ButtonFlat_Convert = new Marathon.Toolkit.Components.ButtonFlat();
            this.PictureBox_FileDropIndicator = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.KryptonRibbon_MarathonForm)).BeginInit();
            this.MenuStripDark_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_FileDropIndicator)).BeginInit();
            this.SuspendLayout();
            // 
            // KryptonRibbon_MarathonForm
            // 
            this.KryptonRibbon_MarathonForm.Size = new System.Drawing.Size(320, 142);
            // 
            // MenuStripDark_Main
            // 
            this.MenuStripDark_Main.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MenuStripDark_Main.AutoSize = false;
            this.MenuStripDark_Main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.MenuStripDark_Main.Dock = System.Windows.Forms.DockStyle.None;
            this.MenuStripDark_Main.ForeColor = System.Drawing.SystemColors.Control;
            this.MenuStripDark_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStripDark_Main_Tools,
            this.MenuStripDark_Main_Help});
            this.MenuStripDark_Main.Location = new System.Drawing.Point(-4, 0);
            this.MenuStripDark_Main.Name = "MenuStripDark_Main";
            this.MenuStripDark_Main.Size = new System.Drawing.Size(325, 24);
            this.MenuStripDark_Main.TabIndex = 0;
            this.MenuStripDark_Main.Text = "menuStripDark1";
            // 
            // MenuStripDark_Main_Tools
            // 
            this.MenuStripDark_Main_Tools.Name = "MenuStripDark_Main_Tools";
            this.MenuStripDark_Main_Tools.Size = new System.Drawing.Size(46, 20);
            this.MenuStripDark_Main_Tools.Text = "Tools";
            // 
            // MenuStripDark_Main_Help
            // 
            this.MenuStripDark_Main_Help.Name = "MenuStripDark_Main_Help";
            this.MenuStripDark_Main_Help.Size = new System.Drawing.Size(44, 20);
            this.MenuStripDark_Main_Help.Text = "Help";
            // 
            // ButtonFlat_Convert
            // 
            this.ButtonFlat_Convert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonFlat_Convert.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ButtonFlat_Convert.FlatAppearance.BorderSize = 0;
            this.ButtonFlat_Convert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonFlat_Convert.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ButtonFlat_Convert.Location = new System.Drawing.Point(12, 436);
            this.ButtonFlat_Convert.Name = "ButtonFlat_Convert";
            this.ButtonFlat_Convert.Size = new System.Drawing.Size(296, 23);
            this.ButtonFlat_Convert.TabIndex = 1;
            this.ButtonFlat_Convert.Text = "Convert";
            this.ButtonFlat_Convert.UseVisualStyleBackColor = false;
            this.ButtonFlat_Convert.Visible = false;
            // 
            // PictureBox_FileDropIndicator
            // 
            this.PictureBox_FileDropIndicator.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PictureBox_FileDropIndicator.BackgroundImage = global::Marathon.Toolkit.Properties.Resources.FileConverter_FileDrop;
            this.PictureBox_FileDropIndicator.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PictureBox_FileDropIndicator.Location = new System.Drawing.Point(64, 134);
            this.PictureBox_FileDropIndicator.Name = "PictureBox_FileDropIndicator";
            this.PictureBox_FileDropIndicator.Size = new System.Drawing.Size(192, 192);
            this.PictureBox_FileDropIndicator.TabIndex = 2;
            this.PictureBox_FileDropIndicator.TabStop = false;
            this.PictureBox_FileDropIndicator.DragDrop += new System.Windows.Forms.DragEventHandler(this.FileConverter_DragDrop);
            this.PictureBox_FileDropIndicator.DragEnter += new System.Windows.Forms.DragEventHandler(this.FileConverter_DragEnter);
            // 
            // FileConverter
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(320, 471);
            this.Controls.Add(this.PictureBox_FileDropIndicator);
            this.Controls.Add(this.ButtonFlat_Convert);
            this.Controls.Add(this.MenuStripDark_Main);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.MinimumSize = new System.Drawing.Size(252, 382);
            this.Name = "FileConverter";
            this.Text = "File Converter";
            this.UseRibbon = false;
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FileConverter_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FileConverter_DragEnter);
            this.Controls.SetChildIndex(this.MenuStripDark_Main, 0);
            this.Controls.SetChildIndex(this.ButtonFlat_Convert, 0);
            this.Controls.SetChildIndex(this.PictureBox_FileDropIndicator, 0);
            this.Controls.SetChildIndex(this.KryptonRibbon_MarathonForm, 0);
            ((System.ComponentModel.ISupportInitialize)(this.KryptonRibbon_MarathonForm)).EndInit();
            this.MenuStripDark_Main.ResumeLayout(false);
            this.MenuStripDark_Main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_FileDropIndicator)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Components.MenuStripDark MenuStripDark_Main;
        private System.Windows.Forms.ToolStripMenuItem MenuStripDark_Main_Tools;
        private System.Windows.Forms.ToolStripMenuItem MenuStripDark_Main_Help;
        private Components.ButtonFlat ButtonFlat_Convert;
        private System.Windows.Forms.PictureBox PictureBox_FileDropIndicator;
    }
}
