using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastManager : MonoBehaviour
{ /*
      * The wanted length for the Raycast.
      */
    public float distance = 100f;
    void Update()
    {
        transform.position = GetHitPoint(transform.position + Vector3.up * 0.5f , transform.position - Vector3.up * 5)+ Vector3.up * 0.3f;
    }
    Vector3 GetHitPoint(Vector3 start, Vector3 end)
    {
        RaycastHit hit;
        if (Physics.Linecast(start,end,out hit))
        {
          
            return hit.point;
        }
        return end;
    }
}

