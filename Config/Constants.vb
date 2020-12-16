Namespace Global.JDS.Sapphire.Config
  Public Module Constants
    ' What logging level do we want to set (messages lower than this will not be parsed) 
    Friend Const LogLevel As LogLevel = LogLevel.Trace 

    ' Set version data
    Private Enum ver
      Major = 0
      Minor = 0
      Build = 1
      RevisionType = -3
      Revision = 2
    End Enum

    ' Constants used throughout the plugin (and profile)
    Friend Const SapphireName As String = "Sapphire"
    Friend Const SapphireInfo As String = "a Voice Attack Plugin for use with the 'Sapphire' Elite Dangerous Voice Attack Profile"
    Friend ReadOnly  SapphireVersion = New Config.Version(ver.Major, ver.Minor, ver.Build, ver.RevisionType, ver.Revision).ToString
    Friend Const SapphireGuid As String = "{48DD2AC0-7FAE-460E-9EDD-53BCE07EF742}"

    ' Set Logging Prefix
    Public Const LogPrefix As String = "[Sapphire Plugin]"

  End Module
  
  Friend Enum LogLevel
    Trace = 0	
    Debug = 1	
    Information = 2	
    Warning = 3	
    [Error] = 4	
    Critical = 5	
    None = 6	
  End Enum
  
End Namespace