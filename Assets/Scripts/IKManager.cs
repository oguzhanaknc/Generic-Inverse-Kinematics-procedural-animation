using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKManager : MonoBehaviour
{
    public ArmJoint m_root;
    public GameObject m_foot;
    public GameObject target;
    public GameObject newTarget;
    public float m_threshold = 0.05f;
    public float moveSpeed = 10f;
    public int m_steps = 20;
    public float distance;
    public bool zig;
    private int stepCount = 1;
    float CalculateSlope(ArmJoint _joint)
    {
        float deltaTheta = 0.01f;
        float distance1 = GetDistance(m_foot.transform.position, target.transform.position);
        _joint.Rotate(Vector3.up, deltaTheta);
        float distance2 = GetDistance(m_foot.transform.position, target.transform.position);
        _joint.Rotate(Vector3.up, -deltaTheta);

        return (distance2 - distance1) / deltaTheta;
    }
    float CalculateSlopeZ(ArmJoint _joint)
    {
        float deltaTheta = 0.01f;
        float distance1 = GetDistance(m_foot.transform.position, target.transform.position);
        _joint.Rotate(Vector3.forward, deltaTheta);
        float distance2 = GetDistance(m_foot.transform.position, target.transform.position);
        _joint.Rotate(Vector3.forward, -deltaTheta);

        return (distance2 - distance1) / deltaTheta;


    }
    public void Step()
    {
        for (int i = 0; i < m_steps; i++)
        {
            if (GetDistance(m_foot.transform.position, target.transform.position) > m_threshold)
            {
                ArmJoint currnet = m_root;
                float slopeZ = CalculateSlopeZ(currnet);
                currnet.Rotate(Vector3.forward, -slopeZ * moveSpeed);
                currnet = currnet.GetChlid();
                while (currnet != null)
                {
                    float slope = CalculateSlope(currnet);

                 
                    currnet.Rotate(Vector3.up, -slope * moveSpeed);

                    currnet = currnet.GetChlid();
           
                }
            }
        }
        if (zig )
        {
            if (stepCount % 2 == 0)
            {
                distance = 4.1f;
            }
            else
            {
                distance = 2.1f;
            }
        }
        else
        {
            distance = 4.1f;
        }

        if (GetDistance(newTarget.transform.position, target.transform.position) >= distance )
        {
            target.transform.position = newTarget.transform.position;
            stepCount += 1;
            
        }
   
    }
    float GetDistance(Vector3 _point1,Vector3 _point2)
    {
        return Vector3.Distance(_point1, _point2);
    }
    public float GetHeight()
    {
        return m_root.GetHeight();
    }
}
