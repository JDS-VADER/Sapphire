Imports JDS.VAProxyWrapper
Imports JDS.Sapphire.Core.Event

Namespace Global.JDS.Sapphire.Core
  Friend Class EventManager
    Private ReadOnly Property VAProxy As VAProxy
    Friend ReadOnly Property Handlers As Handlers

    Friend Sub New(proxy As VAProxy)
      _VAProxy = proxy
      _Handlers = New Handlers(VAProxy, Me)
    End Sub

    '*********************
    ' Profile changes

    ' Called when Voice Attack sends a ProfileChanging event through the proxy
    Friend Sub onProfileChanging(FromInternalID As Guid?, ToInternalID As Guid?, FromName As String, ToName As String)
    
      ' Required trace logging
      VAProxy.Log.Trace($"Profile ""{FromName}"" ({FromInternalID}) unloading...")
      VAProxy.Log.Trace($"Initializing profile ""{ToName}"" ({ToInternalID})")
    End Sub

    ' Called when Voice Attack sends a ProfileChanged event through the proxy
    Friend Sub onProfileChanged(FromInternalID As Guid?, ToInternalID As Guid?, FromName As String, ToName As String)

      ' Required trace logging
      VAProxy.Log.Trace($"Profile ""{FromName}"" ({FromInternalID}) unloaded.")
      VAProxy.Log.Trace($"The ""{ToName}"" ({ToInternalID}) profile is now loaded and active.")
    End Sub

    '*********************
    ' Command execution (MUST have the Command Advanced Option "Enable Proxy Command Events" enabled for the event to fire)

    ' Called when Voice Attack sends a CommandExecuting event through the proxy (about to execute)
    Friend Sub onCommandExecuting(InternalID As Guid?)

      ' Required trace logging
      VAProxy.Log.Trace($"Command with internal identifier: {{{InternalID}}} began execution")
    End Sub

    ' Called when Voice Attack sends a CommandExecuted event through the proxy (about to execute)
    Friend Sub onCommandExecuted(InternalID As Guid?)


      ' Required trace logging
      VAProxy.Log.Trace($"Command with internal identifier: {{{InternalID}}} was executed")
    End Sub

    '*********************
    ' Variable changes (a variable MUST end with '#' for an event to fire)

    ' Called when a tracked boolean value has changed
    Friend Sub onBooleanChanged(Name As String, bFrom As Boolean?, bTo As Boolean?, InternalID As Guid?)
      ' Parse through the boolean name to determine what to do!

      ' Required trace logging
      VAProxy.Log.Trace($"{left(name, len(name) -1)} was changed from {bFrom} to {bTo}")
    End Sub

    ' Called when a tracked date value has changed
    Friend Sub onDateChanged(Name As String, dateFrom As DateTime?, dateTo As DateTime?, InternalID As Guid?)
      ' Parse through the boolean name to determine what to do!

      ' Required trace logging
      VAProxy.Log.Trace($"{left(name, len(name) -1)} was changed from {dateFrom} to {dateTo}")
    End Sub
      
    ' Called when a tracked decimal value has changed
    Friend Sub onDecimalChanged(Name As String, decFrom As Decimal?, decTo As Decimal?, InternalID As Guid?)
      ' Parse through the boolean name to determine what to do!

      ' Required trace logging
      VAProxy.Log.Trace($"{left(name, len(name) -1)} was changed from {decFrom} to {decTo}")
    End Sub

    ' Called when a tracked integer value has changed
    Friend Sub onIntegerChanged(Name As String, iFrom As Integer?, iTo As Integer?, InternalID As Guid?)
      ' Parse through the boolean name to determine what to do!

      ' Required trace logging
      VAProxy.Log.Trace($"{left(name, len(name) -1)} was changed from {iFrom} to {iTo}")
    End Sub

    ' Called when a tracked string value has changed
    Friend Sub onTextChanged(Name As String, sFrom As String, sTo As String, InternalID As Guid?)
      ' Parse through the boolean name to determine what to do!

      ' Required trace logging
      VAProxy.Log.Trace($"{left(name, len(name) -1)} was changed from {sFrom} to {sTo}")
    End Sub    

  End Class
End Namespace