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
		String[] cases;
		public double weight;
		
		public Graph ListCircuits { get { return listCircuits; } }
		
		public string[] Cases { get { return cases; } }
		public Hamilton() {
			listCircuits = new Graph();
			cases = new string[0];
			weight = 100000;
		}
		
		public Hamilton(Graph lg) {
			listCircuits = new Graph(lg);
			addLastConection();
			cases = new string[lg.getVertexCount()+2];
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
		
		public void print() {
			//String s = "";
			for(int i = 0; i < listCircuits.getVertexCount()-1; i++) {
				cases[i] = ""+listCircuits.GetVertex()[i].Id;
				//s += ""+listCircuits.GetVertex()[i].Id + " - " +listCircuits.GetVertex()[i+1].Id +" -> " + listWeight[i+1] + "\n";
			}
			cases[cases.Length-2] =(""+listCircuits.GetVertex()[0].Id);
			cases[cases.Length-1] = (""+(int)weight);
			//System.Windows.Forms.MessageBox.Show(s);
		}
	}
}
