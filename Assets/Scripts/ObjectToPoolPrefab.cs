using UnityEngine;
using UnityEngine.Pool;

public class ObjectToPoolPrefab : MonoBehaviour
{
    private IObjectPool<ObjectToPoolPrefab> pool;
    public IObjectPool<ObjectToPoolPrefab> Pool {  set => pool = value; }
}
