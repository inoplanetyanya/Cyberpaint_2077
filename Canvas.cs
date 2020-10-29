using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cyberpaint_2077 {
	public partial class Canvas : UserControl {
		public Canvas() {
			InitializeComponent();
			data = new SerializebleData();
			Anchor = AnchorStyles.None;
		}

		public Canvas(SerializebleData data) {
			InitializeComponent();
			this.data = data;
			Size = data.GetCanvasSize();
			Anchor = AnchorStyles.None;
		}

		SerializebleData data;

		public SerializebleData GetSerializebleData() {
			return data;
		}

		public void SetSerializebleData(SerializebleData data) {
			this.data = data;
		}

		public void CreateSerializebleData() {
			data = new SerializebleData();
		}

		public void SetCanvasSize(Size size) {
			data.SetCanvasSize(size);
		}

		public Size GetCanvasSize() {
			return data.GetCanvasSize();
		}

		public void SetName(string name) {
			data.SetName(name);
		}

		public string GetName() {
			return data.GetName();
		}

		public void SetFormChangedState(bool isChanged) {
			data.SetFormChangedState(isChanged);
		}

		public bool GetFormChangedState() {
			return data.GetFormChangedState();
		}

		//

		public List<AbstractFigure> GetFigures() {
			return data.GetFigures();
		}

		public AbstractFigure GetFigure(int index) {
			return data.GetFigure(index);
		}

		public void SetFigures(List<AbstractFigure> figures) {
			data.SetFigures(figures);
		}

		public void AddFigure(AbstractFigure figure) {
			data.AddFigure(figure);
		}

		public void RemoveFigure(int index) {
			data.RemoveFigure(index);
		}

		public void RemoveFigure(AbstractFigure figure) {
			data.RemoveFigure(figure);
		}

		//

		public List<AbstractFigure> GetPickedFigures() {
			return data.GetPickedFigures();
		}

		public void SetPickedFigures(List<AbstractFigure> figures) {
			data.SetPickedFigures(figures);
		}

		public void AddPickedFigure(AbstractFigure figure) {
			data.AddPickedFigure(figure);
		}

		public void AddPickedFigures(List<AbstractFigure> figures) {
			data.AddPickedFigures(figures);
		}

		public void DeletePickedFigures() {
			data.DeletePickedFigures();
			Refresh();
		}

		public void RestoreFigures() {
			data.RestoreFigures();
		}

		//

		public void SetChildFormSize(Size size) {
			data.SetChildFormSize(size);
		}

		public Size GetChildFormSize() {
			return data.GetChildFormSize();
		}

		//
		
		public void SetCopyingToMetafileStatus(bool isCopying) {
			copyingToMetafile = isCopying;
		}

		//

		public void SetGrid(List<AbstractFigure> grid) {
			this.grid = grid;
		}

		public void SetGridNodes(List<Point> points) {
			gridNodes = points;
		}

		public List<Point> GetGridNodes() {
			return gridNodes;
		}

		//

		Point startPosition, endPosition;
		Point[] sortedPoints;
		List<Point> points;
		bool mousePressed = false, canMoveFigures = false;
		AbstractFigure figure;

		int brushSize;
		Color colorLine, colorBackGround;
		bool fillFlag, selectionFlag, figureInCanvas;
		string text;
		Font font;

		AbstractFigure figureOnCursor = null;
		bool mousePressedOnFigure = false;

		bool copyingToMetafile = false;

		List<AbstractFigure> grid = null;
		List<Point> gridNodes = null;

		private void Canvas_MouseDown(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				brushSize = DrawParameters.GetBrushSize();
				colorLine = DrawParameters.GetColorLine(); 
				colorBackGround = DrawParameters.GetColorBackground();
				fillFlag = DrawParameters.GetFillFlag();
				selectionFlag = DrawParameters.GetObjectSelectionFlag();
				font = DrawParameters.GetFont();
				text = string.Empty;

				textBox_Leave(sender, e);

				startPosition = e.Location;
				endPosition = e.Location;
				mousePressed = true;

				points = new List<Point>();
				points.Add(startPosition);

				Refresh();
			}
		}

		private void Canvas_MouseMove(object sender, MouseEventArgs e) {
			SomeMethodsForMainForm.RefreshStatusBarCursorPosition(e.X.ToString() + " ; " + e.Y.ToString());

			if (mousePressed && selectionFlag && !canMoveFigures && !mousePressedOnFigure) {
				endPosition = e.Location;
				sortedPoints = SomeMethodsForCanvas.SortPoints(startPosition, endPosition);
				figure = new MyRectangle(sortedPoints[0], sortedPoints[1], 1, Color.Black, Color.White, false);
				Refresh();
			}

			foreach (AbstractFigure f in GetPickedFigures()) {
				if (SomeMethodsForCanvas.CursorInFigure(f, e.Location)) {
					canMoveFigures = true;
					figureOnCursor = f;
				}
			}

			if (mousePressed && canMoveFigures) {
				mousePressedOnFigure = true;
			}

			if (figureOnCursor != null) Cursor = Cursors.SizeAll;
			else {
				Cursor = Cursors.Default;
				canMoveFigures = false;
			}

			figureOnCursor = null;

			if (mousePressedOnFigure) {
				endPosition = e.Location;

				bool allFiguresWillBeInCanvas = false;

				if (GetPickedFigures().Where(x => SomeMethodsForCanvas.BordersCheckForMovingFigures(x, this, endPosition.X - startPosition.X, endPosition.Y - startPosition.Y)).Count() == GetPickedFigures().Count())
					allFiguresWillBeInCanvas = true;

				if (allFiguresWillBeInCanvas) {
					foreach (AbstractFigure f in GetPickedFigures()) {
						f.MoveFigure(endPosition.X - startPosition.X, endPosition.Y - startPosition.Y);
					}
				}

				startPosition = e.Location;
				Refresh();
			}

			if (mousePressed && !selectionFlag && !canMoveFigures) {
				if (DrawParameters.GetFigureType() == "Curve") {
					endPosition = e.Location;
					points.Add(endPosition);
					figure = new MyCurve(points, brushSize, colorLine, colorBackGround, fillFlag);
				}
				else {
					endPosition = e.Location;
					if (endPosition != startPosition) {
						switch (DrawParameters.GetFigureType()) {
							default: break;
							case "Line":
								figure = new MyLine(startPosition, endPosition, brushSize, colorLine, colorBackGround, fillFlag);
								break;
							case "Rectangle":
								sortedPoints = SomeMethodsForCanvas.SortPoints(startPosition, endPosition);
								figure = new MyRectangle(sortedPoints[0], sortedPoints[1], brushSize, colorLine, colorBackGround, fillFlag);
								break;
							case "Ellipse":
								sortedPoints = SomeMethodsForCanvas.SortPoints(startPosition, endPosition);
								figure = new MyEllipse(sortedPoints[0], sortedPoints[1], brushSize, colorLine, colorBackGround, fillFlag);
								break;
							case "Text":
								sortedPoints = SomeMethodsForCanvas.SortPoints(startPosition, endPosition);
								figure = new MyText(sortedPoints[0], sortedPoints[1], brushSize, colorLine, colorBackGround, fillFlag, font, text);
								break;
						}
					}
				}
				Refresh();
			}
		}

		private void Canvas_MouseUp(object sender, MouseEventArgs e) {
			if (figure != null && mousePressed) {
				figureInCanvas = SomeMethodsForCanvas.BordersCheck(figure, this);

				if (DrawParameters.GetFigureType() == "Text" && figureInCanvas && !selectionFlag) {
					figure = new MyText(sortedPoints[0], sortedPoints[1], brushSize, colorLine, colorBackGround, fillFlag, font, text);
					if (DrawParameters.GetGridBinging()) figure.FigureAlign(SomeMethodsForCanvas.FindNearNodes(figure, gridNodes));
					textBox.Location = figure.GetFigureBox().Location;
					textBox.Clear();
					textBox.BackColor = colorBackGround;
					textBox.Font = font;
					textBox.ClientSize = figure.GetFigureBox().Size;
					textBox.Show();
					textBox.Focus();
				}

				if (figureInCanvas && !selectionFlag && DrawParameters.GetFigureType() != "Text") {
					if (DrawParameters.GetGridBinging()) figure.FigureAlign(SomeMethodsForCanvas.FindNearNodes(figure, gridNodes));
					AddFigure(figure);
					SetFormChangedState(true);
					SomeMethodsForMainForm.CheckSaveButtons();
				}
			}

			if (selectionFlag && !canMoveFigures) {
				if (endPosition == startPosition) {
					endPosition.Offset(1, 1);
					sortedPoints = SomeMethodsForCanvas.SortPoints(startPosition, endPosition);
					figure = new MyRectangle(sortedPoints[0], sortedPoints[1], 1, Color.Black, Color.White, false);
				}
				SomeMethodsForCanvas.PickFigures(this, figure);
			}

			mousePressed = false;
			mousePressedOnFigure = false;
			figure = null;
			Refresh();
		}

		private void textBox_Leave(object sender, EventArgs e) {
			textBox.Hide();
			Refresh();
		}

		private void Canvas_KeyDown(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Delete) {
				DeletePickedFigures();
				Refresh();
			}
		}

		private void textBox_KeyDown(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Enter && textBox.Text != "") {
				text = textBox.Text;
				figure = new MyText(sortedPoints[0], sortedPoints[1], brushSize, colorLine, colorBackGround, fillFlag, font, text);
				if (DrawParameters.GetGridBinging()) figure.FigureAlign(SomeMethodsForCanvas.FindNearNodes(figure, gridNodes));
				if (figureInCanvas) AddFigure(figure);
				textBox.Hide();
				figure = null;
			}
			Refresh();
		}

		private void Canvas_Paint(object sender, PaintEventArgs e) {
			Graphics g = e.Graphics;

			if (grid != null && DrawParameters.GetShowGrid()) {
				foreach (AbstractFigure f in grid) {
					f.DrawDash(g);
				}
			}

			foreach (AbstractFigure f in GetFigures()) {
				f.Draw(g);
				//g.DrawRectangle(new Pen(Color.Red, 1), f.GetFigureBox());
			}

			foreach (AbstractFigure f in GetPickedFigures()) {
				if (copyingToMetafile) f.Draw(g);
				else f.DrawDash(g);
			}

			if (figure != null) {
				figure.DrawDash(g);
			}
		}

		public void Canvas_MouseLeave(object sender, EventArgs e) {
			SomeMethodsForMainForm.RefreshStatusBarCursorPosition("-- ; --");
		}
	}
}