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
		AbstractFigure figure, figureDash;

		int brushSize;
		Color colorLine, colorBackGround;
		bool fillFlag, selectionFlag, figureInCanvas;
		string text;
		Font font;

		AbstractFigure figureOnCursor = null;

		public AbstractFigure GetFigureOnCursor() {
			return figureOnCursor;
		}

		bool mousePressedOnFigure = false;
		bool copyingToMetafile = false;
		bool mousePressedOnResizeMarker = false;
		int activeResizeMarker = -1;

		Tuple<Cursor, int> cursorAndMarkerIndex;

		List<AbstractFigure> grid = null;
		List<Point> gridNodes = null;

		string textForCheckTextbox = string.Empty;

		public void SetTextForCheckTextBox(string text) {
			textForCheckTextbox = text;
		}

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

				if (Cursor != Cursors.Default && Cursor != Cursors.SizeAll) {
					mousePressedOnResizeMarker = true;
					activeResizeMarker = cursorAndMarkerIndex.Item2;
				}
				else {
					mousePressedOnResizeMarker = false;
					activeResizeMarker = -1;
				}

				points = new List<Point>();
				points.Add(startPosition);

				Refresh();
			}
		}

		private void Canvas_MouseMove(object sender, MouseEventArgs e) {
			SomeMethodsForMainForm.RefreshStatusBarCursorPosition(e.X.ToString() + " ; " + e.Y.ToString());

			if (mousePressed && selectionFlag && !canMoveFigures && !mousePressedOnFigure && !mousePressedOnResizeMarker) {
				endPosition = e.Location;
				sortedPoints = SomeMethodsForCanvas.SortPoints(startPosition, endPosition);
				figure = new MyRectangle(sortedPoints[0], sortedPoints[1], 1, Color.Black, Color.White, false);
				Refresh();
			}

			foreach (AbstractFigure f in GetPickedFigures()) {
				if (SomeMethodsForCanvas.CursorInFigure(f, e.Location) && !mousePressed) {
					canMoveFigures = true;
					figureOnCursor = f;
				}
			}

			cursorAndMarkerIndex = SomeMethodsForCanvas.RefreshCursor(this, e.Location);

			if (GetPickedFigures().Count == 1) {
				if (cursorAndMarkerIndex.Item2 != -1) {
					Cursor = cursorAndMarkerIndex.Item1;
				}
				else {
					Cursor = cursorAndMarkerIndex.Item1;
				}
			}

			if (mousePressed && canMoveFigures && !mousePressedOnResizeMarker) {
				mousePressedOnFigure = true;
			}

			if (figureOnCursor != null) Cursor = cursorAndMarkerIndex.Item1;
			else if (cursorAndMarkerIndex.Item2 == -1) {
				Cursor = cursorAndMarkerIndex.Item1;
				canMoveFigures = false;
			}

			figureOnCursor = null;

			if (mousePressedOnResizeMarker) {
				Point p1 = startPosition;
				Point p2 = endPosition;
				p2 = e.Location;
				Rectangle rectangle = SomeMethodsForCanvas.GetResizedFigureBox(p2.X - p1.X, p2.Y - p1.Y, activeResizeMarker, GetPickedFigures().First().GetFigureBox());
				figureDash = new MyRectangle(rectangle.Location, new Point(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height), 1, Color.Black, Color.White, false);
				p1 = e.Location;
				Refresh();
			}

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
					textBox.Size = figure.GetFigureBox().Size;
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

			if (selectionFlag && !canMoveFigures && !mousePressedOnResizeMarker) {
				if (startPosition != endPosition) {
					figure = new MyRectangle(sortedPoints[0], sortedPoints[1], 1, Color.Black, Color.White, false);
					SomeMethodsForCanvas.PickFigures(this, figure);
				}
			}

			if (mousePressedOnResizeMarker && DrawParameters.GetGridBinging() && GetPickedFigures().Count() == 1) {
				endPosition = e.Location;
				GetPickedFigures().First().ResizeFigure(endPosition.X - startPosition.X, endPosition.Y - startPosition.Y, activeResizeMarker);
				GetPickedFigures().First().FigureAlign(SomeMethodsForCanvas.FindNearNodes(GetPickedFigures().First(), gridNodes));
			}
			else if (mousePressedOnResizeMarker && GetPickedFigures().Count() == 1) {
				endPosition = e.Location;
				if (SomeMethodsForCanvas.BordersCheckForResizingFigure(GetPickedFigures().First(), this, endPosition.X - startPosition.X, endPosition.Y - startPosition.Y, activeResizeMarker)) {
					GetPickedFigures().First().ResizeFigure(endPosition.X - startPosition.X, endPosition.Y - startPosition.Y, activeResizeMarker);
				}
			}

			mousePressed = false;
			mousePressedOnFigure = false;
			mousePressedOnResizeMarker = false;
			figure = null;
			Refresh();
		}

		private void Canvas_Click(object sender, EventArgs e) {
			if (selectionFlag && !canMoveFigures && !mousePressedOnResizeMarker) {
				RestoreFigures();

				List<AbstractFigure> list = GetFigures().Where(a => SomeMethodsForCanvas.CursorInRectangle(a.GetFigureBox(), startPosition)).ToList();

				if (list.Count > 0) {
					AbstractFigure f = list.Last();
					RemoveFigure(f);
					AddPickedFigure(f);
				}
				
				DrawParameters.SetPickedSingleFigure(false, null);
				SomeMethodsForMainForm.GetMainForm().StatusBarRefresh();
			}
		}

		private void Canvas_DoubleClick(object sender, EventArgs e) {
			if (selectionFlag && canMoveFigures && !mousePressedOnResizeMarker) {
				if (GetPickedFigures().Count == 1) {
					DrawParameters.SetPickedSingleFigure(true, GetPickedFigures().First());
					SomeMethodsForMainForm.GetMainForm().StatusBarRefresh();
					if (GetPickedFigures().First() is MyText) {
						SomeMethodsForMainForm.GetMainForm().ShowEditTextButton();
					}
					else {
						SomeMethodsForMainForm.GetMainForm().HideEditTextButton();
					}
				}
				else {
					DrawParameters.SetPickedSingleFigure(false, null);
					SomeMethodsForMainForm.GetMainForm().StatusBarRefresh();
				}
			}
		}

		private void textBox_Leave(object sender, EventArgs e) {
			textBox.Hide();
			Refresh();
		}

		private void Canvas_KeyDown(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Delete) {
				DrawParameters.SetPickedSingleFigure(false, null);
				DeletePickedFigures();
				Refresh();
			}
		}

		private void textBox_KeyDown(object sender, KeyEventArgs e) {
			if (textForCheckTextbox == "") {
				if (e.KeyCode == Keys.Enter && textBox.Text != "") {
					text = textBox.Text;
					figure = new MyText(sortedPoints[0], sortedPoints[1], brushSize, colorLine, colorBackGround, fillFlag, font, text);
					if (DrawParameters.GetGridBinging()) figure.FigureAlign(SomeMethodsForCanvas.FindNearNodes(figure, gridNodes));
					if (figureInCanvas) AddFigure(figure);
					textBox.Hide();
					figure = null;
					textForCheckTextbox = string.Empty;
				}
				Refresh();
			}
			else if (GetPickedFigures().Count == 1) {
				if (e.KeyCode == Keys.Enter) {
					text = textBox.Text;

					AbstractFigure targetFigure = DrawParameters.GetSingleFigure();
					Point p1 = targetFigure.GetFigureBox().Location;
					Point p2 = targetFigure.GetFigureBox().Location;
					p2.Offset(targetFigure.GetFigureBox().Width, targetFigure.GetFigureBox().Height);
					int bs = targetFigure.GetBrushSize();
					Font f = targetFigure.GetFont();
					Color cl = targetFigure.GetColorLine();
					Color cb = targetFigure.GetColorBackground();
					bool ff = targetFigure.GetFillFlag();

					GetPickedFigures()[0] = new MyText(p1, p2, bs, cl, cb, ff, f, text);
					if (DrawParameters.GetGridBinging()) figure.FigureAlign(SomeMethodsForCanvas.FindNearNodes(figure, gridNodes));
					textBox.Hide();
					figure = null;
					textForCheckTextbox = string.Empty;
				}
				Refresh();
			}
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
			}

			foreach (AbstractFigure f in GetPickedFigures()) {
				if (copyingToMetafile) f.Draw(g);
				else {
					f.DrawDash(g);
					if (figureDash != null) {
						figureDash.DrawDash(g);
						figureDash = null;
					}
					if (DrawParameters.GetPickedSingleFigureState()) f.DrawResizeMarkers(g);
				}
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