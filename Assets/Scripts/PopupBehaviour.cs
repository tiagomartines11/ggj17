using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupBehaviour : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void Play(string msg)
    {
        var panel = transform.Find("Canvas").Find("Panel");
        panel.gameObject.SetActive(true);
        panel.Find("Text").gameObject.GetComponent<Text>().text = msg;
        StartCoroutine(Dismiss(1.5f));
    }

    IEnumerator Dismiss (float time)
    {
        yield return new WaitForSeconds(time);

        var panel = transform.Find("Canvas").Find("Panel");
        panel.gameObject.SetActive(false);
    }
}
