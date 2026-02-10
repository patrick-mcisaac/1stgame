using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class GameManager : MonoBehaviour
{
    private float _playerHealth { get; set; }

    public float PlayerHealth
    {
        get
        {
            return _playerHealth;
        }
        set
        {
            _playerHealth += value;
        }
    }

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

}
