' This plugin requires EDDI installed and running as a Voice Attack plugin
' to be most effective.  The Plugin will not load if it does not detect
' EDDI installed as a Voice Attack plugin

Imports JDS.VAProxyWrapper ' VAProxy object wrapper 
Imports JDS.Sapphire.Core ' Core Plugin functionality

Namespace Global.JDS.Sapphire
  Public Class Sapphire

    ' For logging purposes
    Private Shared _methodName As String

    'Private Shared ReadOnly Property Constants As Constants
    ' Voice Attack proxy object
    Private Shared ReadOnly Property VAProxy As VAProxy
  
  ' Sapphire objects
    Private Shared ReadOnly Property EventManager As EventManager ' For capturing events raised by Voice Attack

    ' Required Voice Attack function VA_Id() - Provides VA with our self-generated GUID
    Public Shared Function VA_Id() As Guid
      Return New Guid(Config.Constants.SapphireGuid)
    End Function

    ' Required Voice Attack function VA_DisplayName() - Gives VA our Plugin Display Name
    Public Shared Function VA_DisplayName() As String
      Return $"{Config.Constants.SapphireName} v{Config.Constants.SapphireVersion}" 
    End Function

    ' Required Voice Attack function VA_DisplayInfo() - Gives VA our Plugin Display Info
    Public Shared Function VA_DisplayInfo() As String
      Return $"{Config.Constants.SapphireName} ({Config.Constants.SapphireVersion})\r\n{Config.Constants.SapphireInfo}"
    End Function

    ' VA_Init1 - Called by Voice Attack when initially loading the plugin (async)
    ' Note that we have to use "As Object" for the proxy in the declaration, because using
    ' "As VoiceAttackInitProxyObject" causes Voice Attack to stop seeing the plugin as valid
    Public Shared Sub VA_Init1(proxy As Object)
      _methodName =  "[VA_Init1]:"

      ' Create Proxy Wrapper 
      _VAProxy = New VAProxy(proxy, Config.Constants.LogLevel, Config.Constants.LogPrefix)
    
      ' Start logging
      VAProxy.Log.Trace($"{_methodName} Plugin initializing....")

      ' Create Sapphire plugin event Manager. Add Voice Attack proxy event handlers
      _EventManager = New EventManager(VAProxy)
      EventManager.Handlers.Add()

      ' Load configuration with default settings
'      LoadConfig(defaults)

      ' Initialization complete 
      VAProxy.Log.Trace($"{_methodName} - Initialization completed.")

    End Sub

    ' VA_Invoke1 - Called by Voice Attack when the command action "Execute an External Plugin Function" fires
    Public Shared Sub VA_Invoke1(proxy As Object)
      _methodName =  "[VA_Invoke1]:"
      Dim oldProxyType As String = VAProxy.ProxyType
    
      ' Update our proxy object... (it is still VoiceAttackInitProxyClass at this point)
      VAProxy.Invoke(proxy)
      If (oldProxyType <> VAProxy.ProxyType) Then
        VAProxy.Log.Trace($"{_methodName} Updated VAProxy object from {oldProxyType} to {VAProxy.ProxyType}")
      End If

      ' Log invocation (with passed proxy context)
      VAProxy.Log.Trace($"{_methodName} Began invocation with context ""{proxy.Context}""")
    

      
      ' Perform plugin stuff here...
      If VAProxy.Commands.Exists("JDS.EDDI.Talk") Then
        VAProxy.Commands.Execute("JDS.EDDI.Talk", PassedText := """This is a test""")
      End If

      ' Invocation complete
      VAProxy.Log.Trace($"{_methodName} invocation completed.")

    End Sub

    ' VA_StopCommand - Called by Voice Attack when the "stop all commands" button or call has been fired
    Public Shared Sub VA_StopCommand()
      _methodName = "[VA_StopCommand]:"

      ' Log command event
      VAProxy.Log.Trace($"Event received: {_methodName}...")
    
    End Sub

    ' VA_Exit1 - Called by Voice Attack when Voice Attack closes. Cleanup code here...
    Public Shared Sub VA_Exit1(proxy As Object)
      _methodName = "[VA_Exit1]:"

      ' Log command event
      VAProxy.Log.Trace($"{_methodName}...")

      ' Prepare the proxy object to unload
      VAProxy.Exit(proxy)

      ' Perform exit routines
    
      ' Remove the event handlers for the Sapphire plugin
      EventManager.Handlers.Remove()
    
      ' Save the current config
      

    End Sub
  End Class
End Namespace