using UnityEngine;
using UnityEngine.UI;

public class ScriptHealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;

    [SerializeField] private Image _fillBar;

    private void Update()
    {
        _fillBar.fillAmount = _health.HealthPercentage;
    }
}
