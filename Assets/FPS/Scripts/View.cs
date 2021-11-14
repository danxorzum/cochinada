using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class View : MonoBehaviour
{
    public RectTransform _pointScope;
    public Image _view;


    public void ShakeScope(float duration, float strength)
    {
        _pointScope.DOComplete();
        _pointScope.DOShakePosition(duration, strength);
    }

    public void ShowDamageView()
    {
        Sequence seq = DOTween.Sequence();
        seq
        .Append(_view.DOColor(new Color(1, 0, 0, 1), .5f).SetEase(Ease.InFlash))
        .Append(_view.DOColor(new Color(1, 0, 0, 0), .3f).SetEase(Ease.OutFlash));
        
    }

    public void ShowDeadView()
    {
        _view.sprite = null;
        _view.DOComplete();
        _view.DOColor(new Color(0, 0, 0, 1), 3).SetEase(Ease.InSine).OnComplete(() => {
            MainMenu.GotoMenu();
        });
    }
}
