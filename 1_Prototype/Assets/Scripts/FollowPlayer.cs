using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform boy;  
    public Transform CameraTarget;
    public float cameraYDistance = 1.5f;
   
    public float maxDegreesDelta = 0.2f;

    private void Start()
    {
        
    }

    void LateUpdate()
    {

        
        transform.position = Vector3.MoveTowards(transform.position, CameraTarget.position, maxDegreesDelta);

        Ray ray = new Ray(transform.position+Vector3.up*5, Vector3.down);
        if(Physics.Raycast(ray,out RaycastHit hit))
        {
            Debug.Log(hit.collider.gameObject.name);
            if (transform.position.y-1f <= hit.point.y)
            {
                Vector3 cameraOffset = new Vector3(CameraTarget.position.x, hit.point.y + 1.0f, CameraTarget.position.z);
                CameraTarget.position = cameraOffset;
            }
            else if(Mathf.Abs(hit.point.y-CameraTarget.position.y)>cameraYDistance)
            {
                CameraTarget.localPosition = new Vector3(CameraTarget.localPosition.x, cameraYDistance, CameraTarget.localPosition.z);
            }
            
        }

        transform.LookAt(boy.transform.position-boy.transform.right*1.5f);
    }

    void LookRotation(Vector3 boy)
    {
        var lookRotation = Quaternion.LookRotation(new Vector3(boy.x, transform.position.y, boy.z) - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, maxDegreesDelta);

    }


}
