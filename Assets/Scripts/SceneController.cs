using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance { get; private set; }

    private IPopup settingsPopup;
    private IPopup notesPopup;
    private IPopup instructionPopup;

    private IPlayerInput _playerInput;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        AudioManager.Instance?.PlayBackgroundMusic();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;

        if (_playerInput != null)
        {
            _playerInput.OnNotesPressed -= HandleNotesPressed;
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        FindPopupsInScene();
        FindPlayerInput();

        if (instructionPopup != null && !instructionPopup.IsVisible)
            instructionPopup.Show();

        Time.timeScale = 1f;
    }

    private void FindPopupsInScene()
    {
        var allPopups = FindObjectsOfType<Popup>();

        settingsPopup = allPopups.FirstOrDefault(p => p.gameObject.name.Contains("SettingsPopup")) as IPopup;
        notesPopup = allPopups.FirstOrDefault(p => p.gameObject.name.Contains("NotesPopup")) as IPopup;
        instructionPopup = allPopups.FirstOrDefault(p => p.gameObject.name.Contains("InstructionPopup")) as IPopup;
    }

    private void FindPlayerInput()
    {
        _playerInput = FindObjectOfType<PlayerInput>();
        if (_playerInput == null) return;

        _playerInput.OnNotesPressed += HandleNotesPressed;
    }

    public void HandleNotesPressed()
    {
        if (notesPopup == null) return;

        var pauseHandler = FindObjectOfType<PauseHandler>();
        if (pauseHandler != null && pauseHandler.IsPaused)
            return;

        if (notesPopup.IsVisible)
            notesPopup.Hide();
        else
            notesPopup.Show();
    }

    public void LoadSceneByName(string sceneName)
    {
        if (string.IsNullOrEmpty(sceneName))
        {
            Debug.LogWarning("Имя сцены пустое.");
            return;
        }

        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
