using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<MovementCard> movementCards;
    public GameObject Chef;

    private void Awake()
    {
        movementCards = new List<MovementCard>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        string s = "";
        foreach (var item in movementCards)
        {
            s += item.CardName + " ";           
        }
        Debug.LogWarning(s);

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
    }

    public void AddCard(string cardName)
    {
        movementCards.Add(new MovementCard(cardName));
    }

    public void RemoveCard(string cardName)
    {
        movementCards.Remove(movementCards.Find(x => x.CardName == cardName));
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
                            for (int j = 0; j < loopCount; j++)
                            {
                                GoForward();
                            }
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
        Chef.transform.position -= Chef.transform.right / 1.5f;
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
}
