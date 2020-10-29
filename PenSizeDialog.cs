using System;
using System.Windows.Forms;

namespace Cyberpaint_2077 {
	public partial class PenSizeDialog : Form {
		int size, index;
		public PenSizeDialog() {
			InitializeComponent();
			comboBox1.SelectedIndex = DrawParameters.GetPenIndex();
		}

		private void button1_Click(object sender, EventArgs e) {
			//???
		}

		private void PenParam_Load(object sender, EventArgs e) {
			int[] arr = new int[] { 1, 2, 5, 8, 10, 12, 15 };
			for (int i = 0; i < arr.Length; i++) {
				comboBox1.Items.Add(arr[i]);
			}
		}

		public int GetSize() {
			return size;
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
			
		}

		private void button1_Click_1(object sender, EventArgs e) {
			size = Convert.ToInt32(comboBox1.SelectedItem);
			index = comboBox1.SelectedIndex;
		}

		public int GetIndex() {
			return index;
		}
	}
}
