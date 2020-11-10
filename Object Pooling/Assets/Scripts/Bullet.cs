using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float speed = 0;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    public void DestroyBullet()
    {
        //Original destruction approach (BAD FOR PERFORMANCE):
        //Destroy(gameObject);

        //First time destroying by using ObjectPooling:
        //GameObject.Find("BulletPooling").GetComponent<ObjectPooling>().ReturnToPool(gameObject);

        //Final version of our ObjectPooling:
        ObjectPooling.Find("BulletPooling").ReturnToPool(gameObject);
    }
}