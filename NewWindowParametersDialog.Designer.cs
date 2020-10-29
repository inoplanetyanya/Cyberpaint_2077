namespace Cyberpaint_2077 {
	partial class NewWindowParametersDialog {
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonOK = new System.Windows.Forms.Button();
			this.textBoxHeight = new System.Windows.Forms.TextBox();
			this.textBoxWidth = new System.Windows.Forms.TextBox();
			this.labelHeightText = new System.Windows.Forms.Label();
			this.labelWidthText = new System.Windows.Forms.Label();
			this.checkBoxUserSize = new System.Windows.Forms.CheckBox();
			this.RB800x600 = new System.Windows.Forms.RadioButton();
			this.RB640x480 = new System.Windows.Forms.RadioButton();
			this.RB320x240 = new System.Windows.Forms.RadioButton();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.buttonCancel);
			this.groupBox1.Controls.Add(this.buttonOK);
			this.groupBox1.Controls.Add(this.textBoxHeight);
			this.groupBox1.Controls.Add(this.textBoxWidth);
			this.groupBox1.Controls.Add(this.labelHeightText);
			this.groupBox1.Controls.Add(this.labelWidthText);
			this.groupBox1.Controls.Add(this.checkBoxUserSize);
			this.groupBox1.Controls.Add(this.RB800x600);
			this.groupBox1.Controls.Add(this.RB640x480);
			this.groupBox1.Controls.Add(this.RB320x240);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(239, 116);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Выбор размера";
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(152, 90);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 9;
			this.buttonCancel.Text = "Отмена";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// buttonOK
			// 
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Enabled = false;
			this.buttonOK.Location = new System.Drawing.Point(6, 90);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 8;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// textBoxHeight
			// 
			this.textBoxHeight.Enabled = false;
			this.textBoxHeight.Location = new System.Drawing.Point(152, 64);
			this.textBoxHeight.Name = "textBoxHeight";
			this.textBoxHeight.Size = new System.Drawing.Size(75, 20);
			this.textBoxHeight.TabIndex = 7;
			this.textBoxHeight.TextChanged += new System.EventHandler(this.textBoxHeight_TextChanged);
			this.textBoxHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxHeight_KeyPress);
			// 
			// textBoxWidth
			// 
			this.textBoxWidth.Enabled = false;
			this.textBoxWidth.Location = new System.Drawing.Point(152, 41);
			this.textBoxWidth.Name = "textBoxWidth";
			this.textBoxWidth.Size = new System.Drawing.Size(75, 20);
			this.textBoxWidth.TabIndex = 6;
			this.textBoxWidth.TextChanged += new System.EventHandler(this.textBoxWidth_TextChanged);
			this.textBoxWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxWidth_KeyPress);
			// 
			// labelHeightText
			// 
			this.labelHeightText.AutoSize = true;
			this.labelHeightText.Location = new System.Drawing.Point(100, 67);
			this.labelHeightText.Name = "labelHeightText";
			this.labelHeightText.Size = new System.Drawing.Size(45, 13);
			this.labelHeightText.TabIndex = 5;
			this.labelHeightText.Text = "Высота";
			// 
			// labelWidthText
			// 
			this.labelWidthText.AutoSize = true;
			this.labelWidthText.Location = new System.Drawing.Point(100, 44);
			this.labelWidthText.Name = "labelWidthText";
			this.labelWidthText.Size = new System.Drawing.Size(46, 13);
			this.labelWidthText.TabIndex = 4;
			this.labelWidthText.Text = "Ширина";
			// 
			// checkBoxUserSize
			// 
			this.checkBoxUserSize.AutoSize = true;
			this.checkBoxUserSize.Location = new System.Drawing.Point(152, 19);
			this.checkBoxUserSize.Name = "checkBoxUserSize";
			this.checkBoxUserSize.Size = new System.Drawing.Size(68, 17);
			this.checkBoxUserSize.TabIndex = 3;
			this.checkBoxUserSize.Text = "Вручную";
			this.checkBoxUserSize.UseVisualStyleBackColor = true;
			this.checkBoxUserSize.CheckedChanged += new System.EventHandler(this.checkBoxUserSize_CheckedChanged);
			// 
			// RB800x600
			// 
			this.RB800x600.AutoSize = true;
			this.RB800x600.Location = new System.Drawing.Point(6, 65);
			this.RB800x600.Name = "RB800x600";
			this.RB800x600.Size = new System.Drawing.Size(66, 17);
			this.RB800x600.TabIndex = 2;
			this.RB800x600.Text = "800x600";
			this.RB800x600.UseVisualStyleBackColor = true;
			this.RB800x600.CheckedChanged += new System.EventHandler(this.RB800x600_CheckedChanged);
			// 
			// RB640x480
			// 
			this.RB640x480.AutoSize = true;
			this.RB640x480.Location = new System.Drawing.Point(6, 42);
			this.RB640x480.Name = "RB640x480";
			this.RB640x480.Size = new System.Drawing.Size(66, 17);
			this.RB640x480.TabIndex = 1;
			this.RB640x480.Text = "640x480";
			this.RB640x480.UseVisualStyleBackColor = true;
			this.RB640x480.CheckedChanged += new System.EventHandler(this.RB640x480_CheckedChanged);
			// 
			// RB320x240
			// 
			this.RB320x240.AutoSize = true;
			this.RB320x240.Location = new System.Drawing.Point(6, 19);
			this.RB320x240.Name = "RB320x240";
			this.RB320x240.Size = new System.Drawing.Size(66, 17);
			this.RB320x240.TabIndex = 0;
			this.RB320x240.Text = "320x240";
			this.RB320x240.UseVisualStyleBackColor = true;
			this.RB320x240.CheckedChanged += new System.EventHandler(this.RB320x240_CheckedChanged);
			// 
			// NewWindowParametersDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(239, 116);
			this.Controls.Add(this.groupBox1);
			this.Name = "NewWindowParametersDialog";
			this.Text = "New Window";
			this.Shown += new System.EventHandler(this.NewWindowParameters_Shown);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.TextBox textBoxHeight;
		private System.Windows.Forms.TextBox textBoxWidth;
		private System.Windows.Forms.Label labelHeightText;
		private System.Windows.Forms.Label labelWidthText;
		private System.Windows.Forms.CheckBox checkBoxUserSize;
		private System.Windows.Forms.RadioButton RB800x600;
		private System.Windows.Forms.RadioButton RB640x480;
		private System.Windows.Forms.RadioButton RB320x240;
	}
}