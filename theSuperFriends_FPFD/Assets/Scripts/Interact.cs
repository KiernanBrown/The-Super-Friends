using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour
{

    public float interactDistance = 30.0f;
    public Animator anim;
    public GameObject player;
    Vector3 position;
    float animationTimer = 0.0f;

    // Use this for initialization
    void Start ()
    {
        anim.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        position = new Vector3(gameObject.transform.position.x, player.transform.position.y, gameObject.transform.position.z);
        if (animationTimer > 0.0f)
        {
            animationTimer -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.E) && Vector3.Distance(player.transform.position, position) < interactDistance && animationTimer <= 0.0f)
        {
            anim.enabled = true;
            anim.Play(0);
            animationTimer = anim.GetCurrentAnimatorStateInfo(0).length / anim.speed;
        }
	}

    void OnGUI()
    {
        if(Vector3.Distance(player.transform.position, position) < interactDistance && animationTimer <= 0.0f)
        {
            GUI.Box(new Rect(Screen.width / 2 - 200, 10, 400, 40), "Press E to Interact with this object!");
        }
    }
}
