using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;


public class PathfindingTest : MonoBehaviour{

	public GameObject mapGroup;

	public Sprite Obstacle;
	public Sprite RedBall;
	public Sprite BlueBall;
	public Sprite RedHole;
	public Sprite BlueHole;

	public Text RedText;
	public Text BlueText;

	// Use this for initialization
	void Start () {
		int[,] map = new int[5, 5]{
			{0,0,0,0,1},
			{0,0,1,0,0},
			{0,1,0,1,0},
			{0,0,0,0,0},
			{0,1,0,0,1}
		};

		var graph = new Graph (map);
		ResetMapGroup(graph);

		var blueSearch = new Search (graph);
		blueSearch.Start (graph.nodes[5], graph.nodes[8]);
		GetImage(graph.nodes[5].label).sprite = BlueBall;
		GetImage(graph.nodes[8].label).sprite = BlueHole;
		while(!blueSearch.finished){
			blueSearch.Step();
		}
		Debug.Log ("BLUE done. Path length "+blueSearch.path.Count+" iterations "+blueSearch.iterations);
		BlueText.text = "BLUE: Path length ("+blueSearch.path.Count+"), iterations ("+blueSearch.iterations+")";
		foreach(var node in blueSearch.path){
			GetImage(node.label).color = Color.blue;
		}
		
		var redSearch = new Search (graph);
		redSearch.Start(graph.nodes[15], graph.nodes[14]);
		GetImage(graph.nodes[15].label).sprite = RedBall;
		GetImage(graph.nodes[14].label).sprite = RedHole;
		while(!redSearch.finished){
			redSearch.Step();
		}
		Debug.Log ("RED done. Path length "+redSearch.path.Count+" iterations "+redSearch.iterations);
		RedText.text = "RED: Path length ("+redSearch.path.Count+"), iterations ("+redSearch.iterations+")";
		foreach(var node in redSearch.path){
			GetImage(node.label).color = Color.red;
		}
	}

	Image GetImage(string label){
		var id = Int32.Parse (label);
		var go = mapGroup.transform.GetChild(id).gameObject;
		return go.GetComponent<Image>();
	}

	void ResetMapGroup(Graph graph){
		foreach(var node in graph.nodes){
			if (node.adjacent.Count == 0){
				GetImage(node.label).sprite = Obstacle;
			}
			else{
			GetImage(node.label).color = Color.white;
			}
		}
	}
}
