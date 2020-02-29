/*
 * Creado por SharpDevelop.
 * Usuario: dagur
 * Fecha: 20/02/2020
 * Hora: 05:25 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;

namespace localizacion_de_circulos
{
	/// <summary>
	/// Description of Hamilton.
	/// </summary>
	public class Hamilton {
		Graph listCircuits;
		public double weight;
		
		public Graph ListCircuits { get { return listCircuits; } }
		
		public Hamilton() {
			listCircuits = new Graph();
			weight = 100000;
		}
		
		public Hamilton(Graph lg) {
			listCircuits = new Graph(lg);
			addLastConection();
			newWeight();
		}
		
		
		
		void newWeight() {
			for(int i = 0; i < ListCircuits.getVertexCount()-1; i++) {
				weight += ListCircuits.GetVertex()[i].Circle.distance(ListCircuits.GetVertex()[i+1].Circle);
			}
		}
		
		void addLastConection() {
			ListCircuits.ListVertex.Add(ListCircuits.GetVertex()[0]);
		}
		
		
	}
}
