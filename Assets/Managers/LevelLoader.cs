using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void RestartLevel() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    
}
