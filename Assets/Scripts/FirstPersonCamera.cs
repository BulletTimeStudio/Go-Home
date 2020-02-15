using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{

    public Vector3 offSet;
    private Transform target;
    [Range (0, 1)] public float lerpValue;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("kumi_v1").transform;
    }

    // Update is called once per frame
    void Update()
    {  
        transform.position = Vector3.Lerp(transform.position, target.position + offSet, lerpValue);
        transform.LookAt(target);
        alejar();
        acercar();
    }
        
    void alejar()
    {
        if (target.position.x <= 5.99 && target.position.y >= 20 && offSet.z > -10f && offSet.y < 4f)
        {
            offSet.z = offSet.z - 0.1f;
            offSet.y = offSet.y + 0.1f;
        }
    }
    
    void acercar()
    {
        if (target.position.x >= 5.99 && offSet.z < -5f && offSet.y > 2f)
            {
                offSet.z = offSet.z + 0.1f;
                offSet.y = offSet.y - 0.1f;
            }
    }
}
