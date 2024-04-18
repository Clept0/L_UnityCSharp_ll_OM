using UnityEngine;

public class playerControl : MonoBehaviour {
    bool jmp; int hlth = 100; string n; float spd = 5f;
    public void Update() { 
        if (Input.GetKeyDown(KeyCode.Space) && jmp == false) { jmp = true; }
        var x = Input.GetAxis("Horizontal") * spd;
        var z = Input.GetAxis("Vertical") * spd;
        transform.Translate(x * Time.deltaTime, 0, z * Time.deltaTime);
        if (jmp) { GetComponent<Rigidbody>().AddForce(Vector3.up * 5f, ForceMode.VelocityChange); jmp = false; }
        if (hlth <= 0) { Debug.Log("GameOver"); }
    }
}
