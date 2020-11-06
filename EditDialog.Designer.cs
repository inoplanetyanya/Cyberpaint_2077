namespace Cyberpaint_2077 {
	partial class EditDialog {
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
			this.LVTable = new System.Windows.Forms.ListView();
			this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.FigureType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.FigurePosition = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.PenSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.PenColor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.BGColor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.FillFlag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.FontSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.FigureFont = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.GBEdit = new System.Windows.Forms.GroupBox();
			this.LPosition = new System.Windows.Forms.Label();
			this.LSize = new System.Windows.Forms.Label();
			this.BPoints = new System.Windows.Forms.Button();
			this.BSize = new System.Windows.Forms.Button();
			this.BPosition = new System.Windows.Forms.Button();
			this.CBFill = new System.Windows.Forms.CheckBox();
			this.BCancel = new System.Windows.Forms.Button();
			this.GBText = new System.Windows.Forms.GroupBox();
			this.TBEditText = new System.Windows.Forms.TextBox();
			this.BSaveText = new System.Windows.Forms.Button();
			this.BTextEdit = new System.Windows.Forms.Button();
			this.LFont = new System.Windows.Forms.Label();
			this.LColorBG = new System.Windows.Forms.Label();
			this.LPenColor = new System.Windows.Forms.Label();
			this.LPenSize = new System.Windows.Forms.Label();
			this.BFont = new System.Windows.Forms.Button();
			this.BColorBG = new System.Windows.Forms.Button();
			this.BColorLine = new System.Windows.Forms.Button();
			this.BPenSize = new System.Windows.Forms.Button();
			this.BUP = new System.Windows.Forms.Button();
			this.BDown = new System.Windows.Forms.Button();
			this.BAdd = new System.Windows.Forms.Button();
			this.BDelete = new System.Windows.Forms.Button();
			this.BOK = new System.Windows.Forms.Button();
			this.BSave = new System.Windows.Forms.Button();
			this.BToBegin = new System.Windows.Forms.Button();
			this.ToEnd = new System.Windows.Forms.Button();
			this.GBEdit.SuspendLayout();
			this.GBText.SuspendLayout();
			this.SuspendLayout();
			// 
			// LVTable
			// 
			this.LVTable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.FigureType,
            this.FigurePosition,
            this.PenSize,
            this.PenColor,
            this.BGColor,
            this.FillFlag,
            this.FontSize,
            this.FigureFont});
			this.LVTable.FullRowSelect = true;
			this.LVTable.HideSelection = false;
			this.LVTable.LabelWrap = false;
			this.LVTable.Location = new System.Drawing.Point(12, 12);
			this.LVTable.MaximumSize = new System.Drawing.Size(830, 500);
			this.LVTable.MinimumSize = new System.Drawing.Size(830, 500);
			this.LVTable.MultiSelect = false;
			this.LVTable.Name = "LVTable";
			this.LVTable.ShowGroups = false;
			this.LVTable.ShowItemToolTips = true;
			this.LVTable.Size = new System.Drawing.Size(830, 500);
			this.LVTable.TabIndex = 0;
			this.LVTable.UseCompatibleStateImageBehavior = false;
			this.LVTable.View = System.Windows.Forms.View.Details;
			this.LVTable.SelectedIndexChanged += new System.EventHandler(this.LVTable_SelectedIndexChanged);
			// 
			// ID
			// 
			this.ID.Text = "ID";
			// 
			// FigureType
			// 
			this.FigureType.Text = "Тип";
			this.FigureType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.FigureType.Width = 100;
			// 
			// FigurePosition
			// 
			this.FigurePosition.Text = "Положение";
			this.FigurePosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.FigurePosition.Width = 80;
			// 
			// PenSize
			// 
			this.PenSize.Text = "Размер пера";
			this.PenSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.PenSize.Width = 80;
			// 
			// PenColor
			// 
			this.PenColor.Text = "Цвет пера";
			this.PenColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.PenColor.Width = 100;
			// 
			// BGColor
			// 
			this.BGColor.Text = "Цвет заливки";
			this.BGColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.BGColor.Width = 100;
			// 
			// FillFlag
			// 
			this.FillFlag.Text = "Заливка";
			this.FillFlag.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.FillFlag.Width = 55;
			// 
			// FontSize
			// 
			this.FontSize.Text = "Размер шрифта";
			this.FontSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.FontSize.Width = 95;
			// 
			// FigureFont
			// 
			this.FigureFont.Text = "Шрифт";
			this.FigureFont.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.FigureFont.Width = 139;
			// 
			// GBEdit
			// 
			this.GBEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.GBEdit.Controls.Add(this.LPosition);
			this.GBEdit.Controls.Add(this.LSize);
			this.GBEdit.Controls.Add(this.BPoints);
			this.GBEdit.Controls.Add(this.BSize);
			this.GBEdit.Controls.Add(this.BPosition);
			this.GBEdit.Controls.Add(this.CBFill);
			this.GBEdit.Controls.Add(this.BCancel);
			this.GBEdit.Controls.Add(this.GBText);
			this.GBEdit.Controls.Add(this.BSaveText);
			this.GBEdit.Controls.Add(this.BTextEdit);
			this.GBEdit.Controls.Add(this.LFont);
			this.GBEdit.Controls.Add(this.LColorBG);
			this.GBEdit.Controls.Add(this.LPenColor);
			this.GBEdit.Controls.Add(this.LPenSize);
			this.GBEdit.Controls.Add(this.BFont);
			this.GBEdit.Controls.Add(this.BColorBG);
			this.GBEdit.Controls.Add(this.BColorLine);
			this.GBEdit.Controls.Add(this.BPenSize);
			this.GBEdit.Location = new System.Drawing.Point(848, 12);
			this.GBEdit.Name = "GBEdit";
			this.GBEdit.Size = new System.Drawing.Size(404, 500);
			this.GBEdit.TabIndex = 1;
			this.GBEdit.TabStop = false;
			this.GBEdit.Text = "Изменить";
			// 
			// LPosition
			// 
			this.LPosition.AutoSize = true;
			this.LPosition.Location = new System.Drawing.Point(328, 24);
			this.LPosition.Name = "LPosition";
			this.LPosition.Size = new System.Drawing.Size(13, 13);
			this.LPosition.TabIndex = 18;
			this.LPosition.Text = "--";
			// 
			// LSize
			// 
			this.LSize.AutoSize = true;
			this.LSize.Location = new System.Drawing.Point(328, 53);
			this.LSize.Name = "LSize";
			this.LSize.Size = new System.Drawing.Size(13, 13);
			this.LSize.TabIndex = 17;
			this.LSize.Text = "--";
			// 
			// BPoints
			// 
			this.BPoints.Enabled = false;
			this.BPoints.Location = new System.Drawing.Point(247, 77);
			this.BPoints.Name = "BPoints";
			this.BPoints.Size = new System.Drawing.Size(75, 23);
			this.BPoints.TabIndex = 16;
			this.BPoints.Text = "Точки";
			this.BPoints.UseVisualStyleBackColor = true;
			this.BPoints.Click += new System.EventHandler(this.BPoints_Click);
			// 
			// BSize
			// 
			this.BSize.Location = new System.Drawing.Point(247, 48);
			this.BSize.Name = "BSize";
			this.BSize.Size = new System.Drawing.Size(75, 23);
			this.BSize.TabIndex = 15;
			this.BSize.Text = "Размер";
			this.BSize.UseVisualStyleBackColor = true;
			this.BSize.Click += new System.EventHandler(this.BSize_Click);
			// 
			// BPosition
			// 
			this.BPosition.Location = new System.Drawing.Point(247, 19);
			this.BPosition.Name = "BPosition";
			this.BPosition.Size = new System.Drawing.Size(75, 23);
			this.BPosition.TabIndex = 14;
			this.BPosition.Text = "Положение";
			this.BPosition.UseVisualStyleBackColor = true;
			this.BPosition.Click += new System.EventHandler(this.BPosition_Click);
			// 
			// CBFill
			// 
			this.CBFill.AutoSize = true;
			this.CBFill.Location = new System.Drawing.Point(172, 81);
			this.CBFill.Name = "CBFill";
			this.CBFill.Size = new System.Drawing.Size(69, 17);
			this.CBFill.TabIndex = 12;
			this.CBFill.Text = "Заливка";
			this.CBFill.UseVisualStyleBackColor = true;
			this.CBFill.Click += new System.EventHandler(this.CBFill_Click);
			// 
			// BCancel
			// 
			this.BCancel.Enabled = false;
			this.BCancel.Location = new System.Drawing.Point(190, 135);
			this.BCancel.Name = "BCancel";
			this.BCancel.Size = new System.Drawing.Size(75, 23);
			this.BCancel.TabIndex = 11;
			this.BCancel.Text = "Отмена";
			this.BCancel.UseVisualStyleBackColor = true;
			this.BCancel.Visible = false;
			this.BCancel.Click += new System.EventHandler(this.BCancel_Click);
			// 
			// GBText
			// 
			this.GBText.Controls.Add(this.TBEditText);
			this.GBText.Location = new System.Drawing.Point(6, 164);
			this.GBText.Name = "GBText";
			this.GBText.Size = new System.Drawing.Size(392, 330);
			this.GBText.TabIndex = 10;
			this.GBText.TabStop = false;
			this.GBText.Text = "Текст";
			// 
			// TBEditText
			// 
			this.TBEditText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TBEditText.Enabled = false;
			this.TBEditText.Location = new System.Drawing.Point(3, 16);
			this.TBEditText.MinimumSize = new System.Drawing.Size(322, 40);
			this.TBEditText.Multiline = true;
			this.TBEditText.Name = "TBEditText";
			this.TBEditText.Size = new System.Drawing.Size(386, 311);
			this.TBEditText.TabIndex = 0;
			// 
			// BSaveText
			// 
			this.BSaveText.Enabled = false;
			this.BSaveText.Location = new System.Drawing.Point(109, 135);
			this.BSaveText.Name = "BSaveText";
			this.BSaveText.Size = new System.Drawing.Size(75, 23);
			this.BSaveText.TabIndex = 9;
			this.BSaveText.Text = "Сохранить";
			this.BSaveText.UseVisualStyleBackColor = true;
			this.BSaveText.Visible = false;
			this.BSaveText.Click += new System.EventHandler(this.BSaveText_Click);
			// 
			// BTextEdit
			// 
			this.BTextEdit.Enabled = false;
			this.BTextEdit.Location = new System.Drawing.Point(6, 135);
			this.BTextEdit.Name = "BTextEdit";
			this.BTextEdit.Size = new System.Drawing.Size(97, 23);
			this.BTextEdit.TabIndex = 8;
			this.BTextEdit.Text = "Текст";
			this.BTextEdit.UseVisualStyleBackColor = true;
			this.BTextEdit.Click += new System.EventHandler(this.BTextEdit_Click);
			// 
			// LFont
			// 
			this.LFont.AutoSize = true;
			this.LFont.Location = new System.Drawing.Point(109, 111);
			this.LFont.Name = "LFont";
			this.LFont.Size = new System.Drawing.Size(13, 13);
			this.LFont.TabIndex = 7;
			this.LFont.Text = "--";
			// 
			// LColorBG
			// 
			this.LColorBG.AutoSize = true;
			this.LColorBG.BackColor = System.Drawing.Color.White;
			this.LColorBG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.LColorBG.Location = new System.Drawing.Point(109, 82);
			this.LColorBG.Name = "LColorBG";
			this.LColorBG.Size = new System.Drawing.Size(57, 15);
			this.LColorBG.TabIndex = 6;
			this.LColorBG.Text = "                ";
			// 
			// LPenColor
			// 
			this.LPenColor.AutoSize = true;
			this.LPenColor.BackColor = System.Drawing.Color.White;
			this.LPenColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.LPenColor.Location = new System.Drawing.Point(109, 53);
			this.LPenColor.Name = "LPenColor";
			this.LPenColor.Size = new System.Drawing.Size(57, 15);
			this.LPenColor.TabIndex = 5;
			this.LPenColor.Text = "                ";
			// 
			// LPenSize
			// 
			this.LPenSize.AutoSize = true;
			this.LPenSize.Location = new System.Drawing.Point(109, 24);
			this.LPenSize.Name = "LPenSize";
			this.LPenSize.Size = new System.Drawing.Size(13, 13);
			this.LPenSize.TabIndex = 4;
			this.LPenSize.Text = "--";
			// 
			// BFont
			// 
			this.BFont.Location = new System.Drawing.Point(6, 106);
			this.BFont.Name = "BFont";
			this.BFont.Size = new System.Drawing.Size(97, 23);
			this.BFont.TabIndex = 3;
			this.BFont.Text = "Шрифт";
			this.BFont.UseVisualStyleBackColor = true;
			this.BFont.Click += new System.EventHandler(this.BFont_Click);
			// 
			// BColorBG
			// 
			this.BColorBG.Enabled = false;
			this.BColorBG.Location = new System.Drawing.Point(6, 77);
			this.BColorBG.Name = "BColorBG";
			this.BColorBG.Size = new System.Drawing.Size(97, 23);
			this.BColorBG.TabIndex = 2;
			this.BColorBG.Text = "Цвет заливки";
			this.BColorBG.UseVisualStyleBackColor = true;
			this.BColorBG.Click += new System.EventHandler(this.BColorBG_Click);
			// 
			// BColorLine
			// 
			this.BColorLine.Location = new System.Drawing.Point(6, 48);
			this.BColorLine.Name = "BColorLine";
			this.BColorLine.Size = new System.Drawing.Size(97, 23);
			this.BColorLine.TabIndex = 1;
			this.BColorLine.Text = "Цвет пера";
			this.BColorLine.UseVisualStyleBackColor = true;
			this.BColorLine.Click += new System.EventHandler(this.BColorLine_Click);
			// 
			// BPenSize
			// 
			this.BPenSize.Location = new System.Drawing.Point(6, 19);
			this.BPenSize.Name = "BPenSize";
			this.BPenSize.Size = new System.Drawing.Size(97, 23);
			this.BPenSize.TabIndex = 0;
			this.BPenSize.Text = "Размер пера";
			this.BPenSize.UseVisualStyleBackColor = true;
			this.BPenSize.Click += new System.EventHandler(this.BPenSize_Click);
			// 
			// BUP
			// 
			this.BUP.Enabled = false;
			this.BUP.Location = new System.Drawing.Point(12, 518);
			this.BUP.Name = "BUP";
			this.BUP.Size = new System.Drawing.Size(75, 23);
			this.BUP.TabIndex = 2;
			this.BUP.Text = "Вверх";
			this.BUP.UseVisualStyleBackColor = true;
			this.BUP.Click += new System.EventHandler(this.BUP_Click);
			// 
			// BDown
			// 
			this.BDown.Enabled = false;
			this.BDown.Location = new System.Drawing.Point(12, 547);
			this.BDown.Name = "BDown";
			this.BDown.Size = new System.Drawing.Size(75, 23);
			this.BDown.TabIndex = 3;
			this.BDown.Text = "Вниз";
			this.BDown.UseVisualStyleBackColor = true;
			this.BDown.Click += new System.EventHandler(this.BDown_Click);
			// 
			// BAdd
			// 
			this.BAdd.Location = new System.Drawing.Point(255, 518);
			this.BAdd.Name = "BAdd";
			this.BAdd.Size = new System.Drawing.Size(75, 23);
			this.BAdd.TabIndex = 4;
			this.BAdd.Text = "Добавить";
			this.BAdd.UseVisualStyleBackColor = true;
			this.BAdd.Click += new System.EventHandler(this.BAdd_Click);
			// 
			// BDelete
			// 
			this.BDelete.Enabled = false;
			this.BDelete.Location = new System.Drawing.Point(336, 518);
			this.BDelete.Name = "BDelete";
			this.BDelete.Size = new System.Drawing.Size(75, 23);
			this.BDelete.TabIndex = 5;
			this.BDelete.Text = "Удалить";
			this.BDelete.UseVisualStyleBackColor = true;
			this.BDelete.Click += new System.EventHandler(this.BDelete_Click);
			// 
			// BOK
			// 
			this.BOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.BOK.Location = new System.Drawing.Point(1177, 547);
			this.BOK.Name = "BOK";
			this.BOK.Size = new System.Drawing.Size(75, 23);
			this.BOK.TabIndex = 6;
			this.BOK.Text = "OK";
			this.BOK.UseVisualStyleBackColor = true;
			this.BOK.Click += new System.EventHandler(this.BOK_Click);
			// 
			// BSave
			// 
			this.BSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BSave.Location = new System.Drawing.Point(1095, 547);
			this.BSave.Name = "BSave";
			this.BSave.Size = new System.Drawing.Size(75, 23);
			this.BSave.TabIndex = 7;
			this.BSave.Text = "Сохранить";
			this.BSave.UseVisualStyleBackColor = true;
			this.BSave.Click += new System.EventHandler(this.BSave_Click);
			// 
			// BToBegin
			// 
			this.BToBegin.Enabled = false;
			this.BToBegin.Location = new System.Drawing.Point(93, 518);
			this.BToBegin.Name = "BToBegin";
			this.BToBegin.Size = new System.Drawing.Size(75, 23);
			this.BToBegin.TabIndex = 8;
			this.BToBegin.Text = "В начало";
			this.BToBegin.UseVisualStyleBackColor = true;
			this.BToBegin.Click += new System.EventHandler(this.BToBegin_Click);
			// 
			// ToEnd
			// 
			this.ToEnd.Enabled = false;
			this.ToEnd.Location = new System.Drawing.Point(93, 547);
			this.ToEnd.Name = "ToEnd";
			this.ToEnd.Size = new System.Drawing.Size(75, 23);
			this.ToEnd.TabIndex = 9;
			this.ToEnd.Text = "В конец";
			this.ToEnd.UseVisualStyleBackColor = true;
			this.ToEnd.Click += new System.EventHandler(this.ToEnd_Click);
			// 
			// EditDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1264, 582);
			this.Controls.Add(this.ToEnd);
			this.Controls.Add(this.BToBegin);
			this.Controls.Add(this.BSave);
			this.Controls.Add(this.BOK);
			this.Controls.Add(this.BDelete);
			this.Controls.Add(this.BAdd);
			this.Controls.Add(this.BDown);
			this.Controls.Add(this.BUP);
			this.Controls.Add(this.GBEdit);
			this.Controls.Add(this.LVTable);
			this.MaximumSize = new System.Drawing.Size(1280, 621);
			this.MinimumSize = new System.Drawing.Size(1280, 621);
			this.Name = "EditDialog";
			this.Text = "Редактировать";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditDialog_FormClosing);
			this.GBEdit.ResumeLayout(false);
			this.GBEdit.PerformLayout();
			this.GBText.ResumeLayout(false);
			this.GBText.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView LVTable;
		private System.Windows.Forms.ColumnHeader ID;
		private System.Windows.Forms.ColumnHeader FigureType;
		private System.Windows.Forms.ColumnHeader FigurePosition;
		private System.Windows.Forms.GroupBox GBEdit;
		private System.Windows.Forms.Button BColorBG;
		private System.Windows.Forms.Button BColorLine;
		private System.Windows.Forms.Button BPenSize;
		private System.Windows.Forms.Button BFont;
		private System.Windows.Forms.ColumnHeader PenSize;
		private System.Windows.Forms.ColumnHeader PenColor;
		private System.Windows.Forms.ColumnHeader BGColor;
		private System.Windows.Forms.ColumnHeader FillFlag;
		private System.Windows.Forms.ColumnHeader FontSize;
		private System.Windows.Forms.ColumnHeader FigureFont;
		private System.Windows.Forms.GroupBox GBText;
		private System.Windows.Forms.TextBox TBEditText;
		private System.Windows.Forms.Button BSaveText;
		private System.Windows.Forms.Button BTextEdit;
		private System.Windows.Forms.Label LFont;
		private System.Windows.Forms.Label LColorBG;
		private System.Windows.Forms.Label LPenColor;
		private System.Windows.Forms.Label LPenSize;
		private System.Windows.Forms.Button BUP;
		private System.Windows.Forms.Button BDown;
		private System.Windows.Forms.Button BAdd;
		private System.Windows.Forms.Button BDelete;
		private System.Windows.Forms.Button BOK;
		private System.Windows.Forms.Button BSave;
		private System.Windows.Forms.Button BCancel;
		private System.Windows.Forms.CheckBox CBFill;
		private System.Windows.Forms.Label LPosition;
		private System.Windows.Forms.Label LSize;
		private System.Windows.Forms.Button BPoints;
		private System.Windows.Forms.Button BSize;
		private System.Windows.Forms.Button BPosition;
		private System.Windows.Forms.Button BToBegin;
		private System.Windows.Forms.Button ToEnd;
	}
}