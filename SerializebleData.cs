using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpaint_2077 {

	[Serializable]

	public class SerializebleData {

		public SerializebleData(Size canvasSize, string name, bool childFormChanged, List<AbstractFigure> listOfFigures) {
			this.canvasSize = canvasSize;
			this.name = name;
			this.childFormChanged = childFormChanged;
			this.listOfFigures = listOfFigures;
		}

		public SerializebleData() {
		}

		//

		Size canvasSize;

		public void SetCanvasSize(Size size) {
			canvasSize = size;
		}

		public Size GetCanvasSize() {
			return canvasSize;
		}

		//

		string name = string.Empty;

		public void SetName(string name) {
			this.name = name;
		}

		public string GetName() {
			return name;
		}

		//

		bool childFormChanged;

		public void SetFormChangedState(bool isChanged) {
			childFormChanged = isChanged;
		}

		public bool GetFormChangedState() {
			return childFormChanged;
		}

		//

		List<AbstractFigure> listOfFigures;

		public List<AbstractFigure> GetFigures() {
			return listOfFigures;
		}

		public AbstractFigure GetFigure(int index) {
			return listOfFigures[index];
		}

		public void SetFigures(List<AbstractFigure> figures) {
			listOfFigures = figures;
		}

		public void AddFigure(AbstractFigure figure) {
			listOfFigures.Add(figure);
		}

		public void RemoveFigure(int index) {
			listOfFigures.RemoveAt(index);
		}

		public void RemoveFigure(AbstractFigure figure) {
			listOfFigures.Remove(figure);
		}

		//

		List<AbstractFigure> listOfPickedFigures = new List<AbstractFigure>();

		public List<AbstractFigure> GetPickedFigures() {
			return listOfPickedFigures;
		}

		public void SetPickedFigures(List<AbstractFigure> figures) {
			listOfPickedFigures = figures;
		}

		public void AddPickedFigure(AbstractFigure figure) {
			listOfPickedFigures.Add(figure);
		}

		public void AddPickedFigures(List<AbstractFigure> figures) {
			foreach (AbstractFigure f in figures) {
				listOfPickedFigures.Add(f);
			}
		}

		public void RemovePickedFigure(int index) {
			listOfPickedFigures.RemoveAt(index);
		}

		//

		public void RestoreFigures() {
			foreach(AbstractFigure figure in listOfPickedFigures) {
				listOfFigures.Add(figure);
			}
			listOfPickedFigures.Clear();
		}

		public void DeletePickedFigures() {
			listOfPickedFigures.Clear();
		}

		//

		Size childFormSize;

		public void SetChildFormSize(Size size) {
			childFormSize = size;
		}

		public Size GetChildFormSize() {
			return childFormSize;
		}
	}
}
