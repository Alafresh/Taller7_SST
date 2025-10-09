using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using System;
using Unity.VisualScripting;

public class ObjectsManager : MonoBehaviour
{
    //Este c�digo va a permitir el f�cil establecimiento de EPP en la escena y la calidad que le responde dependiendo de la situaci�n
    //La idea es que aparezca en el inspector un men� desplegable con las diferentes categor�as de EPP, se seleccione cu�les van a estar en la situaci�n
    //Despu�s se debe elegir por cada categor�a cu�l de sus opciones son de mejor o peor calidad dependiendo de la tarea

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
    #endregion

    public void SpawnObject(Transform position) {
        ObjectToPoolPrefab objectInstance = pool.Get();
        objectInstance.transform.position = position.position;
        
    }
}
