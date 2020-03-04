/*
 * Creado por SharpDevelop.
 * Usuario: dagur
 * Fecha: 03/03/2020
 * Hora: 10:31 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Drawing;

namespace Actividad3 {
	/// <summary>
	/// Description of Figure.
	/// </summary>
	public class Figure {
		int x, y, r;
		
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
		/* aqui termina las funciones internas para crear el objeto
		 * y ver colisiones y distancias
		 * 	  
		 */
		
		
		public void searchCenter(int x, int y, Bitmap bmp) {
			//buscara el centro de la figura
			//no anlizamos la fila encontrada, ya que puede contener ruido
			//es mas seguro analizar la fila siguiente
			y++;
			while(x > 0 && bmp.GetPixel(x,y).ToArgb().Equals(Color.Black.ToArgb())) { x--; }
			//incrementa en uno para re-encontrar el pixel negro
			x++;
			
			//analiza la figura para obtener sus posicion y su radio
			int x_f = x;//x final
			int y_f = y;//y final
			//Figure figure = new Figure();// regresa el centro y el radio de la figura (posible circulo)
			
			//mientras que no sobrepase el alto de la imagen seguira buscando el tope inferior del circulo
			while(y_f < bmp.Height && bmp.GetPixel(x,y_f).ToArgb().Equals(Color.Black.ToArgb())) { y_f++;	}
			
			//mienstras que no sobrepase el ancho de la imagen seguira buscado el tope superior derecho
			while(x_f < bmp.Width && bmp.GetPixel(x_f,y).ToArgb().Equals(Color.Black.ToArgb())) { x_f++; }
			
			//nos genera el centro en X
			this.x = (x_f+x)/2; 
			//y en Y
			this.y = (y_f+y)/2;
			//guardamos el raidio, le agregamos uno, que es el cesgo que obtenemos
			//al iniciar el analisis en la segunda fila
			this.r = this.y-y+1;
		}
		
		public bool isCircle(Bitmap bmp) {
			//queremos buscar el ancho del circulo
			int width = 0, x = this.x, margin_error;
			
			//obtenemos del inicio del mapa hasta el fin del circulo (anchura)
			while(x < bmp.Width && !bmp.GetPixel(x, this.y).ToArgb().Equals(Color.White.ToArgb())) { x++; }
			//lo agregamos
			width += x;
			x = this.x;
			//obtenemos del inicio del mapa al inicio del circulo
			while(x > 0 && !bmp.GetPixel(x, this.y).ToArgb().Equals(Color.White.ToArgb())) { x--; }
			//obtenemos del inicio del mapa al inicio del circulo
			
			//lo restamos y obtenemos la anchura del circulo
			width -= x;
			
			//con el operador ternario verificamos si es un circulo (10 pixeles de diferencia en susdiametros)
			margin_error = this.r*2 - width;
			//r2 = width/2;
			//nos regresa true si la diferencia entre la altura y anchura es menor a 10 pixeles
			return marginErrorPixels(margin_error);
		}
		
		public void drawCenter(Bitmap bmp) {
			//da el ancho del punto central de cada circulo
			const int WIDTH = 20;//7
			for(int i = this.x - WIDTH; i < this.x + WIDTH; i++) {
				for(int j = this.y - WIDTH; j < this.y + WIDTH; j++) {
					if(i >= 0 && i < bmp.Width && j >= 0 && j < bmp.Height) {
						//pinta los pixeles
						//cambiar por un grapics
						bmp.SetPixel(i,j, Color.Purple);
					}
				}
			}
		}
		
		bool marginErrorPixels(int margin_error) { return margin_error >= -10 && margin_error <= 10; }

		
	}
}
