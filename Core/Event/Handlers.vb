Imports JDS.VAProxyWrapper

Namespace Global.JDS.Sapphire.Core.Event
  Friend Class Handlers
    Private ReadOnly Property VAProxy As VAProxy
    Private ReadOnly Property EventManager As EventManager

    ' Constructor
    Friend Sub New(proxy As VAProxy, EventManager As EventManager)
      _VAProxy = proxy
      _EventManager = EventManager
    End Sub

    ' Adds event handlers to the plugin  
    Friend Sub Add()
      ' Add the handlers for the VoiceAttack ProfileChanging/ProfileChanged events
      AddHandler VAProxy.EventHandlers.ProfileChanging, AddressOf EventManager.onProfileChanging
      AddHandler VAProxy.EventHandlers.ProfileChanged, AddressOf EventManager.onProfileChanged

      ' Add the handlers for the VoiceAttack CommandExecuting/CommandExecuted events
      AddHandler VAProxy.EventHandlers.CommandExecuting, AddressOf EventManager.onCommandExecuting
      AddHandler VAProxy.EventHandlers.CommandExecuted, AddressOf EventManager.onCommandExecuted

      ' Add the variable change events
      AddHandler VAProxy.EventHandlers.BooleanChanged, AddressOf EventManager.onBooleanChanged
      AddHandler VAProxy.EventHandlers.DateChanged, AddressOf EventManager.onDateChanged
      AddHandler VAProxy.EventHandlers.DecimalChanged, AddressOf EventManager.onDecimalChanged
      AddHandler VAProxy.EventHandlers.IntegerChanged, AddressOf EventManager.onIntegerChanged
      AddHandler VAProxy.EventHandlers.TextChanged, AddressOf EventManager.onTextChanged
    End Sub
    
    ' Removes event handlers from the plugin  
    Friend Sub Remove()
      ' Remove the handlers for the VoiceAttack ProfileChanging/ProfileChanged events
      RemoveHandler VAProxy.EventHandlers.ProfileChanging, AddressOf EventManager.onProfileChanging
      RemoveHandler VAProxy.EventHandlers.ProfileChanged, AddressOf EventManager.onProfileChanged

      ' Remove the handlers for the VoiceAttack CommandExecuting/CommandExecuted events
      RemoveHandler VAProxy.EventHandlers.CommandExecuting, AddressOf EventManager.onCommandExecuting
      RemoveHandler VAProxy.EventHandlers.CommandExecuted, AddressOf EventManager.onCommandExecuted

      ' Remove the variable change events
      RemoveHandler VAProxy.EventHandlers.BooleanChanged, AddressOf EventManager.onBooleanChanged
      RemoveHandler VAProxy.EventHandlers.DateChanged, AddressOf EventManager.onDateChanged
      RemoveHandler VAProxy.EventHandlers.DecimalChanged, AddressOf EventManager.onDecimalChanged
      RemoveHandler VAProxy.EventHandlers.IntegerChanged, AddressOf EventManager.onIntegerChanged
      RemoveHandler VAProxy.EventHandlers.TextChanged, AddressOf EventManager.onTextChanged
    End Sub
  End Class
End Namespace