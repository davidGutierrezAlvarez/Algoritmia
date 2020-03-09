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
			this.id      = id;
			this.origen  = v1;
			this.destino = v2;
			this.weight  = Weight;
		}
		public Edge(Edge e) {
			this.id      = e.id;
			this.origen  = e.origen;
			this.destino = e.destino;
			this.weight  = e.weight;
		}
		public Edge() { }
		
		public int CompareTo(Edge e) {
			return this.Weight.CompareTo(e.Weight);
		}
	}
		
	public class Vertex { /*grafo*/
		List<Edge> ListEdge;
		Figure circle;
		int id;//from 1 to n
		//Getters
		public List<Edge> Edge { get { return ListEdge; } }
		public Figure Circle   { get { return circle;   } }
		public int Id          { get { return id;       } }
		
		public Vertex() { }
		
		public Vertex(Figure c, int id) {
			this.id       = id;
			this.circle   = c;
			this.ListEdge = new List<Edge>();
		}
		
		public Vertex(Vertex v) {
			this.id     = v.id;
			this.circle = v.circle;
			this.ListEdge = new List<Edge>();
		}
		
		public void addEdge(Edge e) {
			this.ListEdge.Add(e);
		}
		
		public override String ToString() {
			return id + " - (" + circle.X + ", " + circle.Y + ") -> " + circle.R;
		}
		
	}
		
	public class Graph {
		List<Vertex> listVertex;
		
		public Graph() {
			listVertex = new List<Vertex>();
		}
		
		public Graph(Graph g) {
			listVertex = new List<Vertex>(g.listVertex);
		}
		
		public void Copy(Graph g) {
			foreach(Vertex v in g.listVertex) {
				this.listVertex.Add(new Vertex(v));
			}
		}
		
		public List<Vertex> vertex() {
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
		
		public void addEdge(Edge e) {
			listVertex[e.Origen.Id].addEdge(new Edge(e));
		}
		
		public void Clear() {
			listVertex.Clear();
		}
		
		
		
	}

}
