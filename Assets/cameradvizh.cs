using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameradvizh : MonoBehaviour
{


    //public float speed = 5;

    //public KeyCode left = KeyCode.A;
    //public KeyCode right = KeyCode.D;
    //public KeyCode up = KeyCode.W;
    //public KeyCode down = KeyCode.S;
    //public KeyCode rotCamA = KeyCode.Q;
    //public KeyCode rotCamB = KeyCode.E;

    //public Transform startPoint;
    //public int rotationX = 70;
    //public float maxHeight = 15;
    //public float minHeight = 5;
    //public int rotationLimit = 240;

    //private float camRotation;
    //private float height;
    //private float tmpHeight;
    //private float h, v;
    //private bool L, R, U, D;

    //void Start()
    //{
    //	height = (maxHeight + minHeight) / 2;
    //	tmpHeight = height;
    //	camRotation = rotationLimit / 2;
    //	transform.position = new Vector3(startPoint.position.x, height, startPoint.position.z);
    //}

    //public void CursorTriggerEnter(string triggerName)
    //{
    //	switch (triggerName)
    //	{
    //		case "L":
    //			L = true;
    //			break;
    //		case "R":
    //			R = true;
    //			break;
    //		case "U":
    //			U = true;
    //			break;
    //		case "D":
    //			D = true;
    //			break;
    //	}
    //}

    //public void CursorTriggerExit(string triggerName)
    //{
    //	switch (triggerName)
    //	{
    //		case "L":
    //			L = false;
    //			break;
    //		case "R":
    //			R = false;
    //			break;
    //		case "U":
    //			U = false;
    //			break;
    //		case "D":
    //			D = false;
    //			break;
    //	}
    //}

    //void Update()
    //{
    //	if (Input.GetKey(left) || L) h = -1; else if (Input.GetKey(right) || R) h = 1; else h = 0;
    //	if (Input.GetKey(down) || D) v = -1; else if (Input.GetKey(up) || U) v = 1; else v = 0;

    //	if (Input.GetKey(rotCamB)) camRotation += 3; else if (Input.GetKey(rotCamA)) camRotation -= 3;
    //	camRotation = Mathf.Clamp(camRotation, 0, rotationLimit);

    //	if (Input.GetAxis("Mouse ScrollWheel") > 0)
    //	{
    //		if (height < maxHeight) tmpHeight += 1;
    //	}
    //	if (Input.GetAxis("Mouse ScrollWheel") < 0)
    //	{
    //		if (height > minHeight) tmpHeight -= 1;
    //	}

    //	tmpHeight = Mathf.Clamp(tmpHeight, minHeight, maxHeight);
    //	height = Mathf.Lerp(height, tmpHeight, 3 * Time.deltaTime);

    //	Vector3 direction = new Vector3(h, v, 0);
    //	transform.Translate(direction * speed * Time.deltaTime);
    //	transform.position = new Vector3(transform.position.x, height, transform.position.z);
    ////	transform.rotation = Quaternion.Euler(rotationX, camRotation, 0);
    //}






    //    public float cameraSpeed = 5;
    //    public Vector3 thiscamera;
    //    void Awake()
    //    {
    //        thiscamera = this.gameObject.transform.position;
    //    }
    //    void Update ()
    //    {
    //        if (thiscamera.x>X1&&thiscamera.x<X2)
    //        {
    //            if (Input.mousePosition.x > Screen.width - 10)
    //                transform.Translate(Vector3.right* cameraSpeed);
    //            if (Input.mousePosition.x< 10)
    //                transform.Translate(Vector3.left* cameraSpeed);
    //        }
    //        if (thiscamera.z > Z1 && thiscamera.z < Z2)
    //{
    //    if (Input.mousePosition.y > Screen.height - 10)
    //        transform.Translate(Vector3.up * cameraSpeed);
    //    if (Input.mousePosition.y < 10)
    //        transform.Translate(Vector3.down * cameraSpeed);
    //}





    // Start is called before the first frame update
    void LateUpdate()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.x /= Screen.width;
        mousePos.y /= Screen.height;

        Vector3 delta = mousePos - new Vector3(0.5f,0f, 0.5f);

        float sideBorder = Mathf.Min(Screen.width, Screen.height) / 8f;

        float xDist = Screen.width * (0.5f - Mathf.Abs(delta.x));
        float yDist = Screen.height * (0.5f - Mathf.Abs(delta.y));

        if (xDist < sideBorder || yDist < sideBorder)
        {
            delta = delta.normalized;
            delta *= Mathf.Clamp01(1 - Mathf.Min(xDist, yDist) / sideBorder);

            transform.Translate(delta * 8 * Time.deltaTime, Space.Self);
        }
    }
}
