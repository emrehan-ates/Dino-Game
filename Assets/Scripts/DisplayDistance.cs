using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class DisplayDistance : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _distText;
    private Transform _playerTran;
    private Vector2 _start;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // void Start()
    // {
    //     _playerTran = GameObject.FindGameObjectWithTag("Players").transform;
    //     _start = _playerTran.position;
    // }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Find player fresh each time scene loads
        var playerObj = GameObject.FindGameObjectWithTag("Players");
        if (playerObj != null)
        {
            _playerTran = playerObj.transform;
            _start = _playerTran.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerTran == null)
            return; // avoid crash

        Vector2 dist = (Vector2)_playerTran.position - _start;

        if (dist.x < 0)
            dist = Vector2.zero;

        _distText.text = dist.x.ToString("F0") + "m";
    }

}
