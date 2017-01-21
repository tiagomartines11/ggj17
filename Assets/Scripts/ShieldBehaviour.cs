using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehaviour : MonoBehaviour {

    public int[] shieldAngles = { 90 };
    public float angularSpeed = 1.5f;
    public float shieldDistance = 1.5f;

    float activeAngle = 0.0f;

    GameObject shieldContainer;

    // Use this for initialization
    void Start()
    {
        activeAngle = 0;

        shieldContainer = new GameObject();

        foreach (int angle in shieldAngles)
        {
            GameObject container = new GameObject();

            GameObject instance = Instantiate(Resources.Load("Shield", typeof(GameObject))) as GameObject;

            instance.transform.parent = container.transform;
            container.transform.parent = shieldContainer.transform;

            container.transform.localPosition = new Vector3(0, 0, 0);

            Quaternion rot = new Quaternion();
            rot.eulerAngles = new Vector3(0, 0, angle);
            container.transform.rotation = rot;

            instance.transform.localPosition = new Vector3(shieldDistance, 0, 0);
        }

        shieldContainer.transform.parent = this.transform;
        shieldContainer.transform.localPosition = new Vector3(0, 0, 0);

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
        shieldContainer.transform.rotation = rot;
    }

    void OnDisable()
    {
        GameObject.Destroy(shieldContainer);
    }
}
