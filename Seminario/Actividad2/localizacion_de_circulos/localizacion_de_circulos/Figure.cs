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
		
		public Figure() { }
		
		public Figure(Figure f) {
			this.x = f.x;
			this.y = f.y;
			this.r = f.r;
		}
		
		public Figure(int x, int y, int r) {
			//inicializar con los valores definidos
			this.x = x;
			this.y = y;
			this.r = r;
		}
		
		public int X {
			get { return this.x; }
			set { this.x = value; }
		}
		
		public int Y {
			get { return this.y; }
			set { this.y = value; }
		}
		
		public int R {
			get { return this.r; }
			set { this.r = value; }
		}
		
		public float distance(int x, int y) {
			return (float)Math.Sqrt(Math.Pow(Math.Abs(x - this.x), 2) + Math.Pow(Math.Abs(y - this.y), 2));
		}
		
		public float distance(Figure circle) {
			return (float)Math.Sqrt(Math.Pow(Math.Abs(circle.X - this.x), 2) + Math.Pow(Math.Abs(circle.Y - this.y), 2));
		}
		
		public bool collision(Figure c2) {
			return this.r+5 + c2.r > distance(c2.X, c2.Y);
		}
		
		public override string ToString() {
			return "("+x+","+y+") -> "+r;
		}
	}
}
