using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float aimLength = 2f;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private CameraShake shake;

    private Vector3 direction = Vector3.zero;

    private LineRenderer line;
    private Vector3[] linePositions = new Vector3[2];
    private Vector3 aimDirection;

    private Camera cam;

    private bool canSlowMo = true;

    private int life = 3;
    
    void Start()
    {
        line = GetComponent<LineRenderer>();
        cam = Camera.main;
    }

    void Update()
    {
        Move();
        Aim();
        
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.Space) && canSlowMo)
        {
            canSlowMo = false;
            EasySlowMotion.StartSlowMo(0.2f, 0.4f, 2f, 0.4f);
            Invoke("ReSlowMo", 6f);
        }
    }

    private void Move()
    {
        direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        transform.position += direction * speed * Time.deltaTime;
    }

    private void Aim()
    {
        Vector2 mousePosition = Input.mousePosition;
        Vector3 mouseOnPlane = Vector3.zero;

        Ray cameraRay = cam.ScreenPointToRay(mousePosition);
        Plane groundPlane = new Plane(Vector3.up, transform.position);
        float rayLength;
        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            mouseOnPlane = cameraRay.GetPoint(rayLength);
            mouseOnPlane.y = transform.position.y;
        }

        aimDirection = (mouseOnPlane - transform.position).normalized * aimLength;

        linePositions[0] = transform.position;
        linePositions[1] = transform.position + aimDirection;

        line.SetPositions(linePositions);
    }

    private void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        newBullet.transform.forward = aimDirection;
        shake.Shake(4f, 0.2f, 0.1f, true);
    }

    public void LoseOneLife()
    {
        life--;
        shake.Shake(15f, 0.3f, 0.5f, true);
        if (life == 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        gameOverPanel.SetActive(true);
        Destroy(this.gameObject);
    }

    private void ReSlowMo()
    {
        canSlowMo = true;
    }
}