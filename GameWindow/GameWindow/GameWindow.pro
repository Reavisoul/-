QT       += core gui

greaterThan(QT_MAJOR_VERSION, 4): QT += widgets

CONFIG += c++11

# The following define makes your compiler emit warnings if you use
# any Qt feature that has been marked deprecated (the exact warnings
# depend on your compiler). Please consult the documentation of the
# deprecated API in order to know how to port your code away from it.
DEFINES += QT_DEPRECATED_WARNINGS

# You can also make your code fail to compile if it uses deprecated APIs.
# In order to do so, uncomment the following line.
# You can also select to disable deprecated APIs only up to a certain version of Qt.
#DEFINES += QT_DISABLE_DEPRECATED_BEFORE=0x060000    # disables all the APIs deprecated before Qt 6.0.0

SOURCES += \
    main.cpp \
    mainwindow.cpp

HEADERS += \
    mainwindow.h

FORMS += \
    mainwindow.ui

# Default rules for deployment.
qnx: target.path = /tmp/$${TARGET}/bin
else: unix:!android: target.path = /opt/$${TARGET}/bin
!isEmpty(target.path): INSTALLS += target

RESOURCES += \
    Resources.qrc

DISTFILES += \
    Creash_Sweets/Creash_Sweets.exe \
    Creash_Sweets/Creash_Sweets_Data/Managed/Assembly-CSharp.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/Mono.Security.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/System.ComponentModel.Composition.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/System.Configuration.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/System.Core.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/System.Data.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/System.Diagnostics.StackTrace.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/System.Drawing.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/System.EnterpriseServices.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/System.Globalization.Extensions.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/System.IO.Compression.FileSystem.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/System.IO.Compression.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/System.Net.Http.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/System.Numerics.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/System.Runtime.Serialization.Xml.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/System.Runtime.Serialization.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/System.ServiceModel.Internals.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/System.Transactions.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/System.Xml.Linq.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/System.Xml.XPath.XDocument.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/System.Xml.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/System.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/Unity.2D.Animation.Runtime.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/Unity.2D.Animation.Triangle.Runtime.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/Unity.2D.Common.Runtime.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/Unity.2D.PixelPerfect.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/Unity.2D.SpriteShape.Runtime.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/Unity.InternalAPIEngineBridge.001.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/Unity.Mathematics.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/Unity.TextMeshPro.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/Unity.Timeline.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.AIModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.ARModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.AccessibilityModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.AndroidJNIModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.AnimationModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.AssetBundleModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.AudioModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.ClothModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.ClusterInputModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.ClusterRendererModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.CoreModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.CrashReportingModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.DSPGraphModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.DirectorModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.GameCenterModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.GridModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.HotReloadModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.IMGUIModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.ImageConversionModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.InputLegacyModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.InputModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.JSONSerializeModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.LocalizationModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.ParticleSystemModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.PerformanceReportingModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.Physics2DModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.PhysicsModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.ProfilerModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.ScreenCaptureModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.SharedInternalsModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.SpriteMaskModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.SpriteShapeModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.StreamingModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.SubstanceModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.SubsystemsModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.TLSModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.TerrainModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.TerrainPhysicsModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.TextCoreModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.TextRenderingModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.TilemapModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.UI.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.UIElementsModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.UIElementsNativeModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.UIModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.UNETModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.UmbraModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.UnityAnalyticsModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.UnityConnectModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.UnityTestProtocolModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.UnityWebRequestAssetBundleModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.UnityWebRequestAudioModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.UnityWebRequestModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.UnityWebRequestTextureModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.UnityWebRequestWWWModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.VFXModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.VRModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.VehiclesModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.VideoModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.VirtualTexturingModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.WindModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.XRModule.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/UnityEngine.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/mscorlib.dll \
    Creash_Sweets/Creash_Sweets_Data/Managed/netstandard.dll \
    Creash_Sweets/Creash_Sweets_Data/Resources/unity default resources \
    Creash_Sweets/Creash_Sweets_Data/Resources/unity_builtin_extra \
    Creash_Sweets/Creash_Sweets_Data/app.info \
    Creash_Sweets/Creash_Sweets_Data/globalgamemanagers \
    Creash_Sweets/Creash_Sweets_Data/globalgamemanagers.assets \
    Creash_Sweets/Creash_Sweets_Data/level0 \
    Creash_Sweets/Creash_Sweets_Data/level1 \
    Creash_Sweets/Creash_Sweets_Data/sharedassets0.assets \
    Creash_Sweets/Creash_Sweets_Data/sharedassets0.assets.resS \
    Creash_Sweets/Creash_Sweets_Data/sharedassets0.resource \
    Creash_Sweets/Creash_Sweets_Data/sharedassets1.assets \
    Creash_Sweets/Creash_Sweets_Data/sharedassets1.assets.resS \
    Creash_Sweets/Creash_Sweets_Data/sharedassets1.resource \
    Creash_Sweets/MonoBleedingEdge/EmbedRuntime/MonoPosixHelper.dll \
    Creash_Sweets/MonoBleedingEdge/EmbedRuntime/mono-2.0-bdwgc.dll \
    Creash_Sweets/MonoBleedingEdge/etc/mono/2.0/Browsers/Compat.browser \
    Creash_Sweets/MonoBleedingEdge/etc/mono/2.0/DefaultWsdlHelpGenerator.aspx \
    Creash_Sweets/MonoBleedingEdge/etc/mono/2.0/settings.map \
    Creash_Sweets/MonoBleedingEdge/etc/mono/4.0/Browsers/Compat.browser \
    Creash_Sweets/MonoBleedingEdge/etc/mono/4.0/DefaultWsdlHelpGenerator.aspx \
    Creash_Sweets/MonoBleedingEdge/etc/mono/4.0/settings.map \
    Creash_Sweets/MonoBleedingEdge/etc/mono/4.5/Browsers/Compat.browser \
    Creash_Sweets/MonoBleedingEdge/etc/mono/4.5/DefaultWsdlHelpGenerator.aspx \
    Creash_Sweets/MonoBleedingEdge/etc/mono/4.5/settings.map \
    Creash_Sweets/MonoBleedingEdge/etc/mono/browscap.ini \
    Creash_Sweets/MonoBleedingEdge/etc/mono/config \
    Creash_Sweets/MonoBleedingEdge/etc/mono/mconfig/config.xml \
    Creash_Sweets/UnityCrashHandler64.exe \
    Creash_Sweets/UnityPlayer.dll \
    Tank_War/MonoBleedingEdge/EmbedRuntime/MonoPosixHelper.dll \
    Tank_War/MonoBleedingEdge/EmbedRuntime/mono-2.0-bdwgc.dll \
    Tank_War/MonoBleedingEdge/etc/mono/2.0/Browsers/Compat.browser \
    Tank_War/MonoBleedingEdge/etc/mono/2.0/DefaultWsdlHelpGenerator.aspx \
    Tank_War/MonoBleedingEdge/etc/mono/2.0/settings.map \
    Tank_War/MonoBleedingEdge/etc/mono/4.0/Browsers/Compat.browser \
    Tank_War/MonoBleedingEdge/etc/mono/4.0/DefaultWsdlHelpGenerator.aspx \
    Tank_War/MonoBleedingEdge/etc/mono/4.0/settings.map \
    Tank_War/MonoBleedingEdge/etc/mono/4.5/Browsers/Compat.browser \
    Tank_War/MonoBleedingEdge/etc/mono/4.5/DefaultWsdlHelpGenerator.aspx \
    Tank_War/MonoBleedingEdge/etc/mono/4.5/settings.map \
    Tank_War/MonoBleedingEdge/etc/mono/browscap.ini \
    Tank_War/MonoBleedingEdge/etc/mono/config \
    Tank_War/MonoBleedingEdge/etc/mono/mconfig/config.xml \
    Tank_War/Tank_War.exe \
    Tank_War/Tank_War_Data/Managed/Assembly-CSharp.dll \
    Tank_War/Tank_War_Data/Managed/Mono.Security.dll \
    Tank_War/Tank_War_Data/Managed/System.ComponentModel.Composition.dll \
    Tank_War/Tank_War_Data/Managed/System.Configuration.dll \
    Tank_War/Tank_War_Data/Managed/System.Core.dll \
    Tank_War/Tank_War_Data/Managed/System.Data.dll \
    Tank_War/Tank_War_Data/Managed/System.Diagnostics.StackTrace.dll \
    Tank_War/Tank_War_Data/Managed/System.Drawing.dll \
    Tank_War/Tank_War_Data/Managed/System.EnterpriseServices.dll \
    Tank_War/Tank_War_Data/Managed/System.Globalization.Extensions.dll \
    Tank_War/Tank_War_Data/Managed/System.IO.Compression.FileSystem.dll \
    Tank_War/Tank_War_Data/Managed/System.IO.Compression.dll \
    Tank_War/Tank_War_Data/Managed/System.Net.Http.dll \
    Tank_War/Tank_War_Data/Managed/System.Numerics.dll \
    Tank_War/Tank_War_Data/Managed/System.Runtime.Serialization.Xml.dll \
    Tank_War/Tank_War_Data/Managed/System.Runtime.Serialization.dll \
    Tank_War/Tank_War_Data/Managed/System.ServiceModel.Internals.dll \
    Tank_War/Tank_War_Data/Managed/System.Transactions.dll \
    Tank_War/Tank_War_Data/Managed/System.Xml.Linq.dll \
    Tank_War/Tank_War_Data/Managed/System.Xml.XPath.XDocument.dll \
    Tank_War/Tank_War_Data/Managed/System.Xml.dll \
    Tank_War/Tank_War_Data/Managed/System.dll \
    Tank_War/Tank_War_Data/Managed/Unity.2D.Animation.Runtime.dll \
    Tank_War/Tank_War_Data/Managed/Unity.2D.Animation.Triangle.Runtime.dll \
    Tank_War/Tank_War_Data/Managed/Unity.2D.Common.Runtime.dll \
    Tank_War/Tank_War_Data/Managed/Unity.2D.PixelPerfect.dll \
    Tank_War/Tank_War_Data/Managed/Unity.2D.SpriteShape.Runtime.dll \
    Tank_War/Tank_War_Data/Managed/Unity.InternalAPIEngineBridge.001.dll \
    Tank_War/Tank_War_Data/Managed/Unity.Mathematics.dll \
    Tank_War/Tank_War_Data/Managed/Unity.TextMeshPro.dll \
    Tank_War/Tank_War_Data/Managed/Unity.Timeline.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.AIModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.ARModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.AccessibilityModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.AndroidJNIModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.AnimationModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.AssetBundleModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.AudioModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.ClothModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.ClusterInputModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.ClusterRendererModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.CoreModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.CrashReportingModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.DSPGraphModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.DirectorModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.GameCenterModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.GridModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.HotReloadModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.IMGUIModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.ImageConversionModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.InputLegacyModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.InputModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.JSONSerializeModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.LocalizationModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.ParticleSystemModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.PerformanceReportingModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.Physics2DModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.PhysicsModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.ProfilerModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.ScreenCaptureModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.SharedInternalsModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.SpriteMaskModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.SpriteShapeModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.StreamingModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.SubstanceModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.SubsystemsModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.TLSModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.TerrainModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.TerrainPhysicsModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.TextCoreModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.TextRenderingModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.TilemapModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.UI.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.UIElementsModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.UIElementsNativeModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.UIModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.UNETModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.UmbraModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.UnityAnalyticsModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.UnityConnectModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.UnityTestProtocolModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.UnityWebRequestAssetBundleModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.UnityWebRequestAudioModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.UnityWebRequestModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.UnityWebRequestTextureModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.UnityWebRequestWWWModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.VFXModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.VRModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.VehiclesModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.VideoModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.VirtualTexturingModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.WindModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.XRModule.dll \
    Tank_War/Tank_War_Data/Managed/UnityEngine.dll \
    Tank_War/Tank_War_Data/Managed/mscorlib.dll \
    Tank_War/Tank_War_Data/Managed/netstandard.dll \
    Tank_War/Tank_War_Data/Resources/unity default resources \
    Tank_War/Tank_War_Data/Resources/unity_builtin_extra \
    Tank_War/Tank_War_Data/app.info \
    Tank_War/Tank_War_Data/globalgamemanagers \
    Tank_War/Tank_War_Data/globalgamemanagers.assets \
    Tank_War/Tank_War_Data/level0 \
    Tank_War/Tank_War_Data/level1 \
    Tank_War/Tank_War_Data/level2 \
    Tank_War/Tank_War_Data/sharedassets0.assets \
    Tank_War/Tank_War_Data/sharedassets0.assets.resS \
    Tank_War/Tank_War_Data/sharedassets0.resource \
    Tank_War/Tank_War_Data/sharedassets1.assets \
    Tank_War/Tank_War_Data/sharedassets1.assets.resS \
    Tank_War/Tank_War_Data/sharedassets1.resource \
    Tank_War/Tank_War_Data/sharedassets2.assets \
    Tank_War/Tank_War_Data/sharedassets2.assets.resS \
    Tank_War/UnityCrashHandler64.exe \
    Tank_War/UnityPlayer.dll
