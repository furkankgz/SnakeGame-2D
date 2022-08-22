using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    [SerializeField] private float _minX, _maxX, minY, maxY;
    [SerializeField] private Snake_Controller _snake;

    void Start()
    {
        RandomChickenPosition();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Snake"))
        {
            RandomChickenPosition();
            _snake.CreateSegment();
        }
    }

    private void RandomChickenPosition()
    {
        transform.position = new Vector2(
                Mathf.Round(Random.Range(_minX, _maxX)) + .5f,
                Mathf.Round(Random.Range(minY, maxY)) + .5f
            );
    }

    void Update()
    {
        
    }
}
