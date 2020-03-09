/*
 * Creado por SharpDevelop.
 * Usuario: dagur
 * Fecha: 04/03/2020
 * Hora: 09:03 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;

namespace Actividad3 {
	/// <summary>
	/// Description of Kruskal.
	/// </summary>
	public class Kruskal {
		Graph graph;
		public Graph minimumPath;
		List<Edge> edges;
		int[,] Matriz;
		List<int> temp;
		int isTreeMinimumPath;
		
		public Kruskal(Graph graph) {
			this.graph = graph;
			minimumPath = new Graph();
			minimumPath.Copy(graph);
			edges = new List<Edge>();
			Matriz = new int[graph.vertex().Count, graph.vertex().Count];
			isTreeMinimumPath = 0;
		}
		
		void edgesByOrder() {
			for(int i = 0; i < graph.vertex().Count; i++) {
				for(int j = 0; j < graph.vertex()[i].Edge.Count; j++) {
						edges.Add(graph.vertex()[i].Edge[j]);
				}
			}
			edges.Sort((x, y) => x.CompareTo(y));
		}
		
		
		public void generate() {
			//ordenar caminos
			edgesByOrder();
			Vertex u = new Vertex();
			Vertex v = new Vertex();
			int id = -1;
			
			foreach(Edge e in edges) {
				u = e.Origen;
				v = e.Destino;
				//si no es conexo unirlos
				if(!conexo(u, v)) {
					//actualizo la matriz
					Matriz[u.Id, v.Id] = 1;
					Matriz[v.Id, u.Id] = 1;
					//agregar adyaciencia
					isTreeMinimumPath++;
					//minimumPath.addEdge(e);
					minimumPath.addEdge(++id, e.Origen.Id, e.Destino.Id, (float)e.Weight);
					minimumPath.addEdge(++id, e.Destino.Id, e.Origen.Id, (float)e.Weight);
				}
				if(isTreeMinimumPath == graph.vertex().Count-1)
					return;
			}
		}
	
		bool conexo(Vertex u, Vertex v) {
			temp = new List<int>();
			adyacente(u.Id);
			if(temp.Contains(v.Id)) {
				return true;
			}
			return false;
		}
	
		void adyacente(int vertex) {
			if(!temp.Contains(vertex)) {
				temp.Add(vertex);
				for(int i = 0; i < graph.vertex().Count; i++) {
					if(Matriz[vertex, i] == 1) {
						adyacente(i);
					}
				}
			}
		}
		
		
		
	}
}
