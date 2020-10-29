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
	public partial class NewWindowParametersDialog : Form {
		public NewWindowParametersDialog() {
			InitializeComponent();
		}

		public int width, height;

		private void RB320x240_CheckedChanged(object sender, EventArgs e) {
			width = 320;
			height = 240;
			if (RB320x240.Checked) buttonOK.Enabled = true;
		}

		private void RB640x480_CheckedChanged(object sender, EventArgs e) {
			width = 640;
			height = 480;
			if (RB640x480.Checked) buttonOK.Enabled = true;
		}

		private void RB800x600_CheckedChanged(object sender, EventArgs e) {
			width = 800;
			height = 600;
			if (RB800x600.Checked) buttonOK.Enabled = true;
		}

		private void checkBoxUserSize_CheckedChanged(object sender, EventArgs e) {
			if (checkBoxUserSize.Checked) {
				RB320x240.Checked = false;
				RB640x480.Checked = false;
				RB800x600.Checked = false;
				textBoxHeight.Enabled = true;
				textBoxWidth.Enabled = true;
				buttonOK.Enabled = false;
			}
			else {
				textBoxWidth.Clear();
				textBoxHeight.Clear();
				textBoxHeight.Enabled = false;
				textBoxWidth.Enabled = false;
				RB320x240.Checked = true;
			}
		}

		private void textBoxWidth_TextChanged(object sender, EventArgs e) {
			if (textBoxWidth.Text != "" && textBoxHeight.Text != "") {
				buttonOK.Enabled = true;
			}
			else buttonOK.Enabled = false;
		}

		private void textBoxWidth_KeyPress(object sender, KeyPressEventArgs e) {
			if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8) {
				e.Handled = true;
			}
		}

		private void textBoxHeight_TextChanged(object sender, EventArgs e) {
			if (textBoxWidth.Text != "" && textBoxHeight.Text != "") {
				buttonOK.Enabled = true;
			}
			else buttonOK.Enabled = false;
		}

		private void textBoxHeight_KeyPress(object sender, KeyPressEventArgs e) {
			if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8) {
				e.Handled = true;
			}
		}

		private void buttonOK_Click(object sender, EventArgs e) {
			if (checkBoxUserSize.Checked) {
				width = Convert.ToInt32(textBoxWidth.Text);
				height = Convert.ToInt32(textBoxHeight.Text);
			}
		}

		private void NewWindowParameters_Shown(object sender, EventArgs e) {
			RB320x240.Checked = true;
		}
	}
}
