namespace Cyberpaint_2077 {
	partial class EditFigurePositionDialog {
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
			this.LX = new System.Windows.Forms.Label();
			this.TBX = new System.Windows.Forms.TextBox();
			this.LY = new System.Windows.Forms.Label();
			this.TBY = new System.Windows.Forms.TextBox();
			this.BOK = new System.Windows.Forms.Button();
			this.BCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// LX
			// 
			this.LX.AutoSize = true;
			this.LX.Location = new System.Drawing.Point(12, 15);
			this.LX.Name = "LX";
			this.LX.Size = new System.Drawing.Size(14, 13);
			this.LX.TabIndex = 0;
			this.LX.Text = "X";
			// 
			// TBX
			// 
			this.TBX.Location = new System.Drawing.Point(32, 12);
			this.TBX.Name = "TBX";
			this.TBX.Size = new System.Drawing.Size(148, 20);
			this.TBX.TabIndex = 1;
			this.TBX.TextChanged += new System.EventHandler(this.TBX_TextChanged);
			this.TBX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBX_KeyPress);
			// 
			// LY
			// 
			this.LY.AutoSize = true;
			this.LY.Location = new System.Drawing.Point(12, 41);
			this.LY.Name = "LY";
			this.LY.Size = new System.Drawing.Size(14, 13);
			this.LY.TabIndex = 2;
			this.LY.Text = "Y";
			// 
			// TBY
			// 
			this.TBY.Location = new System.Drawing.Point(32, 38);
			this.TBY.Name = "TBY";
			this.TBY.Size = new System.Drawing.Size(148, 20);
			this.TBY.TabIndex = 3;
			this.TBY.TextChanged += new System.EventHandler(this.TBY_TextChanged);
			this.TBY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBY_KeyPress);
			// 
			// BOK
			// 
			this.BOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.BOK.Location = new System.Drawing.Point(105, 64);
			this.BOK.Name = "BOK";
			this.BOK.Size = new System.Drawing.Size(75, 23);
			this.BOK.TabIndex = 4;
			this.BOK.Text = "OK";
			this.BOK.UseVisualStyleBackColor = true;
			this.BOK.Click += new System.EventHandler(this.BOK_Click);
			// 
			// BCancel
			// 
			this.BCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.BCancel.Location = new System.Drawing.Point(12, 64);
			this.BCancel.Name = "BCancel";
			this.BCancel.Size = new System.Drawing.Size(75, 23);
			this.BCancel.TabIndex = 5;
			this.BCancel.Text = "Отмена";
			this.BCancel.UseVisualStyleBackColor = true;
			// 
			// EditFigurePositionDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(192, 97);
			this.Controls.Add(this.BCancel);
			this.Controls.Add(this.BOK);
			this.Controls.Add(this.TBY);
			this.Controls.Add(this.LY);
			this.Controls.Add(this.TBX);
			this.Controls.Add(this.LX);
			this.Name = "EditFigurePositionDialog";
			this.Text = "Положение";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditFigurePositionDialog_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label LX;
		private System.Windows.Forms.TextBox TBX;
		private System.Windows.Forms.Label LY;
		private System.Windows.Forms.TextBox TBY;
		private System.Windows.Forms.Button BOK;
		private System.Windows.Forms.Button BCancel;
	}
}