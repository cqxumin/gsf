﻿//*******************************************************************************************************
//  WaveFile.cs - Gbtc
//
//  Tennessee Valley Authority, 2009
//  No copyright is claimed pursuant to 17 USC § 105.  All Other Rights Reserved.
//
//  This software is made freely available under the TVA Open Source Agreement (see below).
//  Code in this file licensed to TVA under one or more contributor license agreements listed below.
//
//  Code Modification History:
//  -----------------------------------------------------------------------------------------------------
//  07/29/2009 - J. Ritchie Carroll
//       Generated original version of source code.
//  08/06/2009 - Josh L. Patterson
//       Edited Comments.
//  09/14/2009 - Stephen C. Wills
//       Added new header and license agreement.
//
//*******************************************************************************************************

#region [ TVA Open Source Agreement ]
/*

 THIS OPEN SOURCE AGREEMENT ("AGREEMENT") DEFINES THE RIGHTS OF USE,REPRODUCTION, DISTRIBUTION,
 MODIFICATION AND REDISTRIBUTION OF CERTAIN COMPUTER SOFTWARE ORIGINALLY RELEASED BY THE
 TENNESSEE VALLEY AUTHORITY, A CORPORATE AGENCY AND INSTRUMENTALITY OF THE UNITED STATES GOVERNMENT
 ("GOVERNMENT AGENCY"). GOVERNMENT AGENCY IS AN INTENDED THIRD-PARTY BENEFICIARY OF ALL SUBSEQUENT
 DISTRIBUTIONS OR REDISTRIBUTIONS OF THE SUBJECT SOFTWARE. ANYONE WHO USES, REPRODUCES, DISTRIBUTES,
 MODIFIES OR REDISTRIBUTES THE SUBJECT SOFTWARE, AS DEFINED HEREIN, OR ANY PART THEREOF, IS, BY THAT
 ACTION, ACCEPTING IN FULL THE RESPONSIBILITIES AND OBLIGATIONS CONTAINED IN THIS AGREEMENT.

 Original Software Designation: openPDC
 Original Software Title: The TVA Open Source Phasor Data Concentrator
 User Registration Requested. Please Visit https://naspi.tva.com/Registration/
 Point of Contact for Original Software: J. Ritchie Carroll <mailto:jrcarrol@tva.gov>

 1. DEFINITIONS

 A. "Contributor" means Government Agency, as the developer of the Original Software, and any entity
 that makes a Modification.

 B. "Covered Patents" mean patent claims licensable by a Contributor that are necessarily infringed by
 the use or sale of its Modification alone or when combined with the Subject Software.

 C. "Display" means the showing of a copy of the Subject Software, either directly or by means of an
 image, or any other device.

 D. "Distribution" means conveyance or transfer of the Subject Software, regardless of means, to
 another.

 E. "Larger Work" means computer software that combines Subject Software, or portions thereof, with
 software separate from the Subject Software that is not governed by the terms of this Agreement.

 F. "Modification" means any alteration of, including addition to or deletion from, the substance or
 structure of either the Original Software or Subject Software, and includes derivative works, as that
 term is defined in the Copyright Statute, 17 USC § 101. However, the act of including Subject Software
 as part of a Larger Work does not in and of itself constitute a Modification.

 G. "Original Software" means the computer software first released under this Agreement by Government
 Agency entitled openPDC, including source code, object code and accompanying documentation, if any.

 H. "Recipient" means anyone who acquires the Subject Software under this Agreement, including all
 Contributors.

 I. "Redistribution" means Distribution of the Subject Software after a Modification has been made.

 J. "Reproduction" means the making of a counterpart, image or copy of the Subject Software.

 K. "Sale" means the exchange of the Subject Software for money or equivalent value.

 L. "Subject Software" means the Original Software, Modifications, or any respective parts thereof.

 M. "Use" means the application or employment of the Subject Software for any purpose.

 2. GRANT OF RIGHTS

 A. Under Non-Patent Rights: Subject to the terms and conditions of this Agreement, each Contributor,
 with respect to its own contribution to the Subject Software, hereby grants to each Recipient a
 non-exclusive, world-wide, royalty-free license to engage in the following activities pertaining to
 the Subject Software:

 1. Use

 2. Distribution

 3. Reproduction

 4. Modification

 5. Redistribution

 6. Display

 B. Under Patent Rights: Subject to the terms and conditions of this Agreement, each Contributor, with
 respect to its own contribution to the Subject Software, hereby grants to each Recipient under Covered
 Patents a non-exclusive, world-wide, royalty-free license to engage in the following activities
 pertaining to the Subject Software:

 1. Use

 2. Distribution

 3. Reproduction

 4. Sale

 5. Offer for Sale

 C. The rights granted under Paragraph B. also apply to the combination of a Contributor's Modification
 and the Subject Software if, at the time the Modification is added by the Contributor, the addition of
 such Modification causes the combination to be covered by the Covered Patents. It does not apply to
 any other combinations that include a Modification. 

 D. The rights granted in Paragraphs A. and B. allow the Recipient to sublicense those same rights.
 Such sublicense must be under the same terms and conditions of this Agreement.

 3. OBLIGATIONS OF RECIPIENT

 A. Distribution or Redistribution of the Subject Software must be made under this Agreement except for
 additions covered under paragraph 3H. 

 1. Whenever a Recipient distributes or redistributes the Subject Software, a copy of this Agreement
 must be included with each copy of the Subject Software; and

 2. If Recipient distributes or redistributes the Subject Software in any form other than source code,
 Recipient must also make the source code freely available, and must provide with each copy of the
 Subject Software information on how to obtain the source code in a reasonable manner on or through a
 medium customarily used for software exchange.

 B. Each Recipient must ensure that the following copyright notice appears prominently in the Subject
 Software:

          No copyright is claimed pursuant to 17 USC § 105.  All Other Rights Reserved.

 C. Each Contributor must characterize its alteration of the Subject Software as a Modification and
 must identify itself as the originator of its Modification in a manner that reasonably allows
 subsequent Recipients to identify the originator of the Modification. In fulfillment of these
 requirements, Contributor must include a file (e.g., a change log file) that describes the alterations
 made and the date of the alterations, identifies Contributor as originator of the alterations, and
 consents to characterization of the alterations as a Modification, for example, by including a
 statement that the Modification is derived, directly or indirectly, from Original Software provided by
 Government Agency. Once consent is granted, it may not thereafter be revoked.

 D. A Contributor may add its own copyright notice to the Subject Software. Once a copyright notice has
 been added to the Subject Software, a Recipient may not remove it without the express permission of
 the Contributor who added the notice.

 E. A Recipient may not make any representation in the Subject Software or in any promotional,
 advertising or other material that may be construed as an endorsement by Government Agency or by any
 prior Recipient of any product or service provided by Recipient, or that may seek to obtain commercial
 advantage by the fact of Government Agency's or a prior Recipient's participation in this Agreement.

 F. In an effort to track usage and maintain accurate records of the Subject Software, each Recipient,
 upon receipt of the Subject Software, is requested to register with Government Agency by visiting the
 following website: https://naspi.tva.com/Registration/. Recipient's name and personal information
 shall be used for statistical purposes only. Once a Recipient makes a Modification available, it is
 requested that the Recipient inform Government Agency at the web site provided above how to access the
 Modification.

 G. Each Contributor represents that that its Modification does not violate any existing agreements,
 regulations, statutes or rules, and further that Contributor has sufficient rights to grant the rights
 conveyed by this Agreement.

 H. A Recipient may choose to offer, and to charge a fee for, warranty, support, indemnity and/or
 liability obligations to one or more other Recipients of the Subject Software. A Recipient may do so,
 however, only on its own behalf and not on behalf of Government Agency or any other Recipient. Such a
 Recipient must make it absolutely clear that any such warranty, support, indemnity and/or liability
 obligation is offered by that Recipient alone. Further, such Recipient agrees to indemnify Government
 Agency and every other Recipient for any liability incurred by them as a result of warranty, support,
 indemnity and/or liability offered by such Recipient.

 I. A Recipient may create a Larger Work by combining Subject Software with separate software not
 governed by the terms of this agreement and distribute the Larger Work as a single product. In such
 case, the Recipient must make sure Subject Software, or portions thereof, included in the Larger Work
 is subject to this Agreement.

 J. Notwithstanding any provisions contained herein, Recipient is hereby put on notice that export of
 any goods or technical data from the United States may require some form of export license from the
 U.S. Government. Failure to obtain necessary export licenses may result in criminal liability under
 U.S. laws. Government Agency neither represents that a license shall not be required nor that, if
 required, it shall be issued. Nothing granted herein provides any such export license.

 4. DISCLAIMER OF WARRANTIES AND LIABILITIES; WAIVER AND INDEMNIFICATION

 A. No Warranty: THE SUBJECT SOFTWARE IS PROVIDED "AS IS" WITHOUT ANY WARRANTY OF ANY KIND, EITHER
 EXPRESSED, IMPLIED, OR STATUTORY, INCLUDING, BUT NOT LIMITED TO, ANY WARRANTY THAT THE SUBJECT
 SOFTWARE WILL CONFORM TO SPECIFICATIONS, ANY IMPLIED WARRANTIES OF MERCHANTABILITY, FITNESS FOR A
 PARTICULAR PURPOSE, OR FREEDOM FROM INFRINGEMENT, ANY WARRANTY THAT THE SUBJECT SOFTWARE WILL BE ERROR
 FREE, OR ANY WARRANTY THAT DOCUMENTATION, IF PROVIDED, WILL CONFORM TO THE SUBJECT SOFTWARE. THIS
 AGREEMENT DOES NOT, IN ANY MANNER, CONSTITUTE AN ENDORSEMENT BY GOVERNMENT AGENCY OR ANY PRIOR
 RECIPIENT OF ANY RESULTS, RESULTING DESIGNS, HARDWARE, SOFTWARE PRODUCTS OR ANY OTHER APPLICATIONS
 RESULTING FROM USE OF THE SUBJECT SOFTWARE. FURTHER, GOVERNMENT AGENCY DISCLAIMS ALL WARRANTIES AND
 LIABILITIES REGARDING THIRD-PARTY SOFTWARE, IF PRESENT IN THE ORIGINAL SOFTWARE, AND DISTRIBUTES IT
 "AS IS."

 B. Waiver and Indemnity: RECIPIENT AGREES TO WAIVE ANY AND ALL CLAIMS AGAINST GOVERNMENT AGENCY, ITS
 AGENTS, EMPLOYEES, CONTRACTORS AND SUBCONTRACTORS, AS WELL AS ANY PRIOR RECIPIENT. IF RECIPIENT'S USE
 OF THE SUBJECT SOFTWARE RESULTS IN ANY LIABILITIES, DEMANDS, DAMAGES, EXPENSES OR LOSSES ARISING FROM
 SUCH USE, INCLUDING ANY DAMAGES FROM PRODUCTS BASED ON, OR RESULTING FROM, RECIPIENT'S USE OF THE
 SUBJECT SOFTWARE, RECIPIENT SHALL INDEMNIFY AND HOLD HARMLESS  GOVERNMENT AGENCY, ITS AGENTS,
 EMPLOYEES, CONTRACTORS AND SUBCONTRACTORS, AS WELL AS ANY PRIOR RECIPIENT, TO THE EXTENT PERMITTED BY
 LAW.  THE FOREGOING RELEASE AND INDEMNIFICATION SHALL APPLY EVEN IF THE LIABILITIES, DEMANDS, DAMAGES,
 EXPENSES OR LOSSES ARE CAUSED, OCCASIONED, OR CONTRIBUTED TO BY THE NEGLIGENCE, SOLE OR CONCURRENT, OF
 GOVERNMENT AGENCY OR ANY PRIOR RECIPIENT.  RECIPIENT'S SOLE REMEDY FOR ANY SUCH MATTER SHALL BE THE
 IMMEDIATE, UNILATERAL TERMINATION OF THIS AGREEMENT.

 5. GENERAL TERMS

 A. Termination: This Agreement and the rights granted hereunder will terminate automatically if a
 Recipient fails to comply with these terms and conditions, and fails to cure such noncompliance within
 thirty (30) days of becoming aware of such noncompliance. Upon termination, a Recipient agrees to
 immediately cease use and distribution of the Subject Software. All sublicenses to the Subject
 Software properly granted by the breaching Recipient shall survive any such termination of this
 Agreement.

 B. Severability: If any provision of this Agreement is invalid or unenforceable under applicable law,
 it shall not affect the validity or enforceability of the remainder of the terms of this Agreement.

 C. Applicable Law: This Agreement shall be subject to United States federal law only for all purposes,
 including, but not limited to, determining the validity of this Agreement, the meaning of its
 provisions and the rights, obligations and remedies of the parties.

 D. Entire Understanding: This Agreement constitutes the entire understanding and agreement of the
 parties relating to release of the Subject Software and may not be superseded, modified or amended
 except by further written agreement duly executed by the parties.

 E. Binding Authority: By accepting and using the Subject Software under this Agreement, a Recipient
 affirms its authority to bind the Recipient to all terms and conditions of this Agreement and that
 Recipient hereby agrees to all terms and conditions herein.

 F. Point of Contact: Any Recipient contact with Government Agency is to be directed to the designated
 representative as follows: J. Ritchie Carroll <mailto:jrcarrol@tva.gov>.

*/
#endregion

#region [ Contributor License Agreements ]

/**************************************************************************\
   Copyright © 2009 - J. Ritchie Carroll
   All rights reserved.
  
   Redistribution and use in source and binary forms, with or without
   modification, are permitted provided that the following conditions
   are met:
  
      * Redistributions of source code must retain the above copyright
        notice, this list of conditions and the following disclaimer.
       
      * Redistributions in binary form must reproduce the above
        copyright notice, this list of conditions and the following
        disclaimer in the documentation and/or other materials provided
        with the distribution.
  
   THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDER "AS IS" AND ANY
   EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
   IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR
   PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR
   CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL,
   EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
   PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR
   PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY
   OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
   (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
   OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
  
\**************************************************************************/

#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Media;

namespace TVA.Media
{
    #region [ Enumerations ]

    /// <summary>
    /// Typical samples rates supported by wave files.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Quantization of the analog waveform, or signal, is a real-time process operating over a continuous
    /// time-period which produces a “stream” of digital values. In order for the process to work you must
    /// define the rate at which new digital values are measured, or sampled, from the analog signal. The
    /// rate at which new values are measured is called the “sampling rate” (a.k.a., the sampling frequency).
    /// </para>
    /// <para>
    /// Audio based Compact Discs use a sampling rate of 44,100 Hz; this means the the Nyquist frequency is
    /// 22,050 Hz (i.e., the upper bound on the highest frequency that the digital data can clearly represent
    /// without aliasing). This sample rate selection was no accident as the range of hearing for a healthy
    /// young person is approximately 20 to 20,000 Hz.
    /// </para>
    /// <para>
    /// In plain English, higher sampling rates will equate to higher quality sound reproduction but anything
    /// above 44,100 Hz will not be perceived as better quality by normal human beings.
    /// </para>
    /// </remarks>
    public enum SampleRate
    {
        /// <summary>8000 samples per second</summary>
        Hz8000 = 8000,
        /// <summary>11025 samples per second</summary>
        Hz11025 = 11025,
        /// <summary>12000 samples per second</summary>
        Hz12000 = 12000,
        /// <summary>16000 samples per second</summary>
        Hz16000 = 16000,
        /// <summary>22050 samples per second</summary>
        Hz22050 = 22050,
        /// <summary>24000 samples per second</summary>
        Hz24000 = 24000,
        /// <summary>32000 samples per second</summary>
        Hz32000 = 32000,
        /// <summary>44100 samples per second</summary>
        /// <remarks>This is the standard setting for CD audio quality</remarks>
        Hz44100 = 44100,
        /// <summary>48000 samples per second</summary>
        Hz48000 = 48000
    }

    /// <summary>
    /// Typical bit sizes supported by wave files.
    /// </summary>
    /// <remarks>
    /// Strictly speaking, “bits-per-sample” describes the total number of bits used
    /// to encode the amplitude (or volume) of a sampled signal.  The following table
    /// describes a few typical bit ranges and their possible resolution:
    /// <list type="table">
    /// <listheader>
    ///     <term>Bit range</term>
    ///     <description>Resolution</description>
    /// </listheader>
    /// <item>
    ///     <term>8-bits (1 Byte)</term>
    ///     <description>0 to 255</description>
    /// </item>
    /// <item>
    ///     <term>16-bits (2 Bytes)</term>
    ///     <description>-32,768 to 32,767</description>
    /// </item>
    /// <item>
    ///     <term>24-bits (3 Bytes)</term>
    ///     <description>-8,388,608 to 8,388,607</description>
    /// </item>
    /// <item>
    ///     <term>32-bits (4 Bytes)</term>
    ///     <description>-2,147,483,648 to 2,147,483,647</description>
    /// </item>
    /// </list>
    /// The net result is that more bits you use, the more resolution you can achieve in
    /// amplitude; hence “more bits = better sound quality” however you have to compromise
    /// for technical constraints because “more bits = more required space”.
    /// </remarks>
    public enum BitsPerSample : short
    {
        /// <summary>8-bits per sample</summary>
        Bits8 = 8,
        /// <summary>16-bits per sample</summary>
        /// <remarks>This is the standard setting for CD audio quality</remarks>
        Bits16 = 16,
        /// <summary>24-bits per sample</summary>
        Bits24 = 24,
        /// <summary>32-bits per sample</summary>
        Bits32 = 32
    }

    /// <summary>
    /// Typical number of data channels used by wave files.
    /// </summary>
    /// <remarks>
    /// These are some common number of data channels, but wave files can support any number of data channels.
    /// </remarks>
    public enum DataChannels : short
    {
        /// <summary>Defines a single (monaural) data sample channel</summary>
        Mono = 1,
        /// <summary>Defines two (stereo) data sample channels</summary>
        /// <remarks>This is the standard setting for CD audio quality</remarks>
        Stereo = 2,
        /// <summary>Defines three data sample channels</summary>
        /// <remarks>3.0 Channel Surround (analog matrixed: Dolby Surround)</remarks>
        DolbySurround = 3,
        /// <summary>Defines four data sample channels</summary>
        /// <remarks>4.0 Channel Surround (analog matrixed: Dolby Pro Logic)</remarks>
        DolbyProLogic = 4,
        /// <summary>Defines six data sample channels</summary>
        /// <remarks>5.1 Channel Surround (digital discrete: Dolby Digital, DTS, SDDS)</remarks>
        DolbyDigital = 6
    }

    /// <summary>
    /// Common WAVE audio encoding formats.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Microsoft defines more than 130 different audio encoding formats for WAVE files.  Only the
    /// more common formats are defined here.
    /// </para>
    /// <para>
    /// Note that PCM (i.e., Pulse Code Modulation) is a universal audio encoding format.  It is a
    /// very common method of storing and transmitting uncompressed digital audio. Since it is a
    /// generic format, it can be read by most any audio application similar to the way a plain text
    /// file can be read by any word-processing program. PCM is used by Audio CDs and digital audio
    /// tapes (DATs). PCM is also a very common format for AIFF and WAV files.
    /// </para>
    /// </remarks>
    [CLSCompliant(false)]
    public enum WaveFormat : ushort
    {
        /// <summary>Wave format type is undefined.</summary>
        Unknown = 0x0,
        /// <summary>Standard pulse-code modulation audio format</summary>
        PCM = 0x1,
        /// <summary>Adpative differential pulse-code modulation encoding algorithm</summary>
        ADPCM = 0x2,
        /// <summary>Floating point PCM encoding algorithm</summary>
        IeeeFloat = 0x3,
        /// <summary>A-law encoding algorithm (used in Europe and the rest of the world)</summary>
        ALaw = 0x6,
        /// <summary>μ-law encoding algorithm (used in North America and Japan)</summary>
        MuLaw = 0x7,
        /// <summary>Decode Timestamp encoding algorithm (used in MPEG-coded multimedia)</summary>
        DTS = 0x8,
        /// <summary>Digital Rights Management encoded format (for digital-audio content protected by Microsoft DRM).</summary>
        DRM = 0x9,
        /// <summary>MPEG Audio is a family of open standards for compressed audio that includes MP2, MP3 and AAC.</summary>
        Mpeg = 0x50,
        /// <summary>ISO MPEG-Layer 3 audio format.</summary>
        MpegLayer3 = 0x55,
        /// <summary>Use WAVEFORMATEXTENSIBLE structure.</summary>
        /// <remarks>
        /// This wave file format is used to identify multiple channels in the wave file for spatial positioning
        /// of speakers, see <see cref="WaveFormatExtensible"/> for more details.
        /// </remarks>
        WaveFormatExtensible = 0xFFFE

        #region [ Other Wave Formats ]

        //OKI_ADPCM = 0x10,                    // OKI
        //DVI_ADPCM = 0x11,                    // Intel Corporation
        //IMA_ADPCM = 0x11,                    // Intel Corporation
        //MEDIASPACE_ADPCM = 0x12,             // Videologic
        //SIERRA_ADPCM = 0x13,                 // Sierra Semiconductor Corp
        //G723_ADPCM = 0x14,                   // Antex Electronics Corporation
        //DIGISTD = 0x15,                      // DSP Solutions, Inc.
        //DIGIFIX = 0x16,                      // DSP Solutions, Inc.
        //DIALOGIC_OKI_ADPCM = 0x17,           // Dialogic Corporation
        //MEDIAVISION_ADPCM = 0x18,            // Media Vision, Inc.
        //CU_CODEC = 0x19,                     // Hewlett-Packard Company
        //YAMAHA_ADPCM = 0x20,                 // Yamaha Corporation of America
        //SONARC = 0x21,                       // Speech Compression
        //DSPGROUP_TRUESPEECH = 0x22,          // DSP Group, Inc
        //ECHOSC1 = 0x23,                      // Echo Speech Corporation
        //AUDIOFILE_AF36 = 0x24,               // Virtual Music, Inc.
        //APTX = 0x25,                         // Audio Processing Technology
        //AUDIOFILE_AF10 = 0x26,               // Virtual Music, Inc.
        //PROSODY_1612 = 0x27,                 // Aculab plc
        //LRC = 0x28,                          // Merging Technologies S.A.
        //DOLBY_AC2 = 0x30,                    // Dolby Laboratories
        //GSM610 = 0x31,                       // Microsoft Corporation
        //MSNAUDIO = 0x32,                     // Microsoft Corporation
        //ANTEX_ADPCME = 0x33,                 // Antex Electronics Corporation
        //CONTROL_RES_VQLPC = 0x34,            // Control Resources Limited
        //DIGIREAL = 0x35,                     // DSP Solutions, Inc.
        //DIGIADPCM = 0x36,                    // DSP Solutions, Inc.
        //CONTROL_RES_CR10 = 0x37,             // Control Resources Limited
        //NMS_VBXADPCM = 0x38,                 // Natural MicroSystems
        //CS_IMAADPCM = 0x39,                  // Crystal Semiconductor IMA ADPCM
        //ECHOSC3 = 0x3A,                      // Echo Speech Corporation
        //ROCKWELL_ADPCM = 0x3B,               // Rockwell International
        //ROCKWELL_DIGITALK = 0x3C,            // Rockwell International
        //XEBEC = 0x3D,                        // Xebec Multimedia Solutions Limited
        //G721_ADPCM = 0x40,                   // Antex Electronics Corporation
        //G728_CELP = 0x41,                    // Antex Electronics Corporation
        //MSG723 = 0x42,                       // Microsoft Corporation
        //RT24 = 0x52,                         // InSoft, Inc.
        //PAC = 0x53,                          // InSoft, Inc.
        //LUCENT_G723 = 0x59,                  // Lucent Technologies
        //CIRRUS = 0x60,                       // Cirrus Logic
        //ESPCM = 0x61,                        // ESS Technology
        //VOXWARE = 0x62,                      // Voxware Inc
        //CANOPUS_ATRAC = 0x63,                // Canopus, co., Ltd.
        //G726_ADPCM = 0x64,                   // APICOM
        //G722_ADPCM = 0x65,                   // APICOM
        //DSAT_DISPLAY = 0x67,                 // Microsoft Corporation
        //VOXWARE_BYTE_ALIGNED = 0x69,         // Voxware Inc
        //VOXWARE_AC8 = 0x70,                  // Voxware Inc
        //VOXWARE_AC10 = 0x71,                 // Voxware Inc
        //VOXWARE_AC16 = 0x72,                 // Voxware Inc
        //VOXWARE_AC20 = 0x73,                 // Voxware Inc
        //VOXWARE_RT24 = 0x74,                 // Voxware Inc
        //VOXWARE_RT29 = 0x75,                 // Voxware Inc
        //VOXWARE_RT29HW = 0x76,               // Voxware Inc
        //VOXWARE_VR12 = 0x77,                 // Voxware Inc
        //VOXWARE_VR18 = 0x78,                 // Voxware Inc
        //VOXWARE_TQ40 = 0x79,                 // Voxware Inc
        //SOFTSOUND = 0x80,                    // Softsound, Ltd.
        //VOXWARE_TQ60 = 0x81,                 // Voxware Inc
        //MSRT24 = 0x82,                       // Microsoft Corporation
        //G729A = 0x83,                        // AT&T Labs, Inc.
        //MVI_MVI2 = 0x84,                     // Motion Pixels
        //DF_G726 = 0x85,                      // DataFusion Systems (Pty) (Ltd)
        //DF_GSM610 = 0x86,                    // DataFusion Systems (Pty) (Ltd)
        //ISIAUDIO = 0x88,                     // Iterated Systems, Inc.
        //ONLIVE = 0x89,                       // OnLive! Technologies, Inc.
        //SBC24 = 0x91,                        // Siemens Business Communications Sys
        //DOLBY_AC3_SPDIF = 0x92,              // Sonic Foundry
        //MEDIASONIC_G723 = 0x93,              // MediaSonic
        //PROSODY_8KBPS = 0x94,                // Aculab plc
        //ZYXEL_ADPCM = 0x97,                  // ZyXEL Communications, Inc.
        //PHILIPS_LPCBB = 0x98,                // Philips Speech Processing
        //PACKED = 0x99,                       // Studer Professional Audio AG
        //MALDEN_PHONYTALK = 0xA0,             // Malden Electronics Ltd.
        //RHETOREX_ADPCM = 0x100,              // Rhetorex Inc.
        //IRAT = 0x101,                        // BeCubed Software Inc.
        //VIVO_G723 = 0x111,                   // Vivo Software
        //VIVO_SIREN = 0x112,                  // Vivo Software
        //DIGITAL_G723 = 0x123,                // Digital Equipment Corporation
        //SANYO_LD_ADPCM = 0x125,              // Sanyo Electric Co., Ltd.
        //SIPROLAB_ACEPLNET = 0x130,           // Sipro Lab Telecom Inc.
        //SIPROLAB_ACELP4800 = 0x131,          // Sipro Lab Telecom Inc.
        //SIPROLAB_ACELP8V3 = 0x132,           // Sipro Lab Telecom Inc.
        //SIPROLAB_G729 = 0x133,               // Sipro Lab Telecom Inc.
        //SIPROLAB_G729A = 0x134,              // Sipro Lab Telecom Inc.
        //SIPROLAB_KELVIN = 0x135,             // Sipro Lab Telecom Inc.
        //G726ADPCM = 0x140,                   // Dictaphone Corporation
        //QUALCOMM_PUREVOICE = 0x150,          // Qualcomm, Inc.
        //QUALCOMM_HALFRATE = 0x151,           // Qualcomm, Inc.
        //TUBGSM = 0x155,                      // Ring Zero Systems, Inc.
        //MSAUDIO1 = 0x160,                    // Microsoft Corporation
        //UNISYS_NAP_ADPCM = 0x170,            // Unisys Corp.
        //UNISYS_NAP_ULAW = 0x171,             // Unisys Corp.
        //UNISYS_NAP_ALAW = 0x172,             // Unisys Corp.
        //UNISYS_NAP_16K = 0x173,              // Unisys Corp.
        //CREATIVE_ADPCM = 0x200,              // Creative Labs, Inc
        //CREATIVE_FASTSPEECH8 = 0x202,        // Creative Labs, Inc
        //CREATIVE_FASTSPEECH10 = 0x203,       // Creative Labs, Inc
        //UHER_ADPCM = 0x210,                  // UHER informatic GmbH
        //QUARTERDECK = 0x220,                 // Quarterdeck Corporation
        //ILINK_VC = 0x230,                    // I-link Worldwide
        //RAW_SPORT = 0x240,                   // Aureal Semiconductor
        //ESST_AC3 = 0x241,                    // ESS Technology, Inc.
        //IPI_HSX = 0x250,                     // Interactive Products, Inc.
        //IPI_RPELP = 0x251,                   // Interactive Products, Inc.
        //CS2 = 0x260,                         // Consistent Software
        //SONY_SCX = 0x270,                    // Sony Corp.
        //FM_TOWNS_SND = 0x300,                // Fujitsu Corp.
        //BTV_DIGITAL = 0x400,                 // Brooktree Corporation
        //QDESIGN_MUSIC = 0x450,               // QDesign Corporation
        //VME_VMPCM = 0x680,                   // AT&T Labs, Inc.
        //TPC = 0x681,                         // AT&T Labs, Inc.
        //OLIGSM = 0x1000,                     // Ing C. Olivetti & C., S.p.A.
        //OLIADPCM = 0x1001,                   // Ing C. Olivetti & C., S.p.A.
        //OLICELP = 0x1002,                    // Ing C. Olivetti & C., S.p.A.
        //OLISBC = 0x1003,                     // Ing C. Olivetti & C., S.p.A.
        //OLIOPR = 0x1004,                     // Ing C. Olivetti & C., S.p.A.
        //LH_CODEC = 0x1100,                   // Lernout & Hauspie
        //NORRIS = 0x1400,                     // Norris Communications, Inc.
        //SOUNDSPACE_MUSICOMPRESS = 0x1500,    // AT&T Labs, Inc.
        //DVM = 0x2000                         // FAST Multimedia AG

        #endregion
    }

    #endregion

    /// <summary>
    /// Represents a waveform audio format file (WAV).
    /// </summary>
    public class WaveFile
    {
        #region [ Waveform Format Structure ]

        // /* general waveform format structure (information common to all formats) */
        // typedef struct waveformat_tag {
        //     WORD    wFormatTag;        /* format type */
        //     WORD    nChannels;         /* number of channels (i.e. mono, stereo...) */
        //     DWORD   nSamplesPerSec;    /* sample rate */
        //     DWORD   nAvgBytesPerSec;   /* for buffer estimation */
        //     WORD    nBlockAlign;       /* block size of data */
        // } WAVEFORMAT;

        //Offset  Size  Name             Description
        //--------------------------------------------------------------------------------
        //The canonical WAVE format starts with the RIFF header:

        //0         4   ChunkID          Contains the letters "RIFF" in ASCII form
        //                               (0x52494646 big-endian form).
        //4         4   ChunkSize        36 + SubChunk2Size, or more precisely:
        //                               4 + (8 + SubChunk1Size) + (8 + SubChunk2Size)
        //                               This is the size of the rest of the chunk 
        //                               following this number.  This is the size of the 
        //                               entire file in bytes minus 8 bytes for the
        //                               two fields not included in this count:
        //                               ChunkID and ChunkSize.
        //8         4   Format           Contains the letters "WAVE"
        //                               (0x57415645 big-endian form).

        //The "WAVE" format consists of two subchunks: "fmt " and "data":
        //The "fmt " subchunk describes the sound data's format:

        //12        4   Subchunk1ID      Contains the letters "fmt "
        //                               (0x666d7420 big-endian form).
        //16        4   Subchunk1Size    16 for PCM.  This is the size of the
        //                               rest of the Subchunk which follows this number.
        //20        2   AudioFormat      PCM = 1 (i.e. Linear quantization)
        //                               Values other than 1 indicate some 
        //                               form of compression.
        //22        2   NumChannels      Mono = 1, Stereo = 2, etc.
        //24        4   SampleRate       8000, 44100, etc.
        //28        4   ByteRate         == SampleRate * NumChannels * BitsPerSample/8
        //32        2   BlockAlign       == NumChannels * BitsPerSample/8
        //                               The number of bytes for one sample including
        //                               all channels. I wonder what happens when
        //                               this number isn't an integer?
        //34        2   BitsPerSample    8 bits = 8, 16 bits = 16, etc.
        //          2   ExtraParamSize   if PCM, then doesn't exist
        //          X   ExtraParams      space for extra parameters

        //The "data" subchunk contains the size of the data and the actual sound:

        //36        4   Subchunk2ID      Contains the letters "data"
        //                               (0x64617461 big-endian form).
        //40        4   Subchunk2Size    == NumSamples * NumChannels * BitsPerSample/8
        //                               This is the number of bytes in the data.
        //                               You can also think of this as the size
        //                               of the read of the subchunk following this 
        //                               number.
        //44        *   Data             The actual sound data.

        #endregion

        #region [ Members ]

        // Fields
        private RiffHeaderChunk m_waveHeader;
        private WaveFormatChunk m_waveFormat;
        private WaveDataChunk m_waveData;
        private ListInfoChunk m_listInfo;

        #endregion

        #region [ Constructors ]

        /// <summary>
        /// Creates a new empty in-memory wave file using standard CD quality settings.
        /// </summary>
        public WaveFile()
        {
            m_waveHeader = new RiffHeaderChunk("WAVE");
            m_waveFormat = new WaveFormatChunk(44100, 16, 2, 0x1);
            m_waveData = new WaveDataChunk(m_waveFormat);
        }

        /// <summary>
        /// Creates a new empty in-memory wave file in Pulse Code Modulation (PCM) audio format.
        /// </summary>
        /// <param name="sampleRate">Desired sample rate.</param>
        /// <param name="bitsPerSample">Desired bits-per-sample.</param>
        /// <param name="channels">Desired data channels.</param>
        public WaveFile(SampleRate sampleRate, BitsPerSample bitsPerSample, DataChannels channels)
            : this((int)sampleRate, (short)bitsPerSample, (short)channels, (ushort)WaveFormat.PCM)
        {
        }

        /// <summary>
        /// Creates a new empty in-memory wave file in specified audio format.
        /// </summary>
        /// <param name="sampleRate">Desired sample rate.</param>
        /// <param name="bitsPerSample">Desired bits-per-sample.</param>
        /// <param name="channels">Desired data channels.</param>
        /// <param name="audioFormat">Desired audio format.</param>
        /// <remarks>Consumer will need to apply appropriate data compression for non-PCM data formats.</remarks>
        [CLSCompliant(false)]
        public WaveFile(SampleRate sampleRate, BitsPerSample bitsPerSample, DataChannels channels, WaveFormat audioFormat)
            : this((int)sampleRate, (short)bitsPerSample, (short)channels, (ushort)audioFormat)
        {
        }

        /// <summary>
        /// Creates a new empty in-memory wave file in Pulse Code Modulation (PCM) audio format.
        /// </summary>
        /// <param name="sampleRate">Desired sample rate (e.g., 44100).</param>
        /// <param name="bitsPerSample">Desired bits-per-sample (e.g., 16).</param>
        /// <param name="channels">Desired data channels (e.g., 2 for stereo).</param>
        public WaveFile(int sampleRate, short bitsPerSample, short channels)
            : this(sampleRate, bitsPerSample, channels, (ushort)WaveFormat.PCM)
        {
        }

        /// <summary>
        /// Creates a new empty in-memory wave file in specified audio format.
        /// </summary>
        /// <param name="sampleRate">Desired sample rate (e.g., 44100).</param>
        /// <param name="bitsPerSample">Desired bits-per-sample (e.g., 16).</param>
        /// <param name="channels">Desired data channels (e.g., 2 for stereo).</param>
        /// <param name="audioFormat">Desired audio format (e.g., 0x1 for Pulse Code Modulation).</param>
        /// <remarks>
        /// Consumer will need to apply appropriate data compression for non-PCM data formats.
        /// </remarks>
        [CLSCompliant(false)]
        public WaveFile(int sampleRate, short bitsPerSample, short channels, ushort audioFormat)
        {
            m_waveHeader = new RiffHeaderChunk("WAVE");
            m_waveFormat = new WaveFormatChunk(sampleRate, bitsPerSample, channels, audioFormat);
            m_waveData = new WaveDataChunk(m_waveFormat);
        }

        /// <summary>
        /// Creates a new empty in-memory wave file using existing constituent chunks.
        /// </summary>
        /// <param name="waveData">A <see cref="RiffHeaderChunk"/> header object.</param>
        /// <param name="waveFormat">A <see cref="WaveFormatChunk"/> format object.</param>
        /// <param name="waveHeader">A <see cref="WaveDataChunk"/> data object</param>
        /// <param name="listInfo">Optional <see cref="ListInfoChunk"/> object.</param>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public WaveFile(RiffHeaderChunk waveHeader, WaveFormatChunk waveFormat, WaveDataChunk waveData, ListInfoChunk listInfo = null)
        {
            m_waveHeader = waveHeader;
            m_waveFormat = waveFormat;
            m_waveData = waveData;
            m_listInfo = listInfo;
        }

        #endregion

        #region [ Properties ]

        /// <summary>
        /// Gets or sets audio format used by the <see cref="WaveFile"/>.
        /// </summary>
        /// <remarks>
        /// PCM = 1 (i.e., linear quantization), values other than 1 typically indicate some form of compression.
        /// See <see cref="WaveFormat"/> enumeration for more details.
        /// </remarks>
        [CLSCompliant(false)]
        public ushort AudioFormat
        {
            get
            {
                return m_waveFormat.AudioFormat;
            }
            set
            {
                m_waveFormat.AudioFormat = value;
            }
        }

        /// <summary>
        /// Gets or sets number of audio channels in the <see cref="WaveFile"/>.
        /// </summary>
        /// <remarks>
        /// This property defines the number of channels (e.g., mono = 1, stereo = 2, etc.) defined
        /// in each sample block. See <see cref="DataChannels"/> enumeration for more details.
        /// </remarks>
        public short Channels
        {
            get
            {
                return m_waveFormat.Channels;
            }
            set
            {
                m_waveFormat.Channels = value;
            }
        }

        /// <summary>
        /// Gets or sets the sample rate (i.e., the number of samples per second) defined in the <see cref="WaveFile"/>.
        /// </summary>
        /// <remarks>
        /// This property defines the number of samples per second defined in each second of data in
        /// the <see cref="WaveFile"/>.  See <see cref="SampleRate"/> enumeraion for more details.
        /// </remarks>
        public int SampleRate
        {
            get
            {
                return m_waveFormat.SampleRate;
            }
            set
            {
                m_waveFormat.SampleRate = value;
            }
        }

        /// <summary>
        /// Gets or sets the byte rate used for buffer estimation.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This property is not usually changed.  It will be automatically calculated for new wave files.
        /// </para>
        /// <para>
        /// This is typically just the arithmetic result of:
        /// <see cref="SampleRate"/> * <see cref="Channels"/> * <see cref="BitsPerSample"/> / 8.
        /// However, this value can be changed as needed to accomodate better buffer estimations during
        /// data read cycle.
        /// </para>
        /// </remarks>
        public int ByteRate
        {
            get
            {
                return m_waveFormat.ByteRate;
            }
            set
            {
                m_waveFormat.ByteRate = value;
            }
        }

        /// <summary>
        /// Gets or sets the block size of a complete sample of data (i.e., samples for all channels of data at
        /// one instant in time).
        /// </summary>
        /// <remarks>
        /// <para>
        /// This property is not usually changed.  It will be automatically calculated for new wave files.
        /// </para>
        /// <para>
        /// This is typically just the arithmetic result of:
        /// <see cref="Channels"/> * <see cref="BitsPerSample"/> / 8.
        /// However, this value can be changed as needed to accomodate even block-alignment of non-standard
        /// <see cref="BitsPerSample"/> values.
        /// </para>
        /// </remarks>
        public short BlockAlignment
        {
            get
            {
                return m_waveFormat.BlockAlignment;
            }
            set
            {
                m_waveFormat.BlockAlignment = value;
            }
        }

        /// <summary>
        /// Gets or sets number of bits-per-sample in the <see cref="WaveFile"/>.
        /// </summary>
        /// <remarks>
        /// This property defines the number of bits-per-sample (e.g., 8, 16, 24, 32, etc.) used
        /// by each sample in a block of samples - effectively the data sample size. See
        /// <see cref="BitsPerSample"/> enumeration for more details.
        /// </remarks>
        public short BitsPerSample
        {
            get
            {
                return m_waveFormat.BitsPerSample;
            }
            set
            {
                m_waveFormat.BitsPerSample = value;
            }
        }

        /// <summary>
        /// Returns the amplitude scalar for the given bits per sample of the WaveFile (i.e., maximum value
        /// for given <see cref="BitsPerSample"/>).
        /// </summary>
        /// <remarks>
        /// This defines a scaling factor (essentially a maximum value) used for integer based wave file
        /// formats.  Floating point wave file formats do not need such scaling.
        /// </remarks>
        public double AmplitudeScalar
        {
            get
            {
                // Return amplitude factor for given bit size
                switch (BitsPerSample)
                {
                    case 8:
                        return SByte.MaxValue;
                    case 16:
                        return Int16.MaxValue;
                    case 24:
                        return Int24.MaxValue;
                    case 32:
                        return Int32.MaxValue;
                    case 64:
                        return Int64.MaxValue;
                    default:
                        throw new InvalidOperationException(string.Format("Cannot get \"AmplitudeScalar\" for {0} bits per sample - must be 8, 16, 24, 32 or 64", BitsPerSample));
                }
            }
        }

        /// <summary>
        /// Gets list of info strings available in this <see cref="WaveFile"/> if any were available during load; otherwise an empty dictionary.
        /// </summary>
        /// <remarks>
        /// The current implementation only allows reading of loaded <see cref="WaveFile"/> metadata tags, not updating them.
        /// </remarks>
        public Dictionary<string, string> InfoStrings
        {
            get
            {
                if (m_listInfo != null)
                    return m_listInfo.InfoStrings;

                return new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
            }
        }

        /// <summary>
        /// Gets calculated audio length.
        /// </summary>
        public TimeSpan AudioLength
        {
            get
            {
                return Ticks.FromSeconds((m_waveData.ChunkSize / m_waveFormat.BlockAlignment) / (double)m_waveFormat.SampleRate);
            }
        }

        /// <summary>
        /// Gets the size of the <see cref="ExtraParameters"/> buffer, if defined.
        /// </summary>
        public short ExtraParametersSize
        {
            get
            {
                return m_waveFormat.ExtraParametersSize;
            }
        }

        /// <summary>
        /// Gets or sets any extra parameters defined in the format header of the <see cref="WaveFile"/>.
        /// </summary>
        /// <remarks>
        /// See the <see cref="WaveFormatExtensible"/> class for an example of usage of this property.
        /// </remarks>
        public byte[] ExtraParameters
        {
            get
            {
                return m_waveFormat.ExtraParameters;
            }
            set
            {
                m_waveFormat.ExtraParameters = value;
            }
        }

        /// <summary>
        /// Accesses each individual block of sample data indexed by time.
        /// </summary>
        public List<LittleBinaryValue[]> SampleBlocks
        {
            get
            {
                return m_waveData.SampleBlocks;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="RiffHeaderChunk"/> of this <see cref="WaveFile"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public RiffHeaderChunk HeaderChunk
        {
            get
            {
                return m_waveHeader;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="WaveFormatChunk"/> of this <see cref="WaveFile"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public WaveFormatChunk FormatChunk
        {
            get
            {
                return m_waveFormat;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="WaveDataChunk"/> of this <see cref="WaveFile"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public WaveDataChunk DataChunk
        {
            get
            {
                return m_waveData;
            }
        }

        /// <summary>
        /// Gets the <see cref="ListInfoChunk"/> of this <see cref="WaveFile"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public ListInfoChunk InfoChunk
        {
            get
            {
                return m_listInfo;
            }
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Add the sample to the wave file.
        /// </summary>
        /// <param name="sample">Sample to add to the wave file.</param>
        /// <remarks>
        /// <para>
        /// Sample is applied to all channels and cast to the appropriate size.  Sample should be scaled
        /// by <see cref="AmplitudeScalar"/> for integer based wave file formats to make sure sample will
        /// fit into <see cref="BitsPerSample"/> defined by wave file.
        /// </para>
        /// <para>
        /// If you have samples to apply to individual channels (e.g., for a stereo format), use the
        /// <see cref="AddSamples"/> method instead.
        /// </para>
        /// </remarks>
        public void AddSample(double sample)
        {
            LittleBinaryValue[] binaryValues;

            // Create a new sample block for wave file
            binaryValues = new LittleBinaryValue[m_waveFormat.Channels];

            // Iterate through each channel in WaveFile applying same value to each channel
            for (int x = 0; x < m_waveFormat.Channels; x++)
            {
                // Cast sample value to appropriate data type based on bit size
                binaryValues[x] = m_waveFormat.CastSample(sample);
            }

            // Add sample block to WaveFile
            AddSampleBlock(binaryValues);
        }

        /// <summary>
        /// Adds a series of samples, one per channel, to the wave file.
        /// </summary>
        /// <param name="samples">Samples to add to the wave file.</param>
        /// <remarks>
        /// <para>
        /// You need to pass in one sample for each defined channel (e.g., if wave is configured for stereo
        /// you will need to pass in two parameters).
        /// </para>
        /// Each sample will be cast to the appropriate size.  Samples should be scaled by <see cref="AmplitudeScalar"/>
        /// for integer based wave file formats to make sure samples will fit into <see cref="BitsPerSample"/> defined
        /// by wave file.
        /// </remarks>
        public void AddSamples(params double[] samples)
        {
            // Validate number of samples
            if (samples.Length != m_waveFormat.Channels)
                throw new ArgumentOutOfRangeException("samples", "You must provide one sample for each defined channel");

            LittleBinaryValue[] binaryValues;

            // Create a new sample block for wave file
            binaryValues = new LittleBinaryValue[samples.Length];

            // Iterate through each channel in provided data samples
            for (int x = 0; x < samples.Length; x++)
            {
                // Cast sample value to appropriate data type based on bit size
                binaryValues[x] = m_waveFormat.CastSample(samples[x]);
            }

            // Add sample block to WaveFile
            AddSampleBlock(binaryValues);
        }

        /// <summary>
        /// Adds a block of samples in native format to the wave file (e.g., if <see cref="BitsPerSample"/> = 16,
        /// parameters need to be Int16 values). Note that <see cref="LittleBinaryValue"/> parameter type is
        /// implicitly castable to common native types, including floating points.
        /// </summary>
        /// <param name="samples">Samples to add to the wave file.</param>
        /// <remarks>
        /// <para>
        /// You need to pass in one sample for each defined channel (e.g., if wave is configured for stereo
        /// you will need to pass in two parameters).
        /// </para>
        /// You should only add values that match the wave file's <see cref="BitsPerSample"/> (e.g., if wave file is
        /// configured for 16-bits only pass in Int16 values, casting if necessary).
        /// </remarks>
        public void AddSampleBlock(params LittleBinaryValue[] samples)
        {
            // Validate number of samples
            if (samples.Length != m_waveFormat.Channels)
                throw new ArgumentOutOfRangeException("samples", "You must provide one sample for each defined channel");

            int byteLength = m_waveFormat.BitsPerSample / 8;

            // Validate bit-lengths of samples
            foreach (LittleBinaryValue item in samples)
            {
                if (item.Buffer.Length != byteLength)
                    throw new ArrayTypeMismatchException(string.Format("One of the parameters is {0}-bits and wave is configured for {1}-bits per sample", item.Buffer.Length * 8, m_waveFormat.BitsPerSample));
            }

            m_waveData.SampleBlocks.Add(samples);
        }

        /// <summary>
        /// Plays the wave file using <see cref="SoundPlayer"/>.
        /// </summary>
        public void Play()
        {
            MemoryStream stream = new MemoryStream();
            SoundPlayer player = new SoundPlayer(stream);
            Save(stream);
            stream.Position = 0;
            player.Play();
        }

        /// <summary>
        /// Saves wave file to the specified file name.
        /// </summary>
        /// <param name="waveFileName">Desired destination file name for wave file.</param>
        public void Save(string waveFileName)
        {
            FileStream stream = File.Create(waveFileName);
            Save(stream);
            stream.Close();
        }

        /// <summary>
        /// Saves wave file to the specified stream.
        /// </summary>
        /// <param name="destination">Destination stream for binary wave file data.</param>
        public void Save(Stream destination)
        {
            m_waveHeader.ChunkSize = 4 + m_waveFormat.BinaryLength + m_waveData.BinaryLength;
            destination.Write(m_waveHeader.BinaryImage, 0, m_waveHeader.BinaryLength);
            destination.Write(m_waveFormat.BinaryImage, 0, m_waveFormat.BinaryLength);
            destination.Write(m_waveData.BinaryImage, 0, m_waveData.BinaryLength);
        }

        /// <summary>
        /// Reverses the data samples in the wave file.
        /// </summary>
        /// <remarks>
        /// This is just used to reverse the sound in the file for effect.
        /// </remarks>
        public void Reverse()
        {
            m_waveData.SampleBlocks.Reverse();
        }

        /// <summary>
        /// Creates a deeply cloned copy of the <see cref="WaveFile"/>.
        /// </summary>
        /// <returns>A deeply cloned copy of the <see cref="WaveFile"/>.</returns>
        public WaveFile Clone()
        {
            RiffHeaderChunk waveHeader = m_waveHeader.Clone();
            WaveFormatChunk waveFormat = m_waveFormat.Clone();
            WaveDataChunk waveData = m_waveData.Clone();

            // Make sure new data chunk references new wave format
            waveData.WaveFormat = waveFormat;

            return new WaveFile(waveHeader, waveFormat, waveData);
        }

        /// <summary>
        /// Determines sample data type code based on defined <see cref="BitsPerSample"/>
        /// and <see cref="AudioFormat"/>.
        /// </summary>
        /// <returns>
        /// Sample type code based on defined <see cref="BitsPerSample"/> and
        /// <see cref="AudioFormat"/>.
        /// </returns>
        public TypeCode GetSampleTypeCode()
        {
            return m_waveFormat.GetSampleTypeCode();
        }

        /// <summary>
        /// Casts sample value to its equivalent native type based on defined <see cref="BitsPerSample"/>
        /// and <see cref="AudioFormat"/>.
        /// </summary>
        /// <param name="sample">Sample value.</param>
        /// <returns>
        /// Sample value cast to its equivalent native type based on defined <see cref="BitsPerSample"/>
        /// and <see cref="AudioFormat"/>.
        /// </returns>
        public LittleBinaryValue CastSample(double sample)
        {
            return m_waveFormat.CastSample(sample);
        }

        #endregion

        #region [ Static ]

        /// <summary>
        /// Creates a new in-memory wave loaded from an existing wave file.
        /// </summary>
        /// <param name="waveFileName">File name of WAV file to load.</param>
        /// <param name="loadData">Determines if wave data should be loaded into memory.</param>
        /// <returns>In-memory representation of wave file.</returns>
        public static WaveFile Load(string waveFileName, bool loadData = true)
        {
            FileStream source = File.Open(waveFileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            WaveFile waveFile = WaveFile.Load(source, loadData);
            source.Close();
            return waveFile;
        }

        /// <summary>
        /// Creates a new in-memory wave loaded from an existing wave audio stream.
        /// </summary>
        /// <param name="source">Stream of WAV formatted audio data to load.</param>
        /// <param name="loadData">Determines if wave data should be loaded into memory.</param>
        /// <returns>In-memory representation of wave file.</returns>
        public static WaveFile Load(Stream source, bool loadData = true)
        {
            RiffChunk riffChunk;
            RiffHeaderChunk waveHeader = null;
            WaveFormatChunk waveFormat = null;
            WaveDataChunk waveData = null;
            ListInfoChunk listInfo = null;

            while (source.Position < source.Length)
            {
                riffChunk = RiffChunk.ReadNext(source);

                switch (riffChunk.TypeID)
                {
                    case RiffHeaderChunk.RiffTypeID:
                        waveHeader = new RiffHeaderChunk(riffChunk, source, "WAVE");
                        break;
                    case WaveFormatChunk.RiffTypeID:
                        if (waveHeader == null)
                            throw new InvalidDataException("WAVE format section encountered before RIFF header, wave file corrupted");

                        waveFormat = new WaveFormatChunk(riffChunk, source);
                        break;
                    case WaveDataChunk.RiffTypeID:
                        if (waveFormat == null)
                            throw new InvalidDataException("WAVE data section encountered before format section, wave file corrupted");

                        if (loadData)
                        {
                            waveData = new WaveDataChunk(riffChunk, source, waveFormat);
                        }
                        else
                        {
                            source.Seek(riffChunk.ChunkSize, SeekOrigin.Current);
                            waveData = new WaveDataChunk(waveFormat);
                            waveData.ChunkSize = riffChunk.ChunkSize;
                        }
                        break;
                    case ListInfoChunk.RiffTypeID:
                        listInfo = new ListInfoChunk(riffChunk, source);
                        break;
                    default:
                        // Skip unidentified section
                        source.Seek(riffChunk.ChunkSize, SeekOrigin.Current);
                        break;
                }
            }

            return new WaveFile(waveHeader, waveFormat, waveData, listInfo);
        }

        /// <summary>
        /// Combines wave files together, all starting at the same time, into a single file.
        /// This has the effect of playing two sound tracks simultaneously.
        /// </summary>
        /// <param name="waveFiles">Wave files to combine</param>
        /// <returns>Combined wave files.</returns>
        /// <remarks>
        /// <para>
        /// This overload "equalizes" the volume of each source wave file.  To specify a desired volume for
        /// each combined wave file use the <see cref="Combine(WaveFile[], double[])"/> overload that takes
        /// a series of volumes as a parameter.
        /// </para>
        /// <para>
        /// Resulting sounds will overlap; no truncation is performed. Final wave file length will equal length of
        /// longest source file.
        /// </para>
        /// <para>
        /// Combining sounds files with non-PCM based audio formats will have unexpected results.
        /// </para>
        /// </remarks>
        public static WaveFile Combine(params WaveFile[] waveFiles)
        {
            double[] volumes = new double[waveFiles.Length];

            for (int x = 0; x < volumes.Length; x++)
            {
                volumes[x] = 1.0D / waveFiles.Length;
            }

            return Combine(waveFiles, volumes);
        }

        /// <summary>
        /// Combines wave files together, all starting at the same time, into a single file.
        /// This has the effect of playing two sound tracks simultaneously.
        /// </summary>
        /// <param name="waveFiles">Wave files to combine</param>
        /// <param name="volumes">Volume for each wave file (0.0 to 1.0)</param>
        /// <returns>Combined wave files.</returns>
        /// <remarks>
        /// <para>
        /// Cumulatively, volumes cannot exceed 1.0 - these volumes represent a fractional percentage
        /// of volume to be applied to each wave file.
        /// </para>
        /// <para>
        /// Resulting sounds will overlap; no truncation is performed. Final wave file length will equal length of
        /// longest source file.
        /// </para>
        /// <para>
        /// Combining sounds files with non-PCM based audio formats will have unexpected results.
        /// </para>
        /// </remarks>
        public static WaveFile Combine(WaveFile[] waveFiles, double[] volumes)
        {
            if (waveFiles.Length > 1)
            {
                // Validate volumes
                if (volumes.Length != waveFiles.Length)
                    throw new ArgumentOutOfRangeException("volumes", "There must be one volume per each wave file");

                if (volumes.Sum() > 1.0D)
                    throw new ArgumentOutOfRangeException("volumes", "Cumulatively, volumes cannot exceed 1.0");

                // Deep clone first wave file - this will become the base of the new combined wave file
                WaveFile next, source = waveFiles[0].Clone();
                int maxLength, nextLength, sourceLength = source.SampleBlocks.Count;

                // Validate compatibility of wave files to be combined
                for (int x = 1; x < waveFiles.Length; x++)
                {
                    next = waveFiles[x];

                    if (source.AudioFormat != next.AudioFormat ||
                        source.SampleRate != next.SampleRate ||
                        source.BitsPerSample != next.BitsPerSample ||
                        source.Channels != next.Channels)
                        throw new ArgumentException("All wave files to be combined must have the same audio format, sample rate, bits per sample and number of channels");
                }

                // Apply volume adjustment to source file
                for (int x = 0; x < sourceLength; x++)
                {
                    for (int y = 0; y < source.Channels; y++)
                    {
                        // Apply volume adjustment to source
                        source.SampleBlocks[x][y] = CombineBinarySamples(source.BitsPerSample, 0, source.SampleBlocks[x][y], volumes[0]);
                    }
                }

                // Combine subsequent wave files
                for (int x = 1; x < waveFiles.Length; x++)
                {
                    next = waveFiles[x];
                    nextLength = next.SampleBlocks.Count;
                    maxLength = sourceLength > nextLength ? sourceLength : nextLength;

                    for (int y = 0; y < maxLength; y++)
                    {
                        if (y < sourceLength && y < nextLength)
                        {
                            for (int z = 0; z < source.Channels; z++)
                            {
                                // Combine each data channel from the source and current wave files
                                source.SampleBlocks[y][z] = CombineBinarySamples(source.BitsPerSample, source.SampleBlocks[y][z], next.SampleBlocks[y][z], volumes[x]);
                            }
                        }
                        else
                        {
                            // Extend source if necessary - note that extended samples still need to be equalized
                            if (nextLength > sourceLength)
                            {
                                LittleBinaryValue[] samples = new LittleBinaryValue[source.Channels];

                                for (int z = 0; z < source.Channels; z++)
                                {
                                    // Combine extended samples with "0" from source to maintain amplitude equalization
                                    samples[z] = CombineBinarySamples(source.BitsPerSample, 0, next.SampleBlocks[y][z], volumes[x]);
                                }

                                source.SampleBlocks.Add(samples);
                            }
                            else
                                break;
                        }
                    }
                }

                return source;
            }
            else
                throw new ArgumentException("You must provide at least two wave files to combine.", "waveFiles");
        }

        /// <summary>
        /// Appends wave files together, one after another, into a single file.
        /// </summary>
        /// <param name="waveFiles">Wave files to append</param>
        /// <returns>Combined wave files.</returns>
        /// <remarks>Each resulting wave file is appending behind the next.</remarks>
        public static WaveFile Append(params WaveFile[] waveFiles)
        {
            if (waveFiles.Length > 1)
            {
                // Deep clone first wave file - this will become the base of the new combined wave file
                WaveFile next, source = waveFiles[0].Clone();

                // Validate compatibility of wave files to be combined
                for (int x = 1; x < waveFiles.Length; x++)
                {
                    next = waveFiles[x];

                    if (source.AudioFormat != next.AudioFormat ||
                        source.SampleRate != next.SampleRate ||
                        source.BitsPerSample != next.BitsPerSample ||
                        source.Channels != next.Channels)
                        throw new ArgumentException("All wave files to be appended together must have the same audio format, sample rate, bits per sample and number of channels");
                }

                // Combine subsequent wave files
                for (int x = 1; x < waveFiles.Length; x++)
                {
                    next = waveFiles[x];

                    for (int y = 0; y < next.SampleBlocks.Count; y++)
                    {
                        // Extend source with next wave file's data
                        source.SampleBlocks.Add(CloneSampleBlock(next.SampleBlocks[y]));
                    }
                }

                return source;
            }
            else
                throw new ArgumentException("You must provide at least two wave files to append together.", "waveFiles");
        }

        /// <summary>
        /// Performs a deep clone of all the channel samples in a sample block.
        /// </summary>
        /// <param name="samples">Sample block to clone.</param>
        /// <returns>A deep clone of all the channel samples in a sample block.</returns>
        public static LittleBinaryValue[] CloneSampleBlock(LittleBinaryValue[] samples)
        {
            LittleBinaryValue[] clonedSamples = new LittleBinaryValue[samples.Length];
            byte[] copiedBytes;

            // Perform a deep clone of source samples
            for (int x = 0; x < samples.Length; x++)
            {
                copiedBytes = new byte[samples[x].Buffer.Length];
                Buffer.BlockCopy(samples[x].Buffer, 0, copiedBytes, 0, copiedBytes.Length);
                clonedSamples[x] = new LittleBinaryValue(samples[x].TypeCode, copiedBytes);
            }

            return clonedSamples;
        }

        // Data type independent binary sample combination
        private static LittleBinaryValue CombineBinarySamples(int bitsPerSample, LittleBinaryValue value1, LittleBinaryValue value2, double value2Volume)
        {
            // Algorithm:
            //      1) Convert value into double data type to prevent arithmetic overflow. Note that you
            //         cannot directly cast to a double as there are only enough bytes in the binary
            //         value to cast it to its native data type.
            //      2) Add both data samples together, appling volume adjustment to second value to make
            //         sure values get desired amplitude weight so as to not adversely affect the volume
            //         of the resultant sample.
            //      3) Convert arithmetic result back to proper data type for wave file and return.

            LittleBinaryValue result;

            // Must handle 24-bit as a special case since there is no 24-bit type code in .NET
            if (bitsPerSample == 24)
            {
                Int24 _value1 = value1;
                Int24 _value2 = value1;

                result = (double)_value1 + (double)_value2 * value2Volume;
            }
            else
            {
                result =
                    (double)value1.ConvertToType(TypeCode.Double) +
                    (double)value2.ConvertToType(TypeCode.Double) * value2Volume;
            }

            return result.ConvertToType(value1.TypeCode);
        }

        #endregion
    }
}
