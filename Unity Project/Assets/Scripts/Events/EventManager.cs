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

        private Dictionary<string, List<EventListener>> eventListeners;
        public delegate void EventListener(EventInfo e);

        public void RegisterListener(string eventName, EventListener listener)
        {
            if (eventListeners == null)
            {
                eventListeners = new Dictionary<string, List<EventListener>>();
            }

            if (!eventListeners.ContainsKey(eventName))
            {
                eventListeners.Add(eventName, new List<EventListener>());
            }

            eventListeners[eventName].Add(listener);
        }

        public void UnregisterListener(string eventName, EventListener listener)
        {
            if (eventListeners.ContainsKey(eventName))
            {
                eventListeners[eventName].Remove(listener);

                if (eventListeners[eventName].Count == 0)
                {
                    eventListeners.Remove(eventName);
                }
            }
        }

        public void CallEvent(string eventName, EventInfo info )
        {
            if (eventListeners == null || !eventListeners.ContainsKey(eventName))
            {
                return;
            }

            foreach(EventListener eventListener in  eventListeners[eventName])
            {
                eventListener(info);
            }

        }

        public void CallEvent(string eventName, EventInfo info, float delay)
        {
            StartCoroutine(CallEventDelay(eventName, info, delay));
        }

        IEnumerator CallEventDelay(string eventName,  EventInfo info, float delay)
        {
            yield return new WaitForSeconds(delay);
            CallEvent(eventName, info, delay);
        }
    }


}
