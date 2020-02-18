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
			this.tabOptions = new System.Windows.Forms.TabPage();
			this.btnTextColor = new System.Windows.Forms.Button();
			this.lblColorText = new System.Windows.Forms.Label();
			this.lblColorLine = new System.Windows.Forms.Label();
			this.btnColor = new System.Windows.Forms.Button();
			this.close = new System.Windows.Forms.Label();
			this.listBoxCircles = new System.Windows.Forms.ListBox();
			this.lblLoad = new System.Windows.Forms.Label();
			this.lblAnalize = new System.Windows.Forms.Label();
			this.lblGenerate = new System.Windows.Forms.Label();
			this.openFileDialogImg = new System.Windows.Forms.OpenFileDialog();
			this.colorDialog = new System.Windows.Forms.ColorDialog();
			this.treeViewCircles = new System.Windows.Forms.TreeView();
			this.lblclosestPair = new System.Windows.Forms.Label();
			this.tabControl.SuspendLayout();
			this.tabOrigen.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxOrigen)).BeginInit();
			this.tabOptions.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabOrigen);
			this.tabControl.Controls.Add(this.tabOptions);
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
			this.tabOrigen.Text = "Analisis";
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
			// tabOptions
			// 
			this.tabOptions.Controls.Add(this.btnTextColor);
			this.tabOptions.Controls.Add(this.lblColorText);
			this.tabOptions.Controls.Add(this.lblColorLine);
			this.tabOptions.Controls.Add(this.btnColor);
			this.tabOptions.Location = new System.Drawing.Point(4, 29);
			this.tabOptions.Name = "tabOptions";
			this.tabOptions.Padding = new System.Windows.Forms.Padding(3);
			this.tabOptions.Size = new System.Drawing.Size(839, 603);
			this.tabOptions.TabIndex = 1;
			this.tabOptions.Text = "Opciones";
			this.tabOptions.UseVisualStyleBackColor = true;
			// 
			// btnTextColor
			// 
			this.btnTextColor.Location = new System.Drawing.Point(7, 112);
			this.btnTextColor.Name = "btnTextColor";
			this.btnTextColor.Size = new System.Drawing.Size(157, 51);
			this.btnTextColor.TabIndex = 3;
			this.btnTextColor.Text = "Color de texto";
			this.btnTextColor.UseVisualStyleBackColor = true;
			this.btnTextColor.Click += new System.EventHandler(this.BtnTextColorClick);
			// 
			// lblColorText
			// 
			this.lblColorText.Location = new System.Drawing.Point(182, 112);
			this.lblColorText.Name = "lblColorText";
			this.lblColorText.Size = new System.Drawing.Size(51, 53);
			this.lblColorText.TabIndex = 2;
			// 
			// lblColorLine
			// 
			this.lblColorLine.Location = new System.Drawing.Point(182, 55);
			this.lblColorLine.Name = "lblColorLine";
			this.lblColorLine.Size = new System.Drawing.Size(51, 51);
			this.lblColorLine.TabIndex = 1;
			// 
			// btnColor
			// 
			this.btnColor.Location = new System.Drawing.Point(6, 55);
			this.btnColor.Name = "btnColor";
			this.btnColor.Size = new System.Drawing.Size(158, 51);
			this.btnColor.TabIndex = 0;
			this.btnColor.Text = "Color de linea";
			this.btnColor.UseVisualStyleBackColor = true;
			this.btnColor.Click += new System.EventHandler(this.Button1Click);
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
			this.listBoxCircles.Size = new System.Drawing.Size(159, 164);
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
			this.lblAnalize.Text = "Generar";
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
			this.lblGenerate.Text = "Animar";
			this.lblGenerate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblGenerate.Click += new System.EventHandler(this.LblGenerateClick);
			this.lblGenerate.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblGenerateMouseDown);
			this.lblGenerate.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LblGenerateMouseUp);
			// 
			// openFileDialogImg
			// 
			this.openFileDialogImg.FileName = "dialog";
			// 
			// treeViewCircles
			// 
			this.treeViewCircles.Location = new System.Drawing.Point(869, 384);
			this.treeViewCircles.Name = "treeViewCircles";
			this.treeViewCircles.Size = new System.Drawing.Size(157, 268);
			this.treeViewCircles.TabIndex = 2;
			// 
			// lblclosestPair
			// 
			this.lblclosestPair.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblclosestPair.ForeColor = System.Drawing.Color.White;
			this.lblclosestPair.Location = new System.Drawing.Point(18, 657);
			this.lblclosestPair.Name = "lblclosestPair";
			this.lblclosestPair.Size = new System.Drawing.Size(839, 43);
			this.lblclosestPair.TabIndex = 8;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(30)))));
			this.ClientSize = new System.Drawing.Size(1041, 704);
			this.Controls.Add(this.lblclosestPair);
			this.Controls.Add(this.treeViewCircles);
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
			this.tabOptions.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label lblclosestPair;
		private System.Windows.Forms.Label lblColorText;
		private System.Windows.Forms.Button btnTextColor;
		private System.Windows.Forms.TreeView treeViewCircles;
		private System.Windows.Forms.Label lblColorLine;
		private System.Windows.Forms.ColorDialog colorDialog;
		private System.Windows.Forms.Button btnColor;
		private System.Windows.Forms.OpenFileDialog openFileDialogImg;
		private System.Windows.Forms.PictureBox pictureBoxOrigen;
		private System.Windows.Forms.Label lblGenerate;
		private System.Windows.Forms.Label lblAnalize;
		private System.Windows.Forms.Label lblLoad;
		private System.Windows.Forms.ListBox listBoxCircles;
		private System.Windows.Forms.Label close;
		private System.Windows.Forms.TabPage tabOptions;
		private System.Windows.Forms.TabPage tabOrigen;
		private System.Windows.Forms.TabControl tabControl;
		private System.Drawing.Bitmap bmp;
		private Figure circle = new Figure();
		private System.Collections.Generic.LinkedList<Figure> figures;
		private System.Drawing.Color lineColor = new System.Drawing.Color();
		private System.Drawing.Color textColor = new System.Drawing.Color();
		
	}
}
