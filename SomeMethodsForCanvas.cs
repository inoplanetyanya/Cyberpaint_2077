using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cyberpaint_2077 {
	public static class SomeMethodsForCanvas {

		public static Point[] SortPoints(Point p1, Point p2) {
			int tmp;
			if (p1.X > p2.X) { tmp = p2.X; p2.X = p1.X; p1.X = tmp; }
			if (p1.Y > p2.Y) { tmp = p2.Y; p2.Y = p1.Y; p1.Y = tmp; }
			return new Point[] { p1, p2 };
		}

		public static bool BordersCheck(AbstractFigure figure, Canvas canvas) {
			Rectangle rectangle = Rectangle.Intersect(figure.GetFigureBox(), new Rectangle(new Point(0, 0), new Size(canvas.Width - 1, canvas.Height - 1)));
			return rectangle == figure.GetFigureBox();
		}

		public static bool BordersCheckForMovingFigures(AbstractFigure figure, Canvas canvas, int dx, int dy) {
			Rectangle rectangle = Rectangle.Intersect(figure.GetShiftedFigureBox(dx, dy), new Rectangle(new Point(0, 0), new Size(canvas.Width - 1, canvas.Height - 1)));
			return rectangle == figure.GetShiftedFigureBox(dx, dy);
		}

		public static bool BordersCheckForResizingFigure(AbstractFigure figure, Canvas canvas, int dx, int dy, int markerIndex) {
			Rectangle rectangle = Rectangle.Intersect(figure.GetResizedFigureBox(dx, dy, markerIndex), new Rectangle(new Point(0, 0), new Size(canvas.Width - 1, canvas.Height - 1)));
			return rectangle == figure.GetResizedFigureBox(dx, dy, markerIndex);
		}

		public static bool IntersectCheck(AbstractFigure figure, AbstractFigure selectionZone) {
			return selectionZone.GetFigureBox().IntersectsWith(figure.GetFigureBox());
		}

		public static Rectangle GetSelectionRectangle(Canvas canvas) {
			Point p1 = new Point(canvas.GetCanvasSize().Width, canvas.GetCanvasSize().Height);
			Point p2 = new Point(0, 0);
			foreach (AbstractFigure f in canvas.GetPickedFigures()) {
				if (f.GetFigureBox().Location.X <= p1.X) p1.X = f.GetFigureBox().Location.X;
				if (f.GetFigureBox().Location.Y <= p1.Y) p1.Y = f.GetFigureBox().Location.Y;
				if (f.GetFigureBox().Location.X + f.GetFigureBox().Width >= p2.X) p2.X = f.GetFigureBox().Location.X + f.GetFigureBox().Width;
				if (f.GetFigureBox().Location.Y + f.GetFigureBox().Height >= p2.Y) p2.Y = f.GetFigureBox().Location.Y + f.GetFigureBox().Height;
			}
			return new Rectangle(p1, new Size(p2.X - p1.X, p2.Y - p1.Y));
		}

		public static Rectangle GetSelectionRectangle(Canvas canvas, List<AbstractFigure> figures) {
			Point p1 = new Point(canvas.Size.Width, canvas.Size.Height);
			Point p2 = new Point(0, 0);
			foreach (AbstractFigure f in figures) {
				if (f.GetFigureBox().Location.X <= p1.X) p1.X = f.GetFigureBox().Location.X;
				if (f.GetFigureBox().Location.Y <= p1.Y) p1.Y = f.GetFigureBox().Location.Y;
				if (f.GetFigureBox().Location.X + f.GetFigureBox().Width >= p2.X) p2.X = f.GetFigureBox().Location.X + f.GetFigureBox().Width;
				if (f.GetFigureBox().Location.Y + f.GetFigureBox().Height >= p2.Y) p2.Y = f.GetFigureBox().Location.Y + f.GetFigureBox().Height;
			}
			return new Rectangle(p1, new Size(p2.X - p1.X, p2.Y - p1.Y));
		}

		public static bool CursorInFigure(AbstractFigure figure, Point cursorPosition) {
			return
			cursorPosition.X >= figure.GetFigureBox().Location.X &&
			cursorPosition.X <= figure.GetFigureBox().Location.X + figure.GetFigureBox().Width &&
			cursorPosition.Y >= figure.GetFigureBox().Location.Y &&
			cursorPosition.Y <= figure.GetFigureBox().Location.Y + figure.GetFigureBox().Height;
		}

		public static bool CursorInRectangle(Rectangle rectangle, Point cursorPosition) {
			return
			cursorPosition.X >= rectangle.X &&
			cursorPosition.X <= rectangle.X + rectangle.Width &&
			cursorPosition.Y >= rectangle.Y &&
			cursorPosition.Y <= rectangle.Y + rectangle.Height;
		}

		public static Tuple<Cursor, int> RefreshCursor(Canvas canvas, Point cursorPosition) {
			int i = 0;
			bool markerFound = false;

			foreach (AbstractFigure figure in canvas.GetPickedFigures()) {
				foreach (Rectangle rectangle in figure.GetResizeMarkers()) {
					if (CursorInRectangle(rectangle, cursorPosition)) {
						markerFound = true;
						break;
					}
					i++;
				}
			}

			if (markerFound) {
				if (i == 0 || i == 7) return new Tuple<Cursor, int>(Cursors.SizeNWSE, i);
				else if (i == 1 || i == 6) return new Tuple<Cursor, int>(Cursors.SizeWE, i);
				else if (i == 2 || i == 5) return new Tuple<Cursor, int>(Cursors.SizeNESW, i);
				else if (i == 3 || i == 4) return new Tuple<Cursor, int>(Cursors.SizeNS, i);
			}

			if (canvas.GetFigureOnCursor() == null) return new Tuple<Cursor, int>(Cursors.Default, -1);
			return new Tuple<Cursor, int>(Cursors.SizeAll, -1);
		}

		public static void CopyAreaToMetafile(Canvas canvas) {
			canvas.SetCopyingToMetafileStatus(true);
			Bitmap bitmap = new Bitmap(canvas.Width, canvas.Height);
			canvas.DrawToBitmap(bitmap, new Rectangle(0, 0, canvas.Width, canvas.Height));
			Clipboard.SetImage(bitmap.Clone(new Rectangle(GetSelectionRectangle(canvas).Location, new Size(GetSelectionRectangle(canvas).Width + 1, GetSelectionRectangle(canvas).Height + 1)), bitmap.PixelFormat));
			canvas.SetCopyingToMetafileStatus(false);
		}

		public static void CopyAreaToClipboard(Canvas canvas) {
			Clipboard.SetData("Cyberpaint2077Format", canvas.GetPickedFigures());
		}

		public static void PasteAreaFromClipboard(Canvas canvas) {
			if (Clipboard.GetDataObject().GetDataPresent("Cyberpaint2077Format")) {
				if (GetSelectionRectangle(canvas, (List<AbstractFigure>)Clipboard.GetDataObject().GetData("Cyberpaint2077Format")).Width <= canvas.Width && GetSelectionRectangle(canvas, (List<AbstractFigure>)Clipboard.GetDataObject().GetData("Cyberpaint2077Format")).Height <= canvas.Height) {
					List<AbstractFigure> figures = ((List<AbstractFigure>)Clipboard.GetDataObject().GetData("Cyberpaint2077Format"));

					Point offset = new Point(-GetSelectionRectangle(canvas, figures).Location.X, -GetSelectionRectangle(canvas, figures).Location.Y);

					foreach (AbstractFigure f in figures) {
						f.MoveFigure(offset.X, offset.Y);
					}

					canvas.RestoreFigures();
					canvas.AddPickedFigures(figures);
					canvas.Refresh();
				}
				else {
					MessageBox.Show("Размеры фрагмента превышают размеры холста");
				}
			}
		}

		public static void PickFigures(Canvas canvas, AbstractFigure figure) {
			canvas.RestoreFigures();
			canvas.SetPickedFigures(canvas.GetFigures().Where(x => SomeMethodsForCanvas.IntersectCheck(x, figure)).ToList<AbstractFigure>());
			foreach (AbstractFigure f in canvas.GetPickedFigures()) {
				canvas.RemoveFigure(f);
			}
			canvas.Refresh();
		}

		public static void PickAllFigures(Canvas canvas) {
			canvas.RestoreFigures();
			canvas.AddPickedFigures(canvas.GetFigures().Where(x => true).ToList<AbstractFigure>());
			foreach (AbstractFigure f in canvas.GetPickedFigures()) {
				canvas.RemoveFigure(f);
			}
			canvas.Refresh();
		}

		public static double RectangleDiagonal(Rectangle rectangle) {
			return Math.Sqrt(Math.Pow(rectangle.Width + rectangle.X - rectangle.Location.X, 2) + Math.Pow(rectangle.Height + rectangle.Y - rectangle.Location.Y, 2));
		}

		public static double RectangleDiagonal(Point topLeft, Point bottomRight) {
			return Math.Sqrt(Math.Pow(bottomRight.X - topLeft.X, 2) + Math.Pow(bottomRight.Y - topLeft.Y, 2));
		}

		public static List<Point> FindNearNodes(AbstractFigure figure, List<Point> nodes) {
			Point startPositon = figure.GetFigureBox().Location;
			Point endPosition = new Point(figure.GetFigureBox().Location.X + figure.GetFigureBox().Width, figure.GetFigureBox().Location.Y + figure.GetFigureBox().Height);

			double minDistance = double.MaxValue;

			Point findedNode1 = new Point();
			Point findedNode2 = new Point();

			foreach (Point point in nodes) {
				double distance = Math.Sqrt(Math.Pow(startPositon.X - point.X, 2) + Math.Pow(startPositon.Y - point.Y, 2));
				if (distance < minDistance) {
					minDistance = distance;
					findedNode1 = point;
				}
			}

			minDistance = double.MaxValue;

			foreach (Point point in nodes) {
				double distance = Math.Sqrt(Math.Pow(endPosition.X - point.X, 2) + Math.Pow(endPosition.Y - point.Y, 2));
				if (distance < minDistance) {
					minDistance = distance;
					findedNode2 = point;
				}
			}

			return new List<Point>(new Point[] {findedNode1, findedNode2});
		}

		public static void AlignGrid(Canvas canvas) {
			foreach (AbstractFigure figure in canvas.GetFigures()) {
				figure.FigureAlign(FindNearNodes(figure, canvas.GetGridNodes()));
			}
			canvas.Refresh();
		}

		public static Rectangle GetResizedFigureBox(int dx, int dy, int markerIndex, Rectangle figureBox) {
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
	}
}
