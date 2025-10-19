using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using System;
using Unity.VisualScripting;

public class ObjectsManager : MonoBehaviour
{

    #region Pooling

    [SerializeField] private int defaultPoolSize;
    [SerializeField] private int maxPoolSize;
    [SerializeField] private ObjectToPoolPrefab objectToPool;
    // para usar el pool llamar las funciones pool.Clear Removes all pooled items
    // pool.Get Get an instance from the pool. If the pool is empty then a new instance will be created.
    // pool.Release Returns the instance back to the pool.
    // https://docs.unity3d.com/2021.1/Documentation/ScriptReference/Pool.IObjectPool_1.html
    private IObjectPool<ObjectToPoolPrefab> pool;

    private void Awake() {
        pool = new ObjectPool<ObjectToPoolPrefab>(CreateObject, 
            GetFromPool, ReleaseToPool, DestroyPooledObject, true, defaultPoolSize, maxPoolSize);
    }

    public ObjectToPoolPrefab CreateObject() {
        ObjectToPoolPrefab objectToInstance = Instantiate(objectToPool);
        objectToInstance.Pool = pool;
        return objectToInstance;
    }

    public void GetFromPool(ObjectToPoolPrefab objectInstance) {
        objectInstance.gameObject.SetActive(true);
    }

    public void ReleaseToPool(ObjectToPoolPrefab objectInstance) {
        objectInstance.gameObject.SetActive(false);
    }
    public void DestroyPooledObject(ObjectToPoolPrefab objectInstace) {
        Destroy(objectInstace.gameObject);
    }
    public void SpawnObject(Transform position) {
        ObjectToPoolPrefab objectInstance = pool.Get();
        objectInstance.transform.position = position.position;
        
    }
    #endregion

}
