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
	public partial class MainForm : Form {
		public MainForm() {
			InitializeComponent();
			SomeMethodsForMainForm.SetMainForm(this);
			ComboBoxInit();
			StatusBarRefresh();
			CheckEditMenu();
			CheckSaveButtonsStatus();
		}

		ChildForm activeChild;

		//	ToolStrip Menu START
		private void FileToolStripMenuItem_Click(object sender, EventArgs e) {
			CheckSaveButtonsStatus();
		}

		private void FileCreateToolStripMenuItem_Click(object sender, EventArgs e) {
			SomeMethodsForMainForm.AddEmptyChildForm(this);
		}

		private void FileOpenToolStripMenuItem_Click(object sender, EventArgs e) {
			SomeMethodsForMainForm.OpenFile(this);
		}

		private void FileSaveToolStripMenuItem_Click(object sender, EventArgs e) {
			SomeMethodsForMainForm.SaveFile((ChildForm)ActiveMdiChild);
		}

		private void FileSaveAsToolStripMenuItem_Click(object sender, EventArgs e) {
			SomeMethodsForMainForm.SaveFile((ChildForm)ActiveMdiChild);
		}

		//

		private void WindowToolStripMenuItem_Click(object sender, EventArgs e) {

		}

		//

		private void ParametersToolStripMenuItem_Click(object sender, EventArgs e) {

		}

		private void ParametersPenSizeToolStripMenuItem_Click(object sender, EventArgs e) {
			SomeMethodsForMainForm.ChangePenSizeDialog();
			StatusBarRefresh();
		}

		private void ParametersPenColorToolStripMenuItem_Click(object sender, EventArgs e) {
			SomeMethodsForMainForm.ChangeColorLine(this);
			StatusBarRefresh();
		}

		private void ParametersBGColorToolStripMenuItem_Click(object sender, EventArgs e) {
			SomeMethodsForMainForm.ChangeColorBackground(this);
			StatusBarRefresh();
		}

		private void ParametersFillToolStripMenuItem_Click(object sender, EventArgs e) {
			SomeMethodsForMainForm.ChangeFillFlag(this);
		}

		//

		private void FiguresToolStripMenuItem_Click(object sender, EventArgs e) {

		}

		private void FiguresLineToolStripMenuItem_Click(object sender, EventArgs e) {
			SomeMethodsForMainForm.ChangeFigureType(this, FiguresLineToolStripMenuItem);
			DrawParameters.SetFigureType("Line");
		}

		private void FiguresCurveToolStripMenuItem_Click(object sender, EventArgs e) {
			SomeMethodsForMainForm.ChangeFigureType(this, FiguresCurveToolStripMenuItem);
			DrawParameters.SetFigureType("Curve");
		}

		private void FiguresRectangleToolStripMenuItem_Click(object sender, EventArgs e) {
			SomeMethodsForMainForm.ChangeFigureType(this, FiguresRectangleToolStripMenuItem);
			DrawParameters.SetFigureType("Rectangle");
		}

		private void FiguresEllipseToolStripMenuItem_Click(object sender, EventArgs e) {
			SomeMethodsForMainForm.ChangeFigureType(this, FiguresEllipseToolStripMenuItem);
			DrawParameters.SetFigureType("Ellipse");
		}

		//

		private void EditToolStripMenuItem_Click(object sender, EventArgs e) {
			CheckEditMenu();
		}

		private void EditCopyToolStripMenuItem_Click(object sender, EventArgs e) {
			if (activeChild != null) SomeMethodsForCanvas.CopyAreaToClipboard(activeChild.GetCanvas());
		}

		private void EditCopyToMetafileToolStripMenuItem_Click(object sender, EventArgs e) {
			if (activeChild != null) SomeMethodsForCanvas.CopyAreaToMetafile(activeChild.GetCanvas());
		}

		private void EditCutToolStripMenuItem_Click(object sender, EventArgs e) {
			if (activeChild != null) {
				SomeMethodsForCanvas.CopyAreaToClipboard(activeChild.GetCanvas());
				activeChild.GetCanvas().DeletePickedFigures();
			}
		}

		private void EditPasteToolStripMenuItem_Click(object sender, EventArgs e) {
			if (activeChild != null) {
				if (!DrawParameters.GetObjectSelectionFlag()) buttonSelection_Click(sender, e);
				SomeMethodsForCanvas.PasteAreaFromClipboard(activeChild.GetCanvas());
			}
		}

		private void EditSelectAllToolStripMenuItem_Click(object sender, EventArgs e) {
			if (activeChild != null) {
				if (!DrawParameters.GetObjectSelectionFlag()) buttonSelection_Click(sender, e);
				activeChild.PickAllFigures();
			}
		}
		//	ToolStrip Menu END


		//	Menu START

		//	File Menu START
		private void buttonCreate_Click(object sender, EventArgs e) {
			SomeMethodsForMainForm.AddEmptyChildForm(this, SomeMethodsForMainForm.GetNewFormSize(RB320x240, RB640x480, RB800x600));
			RB320x240.Checked = false;
			RB640x480.Checked = false;
			RB800x600.Checked = false;
			buttonCreate.Enabled = false;
		}

		private void buttonOpen_Click(object sender, EventArgs e) {
			SomeMethodsForMainForm.OpenFile(this);
		}

		private void buttonSave_Click(object sender, EventArgs e) {
			SomeMethodsForMainForm.SaveFile(activeChild);
			buttonSave.Enabled = false;
		}

		private void buttonSaveAs_Click(object sender, EventArgs e) {
			SomeMethodsForMainForm.SaveFile(activeChild);
		}

		private void RB320x240_CheckedChanged(object sender, EventArgs e) {
			if (RB320x240.Checked || RB640x480.Checked || RB640x480.Checked) DisableUserSize();
			RadioButtonsStateChanged();
		}

		private void RB640x480_CheckedChanged(object sender, EventArgs e) {
			if (RB320x240.Checked || RB640x480.Checked || RB640x480.Checked) DisableUserSize();
			RadioButtonsStateChanged();
		}

		private void RB800x600_CheckedChanged(object sender, EventArgs e) {
			if (RB320x240.Checked || RB640x480.Checked || RB640x480.Checked) DisableUserSize();
			RadioButtonsStateChanged();
		}

		private void checkBoxUserSize_CheckedChanged(object sender, EventArgs e) {
			if (checkBoxUserSize.Checked) {
				if (textBoxWidth.Text != "" && textBoxHeight.Text != "") buttonCreate.Enabled = true;
				else buttonCreate.Enabled = false;
				UncheckRadioButtons();
				textBoxWidth.Enabled = true;
				textBoxHeight.Enabled = true;
			}
			else {
				textBoxWidth.Clear();
				textBoxHeight.Clear();
				textBoxWidth.Enabled = false;
				textBoxHeight.Enabled = false;
			}
		}

		private void textBoxWidth_TextChanged(object sender, EventArgs e) {
			if (textBoxWidth.Text != "" && textBoxHeight.Text != "") buttonCreate.Enabled = true;
			else buttonCreate.Enabled = false;
		}

		private void textBoxWidth_KeyPress(object sender, KeyPressEventArgs e) {
			if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8) {
				e.Handled = true;
			}
		}

		private void textBoxHeight_TextChanged(object sender, EventArgs e) {
			if (textBoxWidth.Text != "" && textBoxHeight.Text != "") buttonCreate.Enabled = true;
			else buttonCreate.Enabled = false;
		}

		private void textBoxHeight_KeyPress(object sender, KeyPressEventArgs e) {
			if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8) {
				e.Handled = true;
			}
		}
		//	File Menu END

		//	Parameters Menu START
		private void labelPenColor_Click(object sender, EventArgs e) {
			SomeMethodsForMainForm.ChangeColorLine(this);
		}

		private void labelBGColor_Click(object sender, EventArgs e) {
			SomeMethodsForMainForm.ChangeColorBackground(this);
		}

		private void checkBoxBGFill_CheckedChanged(object sender, EventArgs e) {
			
		}

		private void checkBoxBGFill_Click(object sender, EventArgs e) {
			SomeMethodsForMainForm.ChangeFillFlag(this);
		}

		private void comboBoxPenSize_SelectedIndexChanged(object sender, EventArgs e) {
			SomeMethodsForMainForm.ChangePenSize(Convert.ToInt32(comboBoxPenSize.SelectedItem), comboBoxPenSize.SelectedIndex);
			StatusBarRefresh();
			CheckEditMenu();
		}
		//	Parameters Menu END

		//	Figures Menu START
		private void RBLine_CheckedChanged(object sender, EventArgs e) {
			FiguresLineToolStripMenuItem_Click(sender, e);
		}

		private void RBCurve_CheckedChanged(object sender, EventArgs e) {
			FiguresCurveToolStripMenuItem_Click(sender, e);
		}

		private void RBRectangle_CheckedChanged(object sender, EventArgs e) {
			FiguresRectangleToolStripMenuItem_Click(sender, e);
		}

		private void RBEllipse_CheckedChanged(object sender, EventArgs e) {
			FiguresEllipseToolStripMenuItem_Click(sender, e);
		}

		private void RBText_CheckedChanged(object sender, EventArgs e) {
			if (RBText.Checked) DrawParameters.SetFigureType("Text");
			SomeMethodsForMainForm.ChangeFigureType(this, new ToolStripMenuItem());
		}

		private void buttonFont_Click(object sender, EventArgs e) {
			SomeMethodsForMainForm.ChangeFont();
		}

		private void buttonSelection_Click(object sender, EventArgs e) {
			SomeMethodsForMainForm.SelectionButtonClick(buttonSelection);
			if (activeChild != null) {
				activeChild.RestoreFigures();
				activeChild.GetCanvas().Refresh();
			}
		}
		//	Figures Menu END

		private void MainForm_MdiChildActivate(object sender, EventArgs e) {
			activeChild = (ChildForm)ActiveMdiChild;
			if (activeChild != null) SBCanvasSize.Text = activeChild.GetCanvasSize().Width.ToString() + " ; " + activeChild.GetCanvasSize().Height.ToString();
			CheckSaveButtonsStatus();
			RefreshGrids();
		}

		private void ComboBoxInit() {
			int[] arr = new int[] { 1, 2, 5, 8, 10, 12, 15 };
			for (int i = 0; i < arr.Length; i++) {
				comboBoxPenSize.Items.Add(arr[i]);
			}
			comboBoxPenSize.SelectedIndex = 0;
			comboBoxPenSize.DropDownStyle = ComboBoxStyle.DropDownList;
		}

		private void UncheckRadioButtons() {
			RB320x240.Checked = false;
			RB640x480.Checked = false;
			RB800x600.Checked = false;
		}

		private void RadioButtonsStateChanged() {
			if (RB320x240.Checked || RB640x480.Checked || RB800x600.Checked) {
				buttonCreate.Enabled = true;
				checkBoxUserSize.Checked = false;
			}
		}

		private void DisableUserSize() {
			textBoxWidth.Clear();
			textBoxHeight.Clear();
			textBoxWidth.Enabled = false;
			textBoxHeight.Enabled = false;
			checkBoxUserSize.Checked = false;
		}

		public void CheckSaveButtonsStatus() {
			if (activeChild != null) {
				if (activeChild.GetFormChangedState()) {
					FileSaveToolStripMenuItem.Enabled = true;
					FileSaveAsToolStripMenuItem.Enabled = true;
					buttonSave.Enabled = true;
					buttonSaveAs.Enabled = true;
				}
				else if (!activeChild.GetFormChangedState()) {
					FileSaveToolStripMenuItem.Enabled = false;
					FileSaveAsToolStripMenuItem.Enabled = false;
					buttonSave.Enabled = false;
					buttonSaveAs.Enabled = false;
				}
				else if (activeChild.GetName() != string.Empty) {
					FileSaveAsToolStripMenuItem.Enabled = true;
					buttonSaveAs.Enabled = true;
				}
			}
			else {
				FileSaveToolStripMenuItem.Enabled = false;
				FileSaveAsToolStripMenuItem.Enabled = false;
				buttonSave.Enabled = false;
				buttonSaveAs.Enabled = false;
			}
		}

		public void RefreshStatusBarCursorPosition(string position) {
			SBCursorPosition.Text = position;
		}

		public void StatusBarRefresh() {
			SBPenSize.Text = Convert.ToInt32(comboBoxPenSize.SelectedItem).ToString();
			SBPenColor.BackColor = DrawParameters.GetColorLine();
			labelPenColor.BackColor = DrawParameters.GetColorLine();
			SBBGColor.BackColor = DrawParameters.GetColorBackground();
			labelBGColor.BackColor = DrawParameters.GetColorBackground();
			SBFontSize.Text = DrawParameters.GetFont().Size.ToString();
			SBFont.Text = DrawParameters.GetFont().Name;

			comboBoxPenSize.SelectedIndex = DrawParameters.GetPenIndex();
		}

		void CheckEditMenu() {
			if (activeChild != null) {
				if (activeChild.GetPickedFigures().Count() > 0) {
					EditCopyToolStripMenuItem.Enabled = true;
					EditCopyToMetafileToolStripMenuItem.Enabled = true;
					EditCutToolStripMenuItem.Enabled = true;
				}
				else {
					EditCopyToolStripMenuItem.Enabled = false;
					EditCopyToMetafileToolStripMenuItem.Enabled = false;
					EditCutToolStripMenuItem.Enabled = false;
				}

				if (Clipboard.GetDataObject().GetDataPresent("Cyberpaint2077Format")) EditPasteToolStripMenuItem.Enabled = true;
				else EditPasteToolStripMenuItem.Enabled = false;

				if (activeChild.GetFigures().Count() > 0) EditSelectAllToolStripMenuItem.Enabled = true;
				else EditSelectAllToolStripMenuItem.Enabled = false;
			}
			else {
				EditCopyToolStripMenuItem.Enabled = false;
				EditCopyToMetafileToolStripMenuItem.Enabled = false;
				EditCutToolStripMenuItem.Enabled = false;
				EditPasteToolStripMenuItem.Enabled = false;
				EditSelectAllToolStripMenuItem.Enabled = false;
			}
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e) {
			DrawParameters.SetShowGrid(checkBoxGrid.Checked);
			foreach (ChildForm childForm in MdiChildren) {
				childForm.GetCanvas().Refresh();
			}
		}

		private void AlignToGridToolStripMenuItem_Click(object sender, EventArgs e) {
			SomeMethodsForCanvas.AlignGrid(activeChild.GetCanvas());
		}

		private void checkBoxGridBinding_CheckedChanged(object sender, EventArgs e) {
			DrawParameters.SetGridBinding(checkBoxGridBinding.Checked);
		}

		int gridPitch = 10;

		private void SlotPitch_KeyPress(object sender, KeyPressEventArgs e) {
			if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8) {
				e.Handled = true;
			}
		}

		private void SlotPitch_TextChanged(object sender, EventArgs e) {
			if (SlotPitch.Text != "") gridPitch = Convert.ToInt32(SlotPitch.Text);
			RefreshGrids();
		}

		private void RefreshGrids() {
			foreach (ChildForm childForm in MdiChildren) {
				SomeMethodsForMainForm.CreateGrid(gridPitch, childForm.GetCanvas());
				childForm.GetCanvas().Refresh();
			}
		}
	}
}
