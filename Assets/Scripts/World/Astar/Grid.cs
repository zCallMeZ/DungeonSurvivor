using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO Mettre des commentaires

public class Grid : MonoBehaviour
{
	[SerializeField] private LayerMask unwalkableMask;
	[SerializeField] private Vector2 gridWorldSize;
	[SerializeField] private float nodeRadius;

	private Node[,] grid;
	private List<Node> path;

	private float nodeDiameter;
	private int gridSizeX, gridSizeY;

	private void Awake()
	{
		nodeDiameter = nodeRadius * 2;
		gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
		gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);
        StartCoroutine(Delay());
	}

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(4.0f);
        CreateGrid();
    }

	public void CreateGrid()
	{
		grid = new Node[gridSizeX, gridSizeY];
		Vector2 worldBottomLeft = (Vector2)transform.position - Vector2.right * gridWorldSize.x / 2.0f - Vector2.up * gridWorldSize.y / 2.0f;

		for (int x = 0; x < gridSizeX; x++)
		{
			for (int y = 0; y < gridSizeY; y++)
			{
				Vector2 worldPoint = worldBottomLeft + Vector2.right * (x * nodeDiameter + nodeRadius) + Vector2.up * (y * nodeDiameter + nodeRadius);
				bool walkable = !(Physics2D.OverlapCircle(worldPoint, nodeRadius - 0.1f, unwalkableMask));
				grid[x, y] = new Node(walkable, worldPoint, x, y);
			}
		}
	}

	public List<Node> GetNeighbours(Node node)
	{
		List<Node> neighbours = new List<Node>();

		for (int x = -1; x <= 1; x++)
		{
			for (int y = -1; y <= 1; y++)
			{
				if (x == 0 && y == 0)
					continue;

				int checkX = node.gridX + x;
				int checkY = node.gridY + y;

				if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY)
				{
					neighbours.Add(grid[checkX, checkY]);
				}
			}
		}
		return neighbours;
	}

	public Node NodeFromWorldPoint(Vector2 worldPosition)
	{
		float percentX = (worldPosition.x + 10.0f ) / gridWorldSize.x;
		float percentY = (worldPosition.y + 20.0f ) / gridWorldSize.y;
		percentX = Mathf.Clamp01(percentX);
		percentY = Mathf.Clamp01(percentY);

		int x = Mathf.RoundToInt((gridSizeX - 1) * percentX);
		int y = Mathf.RoundToInt((gridSizeY - 1) * percentY);
		return grid[x, y];
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireCube(transform.position, new Vector2(gridWorldSize.x, gridWorldSize.y));

		if (grid != null)
		{
			foreach (Node n in grid)
			{
				Gizmos.color = (n.canWalk) ? Color.white : Color.red;
				if (path != null)
					if (path.Contains(n))
						Gizmos.color = Color.black;
				Gizmos.DrawWireSphere(n.worldPos, nodeRadius - 0.1f);
			}
		}
	}
}
