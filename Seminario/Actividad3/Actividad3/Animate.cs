/*
 * Creado por SharpDevelop.
 * Usuario: david
 * Fecha: 10/03/2020
 * Hora: 07:51 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Windows.Forms;
using System.Drawing;

namespace Actividad3
{
	/// <summary>
	/// Description of Animate.
	/// </summary>
	public class Animate {
		private PictureBox pictureBox;
		private Bitmap bmp;
		private Bitmap[] particulas;
		private Graphics graphics;
		private Graph graph;
		private Font font;
		private Pen p;
		
		
		
		public Animate(PictureBox pb, Bitmap bmp) {
			pictureBox = pb;
			this.bmp = bmp;
		}
		
		public void Start() {
			
		}
	}
}
