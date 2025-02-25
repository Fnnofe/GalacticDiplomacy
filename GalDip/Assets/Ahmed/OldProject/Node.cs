using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    enum NodeType
    {
        StartNode,
        PirateNode,
        EmptyNode,
        FuelNode,
        PlanetNode,
        BlueNode,
        YellowNode,
        VictoryNode
    }
    private GameObject obj;
    LineRenderer lineRenderer;
    [SerializeField] NodeType _nodeType;

    void Awake()
    {
        int randomType = Random.Range(1, 4);
        _nodeType = (NodeType)randomType;
        LineRendererSetup();
    }

    void LineRendererSetup()
    {
        if (lineRenderer == null)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
            lineRenderer.startWidth = 0.01f;
            lineRenderer.endWidth = 0.01f;
            lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
            lineRenderer.positionCount = 0;
        }
    }

    public void DrawLineTo(Node toNode)
    {
        if(toNode == null) return;
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, toNode.transform.position);
    }
}
