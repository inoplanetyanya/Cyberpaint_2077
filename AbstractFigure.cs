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

		public AbstractFigure(List<Point> pointList, int brushSize, Color colorLine, Color colorBackground, bool fillFlag) {
			this.brushSize = brushSize;
			this.colorLine = colorLine;
			this.colorBackground = colorBackground;
			this.fillFlag = fillFlag;

			this.pointList = pointList;
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
		}

		public abstract void DrawDash(Graphics g);
		public abstract void Draw(Graphics g);
		public abstract void FigureAlign(List<Point> nodes);

		public virtual Rectangle GetFigureBox() {
			Point p1, p2;
			p1 = new Point(pointList.OrderBy(p => p.X).First().X, pointList.OrderBy(p => p.Y).First().Y);
			p2 = new Point(pointList.OrderBy(p => p.X).Last().X, pointList.OrderBy(p => p.Y).Last().Y);
			return new Rectangle(p1.X, p1.Y, p2.X - p1.X, p2.Y - p1.Y);
		}

		public virtual Rectangle GetShiftedFigureBox(int dx, int dy) {
			List<Point> pts = new List<Point>(pointList);
			for (int i = 0; i < pts.Count; i++) {
				pts[i] = new Point(pts[i].X + dx, pts[i].Y + dy);
			}
			Point p1, p2;
			p1 = new Point(pts.OrderBy(p => p.X).First().X, pts.OrderBy(p => p.Y).First().Y);
			p2 = new Point(pts.OrderBy(p => p.X).Last().X, pts.OrderBy(p => p.Y).Last().Y);
			return new Rectangle(p1.X, p1.Y, p2.X - p1.X, p2.Y - p1.Y);
		}

		public void MoveFigure(int dx, int dy) {
			for (int i = 0; i < pointList.Count; i++) {
				pointList[i] = new Point(pointList[i].X + dx, pointList[i].Y + dy);
			}
		}
	}
}