using System;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerNavigator : MonoBehaviour
{
    public float speed;
    public float jumpPower;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    public bool playerLooksAtMouse;
    public LayerMask lookAtLayerMask;

    private Rigidbody _rb;
    private Transform _transform;
    private bool _isGrounded;

    private PlayerAnimator _playerAnimator;
    

    private void Awake()
    {
        _transform = transform;
        _rb = GetComponent<Rigidbody>();
        _playerAnimator = GetComponent<PlayerAnimator>();
    }
    private void Update()
    {
        if(GameDirector.instance.gameState != GameState.GamePlay)
        {
            return;
        }

        MovePlayerWithKeys(); 
        if (playerLooksAtMouse)
        {
            LookAtMouse();
        }

    }

    private void LookAtMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray.origin, ray.direction, out hit, 50, lookAtLayerMask))
        {
            var lookPos = hit.point;
            lookPos.y = _transform.position.y;
            _transform.LookAt(lookPos);
        }
    }

    void MovePlayerWithKeys()
    {
        var direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;
        }

        var yVelocity = _rb.linearVelocity;

        yVelocity.x = 0;
        yVelocity.z = 0;

        _rb.linearVelocity = direction.normalized * speed + yVelocity;

        

        _isGrounded = Physics.Raycast(_transform.position + Vector3.up * .1f, Vector3.down, 1, lookAtLayerMask);

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rb.linearVelocity = new Vector3(_rb.linearVelocity.x, jumpPower, _rb.linearVelocity.z);
        }
        if (direction.magnitude > .01f && _isGrounded)
        {
            var angle = Vector3.SignedAngle(transform.forward, direction, Vector3.up);
            _playerAnimator.PlayRunAnimation(angle);
        }
        else
        {
            _playerAnimator.PlayIdleAnimation();
        }

        //(*)
        if (direction.magnitude != 01f && _isGrounded)
        {
            GameDirector.instance.audioManager.PlayPlayerWalkSFX();
            
        }



         
    }

    public void ResetPosition()
    {
        _rb.position = Vector3.zero;
    }
}
