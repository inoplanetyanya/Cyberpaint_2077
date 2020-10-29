using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace Cyberpaint_2077 {
	[Serializable]
	class MyCurve : AbstractFigure {
		public MyCurve(List<Point> pointList, int brushSize, Color colorLine, Color colorBackground, bool fillFlag) : base(pointList, brushSize, colorLine, colorBackground, fillFlag) {

		}

		public override void DrawDash(Graphics g) {
			Pen pen = new Pen(colorLine, brushSize);
			pen.DashStyle = DashStyle.Dash;
			g.DrawCurve(pen, pointList.ToArray<Point>());
		}

		public override void Draw(Graphics g) {
			Pen pen = new Pen(colorLine, brushSize);
			g.DrawCurve(pen, pointList.ToArray());
		}

		public override void FigureAlign(List<Point> nodes) {
			double scaleCoeffX = ((double)nodes.Last().X - (double)nodes.First().X) / (double)GetFigureBox().Width;
			double scaleCoeffY = ((double)nodes.Last().Y - (double)nodes.First().Y) / (double)GetFigureBox().Height;

			Point figureCenter = new Point(GetFigureBox().X + GetFigureBox().Width / 2, GetFigureBox().Y + GetFigureBox().Height / 2);
			MoveFigure(-figureCenter.X, -figureCenter.Y);

			for (int i = 0; i < pointList.Count; i++) {
				pointList[i] = new Point((int)Math.Round(pointList[i].X * scaleCoeffX), (int)Math.Round(pointList[i].Y * scaleCoeffY));
			}

			MoveFigure(nodes.First().X - GetFigureBox().X, nodes.First().Y - GetFigureBox().Y);
		}
	}
}
