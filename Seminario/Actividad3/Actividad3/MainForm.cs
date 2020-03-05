/*
 * Creado por SharpDevelop.
 * Usuario: david
 * Fecha: 03/03/2020
 * Hora: 08:00 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Actividad3 {
	
	public partial class MainForm : Form {
		int mov, movX, movY;
		public MainForm() {
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			resize();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void clear() {
			graph.Clear();
			graph.getVertex().Clear();
			figures.Clear();
		}
		
		void LblLoadImgClick(object sender, EventArgs e) {
			if(openFileImage.ShowDialog() == DialogResult.OK) {
				clear();
				//funcion para limpiar el analisis anterior...
				tabControl.SelectedIndex = 0;
				bmp = new Bitmap(openFileImage.FileName);
				bmpBackGround = new Bitmap(openFileImage.FileName);
				pictureBoxInit.Image = bmp;
				
				pictureBoxSecond.Image = bmp;
				
				//analiso la imagen en busca de circulos
				analizeImg();
				//genera las lineans con DDA
				generateEdges();
				//insertar etiquetas
				drawLbl();
				//dibujo los caminos
				drawEdges(graph);
				pictureBoxSecond.BackgroundImage = bmpBackGround;
				pictureBoxSecond.BackgroundImageLayout = ImageLayout.Zoom;
				bmp = new Bitmap(bmpBackGround);
				pictureBoxSecond.Image = bmp;
				tabControl.SelectedIndex = 1;
			}
		}
		
		void analizeImg() {
			int id = 0;
	        for (int y = 0; y < bmp.Height; y++) {
	            for (int x = 0; x < bmp.Width; x++) {
					if(bmp.GetPixel(x,y).ToArgb().Equals(Color.Black.ToArgb())) {
						//
						if(pixelInArea( new Figure(x, y, 1)) == null) {
							circle.searchCenter(x, y, bmp);
							if(circle.isCircle(bmp)) {
								figures.Add(new Figure(circle));
								graph.addVertex(new Figure(circle),  id);
								id++;
							}
						}
					}
				}
			}
			
		}
		
		void LblGenerateTreeClick(object sender, EventArgs e) {
			/*if(idCircleSelct == -1) {
				MessageBox.Show("Debe seleccionar un circulo primero");
				return;
			}
			float diametro = (graph.getVertex()[idCircleSelct].Circle.R*2);
			float total = diametro * graph.getVertex()[idCircleSelct].EL.Count;*/
			overlayTree o = new overlayTree(0);
			o.ShowDialog();
			if(o.tree == -1) {
				MessageBox.Show("tienes que seleccionar");
				return;
			} else if(o.tree == 0) {
				MessageBox.Show("Prim");
			} else {
				MessageBox.Show("Kruskal");
				Kruskal k = new Kruskal(graph);
				k.kruskal();
				foreach(Edge ee in k.minim) {
					DDA(ee.Origen.Circle, ee.Destino.Circle, Color.Blue, 10, 20);
				}
			}
			
		}
		
		
		void LblAnimateClick(object sender, EventArgs e) {
			
		}
		
		void drawLbl() {
			//dibujar etiqueta
			
			int size = graph.getVertex()[0].Circle.R+3;
			Graphics grap = Graphics.FromImage(bmpBackGround);
			if (grap == null)
				return;
			Font font = new Font("Arial", size);
			SolidBrush brocha = new SolidBrush(Color.White);
			
			for(int i = 0; i < graph.getVertex().Count; i++) {
				if(i < 10)
					grap.DrawString(""+i, font, brocha, graph.getVertex()[i].Circle.X-(size/3+size/4), graph.getVertex()[i].Circle.Y-(size/2+size/5));
				else
					grap.DrawString(""+i, font, brocha, graph.getVertex()[i].Circle.X-(size/2+10), graph.getVertex()[i].Circle.Y-(size/2+4));
			}
			pictureBoxSecond.Refresh();
		}
		
		void generateEdges() {
			//genera las aristas entre los vertices
			float weight = 0;//peso -> ponderacion
			int id = -1;
			
			for(int i = 0; i < graph.getVertex().Count; i++) {
				for(int j = i+1; j < graph.getVertex().Count; j++) {
					//obtengo la distancia entre el centro de los circulos
					weight = graph.getVertex()[i].Circle.distance(graph.getVertex()[j].Circle);
					
					if(!collisionDDA(graph.getVertex()[i].Circle, graph.getVertex()[j].Circle, bmp)) {
						//si no encuentra una colision...
						graph.addEdge(++id, i, j, weight);
						//graph.addEdge(++id, j, i, weight);
					}
				}
			}
		}
		
		void drawEdges(Graph graph) {
			//dibuja los caminos del grafo
			for(int i = 0; i<graph.getVertex().Count;i++) {
				for(int j = 0; j<graph.getVertex()[i].EL.Count;j++) {
					DDA(graph.getVertex()[i].Circle, graph.getVertex()[i].EL[j].Destino.Circle, Color.Red, 2, 1);
				}
			}
		}
		
		void DDA(Figure c1, Figure c2, Color color, int R, int parpadeo) {
			float r1 = c1.R + R/2, r2 = c2.R + R/2;
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
			
			Graphics g = Graphics.FromImage(bmpBackGround);
			
			Brush b;
			
			b = R == 2 ?  new SolidBrush(Color.Red) : new SolidBrush(Color.Blue);
			
				
			
			while(i <= res) {
				distanceLineActual = c1.distance((int)x, (int)y);
				if(distanceLineActual > r1 && distanceLineActual < c1.distance(c2)-r2) {
					//este condicional impide el analizis dentro del area de los circulos
					//g.Clear(Color.Transparent);
					g.FillEllipse(b, x-(R/2), y-(R/2), R, R);
				}
				
				x += ax;
				y += ay;
				i++;
				
				//genera una simple aimacion 
				if(i%parpadeo == 0)
				 	pictureBoxSecond.Refresh();
			}
			pictureBoxSecond.Refresh();	
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
		
		Figure pixelInArea(Figure c1) {
			//calcula coliciones entre 2 circulos o un circulo y un pixel
			foreach(Figure c in figures) {
				if(c.collision(c1)) {
					return c;
				}
			}
			return null;
		}
		
		Point ajustarZoom(MouseEventArgs e) {
			int X, Y;
			int w_i = pictureBoxSecond.Image.Width; 
            int h_i = pictureBoxSecond.Image.Height;
            int w_c = pictureBoxSecond.Width;
            int h_c = pictureBoxSecond.Height;
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
		
		
		void PictureBoxSecondMouseClick(object sender, MouseEventArgs e) {
			Point p = ajustarZoom(e);
			Figure c = new Figure();
			Graphics g = Graphics.FromImage(bmp);
			
			if((c = pixelInArea( new Figure(p.X, p.Y, 1))) != null) {
				Brush b = new SolidBrush(Color.Red);
				g.Clear(Color.Transparent);
				g.FillEllipse(b, c.X-(c.R+4), c.Y-(c.R+4), c.R*2+8, c.R*2+8);
				idCircleSelct = figures.IndexOf(c);
			} else {
				g.Clear(Color.Transparent);
				idCircleSelct = -1;
			}
			pictureBoxSecond.Refresh();
		}
	}
}
