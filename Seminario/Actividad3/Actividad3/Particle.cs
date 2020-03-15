/*
 * Creado por SharpDevelop.
 * Usuario: dagur
 * Fecha: 12/03/2020
 * Hora: 06:11 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace Actividad3
{
	/// <summary>
	/// Description of Particle.
	/// </summary>
	public class Particle {
		public int origen;
		public int destino;
		public int actualEdge;
		int actualPos;
		int speed;
		public int diametro;
		
		public Particle(){ }
		public Particle(int origen, int edge, int d) {
			this.origen = origen;
			actualEdge = edge;
			actualPos = 0;
			speed = 6;
			diametro = d;
		}
		
		public bool isWalking() {
			return speed != 0;
		}
		
		public void walk(Edge e) {
			if(e.path.Count > actualPos+speed) {
				actualPos += speed;
			} else {
				speed = 0;
				actualPos = e.path.Count-1;
			}
		}
		
		public int getPos() {
			return actualPos;
		}
	}
}
