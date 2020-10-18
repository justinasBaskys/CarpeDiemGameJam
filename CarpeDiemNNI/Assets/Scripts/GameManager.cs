using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public Player player;
    public GameObject[] spawners;
    public GameObject foreground, background;
    public EndGameMenu endMenu;
    public float timer, speed, daySpeed;

    private float foregroundTime;
    private bool isFrozen, goingUp;
    public void Start()
    {
        foregroundTime = timer;
        playerMovement.enabled = false;
        foreach (GameObject spawner in spawners)
        {
            spawner.SetActive(false);
        }
        isFrozen = true;
        goingUp = true;
    }

    public void Update()
    {
        
        if(foregroundTime > 0)
		{
            foreground.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            foregroundTime -= Time.deltaTime;
            player.HealPlayer(player.maxHealth);
        }
		else if(isFrozen == true)
		{
            playerMovement.enabled = true;            
            foreach (GameObject spawner in spawners)
            {
                spawner.SetActive(true);
            }
            isFrozen = false;
        }

        if (background.transform.position.y < -970)
		{
            goingUp = false;  
        }
        else if (background.transform.position.y > 0)
		{
            goingUp = true;
		}
        if (goingUp == true) {background.transform.position += new Vector3(0, -daySpeed * Time.deltaTime, 0); }
        else { background.transform.position += new Vector3(0, daySpeed * Time.deltaTime, 0); }
    }

    public void EndGame()
    {
        Debug.Log("Game Over");
        endMenu.EndGamePause();
    }
}
