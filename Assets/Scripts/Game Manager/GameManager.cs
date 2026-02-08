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

    void Start()
    {
        playerHealth = 100;
    }
}