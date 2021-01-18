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

        private Dictionary<MyEventType, List<EventListener>> eventListeners;
        public delegate void EventListener(EventInfo e);

        public void RegisterListener(MyEventType eventType, EventListener listener)
        {
            if (eventListeners == null)
            {
                eventListeners = new Dictionary<MyEventType, List<EventListener>>();
            }

            if (!eventListeners.ContainsKey(eventType))
            {
                eventListeners.Add(eventType, new List<EventListener>());
            }

            eventListeners[eventType].Add(listener);
        }

        public void UnregisterListener(MyEventType eventType, EventListener listener)
        {
            if (eventListeners.ContainsKey(eventType))
            {
                eventListeners[eventType].Remove(listener);

                if (eventListeners[eventType].Count == 0)
                {
                    eventListeners.Remove(eventType);
                }
            }
        }

        public void CallEvent(MyEventType eventType, EventInfo info )
        {
            if (eventListeners == null || !eventListeners.ContainsKey(eventType))
            {
                return;
            }

            foreach(EventListener eventListener in  eventListeners[eventType])
            {
                eventListener(info);
            }
        }

        public void CallEvent(MyEventType eventType, EventInfo info, float delay)
        {
            StartCoroutine(CallEventDelay(eventType, info, delay));
        }

        IEnumerator CallEventDelay(MyEventType eventType,  EventInfo info, float delay)
        {
            yield return new WaitForSeconds(delay);
            CallEvent(eventType, info, delay);
        }
    }


}
