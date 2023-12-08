using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

   private void Update()
    {

        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
}