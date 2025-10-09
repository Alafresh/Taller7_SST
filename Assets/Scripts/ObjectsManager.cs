using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
//using Meta.XR.Editor.Tags;
using System;
using Unity.VisualScripting;

public class ObjectsManager : MonoBehaviour
{
    //Este código va a permitir el fácil establecimiento de EPP en la escena y la calidad que le responde dependiendo de la situación
    //La idea es que aparezca en el inspector un menú desplegable con las diferentes categorías de EPP, se seleccione cuáles van a estar en la situación
    //Después se debe elegir por cada categoría cuál de sus opciones son de mejor o peor calidad dependiendo de la tarea

    [SerializeField] public List<Categoria> categoriasEnEscena;
    [SerializeField] public List<GameObject> eppSeleccionados;
    [SerializeField] public List<bool> eppCorrectos;


    

    #region Pooling

    [SerializeField] private int defaultPoolSize;
    [SerializeField] private int maxPoolSize;
    [SerializeField] private ObjectToPoolPrefab objectToPool;
    // para usar el pool llamar las funciones pool.Clear Removes all pooled items
    // pool.Get Get an instance from the pool. If the pool is empty then a new instance will be created.
    // pool.Release Returns the instance back to the pool.
    // https://docs.unity3d.com/2021.1/Documentation/ScriptReference/Pool.IObjectPool_1.html
    [SerializeField] private IObjectPool<ObjectToPoolPrefab> pool;

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
    #endregion

    void SpawnObject(Vector3 position, Quaternion rotation) {
        ObjectToPoolPrefab objectInstance = pool.Get();
        objectInstance.transform.position = position;
        objectInstance.transform.rotation = rotation;
    }
}
