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
		public overlayTree(int diametroK, int diametroP) {
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			lblK.Text += " " + diametroK;
			lblP.Text += " " + diametroP;
			this.diametroK = diametroK;
			this.diametroP = diametroP;
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void LblPrimClick(object sender, System.EventArgs e) {
			if(numValue.Value < diametroP) {
				MessageBox.Show("valor muy pequeño");
				return;
			}
			diametroP = (int)numValue.Value;
			tree = 0;
			this.Close();
		}
		
		void LblKruskalClick(object sender, System.EventArgs e) {
			if(numValue.Value < diametroK) {
				MessageBox.Show("valor muy pequeño");
				return;
			}
			diametroK = (int)numValue.Value;
			tree = 1;
			this.Close();
		}
		
		
		
	}
}
