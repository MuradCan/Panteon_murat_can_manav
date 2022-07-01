using UnityEngine;

[RequireComponent(typeof(Collider))]

public class SprayScript : MonoBehaviour
{
    public GameObject sprayBall, particleEffect;
    private Camera mainCamera;
    private float CameraZDistance;
    // Start is called before the first frame update
    void Start()
    {
        particleEffect.SetActive(false);
        mainCamera = Camera.main;
        CameraZDistance = Camera.main.WorldToScreenPoint(transform.position).z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetMouseButtonUp(0))
        {
            particleEffect.SetActive(false);
        }
        
    }

    private void OnMouseDrag()
    {
        
        Vector3 ScreenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 20);
        Vector3 NewWorldPosition = Camera.main.ScreenToWorldPoint(ScreenPosition);
        transform.position = NewWorldPosition;
        Vector3 pos = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5));
        Instantiate(sprayBall, transform.position, transform.rotation);
        particleEffect.SetActive(true);
    }

    private void OnMouseUp()
    {
        transform.position = new Vector3(-3f, 1.21f, 176f);
    }
}
