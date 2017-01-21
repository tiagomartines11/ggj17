using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehaviour : MonoBehaviour {

    public int[] shieldAngles = { 1 };
    public float angularSpeed = 1.5f;
    public float shieldDistance = 1.5f;

    float activeAngle = 0.0f;

    GameObject aimContainer;

    // Use this for initialization
    void Start()
    {
        activeAngle = 0;

        aimContainer = new GameObject();

        foreach (int angle in shieldAngles)
        {
            GameObject container = new GameObject();

            GameObject instance = Instantiate(Resources.Load("Shield", typeof(GameObject))) as GameObject;

            instance.transform.parent = container.transform;
            container.transform.parent = aimContainer.transform;

            container.transform.localPosition = new Vector3(0, 0, 0);

            Quaternion rot = new Quaternion();
            rot.eulerAngles = new Vector3(0, 0, angle);
            container.transform.rotation = rot;

            instance.transform.localPosition = new Vector3(shieldDistance, 0, 0);
        }

        aimContainer.transform.parent = this.transform;
        aimContainer.transform.localPosition = new Vector3(0, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (activeAngle < 360)
            activeAngle += angularSpeed;
        else
            activeAngle = 0;

        Quaternion rot = new Quaternion();
        rot.eulerAngles = new Vector3(0, 0, activeAngle);
        aimContainer.transform.rotation = rot;
    }
}
