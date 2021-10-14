using UnityEngine;

public class Spawner : MonoBehaviour
{
    private ObjectPool _objectPool;
    

    private void Start()
    {
        _objectPool = ObjectPool.Instance;
    }

    private void FixedUpdate()
    {
        _objectPool.SpawnerFromPool("Cube", transform.position, Quaternion.identity);
        _objectPool.SpawnerFromPool("Sphere", transform.position, Quaternion.identity);
    }
}
