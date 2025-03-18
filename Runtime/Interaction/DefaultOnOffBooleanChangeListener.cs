using UnityEngine;
using UnityEngine.Events;

public class DefaultOnOffBooleanChangeListener : MonoBehaviour
{
    public bool m_isOn;
    public UnityEvent<bool> m_onOffUpdate;
    public UnityEvent m_onOn;
    public UnityEvent m_onOff;
    public void SetBoolean(bool value)
    {
       
            m_isOn = value;
            m_onOffUpdate.Invoke(value);
            if (value)
            {
                m_onOn.Invoke();
            }
            else
            {
                m_onOff.Invoke();
            }
        
    }
}
