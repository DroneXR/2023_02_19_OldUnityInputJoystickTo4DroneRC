using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static XinputToFourDroneRC;

public class OldUnityInputFourXboxToRCInputString : MonoBehaviour
{

    public Eloi.PrimitiveUnityEvent_DoubleString m_idAndCommandEvent;
    public string m_playerXboxId="UNITYXBOX";
    public string m_labelDownUP = "_DRC_DOWN_UP";
    public string m_labelRotateLeftRight = "_DRC_ROTATE_LEFT_RIGHT";
    public string m_labelLeftRight = "_DRC_LEFT_RIGHT";
    public string m_labelBackFront = "_DRC_BACK_FRONT";
    public float m_deathZone = 0.2f;

    
    public XboxFromOldInput[] m_test = new XboxFromOldInput[4] ;

    [System.Serializable]
    public class XboxFromOldInput
    {
        public float m_labelDownUP;
        public float m_labelRotateLeftRight;
        public float m_labelLeftRight;
        public float m_labelBackFront;
        public string m_lastCommand;
    }

    void Update()
    {
        for (int i = 0; i < 4 ; i++)
        {
            m_test[i  ].m_labelDownUP = Input.GetAxis(i + m_labelDownUP);
            m_test[i  ].m_labelRotateLeftRight = Input.GetAxis(i + m_labelRotateLeftRight);
            m_test[i  ].m_labelLeftRight = Input.GetAxis(i + m_labelLeftRight);
            m_test[i  ].m_labelBackFront = Input.GetAxis(i + m_labelBackFront);



            if (m_test[i].m_labelDownUP < m_deathZone && m_test[i].m_labelDownUP > -m_deathZone)
                m_test[i].m_labelDownUP = 0;
            if (m_test[i].m_labelRotateLeftRight < m_deathZone && m_test[i].m_labelRotateLeftRight > -m_deathZone)
                m_test[i].m_labelRotateLeftRight = 0;
            if (m_test[i].m_labelLeftRight < m_deathZone && m_test[i].m_labelLeftRight > -m_deathZone)
                m_test[i].m_labelLeftRight = 0;
            if (m_test[i].m_labelBackFront < m_deathZone && m_test[i].m_labelBackFront > -m_deathZone)
                m_test[i].m_labelBackFront = 0;

            string cmd = string.Format("rc {0} {1} {2} {3}",
      m_test[i].m_labelRotateLeftRight,
      m_test[i].m_labelDownUP,
      m_test[i].m_labelLeftRight,
      m_test[i].m_labelBackFront);
     
            ;
            if (m_test[i].m_lastCommand.Trim().Length == 0)
            {
                m_test[i].m_lastCommand = cmd;
            }
            else if (m_test[i].m_lastCommand != cmd)
            {
                m_test[i].m_lastCommand = cmd;
                m_idAndCommandEvent.Invoke(m_playerXboxId+" "+ i, m_test[i].m_lastCommand);
            }

        }
    }
}
