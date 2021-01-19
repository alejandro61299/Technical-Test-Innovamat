using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyEvents
{

    public enum MyEventType
    {
        // States ----------------------
        // Question Screen
        StateQuestionScreenEnter,
        StateQuestionScreenExit,
        QuestionShowTimeEnd,

        // Answers Screen
        StateAnswersScreenEnter,
        StateAnswersScreenExit,

        // Animations ------------------
        AnimQuestionPanelExitEnd,

        AnimAnswersPanelEnterEnd,
        AnimAnswersPanelExitEnd,

        UpdateFailuresNumber,
        UpdateSuccesNumber,

        // Game -----------------------
        RoundDataGenerated,
        StartRound,
        EndRound

       
    }


    public abstract class EventInfo
    {
        public string description;
    }

    public class RoundStartEventInfo : EventInfo
    {
        public int correctButtonId;
    }

    public class RoundEmdEventInfo : EventInfo
    {
        public bool playerWin = false;
    }

    public class AnimationEventInfo : EventInfo
    {
        public AnimationClip clip;
        public GameObject gameObject;
    }

}


