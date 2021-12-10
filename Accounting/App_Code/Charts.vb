Imports Microsoft.VisualBasic
Imports DevExpress.XtraCharts

Public Class Charts

    Public Shared Sub changeViewType(chartt As DevExpress.XtraReports.UI.XRChart, view As String)
        If view = "Pie" Then
            chartt.SeriesTemplate.ChangeView(ViewType.Pie)
        ElseIf view = "Bar" Then
            chartt.SeriesTemplate.ChangeView(ViewType.Bar)
        ElseIf view = "Line" Then
            chartt.SeriesTemplate.ChangeView(ViewType.Line)
        ElseIf view = "3D Pie" Then
            chartt.SeriesTemplate.ChangeView(ViewType.Pie3D)
        ElseIf view = "Doughnut" Then
            chartt.SeriesTemplate.ChangeView(ViewType.Doughnut)
        ElseIf view = "Bar Stacked" Then
            chartt.SeriesTemplate.ChangeView(ViewType.StackedBar)
        ElseIf view = "Bar Stacked 100%" Then
            chartt.SeriesTemplate.ChangeView(ViewType.FullStackedBar)
        ElseIf view = "Side by Side Bar Stacked" Then
            chartt.SeriesTemplate.ChangeView(ViewType.SideBySideStackedBar)
        ElseIf view = "Side by Side Bar Stacked 100%" Then
            chartt.SeriesTemplate.ChangeView(ViewType.SideBySideFullStackedBar)
        ElseIf view = "3D Bar" Then
            chartt.SeriesTemplate.ChangeView(ViewType.Bar3D)
        ElseIf view = "3D Bar Stacked" Then
            chartt.SeriesTemplate.ChangeView(ViewType.StackedBar3D)
        ElseIf view = "3D Bar Stacked 100%" Then
            chartt.SeriesTemplate.ChangeView(ViewType.FullStackedBar3D)
        ElseIf view = "Manhattan" Then
            chartt.SeriesTemplate.ChangeView(ViewType.ManhattanBar)
        ElseIf view = "Point" Then
            chartt.SeriesTemplate.ChangeView(ViewType.Point)
        ElseIf view = "Bubble" Then
            chartt.SeriesTemplate.ChangeView(ViewType.Bubble)
        ElseIf view = "Line Stacked" Then
            chartt.SeriesTemplate.ChangeView(ViewType.StackedLine)
        ElseIf view = "Line Stacked 100%" Then
            chartt.SeriesTemplate.ChangeView(ViewType.FullStackedLine)
        ElseIf view = "Step Line" Then
            chartt.SeriesTemplate.ChangeView(ViewType.StepLine)
        ElseIf view = "Spline" Then
            chartt.SeriesTemplate.ChangeView(ViewType.Spline)
        ElseIf view = "Scatter Line" Then
            chartt.SeriesTemplate.ChangeView(ViewType.ScatterLine)
        ElseIf view = "Swift Plot" Then
            chartt.SeriesTemplate.ChangeView(ViewType.SwiftPlot)
        ElseIf view = "Line 3D" Then
            chartt.SeriesTemplate.ChangeView(ViewType.Line3D)
        ElseIf view = "Line 3D Stacked" Then
            chartt.SeriesTemplate.ChangeView(ViewType.StackedLine3D)
        ElseIf view = "Line 3D Stacked 100%" Then
            chartt.SeriesTemplate.ChangeView(ViewType.FullStackedLine3D)
        ElseIf view = "Step Line 3D" Then
            chartt.SeriesTemplate.ChangeView(ViewType.StepLine3D)
        ElseIf view = "Spline 3D" Then
            chartt.SeriesTemplate.ChangeView(ViewType.Spline3D)
        ElseIf view = "Doughnut 3D" Then
            chartt.SeriesTemplate.ChangeView(ViewType.Doughnut3D)
        ElseIf view = "Funnel" Then
            chartt.SeriesTemplate.ChangeView(ViewType.Funnel)
        ElseIf view = "Funnel 3D" Then
            chartt.SeriesTemplate.ChangeView(ViewType.Funnel3D)
        ElseIf view = "Area" Then
            chartt.SeriesTemplate.ChangeView(ViewType.Area)
        ElseIf view = "Area Stacked" Then
            chartt.SeriesTemplate.ChangeView(ViewType.StackedArea)
        ElseIf view = "Area Stacked 100%" Then
            chartt.SeriesTemplate.ChangeView(ViewType.FullStackedArea)
        ElseIf view = "Step Area 3D" Then
            chartt.SeriesTemplate.ChangeView(ViewType.StepArea3D)
        ElseIf view = "Spline Area 3D" Then
            chartt.SeriesTemplate.ChangeView(ViewType.SplineArea3D)
        ElseIf view = "Spline Area 3D Stacked" Then
            chartt.SeriesTemplate.ChangeView(ViewType.StackedSplineArea3D)
        ElseIf view = "Spline Area 3D Stacked 100%" Then
            chartt.SeriesTemplate.ChangeView(ViewType.FullStackedSplineArea3D)
        ElseIf view = "Range Bar" Then
            chartt.SeriesTemplate.ChangeView(ViewType.RangeBar)
        ElseIf view = "Side by Side Range Bar" Then
            chartt.SeriesTemplate.ChangeView(ViewType.SideBySideRangeBar)
        ElseIf view = "Range Area" Then
            chartt.SeriesTemplate.ChangeView(ViewType.RangeArea)
        ElseIf view = "Range Area 3D" Then
            chartt.SeriesTemplate.ChangeView(ViewType.RangeArea3D)
        ElseIf view = "Radar Point" Then
            chartt.SeriesTemplate.ChangeView(ViewType.RadarPoint)
        ElseIf view = "Radar Line" Then
            chartt.SeriesTemplate.ChangeView(ViewType.RadarLine)
        ElseIf view = "Radar Area" Then
            chartt.SeriesTemplate.ChangeView(ViewType.RadarArea)
        ElseIf view = "Polar Point" Then
            chartt.SeriesTemplate.ChangeView(ViewType.PolarPoint)
        ElseIf view = "Polar Line" Then
            chartt.SeriesTemplate.ChangeView(ViewType.PolarLine)
        ElseIf view = "Polar Area" Then
            chartt.SeriesTemplate.ChangeView(ViewType.PolarArea)
        ElseIf view = "Stock" Then
            chartt.SeriesTemplate.ChangeView(ViewType.Stock)
        ElseIf view = "Candle Stick" Then
            chartt.SeriesTemplate.ChangeView(ViewType.CandleStick)
        ElseIf view = "Gantt" Then
            chartt.SeriesTemplate.ChangeView(ViewType.Gantt)
        ElseIf view = "Side by Side Gantt" Then
            chartt.SeriesTemplate.ChangeView(ViewType.SideBySideGantt)
        End If
    End Sub
End Class