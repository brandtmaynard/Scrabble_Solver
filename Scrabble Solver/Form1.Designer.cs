
namespace Scrabble_Solver
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
            this.textBox = new System.Windows.Forms.TextBox();
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox.Location = new System.Drawing.Point(12, 12);
            this.textBox.Name = "textBox1";
            this.textBox.Size = new System.Drawing.Size(244, 20);
            this.textBox.TabIndex = 0;
            this.textBox.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            this.textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // listView1
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(12, 38);
            this.listView.Name = "listView1";
            this.listView.Size = new System.Drawing.Size(244, 368);
            this.listView.TabIndex = 2;
            this.listView.UseCompatibleStateImageBehavior = false;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Score";
            this.columnHeader1.Width = -2;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Word";
            this.columnHeader2.Width = 200;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 418);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.textBox);
            this.Name = "Form1";
            this.Text = "Solver";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}

