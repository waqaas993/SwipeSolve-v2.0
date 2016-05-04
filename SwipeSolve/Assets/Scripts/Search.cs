﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Search{

	public Graph graph;
	public List<Node> reachable;
	public List<Node> explored;
	public List<Node> path;
	public Node goalNode;
	public int iterations;
	public bool finished;

	public Search(Graph graph){
		this.graph = graph;
	}

	public void Start(Node start, Node goal){
		reachable = new List<Node>();
		reachable.Add (start);

		goalNode = goal;

		explored = new List<Node>();
		path = new List<Node>();
		iterations = 0;

		for(var i=0; i<graph.nodes.Length; i++)
		{
			graph.nodes[i].Clear ();
		}
	}

	public void Step(){
		if(path.Count > 0)
			return;

		if(reachable.Count == 0){
			finished = true;
			return;
		}
		iterations++;

		var node = ChoseNode ();
		if (node == goalNode){
			while (node!=null){
				path.Insert(0, node);
				node = node.previous;
			}
			finished = true;
			return;
		}

		reachable.Remove(node);
		explored.Add(node);

		for(var i=0; i<node.adjacent.Count; i++){
			AddAdjacent(node, node.adjacent[i]);
		}
	}

	public void AddAdjacent(Node node, Node adjacent){
		if( FindNode(adjacent, explored) || FindNode(adjacent, reachable) ){
			return;
		}
		adjacent.previous = node;
		reachable.Add (adjacent);
	}

	public bool FindNode(Node node, List<Node> list){
		return GetNodeIndex (node, list)>=0;
	}

	public int GetNodeIndex(Node node, List<Node> list){
		for(var i=0; i<list.Count; i++){
			if(node == list[i]){
				return i;
			}
		}
		return -1;
	}

	public Node ChoseNode(){
		return reachable[Random.Range(0, reachable.Count)];
	}


}
