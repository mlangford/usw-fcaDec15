Imports ESRI.ArcGIS.Geodatabase
Imports ESRI.ArcGIS.NetworkAnalyst

Module fcaNAutils

#Region "get data element from data network"

    Public Function fcaNAgetdataelement(ByVal pNWDataset As INetworkDataset) As IDENetworkDataset

        Dim dsComponent As IDatasetComponent = pNWDataset     'QI from NW Dataset to -> DatasetComponent
        Return dsComponent.DataElement                                         'get Data Element and return

    End Function

#End Region

#Region "Create Closest Facility NASolver"

    Public Function fcaNAcreateClosestsolver(ByVal pNWdataset As INetworkDataset) As INAContext

        Dim naSolver As INASolver = Nothing
        Dim deNDS As IDENetworkDataset = Nothing
        Dim contextEdit As INAContextEdit = Nothing

        naSolver = New NAClosestFacilitySolver
        deNDS = fcaNAgetdataelement(pNWdataset)  'get data element
        contextEdit = naSolver.CreateContext(deNDS, naSolver.Name)
        contextEdit.Bind(pNWdataset, New GPMessages)

        Return contextEdit

    End Function

#End Region

#Region "Set Closest Facility solver"

    Public Sub fcaNAsetClosestsolver1(ByRef m_NAContext As INAContext, ByRef cfObj As configParams)

        Dim naSolver As INASolver = Nothing
        Dim cfSolver As INAClosestFacilitySolver = Nothing
        Dim gpMessagesCF As ESRI.ArcGIS.Geodatabase.IGPMessages = New ESRI.ArcGIS.Geodatabase.GPMessages

        'closest facility specific settings:
        naSolver = m_NAContext.Solver
        cfSolver = naSolver
        cfSolver.DefaultCutoff = Nothing
        cfSolver.DefaultTargetFacilityCount = 1
        cfSolver.OutputLines = esriNAOutputLineType.esriNAOutputLineTrueShapeWithMeasure
        cfSolver.TravelDirection = esriNATravelDirection.esriNATravelDirectionToFacility

        'set the network impedance attribute
        Dim naSolverSettings As INASolverSettings2 = naSolver
        naSolverSettings.ImpedanceAttributeName = cfObj.NWimpedanceCar

        'set/remove OneWay Restrictions
        Dim restrictions As ESRI.ArcGIS.esriSystem.IStringArray = naSolverSettings.RestrictionAttributeNames
        restrictions.RemoveAll()
        restrictions.Add("oneway")
        naSolverSettings.RestrictionAttributeNames = restrictions

        'set/remove UTurns
        naSolverSettings.RestrictUTurns = esriNetworkForwardStarBacktrack.esriNFSBNoBacktrack
        naSolverSettings.IgnoreInvalidLocations = True

        'set/remove Hierarchy
        ' naSolverSettings.UseHierarchy = chkUseHierarchy.Checked
        'If naSolverSettings.UseHierarchy Then
        '    naSolverSettings.HierarchyAttributeName = "hierarchy"
        'End If

        'update context after setting options
        naSolver.UpdateContext(m_NAContext, fcaNAgetdataelement(m_NAContext.NetworkDataset), gpMessagesCF)

    End Sub

#End Region

#Region "Create OD Matrix NASolver"

    Public Function fcaNAcreateODsolver(ByVal pNWDataset As INetworkDataset) As INAContext

        Dim naSolver As INASolver = Nothing
        Dim deNDS As IDENetworkDataset = Nothing
        Dim contextEdit As INAContextEdit = Nothing

        naSolver = New NAODCostMatrixSolver
        deNDS = fcaNAgetdataelement(pNWDataset) 'get data element
        contextEdit = naSolver.CreateContext(deNDS, naSolver.Name)

        'Dim gpMessages3 As ESRI.ArcGIS.Geodatabase.IGPMessages = New ESRI.ArcGIS.Geodatabase.GPMessages
        'contextEdit.Bind(pNWDataset, gpMessages3)
        contextEdit.Bind(pNWDataset, New GPMessages)

        Return contextEdit

    End Function

#End Region

#Region "Set OD Matrix solver"

    Public Sub fcaNAsetODsolver1(ByRef m_NAContext As INAContext, ByVal cfObj As configParams)

        Dim naSolver As INASolver = Nothing
        Dim odSolver As INAODCostMatrixSolver = Nothing
        Dim gpMessagesOD As ESRI.ArcGIS.Geodatabase.IGPMessages = New ESRI.ArcGIS.Geodatabase.GPMessages

        'OD matrix specific settings:
        naSolver = m_NAContext.Solver
        odSolver = naSolver
        odSolver.DefaultTargetDestinationCount = Nothing      'no limit to #destinations inside FCA threshold distance
        odSolver.OutputLines = esriNAOutputLineType.esriNAOutputLineStraight    'show solutions as straight lines
        odSolver.DefaultCutoff = cfObj.NWdefCutOffCar

        'generic solver settings:

        'impedance attribute
        Dim naSolverSettings As INASolverSettings = naSolver
        naSolverSettings.ImpedanceAttributeName = cfObj.NWimpedanceCar

        'set/remove OneWay Restriction
        Dim restrictions As ESRI.ArcGIS.esriSystem.IStringArray = naSolverSettings.RestrictionAttributeNames
        restrictions.RemoveAll()
        restrictions.Add("oneway")
        naSolverSettings.RestrictionAttributeNames = restrictions

        'set/remove UTurns
        naSolverSettings.RestrictUTurns = esriNetworkForwardStarBacktrack.esriNFSBNoBacktrack
        naSolverSettings.IgnoreInvalidLocations = True

        'set/remove Hierarchy
        naSolverSettings.UseHierarchy = False
        If naSolverSettings.UseHierarchy Then
            naSolverSettings.HierarchyAttributeName = "hierarchy"
            ' naSolverSettings.HierarchyLevelCount = 3                     'depricated
            'naSolverSettings.MaxValueForHierarchy(1) = 1               'depricated
            'naSolverSettings.NumTransitionToHierarchy(1) = 9        'depricated
            'naSolverSettings.MaxValueForHierarchy(2) = 2              'depricated
            'naSolverSettings.NumTransitionToHierarchy(2) = 9       'depricated
        End If

        'update context after setting options
        naSolver.UpdateContext(m_NAContext, fcaNAgetdataelement(m_NAContext.NetworkDataset), gpMessagesOD)

    End Sub

#End Region

End Module

