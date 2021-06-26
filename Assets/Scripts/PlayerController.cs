using System;
using UnityEngine;

/// <summary>
/// handles player animations, movements and collisions
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float speed;
    [SerializeField] private float jump;

    private Rigidbody2D _playerRigidbody2D;
    private static readonly int Speed = Animator.StringToHash("speed");
    private static readonly int DidCrouch = Animator.StringToHash("didCrouch");
    private static readonly int DidJump = Animator.StringToHash("didJump");
    private static readonly int ShouldPlayDeathAnimation = Animator.StringToHash("shouldPlayDeathAnimation");


    private void Awake()
    {
        _playerRigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var horizontalSpeed = Input.GetAxisRaw("Horizontal");
        var verticalSpeed = Input.GetAxisRaw("Vertical");

        ApplyHorizontalSpeed(horizontalSpeed);
        ApplyJumpMechanics(Input.GetAxisRaw("Jump"));
        MoveCharacter(horizontalSpeed);
    }

    private void ApplyJumpMechanics(float jump)
    {
        animator.SetBool(DidJump, jump > 0);
        if (jump > 0)
        {
            _playerRigidbody2D.AddForce(new Vector2(0f, this.jump), ForceMode2D.Force);
        }
    }

    private void MoveCharacter(float horizontalSpeed)
    {
        var transform1 = transform;
        var vector = transform1.position;
        vector.x += horizontalSpeed * speed * Time.deltaTime;
        transform1.position = vector;
    }

    private void ApplyHorizontalSpeed(float horizontalSpeed)
    {
        animator.SetFloat(Speed, Mathf.Abs(horizontalSpeed));
        ApplyScale(horizontalSpeed);
    }

    private void ApplyScale(float horizontalSpeed)
    {
        var scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * horizontalSpeed < 0 ? -1f : 1f;
        transform.localScale = scale;
    }


    public void OnPlayerDead()
    {
        Debug.Log("OnPlayerDead");
        animator.SetBool(ShouldPlayDeathAnimation, true);
    }

    private void OnDeathAnimationComplete()
    {
        Debug.Log("OnDeathAnimationComplete");
        animator.SetBool(ShouldPlayDeathAnimation, false);
    }
}