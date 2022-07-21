using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveScript : MonoBehaviour
{
    public GameObject theCamera;
    // Start is called before the first frame update
    void Start()
    {
        theCamera= gameObject;
        theCamera.transform.rotation*=Quaternion.Euler(0.0f,0.0f,0.0f);
        theCamera.transform.position+=new Vector3(0,0,-15.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //Use Keyboard to move the camera
        if (Input.GetKey("x")) theCamera.transform.position+=new Vector3(0,-0.1f,0);
        if (Input.GetKey("2")) theCamera.transform.position+=new Vector3(0,0.1f,0);

        if (Input.GetKey("a"))theCamera.transform.RotateAround(Vector3.zero, Vector3.up, 100 * Time.deltaTime);
        if (Input.GetKey("d"))theCamera.transform.RotateAround(Vector3.zero, Vector3.up, -100 * Time.deltaTime);
        if (Input.GetKey("w")) CentreRotateTransform(theCamera.transform,true);
        if (Input.GetKey("s")) CentreRotateTransform(theCamera.transform,false);

        if (Input.GetKey("q")) Application.Quit();

        if (Input.GetKey("up")) theCamera.transform.rotation*=Quaternion.Euler(-1.0f,0.0f,0.0f);
        if (Input.GetKey("down")) theCamera.transform.rotation*=Quaternion.Euler(1.0f,0.0f,0.0f);      
        //Debug.Log("MousePos:"+Input.mousePosition.ToString());
        //Debug.Log("camTrnsRt:"+theCamera.transform.rotation.ToString());
        //Debug.Log("camTrnsPs:"+theCamera.transform.position.ToString());
    }

    void CentreRotateTransform(Transform m, bool towards=true){
        //save and undo rotation
        
        m.rotation*=Quaternion.Inverse(m.rotation);
        if (towards)m.position = Vector3.MoveTowards(m.position, Vector3.zero, 10.0f * Time.deltaTime);
        else m.position = Vector3.MoveTowards(m.position, Vector3.zero, -10.0f * Time.deltaTime);
        m.rotation*=Quaternion.Inverse(m.rotation);
        m.LookAt(Vector3.zero);
    }
}
