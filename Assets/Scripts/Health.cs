using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	TextMesh tm;

	// Use this for initialization
	void Start () {

		tm = GetComponent<TextMesh> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		//face the camera
		transform.forward = Camera.main.transform.forward;

	}

	public int current() {

		return tm.text.Length;

	}

	public void decrease(int damage) {

        if (current() > 1 && current() > damage)
            tm.text = tm.text.Remove(tm.text.Length - damage);
        else
        {
            Destroy(transform.parent.gameObject);
        }
	}
}
