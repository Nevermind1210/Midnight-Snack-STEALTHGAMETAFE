using UnityEngine;

public class Quit : MonoBehaviour
{
    public void QuitGame()
    {
        // quits game when built
        Application.Quit();
        // quits play mode in editor
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
