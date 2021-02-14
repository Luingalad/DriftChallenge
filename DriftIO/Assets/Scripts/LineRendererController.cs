using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererController : MonoBehaviour
{
    public Transform WreckingBall;
    public Transform PlayerModel;

    private LineRenderer _lineRenderer;
    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        _lineRenderer.positionCount = 2;
        _lineRenderer.SetPosition(0, PlayerModel.position);
        _lineRenderer.SetPosition(1, WreckingBall.position);
    }
}
