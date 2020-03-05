/*
 * Creado por SharpDevelop.
 * Usuario: david
 * Fecha: 04/03/2020
 * Hora: 11:55 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Actividad3 {
	/// <summary>
	/// Description of overlayTree.
	/// </summary>
	public partial class overlayTree : Form {
		public overlayTree(double diametro) {
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			lblSize.Text += " " + diametro;
			this.diametro = diametro;
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void LblPrimClick(object sender, System.EventArgs e) {
			if(numValue.Value < (int)diametro) {
				MessageBox.Show("valor muy pequeño");
				return;
			}
			tree = 0;
			this.Close();
		}
		
		void LblKruskalClick(object sender, System.EventArgs e) {
			if(numValue.Value < (int)diametro) {
				MessageBox.Show("valor muy pequeño");
				return;
			}
			tree = 1;
			this.Close();
		}
		
		
	}
}
