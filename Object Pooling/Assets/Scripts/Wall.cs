using UnityEngine;

public class Wall : MonoBehaviour
{
    public GameObject explosion;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            GameObject instance = Instantiate(explosion, other.transform.position, other.transform.rotation);
            instance.transform.parent = GameObject.Find("Explosions").transform;
            other.GetComponent<Bullet>().DestroyBullet();
        }
        
    }
}
