using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Events", menuName = "ScriptableObject/Events")]
public class EventsScriptableObject : ScriptableObject
{
    public List<EventContainer> events;
}
