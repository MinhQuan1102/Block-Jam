using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Core
{
    public static class UIExtensions
    {
        public static void AddEvent(this Component behaviour, EventTriggerType triggerType, Action<PointerEventData> call)
        {
            AddEvent(behaviour.gameObject, triggerType, call);
        }

        public static void AddEvent(this GameObject behaviour, EventTriggerType triggerType, Action<PointerEventData> call)
        {
            EventTrigger trigger = behaviour.GetComponent<EventTrigger>();
            if (trigger == null)
                trigger = behaviour.gameObject.AddComponent<EventTrigger>();

            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = triggerType;
            entry.callback.AddListener((data) => { call((PointerEventData)data); });

            trigger.triggers.Add(entry);
        }
    }
}