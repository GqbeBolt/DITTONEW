using UnityEngine;
using UnityEngine.SceneManagement;

public class Playgame : MonoBehaviour
{
    // The public function the button will call when it is clicked
    public void loadLevel(string levelName)
    {
        // Takes in a string level name and uses it to load that level
        SceneManager.LoadScene(levelName);
    }
}
