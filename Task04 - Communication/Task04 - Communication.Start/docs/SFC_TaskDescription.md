# Zadanie: Implementacja komunikacji opartej na mediatorze 

## Cel: Zmodyfikuj sposób komunikacji z modułem tak aby była oparta o madiatora wykożystaj:
- **SFC.Infrastructure.Interfaces.IEventBus**
- **SFC.Infrastructure.Interfaces.ICommandBus**
- **SFC.Infrastructure.Interfaces.IQuery**)

## Moduł powinien:
- Obsługiwać opracje command:
   - **SetNotificationEmail**
   - **SendNotification**
- Generować zdarzenie **NotificationSentEvent** po poprawnej wysyłce maila
 
## Zreaktoruj test aby wykozystywał ten sposób komunikacji.
Uproszczona implementacja mediatora jest w **SFC.Infrastructure.Bus**
  