
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(PlayerInput))]
public class NotesHandler : MonoBehaviour
{
    private PlayerInput _input;
    private Button[] _buttons;

    private void Awake()
    {
        TryGetComponent(out _input);
        if (_input)
        {
            _input.OnNotesPressed += HandleNotesPressed;
        }
    }

    private void OnDestroy()
    {
        if (_input)
        {
            _input.OnNotesPressed -= HandleNotesPressed;
        }
    }

    private void HandleNotesPressed()
    {
        SceneController.Instance?.HandleNotesPressed();
    }
}
