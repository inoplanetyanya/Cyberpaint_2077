using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace Cyberpaint_2077 {
	[Serializable]
	class MyEllipse : AbstractFigure {
		public MyEllipse(Point startPosition, Point endPosition, int brushSize, Color colorLine, Color colorBackground, bool fillFlag) : base(startPosition, endPosition, brushSize, colorLine, colorBackground, fillFlag) {

		}

		public override void DrawDash(Graphics g) {
			Pen pen = new Pen(colorLine, brushSize);
			pen.DashStyle = DashStyle.Dash;
			SolidBrush solidBrush = new SolidBrush(colorBackground);
			Rectangle rect = new Rectangle(pointList.First(), new Size(pointList.Last().X - pointList.First().X, pointList.Last().Y - pointList.First().Y));
			if (fillFlag) {
				g.FillEllipse(solidBrush, rect);
			}
			g.DrawEllipse(pen, rect);
		}

		public override void Draw(Graphics g) {
			Pen pen = new Pen(colorLine, brushSize);
			SolidBrush solidBrush = new SolidBrush(colorBackground);
			Rectangle rect = new Rectangle(pointList.First(), new Size(pointList.Last().X - pointList.First().X, pointList.Last().Y - pointList.First().Y));
			if (fillFlag) {
				g.FillEllipse(solidBrush, rect);
			}
			g.DrawEllipse(pen, rect);
		}

		public override void FigureAlign(List<Point> nodes) {
			pointList = nodes;
		}
	}
}
