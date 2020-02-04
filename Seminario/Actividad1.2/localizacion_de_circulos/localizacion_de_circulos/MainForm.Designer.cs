/*
 * Creado por SharpDevelop.
 * Usuario: dagur
 * Fecha: 31/01/2020
 * Hora: 11:38 a. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
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
		private void InitializeComponent() {
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabOrigen = new System.Windows.Forms.TabPage();
			this.pictureBoxOrigen = new System.Windows.Forms.PictureBox();
			this.tabDestiny = new System.Windows.Forms.TabPage();
			this.pictureBoxDestiny = new System.Windows.Forms.PictureBox();
			this.close = new System.Windows.Forms.Label();
			this.listBoxCircles = new System.Windows.Forms.ListBox();
			this.lblLoad = new System.Windows.Forms.Label();
			this.lblAnalize = new System.Windows.Forms.Label();
			this.lblGenerate = new System.Windows.Forms.Label();
			this.openFileDialogImg = new System.Windows.Forms.OpenFileDialog();
			this.tabControl.SuspendLayout();
			this.tabOrigen.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxOrigen)).BeginInit();
			this.tabDestiny.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxDestiny)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabOrigen);
			this.tabControl.Controls.Add(this.tabDestiny);
			this.tabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tabControl.Location = new System.Drawing.Point(14, 14);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(847, 636);
			this.tabControl.TabIndex = 1;
			// 
			// tabOrigen
			// 
			this.tabOrigen.Controls.Add(this.pictureBoxOrigen);
			this.tabOrigen.ForeColor = System.Drawing.Color.Black;
			this.tabOrigen.Location = new System.Drawing.Point(4, 29);
			this.tabOrigen.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
			this.tabOrigen.Name = "tabOrigen";
			this.tabOrigen.Padding = new System.Windows.Forms.Padding(3);
			this.tabOrigen.Size = new System.Drawing.Size(839, 603);
			this.tabOrigen.TabIndex = 0;
			this.tabOrigen.Text = "Origen";
			this.tabOrigen.UseVisualStyleBackColor = true;
			// 
			// pictureBoxOrigen
			// 
			this.pictureBoxOrigen.Location = new System.Drawing.Point(0, 0);
			this.pictureBoxOrigen.Name = "pictureBoxOrigen";
			this.pictureBoxOrigen.Size = new System.Drawing.Size(839, 603);
			this.pictureBoxOrigen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxOrigen.TabIndex = 1;
			this.pictureBoxOrigen.TabStop = false;
			// 
			// tabDestiny
			// 
			this.tabDestiny.Controls.Add(this.pictureBoxDestiny);
			this.tabDestiny.Location = new System.Drawing.Point(4, 29);
			this.tabDestiny.Name = "tabDestiny";
			this.tabDestiny.Padding = new System.Windows.Forms.Padding(3);
			this.tabDestiny.Size = new System.Drawing.Size(839, 603);
			this.tabDestiny.TabIndex = 1;
			this.tabDestiny.Text = "Destino";
			this.tabDestiny.UseVisualStyleBackColor = true;
			// 
			// pictureBoxDestiny
			// 
			this.pictureBoxDestiny.Location = new System.Drawing.Point(0, 0);
			this.pictureBoxDestiny.Name = "pictureBoxDestiny";
			this.pictureBoxDestiny.Size = new System.Drawing.Size(839, 603);
			this.pictureBoxDestiny.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxDestiny.TabIndex = 1;
			this.pictureBoxDestiny.TabStop = false;
			// 
			// close
			// 
			this.close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(35)))));
			this.close.Cursor = System.Windows.Forms.Cursors.Hand;
			this.close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.close.Font = new System.Drawing.Font("Arial Rounded MT Bold", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(28)))), ((int)(((byte)(74)))));
			this.close.Location = new System.Drawing.Point(1001, 0);
			this.close.Name = "close";
			this.close.Size = new System.Drawing.Size(28, 34);
			this.close.TabIndex = 1;
			this.close.Text = "x";
			this.close.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.close.Click += new System.EventHandler(this.CloseClick);
			// 
			// listBoxCircles
			// 
			this.listBoxCircles.FormattingEnabled = true;
			this.listBoxCircles.ItemHeight = 16;
			this.listBoxCircles.Location = new System.Drawing.Point(867, 214);
			this.listBoxCircles.Name = "listBoxCircles";
			this.listBoxCircles.Size = new System.Drawing.Size(159, 436);
			this.listBoxCircles.TabIndex = 5;
			// 
			// lblLoad
			// 
			this.lblLoad.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblLoad.ForeColor = System.Drawing.Color.White;
			this.lblLoad.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblLoad.Location = new System.Drawing.Point(867, 43);
			this.lblLoad.Name = "lblLoad";
			this.lblLoad.Size = new System.Drawing.Size(157, 48);
			this.lblLoad.TabIndex = 6;
			this.lblLoad.Text = "Cargar";
			this.lblLoad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblLoad.Click += new System.EventHandler(this.clickLoad);
			this.lblLoad.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblLoadMouseDown);
			this.lblLoad.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LblLoadMouseUp);
			// 
			// lblAnalize
			// 
			this.lblAnalize.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblAnalize.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAnalize.ForeColor = System.Drawing.Color.White;
			this.lblAnalize.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblAnalize.Location = new System.Drawing.Point(869, 96);
			this.lblAnalize.Name = "lblAnalize";
			this.lblAnalize.Size = new System.Drawing.Size(157, 48);
			this.lblAnalize.TabIndex = 7;
			this.lblAnalize.Text = "Analizar";
			this.lblAnalize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblAnalize.Click += new System.EventHandler(this.LblAnalizeClick);
			this.lblAnalize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblAnalizeMouseDown);
			this.lblAnalize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LblAnalizeMouseUp);
			// 
			// lblGenerate
			// 
			this.lblGenerate.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblGenerate.ForeColor = System.Drawing.Color.White;
			this.lblGenerate.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblGenerate.Location = new System.Drawing.Point(869, 149);
			this.lblGenerate.Name = "lblGenerate";
			this.lblGenerate.Size = new System.Drawing.Size(157, 48);
			this.lblGenerate.TabIndex = 7;
			this.lblGenerate.Text = "Generar";
			this.lblGenerate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblGenerate.Click += new System.EventHandler(this.LblGenerateClick);
			this.lblGenerate.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblGenerateMouseDown);
			this.lblGenerate.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LblGenerateMouseUp);
			// 
			// openFileDialogImg
			// 
			this.openFileDialogImg.FileName = "openFileDialog";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(30)))));
			this.ClientSize = new System.Drawing.Size(1041, 664);
			this.Controls.Add(this.lblGenerate);
			this.Controls.Add(this.lblLoad);
			this.Controls.Add(this.lblAnalize);
			this.Controls.Add(this.listBoxCircles);
			this.Controls.Add(this.close);
			this.Controls.Add(this.tabControl);
			this.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.ForeColor = System.Drawing.Color.Black;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "MainForm";
			this.Text = "localizacion de circulos";
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainFormMouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainFormMouseMove);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainFormMouseUp);
			this.tabControl.ResumeLayout(false);
			this.tabOrigen.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxOrigen)).EndInit();
			this.tabDestiny.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxDestiny)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.OpenFileDialog openFileDialogImg;
		private System.Windows.Forms.PictureBox pictureBoxDestiny;
		private System.Windows.Forms.PictureBox pictureBoxOrigen;
		private System.Windows.Forms.Label lblGenerate;
		private System.Windows.Forms.Label lblAnalize;
		private System.Windows.Forms.Label lblLoad;
		private System.Windows.Forms.ListBox listBoxCircles;
		private System.Windows.Forms.Label close;
		private System.Windows.Forms.TabPage tabDestiny;
		private System.Windows.Forms.TabPage tabOrigen;
		private System.Windows.Forms.TabControl tabControl;
		private System.Drawing.Bitmap bmp;
		private Figure figure = new Figure();
		private int r2;
		
		
	}
}
