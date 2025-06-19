using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] private GameObject cutscenePanel;

    public void CloseCutscene()
    {
        cutscenePanel.SetActive(false);
    }

    public void ShowCutscene()
    {
        cutscenePanel.SetActive(true);
    }
}
