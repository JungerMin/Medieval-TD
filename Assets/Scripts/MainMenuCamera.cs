using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCamera : MonoBehaviour
{
    public Transform centre;
    public float speed = 1f;
    void Update()
    {
        transform.LookAt(centre);
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }
}
