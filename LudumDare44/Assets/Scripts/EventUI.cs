﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EventUI : Singleton<EventUI>
{
    public GameObject Container;
    public Text MainText;
    public Button ProposalOneButton;
    public Text ProposalOneText;
    public Button ProposalTwoButton;
    public Text ProposalTwoText;
    public Button ProposalSpecialButton;
    public Text ProposalSpecialText;
    public Button OkButton;
    public EventContainer EventContainer { get; set; }

    public void CreateView(EventContainer eventContainer){
        //ouvre l'event
        if(eventContainer.CustomSongId.HasValue){
            SoundManager.instance.PlayEventSound(eventContainer.CustomSongId.Value,true);
        }   else
        {
            SoundManager.instance.PlayEventSound(0,true);
        }
        this.Container.SetActive(true);
        this.OkButton.gameObject.SetActive(false);
        this.EventContainer = eventContainer;
        this.MainText.text = this.EventContainer.GetMessage();
        this.ProposalOneButton.gameObject.SetActive(true);
        this.ProposalOneText.text = this.EventContainer.FormatText(this.EventContainer.ProposalOne.Choice);
        if(string.IsNullOrEmpty(this.EventContainer.ProposalTwo.Choice)){
            this.ProposalTwoButton.gameObject.SetActive(false);
        }   else
        {
            this.ProposalTwoButton.gameObject.SetActive(true);
            this.ProposalTwoText.text = this.EventContainer.FormatText(this.EventContainer.ProposalTwo.Choice);
        }
        if(string.IsNullOrEmpty(this.EventContainer.ProposalSpecial.Choice)){
            this.ProposalSpecialButton.gameObject.SetActive(false);
        }   else
        {
            this.ProposalSpecialButton.gameObject.SetActive(true);
            this.ProposalSpecialText.text = this.EventContainer.FormatText(this.EventContainer.ProposalSpecial.Choice);
        }
    }

    private void proposalSelected(){
        //selectionne une proposition
        this.ProposalOneButton.gameObject.SetActive(false);
        this.ProposalTwoButton.gameObject.SetActive(false);
        this.ProposalSpecialButton.gameObject.SetActive(false);
        this.OkButton.gameObject.SetActive(true);
    }

    public void ClickOnProposalOne(){   
        this.proposalSelected();
        if(this.EventContainer.ProposalOne.CustomSongId.HasValue){
            SoundManager.instance.PlayEventSound(this.EventContainer.ProposalOne.CustomSongId.Value,false);
        }   else
        {
            SoundManager.instance.PlayEventSound(0,false);
        }
        this.MainText.text = this.EventContainer.FormatText(this.EventContainer.ProposalOne.Response);
        this.EventContainer.ProposalOne.DoEffects(this.EventContainer.GetEffectParams());
    }

    public void ClickOnProposalTwo(){
        this.proposalSelected();
        if(this.EventContainer.ProposalTwo.CustomSongId.HasValue){
            SoundManager.instance.PlayEventSound(this.EventContainer.ProposalTwo.CustomSongId.Value,false);
        }   else
        {
            SoundManager.instance.PlayEventSound(0,false);
        }
        this.MainText.text = this.EventContainer.FormatText(this.EventContainer.ProposalTwo.Response);
        this.EventContainer.ProposalTwo.DoEffects(this.EventContainer.GetEffectParams());
    }

    public void ClickOnProposalSpecial(){
        this.proposalSelected();
        if(this.EventContainer.ProposalSpecial.CustomSongId.HasValue){
            SoundManager.instance.PlayEventSound(this.EventContainer.ProposalSpecial.CustomSongId.Value,false);
        }   else
        {
            SoundManager.instance.PlayEventSound(0,false);
        }
        this.MainText.text = this.EventContainer.FormatText(this.EventContainer.ProposalSpecial.Response);
        this.EventContainer.ProposalSpecial.DoEffects(this.EventContainer.GetEffectParams());
    }

    public void Close(){
        this.Container.SetActive(false);
        GameManager.Instance.NextTurn();
    }
}
