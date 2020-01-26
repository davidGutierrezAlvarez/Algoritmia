/*
 * Creado por SharpDevelop.
 * Usuario: dagur
 * Fecha: 23/01/2020
 * Hora: 06:48 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace localizacion_de_circulos
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm() {
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void BtnLoadClick(object sender, System.EventArgs e) {
			//selecciona el tab Origen
			tabControl.SelectedIndex = 0;
			
			//abrir ventana de dialogo
			while(openFileDialogImg.ShowDialog() != System.Windows.Forms.DialogResult.OK){ /*fuerza la apertura de un archivo*/ }
			
			//cargar la imagen en el tab Origen
			pictureBoxOrigin.ImageLocation = openFileDialogImg.FileName;
			
			//limpia la lista de datos
			while( listBoxCircles.Items.Count > 0) {
				listBoxCircles.Items.RemoveAt(0);
			}
		}
		
		void BtnAnalyzeClick(object sender, System.EventArgs e) {
			// genera una copia de la imagen de origen para manipularla
			bmp= new Bitmap(openFileDialogImg.FileName);
			
			//agrega el texto visible del formato que tiene la lista
			listBoxCircles.Items.Add("(x, y) -> radio");
			
	        for (int y = 0; y < bmp.Height; y++) {
	            for (int x = 0; x < bmp.Width; x++) {
					//busca el primer pixel negro
					if(bmp.GetPixel(x,y).ToArgb().Equals(Color.Black.ToArgb())) {
						//al encontrarlo busca si se puede generar un circulo
						searchCircle(analisisFigure(x, y, Color.Black));
					}
				}
			}
			System.Windows.Forms.MessageBox.Show("El analisis se ha compeltado con exito.");
		}
		
		void BtnGenerateClick(object sender, System.EventArgs e) {
			//cambia la vista a la imagen modificada
            tabControl.SelectedIndex = 1;
            
			//generar imagen resultante
            pictureBoxDestiny.Image = bmp;
            
		}
		
		Circle analisisFigure(int x, int y, Color color) {
			//analiza la figura para obtener sus posicion y su radio
			int x_f = x;//x final
			int y_f = y;//y final
			Circle figure;// regresa el centro y el radio de la figura (posible circulo)
			//mientras que no sobrepase el alto de la imagen seguira buscando el tope inferior del circulo
			while(y_f < bmp.Height && bmp.GetPixel(x,y_f).ToArgb().Equals(color.ToArgb())) { y_f++; }
			
			//mienstras que no sobrepase el ancho de la imagen seguira buscado el tope superior derecho
			while(x_f < bmp.Width && bmp.GetPixel(x_f,y).ToArgb().Equals(color.ToArgb())) { x_f++; }
			
			//nos genera el centro en X
			figure.x = (x_f+x)/2;
			//y en Y
			figure.y = (y_f+y)/2;
			//guardamos el raidio
			figure.radius = figure.y-y;
			return figure;
		}
		
		void searchCircle(Circle pos) {
			//detecta que es un circulo y no omite elruido
			if(isCircle(pos, Color.White) && pos.radius > 10) {
				string circle = "("+pos.x+","+pos.y+") -> "+(pos.radius);
				//guarda en la lista los datos del circulo
				listBoxCircles.Items.Add(circle);
				//rellena el cruclo
				fillCircle(pos, Color.BlueViolet);
				//dibuja el centro
				drawCenter(pos);
			} else {
				//si no es circulo, revisar si es un toroide
				if(!isToroide(pos)) {
					//en casa de que no sea toroide tendra que ser un ovalo y se eliminara
					fillCircle(pos, Color.White);
				}
			}
		}
		
		void drawCenter(Circle pos) {
			//da el ancho del punto central de cada circulo
			const int WIDTH = 7;
			for(int i = pos.x - WIDTH; i < pos.x + WIDTH; i++) {
				for(int j = pos.y - WIDTH; j < pos.y + WIDTH; j++) {
					if(i >= 0 && i < bmp.Width && j >= 0 && j < bmp.Height) {
						//pinta los pixeles
						bmp.SetPixel(i,j, Color.Silver);
					}
				}
			}
		}
		
		void fillCircle(Circle posInit, Color c_f) {
			//c_i es el colo oroginial y c_f color final
			//el corredor se situal en la posicion inicial
			Circle runner = posInit;
			//despues se coloca en el punto superior
			runner.y -= posInit.radius++;
			
			//e ira desendiendo hasta colorear todo el circulo o toparse con el fin del mapa
			while(runner.y <= posInit.y+posInit.radius && runner.y < bmp.Height) {
				//resetea la posicion x
				runner.x = posInit.x;
				while(runner.x < bmp.Width && !bmp.GetPixel(runner.x, runner.y).ToArgb().Equals(Color.White.ToArgb())) {
					//colorea la mitad derecha de la fila
					bmp.SetPixel(runner.x++,runner.y, c_f);
				}
				
				//reseteal el valor de la x de nuevo
				runner.x = posInit.x-1;
				while( runner.x >= 0 && !bmp.GetPixel(runner.x, runner.y).ToArgb().Equals(Color.White.ToArgb())) {
					//para colorear la mitd izquierda
					bmp.SetPixel(runner.x--,runner.y, c_f);
				}
				
				//baja a la siguiente file
				runner.y++;
			}
		}
		
		void fillToroide(Circle posInit, int r_i) {
			//c_i es el colo oroginial y c_f color final
			//el corredor se situal en la posicion inicial
			Circle runner = posInit;
			//despues se coloca en el punto superior
			runner.radius = r_i;
			//fillCircle(runner, Color.Orange);
			runner.radius = posInit.radius;
			runner.y -= posInit.radius+2;
			
			//e ira desendiendo hasta colorear todo el circulo o toparse con el fin del mapa
			while(runner.y <= posInit.y+posInit.radius && runner.y < bmp.Height) {
				//resetea la posicion x
				runner.x = posInit.x;
				
				while((runner.x < bmp.Width && runner.x < posInit.x + posInit.radius) &&
				      (!bmp.GetPixel(runner.x, runner.y).ToArgb().Equals(Color.White.ToArgb()) || posInit.x + r_i > runner.x)) {
					
					if(bmp.GetPixel(runner.x, runner.y).ToArgb().Equals(Color.White.ToArgb())) {
							bmp.SetPixel(runner.x++,runner.y, Color.White);
						
					} else {
						//colorea la mitad derecha de la fila
						bmp.SetPixel(runner.x++,runner.y, Color.Red);
					}
					
				}
				
				//reseteal el valor de la x de nuevo se resta uno ya que el pixel central fue pintado arriba
				runner.x = posInit.x-1;
				while((runner.x >= 0 && runner.x > posInit.x - posInit.radius) &&
				      (!bmp.GetPixel(runner.x, runner.y).ToArgb().Equals(Color.White.ToArgb()) || posInit.x - r_i < runner.x)) {
					//para colorear la mitd izquierda
					
					if(bmp.GetPixel(runner.x, runner.y).ToArgb().Equals(Color.White.ToArgb())) {
						bmp.SetPixel(runner.x--,runner.y, Color.White);
					} else {
						//colorea la mitad izquierda de la fila
						bmp.SetPixel(runner.x--,runner.y, Color.Red);
					}
				}
				
				//baja a la siguiente file
				runner.y++;
			}
			
		}
		
		bool isToroide(Circle pos) {
			//primero colocamos el centro en el tope superior
			pos.y -= pos.radius;
			//inicamos h en eltope del circulo interno
			int h = 0, w = 0, r_i, margin_error;
			
			//parte superior
			while(pos.y+h < bmp.Height && bmp.GetPixel(pos.x, pos.y+h).ToArgb().Equals(Color.Black.ToArgb())) { h++; }
			
			//centro
			while(pos.y+h < bmp.Height && !bmp.GetPixel(pos.x, pos.y+h).ToArgb().Equals(Color.Black.ToArgb())) { h++; }
			
			//si llego hasta abajo sin encotnrar la parte inferior del circulo entonces no es un toroidal
			if(pos.y+h == bmp.Height) { return false; }
			//en caso contrario buscar el limite de la parte inferior
			
			//el radio interno sera la mitad de la altura obtenida
			r_i = (h-pos.radius*2)/2+1;
			
			while(pos.y+h < bmp.Height && bmp.GetPixel(pos.x, pos.y+h).ToArgb().Equals(Color.Black.ToArgb())) { h++; }
			
			
			margin_error = h - (pos.radius*4 + r_i*2);
			
			//actualizo los datos del circulo
			pos.radius = h/2;
			pos.y += h/2;
			
			
			
			//drawCenter(pos);
			//analizar en fila
			while(pos.x-w > 0 && !bmp.GetPixel(pos.x-w, pos.y).ToArgb().Equals(Color.Black.ToArgb())) { w++; }
			
			if(r_i-w < -10  || r_i-w > 10) {return false; }
			//w = 0;
			//while(pos.x+w < bmp.Width && bmp.GetPixel(pos.x+w, pos.y).ToArgb().Equals(Color.Black.ToArgb())) { w++; }
			
			//if(pos.radius < -10  || pos.radius > 10) { return false; }
				
			if(margin_error >= -5 && margin_error <= 5 && r_i > 1 && pos.radius > r_i) {
				System.Windows.Forms.MessageBox.Show("toride: "+pos.radius+","+pos.x+","+pos.y+"\nCirculo: "+ r_i);
				fillToroide(pos, r_i);
				drawCenter(pos);
				return true;
			}
			return false;
			//return  ? true : false;
			
		}
		
		bool isCircle(Circle center, Color color_extern) {
			//queremos buscar el ancho del circulo
			int width = 0, x = center.x, h=0;
			/*if(center.x-h >= 0 && center.y-h >= 0 && 
			   !bmp.GetPixel(center.x-center.radius*Math.sqrt(2)+5, center.y-center.radius*Math.sqrt(2)+5).ToArgb().Equals(color_extern.ToArgb()) &&
			   bmp.GetPixel(center.x-center.radius*Math.sqrt(2)-5, center.y-center.radius*Math.sqrt(2)-5).ToArgb().Equals(color_extern.ToArgb())) {
				h = 1;
			}*/
			//obtenemos del inicio del mapa hasta el fin del circulo (anchura)
			while(x < bmp.Width && !bmp.GetPixel(x, center.y).ToArgb().Equals(color_extern.ToArgb())) { x++; }
			//lo agregamos
			width += x;
		
			//obtenemos del inicio del mapa al inicio del circulo
		
			while( center.x > 0 && !bmp.GetPixel(center.x, center.y).ToArgb().Equals(color_extern.ToArgb())) { center.x--; }
			//lo restamos y obtenemos la anchura del circulo
			width -= center.x;
			
			//con el operador ternario verificamos si es un circulo (10 pixeles de diferencia en susdiametros)
			
			//System.Windows.Forms.MessageBox.Show("h = "+h);
			return center.radius*2 - width < 10 && center.radius*2 - width > - 10 ? true : false;
		}
		


	}
}
