﻿/*
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
		int x1=0,y1,x2,y2, idCircleSelct=0;
		Graph graph = new Graph();
		public MainForm() {
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			lineColor = Color.Red;
			circuitLineColor = Color.Blue;
			textColor = Color.White;
			lblColorLine.BackColor = lineColor;
			lblColorCircuit.BackColor = circuitLineColor;
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
			lblColorText.BackColor = colorDialog.Color;
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
			bmpAux = new Bitmap(openFileDialogImg.FileName);
			pictureBoxOrigen.Image = bmp;
			
			Clean();
		}
		
		void Clean() {
			//limpia la lista de datos
			listBoxCircles.Items.Clear();
			figures = new LinkedList<Figure>();
			treeViewCircles.Nodes.Clear();
			//limpio el grafo
			lblclosestPair.Text = "";
			graph.GetVertex().Clear();
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
								figures.AddLast(new Figure(circle));
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
            int circleInit = listBoxCircles.SelectedIndex-1;
            //limpio el circulo generado para hacer un recorrido limpio
			pictureBoxOrigen.Image = bmp;
            //generar animacion del grafo
            
            if(listBoxCircles.SelectedIndex == -1) {
            	MessageBox.Show("Primero debe seleccionar un Vertice.");
            	return;
            }
            //inicializo mi auxiliar
            bmpAux = new Bitmap(bmp);
            
            if(circuitHamiltonian(circleInit) == null) {
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
			
			//un circulo tambien es una figura eliptica
			//return isElipse();
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
				if(i%30 == 0)
					pictureBoxOrigen.Refresh();
			}			
		}
		
		void circuitCircles(Figure c1, Figure c2, Color color) {
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
			
			Pen pen = new Pen(color, 4);
			Pen penT = new Pen(Color.Transparent, 4);
			Graphics g = Graphics.FromImage(bmp);
			
	
		
			while(i <= res) {
				//g.DrawEllipse(penT, x-ax, y-ay, c1.R, c1.R);
				//g.DrawEllipse(pen, x, y, c1.R, c1.R);
				fillCircle(new Figure((int)(x-ax), (int)(y-ay), c1.R), Color.Transparent);
				fillCircle(new Figure((int)x, (int)y, c1.R), color);
				
				x += ax;
				y += ay;
				i++;
				
				//genera una simple aimacion 
				if(i%15 == 0)
					pictureBoxOrigen.Refresh();
			}
			fillCircle(new Figure((int)x, (int)y, c1.R), Color.Transparent);		
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
				if(distanceLineActual > r1 && distanceLineActual < c1.distance(c2)-r2)
					//este condicional impide el analizis dentro del area de los circulos
					//esto evitara notar colisiones con el mismo circulo
					if(collision((int)x, (int)y, bmp_))
						return true;
				
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
			
			for(int i = 0; i < graph.getVertexCount(); i++)
				grap.DrawString(""+i, font, brocha, graph.GetVertex()[i].Circle.X-(size/2+1), graph.GetVertex()[i].Circle.Y-(size/2+4));
			pictureBoxOrigen.Refresh();
		}
		
		void generateEdges() {//genera las aristas entre los vertices
			//esta funcion se encarga tambien del closestPairPoints
			//esto dentro del primer if
			float weight = 0, minDist = bmp.Width;//peso -> ponderacion
			int id = -1;
			for(int i = 0; i < graph.getVertexCount(); i++) {
				for(int j = i+1; j < graph.getVertexCount(); j++) {
					//obtengo la distancia entre el centro de los circulos
					weight = graph.GetVertex()[i].Circle.distance(graph.GetVertex()[j].Circle);
					
					if(weight < minDist) {
						minDist = weight;
						graph.closestPair(graph.GetVertex()[i] , graph.GetVertex()[j]);
					}
					
					if(!collisionDDA(graph.GetVertex()[i].Circle, graph.GetVertex()[j].Circle, bmp)) {
						//si encuentra una colision...
						graph.addEdge(++id, i, j, weight);
						graph.addEdge(++id, j, i, weight);
						//trazo la recta para validar las nuevas colisiones
					}
				}
			}
			//al terminar obtiene la menor distancia
			graph.Distance = minDist;
		}
		
		void drawEdges(Graph graph, Color color) {
			//dibuja los caminos del grafo
			for(int i = 0; i<graph.getVertexCount();i++) {
				for(int j = 0; j<graph.GetVertex()[i].EL.Count;j++) {
					DDA(graph.GetVertex()[i].Circle, graph.GetVertex()[i].EL[j].Destino.Circle, color);
				}
			}
		}
			
		void generateTreeView() {
			treeViewCircles.BeginUpdate();
			for(int i = 0; i<graph.getVertexCount();i++) {
				treeViewCircles.Nodes.Add("Origen: "+graph.GetVertex()[i].Id);
				for(int j = 0; j<graph.GetVertex()[i].EL.Count;j++) {
					treeViewCircles.Nodes[i].Nodes.Add("Destino: "+graph.GetVertex()[i].EL[j].Destino.Id + " -> " + graph.GetVertex()[i].EL[j].Weight);
				}
			}
			treeViewCircles.EndUpdate();
		}
		
		bool pixelInArea(Figure c1) {
			//calcula coliciones entre 2 circulos o un circulo y un pixel
			foreach(Figure circle in figures) {
				if(circle.collision(c1)) {
					return true;
				}
			}
			return false;
		}
		
		Graph circuitHamiltonian(int oneVertex) {
			//creamos el inicio del camino...
			Graph circuit = new Graph();
			//creamos un vertice auxiliar
			Vertex aux = new Vertex();
			//agregamos el vertice seleccionado
			circuit.addVertex(graph.GetVertex()[oneVertex]);
			//inicio desde el vertice seleccionado
			//cada vertice tiene un id
			int count, id = -1, i = oneVertex, size = graph.getVertexCount();//
			
			pictureBoxOrigen.Image = bmpBackGround;
			do {
				count = 0;//cuenta los caminos de cada vertice
				
				
				for(int j = 0; j < graph.GetVertex()[i].EL.Count ; j++) {
					//si ya lo contamos saltarlo
					if(id == graph.GetVertex()[i].EL.Last().Destino.Id) {
						id = circuit.GetVertex().Last().Id;
						//hago pop
						circuit.GetVertex().Remove(circuit.GetVertex().Last());
						//mi i regresara al ultimo vertice
						if(circuit.getVertexCount() > 0) {
							//en el ultimo caso estara vacio
							i = circuit.GetVertex().Last().Id;
						}
						break;
					}
					/*String s ="";
					foreach(Vertex v in circuit.GetVertex()) {
						s += " " + v.Id;
					}
					MessageBox.Show(s+"\nid="+id  +"\ni="+ graph.GetVertex()[i].Id+ "\norigen" + graph.GetVertex()[i].EL.Last().Origen.Id + " \ndestino="+ graph.GetVertex()[i].EL.Last().Destino.Id);
					*/
					//nos lanzara los pops necesarios
					
					
					if(graph.GetVertex()[i].EL[j].Destino.Id <= id) {
						//si ya paso por los puntos anteriores es obligatorio no pasar por ellos de nuevo
						//nuestro contador nos avisara por cuantos ya paso
						count++;
						continue;
					}
					
					//genero el auxiliar...
					aux = graph.GetVertex()[i].EL[j].Destino;
					
					if(!circuit.vertexInCircuit(aux) ) {
						//en caso contrario agregar
						//si el vertice no esta dentro del grafo entonces
						//lo agrego, y paso al siguiente
						circuit.addVertex(aux);
						i = aux.Id;
						count = 0;
						id = -1;//cuando se agrega un vertice se elimina el NO posible anterior
						break;
					} else {
						count++;
					}
					
					if(count  == graph.GetVertex()[i].EL.Count) {
						//si no encontro ni un camino regreso al vertice anterior
						//primero obtengo su id, para comenzar las conexiones desde el siguiente
						id = circuit.GetVertex().Last().Id;
						//hago pop
						circuit.GetVertex().Remove(circuit.GetVertex().Last());
						//mi i regresara al ultimo vertice
						if(circuit.getVertexCount() > 0) {
							//en el ultimo caso estara vacio
							i = circuit.GetVertex().Last().Id;
						}
						break;
					}
				}
				
				if(circuit.getVertexCount() == graph.getVertexCount()) {
					//si no hay colision al unir los puntos tendremos un circuito de hamilton
					
					if(!collisionDDA(circuit.GetVertex().Last().Circle, graph.GetVertex()[oneVertex].Circle, bmpBackGround)) {
						circuit.addVertex(graph.GetVertex()[oneVertex]);
					}else {
						id = circuit.GetVertex().Last().Id;
						//hago pop
						circuit.GetVertex().Remove(circuit.GetVertex().Last());
						//mi i regresara al ultimo vertice
						if(circuit.getVertexCount() > 0) {
							//en el ultimo caso estara vacio
							i = circuit.GetVertex().Last().Id;
						}
					}
				}
			} while(circuit.getVertexCount() < graph.getVertexCount()  &&  circuit.getVertexCount() > 0);
			pictureBoxOrigen.Image = bmp;
			//bmpBackGround = new Bitmap(bmp);
			drawCircuit(circuit, circuitLineColor);
			if(circuit.getVertexCount() > 0) {
				return circuit;
			} else {
				return null;
			}
		}
		
		void drawCircuit(Graph circuit, Color color) {
			//dibuja los caminos del grafo
			String s = "";
			//bmp = new Bitmap(bmpBackGround);
			//pictureBoxOrigen.Image = bmp;
			for(int i = 0; i < circuit.getVertexCount()-1;i++) {
				s += circuit.GetVertex()[i].Id + ", ";
				circuitCircles(circuit.GetVertex()[i].Circle, circuit.GetVertex()[i+1].Circle, color);
			}
			if(circuit.getVertexCount() > 0)
				lblCircuit.Text = "Circuito: " + s + circuit.GetVertex()[0].Id;
		}
		
		void PictureBoxOrigenMouseClick(object sender, MouseEventArgs e) {
			//MessageBox.Show("x: "+ e.X +"\ny: "+ e.Y);
			
			if(x1 == 0) {
				x1 = e.X;
				y1 = e.Y;
			} else {
				x2 = e.X;
				y2 = e.Y;
				
				//DDA(new Figure(x1, y1, 1), new Figure(x2, y2, 1));
				x1=0;
			}
			
		}
		
		void ListBoxCirclesSelectedIndexChanged(object sender, EventArgs e) {
			int idCircle = listBoxCircles.SelectedIndex-1;
			if(idCircle >= 0) {
				fillCircle(graph.GetVertex()[idCircleSelct].Circle, Color.Transparent);
				fillCircle(graph.GetVertex()[idCircle].Circle, circuitLineColor);
				pictureBoxOrigen.Image = bmp;
				idCircleSelct = idCircle;
				
			} else {
				fillCircle(graph.GetVertex()[idCircleSelct].Circle, Color.Transparent);
				pictureBoxOrigen.Image = bmp;
			}
		}
		
		
	}
}
