using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] Node node;
    private List<Node> nodes = new List<Node>();
    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] private float xSpacing;
    [SerializeField] private float ySpacing;
    

    private void Start()
    {
        GenrateNodes();
        ConnectNodes();
    }

    void GenrateNodes()
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                int randomY = Random.Range(-1, 1);
                int randomX = Random.Range(-1, 1);
                int randomZ = Random.Range(-1, 1);
                Vector3 pos = new Vector3(x * xSpacing + randomX, randomY, z * ySpacing + randomZ);
                Node newNode = Instantiate(node, pos, Quaternion.identity);
                nodes.Add(newNode);
            }
        }
    }

    void ConnectNodes()
    {
        foreach (Node node in nodes) // ✅ Loop through each node
        {
            foreach (Node otherNode in nodes)
            {
                //if (node != otherNode) // Prevent self-connection
                {
                    float distance = Vector3.Distance(node.transform.position, otherNode.transform.position);
                    if (distance <= 6f) // Adjust max distance
                    {
                        node.DrawLineTo(otherNode); // ✅ This ensures each node calls DrawLineTo()
                    }
                }
            }
        }
    }
}
