using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cyberpaint_2077 {
	public partial class EditFigureSizeDialog : Form {

		Canvas activeCanvas;
		AbstractFigure activeFigure;

		public EditFigureSizeDialog(Canvas canvas, AbstractFigure figure) {
			InitializeComponent();
			activeCanvas = canvas;
			activeFigure = figure;
			TBWidth.Text = activeFigure.GetFigureBox().Width.ToString();
			TBHeight.Text = activeFigure.GetFigureBox().Height.ToString();
		}

		private void TBWidth_TextChanged(object sender, EventArgs e) {
			if (TBWidth.Text != "" && TBHeight.Text != "") {
				BOK.Enabled = true;
			}
			else BOK.Enabled = false;
		}

		private void TBHeight_TextChanged(object sender, EventArgs e) {
			if (TBWidth.Text != "" && TBHeight.Text != "") {
				BOK.Enabled = true;
			}
			else BOK.Enabled = false;
		}

		private void TBWidth_KeyPress(object sender, KeyPressEventArgs e) {
			if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8) {
				e.Handled = true;
			}
		}

		private void TBHeight_KeyPress(object sender, KeyPressEventArgs e) {
			if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8) {
				e.Handled = true;
			}
		}

		private void BOK_Click(object sender, EventArgs e) {
			if (BorderCheck()) {
				cancel = false;
				activeFigure.ResizeFigure(p2.X - p1.X, p2.Y - p1.Y, 7);
			}
			else {
				cancel = true;
				TBWidth.Text = activeFigure.GetFigureBox().X.ToString();
				TBHeight.Text = activeFigure.GetFigureBox().Y.ToString();
				MessageBox.Show("Не удалось изменить размер фигуры", "Ошибка", MessageBoxButtons.OK);
			}
		}

		Point p1;
		Point p2;

		bool BorderCheck() {
			p1 = activeFigure.GetFigureBox().Location;
			p1.Offset(activeFigure.GetFigureBox().Width, activeFigure.GetFigureBox().Height);
			p2 = new Point(Convert.ToInt32(TBWidth.Text), Convert.ToInt32(TBHeight.Text));
			return SomeMethodsForCanvas.BordersCheckForResizingFigure(activeFigure, activeCanvas, p2.X - p1.X, p2.Y - p1.Y, 7);
		}

		bool cancel;

		private void EditSizeDialog_FormClosing(object sender, FormClosingEventArgs e) {
			e.Cancel = cancel;
			cancel = false;
		}
	}
}
