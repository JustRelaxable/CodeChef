using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<MovementCard> movementCards;
    public GameObject Chef;
    public Text commandText;
    private void Awake()
    {
        movementCards = new List<MovementCard>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        Debug.Log(Chef.transform.parent.TransformVector(Chef.transform.right));
        if (Input.GetKeyDown(KeyCode.C))
        {
            GoForward();
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            Turn("LEFT");
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            Turn("RIGHT");
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            Test();
        }
    }

    private void UpdateCommandTextBox()
    {
        string s = "";
        foreach (var item in movementCards)
        {
            s += item.CardName + "\n";
        }
        commandText.text = s;
    }

    public void AddCard(string cardName)
    {
        movementCards.Add(new MovementCard(cardName));
        UpdateCommandTextBox();
    }

    public void RemoveCard(string cardName)
    {
        movementCards.Remove(movementCards.Find(x => x.CardName == cardName));
        UpdateCommandTextBox();
    }

    public void StartSeen()
    {
        try
        {
            bool isLoopEnabled = false;
            bool isTurnEnabled = false;
            int loopCount = -1;
            for (int i = 0; i < movementCards.Count; i++)
            {
                switch (movementCards[i].CardName)
                {
                    case "WALK":
                        if (isLoopEnabled)
                        {
                            StartCoroutine(GoForwardLoop(loopCount));
                        }
                        else
                        {
                            GoForward();
                        }

                        isLoopEnabled = false;
                        break;
                    case "LOOP":
                        isLoopEnabled = true;
                        break;
                    case "TURN":
                        isTurnEnabled = true;
                        break;
                    case "RIGHT":
                    case "LEFT":
                        if (isTurnEnabled)
                        {
                            Turn(movementCards[i].CardName);
                        }
                        else
                        {
                            throw new System.Exception("There must be TURN command before RIGHT or LEFT argument.");
                        }
                        break;

                    case "SIX":
                        if (isLoopEnabled)
                        {
                            loopCount = 6;
                        }
                        else
                        {
                            throw new System.Exception("There must be LOOP command before any numbers!");
                        }
                        break;
                    case "FIVE":
                        if (isLoopEnabled)
                        {
                            loopCount = 5;
                        }
                        else
                        {
                            throw new System.Exception("There must be LOOP command before any numbers!");
                        }
                        break;
                    case "FOUR":
                        if (isLoopEnabled)
                        {
                            loopCount = 4;
                        }
                        else
                        {
                            throw new System.Exception("There must be LOOP command before any numbers!");
                        }
                        break;
                    case "THREE":
                        if (isLoopEnabled)
                        {
                            loopCount = 3;
                        }
                        else
                        {
                            throw new System.Exception("There must be LOOP command before any numbers!");
                        }
                        break;
                    case "TWO":
                        if (isLoopEnabled)
                        {
                            loopCount = 2;
                        }
                        else
                        {
                            throw new System.Exception("There must be LOOP command before any numbers!");
                        }
                        break;
                    case "ONE":
                        if (isLoopEnabled)
                        {
                            loopCount = 1;
                        }
                        else
                        {
                            throw new System.Exception("There must be LOOP command before any numbers!");
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    public void GoForward()
    {
        var factor = Chef.transform.InverseTransformVector(Chef.transform.parent.right);
        factor = new Vector3(factor.x, factor.y, -factor.z);

        var startingPos = Chef.transform.localPosition;
        var finalPos = Chef.transform.localPosition -= factor * 0.66f;
        StartCoroutine(SmoothLerp(1f,startingPos,finalPos));
    }

    public IEnumerator GoForwardLoop(int loopTime)
    {
        for (int i = 0; i < loopTime; i++)
        {
            var factor = Chef.transform.InverseTransformVector(Chef.transform.parent.right);
            factor = new Vector3(factor.x, factor.y, -factor.z);

            var startingPos = Chef.transform.localPosition;
            var finalPos = Chef.transform.localPosition -= factor * 0.66f;
            yield return SmoothLerp(1f, startingPos, finalPos);
        }
    }

    public void Test()
    {
        StartCoroutine(GoForwardLoop(4));
    }

    public void Turn(string argument)
    {
        switch (argument)
        {
            case "RIGHT":
                Chef.transform.rotation *= Quaternion.Euler(0, 90, 0);
                break;
            case "LEFT":
                Chef.transform.rotation *= Quaternion.Euler(0, -90, 0);
                break;
        }
    }

    private IEnumerator SmoothLerp(float time,Vector3 startingPos,Vector3 finalPos)
    {
        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            Chef.transform.localPosition = Vector3.Lerp(startingPos, finalPos, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
