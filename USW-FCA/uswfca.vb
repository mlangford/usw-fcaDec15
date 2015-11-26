Public Class uswfca
    Inherits ESRI.ArcGIS.Desktop.AddIns.Button

    'Create object to store analysis parameters
    Public configObj As New configParams

    Protected Overrides Sub OnClick()

        'Display Input Form 1, passing through configObj
        Dim p_s1frmNetworkLayers As New s1_frmNetworkLayers(configObj)
        p_s1frmNetworkLayers.Show()

    End Sub

End Class
