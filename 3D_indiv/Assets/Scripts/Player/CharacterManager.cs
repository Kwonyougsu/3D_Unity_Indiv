using UnityEngine;

public class CharacaterManager : MonoBehaviour
{
    private static CharacaterManager _instance;

    public static CharacaterManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("CharacaterManager").AddComponent<CharacaterManager>();
            }
            return _instance;
        }
    }

    public Player _player;

    public Player player
    {
        get { return _player; }
        set { _player = value; }
    }

    private void Awake()
    {
        if(_instance != null)
        {
            Destroy(_instance);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
