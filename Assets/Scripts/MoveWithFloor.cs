using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithFloor : MonoBehaviour
{
    public CharacterController Player;
    
    public Vector3 groundPosition;
    public Vector3 lastGroundPosition;
    public string groundName;
    public string lastGroundName;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Player = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.isGrounded)
        {
            RaycastHit hit;
            
            if (Physics.SphereCast(transform.position, Player.height / 0.08f, -transform.up, out hit))
            {
                GameObject groundedIn = hit.collider.gameObject;
                groundName = groundedIn.name;
                groundPosition = groundedIn.transform.position;
                
                if (groundPosition != lastGroundPosition && groundName == lastGroundName)
                {
                    this.transform.position += groundPosition - lastGroundPosition;
                }
                
                lastGroundName = groundName;
                lastGroundPosition = groundPosition;
            }
            
        }
        
        else if (!Player.isGrounded)
        {
            lastGroundName = null;
            lastGroundPosition = Vector3.zero;
        }
    }
    
    private void OnDrawGizmos()
    {
        Player = this.GetComponent<CharacterController>();
        Gizmos.DrawWireSphere(transform.position, Player.height / 0.08f);
    }
}
