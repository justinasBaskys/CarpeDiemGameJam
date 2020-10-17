using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructor : MonoBehaviour
{
    public string[] DestroyTags;
    private void OnTriggerExit2D(Collider2D other)
    {
        foreach(string tag in DestroyTags)
        if (other.tag == tag)
        {
            Debug.Log("Enemy Collision");
            Destroy(other.gameObject);
        }
    }
}
