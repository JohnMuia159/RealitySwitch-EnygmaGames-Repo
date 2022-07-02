using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public GameObject bow;
    public GameObject arrow;
    public float launchForce;
    public Transform shotPoint;

    public GameObject point;
    GameObject[] points;
    public int numberOfPoints;
    public float spaceBetweenPoints;
    public Vector2 dir;
    private bool bowActive;

    public NewPlayer player;

    // Start is called before the first frame update
    void Start()
    {
        points = new GameObject[numberOfPoints];
        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i] = Instantiate(point, shotPoint.position, Quaternion.identity);
        }
        player = GetComponent<NewPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.bowEquip)
        {
            bow.gameObject.SetActive(true);
            bowActive = true;
        }
        else if (!player.bowEquip)
        {
            bow.gameObject.SetActive(false);
            bowActive = false;
        }

        Vector2 bowPosition = bow.transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dir = mousePosition - bowPosition;

        if (player.isFacingRight)
            bow.transform.right = dir;
        else if (player.isFacingLeft)
            bow.transform.right = -dir;

        if (Input.GetMouseButtonDown(0) && bowActive)
        {
            Shoot();
        }

        //for (int i = 0; i < numberOfPoints; i++)
        //{
        //    points[i].transform.position = PointPosition(i * spaceBetweenPoints);
        //}
    }

    void Shoot()
    {
        GameObject newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
       
        if (player.isFacingRight)
            newArrow.GetComponent<Rigidbody2D>().velocity = bow.transform.right * launchForce;
        else if (player.isFacingLeft)
            newArrow.GetComponent<Rigidbody2D>().velocity = -bow.transform.right * launchForce;
    }

    Vector2 PointPosition(float t)
    {
        Vector2 position = (Vector2)shotPoint.position + (dir.normalized * launchForce * t) + 0.5f * Vector2.right * (t*t);
        return position;
    }
}
