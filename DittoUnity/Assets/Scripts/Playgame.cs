using UnityEngine;
using UnityEngine.SceneManagement;

public class Playgame : MonoBehaviour
{
    // The public function the button will call when it is clicked
    public void loadLevel(string levelName)
    {
        // Takes in a string level name and uses it to load that level
        PlayerPrefs.SetFloat("PlayerHealth", 10);
        PlayerPrefs.SetFloat("PlayerHolding", 0);
        SceneManager.LoadScene(levelName);
    }
}
