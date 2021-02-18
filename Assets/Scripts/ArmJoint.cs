using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmJoint : MonoBehaviour
{
    public ArmJoint m_child;
    public ArmJoint GetChlid()
    {
        return m_child;
    }
    public void Rotate(Vector3 target,float _angle)
    {
        
            transform.Rotate(target * _angle);
        
       
       

    }
    public float GetHeight()
    {
        return m_child.transform.position.y;
    }
}
