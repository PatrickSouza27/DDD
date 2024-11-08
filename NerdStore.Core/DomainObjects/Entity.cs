﻿using NerdStore.Core.Messages;

namespace NerdStore.Core.DomainObjects;

public abstract class Entity
{
    
    private List<Event> _notifications;
    public Guid Id { get; set; }
    public IReadOnlyCollection<Event> Notifications => _notifications.AsReadOnly();
    
    protected Entity()
    {
        Id = Guid.NewGuid();
    }
    
    public void AdicionarEvento(Event evento)
    {
        _notifications = _notifications ?? new List<Event>();
        _notifications.Add(evento);
    }
    
    public void RemoverEvento(Event evento)
    {
        _notifications?.Remove(evento);
    }
    
    public void LimparEventos()
    {
        _notifications?.Clear();
    }

    public override bool Equals(object? obj)
    {
        var compareTo = obj as Entity;
        
        if(ReferenceEquals(this, compareTo)) return true;
        return !ReferenceEquals(null, compareTo) && Id.Equals(compareTo.Id);
    }

    public static bool operator ==(Entity? a, Entity? b)
    {
        if(ReferenceEquals(a, null) && ReferenceEquals(b, null)) return true;
        if(ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;

        return a.Equals(b);
    }

    public static bool operator !=(Entity? a, Entity? b)
    {
        return !(a == b);
    }
    
    public override int GetHashCode()
    {
        return (GetType().GetHashCode() * 907) + Id.GetHashCode();
    }

    public override string ToString()
    {
        return $"{GetType().Name} [Id={Id}]";
    }
    
    public virtual bool EhValido() => true;
}