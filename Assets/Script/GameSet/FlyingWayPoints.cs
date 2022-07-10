using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingWayPoints : MonoBehaviour
{
    private static Transform[] _flyPoints;

    public static Transform[] FlyingPoints => _flyPoints;

    private void Awake()
    {
        _flyPoints = new Transform[transform.childCount];
        for (int i = 0; i < _flyPoints.Length; i++)
        {
            _flyPoints[i] = transform.GetChild(i);
        }
    }
}
