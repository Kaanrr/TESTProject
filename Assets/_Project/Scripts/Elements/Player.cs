using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameDirector gameDirector;
    public int startHealth;
    private int _currentHealth;

    
    private PlayerNavigator _playerNavigator;

    private bool _isDead;

    public GameObject interactingObject;
    public float touchDistance;
    public LayerMask interactableLayerMask;

    private bool _haveKey;

    private void Awake()
    {
        _playerNavigator = GetComponent<PlayerNavigator>();
    }

    private void Update()
    {
        Debug.DrawRay(transform.position + Vector3.up, transform.forward * touchDistance);
        if(Physics.Raycast(transform.position + Vector3.up, transform.forward, out var hit, touchDistance, interactableLayerMask))
        {
            interactingObject = hit.transform.gameObject;
        }
        else
        {
            interactingObject = null;
        }
        if(Input.GetKeyDown(KeyCode.E) && interactingObject != null)
        {
            ExecuteInteractingObject();
        }
    }

    private void ExecuteInteractingObject()
    {
        var door = interactingObject.GetComponent<Door>();
        if(door != null)
        {
            door.DoorInteracted(_haveKey);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Key"))
        {
            Destroy(other.gameObject);
            _haveKey = true;
        }
    }


    internal void RestartPlayer()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        _isDead = false;
        _currentHealth = startHealth;
        gameDirector.playerHealthUI.UpdateHealth(1);
        gameObject.SetActive(true);
        _playerNavigator.ResetPosition();
    }
    
    internal void GetHit()
    {
        if(_isDead)
        {
            return;
        }

        _currentHealth -= 1;
        if (_currentHealth <= 0)
        {
            Die();
        }

        gameDirector.audioManager.PlayPlayerGetHitSFX();
        gameDirector.cameraHolder.ShakeCamera(.5f, .5f);
        gameDirector.playerHealthUI.UpdateHealth((float)_currentHealth / startHealth);
        gameDirector.playerHitUI.PopPlayerHitUI();
    }

    private void Die()
    {
        _isDead = true;
        gameObject.SetActive(false);
    }
    public void RefillHealth()
    {
        _currentHealth = startHealth;
        gameDirector.playerHealthUI.UpdateHealth(1);
    }

    public void UseKey()
    {
        _haveKey = false;
    }
}
