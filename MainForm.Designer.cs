
namespace VRCVideoSync
{
    partial class MainForm
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
            this.txt_url = new System.Windows.Forms.TextBox();
            this.lst_urls = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.lst_urls)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_url
            // 
            this.txt_url.Dock = System.Windows.Forms.DockStyle.Top;
            this.txt_url.Location = new System.Drawing.Point(0, 0);
            this.txt_url.Name = "txt_url";
            this.txt_url.Size = new System.Drawing.Size(764, 20);
            this.txt_url.TabIndex = 0;
            this.txt_url.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_url_KeyUp);
            // 
            // lst_urls
            // 
            this.lst_urls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lst_urls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lst_urls.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.lst_urls.Location = new System.Drawing.Point(0, 20);
            this.lst_urls.MultiSelect = false;
            this.lst_urls.Name = "lst_urls";
            this.lst_urls.ReadOnly = true;
            this.lst_urls.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.lst_urls.Size = new System.Drawing.Size(764, 448);
            this.lst_urls.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 468);
            this.Controls.Add(this.lst_urls);
            this.Controls.Add(this.txt_url);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.lst_urls)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_url;
        private System.Windows.Forms.DataGridView lst_urls;
    }
}

