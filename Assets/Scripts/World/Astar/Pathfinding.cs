using System.Collections.Generic;
using UnityEngine;

//TODO Mettre des commentaires

public class Pathfinding : MonoBehaviour
{
    private Grid grid;

    private void Awake()
	{
		grid = GetComponent<Grid>();
	}

	public List<Node> FindPath(Vector2 seekerPos, Vector2 targetPos)
	{
		Node startNode = grid.NodeFromWorldPoint(seekerPos);
		Node targetNode = grid.NodeFromWorldPoint(targetPos);

		List<Node> openSet = new List<Node>();
		List<Node> closedSet = new List<Node>();
		openSet.Add(startNode);

		while (openSet.Count > 0)
		{
			Node node = openSet[0];
			for (int i = 1; i < openSet.Count; i++)
			{
				if (openSet[i].fCost <= node.fCost)
				{
                    if (openSet[i].hCost < node.hCost)
                    {
                        node = openSet[i];
                    }
				}
			}

			openSet.Remove(node);
			closedSet.Add(node);

			if (node == targetNode)
			{
                return RetracePath(startNode, targetNode);
			}

			foreach (Node neighbour in grid.GetNeighbours(node))
			{
				if (!neighbour.canWalk || closedSet.Contains(neighbour))
				{
					continue;
				}

				int newCostToNeighbour = node.gCost + GetDistance(node, neighbour);
				if (newCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour))
				{
					neighbour.gCost = newCostToNeighbour;
					neighbour.hCost = GetDistance(neighbour, targetNode);
					neighbour.parent = node;

                    if (!openSet.Contains(neighbour))
                    {
                        openSet.Add(neighbour);
                    }
				}
			}
		}
        return new List<Node>();
	}

    private List<Node> RetracePath(Node startNode, Node endNode)
	{
		List<Node> path = new List<Node>();
		Node currentNode = endNode;

		while (currentNode != startNode)
		{
			path.Add(currentNode);
			currentNode = currentNode.parent;
		}
		path.Reverse();
		return path;

	}

    private int GetDistance(Node nodeA, Node nodeB)
	{
		int distanceX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
		int distanceY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

		if (distanceX > distanceY) {
			return 14 * distanceY + 10 * (distanceX - distanceY);
        }
		return 14 * distanceX + 10 * (distanceY - distanceX);
	}
}
