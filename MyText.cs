using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;

namespace Cyberpaint_2077 {
	[Serializable]
	class MyText : AbstractFigure {
		string text;
		Font font;
		public MyText(Point startPosition, Point endPosition, int brushSize, Color colorLine, Color colorBackground, bool fillFlag, Font font, string text) : base(startPosition, endPosition, brushSize, colorLine, colorBackground, fillFlag) {
			this.text = text;
			this.font = font;
		}

		public override void Draw(Graphics g) {
			Pen pen = new Pen(colorLine, brushSize);
			SolidBrush solidBrush = new SolidBrush(colorBackground);
			Rectangle rect = new Rectangle(pointList.First(), new Size(pointList.Last().X - pointList.First().X, pointList.Last().Y - pointList.First().Y));
			if (fillFlag) { 
				g.FillRectangle(solidBrush, rect); 
			}
			g.DrawRectangle(pen, rect);
			g.DrawString(text, font, new SolidBrush(colorLine), rect);
		}

		public override void DrawDash(Graphics g) {
			Pen pen = new Pen(colorLine, brushSize);
			pen.DashStyle = DashStyle.Dash;
			SolidBrush solidBrush = new SolidBrush(colorBackground);
			Rectangle rect = new Rectangle(pointList.First(), new Size(pointList.Last().X - pointList.First().X, pointList.Last().Y - pointList.First().Y));
			if (fillFlag) {
				g.FillRectangle(solidBrush, rect);
			}
			g.DrawRectangle(pen, rect);
			g.DrawString(text, font, new SolidBrush(colorLine), rect);
		}

		public override void FigureAlign(List<Point> nodes) {
			pointList = nodes;
		}
	}
}
