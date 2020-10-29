using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cyberpaint_2077 {
	public static class SomeMethodsForMainForm {

		public static void AddEmptyChildForm(MainForm mainForm) {
			NewWindowParametersDialog dialog = new NewWindowParametersDialog();
			if (dialog.ShowDialog() == DialogResult.OK) {
				ChildForm childForm = new ChildForm();
				childForm.MdiParent = mainForm;
				childForm.Text = mainForm.MdiChildren.Length.ToString();
				childForm.ClientSize = new Size(dialog.width, dialog.height);

				Canvas canvas = new Canvas();
				canvas.Size = childForm.ClientSize;
				canvas.ClientSize = childForm.ClientSize;
				canvas.BackColor = Color.White;
				canvas.Anchor = AnchorStyles.None;
				canvas.Name = "Canvas";

				canvas.SetCanvasSize(new Size(dialog.width, dialog.height));
				canvas.SetFigures(new List<AbstractFigure>());
				canvas.SetFormChangedState(false);
				canvas.SetName(string.Empty);

				childForm.AutoScrollMinSize = canvas.GetCanvasSize();
				childForm.SetCanvas(canvas);
				childForm.Show();
			}
		}

		public static void AddEmptyChildForm(MainForm mainForm, Size size) {
			ChildForm childForm = new ChildForm();
			childForm.MdiParent = mainForm;
			childForm.Text = mainForm.MdiChildren.Length.ToString();
			childForm.ClientSize = size;

			Canvas canvas = new Canvas();
			canvas.Size = childForm.ClientSize;
			canvas.ClientSize = childForm.ClientSize;
			canvas.BackColor = Color.White;
			canvas.Anchor = AnchorStyles.None;
			canvas.Name = "Canvas";

			canvas.SetCanvasSize(size);
			canvas.SetFigures(new List<AbstractFigure>());
			canvas.SetFormChangedState(false);
			canvas.SetName(string.Empty);

			childForm.AutoScrollMinSize = canvas.GetCanvasSize();
			childForm.SetCanvas(canvas);
			childForm.Show();
		}

		public static void OpenFile(MainForm mainForm) {
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.InitialDirectory = Environment.CurrentDirectory;
			dialog.Filter = "Файл (*.StepanovDA_0023-02)|*.StepanovDA_0023-02";
			if (dialog.ShowDialog() == DialogResult.OK) {
				BinaryFormatter formatter = new BinaryFormatter();
				Stream stream = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read);

				SerializebleData data = (SerializebleData)formatter.Deserialize(stream);

				ChildForm childForm = new ChildForm();
				childForm.Text = data.GetName();
				childForm.MdiParent = mainForm;
				childForm.ClientSize = data.GetCanvasSize();

				Canvas canvas = new Canvas(data);
				childForm.SetCanvas(canvas);

				childForm.Show();

				stream.Close();

				CheckSaveButtons();
				mainForm.buttonSave.Enabled = false;
				mainForm.FileSaveToolStripMenuItem.Enabled = false;
			}
		}

		public static void SaveFile(ChildForm childForm) {
			SaveFileDialog dialog = new SaveFileDialog();
			dialog.InitialDirectory = Environment.CurrentDirectory;
			dialog.Filter = "Файл (*.StepanovDA_0023-02)|*.StepanovDA_0023-02";
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			if (childForm.GetCanvas().GetSerializebleData().GetName() == string.Empty) {
				if (dialog.ShowDialog() == DialogResult.OK) {
					childForm.SetName(System.IO.Path.GetFileName(dialog.FileName));
					childForm.SetFormChangedState(false);
					childForm.Text = System.IO.Path.GetFileName(dialog.FileName);
					childForm.RestoreFigures();

					Stream stream = new FileStream(childForm.GetCanvas().GetSerializebleData().GetName(), FileMode.Create, FileAccess.Write);
					binaryFormatter.Serialize(stream, childForm.GetCanvas().GetSerializebleData());
					stream.Close();
				}
			}
			else {
				dialog.FileName = childForm.GetName();

				childForm.SetName(dialog.FileName);
				childForm.SetFormChangedState(false);
				childForm.RestoreFigures();
				childForm.Text = System.IO.Path.GetFileName(dialog.FileName);

				Stream stream = new FileStream(dialog.FileName, FileMode.Create, FileAccess.Write);
				stream.Close();
			}
		}

		public static void ChangePenSizeDialog() {
			PenSizeDialog dialog = new PenSizeDialog();
			if (dialog.ShowDialog() == DialogResult.OK) {
				DrawParameters.SetBrushSize(dialog.GetSize());
				DrawParameters.SetPenIndex(dialog.GetIndex());
			}
			mainForm.StatusBarRefresh();
		}

		public static void ChangePenSize(int size, int index) {
			DrawParameters.SetBrushSize(size);
			DrawParameters.SetPenIndex(index);
			mainForm.StatusBarRefresh();
		}

		public static void ChangeColorLine(MainForm mainForm) {
			ColorDialog dialog = new ColorDialog();
			if (dialog.ShowDialog() == DialogResult.OK)DrawParameters.SetColorLine(dialog.Color);
			mainForm.StatusBarRefresh();
		}

		public static void ChangeColorBackground(MainForm mainForm) {
			ColorDialog dialog = new ColorDialog();
			if (dialog.ShowDialog() == DialogResult.OK) DrawParameters.SetColorBackground(dialog.Color);
			mainForm.StatusBarRefresh();
		}

		public static void ChangeFillFlag(MainForm mainForm) {
			DrawParameters.SetFillFlag(!DrawParameters.GetFillFlag());
			mainForm.ParametersFillToolStripMenuItem.Checked = DrawParameters.GetFillFlag();
			mainForm.checkBoxBGFill.Checked = DrawParameters.GetFillFlag();
		}

		public static void ChangeFigureType(MainForm mainForm, ToolStripMenuItem menuItem) {
			mainForm.FiguresLineToolStripMenuItem.Checked = false;
			mainForm.FiguresCurveToolStripMenuItem.Checked = false;
			mainForm.FiguresRectangleToolStripMenuItem.Checked = false;
			mainForm.FiguresEllipseToolStripMenuItem.Checked = false;

			menuItem.Checked = true;
		}

		public static Size GetNewFormSize(RadioButton RB320x240, RadioButton RB640x480, RadioButton RB800x600) {
			if (RB320x240.Checked) return new Size(320, 240);
			if (RB640x480.Checked) return new Size(640, 480);
			if (RB800x600.Checked) return new Size(800, 600);
			return new Size(10, 10);
		}

		static MainForm mainForm;

		public static void SetMainForm(MainForm form) {
			mainForm = form;
		}

		public static void RefreshStatusBarCursorPosition(string position) {
			mainForm.RefreshStatusBarCursorPosition(position);
		}

		public static void CheckSaveButtons() {
			mainForm.CheckSaveButtonsStatus();
		}

		public static void SelectionButtonClick(Button button){
			if (button.BackColor != Color.Gray) button.BackColor = Color.Gray;
			else button.BackColor = Color.FromArgb(240, 240, 240);
			DrawParameters.SetObjectSelectionFlag(!DrawParameters.GetObjectSelectionFlag());
		}

		public static void ChangeFont() {
			FontDialog dialog = new FontDialog();
			if (dialog.ShowDialog() == DialogResult.OK) DrawParameters.SetFont(dialog.Font);
			mainForm.StatusBarRefresh();
		}

		public static void CreateGrid(int gridPitch, Canvas canvas) {
			int linePositionX = gridPitch;
			int linePositionY = gridPitch;

			List<AbstractFigure> grid = new List<AbstractFigure>();
			Color color = Color.FromArgb(30, 128, 128, 128);

			while(linePositionX < canvas.Size.Width) {
				grid.Add(new MyLine(new Point(linePositionX, 0), new Point(linePositionX, canvas.Size.Height), 1, color, Color.White, false));
				linePositionX += gridPitch;
			}

			while (linePositionY < canvas.Size.Width) {
				grid.Add(new MyLine(new Point(0, linePositionY), new Point(canvas.Size.Width, linePositionY), 1, color, Color.White, false));
				linePositionY += gridPitch;
			}

			canvas.SetGrid(grid);

			int nodeLocationX = 0;
			int nodeLocationY = 0;

			List<Point> nodes = new List<Point>();

			while (nodeLocationY <= canvas.Size.Height) {
				while (nodeLocationX <= canvas.Size.Width) {
					nodes.Add(new Point(nodeLocationX, nodeLocationY));
					nodeLocationX += gridPitch;
				}
				nodes.Add(new Point(canvas.Size.Width, nodeLocationY));
				nodeLocationX = 0;
				nodeLocationY += gridPitch;
			}
			while (nodeLocationX <= canvas.Size.Width) {
				nodes.Add(new Point(nodeLocationX, canvas.Size.Height));
				nodeLocationX += gridPitch;
			}
			nodes.Add(new Point(canvas.Width, canvas.Height));

			canvas.SetGridNodes(nodes);
		}
	}
}
