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
		
		/*
		public override string ToString() {
			return string.Format("[Edge Id Destino={0}, Id Arista={1}]", Destino.circle.Id, Id);
		}*/
	}
		
	public class Vertex { /*grafo*/
		List<Edge> ListEdge;
		Figure circle;
		int id;//from 1 to n
		
		//Getters
		public List<Edge> EL { get { return ListEdge; } }
		public Figure Circle { get { return circle;   } }
		public int Id        { get { return id;       } }
		
		public Vertex() { }
		
		public Vertex(Figure c, int id) {
			this.id = id;
			this.circle = c;
			this.ListEdge = new List<Edge>();
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
		bool isCircuitHamilton;
		
		//Getters
		public List<Vertex> ListVertex { get { return listVertex; } }
		public float Distance {
			get { return distance;  }
			set { distance = value; }
		}
		
		public Graph() {
			listVertex = new List<Vertex>();
			isCircuitHamilton = true;
		}
		
		public int getVertexCount() {
			return listVertex.Count;
		}
		
		public List<Vertex> GetVertex() {
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
		
		public void closestPairPoints() {
			//no es usable :v
			//ya que dentro de la generacion del grafo se es mas eficiente
			//pero si es funcional
			float minDist = 500, aux;
			
			for(int i = 0; i < listVertex.Count; i++) {
				for(int j = i+1; j < listVertex.Count; j++) {
					aux = listVertex[i].Circle.distance(listVertex[j].Circle);
					
					if(aux < minDist) {
						minDist = aux;
						closestPair(listVertex[i] , listVertex[j]);
					}
				}
			}
			distance = minDist;
		}
		
		public void closestPair(Vertex o, Vertex d) {
			origen  = o;
			destino = d;
		}
		
		public bool vertexInCircuit(Vertex v) {
			foreach(Vertex vertex in listVertex) {
				if(vertex.Id == v.Id) {
					return true;
				}
			}
			return false;
		}
		
		public override String ToString() {
			if(origen != null)
				return "Más cercanos: ("+ origen.Id + " y " + destino.Id + ") Distancia " + distance;
			else
				return "Más cercanos:  No hay par m+as cercanos.";
		}
		
		public void Clear() {
			origen = null;
			destino = null;
			distance = 0;
			isCircuitHamilton = true;
		}
		

	}

}
