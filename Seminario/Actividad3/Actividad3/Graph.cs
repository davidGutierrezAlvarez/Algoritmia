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

namespace Actividad3 {
	/// <summary>
	/// Description of Graphic.
	/// </summary>
	public class Edge { /*arista*/
		Vertex origen;
		Vertex destino;
		int id;
		double weight;
		
		//Getters
		public Vertex Origen  { get { return origen;  } }
		public Vertex Destino { get { return destino; } }
		public int Id         { get { return id;      } }
		public double Weight  { get { return weight;  } }
		
		public Edge(int id, Vertex v1, Vertex v2, double Weight) {
			this.id = id;
			this.origen = v1;
			this.destino = v2;
			this.weight = Weight;
		}
	}
		
	public class Vertex { /*grafo*/
		List<Edge> ListEdge;
		public List<int> subGrafo;
		Figure circle;
		int id;//from 1 to n
		
		//Getters
		public List<Edge> EL { get { return ListEdge; } }
		public Figure Circle { get { return circle;   } }
		public int Id        { get { return id;       } }
		
		public Vertex() { this.subGrafo = new List<int>(); }
		
		public Vertex(Figure c, int id) {
			this.id = id;
			this.circle = c;
			this.ListEdge = new List<Edge>();
			this.subGrafo = new List<int>();
		}
		
		public void addEdge(Edge v) {
			this.ListEdge.Add(v);
		}
		
	}
		
	public class Graph {
		List<Vertex> listVertex;
		Vertex origen;
		Vertex destino;
		float distance;
		public int[,] Matriz;
		
		//Getters
		public float Distance {
			get { return distance;  }
			set { distance = value; }
		}
		
		public Graph() {
			listVertex = new List<Vertex>();
		}
		
		public Graph(Graph g) {
			listVertex = new List<Vertex>(g.listVertex);
		}
		
		public List<Vertex> getVertex() {
			return listVertex;
		}

		public void addVertex(Vertex v) {
			listVertex.Add(v);
		}
		
		public void addVertex(Figure circle, int id) {
			//cada nuevo circulo que entre se agregara al grafo
			listVertex.Add(new Vertex(circle, id));
		}
		
		public void addEdge(int id, int i, int j, float weight) {
			listVertex[i].addEdge(new Edge(id, listVertex[i], listVertex[j], weight));
		}
		
		public void closestPair(Vertex o, Vertex d) {
			origen  = o;
			destino = d;
		}
		
		public bool vertexInCircuit(Vertex v) {
			if(listVertex.Contains(v))
				return true;
			return false;
		}
		
		public override String ToString() {
			if(origen != null)
				return "Más cercanos: ("+ origen.Id + " y " + destino.Id + ") Distancia " + distance;
			else
				return "Más cercanos:  No hay par más cercanos.";
		}
		
		public void matriz() {
			Matriz = new int[listVertex.Count, listVertex.Count];
		}
		
		public void generarSubGrafo() {
			for(int i = 0; i < listVertex.Count; i++) {
				subGrafo(i);
			}
		}
		
		public String subGrafos() {
			List<List<int>> subgrafos = new List<List<int>>();
			for(int i = 0; i < listVertex.Count; i++) {
				if(!subgrafos.Contains(listVertex[i].subGrafo)) {
					subgrafos.Add(listVertex[i].subGrafo);
				}
			}
			String s = "";
			for(int i=0; i < subgrafos.Count; i++) {
				s += "Grafo " + (i+1) + "\n";
				for(int j=0; j < subgrafos[i].Count; j++) {
					s += subgrafos[i][j] + " ";
				}
				s += "\n\n";
			}
			return s;
		}
		
		private void subGrafo(int vertex) {
			if(!listVertex[vertex].subGrafo.Contains(vertex)) {
				listVertex[vertex].subGrafo.Add(vertex);
				for(int j = 0; j < listVertex.Count; j++) {
					if(Matriz[vertex, j] == 1) {
						Matriz[vertex, j] = 0;
						Matriz[j, vertex] = 0;
						listVertex[j].subGrafo = listVertex[vertex].subGrafo;
						subGrafo(j);
					}
				}
			}
		}
		
		public void Clear() {
			origen = null;
			destino = null;
			distance = 0;
		}
		
	}

}
