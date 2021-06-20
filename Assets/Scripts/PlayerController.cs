using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private static readonly int Speed = Animator.StringToHash("speed");

    private void Update()
    {
        var speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat(Speed, Mathf.Abs(speed));

        var scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * speed < 0 ? -1f : 1f;
        transform.localScale = scale;
    }
}