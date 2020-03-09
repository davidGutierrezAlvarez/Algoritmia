/*
 * Creado por SharpDevelop.
 * Usuario: dagur
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
	/// <summary>
	/// Description of SelecTree.
	/// </summary>
	public partial class SelecTree : Form
	{
		public SelecTree()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void LblPrimClick(object sender, System.EventArgs e) {
			if(vertex == -1) {
				MessageBox.Show("Primero seleccione un Vertice");
				return;
			}
			select = 0;
			this.Close();
		}
		
		void LblKruskalClick(object sender, System.EventArgs e) {
			select = 1;
			this.Close();
		}
		
	}
}
