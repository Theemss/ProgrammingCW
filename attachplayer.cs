using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attachplayer : MonoBehaviour {
    //the character become the son of the object on which is he jumping on
    private void OnTriggerEnter(Collider other)
    {
        other.transform.parent = transform;
    }
    private void OnTriggerExit(Collider other)
    {
        other.transform.parent = null;
    }
}
