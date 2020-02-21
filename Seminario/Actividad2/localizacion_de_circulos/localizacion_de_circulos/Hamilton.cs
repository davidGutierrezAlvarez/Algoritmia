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
		
		List<double> listWeight;
		
		public Graph ListCircuits { get { return listCircuits; } }
		
		public string[] Cases { get { return cases; } }
		public Hamilton() {
			listCircuits = new Graph();
			listWeight = new List<double>();
			cases = new string[0];
		}
		
		public Hamilton(Graph lg, List<double> lw) {
			listCircuits = new Graph(lg);
			listWeight = new List<double>(lw);
			addLastConection();
			cases = new string[lg.getVertexCount()+2];
		}
		
		public double getWeight() {
			double weight = 0;
			for(int i = 0; i < listWeight.Count; i++) {
				weight += listWeight[i];
			}
			return weight;
		}
		
		void addLastConection() {
			listWeight.Add(listCircuits.GetVertex()[0].Circle.distance(ListCircuits.GetVertex()[ListCircuits.getVertexCount()-1].Circle));
			ListCircuits.ListVertex.Add(ListCircuits.GetVertex()[0]);
		}
		
		public void print() {
			//String s = "";
			for(int i = 0; i < listCircuits.getVertexCount()-1; i++) {
				cases[i] = ""+listCircuits.GetVertex()[i].Id;
				//s += ""+listCircuits.GetVertex()[i].Id + " - " +listCircuits.GetVertex()[i+1].Id +" -> " + listWeight[i+1] + "\n";
			}
			cases[cases.Length-2] =(""+listCircuits.GetVertex()[0].Id);
			cases[cases.Length-1] = (""+(int)getWeight());
			//System.Windows.Forms.MessageBox.Show(s);
		}
	}
}
