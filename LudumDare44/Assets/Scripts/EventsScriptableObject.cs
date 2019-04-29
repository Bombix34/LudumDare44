using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Events", menuName = "ScriptableObject/EventsContainer")]
public class EventsScriptableObject : ScriptableObject
{
    public List<EventScriptableObject> events;
}
