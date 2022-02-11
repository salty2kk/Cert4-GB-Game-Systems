using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("RPG Game / Character / Mouse Look")]
public class MouseLook : MonoBehaviour
{



    public enum RotationalAxis
    {
        MouseX,
        MouseY
    }

    #region Variables
    [Header("Rotation")]
    public RotationalAxis axis;
    [Header("Sensetivity")]
    [Range(0, 500)]
    public float sensetivity = 100f;
    [Header("Rotation Clamp")]
    public float minY = -60f;
    public float maxY = 60f;
    private float m_rotY;
    public bool invert;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        Cursor.visible = false;

        if(GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
        }

        if(GetComponent<Camera>())
        {
            axis = RotationalAxis.MouseY;
        }
    }

    // Update is called once per frame
    void Update()
    {
        #region Mouse X
        if (axis == RotationalAxis.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensetivity * Time.deltaTime, 0);
        }
        #endregion
        #region Mouse Y
        else
        {
            m_rotY += Input.GetAxis("Mouse Y") * sensetivity * Time.deltaTime;

            m_rotY = Mathf.Clamp(m_rotY, minY, maxY);

            if(invert)
            {
                transform.localEulerAngles = new Vector3(m_rotY, 0, 0); // invert
            }
            else
            {
                transform.localEulerAngles = new Vector3(-m_rotY, 0, 0); //normal
            }
        }
        #endregion
    }
}
