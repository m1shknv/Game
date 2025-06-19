using DG.Tweening;
using UnityEngine;
using System; 

[RequireComponent(typeof(CanvasGroup))]
public class Popup : MonoBehaviour, IPopup
{
    private CanvasGroup _canvasGroup;
    private Transform _rectTransform;

    public event Action OnPopupHidden; 

    public bool IsVisible => _canvasGroup.alpha > 0f;

    private void Awake()
    {
        TryGetComponent(out _canvasGroup);
        _rectTransform = transform;

        _canvasGroup.alpha = 0f;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;

        _rectTransform.localScale = Vector3.one * 0.8f;
    }

    public void Show()
    {
        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.interactable = true;

        _canvasGroup.DOFade(1f, 0.5f).SetUpdate(true);
        _rectTransform.DOScale(1f, 0.5f)
            .SetEase(Ease.OutElastic)
            .SetUpdate(true);
    }

    public void Hide()
    {
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.interactable = false;

        _canvasGroup.DOFade(0f, 0.5f).SetUpdate(true);
        _rectTransform.DOScale(0.8f, 0.5f)
            .SetEase(Ease.InBack)
            .SetUpdate(true);

        OnPopupHidden?.Invoke(); 
    }

    public void OnCloseButtonPressed()
    {
        AudioManager.Instance?.PlayButtonClick();
        Hide();
    }
}
