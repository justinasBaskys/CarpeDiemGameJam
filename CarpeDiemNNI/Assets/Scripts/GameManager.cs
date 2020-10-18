using UnityEngine;

public class GameManager : MonoBehaviour
{
<<<<<<< Updated upstream
=======
    public PlayerMovement playerMovement;
    public Player player;
    public GameObject[] spawners;
    public GameObject foreground;

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

>>>>>>> Stashed changes
    public void EndGame()
    {
        Debug.Log("Game Over");
    }
}
