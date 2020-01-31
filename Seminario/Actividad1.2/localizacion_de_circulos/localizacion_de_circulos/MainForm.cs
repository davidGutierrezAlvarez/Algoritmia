/*
 * Creado por SharpDevelop.
 * Usuario: dagur
 * Fecha: 31/01/2020
 * Hora: 11:38 a. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace localizacion_de_circulos
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form {
		int mov, movX, movY;
		public MainForm() {
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void CloseClick(object sender, EventArgs e)	{
			Application.Exit();
		}
		void clickLoad(object sender, System.EventArgs e)
		{
			
		}
		void MainFormLoad(object sender, EventArgs e) {
			
		}
		
		void BtnLoadClick(object sender, EventArgs e)
		{
			
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
		
		void LblLoadCursorChanged(object sender, EventArgs e) {
			
		}
		
		void LblLoadMouseDown(object sender, MouseEventArgs e) {
			this.lblLoad.ForeColor = System.Drawing.Color.Red;
			
		}
		
		void LblLoadMouseUp(object sender, MouseEventArgs e) {
			this.lblLoad.ForeColor = System.Drawing.Color.White;
		}
		
		void LblAnalizeMouseDown(object sender, MouseEventArgs e) {
			this.lblAnalize.ForeColor = System.Drawing.Color.Red;
		}

		void LblAnalizeMouseUp(object sender, MouseEventArgs e) {
			this.lblAnalize.ForeColor = System.Drawing.Color.White;
		}
		
		void LblGenerateMouseDown(object sender, MouseEventArgs e) {
			this.lblGenerate.ForeColor = System.Drawing.Color.Red;
		}
		
		void LblGenerateMouseUp(object sender, MouseEventArgs e) {
			this.lblGenerate.ForeColor = System.Drawing.Color.White;
		}
	}
}
