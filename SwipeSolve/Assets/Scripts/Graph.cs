﻿using UnityEngine;
using System.Collections;

public class Graph{

	public int rows = 0;
	public int cols = 0;
	public Node[] nodes;

	public Graph(int[,] grid){
		rows = grid.GetLength (0);
		cols = grid.GetLength (1);

		nodes = new Node[grid.Length];
		for(var i = 0; i<nodes.Length; i++)
		{
			var node = new Node();
			node.label = i.ToString();
			nodes[i] = node;
		}

		for(var r = 0; r < rows; r++)
		{
			for (var c = 0; c < cols; c++)
			{
				var node = nodes[cols*r + c];

				if(grid[r,c] == 1){
					continue;
				}

				if(r > 0){
					node.adjacent.Add(nodes[cols*(r-1)+c]);
				}

				if(c < cols-1){
					node.adjacent.Add(nodes[cols*r+c+1]);
				}

				if(r < rows-1){
					node.adjacent.Add(nodes[cols*(r+1)+c]);
				}

				if(c > 0){
					node.adjacent.Add(nodes[cols*r+c-1]);
				}

			}
		}
	}

}
