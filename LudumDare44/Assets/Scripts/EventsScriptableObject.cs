using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Events", menuName = "ScriptableObject/EventsContainer")]
public class EventsScriptableObject : ScriptableObject
{
    public List<EventScriptableObject> events;
}

[CreateAssetMenu(fileName = "Event", menuName = "ScriptableObject/Event")]
public class EventScriptableObject : ScriptableObject
{
    public EventContainer ev;
}
