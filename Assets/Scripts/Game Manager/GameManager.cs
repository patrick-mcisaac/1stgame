using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float _playerHealth;


    public float playerHealth
    {
        get
        {
            return _playerHealth;
        }
        set
        {
            _playerHealth = value;
        }
    }

    public static GameManager Instance { get; set; }

    private void Awake()
    {
        Instance = this;
        playerHealth = 100;
    }

}