Imports System
Imports System.Collections.Generic
Imports System.Web
Imports System.Web.Routing
Imports Microsoft.AspNet.FriendlyUrls

Public Class RouteConfig
    Public Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
        Dim settings = New FriendlyUrlSettings()
        settings.AutoRedirectMode = RedirectMode.Permanent
        routes.EnableFriendlyUrls(settings)
    End Sub
End Class