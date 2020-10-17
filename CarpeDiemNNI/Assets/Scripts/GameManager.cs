using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public Player player;
    public GameObject[] spawners;

    public void Start()
    {
        /*
        playerMovement.enabled = false;
        foreach (GameObject spawner in spawners)
        {
            spawner.SetActive(false);
        }
        */
    }

    public void Update()
    {
        
    }

    public void EndGame()
    {
        Debug.Log("Game Over");
    }
}
