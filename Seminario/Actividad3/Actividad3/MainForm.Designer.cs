/*
 * Creado por SharpDevelop.
 * Usuario: dagur
 * Fecha: 03/03/2020
 * Hora: 08:00 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
 
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Actividad3
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
		private void InitializeComponent()
		{
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabInit = new System.Windows.Forms.TabPage();
			this.pictureBoxInit = new System.Windows.Forms.PictureBox();
			this.tabSecond = new System.Windows.Forms.TabPage();
			this.pictureBoxSecond = new System.Windows.Forms.PictureBox();
			this.tabResult = new System.Windows.Forms.TabPage();
			this.pictureBoxPrim = new System.Windows.Forms.PictureBox();
			this.pictureBoxKruskal = new System.Windows.Forms.PictureBox();
			this.lblMinimized = new System.Windows.Forms.Label();
			this.lblMaximized = new System.Windows.Forms.Label();
			this.lblClosed = new System.Windows.Forms.Label();
			this.panelSize = new System.Windows.Forms.Panel();
			this.lblLoadImg = new System.Windows.Forms.Label();
			this.lblGenerateTree = new System.Windows.Forms.Label();
			this.lblAnimate = new System.Windows.Forms.Label();
			this.panelbtn = new System.Windows.Forms.Panel();
			this.openFileImage = new System.Windows.Forms.OpenFileDialog();
			this.listBoxVertex = new System.Windows.Forms.ListBox();
			this.tabControl.SuspendLayout();
			this.tabInit.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxInit)).BeginInit();
			this.tabSecond.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSecond)).BeginInit();
			this.tabResult.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxPrim)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxKruskal)).BeginInit();
			this.panelSize.SuspendLayout();
			this.panelbtn.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabInit);
			this.tabControl.Controls.Add(this.tabSecond);
			this.tabControl.Controls.Add(this.tabResult);
			this.tabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tabControl.Location = new System.Drawing.Point(10, 35);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(397, 405);
			this.tabControl.TabIndex = 0;
			// 
			// tabInit
			// 
			this.tabInit.Controls.Add(this.pictureBoxInit);
			this.tabInit.Location = new System.Drawing.Point(4, 34);
			this.tabInit.Name = "tabInit";
			this.tabInit.Padding = new System.Windows.Forms.Padding(3);
			this.tabInit.Size = new System.Drawing.Size(389, 367);
			this.tabInit.TabIndex = 0;
			this.tabInit.Text = "Origen";
			this.tabInit.UseVisualStyleBackColor = true;
			// 
			// pictureBoxInit
			// 
			this.pictureBoxInit.Location = new System.Drawing.Point(0, 0);
			this.pictureBoxInit.Name = "pictureBoxInit";
			this.pictureBoxInit.Size = new System.Drawing.Size(386, 370);
			this.pictureBoxInit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxInit.TabIndex = 0;
			this.pictureBoxInit.TabStop = false;
			// 
			// tabSecond
			// 
			this.tabSecond.Controls.Add(this.pictureBoxSecond);
			this.tabSecond.Location = new System.Drawing.Point(4, 34);
			this.tabSecond.Name = "tabSecond";
			this.tabSecond.Padding = new System.Windows.Forms.Padding(3);
			this.tabSecond.Size = new System.Drawing.Size(389, 367);
			this.tabSecond.TabIndex = 1;
			this.tabSecond.Text = "Modificado";
			this.tabSecond.UseVisualStyleBackColor = true;
			// 
			// pictureBoxSecond
			// 
			this.pictureBoxSecond.Location = new System.Drawing.Point(0, 0);
			this.pictureBoxSecond.Name = "pictureBoxSecond";
			this.pictureBoxSecond.Size = new System.Drawing.Size(386, 370);
			this.pictureBoxSecond.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxSecond.TabIndex = 0;
			this.pictureBoxSecond.TabStop = false;
			this.pictureBoxSecond.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBoxSecondMouseClick);
			// 
			// tabResult
			// 
			this.tabResult.BackColor = System.Drawing.Color.DimGray;
			this.tabResult.Controls.Add(this.pictureBoxPrim);
			this.tabResult.Controls.Add(this.pictureBoxKruskal);
			this.tabResult.Location = new System.Drawing.Point(4, 34);
			this.tabResult.Name = "tabResult";
			this.tabResult.Padding = new System.Windows.Forms.Padding(3);
			this.tabResult.Size = new System.Drawing.Size(389, 367);
			this.tabResult.TabIndex = 2;
			this.tabResult.Text = "Extra";
			// 
			// pictureBoxPrim
			// 
			this.pictureBoxPrim.Location = new System.Drawing.Point(180, 0);
			this.pictureBoxPrim.Name = "pictureBoxPrim";
			this.pictureBoxPrim.Size = new System.Drawing.Size(209, 134);
			this.pictureBoxPrim.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxPrim.TabIndex = 1;
			this.pictureBoxPrim.TabStop = false;
			// 
			// pictureBoxKruskal
			// 
			this.pictureBoxKruskal.Location = new System.Drawing.Point(0, 0);
			this.pictureBoxKruskal.Name = "pictureBoxKruskal";
			this.pictureBoxKruskal.Size = new System.Drawing.Size(170, 134);
			this.pictureBoxKruskal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxKruskal.TabIndex = 0;
			this.pictureBoxKruskal.TabStop = false;
			// 
			// lblMinimized
			// 
			this.lblMinimized.BackColor = System.Drawing.Color.Transparent;
			this.lblMinimized.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblMinimized.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMinimized.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.lblMinimized.Location = new System.Drawing.Point(0, -4);
			this.lblMinimized.Name = "lblMinimized";
			this.lblMinimized.Size = new System.Drawing.Size(30, 35);
			this.lblMinimized.TabIndex = 1;
			this.lblMinimized.Text = "__";
			this.lblMinimized.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			this.lblMinimized.Click += new System.EventHandler(this.LblMinimizedClick);
			// 
			// lblMaximized
			// 
			this.lblMaximized.BackColor = System.Drawing.Color.Transparent;
			this.lblMaximized.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblMaximized.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMaximized.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.lblMaximized.Location = new System.Drawing.Point(37, -1);
			this.lblMaximized.Name = "lblMaximized";
			this.lblMaximized.Size = new System.Drawing.Size(39, 34);
			this.lblMaximized.TabIndex = 2;
			this.lblMaximized.Text = "■";
			this.lblMaximized.Click += new System.EventHandler(this.LblMaximizedClick);
			// 
			// lblClosed
			// 
			this.lblClosed.BackColor = System.Drawing.Color.Transparent;
			this.lblClosed.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblClosed.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblClosed.ForeColor = System.Drawing.Color.Red;
			this.lblClosed.Location = new System.Drawing.Point(82, 0);
			this.lblClosed.Name = "lblClosed";
			this.lblClosed.Size = new System.Drawing.Size(25, 35);
			this.lblClosed.TabIndex = 3;
			this.lblClosed.Text = "x";
			this.lblClosed.Click += new System.EventHandler(this.LblClosedClick);
			// 
			// panelSize
			// 
			this.panelSize.Controls.Add(this.lblMinimized);
			this.panelSize.Controls.Add(this.lblClosed);
			this.panelSize.Controls.Add(this.lblMaximized);
			this.panelSize.Location = new System.Drawing.Point(490, -6);
			this.panelSize.Name = "panelSize";
			this.panelSize.Size = new System.Drawing.Size(120, 35);
			this.panelSize.TabIndex = 4;
			// 
			// lblLoadImg
			// 
			this.lblLoadImg.BackColor = System.Drawing.Color.Transparent;
			this.lblLoadImg.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblLoadImg.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblLoadImg.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.lblLoadImg.Location = new System.Drawing.Point(0, 0);
			this.lblLoadImg.Name = "lblLoadImg";
			this.lblLoadImg.Size = new System.Drawing.Size(200, 30);
			this.lblLoadImg.TabIndex = 5;
			this.lblLoadImg.Text = "Cargar imagen";
			this.lblLoadImg.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.lblLoadImg.Click += new System.EventHandler(this.LblLoadImgClick);
			this.lblLoadImg.MouseLeave += new System.EventHandler(this.LblLoadImgMouseLeave);
			this.lblLoadImg.MouseHover += new System.EventHandler(this.LblLoadImgMouseHover);
			// 
			// lblGenerateTree
			// 
			this.lblGenerateTree.BackColor = System.Drawing.Color.Transparent;
			this.lblGenerateTree.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblGenerateTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblGenerateTree.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.lblGenerateTree.Location = new System.Drawing.Point(0, 45);
			this.lblGenerateTree.Name = "lblGenerateTree";
			this.lblGenerateTree.Size = new System.Drawing.Size(200, 30);
			this.lblGenerateTree.TabIndex = 6;
			this.lblGenerateTree.Text = "Generar arbol";
			this.lblGenerateTree.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.lblGenerateTree.Click += new System.EventHandler(this.LblGenerateTreeClick);
			this.lblGenerateTree.MouseLeave += new System.EventHandler(this.LblGenerateTreeMouseLeave);
			this.lblGenerateTree.MouseHover += new System.EventHandler(this.LblGenerateTreeMouseHover);
			// 
			// lblAnimate
			// 
			this.lblAnimate.BackColor = System.Drawing.Color.Transparent;
			this.lblAnimate.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblAnimate.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAnimate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.lblAnimate.Location = new System.Drawing.Point(0, 90);
			this.lblAnimate.Name = "lblAnimate";
			this.lblAnimate.Size = new System.Drawing.Size(200, 30);
			this.lblAnimate.TabIndex = 7;
			this.lblAnimate.Text = "Animar";
			this.lblAnimate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.lblAnimate.Click += new System.EventHandler(this.LblAnimateClick);
			this.lblAnimate.MouseLeave += new System.EventHandler(this.LblAnimateMouseLeave);
			this.lblAnimate.MouseHover += new System.EventHandler(this.LblAnimateMouseHover);
			// 
			// panelbtn
			// 
			this.panelbtn.Controls.Add(this.lblLoadImg);
			this.panelbtn.Controls.Add(this.lblAnimate);
			this.panelbtn.Controls.Add(this.lblGenerateTree);
			this.panelbtn.Location = new System.Drawing.Point(413, 75);
			this.panelbtn.Name = "panelbtn";
			this.panelbtn.Size = new System.Drawing.Size(200, 128);
			this.panelbtn.TabIndex = 8;
			// 
			// openFileImage
			// 
			this.openFileImage.FileName = "file";
			// 
			// listBoxVertex
			// 
			this.listBoxVertex.FormattingEnabled = true;
			this.listBoxVertex.ItemHeight = 16;
			this.listBoxVertex.Location = new System.Drawing.Point(413, 198);
			this.listBoxVertex.Name = "listBoxVertex";
			this.listBoxVertex.Size = new System.Drawing.Size(197, 84);
			this.listBoxVertex.TabIndex = 10;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(30)))));
			this.ClientSize = new System.Drawing.Size(878, 540);
			this.Controls.Add(this.listBoxVertex);
			this.Controls.Add(this.panelbtn);
			this.Controls.Add(this.panelSize);
			this.Controls.Add(this.tabControl);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "MainForm";
			this.Text = "Actividad3";
			this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MainFormMouseDoubleClick);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainFormMouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainFormMouseMove);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainFormMouseUp);
			this.Resize += new System.EventHandler(this.MainFormResize);
			this.tabControl.ResumeLayout(false);
			this.tabInit.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxInit)).EndInit();
			this.tabSecond.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSecond)).EndInit();
			this.tabResult.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxPrim)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxKruskal)).EndInit();
			this.panelSize.ResumeLayout(false);
			this.panelbtn.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ListBox listBoxVertex;
		private System.Windows.Forms.PictureBox pictureBoxKruskal;
		private System.Windows.Forms.PictureBox pictureBoxPrim;
		private System.Windows.Forms.OpenFileDialog openFileImage;
		private System.Windows.Forms.Panel panelbtn;
		private System.Windows.Forms.Label lblAnimate;
		private System.Windows.Forms.Label lblGenerateTree;
		private System.Windows.Forms.Label lblLoadImg;
		private System.Windows.Forms.TabPage tabResult;
		private System.Windows.Forms.PictureBox pictureBoxSecond;
		private System.Windows.Forms.PictureBox pictureBoxInit;
		private System.Windows.Forms.Panel panelSize;
		private System.Windows.Forms.Label lblClosed;
		private System.Windows.Forms.Label lblMaximized;
		private System.Windows.Forms.Label lblMinimized;
		private System.Windows.Forms.TabPage tabSecond;
		private System.Windows.Forms.TabPage tabInit;
		private System.Windows.Forms.TabControl tabControl;
		private System.Drawing.Bitmap bmp;
		private System.Drawing.Bitmap bmpBackGround;
		private System.Drawing.Bitmap bmpBackGround2;
		private Figure circle = new Figure();
		Graph graph = new Graph();
		int idVertexSelect;
		bool treeSelect;
		Kruskal kruskal;
		Prim prim;
		
		void LblLoadImgMouseHover(object sender, EventArgs e) { lblLoadImg.ForeColor = Color.Red; }
		void LblLoadImgMouseLeave(object sender, EventArgs e) { lblLoadImg.ForeColor = Color.White; }
		
		void LblGenerateTreeMouseHover(object sender, EventArgs e) { lblGenerateTree.ForeColor = Color.Red; }
		void LblGenerateTreeMouseLeave(object sender, EventArgs e) { lblGenerateTree.ForeColor = Color.White; }
		
		void LblAnimateMouseHover(object sender, EventArgs e) { lblAnimate.ForeColor = Color.Red; }
		void LblAnimateMouseLeave(object sender, EventArgs e) { lblAnimate.ForeColor = Color.White; }
		
		void LblClosedClick(object sender, EventArgs e) { Application.Exit(); }
		void LblMaximizedClick(object sender, EventArgs e) {
			if(this.WindowState == FormWindowState.Maximized)
				this.WindowState = FormWindowState.Normal;
			else
				this.WindowState = FormWindowState.Maximized;
		}
		void LblMinimizedClick(object sender, EventArgs e) { this.WindowState = FormWindowState.Minimized; }
		
		
		void MainFormMouseDoubleClick(object sender, MouseEventArgs e) {
			if(this.WindowState == FormWindowState.Maximized)
				this.WindowState = FormWindowState.Normal;
			else
				this.WindowState = FormWindowState.Maximized;
		}
		void MainFormMouseDown(object sender, MouseEventArgs e) {
			mov = 1;
			movX = e.X;
			movY = e.Y;
		}
		
		void MainFormMouseMove(object sender, MouseEventArgs e) {
			if(mov == 1)
				this.SetDesktopLocation(MousePosition.X-movX, MousePosition.Y-movY);
		}
		
		void MainFormMouseUp(object sender, MouseEventArgs e) {
			mov = 0;
		}
		
		void resize() {
			//tab
			tabControl.Width = this.Width - panelbtn.Width - 15;
			tabControl.Height = this.Height - 40;
			//picturebox
			pictureBoxInit.Width    = this.Width - panelbtn.Width - 35;
			pictureBoxInit.Height   = this.Height - 65;
			pictureBoxSecond.Width  = this.Width - panelbtn.Width - 35;
			pictureBoxSecond.Height = this.Height - 65;
			
			pictureBoxKruskal.Location = new Point(0, 0);
			pictureBoxKruskal.Width = tabControl.Width/2 - 5;
			pictureBoxKruskal.Height= tabControl.Height/2;
			
			pictureBoxPrim.Location = new Point(pictureBoxKruskal.Width + 5, 0);
			pictureBoxPrim.Width    = tabControl.Width/2 - 5;
			pictureBoxPrim.Height   = tabControl.Height/2;
			
			//listVertex
			listBoxVertex.Location = new Point(tabControl.Width + 10, listBoxVertex.Top);
			listBoxVertex.Width    = panelbtn.Width;
			listBoxVertex.Height   = tabControl.Bottom - panelbtn.Bottom;
			
			//botones
			panelbtn.Location = new Point(tabControl.Width + 10, panelbtn.Top);
			//closed
			panelSize.Location = new Point(this.Width - 90, 0);
		}
		
		
		void MainFormResize(object sender, EventArgs e) {
			resize();
		}
		
	}
}
