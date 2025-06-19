using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PauseButton : MonoBehaviour
{
    private PauseHandler _pauseHandler;

    private void Awake()
    {
        _pauseHandler = FindObjectOfType<PauseHandler>();
        var button = GetComponent<Button>();

        if (_pauseHandler && button)
        {
            button.onClick.AddListener(() =>
            {
                AudioManager.Instance?.PlayButtonClick();

                _pauseHandler.TogglePause();
            });
        }
        else
        {
            Debug.LogWarning("PauseHandler or Button not found!");
        }
    }
}
