using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheScript : MonoBehaviour
{
    public GameObject cube1, cube2;
    Collider co_01, co_02;
    Material m;
    public GameObject thePlane;
    void Awake(){
        Scene s = gameObject.scene;
        Debug.Log("awake called by:"+gameObject.name + "@" + s.name);
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start called");
        thePlane  = GameObject.CreatePrimitive(PrimitiveType.Plane);
        cube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube1.transform.position = new Vector3(0, 0.5f, 0);
        cube2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube2.transform.position = new Vector3(0, 3.0f, 0);
        
        m = cube1.GetComponent<Renderer>().material;
        //print("Materials " + Resources.FindObjectsOfTypeAll(typeof(Material)).Length);
        m.color=Color.red;
        co_01=cube1.AddComponent<BoxCollider>();
        co_02=cube2.AddComponent<BoxCollider>();
        cube1.AddComponent<Rigidbody>();
        cube2.AddComponent<Rigidbody>();
        cube1.AddComponent<HandleCollision>();
        cube2.AddComponent<HandleCollision>();
    }

    // Update is called once per frame
    void Update()
    {
        cube1.transform.position += Vector3.up * 0.001f;
        cube1.transform.Rotate(0,1,1);
        cube2.transform.position += new Vector3(0,1,0) * -0.001f;
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        //Debug.DrawRay(transform.position, forward, Color.green);
    }
}

public class HandleCollision:MonoBehaviour{
    void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 position = contact.point;
        //Debug.Log("Collided..");
    }

    void OnCollisionStay(Collision collisionInfo)
    {
        //Debug.Log("CollStay");
        // Debug-draw all contact points and normals
        foreach (ContactPoint contact in collisionInfo.contacts)
        {   
            //Debug.Log(contact.point);
            //Debug.DrawRay(contact.point, contact.normal * 100, Color.yellow);
        }
    }
}