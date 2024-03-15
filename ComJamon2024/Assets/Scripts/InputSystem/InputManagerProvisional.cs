using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagerProvisional : MonoBehaviour
{
    CharacterMovement _chM;

    #region MobileInputParameters
    private Vector2 leftScreenMobileInput;
    private List<touchLocation> touches = new List<touchLocation>();
    private float minFingerDisplacement = 60f;
    #endregion

    void Start()
    {
        _chM = GetComponent<CharacterMovement>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump")) _chM.JumpPressed();
        if(Input.GetButtonUp("Jump")) _chM.JumpReleased();
        if (Input.GetButtonDown("Dash")) _chM.DashPressed();

        #region mobileInput
        GetTouchesOnScreen(new Vector2( Screen.width / 2, 0), new Vector2(Screen.width, Screen.height), ref leftScreenMobileInput);
        if (leftScreenMobileInput != Vector2.zero)
        {
            _chM.DashPressed(leftScreenMobileInput);
        }
        
        #endregion
    }


    void FixedUpdate()
    {
        _chM.SetXInput(Input.GetAxisRaw("Horizontal"));
        _chM.SetYInput(Input.GetAxisRaw("Vertical"));
    }

    #region Mobile Input
    void GetTouchesOnScreen(Vector2 screenZone0, Vector2 screenZone1, ref Vector2 returnMove)
    {
        int i = 0;
        while (i < Input.touchCount)
        {
            Touch t = Input.GetTouch(i);

            if (t.phase == TouchPhase.Began)
            {
                if (t.position.x < screenZone0.x || t.position.x > screenZone1.x || t.position.y < screenZone0.y || t.position.y > screenZone1.y) return;
                touches.Add(new touchLocation(t.fingerId, t.position));

            }
            else if (t.phase == TouchPhase.Ended)
            {
                touchLocation thisTouch = touches.Find(touchLocation => touchLocation.touchId == t.fingerId);
                if (thisTouch != null)
                {
                    LookForFingerMovement(thisTouch.startPosition, t.position, thisTouch.startTime, ref returnMove);

                    touches.RemoveAt(touches.IndexOf(thisTouch));
                }
            }
            i++;
        }
    }

    void LookForFingerMovement(Vector2 startPos, Vector2 finishPos, float startTime, ref Vector2 returnMove)
    {
        float totalTime = Time.time - startTime;

        if (totalTime > 0.5f) return;

        Vector2 movement = finishPos - startPos;
        if (movement.x > minFingerDisplacement)
        {
            movement.x = 1;
        }
        else if (movement.x < -minFingerDisplacement)
        {
            movement.x = -1;
        }
        else
        {
            movement.x = 0;
        }

        if (movement.y > minFingerDisplacement)
        {
            movement.y = 1;
        }
        else if (movement.y < -minFingerDisplacement)
        {
            movement.y = -1;
        }
        else
        {
            movement.y = 0;
        }

        //Debug.Log(movement);

        returnMove = movement;
    }
    #endregion
}
public class touchLocation
{
    public int touchId;
    public Vector2 startPosition;
    public float startTime;
    public touchLocation(int newTouchId, Vector2 newStartPosition)
    {
        touchId = newTouchId;
        startPosition = newStartPosition;
        startTime = Time.time;
    }
}

