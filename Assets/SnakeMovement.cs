

using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.UI;

public class SnakeMovement : MonoBehaviour
{
    private Vector2 _directionToMove = Vector2.right;
    public Transform segmentPrefab;
    private List<Transform> _segments;
    [SerializeField] 
    private Text text; 
    [SerializeField]
    private Text high_text;
    int score;
    int highschore;
    void Start()
    {
        _segments = new List<Transform>();
        _segments.Add(transform);
        text.text = "0";
        score = 0;
        highschore = 0;
        high_text.text = highschore.ToString();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            _directionToMove = Vector2.left;
        }    
        else if (Input.GetKeyDown(KeyCode.D))
        {
            _directionToMove = Vector2.right;
        }
        else if(Input.GetKeyDown(KeyCode.W))
        {
            _directionToMove = Vector2.up;
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            _directionToMove = Vector2.down;
        }
    }
    void FixedUpdate()
    {
        for (int i = _segments.Count -1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }
        this.transform.position = new Vector3(Mathf.Round( this.transform.position.x + _directionToMove.x),MathF.Round(this.transform.position.y + _directionToMove.y,0f));   
    }
    void Grow()
    {
        Transform segment = Instantiate(segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);

        //scoring
        score += 1;
        text.text = score.ToString();
        if(score > highschore)
        {
            highschore = score;
            high_text.text = highschore.ToString();
        }

    }
    void ResetState()
    {
        for(int i = 1; i < _segments.Count;i++)
        {
            Destroy(_segments[i].gameObject);
        } 
        _segments.Clear();
        _segments.Add(transform);
            
        transform.position = Vector3.zero;

        //scoring

        score = 0;
        text.text = score.ToString();

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Food")
        {
            Grow();
        }
        else if(other.tag == "Obstacle")
        {
            ResetState();
        }
    }
}
