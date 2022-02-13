using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offsetPosition;
    [SerializeField] private Space offsetPositionSpace = Space.Self;
    [SerializeField] private bool lookAt = true;

    private void Update()
    {
        Refresh();
    }
    public void Refresh()
    {
        //follow the same position as the target adding the offset to have a better view
        if (offsetPositionSpace == Space.Self){
            transform.position = target.TransformPoint(offsetPosition);
        }
        else{
            transform.position = target.position + offsetPosition;
        }

        //follow the same rotation as the target
        if (lookAt){
            transform.LookAt(target);
        }
        else{
            transform.rotation = target.rotation;
        }
    }
}