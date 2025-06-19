using System;

public interface IPlayerInput
{
    event Action OnNotesPressed;
    event Action OnPausePressed;
}
