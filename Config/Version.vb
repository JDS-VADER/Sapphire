Namespace Global.JDS.Sapphire.Config
  Public Class Version
    Public Enum ReleaseType
      A = -3
      B = -2
      RC = -1
      Final = 0
    End Enum

    ' Version variables => 3.2.2 alpha 4 // 4.7 rc 2
    Private ReadOnly _rType As ReleaseType

    ' Version Properties
    Private ReadOnly Property Major As Integer
    Private ReadOnly Property Minor As Integer
    Private ReadOnly Property Build As Integer
    Private ReadOnly Property Revision As Integer

    Private ReadOnly Property Type As String ' alpha
      Get
        Select Case _rType
          Case -3:
            return "alpha"
          Case -2:
            return "beta"
          Case -1:
            return "release candidate"
          Case 0:
            return ""
          Case else:
            return "error: invalid release type"
        End Select
      End Get
    End Property

    ' Constructor - just saves version data to class variables
    Public Sub New(maj As Integer, min As Integer, bld As Integer, rType As ReleaseType, rev As Integer) 
      Major = maj
      Minor = min
      Build = bld
      _rType = rType
      Revision = rev
    End Sub

    ' Return the Major.Minor version short string
    Public Function ToShortString() As String
      Return String.Format($"{Major}.{Minor}.{Build}")
    End Function

    ' Override ToString() to customize the version string
    Public Overrides Function ToString() As String
      Return String.Format($"{Major}.{Minor}.{Build} ({Type.ToString()} {Revision})")
    End Function

    ' Create a hashcode to test for equality
    Public Overrides Function GetHashCode() As Integer
      Dim hashCode As Integer = 29
      hashCode = hashCode * 23 + Major
      hashCode = hashCode * 23 + Minor
      hashCode = hashCode * 23 + Build
      hashCode = hashCode * 23 + CInt(Type)
      hashCode = hashCode * 23 + Revision
      Return hashCode
    End Function

  End Class
End Namespace