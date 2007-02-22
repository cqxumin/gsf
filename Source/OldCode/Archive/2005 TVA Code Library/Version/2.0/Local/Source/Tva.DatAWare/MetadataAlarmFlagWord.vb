' 02/22/2007

Imports Tva.Interop.Bit

Public Class MetadataAlarmFlagWord

#Region " Member Declaration "

    Private m_flagWord As Int32

    Private Const UnknownMask As Int32 = Bit0
    Private Const DeletedFromProcessingMask As Int32 = Bit1
    Private Const CouldNotCalculatePointMask As Int32 = Bit2
    Private Const DASFrontEndHardwareErrorMask As Int32 = Bit3
    Private Const SensorReadErrorMask As Int32 = Bit4
    Private Const OpenTransducerDetectionMask As Int32 = Bit5
    Private Const InputCountsOutOfSensorRangeMask As Int32 = Bit6
    Private Const UnreasonableHighMask As Int32 = Bit7
    Private Const UnreasonableLowMask As Int32 = Bit8
    Private Const OldMask As Int32 = Bit9
    Private Const SuspectValueAboveHiHiLimitMask As Int32 = Bit10
    Private Const SuspectValueBelowLoLoLimitMask As Int32 = Bit11
    Private Const SuspectValueAboveHiLimitMask As Int32 = Bit12
    Private Const SuspectValueBelowLoLimitMask As Int32 = Bit13
    Private Const SuspectDataMask As Int32 = Bit14
    Private Const DigitalSuspectAlarmMask As Int32 = Bit15
    Private Const InsertedValueAboveHiHiLimitMask As Int32 = Bit16
    Private Const InsertedValueBelowLoLoLimitMask As Int32 = Bit17
    Private Const InsertedValueAboveHiLimitMask As Int32 = Bit18
    Private Const InsertedValueBelowLoLimitMask As Int32 = Bit19
    Private Const InsertedValueMask As Int32 = Bit20
    Private Const DigitalInsertedStatusInAlarmMask As Int32 = Bit21
    Private Const LogicalAlarmMask As Int32 = Bit22
    Private Const ValueAboveHiHiAlarmMask As Int32 = Bit23
    Private Const ValueBelowLoLoAlarmMask As Int32 = Bit24
    Private Const ValueAboveHiAlarmMask As Int32 = Bit25
    Private Const ValueBelowLoAlarmMask As Int32 = Bit26
    Private Const DeletedFromAlarmChecksMask As Int32 = Bit27
    Private Const InhibitedByCutoutPointMask As Int32 = Bit28
    Private Const GoodMask As Int32 = Bit29

    Public Sub New(ByVal flagWord As Int32)

        MyBase.New()
        m_flagWord = flagWord

    End Sub

    Public Property Unknown() As Boolean
        Get
            Return Convert.ToBoolean((m_flagWord And Convert.ToInt32((2 ^ Quality.Unknown))))
        End Get
        Set(ByVal value As Boolean)
            If value Then
                m_flagWord = (m_flagWord Or Convert.ToInt32((2 ^ Quality.Unknown)))
            Else
                m_flagWord = (m_flagWord And Not Convert.ToInt32((2 ^ Quality.Unknown)))
            End If
        End Set
    End Property

    Public Property DeletedFromProcessing() As Boolean
        Get
            Return Convert.ToBoolean((m_flagWord And Convert.ToInt32((2 ^ Quality.DeletedFromProcessing))))
        End Get
        Set(ByVal value As Boolean)
            If value Then
                m_flagWord = (m_flagWord Or Convert.ToInt32((2 ^ Quality.DeletedFromProcessing)))
            Else
                m_flagWord = (m_flagWord And Not Convert.ToInt32((2 ^ Quality.DeletedFromProcessing)))
            End If
        End Set
    End Property

    Public Property CouldNotCalculatePoint() As Boolean
        Get
            Return Convert.ToBoolean((m_flagWord And Convert.ToInt32((2 ^ Quality.CouldNotCalculatePoint))))
        End Get
        Set(ByVal value As Boolean)
            If value Then
                m_flagWord = (m_flagWord Or Convert.ToInt32((2 ^ Quality.CouldNotCalculatePoint)))
            Else
                m_flagWord = (m_flagWord And Not Convert.ToInt32((2 ^ Quality.CouldNotCalculatePoint)))
            End If
        End Set
    End Property

    Public Property DASFrontEndHardwareError() As Boolean
        Get
            Return Convert.ToBoolean((m_flagWord And Convert.ToInt32((2 ^ Quality.DASFrontEndHardwareError))))
        End Get
        Set(ByVal value As Boolean)
            If value Then
                m_flagWord = (m_flagWord Or Convert.ToInt32((2 ^ Quality.DASFrontEndHardwareError)))
            Else
                m_flagWord = (m_flagWord And Not Convert.ToInt32((2 ^ Quality.DASFrontEndHardwareError)))
            End If
        End Set
    End Property

    Public Property SensorReadError() As Boolean
        Get
            Return Convert.ToBoolean((m_flagWord And Convert.ToInt32((2 ^ Quality.SensorReadError))))
        End Get
        Set(ByVal value As Boolean)
            If value Then
                m_flagWord = (m_flagWord Or Convert.ToInt32((2 ^ Quality.SensorReadError)))
            Else
                m_flagWord = (m_flagWord And Not Convert.ToInt32((2 ^ Quality.SensorReadError)))
            End If
        End Set
    End Property

    Public Property OpenTransducerDetection() As Boolean
        Get
            Return Convert.ToBoolean((m_flagWord And Convert.ToInt32((2 ^ Quality.OpenTransducerDetection))))
        End Get
        Set(ByVal value As Boolean)
            If value Then
                m_flagWord = (m_flagWord Or Convert.ToInt32((2 ^ Quality.OpenTransducerDetection)))
            Else
                m_flagWord = (m_flagWord And Not Convert.ToInt32((2 ^ Quality.OpenTransducerDetection)))
            End If
        End Set
    End Property

    Public Property InputCountsOutOfSensorRange() As Boolean
        Get
            Return Convert.ToBoolean((m_flagWord And Convert.ToInt32((2 ^ Quality.InputCountsOutOfSensorRange))))
        End Get
        Set(ByVal value As Boolean)
            If value Then
                m_flagWord = (m_flagWord Or Convert.ToInt32((2 ^ Quality.InputCountsOutOfSensorRange)))
            Else
                m_flagWord = (m_flagWord And Not Convert.ToInt32((2 ^ Quality.InputCountsOutOfSensorRange)))
            End If
        End Set
    End Property

    Public Property UnreasonableHigh() As Boolean
        Get
            Return Convert.ToBoolean((m_flagWord And Convert.ToInt32((2 ^ Quality.UnreasonableHigh))))
        End Get
        Set(ByVal value As Boolean)
            If value Then
                m_flagWord = (m_flagWord Or Convert.ToInt32((2 ^ Quality.UnreasonableHigh)))
            Else
                m_flagWord = (m_flagWord And Not Convert.ToInt32((2 ^ Quality.UnreasonableHigh)))
            End If
        End Set
    End Property

    Public Property UnreasonableLow() As Boolean
        Get
            Return Convert.ToBoolean((m_flagWord And Convert.ToInt32((2 ^ Quality.UnreasonableLow))))
        End Get
        Set(ByVal value As Boolean)
            If value Then
                m_flagWord = (m_flagWord Or Convert.ToInt32((2 ^ Quality.UnreasonableLow)))
            Else
                m_flagWord = (m_flagWord And Not Convert.ToInt32((2 ^ Quality.UnreasonableLow)))
            End If
        End Set
    End Property

    Public Property Old() As Boolean
        Get
            Return Convert.ToBoolean((m_flagWord And Convert.ToInt32((2 ^ Quality.Old))))
        End Get
        Set(ByVal value As Boolean)
            If value Then
                m_flagWord = (m_flagWord Or Convert.ToInt32((2 ^ Quality.Old)))
            Else
                m_flagWord = (m_flagWord And Not Convert.ToInt32((2 ^ Quality.Old)))
            End If
        End Set
    End Property

    Public Property SuspectValueAboveHiHiLimit() As Boolean
        Get
            Return Convert.ToBoolean((m_flagWord And Convert.ToInt32((2 ^ Quality.SuspectValueAboveHiHiLimit))))
        End Get
        Set(ByVal value As Boolean)
            If value Then
                m_flagWord = (m_flagWord Or Convert.ToInt32((2 ^ Quality.SuspectValueAboveHiHiLimit)))
            Else
                m_flagWord = (m_flagWord And Not Convert.ToInt32((2 ^ Quality.SuspectValueAboveHiHiLimit)))
            End If
        End Set
    End Property

    Public Property SuspectValueBelowLoLoLimit() As Boolean
        Get
            Return Convert.ToBoolean((m_flagWord And Convert.ToInt32((2 ^ Quality.SuspectValueBelowLoLoLimit))))
        End Get
        Set(ByVal value As Boolean)
            If value Then
                m_flagWord = (m_flagWord Or Convert.ToInt32((2 ^ Quality.SuspectValueBelowLoLoLimit)))
            Else
                m_flagWord = (m_flagWord And Not Convert.ToInt32((2 ^ Quality.SuspectValueBelowLoLoLimit)))
            End If
        End Set
    End Property

    Public Property SuspectValueAboveHiLimit() As Boolean
        Get
            Return Convert.ToBoolean((m_flagWord And Convert.ToInt32((2 ^ Quality.SuspectValueAboveHiLimit))))
        End Get
        Set(ByVal value As Boolean)
            If value Then
                m_flagWord = (m_flagWord Or Convert.ToInt32((2 ^ Quality.SuspectValueAboveHiLimit)))
            Else
                m_flagWord = (m_flagWord And Not Convert.ToInt32((2 ^ Quality.SuspectValueAboveHiLimit)))
            End If
        End Set
    End Property

    Public Property SuspectValueBelowLoLimit() As Boolean
        Get
            Return Convert.ToBoolean((m_flagWord And Convert.ToInt32((2 ^ Quality.SuspectValueBelowLoLimit))))
        End Get
        Set(ByVal value As Boolean)
            If value Then
                m_flagWord = (m_flagWord Or Convert.ToInt32((2 ^ Quality.SuspectValueBelowLoLimit)))
            Else
                m_flagWord = (m_flagWord And Not Convert.ToInt32((2 ^ Quality.SuspectValueBelowLoLimit)))
            End If
        End Set
    End Property

    Public Property SuspectData() As Boolean
        Get
            Return Convert.ToBoolean((m_flagWord And Convert.ToInt32((2 ^ Quality.SuspectData))))
        End Get
        Set(ByVal value As Boolean)
            If value Then
                m_flagWord = (m_flagWord Or Convert.ToInt32((2 ^ Quality.SuspectData)))
            Else
                m_flagWord = (m_flagWord And Not Convert.ToInt32((2 ^ Quality.SuspectData)))
            End If
        End Set
    End Property

    Public Property DigitalSuspectAlarm() As Boolean
        Get
            Return Convert.ToBoolean((m_flagWord And Convert.ToInt32((2 ^ Quality.DigitalSuspectAlarm))))
        End Get
        Set(ByVal value As Boolean)
            If value Then
                m_flagWord = (m_flagWord Or Convert.ToInt32((2 ^ Quality.DigitalSuspectAlarm)))
            Else
                m_flagWord = (m_flagWord And Not Convert.ToInt32((2 ^ Quality.DigitalSuspectAlarm)))
            End If
        End Set
    End Property

    Public Property InsertedValueAboveHiHiLimit() As Boolean
        Get
            Return Convert.ToBoolean((m_flagWord And Convert.ToInt32((2 ^ Quality.InsertedValueAboveHiHiLimit))))
        End Get
        Set(ByVal value As Boolean)
            If value Then
                m_flagWord = (m_flagWord Or Convert.ToInt32((2 ^ Quality.InsertedValueAboveHiHiLimit)))
            Else
                m_flagWord = (m_flagWord And Not Convert.ToInt32((2 ^ Quality.InsertedValueAboveHiHiLimit)))
            End If
        End Set
    End Property

    Public Property InsertedValueBelowLoLoLimit() As Boolean
        Get
            Return Convert.ToBoolean((m_flagWord And Convert.ToInt32((2 ^ Quality.InsertedValueBelowLoLoLimit))))
        End Get
        Set(ByVal value As Boolean)
            If value Then
                m_flagWord = (m_flagWord Or Convert.ToInt32((2 ^ Quality.InsertedValueBelowLoLoLimit)))
            Else
                m_flagWord = (m_flagWord And Not Convert.ToInt32((2 ^ Quality.InsertedValueBelowLoLoLimit)))
            End If
        End Set
    End Property

    Public Property InsertedValueAboveHiLimit() As Boolean
        Get
            Return Convert.ToBoolean((m_flagWord And Convert.ToInt32((2 ^ Quality.InsertedValueAboveHiLimit))))
        End Get
        Set(ByVal value As Boolean)
            If value Then
                m_flagWord = (m_flagWord Or Convert.ToInt32((2 ^ Quality.InsertedValueAboveHiLimit)))
            Else
                m_flagWord = (m_flagWord And Not Convert.ToInt32((2 ^ Quality.InsertedValueAboveHiLimit)))
            End If
        End Set
    End Property

    Public Property InsertedValueBelowLoLimit() As Boolean
        Get
            Return Convert.ToBoolean((m_flagWord And Convert.ToInt32((2 ^ Quality.InsertedValueBelowLoLimit))))
        End Get
        Set(ByVal value As Boolean)
            If value Then
                m_flagWord = (m_flagWord Or Convert.ToInt32((2 ^ Quality.InsertedValueBelowLoLimit)))
            Else
                m_flagWord = (m_flagWord And Not Convert.ToInt32((2 ^ Quality.InsertedValueBelowLoLimit)))
            End If
        End Set
    End Property

    Public Property InsertedValue() As Boolean
        Get
            Return Convert.ToBoolean((m_flagWord And Convert.ToInt32((2 ^ Quality.InsertedValue))))
        End Get
        Set(ByVal value As Boolean)
            If value Then
                m_flagWord = (m_flagWord Or Convert.ToInt32((2 ^ Quality.InsertedValue)))
            Else
                m_flagWord = (m_flagWord And Not Convert.ToInt32((2 ^ Quality.InsertedValue)))
            End If
        End Set
    End Property

    Public Property DigitalInsertedStatusInAlarm() As Boolean
        Get
            Return Convert.ToBoolean((m_flagWord And Convert.ToInt32((2 ^ Quality.DigitalInsertedStatusInAlarm))))
        End Get
        Set(ByVal value As Boolean)
            If value Then
                m_flagWord = (m_flagWord Or Convert.ToInt32((2 ^ Quality.DigitalInsertedStatusInAlarm)))
            Else
                m_flagWord = (m_flagWord And Not Convert.ToInt32((2 ^ Quality.DigitalInsertedStatusInAlarm)))
            End If
        End Set
    End Property

    Public Property LogicalAlarm() As Boolean
        Get
            Return Convert.ToBoolean((m_flagWord And Convert.ToInt32((2 ^ Quality.LogicalAlarm))))
        End Get
        Set(ByVal value As Boolean)
            If value Then
                m_flagWord = (m_flagWord Or Convert.ToInt32((2 ^ Quality.LogicalAlarm)))
            Else
                m_flagWord = (m_flagWord And Not Convert.ToInt32((2 ^ Quality.LogicalAlarm)))
            End If
        End Set
    End Property

    Public Property ValueAboveHiHiAlarm() As Boolean
        Get
            Return Convert.ToBoolean((m_flagWord And Convert.ToInt32((2 ^ Quality.ValueAboveHiHiAlarm))))
        End Get
        Set(ByVal value As Boolean)
            If value Then
                m_flagWord = (m_flagWord Or Convert.ToInt32((2 ^ Quality.ValueAboveHiHiAlarm)))
            Else
                m_flagWord = (m_flagWord And Not Convert.ToInt32((2 ^ Quality.ValueAboveHiHiAlarm)))
            End If
        End Set
    End Property

    Public Property ValueBelowLoLoAlarm() As Boolean
        Get
            Return Convert.ToBoolean((m_flagWord And Convert.ToInt32((2 ^ Quality.ValueBelowLoLoAlarm))))
        End Get
        Set(ByVal value As Boolean)
            If value Then
                m_flagWord = (m_flagWord Or Convert.ToInt32((2 ^ Quality.ValueBelowLoLoAlarm)))
            Else
                m_flagWord = (m_flagWord And Not Convert.ToInt32((2 ^ Quality.ValueBelowLoLoAlarm)))
            End If
        End Set
    End Property

    Public Property ValueAboveHiAlarm() As Boolean
        Get
            Return Convert.ToBoolean((m_flagWord And Convert.ToInt32((2 ^ Quality.ValueAboveHiAlarm))))
        End Get
        Set(ByVal value As Boolean)
            If value Then
                m_flagWord = (m_flagWord Or Convert.ToInt32((2 ^ Quality.ValueAboveHiAlarm)))
            Else
                m_flagWord = (m_flagWord And Not Convert.ToInt32((2 ^ Quality.ValueAboveHiAlarm)))
            End If
        End Set
    End Property

    Public Property ValueBelowLoAlarm() As Boolean
        Get
            Return Convert.ToBoolean((m_flagWord And Convert.ToInt32((2 ^ Quality.ValueBelowLoAlarm))))
        End Get
        Set(ByVal value As Boolean)
            If value Then
                m_flagWord = (m_flagWord Or Convert.ToInt32((2 ^ Quality.ValueBelowLoAlarm)))
            Else
                m_flagWord = (m_flagWord And Not Convert.ToInt32((2 ^ Quality.ValueBelowLoAlarm)))
            End If
        End Set
    End Property

    Public Property DeletedFromAlarmChecks() As Boolean
        Get
            Return Convert.ToBoolean((m_flagWord And Convert.ToInt32((2 ^ Quality.DeletedFromAlarmChecks))))
        End Get
        Set(ByVal value As Boolean)
            If value Then
                m_flagWord = (m_flagWord Or Convert.ToInt32((2 ^ Quality.DeletedFromAlarmChecks)))
            Else
                m_flagWord = (m_flagWord And Not Convert.ToInt32((2 ^ Quality.DeletedFromAlarmChecks)))
            End If
        End Set
    End Property

    Public Property InhibitedByCutoutPoint() As Boolean
        Get
            Return Convert.ToBoolean((m_flagWord And Convert.ToInt32((2 ^ Quality.InhibitedByCutoutPoint))))
        End Get
        Set(ByVal value As Boolean)
            If value Then
                m_flagWord = (m_flagWord Or Convert.ToInt32((2 ^ Quality.InhibitedByCutoutPoint)))
            Else
                m_flagWord = (m_flagWord And Not Convert.ToInt32((2 ^ Quality.InhibitedByCutoutPoint)))
            End If
        End Set
    End Property

    Public Property Good() As Boolean
        Get
            Return Convert.ToBoolean((m_flagWord And Convert.ToInt32((2 ^ Quality.Good))))
        End Get
        Set(ByVal value As Boolean)
            If value Then
                m_flagWord = (m_flagWord Or Convert.ToInt32((2 ^ Quality.Good)))
            Else
                m_flagWord = (m_flagWord And Not Convert.ToInt32((2 ^ Quality.Good)))
            End If
        End Set
    End Property

    Public Property Value() As Int32
        Get
            Return m_flagWord
        End Get
        Set(ByVal value As Int32)
            m_flagWord = value
        End Set
    End Property

#End Region

End Class
