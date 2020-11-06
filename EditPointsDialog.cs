using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cyberpaint_2077 {
	public partial class EditPointsDialog : Form {

		AbstractFigure activeFigure;

		public EditPointsDialog(AbstractFigure figure) {
			InitializeComponent();
			activeFigure = figure;
			points = figure.GetPoints();
			TBPoints.Text = PointsToSting(points);
		}

		public EditPointsDialog() {
			InitializeComponent();
		}

		List<Point> points = new List<Point>();

		public List<Point> GetPoints() {
			return points;
		}

		private void TBPoints_KeyPress(object sender, KeyPressEventArgs e) {
			if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Enter && e.KeyChar != (char)Keys.Space && e.KeyChar != (char)Keys.Back) {
				e.Handled = true;
			}
		}

		string PointsToSting(List<Point> points) {
			string result = "";

			for (int i = 0; i < points.Count() - 1; i ++) result += points[i].X.ToString() + " " + points[i].Y.ToString() + "\r\n";

			result += points.Last().X.ToString() + " " + points.Last().Y.ToString();

			return result;
		}

		List<Point> StringToPoint(string text) {
			List<Point> points = new List<Point>();
			MatchCollection matchCollection = Regex.Matches(text, @"(\d+)\s(\d+)");

			foreach (Match match in matchCollection) {
				points.Add(new Point(Convert.ToInt32(match.Groups[1].Value), Convert.ToInt32(match.Groups[2].Value)));
			}

			return points;
		}

		bool StringValidation() {
			string[] strs = TBPoints.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
			MatchCollection matchCollection = Regex.Matches(TBPoints.Text, @"\d+\s\d+");

			if (activeFigure is MyCurve) return strs.Length == matchCollection.Count;
			else return strs.Length == matchCollection.Count && matchCollection.Count == 2;
		}

		private void BOK_Click(object sender, EventArgs e) {
			if (StringValidation()) {
				cancel = false;
				points = StringToPoint(TBPoints.Text);
			}
			else {
				cancel = true;
				MessageBox.Show("Неверный формат ввода", "Ошибка", MessageBoxButtons.OK);
			}
		}

		bool cancel;

		private void EditPointsDialog_FormClosing(object sender, FormClosingEventArgs e) {
			e.Cancel = cancel;
			cancel = false;
		}
	}
}
