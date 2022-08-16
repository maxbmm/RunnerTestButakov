using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(SoundManager))]
public class PlayerMovement : MonoBehaviour
{
    private SO_LevelConfig config;
    private int _currentLine = 1;
    private SoundManager _soundManager;
    private bool _canMove = true;
    private void Awake()
    {
        config = Resources.Load<SO_LevelConfig>("LevelConfig");
        _soundManager = GetComponent<SoundManager>();
    }
    private void Start()
    {
        transform.position = new Vector3(config.Lines[_currentLine].x, transform.position.y, transform.position.z);    
    }
    void Update()
    {
        if (Input.GetButtonDown("Horizontal") & _canMove)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                _currentLine = Mathf.Clamp(_currentLine + 1, 0, 2);
                _soundManager.PlaySwipeSoundFx();
                transform.DOLocalMoveX(config.Lines[_currentLine].x, 0.1f);
            }
            else
            {
                _currentLine = Mathf.Clamp(_currentLine - 1, 0, 2);
                _soundManager.PlaySwipeSoundFx();
                transform.DOLocalMoveX(config.Lines[_currentLine].x, 0.1f);
            }
        }
    }
    public void StopMove() => _canMove = false;
    
    public void StartMove() => _canMove = true;

    
}
