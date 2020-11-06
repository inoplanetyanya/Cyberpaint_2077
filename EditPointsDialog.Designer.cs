namespace Cyberpaint_2077 {
	partial class EditPointsDialog {
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
			this.TBPoints = new System.Windows.Forms.TextBox();
			this.BOK = new System.Windows.Forms.Button();
			this.BCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// TBPoints
			// 
			this.TBPoints.Location = new System.Drawing.Point(12, 12);
			this.TBPoints.Multiline = true;
			this.TBPoints.Name = "TBPoints";
			this.TBPoints.Size = new System.Drawing.Size(776, 397);
			this.TBPoints.TabIndex = 0;
			this.TBPoints.WordWrap = false;
			this.TBPoints.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBPoints_KeyPress);
			// 
			// BOK
			// 
			this.BOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.BOK.Location = new System.Drawing.Point(713, 415);
			this.BOK.Name = "BOK";
			this.BOK.Size = new System.Drawing.Size(75, 23);
			this.BOK.TabIndex = 1;
			this.BOK.Text = "OK";
			this.BOK.UseVisualStyleBackColor = true;
			this.BOK.Click += new System.EventHandler(this.BOK_Click);
			// 
			// BCancel
			// 
			this.BCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.BCancel.Location = new System.Drawing.Point(632, 415);
			this.BCancel.Name = "BCancel";
			this.BCancel.Size = new System.Drawing.Size(75, 23);
			this.BCancel.TabIndex = 2;
			this.BCancel.Text = "Отмена";
			this.BCancel.UseVisualStyleBackColor = true;
			// 
			// EditPointsDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.BCancel);
			this.Controls.Add(this.BOK);
			this.Controls.Add(this.TBPoints);
			this.Name = "EditPointsDialog";
			this.Text = "Точки";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditPointsDialog_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox TBPoints;
		private System.Windows.Forms.Button BOK;
		private System.Windows.Forms.Button BCancel;
	}
}