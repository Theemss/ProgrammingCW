using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;
    private double delta = 0;
    private double current = 0;
    GameObject obj;
    void Awake()
    {
        obj = GameObject.FindGameObjectWithTag("Floor");
    }
    //if the player hit one of the AI capsules, we add one death and the player respawn on the respawnpoint
    private void OnTriggerEnter(Collider other)
    {
        current = Time.timeAsDouble;
        if (other.CompareTag("Player"))
        {
            //it allows us to add just one death when the function is called, so we wait 1 sec between two deaths
            //if we don't do that, the fonction can be called two times during the same fall, and added two deaths by fall
            if (current - delta > 1)
            {
                delta = Time.timeAsDouble;
                player.transform.position = respawnPoint.transform.position;
                Physics.SyncTransforms();
                //we called the function "IncreaseDeaths" who are in the respawnfloor script
                obj.GetComponent<respawnfloor>().IncreaseDeaths();
            }
        }
    }
}
