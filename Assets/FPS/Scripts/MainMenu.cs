using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private void Start() {
        
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
    public void GotoScene(int index)
    {
        SceneManager.LoadSceneAsync(index);
    }

    public static void GotoMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
