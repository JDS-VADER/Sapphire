Imports JDS.VAProxyWrapper

Namespace Global.JDS.Sapphire.Core.EventHandlers
  Public Class VoiceAttack
    ' All event handler links and event handling functionalities reside in this file.
    Private ReadOnly Property VAProxy As VAProxy
    
    Public Sub New(proxy As VAProxy)
      _VAProxy = proxy
    End Sub

    ' Adds event handlers to the plugin  
    Friend Sub Add()
      ' Add the handlers for the VoiceAttack ProfileChanging/ProfileChanged events
      AddHandler VAProxy.Events.ProfileChanging, AddressOf onProfileChanging
      AddHandler VAProxy.Events.ProfileChanged, AddressOf onProfileChanged

      ' Add the handlers for the VoiceAttack CommandExecuting/CommandExecuted events
      AddHandler VAProxy.Events.CommandExecuting, AddressOf onCommandExecuting
      AddHandler VAProxy.Events.CommandExecuted, AddressOf onCommandExecuted

      ' Add the variable change events
      AddHandler VAProxy.Events.BooleanChanged, AddressOf onBooleanChanged
      AddHandler VAProxy.Events.DateChanged, AddressOf onDateChanged
      AddHandler VAProxy.Events.DecimalChanged, AddressOf onDecimalChanged
      AddHandler VAProxy.Events.IntegerChanged, AddressOf onIntegerChanged
      AddHandler VAProxy.Events.TextChanged, AddressOf onTextChanged
    End Sub

   ' Removes event handlers from the plugin  
    Friend Sub Remove()
      ' Remove the handlers for the VoiceAttack ProfileChanging/ProfileChanged events
      RemoveHandler VAProxy.Events.ProfileChanging, AddressOf onProfileChanging
      RemoveHandler VAProxy.Events.ProfileChanged, AddressOf onProfileChanged

      ' Remove the handlers for the VoiceAttack CommandExecuting/CommandExecuted events
      RemoveHandler VAProxy.Events.CommandExecuting, AddressOf onCommandExecuting
      RemoveHandler VAProxy.Events.CommandExecuted, AddressOf onCommandExecuted

      ' Remove the variable change events
      RemoveHandler VAProxy.Events.BooleanChanged, AddressOf onBooleanChanged
      RemoveHandler VAProxy.Events.DateChanged, AddressOf onDateChanged
      RemoveHandler VAProxy.Events.DecimalChanged, AddressOf onDecimalChanged
      RemoveHandler VAProxy.Events.IntegerChanged, AddressOf onIntegerChanged
      RemoveHandler VAProxy.Events.TextChanged, AddressOf onTextChanged
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
      ' Parse through the boolean variable name to determine what to do!

      ' Required trace logging
      VAProxy.Log.Trace($"{left(name, len(name) -1)} was changed from {bFrom} to {bTo}")
    End Sub

    ' Called when a tracked date value has changed
    Friend Sub onDateChanged(Name As String, dateFrom As DateTime?, dateTo As DateTime?, InternalID As Guid?)
      ' Parse through the Date variable name to determine what to do!

      ' Required trace logging
      VAProxy.Log.Trace($"{left(name, len(name) -1)} was changed from {dateFrom} to {dateTo}")
    End Sub
      
    ' Called when a tracked decimal value has changed
    Friend Sub onDecimalChanged(Name As String, decFrom As Decimal?, decTo As Decimal?, InternalID As Guid?)
      ' Parse through the Decimal variable name to determine what to do!

      ' Required trace logging
      VAProxy.Log.Trace($"{left(name, len(name) -1)} was changed from {decFrom} to {decTo}")
    End Sub

    ' Called when a tracked integer value has changed
    Friend Sub onIntegerChanged(Name As String, iFrom As Integer?, iTo As Integer?, InternalID As Guid?)
      ' Parse through the integer variable name to determine what to do!

      ' Required trace logging
      VAProxy.Log.Trace($"{left(name, len(name) -1)} was changed from {iFrom} to {iTo}")
    End Sub

    ' Called when a tracked string value has changed
    Friend Sub onTextChanged(Name As String, sFrom As String, sTo As String, InternalID As Guid?)
      ' Parse through the text variable name to determine what to do!

      ' Required trace logging
      VAProxy.Log.Trace($"{left(name, len(name) -1)} was changed from {sFrom} to {sTo}")
    End Sub    

  End Class
End Namespace
