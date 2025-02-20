using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshProUGUI TimerText;
    public TextMeshProUGUI coinCount;
    public float horizontalAxis;
    Camera camera;
    int coins;
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        // Debug.DrawRay(camera.transform.position, mousePos - camera.transform.position, Color.red);
        if (Input.GetMouseButtonDown(0))
        {
            MouseWorldInteract(mousePos);
        }

         horizontalAxis = Input.GetAxis("Horizontal");
         
         camera.transform.Translate(Vector3.right * horizontalAxis * Time.deltaTime);
        

        int timeLeft = 300 - (int)(Time.time);
        TimerText.text = $"Time<br> {timeLeft}";
    }

    private void MouseWorldInteract(Vector3 mousePos)
    {
        Ray ray = camera.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100f))
        {
            if (hit.collider.CompareTag("Brick"))
            {
                Object.Destroy(hit.collider.gameObject);
            }
            else if (hit.collider.CompareTag("Question"))
            {
                coins++;
                coinCount.text = "x" + coins.ToString("D2");
            }
        }
    }
}
