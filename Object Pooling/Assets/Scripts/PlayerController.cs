using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float tilt;              // tilt factor
    public Boundary boundary;       // movememnt boundary

    public GameObject shot;         // bullet prefab
    public Transform shotSpawn;     // the turret (bullet spawn location)
    public Rigidbody myRigidbody;   // reference to rigitbody
    public float fireRate = 0.5f;
    private float nextFire = 0.0f;

    public float smoothing = 5;     // this value is used for smoothing ovement
    private Vector3 smoothDirection;// used to smooth out mouse and touch control

    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // keyboard
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // if keyboard direction key is pressed
        if (moveHorizontal != 0 || moveVertical != 0)
        {
            myRigidbody.velocity = new Vector3(moveHorizontal, 0.0f, moveVertical) * speed;

        }


        transform.position = new Vector3
        (
            Mathf.Clamp(transform.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(transform.position.z, boundary.zMin, boundary.zMax)
        );


        myRigidbody.rotation = Quaternion.Euler(0, 0, myRigidbody.velocity.x * -tilt);
    }

    void Update()
    {
        // Should we fire a bullet?
        if ((Input.GetButton("Fire1") || Input.GetKeyDown(KeyCode.Space)) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }
    }

    public GameObject Shoot()
    {
        //Original individual instantion approach (BAD FOR PERFORMANCE):
        //GameObject bullet = Instantiate(shot, shotSpawn.position, shotSpawn.rotation);

        //First time spawning by using ObjectPooling:
        //GameObject bullet = GameObject.Find("BulletPooling").GetComponent<ObjectPooling>().Spawn(shotSpawn.position, shotSpawn.rotation);

        //Final version of our ObjectPooling:
        GameObject bullet = ObjectPooling.Find("BulletPooling").Spawn(shotSpawn.position, shotSpawn.rotation);
        return bullet;
    }
}
