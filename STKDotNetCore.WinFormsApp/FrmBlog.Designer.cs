

namespace STKDotNetCore.WinFormsApp
{
    partial class FrmBlog
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
            btnSave = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtTitle = new TextBox();
            txtAuthor = new TextBox();
            txtContent = new TextBox();
            btnCancel = new Button();
            btnUpdate = new Button();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(67, 160, 71);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(378, 366);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(123, 50);
            btnSave.TabIndex = 0;
            btnSave.TabStop = false;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(232, 37);
            label1.Name = "label1";
            label1.Size = new Size(58, 28);
            label1.TabIndex = 1;
            label1.Text = "Title :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(232, 123);
            label2.Name = "label2";
            label2.Size = new Size(82, 28);
            label2.TabIndex = 2;
            label2.Text = "Author :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(232, 206);
            label3.Name = "label3";
            label3.Size = new Size(91, 28);
            label3.TabIndex = 3;
            label3.Text = "Content :";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(232, 68);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(377, 34);
            txtTitle.TabIndex = 4;
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(232, 160);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(377, 34);
            txtAuthor.TabIndex = 5;
            // 
            // txtContent
            // 
            txtContent.Location = new Point(232, 237);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.Size = new Size(377, 112);
            txtContent.TabIndex = 6;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(84, 110, 122);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(232, 366);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(123, 50);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "&Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(128, 128, 255);
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(378, 366);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(123, 50);
            btnUpdate.TabIndex = 8;
            btnUpdate.TabStop = false;
            btnUpdate.Text = "&Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Visible = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // FrmBlog
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(880, 504);
            Controls.Add(btnUpdate);
            Controls.Add(btnCancel);
            Controls.Add(txtContent);
            Controls.Add(txtAuthor);
            Controls.Add(txtTitle);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnSave);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.Black;
            Name = "FrmBlog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Blog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSave;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtTitle;
        private TextBox txtAuthor;
        private TextBox txtContent;
        private Button btnCancel;
        private Button btnUpdate;
    }
}
