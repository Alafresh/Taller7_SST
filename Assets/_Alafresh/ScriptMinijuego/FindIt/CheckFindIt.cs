using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CheckFindIt : MiniGamesManager
{
    [SerializeField] private GameObject[] cards;

    [SerializeField] private int objectsStateOne;
    [SerializeField] private int objectsStateTwo;
    [SerializeField] private int objectsStateThree;

    [SerializeField] private UnityEvent OnCorrect;
    [SerializeField] private UnityEvent OnIncorrect;

    enum State
    {
        One, Two, Three
    }

    private State _state = State.One;
    private int _count = 0;

    public void Check()
    {
        SumContadorCheck();
        switch (_state)
        {
            case State.One:
                NextCard(objectsStateOne);
                break;
            case State.Two:
                NextCard(objectsStateTwo);
                break;
            case State.Three:
                NextCard(objectsStateThree);
                break;
        }
    }

    private void NextCard(int objectsState)
    {
        if (!(_count == objectsState))
        {
            OnIncorrect.Invoke();
            return;
        }

        if (_state == State.One)
        {
            timer.StopTimer();
            OnCorrect.Invoke();
            return;
        }
        cards[(int)_state].SetActive(false);
        _state++;
        cards[(int)_state].SetActive(true);
        _count = 0;
    }
    public void SumCount(Button button)
    {
        button.interactable = false;
        _count++;
    }
}
