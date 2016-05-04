using UnityEngine;
using System.Collections.Generic; // to access Lists

public class Node{

	public List<Node> adjacent = new List<Node>();
	public Node previous = null;
	public string label = "";

	public void Clear(){
		previous = null;
	}
}
