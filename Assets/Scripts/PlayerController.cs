using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
    private Rigidbody rd;
	public float szybkosc;
	public GUIText countText = new GUIText();
    public GUIText winText = new GUIText();

  
	private int licznik;
    public float speed;
    private Rigidbody rb;

    void Start()
    {
        winText.text = "";
        countText.text = "";
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }
    void OnTriggerEnter(Collider other) 
	{
		if(other.gameObject.name == "PickUp")
		{
			other.gameObject.SetActive(false);
			licznik = licznik + 1;
			SetCountText();

        }

        if (other.gameObject.name == "PickUp_3")
        {
            other.gameObject.SetActive(false);
            licznik = licznik + 3;
            SetCountText();

        }
    }
	
	void SetCountText ()
	{
		countText.text = "Liczba punktów: " + licznik.ToString();
		if(licznik >= 9)
		{            
			winText.text = "Wygrałeś !";
            Time.timeScale = 0;
        }
    }
}
