using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TrackableList : MonoBehaviour
{

    public ImageTarget walk;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StateManager sm = TrackerManager.Instance.GetStateManager();
        IEnumerable<TrackableBehaviour> activeTrackables = sm.GetActiveTrackableBehaviours();

        //Debug.Log("Şuan aktif kartlar: ");
        foreach (TrackableBehaviour tb in activeTrackables)
        {
           //Debug.Log("Kart: " + tb.TrackableName);

        }
    }
}
