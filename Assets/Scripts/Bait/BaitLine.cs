
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BaitLine : MonoBehaviour
{
    private HingeJoint[] _hinges;
    private LineRenderer _renderer;

    void LoadHinges() => _hinges = transform.GetComponentsInChildren<HingeJoint>();
    void LoadRenderer() => _renderer = transform.GetComponent<LineRenderer>();
    void Start()
    {
        LoadHinges();
        LoadRenderer();
        SortHinges();
        
    }

    private void SortHinges()
    {
        Array.Sort(_hinges, (h1, h2) =>
        {
            Vector3 v1 = h1.transform.TransformPoint(h1.anchor); 
            Vector3 v2 = h2.transform.TransformPoint(h2.anchor);
            if (v1.y < v2.y) return -1; if (v1.y == v2.y) return 0; return 1;
        });
    }

    private void LateUpdate() => ConnectTheDots();


    private void ConnectTheDots()
    {
        List<Vector3> positions = new();
        foreach(var joint in _hinges)
        {
            positions.Add(joint.transform.TransformPoint(joint.anchor));
        }
        _renderer.useWorldSpace = true;
        _renderer.positionCount = positions.Count;

       

        _renderer.SetPositions(positions.ToArray());
    }
}
