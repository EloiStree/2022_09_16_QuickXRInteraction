using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public interface GazableObject {
    public void SetAsGazedBySource(string gazeId, string gazeName);
    public void RemoveGazeSource(string gazeId);
}

public class GazableObjectMono : MonoBehaviour, GazableObject
{

    public float m_gazeGlobalTimeCountSeconds;
    public Dictionary<string, string> m_isGazingTheObject = new Dictionary<string, string>();
    public Dictionary<string, float> m_isGazingTheObjectTime = new Dictionary<string, float>();
    public int m_gazingCount;
    public bool m_useDebug=true;
    public List<string> m_isGazingId = new List<string>();
    public List<string> m_isGazingNameDebug = new List<string>();
    public List<string> m_isGazingNameWithTimeDebug = new List<string>();

    public DefaultBooleanChangeListener m_isGazed;
    public void SetAsGazedBySource(string gazeId, string gazeName)
    {
        if (!m_isGazingTheObject.ContainsKey(gazeId))
        {
            m_isGazingTheObject.Add(gazeId, gazeName);
            m_isGazingTheObjectTime.Add(gazeId, 0);
        }

    }
    public void RemoveGazeSource(string gazeId)
    {
        if (m_isGazingTheObject.ContainsKey(gazeId))
        {
            m_isGazingTheObject.Remove(gazeId);
            m_isGazingTheObjectTime.Remove(gazeId);
        }
    }
    public void Update()
    {
        float deltaTime = Time.deltaTime;
        m_gazingCount = m_isGazingTheObject.Count;
        m_isGazingId = m_isGazingTheObject.Keys.ToList();
        if (m_gazingCount > 0)
        {
            m_gazeGlobalTimeCountSeconds += deltaTime;
        }
        else
        {
            m_gazeGlobalTimeCountSeconds = 0;
        }
        if (m_useDebug)
            m_isGazingNameDebug = m_isGazingTheObject.Values.ToList();
        if (m_useDebug)
            m_isGazingNameWithTimeDebug.Clear();
        for (int i = 0; i < m_isGazingId.Count; i++)
        {
            m_isGazingTheObjectTime[m_isGazingId[i]] += deltaTime;
            if(m_useDebug)
            m_isGazingNameWithTimeDebug.Add( m_isGazingTheObjectTime[m_isGazingId[i]] + " | " + m_isGazingId[i]);

        }
        
        m_isGazed.SetBoolean(m_gazingCount > 0);
    }
}
