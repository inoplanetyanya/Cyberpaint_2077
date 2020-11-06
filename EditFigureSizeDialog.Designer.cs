namespace Cyberpaint_2077 {
	partial class EditFigureSizeDialog {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.LWidth = new System.Windows.Forms.Label();
			this.LHeight = new System.Windows.Forms.Label();
			this.TBWidth = new System.Windows.Forms.TextBox();
			this.TBHeight = new System.Windows.Forms.TextBox();
			this.BCancel = new System.Windows.Forms.Button();
			this.BOK = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// LWidth
			// 
			this.LWidth.AutoSize = true;
			this.LWidth.Location = new System.Drawing.Point(12, 15);
			this.LWidth.Name = "LWidth";
			this.LWidth.Size = new System.Drawing.Size(46, 13);
			this.LWidth.TabIndex = 0;
			this.LWidth.Text = "Ширина";
			// 
			// LHeight
			// 
			this.LHeight.AutoSize = true;
			this.LHeight.Location = new System.Drawing.Point(13, 41);
			this.LHeight.Name = "LHeight";
			this.LHeight.Size = new System.Drawing.Size(45, 13);
			this.LHeight.TabIndex = 1;
			this.LHeight.Text = "Высота";
			// 
			// TBWidth
			// 
			this.TBWidth.Location = new System.Drawing.Point(64, 12);
			this.TBWidth.Name = "TBWidth";
			this.TBWidth.Size = new System.Drawing.Size(104, 20);
			this.TBWidth.TabIndex = 2;
			this.TBWidth.TextChanged += new System.EventHandler(this.TBWidth_TextChanged);
			this.TBWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBWidth_KeyPress);
			// 
			// TBHeight
			// 
			this.TBHeight.Location = new System.Drawing.Point(64, 38);
			this.TBHeight.Name = "TBHeight";
			this.TBHeight.Size = new System.Drawing.Size(104, 20);
			this.TBHeight.TabIndex = 3;
			this.TBHeight.TextChanged += new System.EventHandler(this.TBHeight_TextChanged);
			this.TBHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBHeight_KeyPress);
			// 
			// BCancel
			// 
			this.BCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.BCancel.Location = new System.Drawing.Point(12, 64);
			this.BCancel.Name = "BCancel";
			this.BCancel.Size = new System.Drawing.Size(75, 23);
			this.BCancel.TabIndex = 4;
			this.BCancel.Text = "Отмена";
			this.BCancel.UseVisualStyleBackColor = true;
			// 
			// BOK
			// 
			this.BOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.BOK.Location = new System.Drawing.Point(93, 64);
			this.BOK.Name = "BOK";
			this.BOK.Size = new System.Drawing.Size(75, 23);
			this.BOK.TabIndex = 5;
			this.BOK.Text = "OK";
			this.BOK.UseVisualStyleBackColor = true;
			this.BOK.Click += new System.EventHandler(this.BOK_Click);
			// 
			// EditFigureSizeDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(178, 97);
			this.Controls.Add(this.BOK);
			this.Controls.Add(this.BCancel);
			this.Controls.Add(this.TBHeight);
			this.Controls.Add(this.TBWidth);
			this.Controls.Add(this.LHeight);
			this.Controls.Add(this.LWidth);
			this.Name = "EditFigureSizeDialog";
			this.Text = "Размер";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditSizeDialog_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label LWidth;
		private System.Windows.Forms.Label LHeight;
		private System.Windows.Forms.TextBox TBWidth;
		private System.Windows.Forms.TextBox TBHeight;
		private System.Windows.Forms.Button BCancel;
		private System.Windows.Forms.Button BOK;
	}
}