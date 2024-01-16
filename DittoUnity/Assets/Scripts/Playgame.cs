using UnityEngine;
using UnityEngine.SceneManagement;

public class Playgame : MonoBehaviour
{
    // The public function the button will call when it is clicked
    public void loadLevel(string levelName)
    {
        // Takes in a string level name and uses it to load that level
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        for(int i = 0; i < enemies.Length; i++){
            Destroy(enemies[i]);
        }
        SceneManager.LoadScene(levelName);
    }

    public void RestartGame()//from checkpoint
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        for(int i = 0; i < enemies.Length; i++){
            Destroy(enemies[i]);
        }
        PlayerPrefs.SetFloat("PlayerHealth", 10);
        PlayerPrefs.SetFloat("PlayerHolding", 0);
        if (PlayerPrefs.GetFloat("CheckpointWeapon") != 0)
        {
            PlayerPrefs.SetFloat("PlayerHolding", PlayerPrefs.GetFloat("CheckpointWeapon"));
        }

        SceneManager.LoadScene(PlayerPrefs.GetString("PlayerCheckpoint"));
    }
    public void StartNewGame()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        for(int i = 0; i < enemies.Length; i++){
            Destroy(enemies[i]);
        }
        PlayerPrefs.SetFloat("PlayerHealth", 10);
        PlayerPrefs.SetFloat("PlayerHolding", 0);
        PlayerPrefs.SetString("PlayerCheckpoint", "Default 1");
        SceneManager.LoadScene("Default 1");
    }
}
