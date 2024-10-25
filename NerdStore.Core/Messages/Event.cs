using MediatR;

namespace NerdStore.Core.Messages;

// instalar pacote MediatR
public class Event : Message, INotification
{
    public DateTime Timestamp { get; private set; }
    
    protected Event()
    {
        Timestamp = DateTime.Now;
    }
}