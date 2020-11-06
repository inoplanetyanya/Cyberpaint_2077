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
	public partial class EditDialog : Form {

		SerializebleData inputData;
		SerializebleData outputData;

		Canvas inputCanvas;
		Canvas outputCanvas;

		ChildForm activeChild;

		public EditDialog(Canvas canvas, ref ChildForm childForm) {
			InitializeComponent();

			activeChild = childForm;

			inputCanvas = canvas;
			inputData = inputCanvas.GetSerializebleData();

			List<AbstractFigure> figures = new List<AbstractFigure>();
			foreach(AbstractFigure f in inputData.GetFigures()) {
				figures.Add(f.GetCopy(f));
			}

			outputData = new SerializebleData(inputData.GetCanvasSize(), inputData.GetName(), inputData.GetFormChangedState(), figures);
			outputCanvas = new Canvas(outputData);

			activeChild.SetCanvas(outputCanvas);

			RefreshTabel(outputData);
			RefreshEditGroupBox();
		}

		void RefreshTabel(SerializebleData data) {
			LVTable.Items.Clear();
			int j = 0;
			foreach (AbstractFigure figure in data.GetFigures()) {
				ListViewItem item = new ListViewItem(j.ToString());
				AddSubItems(figure, item);
				LVTable.Items.Add(item);
				j++;
			}
		}

		void AddSubItems(AbstractFigure figure, ListViewItem item) {
			if (figure is MyLine) {
				item.SubItems.Add("Прямая");    // Тип
				item.SubItems.Add(figure.GetFigureBox().X.ToString() + " ; " + figure.GetFigureBox().Y.ToString());    // Позиция
				item.SubItems.Add(figure.GetBrushSize().ToString());    // Размер пера
				Color color = figure.GetColorLine();
				item.SubItems.Add(color.A + " " + color.R + " " + color.G + " " + color.B); //	Цвет пера
				item.SubItems.Add("");  //	Цвет заливки
				item.SubItems.Add("");  //	Флаг заливки
				item.SubItems.Add("");  //	Размер шрифта
				item.SubItems.Add("");  //	Шрифт
			}
			else if (figure is MyCurve) {
				item.SubItems.Add("Кривая");    // Тип
				item.SubItems.Add(figure.GetFigureBox().X.ToString() + " ; " + figure.GetFigureBox().Y.ToString());   // Позиция
				item.SubItems.Add(figure.GetBrushSize().ToString());    // Размер пера
				Color color = figure.GetColorLine();
				item.SubItems.Add(color.A + " " + color.R + " " + color.G + " " + color.B); //	Цвет пера
				item.SubItems.Add("");  //	Цвет заливки
				item.SubItems.Add("");  //	Флаг заливки
				item.SubItems.Add("");  //	Размер шрифта
				item.SubItems.Add("");  //	Шрифт
			}
			else if (figure is MyEllipse) {
				item.SubItems.Add("Эллипс");    // Тип
				item.SubItems.Add(figure.GetFigureBox().X.ToString() + " ; " + figure.GetFigureBox().Y.ToString());    // Позиция
				item.SubItems.Add(figure.GetBrushSize().ToString());    // Размер пера
				Color color = figure.GetColorLine();
				item.SubItems.Add(color.A + " " + color.R + " " + color.G + " " + color.B); //	Цвет пера
				color = figure.GetColorBackground();
				item.SubItems.Add(color.A + " " + color.R + " " + color.G + " " + color.B);  //	Цвет заливки
				if (figure.GetFillFlag()) item.SubItems.Add("Да");  //	Флаг заливки
				else item.SubItems.Add("Нет");
				item.SubItems.Add("");  //	Размер шрифта
				item.SubItems.Add("");  //	Шрифт
			}
			else if (figure is MyRectangle) {
				item.SubItems.Add("Прямоугольник");    // Тип
				item.SubItems.Add(figure.GetFigureBox().X.ToString() + " ; " + figure.GetFigureBox().Y.ToString());    // Позиция
				item.SubItems.Add(figure.GetBrushSize().ToString());    // Размер пера
				Color color = figure.GetColorLine();
				item.SubItems.Add(color.A + " " + color.R + " " + color.G + " " + color.B); //	Цвет пера
				color = figure.GetColorBackground();
				item.SubItems.Add(color.A + " " + color.R + " " + color.G + " " + color.B);  //	Цвет заливки
				if (figure.GetFillFlag()) item.SubItems.Add("Да");  //	Флаг заливки
				else item.SubItems.Add("Нет");
				item.SubItems.Add("");  //	Размер шрифта
				item.SubItems.Add("");  //	Шрифт
			}
			else if (figure is MyText) {
				item.SubItems.Add("Текст");    // Тип
				item.SubItems.Add(figure.GetFigureBox().X.ToString() + " ; " + figure.GetFigureBox().Y.ToString());    // Позиция
				item.SubItems.Add(figure.GetBrushSize().ToString());    // Размер пера
				Color color = figure.GetColorLine();
				item.SubItems.Add(color.A + " " + color.R + " " + color.G + " " + color.B); //	Цвет пера
				color = figure.GetColorBackground();
				item.SubItems.Add(color.A + " " + color.R + " " + color.G + " " + color.B);  //	Цвет заливки
				if (figure.GetFillFlag()) item.SubItems.Add("Да");  //	Флаг заливки
				else item.SubItems.Add("Нет");
				item.SubItems.Add(figure.GetFont().Size.ToString());  // Размер шрифта
				item.SubItems.Add(figure.GetFont().FontFamily.Name + " " + figure.GetFont().Style);  // Шрифт
			}
		}

		AbstractFigure activeFigure;
		int activeIndex = -1;

		private void LVTable_SelectedIndexChanged(object sender, EventArgs e) {
			ListView.SelectedIndexCollection index = LVTable.SelectedIndices;
			if (index.Count > 0) {
				activeIndex = LVTable.SelectedIndices[0];
				activeFigure = outputData.GetFigure(activeIndex);

				AbstractFigure tmp = outputData.GetFigure(activeIndex);
				outputData.DeletePickedFigures();
				outputData.AddPickedFigure(tmp);

				outputCanvas.Refresh();
			}
			RefreshEditGroupBox();
			BDelete.Enabled = true;
		}

		void ToggleControlsEnabled(Control[] controls, bool enabled) {
			foreach (Button button in controls.Where(a => a is Button)) {
				button.Enabled = enabled;
			}

			foreach (Label label in controls.Where(a => a is Label)) {
				label.Visible = enabled;
			}

			foreach (CheckBox checkBox in controls.Where(a => a is CheckBox)) {
				checkBox.Visible = enabled;
			}
		}

		void RefreshEditGroupBox() {
			Control[] controls = {
				BPenSize,
				LPenSize,
				BColorLine,
				LPenColor,
				BColorBG,
				LColorBG,
				CBFill,
				BFont,
				LFont,
				BTextEdit,
				BSaveText,
				BCancel,
				BPosition,
				LPosition,
				BSize,
				LSize,
				BPoints
			};

			ToggleControlsEnabled(controls, false);

			if (activeFigure != null) {
				LPenSize.Text = activeFigure.GetBrushSize().ToString();
				LPenColor.BackColor = activeFigure.GetColorLine();
				LPosition.Text = activeFigure.GetFigureBox().X.ToString() + " ; " + activeFigure.GetFigureBox().Y.ToString();
				LSize.Text = activeFigure.GetFigureBox().Width.ToString() + " x " + activeFigure.GetFigureBox().Height.ToString();
				ToggleControlsEnabled(new Control[] { BPenSize, LPenSize, BColorLine, LPenColor, BPosition, LPosition, BSize, LSize }, true);
				GBText.Visible = false;
				if (activeFigure is MyRectangle || activeFigure is MyEllipse) {
					ToggleControlsEnabled(new Control[] { BColorBG, LColorBG, CBFill }, true);
					LColorBG.BackColor = activeFigure.GetColorBackground();
					CBFill.Checked = activeFigure.GetFillFlag();
					RefreshBottomButtons();
					return;
				}
				else if (activeFigure is MyLine || activeFigure is MyCurve) {
					ToggleControlsEnabled(new Control[] { BPoints }, true);
					RefreshBottomButtons();
					return;
				}
				else if (activeFigure is MyText) {
					ToggleControlsEnabled(new Control[] { BColorBG, LColorBG, BFont, LFont, BTextEdit }, true);
					LColorBG.BackColor = activeFigure.GetColorBackground();
					CBFill.Checked = activeFigure.GetFillFlag();
					Font font = activeFigure.GetFont();
					LFont.Text = font.Size.ToString() + " " + font.Name + " " + font.Style.ToString();
					TBEditText.Text = activeFigure.GetText();
					TBEditText.BackColor = activeFigure.GetColorBackground();
					TBEditText.Font = activeFigure.GetFont();
					TBEditText.ForeColor = activeFigure.GetColorLine();
					GBText.Visible = true;
					RefreshBottomButtons();
				}
			}
		}

		void RefreshBottomButtons() {
			if (activeIndex < LVTable.Items.Count - 1) {
				BDown.Enabled = true;
				ToEnd.Enabled = true;
			}
			else {
				BDown.Enabled = false;
				ToEnd.Enabled = false;
			}

			if (activeIndex > 0) {
				BUP.Enabled = true;
				BToBegin.Enabled = true;
			}
			else {
				BUP.Enabled = false;
				BToBegin.Enabled = false;
			}

			if (activeIndex <= LVTable.Items.Count - 1 && LVTable.Items.Count > 0 && activeIndex > -1) {
				BDelete.Enabled = true;
				for (int i = 0; i < LVTable.Items.Count; i++) {
					LVTable.Items[i].BackColor = SystemColors.Window;
				}
				LVTable.Items[activeIndex].BackColor = SystemColors.Highlight;
			}
			else {
				BDelete.Enabled = false;
				for (int i = 0; i < LVTable.Items.Count; i++) {
					LVTable.Items[i].BackColor = SystemColors.Window;
				}
			}
		}

		private void BTextEdit_Click(object sender, EventArgs e) {
			TBEditText.Enabled = true;
			TBEditText.Focus();
			BSaveText.Enabled = true;
			BSaveText.Visible = true;
			BCancel.Enabled = true;
			BCancel.Visible = true;
		}

		private void BSaveText_Click(object sender, EventArgs e) {
			activeFigure.SetText(TBEditText.Text);
			BSaveText.Enabled = false;
			BSaveText.Visible = false;
			BCancel.Enabled = false;
			BCancel.Visible = false;
			TBEditText.Enabled = false;
		}

		private void BCancel_Click(object sender, EventArgs e) {
			BSaveText.Enabled = false;
			BSaveText.Visible = false;
			BCancel.Enabled = false;
			BCancel.Visible = false;
			TBEditText.Enabled = false;
			RefreshEditGroupBox();
		}

		private void BFont_Click(object sender, EventArgs e) {
			FontDialog dialog = new FontDialog();
			if (dialog.ShowDialog() == DialogResult.OK && activeFigure != null) activeFigure.SetFont(dialog.Font);
			RefreshTabel(outputData);
			RefreshEditGroupBox();
			outputCanvas.Refresh();
		}

		private void BColorBG_Click(object sender, EventArgs e) {
			ColorDialog dialog = new ColorDialog();
			if (dialog.ShowDialog() == DialogResult.OK && activeFigure != null) activeFigure.SetColorBackground(dialog.Color);
			RefreshTabel(outputData);
			RefreshEditGroupBox();
			outputCanvas.Refresh();
		}

		private void BColorLine_Click(object sender, EventArgs e) {
			ColorDialog dialog = new ColorDialog();
			if (dialog.ShowDialog() == DialogResult.OK && activeFigure != null) activeFigure.SetColorLine(dialog.Color);
			RefreshTabel(outputData);
			RefreshEditGroupBox();
			outputCanvas.Refresh();
		}

		private void BPenSize_Click(object sender, EventArgs e) {
			PenSizeDialog dialog = new PenSizeDialog();
			if (dialog.ShowDialog() == DialogResult.OK && activeFigure != null) activeFigure.SetBrushSize(dialog.GetSize());
			RefreshTabel(outputData);
			RefreshEditGroupBox();
			outputCanvas.Refresh();
		}

		private void CBFill_Click(object sender, EventArgs e) {
			activeFigure.SetFillFlag(CBFill.Checked);
			RefreshTabel(outputData);
		}

		private void BPoints_Click(object sender, EventArgs e) {
			EditPointsDialog dialog = new EditPointsDialog(activeFigure);
			//if (activeFigure is MyCurve) dialog = new EditPointsDialog(activeFigure as MyCurve);
			//else dialog = new EditPointsDialog(activeFigure);
			if (dialog.ShowDialog() == DialogResult.OK) activeFigure.SetPoints(dialog.GetPoints());
			RefreshTabel(outputData);
			RefreshEditGroupBox();
			outputCanvas.Refresh();
		}

		private void BPosition_Click(object sender, EventArgs e) {
			EditFigurePositionDialog dialog = new EditFigurePositionDialog(outputCanvas, activeFigure);
			dialog.ShowDialog();
			RefreshTabel(outputData);
			RefreshEditGroupBox();
			outputCanvas.Refresh();
		}

		private void BSize_Click(object sender, EventArgs e) {
			EditFigureSizeDialog dialog = new EditFigureSizeDialog(outputCanvas, activeFigure);
			dialog.ShowDialog();
			RefreshTabel(outputData);
			RefreshEditGroupBox();
			outputCanvas.Refresh();
		}

		private void BUP_Click(object sender, EventArgs e) {
			AbstractFigure tmp = outputData.GetFigure(activeIndex);
			outputData.RemoveFigure(activeIndex);
			outputData.GetFigures().Insert(activeIndex - 1, tmp);
			activeIndex--;
			RefreshTabel(outputData);
			RefreshEditGroupBox();
			for (int i = 0; i < LVTable.Items.Count; i++) {
				LVTable.Items[i].BackColor = SystemColors.Window;
			}
			LVTable.Items[activeIndex].BackColor = SystemColors.Highlight;
		}

		private void BDown_Click(object sender, EventArgs e) {
			AbstractFigure tmp = outputData.GetFigure(activeIndex);
			outputData.RemoveFigure(activeIndex);
			outputData.GetFigures().Insert(activeIndex + 1, tmp);
			activeIndex++;
			RefreshTabel(outputData);
			RefreshEditGroupBox();
			for (int i = 0; i < LVTable.Items.Count; i++) {
				LVTable.Items[i].BackColor = SystemColors.Window;
			}
			LVTable.Items[activeIndex].BackColor = SystemColors.Highlight;
		}

		private void BDelete_Click(object sender, EventArgs e) {
			outputData.RemoveFigure(activeIndex);
			activeIndex--;
			RefreshTabel(outputData);
			RefreshEditGroupBox();
			for (int i = 0; i < LVTable.Items.Count; i++) {
				LVTable.Items[i].BackColor = SystemColors.Window;
			}
			if (activeIndex > -1 && activeIndex < LVTable.Items.Count)
			LVTable.Items[activeIndex].BackColor = SystemColors.Highlight;
			outputCanvas.Refresh();
		}

		private void BAdd_Click(object sender, EventArgs e) {
			AddNewFigure dialog = new AddNewFigure(outputCanvas, outputData);
			dialog.ShowDialog();
			RefreshTabel(outputData);
			RefreshEditGroupBox();
			outputCanvas.Refresh();
		}

		private void ToEnd_Click(object sender, EventArgs e) {
			AbstractFigure tmp = outputData.GetFigure(activeIndex);
			outputData.RemoveFigure(activeIndex);
			outputData.GetFigures().Add(tmp);
			activeIndex = outputData.GetFigures().Count() - 1;
			RefreshTabel(outputData);
			RefreshEditGroupBox();
			for (int i = 0; i < LVTable.Items.Count; i++) {
				LVTable.Items[i].BackColor = SystemColors.Window;
			}
			LVTable.Items[activeIndex].BackColor = SystemColors.Highlight;
		}

		private void BToBegin_Click(object sender, EventArgs e) {
			AbstractFigure tmp = outputData.GetFigure(activeIndex);
			outputData.RemoveFigure(activeIndex);
			outputData.GetFigures().Insert(0, tmp);
			activeIndex = 0;
			RefreshTabel(outputData);
			RefreshEditGroupBox();
			for (int i = 0; i < LVTable.Items.Count; i++) {
				LVTable.Items[i].BackColor = SystemColors.Window;
			}
			LVTable.Items[activeIndex].BackColor = SystemColors.Highlight;
		}

		private void BOK_Click(object sender, EventArgs e) {
			
		}

		private void BSave_Click(object sender, EventArgs e) {
			inputCanvas = outputCanvas;
		}

		private void EditDialog_FormClosing(object sender, FormClosingEventArgs e) {
			activeChild.SetCanvas(inputCanvas);
			
			activeChild.RestoreFigures();
		}
	}
}
