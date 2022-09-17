using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeRayCursorScreenSourceMono : MonoBehaviour
{

    public LayerMask m_allowToTouch = -1;
    public Transform m_rayDirection;
    public float m_rayDistance=3000f;
    public float m_radius=0.1f;
    private void Reset()
    {
        m_rayDirection = this.transform;
    }
}
