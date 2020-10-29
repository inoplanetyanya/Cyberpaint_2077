using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace Cyberpaint_2077 {
	[Serializable]
	class MyLine : AbstractFigure {
		public MyLine(Point startPosition, Point endPosition, int brushSize, Color colorLine, Color colorBackground, bool fillFlag) : base(startPosition, endPosition, brushSize, colorLine, colorBackground, fillFlag) {

		}

		public override void DrawDash(Graphics g) {
			Pen pen = new Pen(colorLine, brushSize);
			pen.DashStyle = DashStyle.Dash;
			g.DrawLine(pen, pointList.First(), pointList.Last());
		}

		public override void Draw(Graphics g) {
			Pen pen = new Pen(colorLine, brushSize);
			g.DrawLine(pen, pointList.First(), pointList.Last());
		}

		public override void FigureAlign(List<Point> nodes) {
			Point p1 = nodes.First();
			Point p2 = nodes.Last();

			if (pointList.First().X > pointList.Last().X) {
				p1.X = nodes.Last().X;
				p2.X = nodes.First().X;
			}

			if (pointList.First().Y > pointList.Last().Y) {
				p1.Y = nodes.Last().Y;
				p2.Y = nodes.First().Y;
			}

			pointList = new List<Point>(new Point[] { p1, p2 });
		}
	}
}