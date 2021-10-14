using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Object : MonoBehaviour, IObjectPool
{
    [SerializeField] private float _upForce = 1f;
    [SerializeField] private float _sideForce = 0.1f;

    public void OnObjectSpawn()
    {
        float xForse = Random.Range(-_sideForce, _sideForce);
        float yForse = Random.Range(_upForce / 2f, _upForce);
        float zForse = Random.Range(-_sideForce, _sideForce);

        Vector3 force = new Vector3(xForse, yForse, zForse);

        GetComponent<Rigidbody>().velocity = force;
    }    
}
