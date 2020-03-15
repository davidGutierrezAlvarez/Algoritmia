/*
 * Creado por SharpDevelop.
 * Usuario: david
 * Fecha: 05/03/2020
 * Hora: 05:12 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;

namespace Actividad3 {
	/// <summary>
	/// Description of Prim.
	/// </summary>
	public class Prim {
		Graph graph;
		public Graph minimumPath;
		Edge e;
		public List<Edge> edges;
		public int[,] Matriz;
		List<int> temp;
		int isTreeMinimumPath;
		int count;
		
		public Prim(Graph graph) {
			this.graph = new Graph();
			this.graph.Copy(graph);
			copy(graph);
			minimumPath = new Graph();
			minimumPath.Copy(graph);
			edges = new List<Edge>();
			Matriz = new int[graph.vertex().Count, graph.vertex().Count];
			isTreeMinimumPath = 0;
		}
		
		void copy(Graph g) {
			Edge e;
			for(int i = 0; i < g.vertex().Count; i++) {
				for(int j = 0; j < g.vertex()[i].Edge.Count; j++) {
					e = new Edge(g.vertex()[i].Edge[j]);
					this.graph.vertex()[i].addEdge(e);
				}
			}
		}
		
		public void generate(int vertex) {
			List<int> candidatos = new List<int>();
			List<int> lista      = new List<int>();
			candidatos.Add(vertex);
			foreach(Vertex v_ in graph.vertex()) lista.Add(v_.Id);
			
			Vertex u = new Vertex();
			Vertex v = new Vertex();
			int id = -1;
			
			while(isTreeMinimumPath != graph.vertex().Count-1) {
				e = new Edge(1, new Vertex(), new Vertex(), 99999999, null);
				count = 0;
				foreach(int i in candidatos) {
					candidato(i);
				}
				
				
				u = e.Origen;
				v = e.Destino;
				
				//eliminar el candidato seleccionado
				//no puede volver a ser candidato
				lista.Remove(u.Id);
				if(count == 0) {
					if(lista.Count > 0) {
						candidato(lista[0]);
						candidatos.Add(lista[0]);
						lista.Remove(lista[0]);
					} else {
						break;
					}
				}
				graph.vertex()[u.Id].Edge.Remove(e);
				
				if(!conexo(u, v)) {
					//actualizo la matriz de adyacencia
					Matriz[u.Id, v.Id] = 1;
					Matriz[v.Id, u.Id] = 1;
					//agregar adyaciencia
					candidatos.Add(v.Id);
					//agregar candidato
					isTreeMinimumPath++;
					edges.Add(e);
					minimumPath.addEdge(++id, e.Origen.Id, e.Destino.Id, (float)e.Weight, e.path);
					List<System.Drawing.Point> pathR = new List<System.Drawing.Point>(e.path);
					pathR.Reverse();
					minimumPath.addEdge(++id, e.Destino.Id, e.Origen.Id, (float)e.Weight, pathR);
				}
			}
		}
		
		void candidato(int vertex) {
			for(int i = 0; i < graph.vertex()[vertex].Edge.Count; i++) {
				if(e.Weight > graph.vertex()[vertex].Edge[i].Weight) {
					e = graph.vertex()[vertex].Edge[i];
					count++;
				}
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
