namespace Cyberpaint_2077 {
	partial class Canvas {
		/// <summary> 
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором компонентов

		/// <summary> 
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent() {
			this.textBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// textBox
			// 
			this.textBox.Location = new System.Drawing.Point(183, 228);
			this.textBox.Multiline = true;
			this.textBox.Name = "textBox";
			this.textBox.Size = new System.Drawing.Size(100, 20);
			this.textBox.TabIndex = 0;
			this.textBox.Visible = false;
			this.textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
			this.textBox.Leave += new System.EventHandler(this.textBox_Leave);
			// 
			// Canvas
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.textBox);
			this.DoubleBuffered = true;
			this.Name = "Canvas";
			this.Size = new System.Drawing.Size(480, 480);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Canvas_KeyDown);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseDown);
			this.MouseLeave += new System.EventHandler(this.Canvas_MouseLeave);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseMove);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseUp);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBox;
	}
}
