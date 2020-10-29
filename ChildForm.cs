using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cyberpaint_2077 {
	
	public partial class ChildForm : Form {
		public ChildForm() {
			InitializeComponent();
		}

		Canvas canvas = new Canvas();

		public Canvas GetCanvas() {
			return canvas;
		}

		public void SetCanvas(Canvas canvas) {
			this.canvas = canvas;
			Controls.Clear();
			Controls.Add(canvas);
		}

		public SerializebleData GetSerializebleData() {
			return canvas.GetSerializebleData();
		}

		public void SetSerializebleData(SerializebleData data) {
			canvas.SetSerializebleData(data);
		}

		public void CreateSerializebleData() {
			canvas.CreateSerializebleData();
		}

		public void SetCanvasSize(Size size) {
			canvas.SetCanvasSize(size);
		}

		public Size GetCanvasSize() {
			return canvas.GetCanvasSize();
		}

		public void SetName(string name) {
			canvas.SetName(name);
		}

		public string GetName() {
			return canvas.GetName();
		}

		public void SetFormChangedState(bool isChanged) {
			canvas.SetFormChangedState(isChanged);
		}

		public bool GetFormChangedState() {
			return canvas.GetFormChangedState();
		}

		public void SetFigures(List<AbstractFigure> figures) {
			canvas.SetFigures(figures);
		}

		public List<AbstractFigure> GetFigures() {
			return canvas.GetFigures();
		}

		public void RestoreFigures() {
			canvas.RestoreFigures();
		}

		public List<AbstractFigure> GetPickedFigures() {
			return canvas.GetPickedFigures();
		}

		public void PickAllFigures() {
			SomeMethodsForCanvas.PickAllFigures(canvas);
		}

		public void SetChildFormSize(Size size) {
			canvas.SetChildFormSize(size);
		}

		public Size GetChildFormSize() {
			return canvas.GetChildFormSize();
		}

		private void ChildForm_FormClosing(object sender, FormClosingEventArgs e) {
			if (GetFormChangedState()) {

				string name = GetName();
				if (name == string.Empty) name = Text;

				DialogResult dialogResult = MessageBox.Show("Сохранить изменения\"" + name + "\"?", "Файл изменен", MessageBoxButtons.YesNoCancel);
				switch (dialogResult) {
					case DialogResult.Cancel:
						e.Cancel = true;
						return;
					case DialogResult.Yes:
						SomeMethodsForMainForm.SaveFile(this);
						break;
					default:
						break;
				}
			}
		}

		private void ChildForm_MouseUp(object sender, MouseEventArgs e) {
			
		}
	}
}
