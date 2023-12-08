using UnityEngine;

public class Target : MonoBehaviour
{
    public float speed = 3.0f;
    private Vector3[] _routePoints;
    private int _currentPointIndex = 0;
    private EnemySpawner _spawner;

    public void SetSpawner(EnemySpawner spawner)
    {
        _spawner = spawner;
    }

    public void SetRoutePoints(Vector3[] routePoints)
    {
        _routePoints = routePoints;
    }

    void Update()
    {
        MoveOnRoute();
    }

    private void MoveOnRoute()
    {
        if (_routePoints != null && _routePoints.Length > 0)
        {
            Vector3 targetPoint = _routePoints[_currentPointIndex];

            transform.position = Vector3.MoveTowards(transform.position, targetPoint, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPoint) < 0.1f)
            {
                _currentPointIndex = (_currentPointIndex + 1) % _routePoints.Length;
            }
        }
    }
}