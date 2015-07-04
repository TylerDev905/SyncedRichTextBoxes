Public Class SyncedRichTextBoxes

    Public WithEvents Master As RichTextBox
    Public Slaves As New ArrayList
    Declare Function SendMessage Lib "user32.dll" Alias "SendMessageW" (ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As Integer, ByRef lParam As Point) As Integer

    Private Sub Master_VScroll(sender As Object, e As EventArgs) Handles Master.VScroll
        Const WM_USER As Integer = &H400
        Const EM_GETSCROLLPOS As Integer = WM_USER + 221
        Const EM_SETSCROLLPOS As Integer = WM_USER + 222
        Dim pt As Point
        SendMessage(Master.Handle, EM_GETSCROLLPOS, 0, pt)

        For Each ControlItem As RichTextBox In Slaves
            SendMessage(ControlItem.Handle, EM_SETSCROLLPOS, 0, pt)
        Next
    End Sub

End Class
