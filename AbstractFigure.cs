using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpaint_2077 {
	[Serializable]
	public abstract class AbstractFigure {
		protected int brushSize;
		protected bool fillFlag;
		protected Color colorLine, colorBackground;
		protected List<Point> pointList;
		protected Point startPosition, endPosition;
		protected List<Rectangle> resizeMarkers;
		protected Rectangle figureBox;

		protected Font font;
		protected string text;

		public AbstractFigure GetCopy(AbstractFigure figure) {
			if (figure is MyLine) {
				return new MyLine(figure.startPosition, figure.endPosition, figure.brushSize, figure.colorLine, figure.colorBackground, figure.fillFlag);
			}
			else if (figure is MyCurve) {
				return new MyCurve(figure.pointList, figure.brushSize, figure.colorLine, figure.colorBackground, figure.fillFlag);
			}
			else if (figure is MyRectangle) {
				return new MyRectangle(figure.startPosition, figure.endPosition, figure.brushSize, figure.colorLine, figure.colorBackground, figure.fillFlag);
			}
			else if (figure is MyEllipse) {
				return new MyEllipse(figure.startPosition, figure.endPosition, figure.brushSize, figure.colorLine, figure.colorBackground, figure.fillFlag);
			}
			else if (figure is MyText) {
				return new MyText(figure.startPosition, figure.endPosition, figure.brushSize, figure.colorLine, figure.colorBackground, figure.fillFlag, figure.font, figure.text);
			}

			return null;
		}


		public int GetBrushSize() {
			return brushSize;
		}

		public void SetBrushSize(int size) {
			brushSize = size;
		}

		public bool GetFillFlag() {
			return fillFlag;
		}

		public void SetFillFlag(bool flag) {
			fillFlag = flag;
		}

		public Color GetColorLine() {
			return colorLine;
		}

		public void SetColorLine(Color color) {
			colorLine = color;
		}

		public Color GetColorBackground() {
			return colorBackground;
		}

		public void SetColorBackground(Color color) {
			colorBackground = color;
		}

		public Font GetFont() {
			if (font != null) return font;
			return new Font(new FontFamily("Times New Roman"), 8, FontStyle.Regular, GraphicsUnit.Point);
		}

		public void SetFont(Font font) {
			this.font = font;
		}

		public string GetText() {
			if (text != null) return text;
			return "";
		}

		public void SetText(string text) {
			this.text = text;
		}

		public List<Point> GetPoints() {
			return pointList;
		}

		public void SetPoints(List<Point> points) {
			pointList = points;
			figureBox = CreateFigureBox();
			resizeMarkers = CreateResizeMarkers();
		}

		public AbstractFigure(List<Point> pointList, int brushSize, Color colorLine, Color colorBackground, bool fillFlag) {
			this.brushSize = brushSize;
			this.colorLine = colorLine;
			this.colorBackground = colorBackground;
			this.fillFlag = fillFlag;

			this.pointList = pointList;
			figureBox = CreateFigureBox();
			resizeMarkers = CreateResizeMarkers();
		}

		public AbstractFigure(Point startPosition, Point endPosition, int brushSize, Color colorLine, Color colorBackground, bool fillFlag) {
			this.brushSize = brushSize;
			this.colorLine = colorLine;
			this.colorBackground = colorBackground;
			this.fillFlag = fillFlag;

			this.startPosition = startPosition;
			this.endPosition = endPosition;
			
			pointList = new List<Point>();
			pointList.Add(startPosition);
			pointList.Add(endPosition);
			figureBox = CreateFigureBox();
			resizeMarkers = CreateResizeMarkers();
		}

		public abstract void DrawDash(Graphics g);
		public abstract void Draw(Graphics g);
		public abstract void FigureAlign(List<Point> nodes);

		protected Rectangle CreateFigureBox() {
			Point p1, p2;
			p1 = new Point(pointList.OrderBy(p => p.X).First().X, pointList.OrderBy(p => p.Y).First().Y);
			p2 = new Point(pointList.OrderBy(p => p.X).Last().X, pointList.OrderBy(p => p.Y).Last().Y);
			return new Rectangle(p1.X, p1.Y, p2.X - p1.X, p2.Y - p1.Y);
		}

		public Rectangle GetFigureBox() {
			return figureBox;
		}

		public Rectangle GetShiftedFigureBox(int dx, int dy) {
			List<Point> pts = new List<Point>(pointList);
			for (int i = 0; i < pts.Count; i++) {
				pts[i] = new Point(pts[i].X + dx, pts[i].Y + dy);
			}
			Point p1, p2;
			p1 = new Point(pts.OrderBy(p => p.X).First().X, pts.OrderBy(p => p.Y).First().Y);
			p2 = new Point(pts.OrderBy(p => p.X).Last().X, pts.OrderBy(p => p.Y).Last().Y);
			return new Rectangle(p1.X, p1.Y, p2.X - p1.X, p2.Y - p1.Y);
		}

		public Rectangle GetResizedFigureBox(int dx, int dy, int markerIndex) {
			Rectangle rectangle = figureBox;
			switch (markerIndex) {
				case 0:
					if (rectangle.Width - dx > 0 && rectangle.Height - dy > 0) {
						rectangle.Offset(dx, dy);
						rectangle.Width -= dx;
						rectangle.Height -= dy;
					}
					break;
				case 1:
					if (rectangle.Width - dx > 0) {
						rectangle.Offset(dx, 0);
						rectangle.Width -= dx;
					}
					break;
				case 2:
					if (rectangle.Width - dx > 0 && rectangle.Height + dy > 0) {
						rectangle.Offset(dx, 0);
						rectangle.Width -= dx;
						rectangle.Height += dy;
					}
					break;
				case 3:
					if (rectangle.Height - dy > 0) {
						rectangle.Offset(0, dy);
						rectangle.Height -= dy;
					}
					break;
				case 4:
					if (rectangle.Height + dy > 0) {
						rectangle.Height += dy;
					}
					break;
				case 5:
					if (rectangle.Width + dx > 0 && rectangle.Height - dy > 0) {
						rectangle.Offset(0, dy);
						rectangle.Width += dx;
						rectangle.Height -= dy;
					}
					break;
				case 6:
					if (rectangle.Width + dx > 0) {
						rectangle.Width += dx;
					}
					break;
				case 7:
					if (rectangle.Width + dx > 0 && rectangle.Height + dy > 0) {
						rectangle.Width += dx;
						rectangle.Height += dy;
					}
					break;
				default:
					break;
			}
			return rectangle;
		}

		public void MoveFigure(int dx, int dy) {
			for (int i = 0; i < pointList.Count; i++) {
				pointList[i] = new Point(pointList[i].X + dx, pointList[i].Y + dy);
			}
			figureBox = CreateFigureBox();
			resizeMarkers = CreateResizeMarkers();
		}

		public void ResizeFigure(int dx, int dy, int markerIndex) {
			Rectangle rectangle = figureBox;
			switch (markerIndex) {
				case 0:
					if (rectangle.Width - dx > 0 && rectangle.Height - dy > 0) {
						rectangle.Offset(dx, dy);
						rectangle.Width -= dx;
						rectangle.Height -= dy;
					}
					break;
				case 1:
					if (rectangle.Width - dx > 0) {
						rectangle.Offset(dx, 0);
						rectangle.Width -= dx;
					}
					break;
				case 2:
					if (rectangle.Width - dx > 0 && rectangle.Height + dy > 0) {
						rectangle.Offset(dx, 0);
						rectangle.Width -= dx;
						rectangle.Height += dy;
					}
					break;
				case 3:
					if (rectangle.Height - dy > 0) {
						rectangle.Offset(0, dy);
						rectangle.Height -= dy;
					}
					break;
				case 4:
					if (rectangle.Height + dy > 0) {
						rectangle.Height += dy;
					}
					break;
				case 5:
					if (rectangle.Width + dx > 0 && rectangle.Height - dy > 0) {
						rectangle.Offset(0, dy);
						rectangle.Width += dx;
						rectangle.Height -= dy;
					}
					break;
				case 6:
					if (rectangle.Width + dx > 0) {
						rectangle.Width += dx;
					}
					break;
				case 7:
					if (rectangle.Width + dx > 0 && rectangle.Height + dy > 0) {
						rectangle.Width += dx;
						rectangle.Height += dy;
					}
					break;
				default:
					break;
			}

			List<Point> points = new List<Point>();
			points.Add(rectangle.Location);
			points.Add(new Point(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height));
			FigureAlign(points);
		}																																	

		public void DrawResizeMarkers(Graphics g) {
			foreach (Rectangle rectangle in resizeMarkers) {
				g.DrawRectangle(new Pen(Color.Black, 1), rectangle);
			}
		}

		protected List<Rectangle> CreateResizeMarkers() {
			List<Rectangle> rectangles = new List<Rectangle>();

			Rectangle figureBox = GetFigureBox();
			Size size = new Size(6, 6);
			int shift = 3;

			rectangles.Add(new Rectangle(new Point(figureBox.X - shift, figureBox.Y - shift), size));
			rectangles.Add(new Rectangle(new Point(figureBox.X - shift, figureBox.Y - shift + figureBox.Height / 2), size));
			rectangles.Add(new Rectangle(new Point(figureBox.X - shift, figureBox.Y - shift + figureBox.Height), size));

			rectangles.Add(new Rectangle(new Point(figureBox.X - shift + figureBox.Width / 2, figureBox.Y - shift), size));
			rectangles.Add(new Rectangle(new Point(figureBox.X - shift + figureBox.Width / 2, figureBox.Y - shift + figureBox.Height), size));

			rectangles.Add(new Rectangle(new Point(figureBox.X - shift + figureBox.Width, figureBox.Y - shift), size));
			rectangles.Add(new Rectangle(new Point(figureBox.X - shift + figureBox.Width, figureBox.Y - shift + figureBox.Height / 2), size));
			rectangles.Add(new Rectangle(new Point(figureBox.X - shift + figureBox.Width, figureBox.Y - shift + figureBox.Height), size));

			return rectangles;
		}

		public List<Rectangle> GetResizeMarkers() {
			return resizeMarkers;
		}
	}
}