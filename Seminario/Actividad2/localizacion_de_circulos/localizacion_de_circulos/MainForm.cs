/*
 * Creado por SharpDevelop.
 * Usuario: dagur
 * Fecha: 31/01/2020
 * Hora: 11:38 a. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace localizacion_de_circulos {
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form {
		int mov, movX, movY;
		public MainForm() {
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void CloseClick(object sender, EventArgs e)	{
			Application.Exit();
		}
					
		void MainFormMouseDown(object sender, MouseEventArgs e) {
			mov = 1;
			movX = e.X;
			movY = e.Y;
		}
		
		void MainFormMouseMove(object sender, MouseEventArgs e) {
			if(mov == 1) {
				this.SetDesktopLocation(MousePosition.X-movX, MousePosition.Y-movY);
			}
		}
		
		void MainFormMouseUp(object sender, MouseEventArgs e) {
			mov = 0;
		}
		
		void LblLoadMouseDown(object sender, MouseEventArgs e) {
			this.lblLoad.ForeColor = System.Drawing.Color.Red;
		}
		
		void LblLoadMouseUp(object sender, MouseEventArgs e) {
			this.lblLoad.ForeColor = System.Drawing.Color.White;
		}
		
		void LblAnalizeMouseDown(object sender, MouseEventArgs e) {
			this.lblAnalize.ForeColor = System.Drawing.Color.Red;
		}

		void LblAnalizeMouseUp(object sender, MouseEventArgs e) {
			this.lblAnalize.ForeColor = System.Drawing.Color.White;
		}
		
		void LblGenerateMouseDown(object sender, MouseEventArgs e) {
			this.lblGenerate.ForeColor = System.Drawing.Color.Red;
		}
		
		void LblGenerateMouseUp(object sender, MouseEventArgs e) {
			this.lblGenerate.ForeColor = System.Drawing.Color.White;
		}
		
		///////////////////////////////////////////////////////////////////////////
		/// 
		/// 
		
		void clickLoad(object sender, System.EventArgs e) {
			//abrir ventana de dialogo
			while(openFileDialogImg.ShowDialog() != System.Windows.Forms.DialogResult.OK){ /*fuerza la apertura de un archivo*/ }
			
			//selecciona el tab Origen
			tabControl.SelectedIndex = 0;
			
			//cargar la imagen en el tab Origen
			pictureBoxOrigen.ImageLocation = openFileDialogImg.FileName;
			
			//limpia la lista de datos
			listBoxCircles.Items.Clear();
			figures = new LinkedList<Figure>();
		}
		
		void LblAnalizeClick(object sender, EventArgs e) {
			// genera una copia de la imagen de origen para manipularla
			bmp= new Bitmap(openFileDialogImg.FileName);
			Figure toroide = new Figure();
			//agrega el texto visible del formato que tiene la lista
			listBoxCircles.Items.Add("(x, y) -> radio");
			
	        for (int y = 0; y < bmp.Height; y++) {
	            for (int x = 0; x < bmp.Width; x++) {
					//busca el primer pixel negro
					if(bmp.GetPixel(x,y).ToArgb().Equals(Color.Black.ToArgb())) {
						//al encontrarlo busca si se puede generar un circulo
						//searchCircle(analisisFigure(x, y, Color.Black));
						searchCenter(x, y, Color.Black);
						
						//LineaBresenham(0,0, 1000, 200);
						//guardara el centro y el radio en figure
						if(isCircle(Color.White)) {
							//si es un circulo debe pintarlo de otro color
							fillCircle(Color.Red);
							figures.AddLast(new Figure(figure));
							//drawCenter();
							string circle = "("+figure.getX()+","+figure.getY()+") -> "+figure.getR();
							//guarda en la lista los datos del circulo
							listBoxCircles.Items.Add("("+figure.getX()+","+figure.getY()+") -> "+figure.getR());
						}else if((toroide = isToroide()) != null) {			
							fillToroide(toroide, Color.Green);
							//drawCenter();
						}else if(isElipse()) {
							//borrar elipse
							eraseElipse();
						}else {
							//ignorar
							fillFigure(Color.Green);
							//fillCircle(Color.Orange);
						}
					}
				}
			}
			// generar todos los puntos entr los circulos
			MessageBox.Show("El analisis se ha compeltado con exito.");
		
		}
				
		void LblGenerateClick(object sender, EventArgs e) {
			//cambia la vista a la imagen modificada
            tabControl.SelectedIndex = 1;
            
			//generar imagen resultante
			union();
            pictureBoxDestiny.Image = bmp;
		}
		
		void searchCenter(int x, int y, Color color) {
			//buscara el centro de la figura
			//no anlizamos la fila encontrada, ya que puede contener ruido
			//es mas seguro analizar la fila siguiente
			y++;
			while(x > 0 && bmp.GetPixel(x,y).ToArgb().Equals(color.ToArgb())) { x--; }
			//MessageBox.Show("valor="+bmp.GetPixel(x,y).Name);
			//incrementa en uno para re-encontrar el pixel negro
			x++;
			
			//analiza la figura para obtener sus posicion y su radio
			int x_f = x;//x final
			int y_f = y;//y final
			//Figure figure = new Figure();// regresa el centro y el radio de la figura (posible circulo)
			
			//mientras que no sobrepase el alto de la imagen seguira buscando el tope inferior del circulo
			while(y_f < bmp.Height && bmp.GetPixel(x,y_f).ToArgb().Equals(color.ToArgb())) { y_f++;	}
			
			//mienstras que no sobrepase el ancho de la imagen seguira buscado el tope superior derecho
			while(x_f < bmp.Width && bmp.GetPixel(x_f,y).ToArgb().Equals(color.ToArgb())) { x_f++; }
			
			//nos genera el centro en X
			figure.setX((x_f+x)/2);
			//y en Y
			figure.setY((y_f+y)/2);
			//guardamos el raidio, le agregamos uno, que es el cesgo que obtenemos
			//al iniciar el analisis en la segunda fila
			figure.setR(figure.getY()-y+1);
			//inicializamos el color de la figura
			figure.setC(Color.Red);
		}
		
		bool isCircle(Color color_extern) {
			//queremos buscar el ancho del circulo
			int width = 0, x = figure.getX(), margin_error;
			
			//obtenemos del inicio del mapa hasta el fin del circulo (anchura)
			while(x < bmp.Width && !bmp.GetPixel(x, figure.getY()).ToArgb().Equals(color_extern.ToArgb())) { x++; }
			//lo agregamos
			width += x;
			x = figure.getX();
			//obtenemos del inicio del mapa al inicio del circulo
			while(x > 0 && !bmp.GetPixel(x, figure.getY()).ToArgb().Equals(color_extern.ToArgb())) { x--; }
			//obtenemos del inicio del mapa al inicio del circulo
			
			//lo restamos y obtenemos la anchura del circulo
			width -= x;
			
			//con el operador ternario verificamos si es un circulo (10 pixeles de diferencia en susdiametros)
			margin_error = figure.getR()*2 - width;
			r2 = width/2;
			//nos regresa true si la diferencia entre la altura y anchura es menor a 10 pixeles
			return marginErrorPixels(margin_error);
			
			//un circulo tambien es una figura eliptica
			//return isElipse();
		}
		
		Figure isToroide() {
			Figure toro = new Figure(figure.getX(), figure.getY(), figure.getR(), figure.getC());
			//primero colocamos el centro en el tope superior
			toro.setY(toro.getY() - toro.getR());
			
			//inicamos h en el tope del circulo interno
			int height = 0, width_intern = 0, width_extern = 0, radius_inter = 0, margin_error_intern, margin_error_extern;
			
			//parte superior
			while(toro.getY()+height < bmp.Height && bmp.GetPixel(toro.getX(), toro.getY()+height).ToArgb().Equals(Color.Black.ToArgb())) { height++; }
			
			//guarda su valor par poder sacar la diferencia
			radius_inter = height;
			
			//centro
			while(toro.getY()+height < bmp.Height && !bmp.GetPixel(toro.getX(), toro.getY()+height).ToArgb().Equals(Color.Black.ToArgb())) { height++;}
			//	MessageBox.Show("x="+pos.x+"\ny="+(pos.y+h)+"\nname="+bmp.GetPixel(pos.x, pos.y+h).Name);
			
			//el radio interno sera la mitad de la altura obtenida
			radius_inter = (height-radius_inter)/2;
			
			//parte inferior
			while(toro.getY()+height < bmp.Height && bmp.GetPixel(toro.getX(), toro.getY()+height).ToArgb().Equals(Color.Black.ToArgb())) { height++; }
			
			//actualizo los datos del circulo
			toro.setR(height/2);
			toro.setY(toro.getY() + height/2);
			
			//analizar en fila
			while(toro.getX()-width_intern > 0 && !bmp.GetPixel(toro.getX()-width_intern, toro.getY()).ToArgb().Equals(Color.Black.ToArgb())) { width_intern++; }
			
			//al ancho externo se le añade el interno ya existente
			width_extern += width_intern;
			while(toro.getX()-width_extern > 0 && bmp.GetPixel(toro.getX()-width_extern, toro.getY()).ToArgb().Equals(Color.Black.ToArgb())) { width_extern++; }
			
			//obtengo el marger de error del circulo interno
			margin_error_intern = width_intern - radius_inter;
			
			//obtengo el margen de error desde el centro hasta el fin del toroide
			margin_error_extern = width_extern - toro.getR();
			
			
			if(toro.getR() > radius_inter && marginErrorPixels(margin_error_intern) && marginErrorPixels(margin_error_extern) & width_intern > 5) {
				//MessageBox.Show("w2="+w2+"\nw="+w+"\nw+w2="+(w+w2)+"\nradio="+toro.radius);
				return toro;
			}
			return null;			
		}
		
		bool isElipse() {
			int	x;
			//x nos dara el punto que recorrera el mapa de forma horizontal
			//limit nos dara el limite en (x) del area del elipse
			
			//aumento los radios para generar el analisis del elipse
			figure.setR(figure.getR()+4);
			r2+=4;
			
			for(int y = figure.getY()-figure.getR(); y <= figure.getY(); y++) {
				x = limitXInElipse(y-figure.getY(), figure.getR(), r2)+figure.getX();
				//si hay colision de color negro en la busqueda no es una elipse
				
				if(figure.getX()*2-x >= 0 && y >= 0 && !bmp.GetPixel(figure.getX()*2-x, y).ToArgb().Equals(Color.White.ToArgb()))
					return false;//cuadrante 2
				
				if(figure.getX()*2-x >= 0 && figure.getY()*2-y < bmp.Height && !bmp.GetPixel(figure.getX()*2-x, figure.getY()*2-y).ToArgb().Equals(Color.White.ToArgb()))
					return false;//cuadrante 3
				
				if(x < bmp.Width && figure.getY()*2-y < bmp.Height && !bmp.GetPixel(x,  figure.getY()*2-y).ToArgb().Equals(Color.White.ToArgb()))
					return false;//cuadrante 4
				
				if(x < bmp.Width && x >= 0 && y >= 0 && !bmp.GetPixel(x, y).ToArgb().Equals(Color.White.ToArgb()))
					return false;//cuadrante 1
			}
			return true;
		}
		
		void drawCenter() {
			//da el ancho del punto central de cada circulo
			const int WIDTH = 7;
			for(int i = figure.getX() - WIDTH; i < figure.getX() + WIDTH; i++) {
				for(int j = figure.getY() - WIDTH; j < figure.getY() + WIDTH; j++) {
					if(i >= 0 && i < bmp.Width && j >= 0 && j < bmp.Height) {
						//pinta los pixeles
						bmp.SetPixel(i,j, Color.Silver);
					}
				}
			}
		}
		
		void eraseElipse() {
			int	x, limit;
			//x nos dara el punto que recorrera el mapa de forma horizontal
			//limit nos dara el limite en (x) del area del elipse
			
			for(int y = figure.getY()-figure.getR(); y <= figure.getY(); y++) {
				x = figure.getX();
				limit = limitXInElipse(y-figure.getY(), figure.getR(), r2);
				
				while(x <= limit+figure.getX()){
					//usando una cuarta pate e l circulo dibujo dentro de los 4 cuadrantes
					if(figure.getX()*2-x >= 0 && y >= 0)
						bmp.SetPixel(figure.getX()*2-x, y, Color.White);//cuadrante 2
					
					if(figure.getX()*2-x >= 0 && figure.getY()*2-y < bmp.Height)
						bmp.SetPixel(figure.getX()*2-x, figure.getY()*2-y, Color.White);//cuadrante 3
					
					if(x < bmp.Width && figure.getY()*2-y < bmp.Height)
						bmp.SetPixel(x,  figure.getY()*2-y, Color.White);//cuadrante 4
					
					if(x < bmp.Width && y >= 0)
						bmp.SetPixel(x, y, Color.White);//cuadrante 1
					x++;
				}
			}
		}
		
		void fillCircle(Color color) {
			int x, limit;
			//aumentamos el radio para evadir el sesgo
			figure.setR(figure.getR()+3);
			for(int y = figure.getY()-figure.getR(); y <= figure.getY(); y++) {
				x = figure.getX();
				limit = limitXInCircle(figure.getR(), figure.getY(), y);
				while(x <= limit+figure.getX()){
					//usando una cuarta pate e l circulo dibujo dentro de los 4 cuadrantes
					if(figure.getX()*2-x >= 0 && y >= 0 && !bmp.GetPixel(figure.getX()*2-x, y).ToArgb().Equals(Color.White.ToArgb()))
						bmp.SetPixel(figure.getX()*2-x, y, color);//cuadrante 2
					
					if(figure.getX()*2-x >= 0 && figure.getY()*2-y < bmp.Height && !bmp.GetPixel(figure.getX()*2-x, figure.getY()*2-y).ToArgb().Equals(Color.White.ToArgb()))
						bmp.SetPixel(figure.getX()*2-x, figure.getY()*2-y, color);//cuadrante 3
					
					if(x < bmp.Width && figure.getY()*2-y < bmp.Height && !bmp.GetPixel(x,  figure.getY()*2-y).ToArgb().Equals(Color.White.ToArgb()))
						bmp.SetPixel(x,  figure.getY()*2-y, color);//cuadrante 4
					
					if(x < bmp.Width && y >= 0 && !bmp.GetPixel(x, y).ToArgb().Equals(Color.White.ToArgb()))
						bmp.SetPixel(x, y, color);//cuadrante 1
					x++;
				}
			}
		}
		
		void fillToroide(Figure figure, Color color) {
			int x, limit;
			//aumentamos el radio para evadir el sesgo
			figure.setR(figure.getR()+3);
			for(int y = figure.getY()-figure.getR(); y <= figure.getY(); y++) {
				x = figure.getX();
				limit = limitXInCircle(figure.getR(), figure.getY(), y);
				while(x <= limit+figure.getX()){
					//usando una cuarta pate e l circulo dibujo dentro de los 4 cuadrantes
					if(figure.getX()*2-x >= 0 && y >= 0 && !bmp.GetPixel(figure.getX()*2-x, y).ToArgb().Equals(Color.White.ToArgb()))
						bmp.SetPixel(figure.getX()*2-x, y, color);//cuadrante 2
					
					if(figure.getX()*2-x >= 0 && figure.getY()*2-y < bmp.Height && !bmp.GetPixel(figure.getX()*2-x, figure.getY()*2-y).ToArgb().Equals(Color.White.ToArgb()))
						bmp.SetPixel(figure.getX()*2-x, figure.getY()*2-y, color);//cuadrante 3
					
					if(x < bmp.Width && figure.getY()*2-y < bmp.Height && !bmp.GetPixel(x,  figure.getY()*2-y).ToArgb().Equals(Color.White.ToArgb()))
						bmp.SetPixel(x,  figure.getY()*2-y, color);//cuadrante 4
					
					if(x < bmp.Width && y >= 0 && !bmp.GetPixel(x, y).ToArgb().Equals(Color.White.ToArgb()))
						bmp.SetPixel(x, y, color);//cuadrante 1
					x++;
				}
			}
		}
		
		void fillFigure(Color color) {
			figure.setR(figure.getR()+2);
			for(int i = figure.getX() - figure.getR(); i < figure.getX() + figure.getR(); i++) {
				for(int j = figure.getY() - figure.getR(); j < figure.getY() + figure.getR(); j++) {
					if(i >= 0 && i < bmp.Width && j >= 0 && j < bmp.Height) {
						//pinta los pixeles
						if(!bmp.GetPixel(i,j).ToArgb().Equals(Color.White.ToArgb()))
							{bmp.SetPixel(i,j, Color.Green);}
					}
				}
			}
		}
		
		int limitXInCircle(int r, int y1, int y2) {
			return (int)Math.Sqrt(Math.Pow(r, 2) - Math.Pow(y2-y1, 2));
		}
		
		int limitXInElipse(int y, int a, int b) {
			//a => r1 => rh
			//b => r2 => rw
			return (int)Math.Sqrt(Math.Pow(b, 2) - Math.Pow((b*y/a), 2));
				
 		}
		
		bool marginErrorPixels(int margin_error) { return margin_error >= -10 && margin_error <= 10; }

		void LineaBresenham(int X1, int Y1, int X2, int Y2) {
			// 0 - Distancias que se desplazan en cada eje
			int dY = (Y2 - Y1);
			int dX = (X2 - X1);
			int Yi,Xi, Yr, Xr;
			// 1 - Incrementos para las secciones con avance inclinado
			if (dY >= 0) {
			  Yi = 1;
			} else {
			  dY = -dY;
			  Yi = -1;
			}
			
			if (dX >= 0) {
			  Xi = 1;
			} else {
			  dX = -dX;
			  Xi = -1;
			}
			
			// 2 - Incrementos para las secciones con avance recto:
			if (dX >= dY) {
			  Yr = 0;
			  Xr = Xi;
			} else {
			  Xr = 0;
			  Yr = Yi;
			
			  // Cuando dy es mayor que dx, se intercambian, para reutilizar el mismo bucle.
			  // ver octantes blancos en la imagen encima del código
			  int k = dX; dX = dY; dY = k;
			}
			
			// 3  - Inicializar valores (y de error).
			int X = X1, Y = Y1;
			int avR = (2 * dY);
			int av  = (avR - dX);
			int avI = (av - dX);
			
			// 4  - Bucle para el trazado de las línea.
			do {
				//MessageBox.Show(av + " "+ X + " " + Y);
				if(X > 0 && X < bmp.Width && Y > 0 && Y < bmp.Height)
				{bmp.SetPixel(X, Y, Color.Black);}
				//DibujarPixel(X, Y, Color); // Como mínimo se dibujará siempre 1 píxel (punto).
				//Mensaje(av + " ") // (debug) para ver los valores de error global que van apareciendo.
				if (av >= 0) {
				  X = (X + Xi);    // X aumenta en inclinado.
				  Y = (Y + Yi);    // Y aumenta en inclinado.
				  av = (av + avI);    // Avance Inclinado
				} else {
				  X = (X + Xr);    // X aumenta en recto.
				  Y = (Y + Yr);    // Y aumenta en recto.
				  av = (av + avR);    // Avance Recto
				}
				//MessageBox.Show("="+X+","+X2);
			} while(X != X2); // NOTA: La condición de 'Repetir Hasta', se debe cambiar si se elige 'Repetir Mientras'
		}
	
		void DDA(int x1, int y1, int x2, int y2) {
			float ax, ay, x, y, res, i = 0;
			
			
			//res = Math.Abs(x2 - x1) >= Math.Abs(y2 - y1) ? Math.Abs(x2 - x1) : Math.Abs(y2 - y1);
			if(Math.Abs(x2 - x1) >= Math.Abs(y2 - y1)) {
				res = Math.Abs(x2 - x1);
			} else {
				res = Math.Abs(y2 - y1);
			}
			
			ax = (x2 - x1) / res;
			ay = (y2 - y1) / res;
			x = (float)x1;
			y = (float)y1;
			
			while(i <= res) {
				pintar((int)x, (int)y);
				x += ax;
				y += ay;
				i++;
			}			
		}
		
		bool collisionDDA(int x1, int y1, int x2, int y2) {
			float ax, ay, x, y, res, i = 0;
			
			
			//res = Math.Abs(x2 - x1) >= Math.Abs(y2 - y1) ? Math.Abs(x2 - x1) : Math.Abs(y2 - y1);
			if(Math.Abs(x2 - x1) >= Math.Abs(y2 - y1)) {
				res = Math.Abs(x2 - x1);
			} else {
				res = Math.Abs(y2 - y1);
			}
			
			ax = (x2 - x1) / res;
			ay = (y2 - y1) / res;
			x = (float)x1;
			y = (float)y1;
			
			while(i <= res) {
				if(x != x1 && y != y1) {
					if(collision((int)x, (int)y)) {
						return true;
					}
				}
				
				x += ax;
				y += ay;
				i++;
			}	
			return false;			
		}
		
		bool collision(int x, int y) {
			if(bmp.GetPixel(x, y).ToArgb().Equals(Color.White.ToArgb()) ||
			   bmp.GetPixel(x, y).ToArgb().Equals(Color.Red.ToArgb()) ) {
				return false;
			}
			//MessageBox.Show(bmp.GetPixel(x, y).Name);
			return true;
		}
		
		void bresenham(int x1, int y1, int x2, int y2) {
			int dx = Math.Abs(x1 - x2);
			int dy = Math.Abs(y1 - y2);
			float m = (float)dy / (float)dx;
			int dy2, par, i = 1;
			//dx = Math.Abs(dx);
			//dy = Math.Abs(dy);
			dy2 = dy*2;
			par = dy2 - dx;
			
			if(m > 0) {
				do {
					pintar(x2, y2);
					while(par >= 0) {
						y2++;
						par -= 2*dx;
						pintar(x2, y2);
					}
					x2++;
					par += dy2;
					i++;
				} while(i < dx);
			} else {
				do {
					pintar(x2, y2);
					while(par >= 0) {
						y2--;
						par -= 2*dx;
						pintar(x2, y2);
					}
					x2++;
					par += dy2;
					i++;
				} while(i < dx);
			}
		} 
		
		void pintar(int x, int y) {
			if(x >= 0 && x < bmp.Width && y >= 0 && y < bmp.Height)
				bmp.SetPixel(x, y, Color.Black);
		}
		
		void union() {
			Figure c = new Figure();
			
			while(figures.First != null) {
				c.setX(figures.First().getX());
				c.setY(figures.First().getY());
				figures.RemoveFirst();
				
				foreach(Figure circle in figures) {
					//MessageBox.Show("x1="+circle.getX()+"\ny1="+circle.getY()+"\nx2="+figure.getX()+"\ny2="+figure.getY());
					if(!collisionDDA(c.getX(), c.getY(), circle.getX(), circle.getY()))
						DDA(c.getX(), c.getY(), circle.getX(), circle.getY());
				}
			}
		}
	}
}
