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
	public partial class AddNewFigure : Form {

		Canvas activeCanvas;
		SerializebleData activeData;
		public AddNewFigure(Canvas canvas, SerializebleData data) {
			InitializeComponent();
			activeCanvas = canvas;
			activeData = data;
			RefreshElements();
		}

		void RefreshElements() {
			CBFigureType.SelectedItem = figureType;
			LColorLineChange.BackColor = colorLine;
			LColorBGChange.BackColor = colorBackground;
			CBFillFlag.Checked = fillFlag;
			CBPenSize.SelectedItem = brushSize.ToString();
			LFont.Text = font.Size.ToString() + " " + font.Name + " " + font.Style;

			if (points.Count < 2) {
				LPoints.Text = "Установите точки фигуры";
				BOK.Enabled = false;
			}
			else {
				LPoints.Text = "Точки фигуры установлены";
				BOK.Enabled = true;
			}
		}

		string figureType = "Прямая";

		int brushSize = 1;
		Color colorLine = Color.Black;
		Color colorBackground = Color.White;
		bool fillFlag = true;
		Font font = new Font(new FontFamily("Times New Roman"), 8, FontStyle.Regular, GraphicsUnit.Point);
		string text = string.Empty;
		//Point startPosition = new Point(-1, -1);
		//Point endPosition = new Point(-1, -1);
		List<Point> points = new List<Point>();

		private void CBFigureType_SelectedIndexChanged(object sender, EventArgs e) {
			figureType = CBFigureType.Text;
			if (figureType != "Кривая" && points.Count != 2 || points.Count() < 2) {
				points.Clear();
				LPoints.Text = "Установите точки фигуры";
				BOK.Enabled = false;
			}
			BFont.Enabled = figureType == "Текст";
			LFont.Visible = figureType == "Текст";
			GBTextBox.Visible = figureType == "Текст";
		}

		private void LColorLineChange_Click(object sender, EventArgs e) {
			ColorDialog dialog = new ColorDialog();
			if (dialog.ShowDialog() == DialogResult.OK) colorLine = dialog.Color;
			TBText.ForeColor = colorLine;
			RefreshElements();
		}

		private void LColorBGChange_Click(object sender, EventArgs e) {
			ColorDialog dialog = new ColorDialog();
			if (dialog.ShowDialog() == DialogResult.OK) colorBackground = dialog.Color;
			TBText.BackColor = colorBackground;
			RefreshElements();
		}

		private void CBFillFlag_Click(object sender, EventArgs e) {
			fillFlag = CBFillFlag.Checked;
			RefreshElements();
		}

		private void BPoints_Click(object sender, EventArgs e) {
			EditPointsDialog dialog = new EditPointsDialog();
			if (dialog.ShowDialog() == DialogResult.OK) points = dialog.GetPoints();
			RefreshElements();
		}

		private void BFont_Click(object sender, EventArgs e) {
			FontDialog dialog = new FontDialog();
			if (dialog.ShowDialog() == DialogResult.OK) font = dialog.Font;
			TBText.Font = font;
			RefreshElements();
		}

		private void BOK_Click(object sender, EventArgs e) {
			text = TBText.Text;
			AbstractFigure figure = null;
			Point[] sortedPoints;
			switch (CBFigureType.SelectedItem.ToString()) {
				case "Прямая":
					sortedPoints = SomeMethodsForCanvas.SortPoints(points.First(), points.Last());
					figure = new MyLine(sortedPoints[0], sortedPoints[1], brushSize, colorLine, colorBackground, fillFlag);
					break;
				case "Кривая":
					figure = new MyCurve(points, brushSize, colorLine, colorBackground, fillFlag);
					break;
				case "Прямоугольник":
					sortedPoints = SomeMethodsForCanvas.SortPoints(points.First(), points.Last());
					figure = new MyRectangle(sortedPoints[0], sortedPoints[1], brushSize, colorLine, colorBackground, fillFlag);
					break;
				case "Эллипс":
					sortedPoints = SomeMethodsForCanvas.SortPoints(points.First(), points.Last());
					figure = new MyEllipse(sortedPoints[0], sortedPoints[1], brushSize, colorLine, colorBackground, fillFlag);
					break;
				case "Текст":
					sortedPoints = SomeMethodsForCanvas.SortPoints(points.First(), points.Last());
					figure = new MyText(sortedPoints[0], sortedPoints[1], brushSize, colorLine, colorBackground, fillFlag, font, text);
					break;
			}
			if (SomeMethodsForCanvas.BordersCheck(figure, activeCanvas)) {
				activeData.AddFigure(figure);
				cancel = false;
			}
			else {
				cancel = true;
			}
		}

		bool cancel;

		private void AddNewFigure_FormClosing(object sender, FormClosingEventArgs e) {
			e.Cancel = cancel;
			cancel = false;
		}

		private void CBPenSize_SelectedIndexChanged(object sender, EventArgs e) {
			brushSize = Convert.ToInt32(CBPenSize.SelectedItem);
			RefreshElements();
		}

		private void TBText_Leave(object sender, EventArgs e) {
			
		}
	}
}
