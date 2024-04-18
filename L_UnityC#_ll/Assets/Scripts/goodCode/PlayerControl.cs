using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private bool jump;
    private int health = 100;
    [SerializeField] private float speed = 5f;


    public void Update()
    { 
        if (Input.GetKeyDown(KeyCode.Space) && jump == false)
        {
            jump = true;
        }

        var x = Input.GetAxis("Horizontal") * speed;
        var z = Input.GetAxis("Vertical") * speed;

        transform.Translate(x * Time.deltaTime, 0, z * Time.deltaTime);

        if (jump)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 5f, ForceMode.VelocityChange);
            jump = false;
        }

        if (health <= 0)
        {
            Debug.Log("GameOver");
        }
    }
}
