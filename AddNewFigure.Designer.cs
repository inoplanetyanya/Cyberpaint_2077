namespace Cyberpaint_2077 {
	partial class AddNewFigure {
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
			this.CBFigureType = new System.Windows.Forms.ComboBox();
			this.LFigureType = new System.Windows.Forms.Label();
			this.BOK = new System.Windows.Forms.Button();
			this.BCancel = new System.Windows.Forms.Button();
			this.LColorLine = new System.Windows.Forms.Label();
			this.LColorBG = new System.Windows.Forms.Label();
			this.LColorLineChange = new System.Windows.Forms.Label();
			this.LColorBGChange = new System.Windows.Forms.Label();
			this.LPenSize = new System.Windows.Forms.Label();
			this.CBPenSize = new System.Windows.Forms.ComboBox();
			this.BFont = new System.Windows.Forms.Button();
			this.LFont = new System.Windows.Forms.Label();
			this.BPoints = new System.Windows.Forms.Button();
			this.LPoints = new System.Windows.Forms.Label();
			this.CBFillFlag = new System.Windows.Forms.CheckBox();
			this.GBTextBox = new System.Windows.Forms.GroupBox();
			this.TBText = new System.Windows.Forms.TextBox();
			this.GBTextBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// CBFigureType
			// 
			this.CBFigureType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CBFigureType.FormattingEnabled = true;
			this.CBFigureType.Items.AddRange(new object[] {
            "Прямая",
            "Кривая",
            "Прямоугольник",
            "Эллипс",
            "Текст"});
			this.CBFigureType.Location = new System.Drawing.Point(103, 12);
			this.CBFigureType.Name = "CBFigureType";
			this.CBFigureType.Size = new System.Drawing.Size(121, 21);
			this.CBFigureType.TabIndex = 0;
			this.CBFigureType.SelectedIndexChanged += new System.EventHandler(this.CBFigureType_SelectedIndexChanged);
			// 
			// LFigureType
			// 
			this.LFigureType.AutoSize = true;
			this.LFigureType.Location = new System.Drawing.Point(11, 15);
			this.LFigureType.Name = "LFigureType";
			this.LFigureType.Size = new System.Drawing.Size(70, 13);
			this.LFigureType.TabIndex = 1;
			this.LFigureType.Text = "Тип Фигуры";
			// 
			// BOK
			// 
			this.BOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.BOK.Enabled = false;
			this.BOK.Location = new System.Drawing.Point(497, 360);
			this.BOK.Name = "BOK";
			this.BOK.Size = new System.Drawing.Size(75, 23);
			this.BOK.TabIndex = 2;
			this.BOK.Text = "OK";
			this.BOK.UseVisualStyleBackColor = true;
			this.BOK.Click += new System.EventHandler(this.BOK_Click);
			// 
			// BCancel
			// 
			this.BCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.BCancel.Location = new System.Drawing.Point(416, 360);
			this.BCancel.Name = "BCancel";
			this.BCancel.Size = new System.Drawing.Size(75, 23);
			this.BCancel.TabIndex = 3;
			this.BCancel.Text = "Отмена";
			this.BCancel.UseVisualStyleBackColor = true;
			// 
			// LColorLine
			// 
			this.LColorLine.AutoSize = true;
			this.LColorLine.Location = new System.Drawing.Point(11, 46);
			this.LColorLine.Name = "LColorLine";
			this.LColorLine.Size = new System.Drawing.Size(65, 13);
			this.LColorLine.TabIndex = 4;
			this.LColorLine.Text = "Цвет линий";
			// 
			// LColorBG
			// 
			this.LColorBG.AutoSize = true;
			this.LColorBG.Location = new System.Drawing.Point(11, 75);
			this.LColorBG.Name = "LColorBG";
			this.LColorBG.Size = new System.Drawing.Size(77, 13);
			this.LColorBG.TabIndex = 5;
			this.LColorBG.Text = "Цвет заливки";
			// 
			// LColorLineChange
			// 
			this.LColorLineChange.AutoSize = true;
			this.LColorLineChange.BackColor = System.Drawing.Color.White;
			this.LColorLineChange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.LColorLineChange.Location = new System.Drawing.Point(103, 41);
			this.LColorLineChange.MinimumSize = new System.Drawing.Size(121, 23);
			this.LColorLineChange.Name = "LColorLineChange";
			this.LColorLineChange.Size = new System.Drawing.Size(121, 23);
			this.LColorLineChange.TabIndex = 6;
			this.LColorLineChange.Text = "                ";
			this.LColorLineChange.Click += new System.EventHandler(this.LColorLineChange_Click);
			// 
			// LColorBGChange
			// 
			this.LColorBGChange.AutoSize = true;
			this.LColorBGChange.BackColor = System.Drawing.Color.White;
			this.LColorBGChange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.LColorBGChange.Location = new System.Drawing.Point(103, 70);
			this.LColorBGChange.MinimumSize = new System.Drawing.Size(121, 23);
			this.LColorBGChange.Name = "LColorBGChange";
			this.LColorBGChange.Size = new System.Drawing.Size(121, 23);
			this.LColorBGChange.TabIndex = 7;
			this.LColorBGChange.Text = "                ";
			this.LColorBGChange.Click += new System.EventHandler(this.LColorBGChange_Click);
			// 
			// LPenSize
			// 
			this.LPenSize.AutoSize = true;
			this.LPenSize.Location = new System.Drawing.Point(11, 104);
			this.LPenSize.Name = "LPenSize";
			this.LPenSize.Size = new System.Drawing.Size(86, 13);
			this.LPenSize.TabIndex = 8;
			this.LPenSize.Text = "Толщина линий";
			// 
			// CBPenSize
			// 
			this.CBPenSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CBPenSize.FormattingEnabled = true;
			this.CBPenSize.Items.AddRange(new object[] {
            "1",
            "2",
            "5",
            "8",
            "10",
            "12",
            "15"});
			this.CBPenSize.Location = new System.Drawing.Point(103, 101);
			this.CBPenSize.Name = "CBPenSize";
			this.CBPenSize.Size = new System.Drawing.Size(121, 21);
			this.CBPenSize.TabIndex = 9;
			this.CBPenSize.SelectedIndexChanged += new System.EventHandler(this.CBPenSize_SelectedIndexChanged);
			// 
			// BFont
			// 
			this.BFont.Location = new System.Drawing.Point(230, 12);
			this.BFont.Name = "BFont";
			this.BFont.Size = new System.Drawing.Size(75, 23);
			this.BFont.TabIndex = 10;
			this.BFont.Text = "Шрифт";
			this.BFont.UseVisualStyleBackColor = true;
			this.BFont.Click += new System.EventHandler(this.BFont_Click);
			// 
			// LFont
			// 
			this.LFont.AutoSize = true;
			this.LFont.Location = new System.Drawing.Point(311, 17);
			this.LFont.Name = "LFont";
			this.LFont.Size = new System.Drawing.Size(13, 13);
			this.LFont.TabIndex = 11;
			this.LFont.Text = "--";
			// 
			// BPoints
			// 
			this.BPoints.Location = new System.Drawing.Point(230, 41);
			this.BPoints.Name = "BPoints";
			this.BPoints.Size = new System.Drawing.Size(75, 23);
			this.BPoints.TabIndex = 12;
			this.BPoints.Text = "Точки";
			this.BPoints.UseVisualStyleBackColor = true;
			this.BPoints.Click += new System.EventHandler(this.BPoints_Click);
			// 
			// LPoints
			// 
			this.LPoints.AutoSize = true;
			this.LPoints.Location = new System.Drawing.Point(311, 46);
			this.LPoints.Name = "LPoints";
			this.LPoints.Size = new System.Drawing.Size(139, 13);
			this.LPoints.TabIndex = 13;
			this.LPoints.Text = "Установите точки фигуры";
			// 
			// CBFillFlag
			// 
			this.CBFillFlag.AutoSize = true;
			this.CBFillFlag.Checked = true;
			this.CBFillFlag.CheckState = System.Windows.Forms.CheckState.Checked;
			this.CBFillFlag.Location = new System.Drawing.Point(230, 74);
			this.CBFillFlag.Name = "CBFillFlag";
			this.CBFillFlag.Size = new System.Drawing.Size(69, 17);
			this.CBFillFlag.TabIndex = 14;
			this.CBFillFlag.Text = "Заливка";
			this.CBFillFlag.UseVisualStyleBackColor = true;
			this.CBFillFlag.Click += new System.EventHandler(this.CBFillFlag_Click);
			// 
			// GBTextBox
			// 
			this.GBTextBox.Controls.Add(this.TBText);
			this.GBTextBox.Location = new System.Drawing.Point(14, 128);
			this.GBTextBox.Name = "GBTextBox";
			this.GBTextBox.Size = new System.Drawing.Size(396, 255);
			this.GBTextBox.TabIndex = 15;
			this.GBTextBox.TabStop = false;
			this.GBTextBox.Text = "Текст";
			// 
			// TBText
			// 
			this.TBText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TBText.Location = new System.Drawing.Point(3, 16);
			this.TBText.Multiline = true;
			this.TBText.Name = "TBText";
			this.TBText.Size = new System.Drawing.Size(390, 236);
			this.TBText.TabIndex = 0;
			this.TBText.Leave += new System.EventHandler(this.TBText_Leave);
			// 
			// AddNewFigure
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 395);
			this.Controls.Add(this.GBTextBox);
			this.Controls.Add(this.CBFillFlag);
			this.Controls.Add(this.LPoints);
			this.Controls.Add(this.BPoints);
			this.Controls.Add(this.LFont);
			this.Controls.Add(this.BFont);
			this.Controls.Add(this.CBPenSize);
			this.Controls.Add(this.LPenSize);
			this.Controls.Add(this.LColorBGChange);
			this.Controls.Add(this.LColorLineChange);
			this.Controls.Add(this.LColorBG);
			this.Controls.Add(this.LColorLine);
			this.Controls.Add(this.BCancel);
			this.Controls.Add(this.BOK);
			this.Controls.Add(this.LFigureType);
			this.Controls.Add(this.CBFigureType);
			this.Name = "AddNewFigure";
			this.Text = "Добавить фигуру";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddNewFigure_FormClosing);
			this.GBTextBox.ResumeLayout(false);
			this.GBTextBox.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox CBFigureType;
		private System.Windows.Forms.Label LFigureType;
		private System.Windows.Forms.Button BOK;
		private System.Windows.Forms.Button BCancel;
		private System.Windows.Forms.Label LColorLine;
		private System.Windows.Forms.Label LColorBG;
		private System.Windows.Forms.Label LColorLineChange;
		private System.Windows.Forms.Label LColorBGChange;
		private System.Windows.Forms.Label LPenSize;
		private System.Windows.Forms.ComboBox CBPenSize;
		private System.Windows.Forms.Button BFont;
		private System.Windows.Forms.Label LFont;
		private System.Windows.Forms.Button BPoints;
		private System.Windows.Forms.Label LPoints;
		private System.Windows.Forms.CheckBox CBFillFlag;
		private System.Windows.Forms.GroupBox GBTextBox;
		private System.Windows.Forms.TextBox TBText;
	}
}