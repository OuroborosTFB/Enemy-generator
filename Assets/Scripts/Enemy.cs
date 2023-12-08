using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;

    private Vector3 _moveDirection;
    private GameObject _target;

    public void SetTarget(GameObject target)
    {
        _target = target;
        SetMoveDirection((_target.transform.position - transform.position).normalized);
    }

    public void SetMoveDirection(Vector3 direction)
    {
       
        _moveDirection = direction.normalized;
    }

    private void Update()
    {
        if (_target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, _target.transform.position) < 0.1f)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}