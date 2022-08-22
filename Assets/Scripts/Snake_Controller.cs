using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snake_Controller : MonoBehaviour
{
    private Vector2 _Direction;
    [SerializeField] private GameObject SegmentPrefab;
    private List<GameObject> Segments = new List<GameObject>();


    void Start()
    {
        Reset();
        ResetSegment();
    }
    
    void Update()
    {
        GetUserInput();
    }

    void FixedUpdate()
    {
        SnakeMove();
        MoveSegment();
    }

    public void CreateSegment()
    {
        GameObject _newSegment = Instantiate(SegmentPrefab);
        _newSegment.transform.position = Segments[Segments.Count - 1].transform.position;
            Segments.Add(_newSegment);
    }

    private void ResetSegment()
    {
        for (int i = 1; i < Segments.Count; i++)
        {
            Destroy(Segments[i]);
        }

        Segments.Clear();
        Segments.Add(gameObject);

        for (int i = 0; i < 3; i++)
        {
            CreateSegment();
        }
    }

    private void MoveSegment()
    {
        for (int i = Segments.Count - 1; i > 0; i--)
        {
            Segments[i].transform.position = Segments[i - 1].transform.position;
        }
    }

    private void Reset()
    {
        _Direction = Vector2.right;
        Time.timeScale = .1f;
    }

    private void SnakeMove()
    {
        float x, y;
        x = transform.position.x + _Direction.x;
        y = transform.position.y + _Direction.y;
        transform.position = new Vector2(x, y);
    }

    private void GetUserInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _Direction = Vector2.up;    
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _Direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            _Direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            _Direction = Vector2.right;
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            RestartGame();
        }
    }
}
