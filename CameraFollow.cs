using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;

    [SerializeField] float cameraSpeed;

    [SerializeField] float offSet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {   
        transform.position = Vector3.Lerp(transform.position,new Vector3(0,target.position.y,+ offSet -10), cameraSpeed *Time.deltaTime ) ;
        
    }
}
