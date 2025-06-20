using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] private GameObject cutscenePanel;

    public void OpenCutscene()
    {
        if (cutscenePanel)
            cutscenePanel.SetActive(true);
    }

    public void CloseCutscene()
    {
        if (cutscenePanel)
            cutscenePanel.SetActive(false);
    }
}
