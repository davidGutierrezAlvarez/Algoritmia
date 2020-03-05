/*
 * Creado por SharpDevelop.
 * Usuario: dagur
 * Fecha: 04/03/2020
 * Hora: 09:03 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Drawing;
using System.Collections.Generic;

namespace Actividad3
{
	/// <summary>
	/// Description of Kruskal.
	/// </summary>
	public class Kruskal {
		Graph graph;
		Graph minimumPath;
		List<Edge> edges;
		public List<Edge> minim;
		int[,] Matriz;
		List<int> temp;
		
		public Kruskal(Graph graph) {
			this.graph = graph;
			minimumPath = new Graph();
			edges = new List<Edge>();
			minim = new List<Edge>();
			Matriz = new int[graph.getVertex().Count, graph.getVertex().Count];
		}
		
		void edgesByOrder() {
			for(int i = 0; i < graph.getVertex().Count; i++) {
				for(int j = 0; j < graph.getVertex()[i].EL.Count; j++) {
						edges.Add(graph.getVertex()[i].EL[j]);
				}
			}
			edges.Sort((x, y) => x.CompareTo(y));
		}
		
		
		public void kruskal() {
			//ordenar caminos
			edgesByOrder();
			Vertex u = new Vertex();
			Vertex v = new Vertex();
			
			foreach(Edge e in edges) {
				//si no es conexo unirlos
				u = e.Origen;
				v = e.Destino;
				if(!adyacente(u, v)) {
					//actualizo la matriz
					Matriz[u.Id, v.Id] = 1;
					Matriz[v.Id, u.Id] = 1;
					//agregar adyaciencia
					minim.Add(e);
				}
				if(minim.Count == graph.getVertex().Count-1)
					return;
			}
		}
		
		bool adyacente(Vertex u, Vertex v) {
			temp = new List<int>();
			matriz(u.Id);
			if(temp.Contains(v.Id)) {
				return true;
			}
			return false;
		}
	
		void matriz(int vertex) {
			if(!temp.Contains(vertex)) {
				temp.Add(vertex);
				for(int i = 0; i < graph.getVertex().Count; i++) {
					if(Matriz[vertex, i] == 1) {
						matriz(i);
					}
				}
			}
		}
		
		
		
	}
}
