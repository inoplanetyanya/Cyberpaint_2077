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
	public partial class EditFigurePositionDialog : Form {

		Canvas activeCanvas;
		AbstractFigure activeFigure;

		public EditFigurePositionDialog(Canvas canvas, AbstractFigure figure) {
			InitializeComponent();
			activeCanvas = canvas;
			activeFigure = figure;
			TBX.Text = activeFigure.GetFigureBox().X.ToString();
			TBY.Text = activeFigure.GetFigureBox().Y.ToString();
		}

		private void TBX_TextChanged(object sender, EventArgs e) {
			if (TBX.Text != "" && TBY.Text != "") {
				BOK.Enabled = true;
			}
			else BOK.Enabled = false;
		}

		private void TBY_TextChanged(object sender, EventArgs e) {
			if (TBX.Text != "" && TBY.Text != "") {
				BOK.Enabled = true;
			}
			else BOK.Enabled = false;
		}

		private void TBX_KeyPress(object sender, KeyPressEventArgs e) {
			if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8) {
				e.Handled = true;
			}
		}

		private void TBY_KeyPress(object sender, KeyPressEventArgs e) {
			if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8) {
				e.Handled = true;
			}
		}

		private void BOK_Click(object sender, EventArgs e) {
			if (BorderCheck()) {
				cancel = false;
				activeFigure.MoveFigure(p2.X - p1.X, p2.Y - p1.Y);
			}
			else {
				cancel = true;
				TBX.Text = activeFigure.GetFigureBox().X.ToString();
				TBY.Text = activeFigure.GetFigureBox().Y.ToString();
				MessageBox.Show("Не удалось переместить фигуру", "Ошибка", MessageBoxButtons.OK);
			}
		}

		Point p1;
		Point p2;

		bool BorderCheck() {
			p1 = activeFigure.GetFigureBox().Location;
			p2 = new Point(Convert.ToInt32(TBX.Text), Convert.ToInt32(TBY.Text));
			return SomeMethodsForCanvas.BordersCheckForMovingFigures(activeFigure, activeCanvas, p2.X - p1.X, p2.Y - p1.Y);
		}

		bool cancel;

		private void EditFigurePositionDialog_FormClosing(object sender, FormClosingEventArgs e) {
			e.Cancel = cancel;
			cancel = false;
		}
	}
}
