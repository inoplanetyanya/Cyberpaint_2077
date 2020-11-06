using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpaint_2077 {
	public static class DrawParameters {

		static int brushSize = 1;
		static int penIndex = 0;
		static bool fillFlag = true, objectSelectionFlag = false;
		static string figureType = "Line";
		static Color colorLine = Color.Black, colorBackGround = Color.White;
		static Font font = new Font(new FontFamily("Times New Roman"), 8, FontStyle.Regular, GraphicsUnit.Point);
		static bool showGrid = false;

		static bool gridBinding = false;
		static int gridPitch = 10;

		static bool pickedSingleFigure = false;
		static AbstractFigure singleFigure;

		public static AbstractFigure GetSingleFigure() {
			return singleFigure;
		}

		public static void SetPickedSingleFigure(bool state, AbstractFigure figure) {
			pickedSingleFigure = state;
			singleFigure = figure;
			SomeMethodsForMainForm.GetMainForm().StatusBarRefresh();
		}

		public static bool GetPickedSingleFigureState() {
			return pickedSingleFigure;
		}

		public static void SetGridBinding(bool binding) {
			gridBinding = binding;
		}

		public static bool GetGridBinging() {
			return gridBinding;
		}

		public static void SetGridPitch(int pitch) {
			gridPitch = pitch;
		}

		public static int GetGridPitch() {
			return gridPitch;
		}

		public static bool GetShowGrid() {
			return showGrid;
		}

		public static void SetShowGrid(bool state) {
			showGrid = state;
		}

		public static int GetBrushSize() {
			return pickedSingleFigure ? singleFigure.GetBrushSize() : brushSize;
		}

		public static void SetBrushSize(int size) {
			if (pickedSingleFigure) singleFigure.SetBrushSize(size);
			else brushSize = size;
		}

		public static int GetPenIndex() {
			return penIndex;
		}

		public static void SetPenIndex(int index) {
			penIndex = index;
		}

		public static bool GetFillFlag() {
			return pickedSingleFigure ? singleFigure.GetFillFlag() : fillFlag;
		}

		public static void SetFillFlag(bool state) {
			if (pickedSingleFigure) singleFigure.SetFillFlag(state);
			else fillFlag = state;
		}

		public static bool GetObjectSelectionFlag() {
			return objectSelectionFlag;
		}

		public static void SetObjectSelectionFlag(bool state) {
			objectSelectionFlag = state;
		}

		public static Color GetColorLine() {
			return pickedSingleFigure ? singleFigure.GetColorLine() : colorLine;
		}

		public static void SetColorLine(Color color) {
			if (pickedSingleFigure) singleFigure.SetColorLine(color);
			else colorLine = color;
		}

		public static Color GetColorBackground() {
			return pickedSingleFigure ? singleFigure.GetColorBackground() : colorBackGround;
		}

		public static void SetColorBackground(Color color) {
			if (pickedSingleFigure) singleFigure.SetColorBackground(color);
			else colorBackGround = color;
		}

		public static Font GetFont() {
			return pickedSingleFigure ? singleFigure.GetFont() : font;
		}

		public static void SetFont(Font newFont) {
			if (pickedSingleFigure) singleFigure.SetFont(newFont);
			else font = newFont;
		}

		public static void SetFigureType(string type) {
			figureType = type;
		}

		public static string GetFigureType() {
			return figureType;
		}
	}
}
