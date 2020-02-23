/*
 * Creado por SharpDevelop.
 * Usuario: dagur
 * Fecha: 22/02/2020
 * Hora: 11:59 a. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace Espiral
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lblMatriz = new System.Windows.Forms.Label();
			this.nnumberBoxmatriz = new System.Windows.Forms.NumericUpDown();
			this.btnGenerar = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.numberBoxBuscar = new System.Windows.Forms.NumericUpDown();
			this.btmBuscar = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.nnumberBoxmatriz)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numberBoxBuscar)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(346, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(650, 650);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "groupBox1";
			// 
			// lblMatriz
			// 
			this.lblMatriz.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMatriz.Location = new System.Drawing.Point(12, 12);
			this.lblMatriz.Name = "lblMatriz";
			this.lblMatriz.Size = new System.Drawing.Size(241, 33);
			this.lblMatriz.TabIndex = 1;
			this.lblMatriz.Text = "Tamaño de la matriz:";
			// 
			// nnumberBoxmatriz
			// 
			this.nnumberBoxmatriz.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.nnumberBoxmatriz.Location = new System.Drawing.Point(259, 12);
			this.nnumberBoxmatriz.Name = "nnumberBoxmatriz";
			this.nnumberBoxmatriz.Size = new System.Drawing.Size(81, 30);
			this.nnumberBoxmatriz.TabIndex = 2;
			// 
			// btnGenerar
			// 
			this.btnGenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnGenerar.Location = new System.Drawing.Point(12, 68);
			this.btnGenerar.Name = "btnGenerar";
			this.btnGenerar.Size = new System.Drawing.Size(328, 44);
			this.btnGenerar.TabIndex = 4;
			this.btnGenerar.Text = "Generar matriz";
			this.btnGenerar.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(13, 136);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(240, 33);
			this.label3.TabIndex = 5;
			this.label3.Text = "Numero a buscar:";
			// 
			// numberBoxBuscar
			// 
			this.numberBoxBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numberBoxBuscar.Location = new System.Drawing.Point(259, 136);
			this.numberBoxBuscar.Name = "numberBoxBuscar";
			this.numberBoxBuscar.Size = new System.Drawing.Size(82, 30);
			this.numberBoxBuscar.TabIndex = 6;
			// 
			// btmBuscar
			// 
			this.btmBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btmBuscar.Location = new System.Drawing.Point(12, 196);
			this.btmBuscar.Name = "btmBuscar";
			this.btmBuscar.Size = new System.Drawing.Size(328, 44);
			this.btmBuscar.TabIndex = 7;
			this.btmBuscar.Text = "Comenzar busqueda";
			this.btmBuscar.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1037, 671);
			this.Controls.Add(this.btmBuscar);
			this.Controls.Add(this.numberBoxBuscar);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.btnGenerar);
			this.Controls.Add(this.nnumberBoxmatriz);
			this.Controls.Add(this.lblMatriz);
			this.Controls.Add(this.groupBox1);
			this.Name = "MainForm";
			this.Text = "Espiral";
			((System.ComponentModel.ISupportInitialize)(this.nnumberBoxmatriz)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numberBoxBuscar)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button btmBuscar;
		private System.Windows.Forms.NumericUpDown numberBoxBuscar;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnGenerar;
		private System.Windows.Forms.NumericUpDown nnumberBoxmatriz;
		private System.Windows.Forms.Label lblMatriz;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}
