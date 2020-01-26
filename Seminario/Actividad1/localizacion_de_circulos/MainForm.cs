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
			MessageBox.Show("El analisis se ha compeltado con exito.");
		}
		
		void BtnGenerateClick(object sender, System.EventArgs e) {
			//cambia la vista a la imagen modificada
            tabControl.SelectedIndex = 1;
            
			//generar imagen resultante
            pictureBoxDestiny.Image = bmp;
            
		}
		
		Circle analisisFigure(int x, int y, Color color) {
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
			Circle figure;// regresa el centro y el radio de la figura (posible circulo)
			
			//mientras que no sobrepase el alto de la imagen seguira buscando el tope inferior del circulo
			while(y_f < bmp.Height && bmp.GetPixel(x,y_f).ToArgb().Equals(color.ToArgb())) { y_f++;	}
			
			//mienstras que no sobrepase el ancho de la imagen seguira buscado el tope superior derecho
			while(x_f < bmp.Width && bmp.GetPixel(x_f,y).ToArgb().Equals(color.ToArgb())) { x_f++; }
			
			//nos genera el centro en X
			figure.x = (x_f+x)/2;
			//y en Y
			figure.y = (y_f+y)/2;
			//guardamos el raidio, le agregamos uno, que es el cesgo que obtenemos
			//al iniciar el analisis en la segunda fila
			figure.radius = figure.y-y+1;
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
					//colorear la mitd izquierda de la fila
					bmp.SetPixel(runner.x--,runner.y, c_f);
				}
				//baja a la siguiente file
				runner.y++;
			}
		}
		
		void fillToroide(Circle posInit, int r_i) {
			//el corredor se situal en la posicion inicial
			Circle runner = posInit;
			
			//la altura del corredor se situara en el punto mas alto de la figura
			//puede existir el caso de que la posicion salga del mapa, y debemos evitarla
			runner.y -= posInit.radius >= runner.y ? runner.y : posInit.radius+1;
			
			//e ira desendiendo hasta colorear todo el circulo o toparse con el fin del mapa
			while(runner.y <= posInit.y+posInit.radius && runner.y < bmp.Height) {
				//resetea la posicion x
				runner.x = posInit.x;
				
				while((runner.x < bmp.Width) &&
				      (!bmp.GetPixel(runner.x, runner.y).ToArgb().Equals(Color.White.ToArgb()) || posInit.x + r_i > runner.x)) {
					//pintar la mitad derecha
					if(bmp.GetPixel(runner.x, runner.y).ToArgb().Equals(Color.White.ToArgb())) {
						//pintar de blanco == omitir
							bmp.SetPixel(runner.x++,runner.y, Color.White);	
					} else {
						//colorea la mitad derecha de la fila
						bmp.SetPixel(runner.x++,runner.y, Color.Red);
					}
				}
				
				//reseteal el valor de la x de nuevo se resta uno ya que el pixel central fue pintado arriba
				runner.x = posInit.x-1;
				while((runner.x >= 0) &&
				      (!bmp.GetPixel(runner.x, runner.y).ToArgb().Equals(Color.White.ToArgb()) || posInit.x - r_i <= runner.x)) {
					//para colorear la mitd izquierda
					if(bmp.GetPixel(runner.x, runner.y).ToArgb().Equals(Color.White.ToArgb())) {
						//pintar de blanco == omitir
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
		
		bool isToroide(Circle toro) {
			//primero colocamos el centro en el tope superior
			toro.y -= toro.radius--;
			
			//inicamos h en el tope del circulo interno
			int height = 0, width_intern = 0, width_extern = 0, radius_inter = 0, margin_error_intern, margin_error_extern;
			
			//parte superior
			while(toro.y+height < bmp.Height && bmp.GetPixel(toro.x, toro.y+height).ToArgb().Equals(Color.Black.ToArgb())) { height++; }
			
			//guarda su valor par poder sacar la diferencia
			radius_inter = height;
			
			//centro
			while(toro.y+height < bmp.Height && !bmp.GetPixel(toro.x, toro.y+height).ToArgb().Equals(Color.Black.ToArgb())) { height++;}
			//	MessageBox.Show("x="+pos.x+"\ny="+(pos.y+h)+"\nname="+bmp.GetPixel(pos.x, pos.y+h).Name);
			
			//el radio interno sera la mitad de la altura obtenida
			radius_inter = (height-radius_inter)/2;
			
			//parte inferior
			while(toro.y+height < bmp.Height && bmp.GetPixel(toro.x, toro.y+height).ToArgb().Equals(Color.Black.ToArgb())) { height++; }
			
			//actualizo los datos del circulo
			toro.radius = height/2;
			toro.y += height/2;
			
			//analizar en fila
			while(toro.x-width_intern > 0 && !bmp.GetPixel(toro.x-width_intern, toro.y).ToArgb().Equals(Color.Black.ToArgb())) { width_intern++; }
			
			//al ancho externo se le añade el interno ya existente
			width_extern += width_intern;
			while(toro.x-width_extern > 0 && bmp.GetPixel(toro.x-width_extern, toro.y).ToArgb().Equals(Color.Black.ToArgb())) { width_extern++; }
			
			//obtengo el marger de error del circulo interno
			margin_error_intern = width_intern - radius_inter;
			
			//obtengo el margen de error desde el centro hasta el fin del toroide
			margin_error_extern = width_extern - toro.radius;
			
			
			if(toro.radius > radius_inter && marginErrorPixels(margin_error_intern) && marginErrorPixels(margin_error_extern) & width_intern > 5) {
				//MessageBox.Show("w2="+w2+"\nw="+w+"\nw+w2="+(w+w2)+"\nradio="+toro.radius);
				fillToroide(toro, radius_inter);
				drawCenter(toro);
				return true;
			}
			return false;			
		}
		
		bool isCircle(Circle center, Color color_extern) {
			//queremos buscar el ancho del circulo
			int width = 0, x = center.x, margin_error;
			
			//obtenemos del inicio del mapa hasta el fin del circulo (anchura)
			while(x < bmp.Width && !bmp.GetPixel(x, center.y).ToArgb().Equals(color_extern.ToArgb())) { x++; }
			//lo agregamos
			width += x;
		
			//obtenemos del inicio del mapa al inicio del circulo
			while( center.x > 0 && !bmp.GetPixel(center.x, center.y).ToArgb().Equals(color_extern.ToArgb())) { center.x--; }
			
			//lo restamos y obtenemos la anchura del circulo
			width -= center.x;
			
			//con el operador ternario verificamos si es un circulo (10 pixeles de diferencia en susdiametros)
			margin_error = center.radius*2 - width;
			
			return marginErrorPixels(margin_error);
		}
		
		bool marginErrorPixels(int margin_error) { return margin_error >= -10 && margin_error <= 10; }


	}
}
