using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endgame : MonoBehaviour
{
    [SerializeField] private Transform player;
    private void OnTriggerEnter(Collider other)
    {
        //if the player jump on the last object, the EngGame fonction will be called
        if (other.CompareTag("Player"))
        {
             FindObjectOfType<GameManager>().EndGame();
        }
    }
}
