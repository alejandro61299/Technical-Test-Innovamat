using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyEvents
{
    public class EventManager : MonoBehaviour
    {
        static private EventManager current;
        static public EventManager instance
        {
            get
            {
                if (current == null)
                {
                    current = FindObjectOfType<EventManager>();
                }
                return current;
            }
        }

        private Dictionary<MyEventType, Action<EventInfo>> eventListeners;

        public void StartListening(MyEventType eventType, Action<EventInfo> listener)
        {
            if (eventListeners == null)
            {
                eventListeners = new Dictionary<MyEventType, Action<EventInfo>>();
            }

            if (!eventListeners.ContainsKey(eventType))
            {
                eventListeners.Add(eventType, listener);
            }
            else
            {
                eventListeners[eventType] += listener;
            }

        }

        public void StopListening(MyEventType eventType, Action<EventInfo> listener)
        {
            if (eventListeners.ContainsKey(eventType))
            {
                eventListeners[eventType] -= listener;

                if (eventListeners[eventType] == null)
                {
                    eventListeners.Remove(eventType);
                }
            }
        }

        public void TriggerEvent(MyEventType eventType, EventInfo info )
        {
            if (eventListeners == null || !eventListeners.ContainsKey(eventType))
            {
                return;
            }

            eventListeners[eventType]?.Invoke(info);

        }

        public void TriggerEvent(MyEventType eventType, EventInfo info, float delay)
        {
            StartCoroutine(TriggerEventDelay(eventType, info, delay));
        }

        IEnumerator TriggerEventDelay(MyEventType eventType,  EventInfo info, float delay)
        {
            yield return new WaitForSeconds(delay);
            TriggerEvent(eventType, info, delay);
        }
    }


}
