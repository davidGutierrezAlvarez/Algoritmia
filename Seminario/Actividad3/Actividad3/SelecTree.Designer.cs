/*
 * Creado por SharpDevelop.
 * Usuario: david
 * Fecha: 08/03/2020
 * Hora: 07:15 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
 using System;
 using System.Drawing;
 using System.Windows.Forms;
 
namespace Actividad3
{
	partial class SelecTree
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
			this.lblClosed = new System.Windows.Forms.Label();
			this.lblKruskal = new System.Windows.Forms.Label();
			this.lblPrim = new System.Windows.Forms.Label();
			this.lblTitle = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblClosed
			// 
			this.lblClosed.BackColor = System.Drawing.Color.Transparent;
			this.lblClosed.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblClosed.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblClosed.ForeColor = System.Drawing.Color.Red;
			this.lblClosed.Location = new System.Drawing.Point(319, -5);
			this.lblClosed.Name = "lblClosed";
			this.lblClosed.Size = new System.Drawing.Size(25, 35);
			this.lblClosed.TabIndex = 5;
			this.lblClosed.Text = "x";
			this.lblClosed.Click += new System.EventHandler(this.LblClosedClick);
			// 
			// lblKruskal
			// 
			this.lblKruskal.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblKruskal.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblKruskal.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.lblKruskal.Location = new System.Drawing.Point(175, 125);
			this.lblKruskal.Name = "lblKruskal";
			this.lblKruskal.Size = new System.Drawing.Size(175, 35);
			this.lblKruskal.TabIndex = 7;
			this.lblKruskal.Text = "KRUSKAL";
			this.lblKruskal.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.lblKruskal.Click += new System.EventHandler(this.LblKruskalClick);
			this.lblKruskal.MouseLeave += new System.EventHandler(this.LblKruskalMouseLeave);
			this.lblKruskal.MouseHover += new System.EventHandler(this.LblKruskalMouseHover);
			// 
			// lblPrim
			// 
			this.lblPrim.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lblPrim.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPrim.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.lblPrim.Location = new System.Drawing.Point(1, 125);
			this.lblPrim.Name = "lblPrim";
			this.lblPrim.Size = new System.Drawing.Size(175, 35);
			this.lblPrim.TabIndex = 6;
			this.lblPrim.Text = "PRIM";
			this.lblPrim.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.lblPrim.Click += new System.EventHandler(this.LblPrimClick);
			this.lblPrim.MouseLeave += new System.EventHandler(this.LblPrimMouseLeave);
			this.lblPrim.MouseHover += new System.EventHandler(this.LblPrimMouseHover);
			// 
			// lblTitle
			// 
			this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.lblTitle.Location = new System.Drawing.Point(1, 55);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(349, 23);
			this.lblTitle.TabIndex = 8;
			this.lblTitle.Text = "SELECCIONE METODO";
			this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// SelecTree
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(30)))));
			this.ClientSize = new System.Drawing.Size(350, 179);
			this.Controls.Add(this.lblTitle);
			this.Controls.Add(this.lblKruskal);
			this.Controls.Add(this.lblPrim);
			this.Controls.Add(this.lblClosed);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "SelecTree";
			this.Text = "SelecTree";
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SelecTreeMouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SelecTreeMouseMove);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SelecTreeMouseUp);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Label lblPrim;
		private System.Windows.Forms.Label lblKruskal;
		private System.Windows.Forms.Label lblClosed;
		int mov, movX, movY;
		public int select = -1;
		
		
		void LblClosedClick(object sender, EventArgs e) { this.Close(); }
		
		void SelecTreeMouseDown(object sender, MouseEventArgs e) {
			mov = 1;
			movX = e.X;
			movY = e.Y;
		}
		
		
		void SelecTreeMouseMove(object sender, MouseEventArgs e) {
			if(mov == 1)
				this.SetDesktopLocation(MousePosition.X-movX, MousePosition.Y-movY);
		}
		
		void SelecTreeMouseUp(object sender, MouseEventArgs e) {
			mov = 0;
		}
		
		void LblPrimMouseHover(object sender, EventArgs e) { lblPrim.ForeColor = Color.Red; }
		void LblPrimMouseLeave(object sender, EventArgs e) { lblPrim.ForeColor = Color.White; }
		
		void LblKruskalMouseHover(object sender, EventArgs e) { lblKruskal.ForeColor = Color.Red; }
		void LblKruskalMouseLeave(object sender, EventArgs e) { lblKruskal.ForeColor = Color.White; }
		
	}
}
