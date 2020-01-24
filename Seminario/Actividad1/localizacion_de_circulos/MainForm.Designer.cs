/*
 * Creado por SharpDevelop.
 * Usuario: dagur
 * Fecha: 23/01/2020
 * Hora: 06:48 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
 using System.Drawing;
namespace localizacion_de_circulos
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		
		struct Position {
		    public int x;
		    public int y;
		}
		
		private void InitializeComponent()
		{
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabOrigin = new System.Windows.Forms.TabPage();
			this.pictureBoxOrigin = new System.Windows.Forms.PictureBox();
			this.tabDestiny = new System.Windows.Forms.TabPage();
			this.pictureBoxDestiny = new System.Windows.Forms.PictureBox();
			this.btn_load = new System.Windows.Forms.Button();
			this.openFileDialogImg = new System.Windows.Forms.OpenFileDialog();
			this.btn_analyze = new System.Windows.Forms.Button();
			this.btn_generate = new System.Windows.Forms.Button();
			this.listBoxCircles = new System.Windows.Forms.ListBox();
			this.tabControl.SuspendLayout();
			this.tabOrigin.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxOrigin)).BeginInit();
			this.tabDestiny.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxDestiny)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabOrigin);
			this.tabControl.Controls.Add(this.tabDestiny);
			this.tabControl.Location = new System.Drawing.Point(21, 22);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(700, 530);
			this.tabControl.TabIndex = 0;
			// 
			// tabOrigin
			// 
			this.tabOrigin.Controls.Add(this.pictureBoxOrigin);
			this.tabOrigin.Location = new System.Drawing.Point(4, 25);
			this.tabOrigin.Name = "tabOrigin";
			this.tabOrigin.Padding = new System.Windows.Forms.Padding(3);
			this.tabOrigin.Size = new System.Drawing.Size(692, 501);
			this.tabOrigin.TabIndex = 0;
			this.tabOrigin.Text = "Origen";
			this.tabOrigin.UseVisualStyleBackColor = true;
			// 
			// pictureBoxOrigin
			// 
			this.pictureBoxOrigin.Location = new System.Drawing.Point(10, 10);
			this.pictureBoxOrigin.Name = "pictureBoxOrigin";
			this.pictureBoxOrigin.Size = new System.Drawing.Size(670, 480);
			this.pictureBoxOrigin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxOrigin.TabIndex = 0;
			this.pictureBoxOrigin.TabStop = false;
			// 
			// tabDestiny
			// 
			this.tabDestiny.Controls.Add(this.pictureBoxDestiny);
			this.tabDestiny.Location = new System.Drawing.Point(4, 25);
			this.tabDestiny.Name = "tabDestiny";
			this.tabDestiny.Padding = new System.Windows.Forms.Padding(3);
			this.tabDestiny.Size = new System.Drawing.Size(692, 501);
			this.tabDestiny.TabIndex = 1;
			this.tabDestiny.Text = "Destino";
			this.tabDestiny.UseVisualStyleBackColor = true;
			// 
			// pictureBoxDestiny
			// 
			this.pictureBoxDestiny.Location = new System.Drawing.Point(10, 10);
			this.pictureBoxDestiny.Name = "pictureBoxDestiny";
			this.pictureBoxDestiny.Size = new System.Drawing.Size(670, 480);
			this.pictureBoxDestiny.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxDestiny.TabIndex = 0;
			this.pictureBoxDestiny.TabStop = false;
			// 
			// btn_load
			// 
			this.btn_load.Location = new System.Drawing.Point(739, 47);
			this.btn_load.Name = "btn_load";
			this.btn_load.Size = new System.Drawing.Size(139, 40);
			this.btn_load.TabIndex = 1;
			this.btn_load.Text = "Cargar";
			this.btn_load.UseVisualStyleBackColor = true;
			this.btn_load.Click += new System.EventHandler(this.BtnLoadClick);
			// 
			// openFileDialogImg
			// 
			this.openFileDialogImg.FileName = "open_file";
			// 
			// btn_analyze
			// 
			this.btn_analyze.AutoSize = true;
			this.btn_analyze.Location = new System.Drawing.Point(739, 102);
			this.btn_analyze.Name = "btn_analyze";
			this.btn_analyze.Size = new System.Drawing.Size(139, 40);
			this.btn_analyze.TabIndex = 1;
			this.btn_analyze.Text = "Analizar";
			this.btn_analyze.UseVisualStyleBackColor = true;
			this.btn_analyze.Click += new System.EventHandler(this.BtnAnalyzeClick);
			// 
			// btn_generate
			// 
			this.btn_generate.Location = new System.Drawing.Point(739, 157);
			this.btn_generate.Name = "btn_generate";
			this.btn_generate.Size = new System.Drawing.Size(139, 40);
			this.btn_generate.TabIndex = 2;
			this.btn_generate.Text = "Generar";
			this.btn_generate.UseVisualStyleBackColor = true;
			this.btn_generate.Click += new System.EventHandler(this.BtnGenerateClick);
			// 
			// listBoxCircles
			// 
			this.listBoxCircles.FormattingEnabled = true;
			this.listBoxCircles.ItemHeight = 16;
			this.listBoxCircles.Location = new System.Drawing.Point(739, 215);
			this.listBoxCircles.Name = "listBoxCircles";
			this.listBoxCircles.Size = new System.Drawing.Size(139, 324);
			this.listBoxCircles.TabIndex = 3;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(894, 570);
			this.Controls.Add(this.listBoxCircles);
			this.Controls.Add(this.btn_generate);
			this.Controls.Add(this.btn_analyze);
			this.Controls.Add(this.btn_load);
			this.Controls.Add(this.tabControl);
			this.Name = "MainForm";
			this.Text = "localizacion_de_circulos";
			this.tabControl.ResumeLayout(false);
			this.tabOrigin.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxOrigin)).EndInit();
			this.tabDestiny.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxDestiny)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ListBox listBoxCircles;
		private System.Windows.Forms.Button btn_generate;
		private System.Windows.Forms.Button btn_analyze;
		private System.Windows.Forms.OpenFileDialog openFileDialogImg;
		private System.Windows.Forms.Button btn_load;
		private System.Windows.Forms.PictureBox pictureBoxDestiny;
		private System.Windows.Forms.PictureBox pictureBoxOrigin;
		private System.Windows.Forms.TabPage tabDestiny;
		private System.Windows.Forms.TabPage tabOrigin;
		private System.Windows.Forms.TabControl tabControl;
		private Bitmap bmp;
		private Position pos;
		
		
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
						searchCircle(x, y);
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
		
		void searchCircle(int x, int y) {
			int x_f = x;//x final
			int y_f = y;//y final
			
			//mientras que no sobrepase el alto de la imagen seguira buscando el tope inferior del circulo
			while(y_f < bmp.Height && bmp.GetPixel(x,y_f).ToArgb().Equals(Color.Black.ToArgb())) { y_f++; }
			
			//mienstras que no sobrepase el ancho de la imagen seguira buscado el tope superior derecho
			while(x_f < bmp.Width && bmp.GetPixel(x_f,y).ToArgb().Equals(Color.Black.ToArgb())) { x_f++; }
			
			//nos genera el centro en X
			pos.x = (x_f+x)/2;
			//y en Y
			pos.y = (y_f+y)/2;
			//guardamos el raidio
			int radius = pos.y-y;
			
			//si detecta que es un circulo y no omite elruido
			if(isCircle(pos, y_f-y) && radius > 10) {
				string circle = "("+pos.x+","+pos.y+") -> "+(y_f-y);
				//guarda en la lista los datos del circulo
				listBoxCircles.Items.Add(circle);
				//rellena el cruclo
				fillCircle(pos, radius);
				//dibuja el centro
				drawCenter(pos);
			}
		}
		
		void drawCenter(Position pos) {
			//da el ancho del punto central de cada circulo
			const int WIDTH = 7;
			for(int i = pos.x - WIDTH; i < pos.x + WIDTH; i++) {
				for(int j = pos.y - WIDTH; j < pos.y + WIDTH; j++) {
					if(i >= 0 && i < bmp.Width && j >= 0 && j < bmp.Height) {
						//pinta los pixeles
						bmp.SetPixel(i,j, Color.BlueViolet);
					}
				}
			}
		}
		
		void fillCircle(Position posInit, int radius) {
			//el corredor se situal en la posicion inicial
			Position runner = posInit;
			//despues se coloca en el punto superior
			runner.y -= radius;
			
			//e ira desendiendo hasta colorear todo el circulo o toparse con el fin del mapa
			while(runner.y <= posInit.y+radius && runner.y < bmp.Height) {
				//resetea la posicion x
				runner.x = posInit.x;
				while(runner.x < bmp.Width && bmp.GetPixel(runner.x, runner.y).ToArgb().Equals(Color.Black.ToArgb())) {
					//colorea la mitad derecha de la fila
					bmp.SetPixel(runner.x++,runner.y, Color.Cyan);
				}
				
				//reseteal el valor de la x de nuevo
				runner.x = posInit.x-1;
				while( runner.x > 0 && bmp.GetPixel(runner.x, runner.y).ToArgb().Equals(Color.Black.ToArgb())) {
					//para colorear la mitd izquierda
					bmp.SetPixel(runner.x--,runner.y, Color.Cyan);
				}
				
				//baja a la siguiente file
				runner.y++;
			}
		}
		
		bool isCircle(Position center, int height) {
			//queremos buscar el ancho del circulo
			int width = 0, x = center.x;
			
			//obtenemos del inicio del mapa hasta el fin del circulo (anchura)
			while(x < bmp.Width && bmp.GetPixel(x, center.y).ToArgb().Equals(Color.Black.ToArgb())) { x++; }
			//lo agregamos
			width += x;
		
			//obtenemos del inicio del mapa al inicio del circulo
			while( center.x > 0 && bmp.GetPixel(center.x, center.y).ToArgb().Equals(Color.Black.ToArgb())) { center.x--; }
			//lo restamos y obtenemos la anchura del circulo
			width -= center.x;
			
			//con el operador ternario verificamos si es un circulo (10 pixeles de diferencia en susdiametros)
			return height - width <= 10 ? true : false;
		}
		
		
	}
}
