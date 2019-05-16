namespace Gardinia
{
    partial class SideButtons
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DesignsTxt = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DesignsTxt
            // 
            this.DesignsTxt.AutoSize = true;
            this.DesignsTxt.Location = new System.Drawing.Point(3, 9);
            this.DesignsTxt.Name = "DesignsTxt";
            this.DesignsTxt.Size = new System.Drawing.Size(60, 13);
            this.DesignsTxt.TabIndex = 0;
            this.DesignsTxt.Text = "Designs list";
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.DesignsTxt);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(68, 32);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DesignsTxt;
    }
}
