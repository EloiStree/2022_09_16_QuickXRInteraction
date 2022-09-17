using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverGazeSourceMono : MonoBehaviour
{
    public GazableObjectMono m_linkedGaze;
    public string m_id;
    public string m_name;

    public void OnMouseOver()
    {
        m_linkedGaze.SetAsGazedBySource(m_id, m_name);
    }
    private void OnMouseEnter()
    {
        m_linkedGaze.SetAsGazedBySource(m_id, m_name);
    }

    private void OnMouseExit()
    {

        m_linkedGaze.RemoveGazeSource(m_id);

    }

    private void Reset()
    {
        m_id = System.Guid.NewGuid().ToString();
    }
}
