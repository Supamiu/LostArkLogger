﻿using System;
using System.Collections.Concurrent;

namespace LostArkLogger
{
    public class Entity
    {
        public UInt64 EntityId;
        public UInt64 OwnerId;
        public String Name;
        public String ClassName = "";
        public EntityType Type = EntityType.Npc;
        public UInt32 Stagger;
        public String VisibleName { get { return Name + (String.IsNullOrEmpty(ClassName) ? "" :" (" + ClassName + ")"); } }
        public enum EntityType
        {
            Unknown,
            Player,
            Npc,
            Projectile,
            Summon,
        }
    }
    public static class EntityExtensions
    {
        public static Entity GetOrAdd(this ConcurrentDictionary<UInt64, Entity> entityList, UInt64 entityId)
        {
            return entityList.GetOrAdd(entityId, new Entity { EntityId = entityId });
        }
        public static void AddOrUpdate(this ConcurrentDictionary<UInt64, Entity> entityList, Entity entity)
        {
            entityList[entity.EntityId] = entity;
        }
    }
}
