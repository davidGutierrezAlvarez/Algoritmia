/*
 * Creado por SharpDevelop.
 * Usuario: dagur
 * Fecha: 04/03/2020
 * Hora: 11:55 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
 using System;
 using System.Drawing;
 using System.Windows.Forms;
 
 
namespace Actividad3
{
	partial class overlayTree
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
			this.numValue = new System.Windows.Forms.NumericUpDown();
			this.lblPrim = new System.Windows.Forms.Label();
			this.lblKruskal = new System.Windows.Forms.Label();
			this.lblSize = new System.Windows.Forms.Label();
			this.lblClosed = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.numValue)).BeginInit();
			this.SuspendLayout();
			// 
			// numValue
			// 
			this.numValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(30)))), ((int)(((byte)(20)))));
			this.numValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numValue.ForeColor = System.Drawing.SystemColors.Info;
			this.numValue.Location = new System.Drawing.Point(136, 97);
			this.numValue.Maximum = new decimal(new int[] {
									-727379969,
									232,
									0,
									0});
			this.numValue.Name = "numValue";
			this.numValue.Size = new System.Drawing.Size(134, 34);
			this.numValue.TabIndex = 0;
			this.numValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// lblPrim
			// 
			this.lblPrim.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblPrim.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPrim.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.lblPrim.Location = new System.Drawing.Point(0, 170);
			this.lblPrim.Name = "lblPrim";
			this.lblPrim.Size = new System.Drawing.Size(200, 35);
			this.lblPrim.TabIndex = 1;
			this.lblPrim.Text = "PRIM";
			this.lblPrim.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.lblPrim.Click += new System.EventHandler(this.LblPrimClick);
			this.lblPrim.MouseLeave += new System.EventHandler(this.LblPrimMouseLeave);
			this.lblPrim.MouseHover += new System.EventHandler(this.LblPrimMouseHover);
			// 
			// lblKruskal
			// 
			this.lblKruskal.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblKruskal.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblKruskal.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.lblKruskal.Location = new System.Drawing.Point(200, 170);
			this.lblKruskal.Name = "lblKruskal";
			this.lblKruskal.Size = new System.Drawing.Size(200, 35);
			this.lblKruskal.TabIndex = 2;
			this.lblKruskal.Text = "KRUSKAL";
			this.lblKruskal.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.lblKruskal.Click += new System.EventHandler(this.LblKruskalClick);
			this.lblKruskal.MouseLeave += new System.EventHandler(this.LblKruskalMouseLeave);
			this.lblKruskal.MouseHover += new System.EventHandler(this.LblKruskalMouseHover);
			// 
			// lblSize
			// 
			this.lblSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSize.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.lblSize.Location = new System.Drawing.Point(0, 48);
			this.lblSize.Name = "lblSize";
			this.lblSize.Size = new System.Drawing.Size(400, 23);
			this.lblSize.TabIndex = 3;
			this.lblSize.Text = "Tamaño inicial minimo: ";
			this.lblSize.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lblClosed
			// 
			this.lblClosed.BackColor = System.Drawing.Color.Transparent;
			this.lblClosed.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblClosed.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblClosed.ForeColor = System.Drawing.Color.Red;
			this.lblClosed.Location = new System.Drawing.Point(369, -4);
			this.lblClosed.Name = "lblClosed";
			this.lblClosed.Size = new System.Drawing.Size(25, 35);
			this.lblClosed.TabIndex = 4;
			this.lblClosed.Text = "x";
			this.lblClosed.Click += new System.EventHandler(this.LblClosedClick);
			// 
			// overlayTree
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(30)))));
			this.ClientSize = new System.Drawing.Size(400, 235);
			this.Controls.Add(this.lblClosed);
			this.Controls.Add(this.lblSize);
			this.Controls.Add(this.lblKruskal);
			this.Controls.Add(this.lblPrim);
			this.Controls.Add(this.numValue);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "overlayTree";
			this.Text = "overlayTree";
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OverlayTreeMouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OverlayTreeMouseMove);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OverlayTreeMouseUp);
			((System.ComponentModel.ISupportInitialize)(this.numValue)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label lblClosed;
		private System.Windows.Forms.Label lblSize;
		private System.Windows.Forms.Label lblKruskal;
		private System.Windows.Forms.Label lblPrim;
		private System.Windows.Forms.NumericUpDown numValue;
		int mov, movX, movY;
		public int tree = -1;
		public int diametro;
		
		
		void LblClosedClick(object sender, EventArgs e) { this.Close(); }
		
		void OverlayTreeMouseDown(object sender, MouseEventArgs e) {
			mov = 1;
			movX = e.X;
			movY = e.Y;
		}
		
		void OverlayTreeMouseMove(object sender, MouseEventArgs e) {
			if(mov == 1)
				this.SetDesktopLocation(MousePosition.X-movX, MousePosition.Y-movY);
		}
		
		void OverlayTreeMouseUp(object sender, MouseEventArgs e) {
			mov = 0;
		}
		
		
		void LblPrimMouseHover(object sender, EventArgs e) { lblPrim.ForeColor = Color.Red; }
		void LblPrimMouseLeave(object sender, EventArgs e) { lblPrim.ForeColor = Color.White; }
		
		void LblKruskalMouseHover(object sender, EventArgs e) { lblKruskal.ForeColor = Color.Red; }
		void LblKruskalMouseLeave(object sender, EventArgs e) { lblKruskal.ForeColor = Color.White; }
	}
}
