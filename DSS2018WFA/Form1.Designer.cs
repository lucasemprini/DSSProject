namespace DSS2018WFA
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
            this.btnStart = new System.Windows.Forms.Button();
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.db_path = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.search_btn = new System.Windows.Forms.Button();
            this.btn_id_param = new System.Windows.Forms.Button();
            this.box_id = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(-3, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(282, 109);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "The button of true";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click_1);
            // 
            // txtConsole
            // 
            this.txtConsole.Location = new System.Drawing.Point(-3, 118);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.Size = new System.Drawing.Size(643, 148);
            this.txtConsole.TabIndex = 1;
            // 
            // db_path
            // 
            this.db_path.Location = new System.Drawing.Point(285, 26);
            this.db_path.Name = "db_path";
            this.db_path.Size = new System.Drawing.Size(335, 20);
            this.db_path.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(382, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Insert Database configuration";
            // 
            // search_btn
            // 
            this.search_btn.Location = new System.Drawing.Point(336, 46);
            this.search_btn.Name = "search_btn";
            this.search_btn.Size = new System.Drawing.Size(254, 23);
            this.search_btn.TabIndex = 4;
            this.search_btn.Text = "Search!";
            this.search_btn.UseVisualStyleBackColor = true;
            this.search_btn.Click += new System.EventHandler(this.search_btn_Click);
            // 
            // btn_id_param
            // 
            this.btn_id_param.Location = new System.Drawing.Point(509, 88);
            this.btn_id_param.Name = "btn_id_param";
            this.btn_id_param.Size = new System.Drawing.Size(75, 23);
            this.btn_id_param.TabIndex = 5;
            this.btn_id_param.Text = "Search byID";
            this.btn_id_param.UseVisualStyleBackColor = true;
            this.btn_id_param.Click += new System.EventHandler(this.btn_id_param_Click);
            // 
            // box_id
            // 
            this.box_id.Location = new System.Drawing.Point(403, 91);
            this.box_id.Name = "box_id";
            this.box_id.Size = new System.Drawing.Size(100, 20);
            this.box_id.TabIndex = 6;
            this.box_id.Text = "put id here";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(333, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "search by id";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 261);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.box_id);
            this.Controls.Add(this.btn_id_param);
            this.Controls.Add(this.search_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.db_path);
            this.Controls.Add(this.txtConsole);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.TextBox db_path;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button search_btn;
        private System.Windows.Forms.Button btn_id_param;
        private System.Windows.Forms.TextBox box_id;
        private System.Windows.Forms.Label label2;
    }
}