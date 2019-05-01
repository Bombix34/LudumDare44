using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LD44/Son database")]
public class SoundDatabase : ScriptableObject
{
    public List<PitchVolumeAudio> audioDatabase;
}
