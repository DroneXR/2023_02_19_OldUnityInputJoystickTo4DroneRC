using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static XinputToFourDroneRC;

public class OldUnityInputFourXboxToRCInput : MonoBehaviour
{
    public string m_labelDownUP = "_DRC_DOWN_UP";
    public string m_labelRotateLeftRight = "_DRC_ROTATE_LEFT_RIGHT";
    public string m_labelLeftRight = "_DRC_LEFT_RIGHT";
    public string m_labelBackFront = "_DRC_BACK_FRONT";
    public float m_deathZone = 0.1f;

    public XboxFromOldInput[] m_joysticksRecovered = new XboxFromOldInput[4];
    public XboxFromOldInputEvent[] m_joysticksRecoveredEvent = new XboxFromOldInputEvent[4];

    [System.Serializable]
    public class XboxFromOldInput
    {
        public float m_downUP;
        public float m_rotateLeftRight;
        public float m_leftRight;
        public float m_backFront;
    }

    [System.Serializable]
    public class XboxFromOldInputEvent
    {
        public FloatEvent m_downUP;
        public FloatEvent m_rotateLeftRight;
        public FloatEvent m_leftRight;
        public FloatEvent m_backFront;
    }
    [System.Serializable]
    public class FloatEvent : UnityEvent<float> { }

    void Update()
    {
        for (int i = 0; i < 4 ; i++)
        {
            m_joysticksRecovered[i].m_downUP = Input.GetAxis(i + m_labelDownUP);
            m_joysticksRecovered[i].m_rotateLeftRight = Input.GetAxis(i + m_labelRotateLeftRight);
            m_joysticksRecovered[i].m_leftRight = Input.GetAxis(i + m_labelLeftRight);
            m_joysticksRecovered[i].m_backFront = Input.GetAxis(i + m_labelBackFront);

            if (m_joysticksRecovered[i].m_downUP < m_deathZone && m_joysticksRecovered[i].m_downUP > -m_deathZone)
                m_joysticksRecovered[i].m_downUP = 0;
            if (m_joysticksRecovered[i].m_rotateLeftRight < m_deathZone && m_joysticksRecovered[i].m_rotateLeftRight > -m_deathZone)
                m_joysticksRecovered[i].m_rotateLeftRight = 0;
            if (m_joysticksRecovered[i].m_leftRight < m_deathZone && m_joysticksRecovered[i].m_leftRight > -m_deathZone)
                m_joysticksRecovered[i].m_leftRight = 0;
            if (m_joysticksRecovered[i].m_backFront < m_deathZone && m_joysticksRecovered[i].m_backFront > -m_deathZone)
                m_joysticksRecovered[i].m_backFront = 0;

            m_joysticksRecoveredEvent[i].m_downUP.Invoke(m_joysticksRecovered[i].m_downUP);
            m_joysticksRecoveredEvent[i].m_rotateLeftRight.Invoke(m_joysticksRecovered[i].m_rotateLeftRight);
            m_joysticksRecoveredEvent[i].m_leftRight.Invoke(m_joysticksRecovered[i].m_leftRight);
            m_joysticksRecoveredEvent[i].m_backFront.Invoke(m_joysticksRecovered[i].m_backFront);

        }
    }
}
