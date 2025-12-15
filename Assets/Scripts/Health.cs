using UnityEngine;

public class Health : MonoBehaviour
{
    //a health manager
    [Header("HealthData")]
    [SerializeField] private int _team = 0;
    [SerializeField] private float _maxHealth = 100;

    private float _currentHealth;

    public int Team => _team;
    public float HealthPercentage => _currentHealth / _maxHealth;

    //To destrpy the element if needed
    public void ApplyDamage(float damage)
    {
        if(_currentHealth < 0) return;

        _currentHealth = Mathf.Clamp(_currentHealth - damage, 0, _maxHealth);

        if (_currentHealth <= 0) {

            if (gameObject.GetComponent<CharacterControl>() != null && GameManager.instance != null) {
                GameManager.instance.endGame();
            }

            Destroy(gameObject);        
        }
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
    }
}
