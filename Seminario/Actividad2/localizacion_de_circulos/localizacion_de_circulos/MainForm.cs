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
	
	delegate void Lambda();
		
	public partial class MainForm : Form {
		int mov, movX, movY;
		int idCircleSelct= -1;
		Graph graph = new Graph();
		List<Bitmap> images = new List<Bitmap>();
		
		public MainForm() {
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			load();
			lineColor = Color.Red;
			circuitLineColor = Color.Blue;
			textColor = Color.White;
			lblTextColor.BackColor = textColor;
			lblColorLine.BackColor = lineColor;
			lblColorCircuit.BackColor = circuitLineColor;
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void load() {
			for(int i = 0; i < 2; i++) {
				images.Add(new Bitmap(@"img/"+(i+2)+ ".png"));
			}
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
			this.lblLoad.ForeColor = Color.Red;
		}
		
		void LblLoadMouseUp(object sender, MouseEventArgs e) {
			this.lblLoad.ForeColor = Color.White;
		}
		
		void LblAnalizeMouseDown(object sender, MouseEventArgs e) {
			this.lblAnalize.ForeColor = Color.Red;
		}

		void LblAnalizeMouseUp(object sender, MouseEventArgs e) {
			this.lblAnalize.ForeColor = Color.White;
		}
		
		void LblGenerateMouseDown(object sender, MouseEventArgs e) {
			this.lblGenerate.ForeColor = Color.Red;
		}
		
		void LblGenerateMouseUp(object sender, MouseEventArgs e) {
			this.lblGenerate.ForeColor = Color.White;
		}
		
		void Button1Click(object sender, EventArgs e) {
			while(colorDialog.ShowDialog() != DialogResult.OK){ /*fuerza la apertura de un archivo*/ }
			lblColorLine.BackColor = colorDialog.Color;
			lineColor = colorDialog.Color;
		}
	
		void BtnTextColorClick(object sender, EventArgs e) {
			while(colorDialog.ShowDialog() != DialogResult.OK){ /*fuerza la apertura de un archivo*/ }
			lblTextColor.BackColor = colorDialog.Color;
			textColor = colorDialog.Color;
		}
		
		void btnCircuitClcik(object sender, EventArgs e) {
			while(colorDialog.ShowDialog() != DialogResult.OK){ /*fuerza la apertura de un archivo*/ }
			lblColorCircuit.BackColor = colorDialog.Color;
			circuitLineColor = colorDialog.Color;
		}
	
		///////////////////////////////////////////////////////////////////////////
		/// 
		///
		/// 
		/// 
		/// 
		///////////////////////////////////////////////////////////////////////////
		
		
		void clickLoad(object sender, System.EventArgs e) {
			//abrir ventana de dialogo
			while(openFileDialogImg.ShowDialog() != DialogResult.OK){ /*fuerza la apertura de un archivo*/ }
			
			//selecciona el tab Origen
			tabControl.SelectedIndex = 0;
			
			//cargar la imagen en el tab Origen
			bmp = new Bitmap(openFileDialogImg.FileName);
			bmpBackGround = new Bitmap(openFileDialogImg.FileName);
			pictureBoxOrigen.Image = bmp;
			
			Clean();
		}
		
		void Clean() {
			//limpia la lista de datos
			listBoxCircles.Items.Clear();
			figures = new List<Figure>();
			treeViewCircles.Nodes.Clear();
			//limpio el grafo
			lblclosestPair.Text = "Más cercanos:";
			lblCircuit.Text = "Circuito:";
			graph.getVertex().Clear();
			graph.Clear();
		}
		
		void LblAnalizeClick(object sender, EventArgs e) {
			// genera una copia de la imagen de origen para manipularla
			if(openFileDialogImg.FileName == "dialog") {
				MessageBox.Show("Primero debe seleccionar una imagen.");
				return;
			}
			//analiza la imagen para generar los nodos del grafo
			analizeImg();
			
			//cambia la vista a la imagen modificada
            tabControl.SelectedIndex = 0;
            
			//genera las lineans con DDA
			generateEdges();
			//insertar etiquetas
			drawLbl();
			//genera la vista Arbol del grafo
			generateTreeView();
			//dibuja las aristas entre los circulos que se pueden conectar
			drawEdges(graph, lineColor);
			//
            lblclosestPair.Text = graph.ToString();
            
			pictureBoxOrigen.BackgroundImage = bmp;
			pictureBoxOrigen.BackgroundImageLayout = ImageLayout.Zoom;
			bmp = new Bitmap(bmp);
			
			MessageBox.Show("El analisis se ha compeltado con exito.");
			
			graph.generarSubGrafo();
		}
			
		void analizeImg() {
			Figure toroide = new Figure();
			//agrega el texto visible del formato que tiene la lista
			listBoxCircles.Items.Add("(x, y) -> radio");
			int id = 0;
			
	        for (int y = 0; y < bmp.Height; y++) {
	            for (int x = 0; x < bmp.Width; x++) {
					//busca el primer pixel negro
					if(bmp.GetPixel(x,y).ToArgb().Equals(Color.Black.ToArgb())) {
						//al encontrarlo busca si se puede generar un circulo
						//searchCircle(analisisFigure(x, y, Color.Black));
						
						if(!pixelInArea(new Figure(x, y, 1))) {
							//si el pixel negro encontrado no colisiona con algun circulo existente comenzara el analisis
							searchCenter(x, y, Color.Black);
							if(isCircle(Color.White)) {
								//si es un circulo debe pintarlo de otro color
								figures.Add(new Figure(circle));
								//
								listBoxCircles.Items.Add(circle.ToString());
								//añado el circlo al Grafo
								graph.addVertex(new Figure(circle), id);
								id++;
							}
						}	
					}
				}
			}
		}
		
		void LblGenerateClick(object sender, EventArgs e) {
			//cambia la vista a la imagen modificada
            tabControl.SelectedIndex = 0;
            //int circleInit = listBoxCircles.SelectedIndex-1;
            //limpio el circulo generado para hacer un recorrido limpio
			pictureBoxOrigen.Image = bmp;
            //generar animacion del grafo
            
            if(idCircleSelct < 0) {
            	MessageBox.Show("Primero debe seleccionar un Vertice.");
            	return;
            }
            //inicializo mi auxiliar
            
            if(!circuitHamiltonian(idCircleSelct)) {
				MessageBox.Show("El circuito no se puede generar");
            }
            
            pictureBoxOrigen.Image = bmp;
		}
		
		void searchCenter(int x, int y, Color color) {
			//buscara el centro de la figura
			//no anlizamos la fila encontrada, ya que puede contener ruido
			//es mas seguro analizar la fila siguiente
			y++;
			while(x > 0 && bmp.GetPixel(x,y).ToArgb().Equals(color.ToArgb())) { x--; }
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
			circle.X = (x_f+x)/2;
			//y en Y
			circle.Y = (y_f+y)/2;
			//guardamos el raidio, le agregamos uno, que es el cesgo que obtenemos
			//al iniciar el analisis en la segunda fila
			circle.R = circle.Y-y+1;
		}
		
		bool isCircle(Color color_extern) {
			//queremos buscar el ancho del circulo
			int width = 0, x = circle.X, margin_error;
			
			//obtenemos del inicio del mapa hasta el fin del circulo (anchura)
			while(x < bmp.Width && !bmp.GetPixel(x, circle.Y).ToArgb().Equals(color_extern.ToArgb())) { x++; }
			//lo agregamos
			width += x;
			x = circle.X;
			//obtenemos del inicio del mapa al inicio del circulo
			while(x > 0 && !bmp.GetPixel(x, circle.Y).ToArgb().Equals(color_extern.ToArgb())) { x--; }
			//obtenemos del inicio del mapa al inicio del circulo
			
			//lo restamos y obtenemos la anchura del circulo
			width -= x;
			
			//con el operador ternario verificamos si es un circulo (10 pixeles de diferencia en susdiametros)
			margin_error = circle.R*2 - width;
			//r2 = width/2;
			//nos regresa true si la diferencia entre la altura y anchura es menor a 10 pixeles
			return marginErrorPixels(margin_error);
		}

		void drawCenter(Figure circle) {
			//da el ancho del punto central de cada circulo
			const int WIDTH = 20;//7
			for(int i = circle.X - WIDTH; i < circle.X + WIDTH; i++) {
				for(int j = circle.Y - WIDTH; j < circle.Y + WIDTH; j++) {
					if(i >= 0 && i < bmp.Width && j >= 0 && j < bmp.Height) {
						//pinta los pixeles
						bmp.SetPixel(i,j, Color.Purple);
					}
				}
			}
		}
		
		void fillCircle(Figure circle, Color color) {
			int x, limit;
			//aumentamos el radio para evadir el sesgo
			//circle.R -= 23;
			//int radio = 25;
			for(int y = circle.Y-circle.R; y <= circle.Y; y++) {
				x = circle.X;
				limit = limitXInCircle(circle.R, circle.Y, y);
				while(x <= limit+circle.X){
					//usando una cuarta pate e l circulo dibujo dentro de los 4 cuadrantes
						pintar(circle.X*2-x, y, color);//cuadrante 2
					
						pintar(circle.X*2-x, circle.Y*2-y, color);//cuadrante 3
					
						pintar(x,  circle.Y*2-y, color);//cuadrante 4
					
						pintar(x, y, color);//cuadrante 1
					x++;
				}
			}
		}
		
		int limitXInCircle(int r, int y1, int y2) { return (int)Math.Sqrt(Math.Pow(r, 2) - Math.Pow(y2-y1, 2)); }
				
		bool marginErrorPixels(int margin_error) { return margin_error >= -10 && margin_error <= 10; }

		void DDA(Figure c1, Figure c2, Color color) {
			int x1 = c1.X, y1 = c1.Y, x2 = c2.X, y2 = c2.Y;
			
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
				pintar((int)x, (int)y, color);
				x += ax;
				y += ay;
				i++;
				
				//genera una simple aimacion 
				//if(i%40 == 0)
				// 	pictureBoxOrigen.Refresh();
			}
			pictureBoxOrigen.Refresh();	
		}
		
		void circuitCircles(Figure c1, Figure c2, Color color) {
			int x1 = c1.X, y1 = c1.Y, x2 = c2.X, y2 = c2.Y;
			
			float ax, ay, x, y, res, i = 0;
			
			if(Math.Abs(x2 - x1) >= Math.Abs(y2 - y1)) {
				res = Math.Abs(x2 - x1);
			} else {
				res = Math.Abs(y2 - y1);
			}
			
			ax = (x2 - x1) / res;
			ay = (y2 - y1) / res;
			x = (float)x1;
			y = (float)y1;
			

			//Brush b = new SolidBrush(color);
			Graphics g = Graphics.FromImage(bmp);
			
			while(i <= res) {
				g.Clear(Color.Transparent);
				g.DrawImage(images[(int)i%images.Count], x-c1.R,    y-c1.R,    c1.R*2, c1.R*2);
				//g.FillEllipse(b,  x-c1.R,    y-c1.R,    c1.R*2, c1.R*2);
				
				x += ax;
				y += ay;
				i++;
				
				//genera una simple aimacion 
				if(i%17 == 0)
					pictureBoxOrigen.Refresh();
			}
			g.Clear(Color.Transparent);
			g.Dispose();
		}
		
		
		bool collisionDDA(Figure c1, Figure c2, Bitmap bmp_) {
			float r1 = c1.R + 5, r2 = c2.R + 5;

			
			int x1 = c1.X, y1 = c1.Y, x2 = c2.X, y2 = c2.Y;
			float ax, ay, x, y, res, i = 0, distanceLineActual;
			
			
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
				distanceLineActual = c1.distance((int)x, (int)y);
				if(distanceLineActual > r1 && distanceLineActual < c1.distance(c2)-r2) {
					//este condicional impide el analizis dentro del area de los circulos
					//esto evitara notar colisiones con el mismo circulo
					if(collision((int)x, (int)y, bmp_))
						return true;
					if(collision((int)(x + ax), (int)y, bmp_))
						return true;
				}
				
				x += ax;
				y += ay;
				i++;
			}
			return false;
		}
		
		bool collision(int x, int y, Bitmap bmp_) {
			//busca colision
			//si no es blanco, es una collision
			if(bmp_.GetPixel(x, y).ToArgb().Equals(Color.White.ToArgb()))
				return false;
			return true;
		}
		
		void pintar(int x, int y, Color color) {
			if(x >= 0 && x < bmp.Width && y >= 0 && y < bmp.Height)
				bmp.SetPixel(x, y, color);
		}
		
		void drawLbl() {
			//dibujar etiqueta
			int size = 22;
			Graphics grap = Graphics.FromImage(bmp);
			Font font = new Font("Arial", size);
			SolidBrush brocha = new SolidBrush(textColor);
			
			for(int i = 0; i < graph.getVertex().Count; i++)
				grap.DrawString(""+i, font, brocha, graph.getVertex()[i].Circle.X-(size/2+1), graph.getVertex()[i].Circle.Y-(size/2+4));
			pictureBoxOrigen.Refresh();
		}
		
		void generateEdges() {//genera las aristas entre los vertices
			//esta funcion se encarga tambien del closestPairPoints
			//esto dentro del primer if
			float weight = 0, minDist = bmp.Width;//peso -> ponderacion
			int id = -1;
			
			graph.matriz();//genero la matriz 
			
			for(int i = 0; i < graph.getVertex().Count; i++) {
				for(int j = i+1; j < graph.getVertex().Count; j++) {
					//obtengo la distancia entre el centro de los circulos
					weight = graph.getVertex()[i].Circle.distance(graph.getVertex()[j].Circle);
					
					if(weight < minDist) {
						minDist = weight;
						graph.closestPair(graph.getVertex()[i] , graph.getVertex()[j]);
					}
					
					if(!collisionDDA(graph.getVertex()[i].Circle, graph.getVertex()[j].Circle, bmp)) {
						//si encuentra una colision...
						graph.addEdge(++id, i, j, weight);
						graph.addEdge(++id, j, i, weight);
						//trazo la recta para validar las nuevas colisiones
						graph.Matriz[i,j] = 1;
						graph.Matriz[j,i] = 1;
					}
				}
			}
			//al terminar obtiene la menor distancia
			graph.Distance = minDist;
		}
		
		void drawEdges(Graph graph, Color color) {
			//dibuja los caminos del grafo
			for(int i = 0; i<graph.getVertex().Count;i++) {
				for(int j = 0; j<graph.getVertex()[i].EL.Count;j++) {
					DDA(graph.getVertex()[i].Circle, graph.getVertex()[i].EL[j].Destino.Circle, color);
				}
			}
		}
			
		void generateTreeView() {
			treeViewCircles.BeginUpdate();
			for(int i = 0; i<graph.getVertex().Count;i++) {
				treeViewCircles.Nodes.Add("Origen: "+graph.getVertex()[i].Id);
				for(int j = 0; j<graph.getVertex()[i].EL.Count;j++) {
					treeViewCircles.Nodes[i].Nodes.Add("Destino: "+graph.getVertex()[i].EL[j].Destino.Id + " -> " + graph.getVertex()[i].EL[j].Weight);
				}
			}
			treeViewCircles.EndUpdate();
		}
		
		bool pixelInArea(Figure c1) {
			//calcula coliciones entre 2 circulos o un circulo y un pixel
			foreach(Figure c in figures) {
				if(c.collision(c1)) {
					return true;
				}
			}
			return false;
		}
		
		Figure pixelInArea2(Figure c1) {
			//calcula coliciones entre 2 circulos o un circulo y un pixel
			foreach(Figure c in figures) {
				if(c.collision(c1)) {
					return c;
				}
			}
			return null;
		}
		
		bool circuitHamiltonian(int oneVertex) {
			
			//me genera los subgrafos...
			MessageBox.Show(graph.subGrafos());
			
			int subGrafoCount = graph.getVertex()[oneVertex].subGrafo.Count;
			
			if(subGrafoCount < 2) {
				return false;
			}
			
			//guarda el camino mas corto y el ultimo para hacer las comparaciones
			Hamilton hamilton = new Hamilton();
			Hamilton ultimo = new Hamilton();
			bool existeCamino = false;
			
			//creamos el inicio del camino...
			Graph circuit = new Graph();
			//creamos un vertice auxiliar
			Vertex aux = new Vertex();
			//agregamos el vertice seleccionado
			circuit.addVertex(graph.getVertex()[oneVertex]);
			//inicio desde el vertice seleccionado
			//cada vertice tiene un id
			int count, id = -1, i = oneVertex;//
						
			Lambda Pop = () => {
				//si no encontro ni un camino regreso al vertice anterior
				//primero obtengo su id, para comenzar las conexiones desde el siguiente
				id = circuit.getVertex().Last().Id;
				//hago pop
				circuit.getVertex().Remove(circuit.getVertex().Last());
				//pop al peso
				//mi i regresara al ultimo vertice
				if(circuit.getVertex().Count > 0) {
					//en el ultimo caso estara vacio
					i = circuit.getVertex().Last().Id;
				}
			};
			
			do {
				count = 0;//cuenta los caminos de cada vertice 
				for(int j = 0; j < graph.getVertex()[i].EL.Count ; j++) {
					//si ya lo contamos saltarlo
					if(id == graph.getVertex()[i].EL.Last().Destino.Id) {
						Pop();
						//validacion
						break;
					}
					//nos lanzara los pops necesarios
					
					if(graph.getVertex()[i].EL[j].Destino.Id <= id) {
						//si ya paso por los puntos anteriores es obligatorio no pasar por ellos de nuevo
						//nuestro contador nos avisara por cuantos ya paso
						count++;
						continue;
					}
					
					//genero el auxiliar...
					aux = graph.getVertex()[i].EL[j].Destino;
					
					if(!circuit.vertexInCircuit(aux)) {
						//si el vertice no esta dentro del grafo entonces
						//y paso al siguiente
						circuit.addVertex(aux);
						i = aux.Id;
						count = 0;
						id = -1;//cuando se agrega un vertice se elimina el NO posible anterior
						break;
					} else {
						count++;
					}
					
					if(count  == graph.getVertex()[i].EL.Count) {
						Pop();
						break;
					}
				}
			
				if(circuit.getVertex().Count == subGrafoCount) {
					if(!collisionDDA(circuit.getVertex().Last().Circle, graph.getVertex()[oneVertex].Circle, bmpBackGround)) {
						//si se puede conectar el circuito, agregar a la lista de posibles
						ultimo = new Hamilton(circuit);
						if(ultimo.ListCircuits.getVertex().Count == hamilton.ListCircuits.getVertex().Count) {
							if( ultimo.weight < hamilton.weight) {
								hamilton = ultimo;
							}
						} else if(ultimo.ListCircuits.getVertex().Count > hamilton.ListCircuits.getVertex().Count) {
								hamilton = ultimo;
						}
							existeCamino = true;
					}
					//hacer pop para analizar el siguiente
					Pop();
				}
			} while(circuit.getVertex().Count > 0);
			if(existeCamino) {
				if(subGrafoCount != graph.getVertex().Count) {
					MessageBox.Show("No existe grafo\npero si un subgrafo a trazar");
				}
				drawCircuit(hamilton, circuitLineColor);
				return true;
			}
			return false;
		}
		
		void drawCircuit(Hamilton h, Color color) {
			//dibuja los caminos del grafo
			String s = "";
			
			for(int i = 0; i < h.ListCircuits.getVertex().Count-1;i++) {
				s += h.ListCircuits.getVertex()[i].Id + ", ";
				circuitCircles(h.ListCircuits.getVertex()[i].Circle, h.ListCircuits.getVertex()[i+1].Circle, color);
			}
			lblCircuit.Text = "Circuito: " + s + h.ListCircuits.getVertex()[0].Id + " -> " + h.weight;
		}
		
		void PictureBoxOrigenMouseClick(object sender, MouseEventArgs e) {
			//MessageBox.Show("x: "+ e.X +"\ny: "+ e.Y);
			Point p = ajustarZoom(e);
			Figure c = new Figure();
			Graphics g = Graphics.FromImage(bmp);
			
			if((c = pixelInArea2( new Figure(p.X, p.Y, 1))) != null) {
				//drawCenter(f);
				Brush b = new SolidBrush(circuitLineColor);
				g.Clear(Color.Transparent);
				g.FillEllipse(b, c.X-(c.R+2), c.Y-(c.R+2), c.R*2+5, c.R*2+5);
				g.DrawImage(images[0], c.X-(c.R+2), c.Y-(c.R+2), c.R*2+5, c.R*2+5);
				pictureBoxOrigen.Image = bmp;
				idCircleSelct = figures.IndexOf(c);
			} else {
				g.Clear(Color.Transparent);
				pictureBoxOrigen.Image = bmp;
				idCircleSelct = -1;
			}
		}
		
		void ListBoxCirclesSelectedIndexChanged(object sender, EventArgs e) {
			idCircleSelct = listBoxCircles.SelectedIndex-1;
			Graphics g = Graphics.FromImage(bmp);
			
			if(idCircleSelct >= 0) {
				Brush b = new SolidBrush(circuitLineColor);
				Figure c = new Figure(graph.getVertex()[idCircleSelct].Circle);
				
				g.Clear(Color.Transparent);
				g.FillEllipse(b, c.X-(c.R+2), c.Y-(c.R+2), c.R*2+5, c.R*2+5);
				g.DrawImage(images[0], c.X-(c.R+2), c.Y-(c.R+2), c.R*2+5, c.R*2+5);
				
				pictureBoxOrigen.Image = bmp;				
			} else {
				g.Clear(Color.Transparent);
				pictureBoxOrigen.Image = bmp;
				idCircleSelct = -1;
			}
		}

		Point ajustarZoom(MouseEventArgs e) {
			int X, Y;
			int w_i = pictureBoxOrigen.Image.Width; 
            int h_i = pictureBoxOrigen.Image.Height;
            int w_c = pictureBoxOrigen.Width;
            int h_c = pictureBoxOrigen.Height;
             float imageRatio = w_i / (float)h_i;
            float containerRatio = w_c / (float)h_c; 

            if (imageRatio >= containerRatio) {
                float scaleFactor = w_c / (float)w_i;
                float scaledHeight = h_i * scaleFactor;
                float filler = Math.Abs(h_c - scaledHeight) / 2;  
                X = (int)(e.X / scaleFactor);
                Y = (int)((e.Y - filler) / scaleFactor);
            } else {
                float scaleFactor = h_c / (float)h_i;
                float scaledWidth = w_i * scaleFactor;
                float filler = Math.Abs(w_c - scaledWidth) / 2;
             	X = (int)((e.X - filler) / scaleFactor);
               	Y = (int)(e.Y / scaleFactor);
            }
            return new Point(X,Y);
		}		
		
	}
}
