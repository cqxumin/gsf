'***********************************************************************
'  PDCstream.CompositeValues.vb - Composite values class
'  Copyright � 2004 - TVA, all rights reserved
'
'  Build Environment: VB.NET, Visual Studio 2003
'  Primary Developer: James R Carroll, System Analyst [WESTAFF]
'      Office: COO - TRNS/PWR ELEC SYS O, CHATTANOOGA, TN - MR 2W-C
'       Phone: 423/751-2827
'       Email: jrcarrol@tva.gov
'
'  Code Modification History:
'  ---------------------------------------------------------------------
'  11/12/2004 - James R Carroll
'       Initial version of source generated
'
'***********************************************************************

Namespace PDCstream

    ' Data comes in one point at a time, so we use this class to temporaily cache all needed
    ' composite values until they've all been received so that a compound value can be created
    Public Class CompositeValues

        Private Structure CompositeValue

            Public Value As Double
            Public Received As Boolean

        End Structure

        Private m_compositeValues As CompositeValue()

        Public Sub New(ByVal count As Integer)

            m_compositeValues = Array.CreateInstance(GetType(CompositeValue), count)

        End Sub

        Default Public Property Value(ByVal index As Integer) As Double
            Get
                Return m_compositeValues(index).Value
            End Get
            Set(ByVal Value As Double)
                With m_compositeValues(index)
                    .Value = Value
                    .Received = True
                End With
            End Set
        End Property

        Public ReadOnly Property Received(ByVal index As Integer) As Boolean
            Get
                Return m_compositeValues(index).Received
            End Get
        End Property

        Public ReadOnly Property Count() As Integer
            Get
                Return m_compositeValues.Length
            End Get
        End Property

        Public ReadOnly Property AllReceived() As Boolean
            Get
                Dim allValuesReceived As Boolean = True

                For x As Integer = 0 To m_compositeValues.Length - 1
                    If Not m_compositeValues(x).Received Then
                        allValuesReceived = False
                        Exit For
                    End If
                Next

                Return allValuesReceived
            End Get
        End Property

    End Class

End Namespace
