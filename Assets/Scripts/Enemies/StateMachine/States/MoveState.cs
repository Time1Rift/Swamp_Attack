using UnityEngine;

public class MoveState : State
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, TargetPlayer.transform.position, _speed * Time.deltaTime);
    }
}