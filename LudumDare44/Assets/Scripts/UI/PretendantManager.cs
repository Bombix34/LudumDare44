using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PretendantManager : MonoBehaviour
{
    public List<WeddingPretendantUI> pretendantsUI;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void LaunchPretendantUI(List<Inheritor> pretendants,int inheritorAttirance)
    {
        for(int i = 0; i < pretendants.Count;i++)
        {
            pretendantsUI[i].CreateView(pretendants[i],inheritorAttirance);
        }
    }
}
