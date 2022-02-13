using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class respawnfloor : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;

    public int deaths = 0;
    public Text deathText;
    private double delta = 0;
    private double current = 0;

    public void IncreaseDeaths()
    {
        deaths += 1;
        //we transformed the deaths integer to a string printable
        deathText.text = deaths.ToString();
    }
    //if the player jump or fall in the hitbox, we add one death and the player respawn on the respawnpoint
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
                IncreaseDeaths();
            }
        }
    }
}
