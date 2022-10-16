using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float angle;
    [SerializeField] float speed = 10f;
    [SerializeField] GameObject missilePrefab;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        FollowMouse();

        if (Input.GetKeyDown(KeyCode.Space) && gameManager.isGameActive)
        {
            GameObject missile = Instantiate(
                missilePrefab,
                transform.position,
                transform.rotation
            );
        }
    }

    void FollowMouse()
    {
        Vector2 mousePosition = Input.mousePosition;
        Vector2 direction = Camera.main.ScreenToWorldPoint(mousePosition) - transform.position;
        angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.back);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
    }
}
