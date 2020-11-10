using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    [SerializeField]
    GameObject objectToPool = null;

    [SerializeField]
    int poolSize = 0;

    Queue<GameObject> pool = new Queue<GameObject>();

    private static Dictionary<string, ObjectPooling> poolDictionary = new Dictionary<string, ObjectPooling>();
    public static ObjectPooling Find(string poolName)
    {
        return poolDictionary[poolName];
    }

    // Start is called before the first frame update
    void Start()
    {
        poolDictionary.Add(gameObject.name, this);

        for (int i = 1; i <= poolSize; i++)
        {
            GameObject instance = Instantiate(objectToPool);
            instance.name += i.ToString();
            instance.SetActive(false);
            instance.transform.parent = transform;
            pool.Enqueue(instance);
        }
    }

    public GameObject Spawn(Vector3 position, Quaternion rotation)
    {
        if (pool.Count == 0)
        {
            return null;
        }
        else
        {
            GameObject instance = pool.Dequeue();
            instance.transform.position = position;
            instance.transform.rotation = rotation;
            instance.SetActive(true);
            return instance;
        }
    }

    public void ReturnToPool(GameObject myObject)
    {
        myObject.SetActive(false);
        pool.Enqueue(myObject);
    }

}
