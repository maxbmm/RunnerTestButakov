using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SoundManager), typeof(ScoreSystem), typeof(AnimationSystem))]
public class PlayerCollision : MonoBehaviour
{
    public event Action OnDeath;

    [SerializeField] private GameObject _mesh;
    
    private SO_LevelConfig config;
    private FX_Controller _fxManager;
    private ScoreSystem _scoreSystem;
    private AnimationSystem _animationSystem;
    private SoundManager _soundManager;
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        config = Resources.Load<SO_LevelConfig>("LevelConfig");
        _fxManager = GetComponent<FX_Controller>();
        _animationSystem = GetComponent<AnimationSystem>();
        _scoreSystem = GetComponent<ScoreSystem>();
        _soundManager = GetComponent<SoundManager>();
        _playerMovement = GetComponent<PlayerMovement>();
        
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.layer == config.CoinLayerIndex)
        {
            
            other.gameObject.SetActive(false);

            _scoreSystem.AddScore(1);
            _animationSystem.CollectAnimation();
            _soundManager.PlayCollectSoundFx();
            _fxManager.PlayPickupFx();

        }
        else if (other.gameObject.layer == config.ObstacleLayerIndex)
        {
            
            _mesh.SetActive(false);
            _fxManager.PlayDeathFx();
            _animationSystem.StopMove();
            _playerMovement.StopMove();
            _soundManager.PlayCrashSoundFx();

            HashSet<PushableBehaviour> pushables = PushableBehaviour.Instances;

            foreach (var pushable in pushables)
            {
                pushable.StopRun();
                
            }

            StartCoroutine(ParticleIsCancel());

        }
    }

    private IEnumerator ParticleIsCancel()
    {
        while (_fxManager.DeathCancel() == true)
        {
            yield return new WaitForSeconds(0.5f);
        }
        OnDeath?.Invoke();
    }
}
