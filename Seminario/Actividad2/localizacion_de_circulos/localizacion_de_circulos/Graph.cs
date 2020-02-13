/*
 * Creado por SharpDevelop.
 * Usuario: david
 * Fecha: 12/02/2020
 * Hora: 10:42 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;

namespace localizacion_de_circulos {
	/// <summary>
	/// Description of Graphic.
	/// </summary>
	public class Edge {
		float weight;
		Vertex v_d;
		public Edge(float x, Vertex d) {
				weight = x;
				v_d = d;
		}
	}
		
	public class Vertex {
		List<Edge> eL;
		Figure c;
		int id;//from 1 to n
		Vertex(Figure c, int id) {
			
		}
		
		public void addEdge(Vertex v) {
			
		}
	}
		
	public class Graph {
		List<Vertex> vL;
		Figure c;
		int id;
		
		public Graph() {
			vL = new List<Vertex>();
		}
		public int getVertexCount() {
			return vL.Count;
		}
		public void addVertex(Figure c) {
			//vL.Add(new vL.Count);
		}
		
		public void addEdge(int i, int j) {
			vL[i].addEdge(vL[j]);
		}
		
	}

}
