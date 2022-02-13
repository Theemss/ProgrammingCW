using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hardAI : MonoBehaviour
{
    public float sensorLength = 2.0f;
    public float speed = 8.0f;
    public float directionValue = 1.0f;
    public float turnValue = 0.0f;
    public float turnSpeed = 50.0f;
    int angle = 0;
    int plus = 1;
    Collider myCollider;

    // Initialisation
    void Start()
    {
        myCollider = transform.GetComponent<Collider>();
    }
    void Update()
    {
        RaycastHit hit;
        int flag = 0;
        //right sensor
        if(Physics.Raycast(transform.position, transform.right, out hit, (sensorLength + transform.localScale.x))){
            if (hit.collider.tag != "Obstacle" || hit.collider == myCollider){
                return;
            }
            //if the right sensor detect something we changed the turn value to go on the other side
            turnValue -= 1;
            flag++;
        }
        //left sensor
        if (Physics.Raycast(transform.position, -transform.right, out hit, (sensorLength + transform.localScale.x))){
            if (hit.collider.tag != "Obstacle" || hit.collider == myCollider){
                return;
            }
            //if the left sensor detect something we changed the turn value to go on the other side
            turnValue += 1;
            flag++;
        }
        //front sensor
        if (Physics.Raycast(transform.position, transform.forward, out hit, (sensorLength + transform.localScale.z))){
            if (hit.collider.tag != "Obstacle" || hit.collider == myCollider){
                return;
            }
            //if the front sensor detect something we changed the direction value to go backward
            // just if we are going frontward
            if (directionValue == 1.0f){
                directionValue = -1;
            }
            flag++;
        }
        //back sensor
        if (Physics.Raycast(transform.position, -transform.forward, out hit, (sensorLength + transform.localScale.z))){
            if (hit.collider.tag != "Obstacle" || hit.collider == myCollider){
                return;
            }
            //if the back sensor detect something we changed the direction value to go frontward
            // just if we are going backward
            if (directionValue == -1.0f){
                directionValue = 1;
            }
            flag++;
        }
        //if nothing happened, we just keep the same way, it's why the flags are here
        if (flag == 0){
            turnValue = 0;
        }
        //the rnd allows me to have 90% luck to stay moving on the same way and 10% luck to change his way
        int rnd = Random.Range(0, 100);
        //if we are in the 90% luck, we just add 5° per frame, it will be efficient with the Quaternion.Euler
        //if we are in the 10% luck, we just remove 5° per frame, it will be efficient with the Quaternion.Euler
        if (rnd <= 90){
            if (plus == 1){
                angle += 5;
            }
            else
            {
                angle -= 5;
            }
        }
        else{
            if (plus == 1){
                plus = 0;
            }
            else{
                plus = 1;
            }
        }
        //we applying the changements according to the values changes (rotation and position)
        transform.rotation = Quaternion.Euler(0, angle%360, 0);
        transform.Rotate(Vector3.up * (turnSpeed * turnValue) * Time.deltaTime);
        transform.position += transform.forward * (speed * directionValue) * Time.deltaTime;
    }
}
