/*
 * Creado por SharpDevelop.
 * Usuario: dagur
 * Fecha: 03/02/2020
 * Hora: 07:53 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Drawing;

namespace localizacion_de_circulos {
	/// <summary>
	/// Description of Figure.
	/// </summary>
	public class Figure {
		private int x, y, r;
		private Color c;
		
		public Figure() { }
		
		public Figure(int x, int y, int r, Color c) {
			//inicializar con los valores definidos
			this.x = x;
			this.y = y;
			this.r = r;
			this.c = c;
		}
		
		public int getX() { return x; }
		public int getY() { return y; }
		public int getR() { return r; }
		public Color getC() { return c; }
		
		public void setX(int x) { this.x = x; }
		public void setY(int y) { this.y = y; }
		public void setR(int r) { this.r = r; }
		public void setC(Color c) { this.c = c; }
	}
}
