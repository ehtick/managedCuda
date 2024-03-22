// Copyright (c) 2023, Michael Kunz and Artic Imaging SARL. All rights reserved.
// http://kunzmi.github.io/managedCuda
//
// This file is part of ManagedCuda.
//
// Commercial License Usage
//  Licensees holding valid commercial ManagedCuda licenses may use this
//  file in accordance with the commercial license agreement provided with
//  the Software or, alternatively, in accordance with the terms contained
//  in a written agreement between you and Artic Imaging SARL. For further
//  information contact us at managedcuda@articimaging.eu.
//  
// GNU General Public License Usage
//  Alternatively, this file may be used under the terms of the GNU General
//  Public License as published by the Free Software Foundation, either 
//  version 3 of the License, or (at your option) any later version.
//  
//  ManagedCuda is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//  
//  You should have received a copy of the GNU General Public License
//  along with this program. If not, see <http://www.gnu.org/licenses/>.


#define ADD_MISSING_CTX
using System;
using System.Diagnostics;
using ManagedCuda.BasicTypes;

namespace ManagedCuda.NPP
{
    /// <summary>
    /// 
    /// </summary>
    public partial class NPPImage_32sC4 : NPPImageBase
    {
        #region Copy
        /// <summary>
        /// Image copy.
        /// </summary>
        /// <param name="dst">Destination image</param>
        /// <param name="channel">Channel number. This number is added to the dst pointer</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void Copy(NPPImage_32sC1 dst, int channel, NppStreamContext nppStreamCtx)
        {
            if (channel < 0 | channel >= _channels) throw new ArgumentOutOfRangeException("channel", "channel must be in range [0..3].");
            status = NPPNativeMethods_Ctx.NPPi.MemCopy.nppiCopy_32s_C4C1R_Ctx(_devPtrRoi + channel * _typeSize, _pitch, dst.DevicePointerRoi, dst.Pitch, _sizeRoi, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiCopy_32s_C4C1R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }

        /// <summary>
        /// Image copy.
        /// </summary>
        /// <param name="dst">Destination image</param>
        /// <param name="channelSrc">Channel number. This number is added to the src pointer</param>
        /// <param name="channelDst">Channel number. This number is added to the dst pointer</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void Copy(NPPImage_32sC4 dst, int channelSrc, int channelDst, NppStreamContext nppStreamCtx)
        {
            if (channelSrc < 0 | channelSrc >= _channels) throw new ArgumentOutOfRangeException("channelSrc", "channelSrc must be in range [0..2].");
            if (channelDst < 0 | channelDst >= dst.Channels) throw new ArgumentOutOfRangeException("channelDst", "channelDst must be in range [0..2].");
            status = NPPNativeMethods_Ctx.NPPi.MemCopy.nppiCopy_32s_C4CR_Ctx(_devPtrRoi + channelSrc * _typeSize, _pitch, dst.DevicePointerRoi + channelDst * _typeSize, dst.Pitch, _sizeRoi, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiCopy_32s_C4CR_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }

        /// <summary>
        /// Masked Operation 8-bit unsigned image copy.
        /// </summary>
        /// <param name="dst">Destination image</param>
        /// <param name="mask">Mask image</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void Copy(NPPImage_32sC4 dst, NPPImage_8uC1 mask, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.MemCopy.nppiCopy_32s_C4MR_Ctx(_devPtrRoi, _pitch, dst.DevicePointerRoi, dst.Pitch, _sizeRoi, mask.DevicePointerRoi, mask.Pitch, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiCopy_32s_C4MR_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }

        /// <summary>
        /// Masked Operation 8-bit unsigned image copy. Not affecting Alpha channel.
        /// </summary>
        /// <param name="dst">Destination image</param>
        /// <param name="mask">Mask image</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void CopyA(NPPImage_32sC4 dst, NPPImage_8uC1 mask, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.MemCopy.nppiCopy_32s_AC4MR_Ctx(_devPtrRoi, _pitch, dst.DevicePointerRoi, dst.Pitch, _sizeRoi, mask.DevicePointerRoi, mask.Pitch, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiCopy_32s_AC4MR_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }

        /// <summary>
        /// Image copy.
        /// </summary>
        /// <param name="dst">Destination image</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void Copy(NPPImage_32sC4 dst, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.MemCopy.nppiCopy_32s_C4R_Ctx(_devPtrRoi, _pitch, dst.DevicePointerRoi, dst.Pitch, _sizeRoi, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiCopy_32s_C4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }

        /// <summary>
        /// Image copy. Not affecting Alpha channel.
        /// </summary>
        /// <param name="dst">Destination image</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void CopyA(NPPImage_32sC4 dst, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.MemCopy.nppiCopy_32s_AC4R_Ctx(_devPtrRoi, _pitch, dst.DevicePointerRoi, dst.Pitch, _sizeRoi, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiCopy_32s_AC4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }

        /// <summary>
        /// Three-channel 8-bit unsigned packed to planar image copy.
        /// </summary>
        /// <param name="dst0">Destination image channel 0</param>
        /// <param name="dst1">Destination image channel 1</param>
        /// <param name="dst2">Destination image channel 2</param>
        /// <param name="dst3">Destination image channel 3</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void Copy(NPPImage_32sC1 dst0, NPPImage_32sC1 dst1, NPPImage_32sC1 dst2, NPPImage_32sC1 dst3, NppStreamContext nppStreamCtx)
        {
            CUdeviceptr[] array = new CUdeviceptr[] { dst0.DevicePointerRoi, dst1.DevicePointerRoi, dst2.DevicePointerRoi, dst3.DevicePointerRoi };
            status = NPPNativeMethods_Ctx.NPPi.MemCopy.nppiCopy_32s_C4P4R_Ctx(_devPtrRoi, _pitch, array, dst0.Pitch, _sizeRoi, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiCopy_32s_C4P4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }

        /// <summary>
        /// Three-channel 8-bit unsigned planar to packed image copy.
        /// </summary>
        /// <param name="src0">Source image channel 0</param>
        /// <param name="src1">Source image channel 1</param>
        /// <param name="src2">Source image channel 2</param>
        /// <param name="src3">Source image channel 2</param>
        /// <param name="dest">Destination image</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public static void Copy(NPPImage_32sC1 src0, NPPImage_32sC1 src1, NPPImage_32sC1 src2, NPPImage_32sC1 src3, NPPImage_32sC4 dest, NppStreamContext nppStreamCtx)
        {
            CUdeviceptr[] array = new CUdeviceptr[] { src0.DevicePointerRoi, src1.DevicePointerRoi, src2.DevicePointerRoi, src3.DevicePointerRoi };
            NppStatus status = NPPNativeMethods_Ctx.NPPi.MemCopy.nppiCopy_32s_P4C4R_Ctx(array, src0.Pitch, dest.DevicePointerRoi, dest.Pitch, dest.SizeRoi, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiCopy_32s_P4C4R_Ctx", status));
            NPPException.CheckNppStatus(status, null);
        }
        #endregion

        #region Convert
        /// <summary>
        /// 32-bit signed to 8-bit unsigned conversion.
        /// </summary>
        /// <param name="dst">Destination image</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void Convert(NPPImage_8uC4 dst, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.BitDepthConversion.nppiConvert_32s8u_C4R_Ctx(_devPtrRoi, _pitch, dst.DevicePointerRoi, dst.Pitch, _sizeRoi, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiConvert_32s8u_C4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }
        /// <summary>
        /// 32-bit signed to 8-bit signed conversion.
        /// </summary>
        /// <param name="dst">Destination image</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void Convert(NPPImage_8sC4 dst, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.BitDepthConversion.nppiConvert_32s8s_C4R_Ctx(_devPtrRoi, _pitch, dst.DevicePointerRoi, dst.Pitch, _sizeRoi, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiConvert_32s8s_C4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }
        /// <summary>
        /// 32-bit signed to 8-bit unsigned conversion. Not affecting Alpha
        /// </summary>
        /// <param name="dst">Destination image</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void ConvertA(NPPImage_8uC4 dst, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.BitDepthConversion.nppiConvert_32s8u_AC4R_Ctx(_devPtrRoi, _pitch, dst.DevicePointerRoi, dst.Pitch, _sizeRoi, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiConvert_32s8u_AC4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }
        /// <summary>
        /// 32-bit signed to 8-bit signed conversion. Not affecting Alpha
        /// </summary>
        /// <param name="dst">Destination image</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void ConvertA(NPPImage_8sC4 dst, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.BitDepthConversion.nppiConvert_32s8s_AC4R_Ctx(_devPtrRoi, _pitch, dst.DevicePointerRoi, dst.Pitch, _sizeRoi, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiConvert_32s8s_AC4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }
        #endregion

        #region Set
        /// <summary>
        /// Set pixel values to nValue.
        /// </summary>
        /// <param name="nValue">Value to be set (Array size = 4)</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void Set(int[] nValue, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.MemSet.nppiSet_32s_C4R_Ctx(nValue, _devPtrRoi, _pitch, _sizeRoi, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiSet_32s_C4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }

        /// <summary>
        /// Set pixel values to nValue. <para/>
        /// The 8-bit mask image affects setting of the respective pixels in the destination image. <para/>
        /// If the mask value is zero (0) the pixel is not set, if the mask is non-zero, the corresponding
        /// destination pixel is set to specified value.
        /// </summary>
        /// <param name="nValue">Value to be set (Array size = 4)</param>
        /// <param name="mask">Mask image</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void Set(int[] nValue, NPPImage_8uC1 mask, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.MemSet.nppiSet_32s_C4MR_Ctx(nValue, _devPtrRoi, _pitch, _sizeRoi, mask.DevicePointerRoi, mask.Pitch, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiSet_32s_C4MR_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }

        /// <summary>
        /// Set pixel values to nValue. <para/>
        /// The 8-bit mask image affects setting of the respective pixels in the destination image. <para/>
        /// If the mask value is zero (0) the pixel is not set, if the mask is non-zero, the corresponding
        /// destination pixel is set to specified value.
        /// </summary>
        /// <param name="nValue">Value to be set</param>
        /// <param name="channel">Channel number. This number is added to the dst pointer</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void Set(int nValue, int channel, NppStreamContext nppStreamCtx)
        {
            if (channel < 0 | channel >= _channels) throw new ArgumentOutOfRangeException("channel", "channel must be in range [0..3].");
            status = NPPNativeMethods_Ctx.NPPi.MemSet.nppiSet_32s_C4CR_Ctx(nValue, _devPtrRoi + channel * _typeSize, _pitch, _sizeRoi, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiSet_32s_C4CR_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }

        /// <summary>
        /// Set pixel values to nValue. <para/>
        /// The 8-bit mask image affects setting of the respective pixels in the destination image. <para/>
        /// If the mask value is zero (0) the pixel is not set, if the mask is non-zero, the corresponding
        /// destination pixel is set to specified value. Not affecting alpha channel.
        /// </summary>
        /// <param name="nValue">Value to be set (Array size = 3)</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void SetA(int[] nValue, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.MemSet.nppiSet_32s_AC4R_Ctx(nValue, _devPtrRoi, _pitch, _sizeRoi, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiSet_32s_AC4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }

        /// <summary>
        /// Set pixel values to nValue. <para/>
        /// The 8-bit mask image affects setting of the respective pixels in the destination image. <para/>
        /// If the mask value is zero (0) the pixel is not set, if the mask is non-zero, the corresponding
        /// destination pixel is set to specified value. Not affecting alpha channel.
        /// </summary>
        /// <param name="nValue">Value to be set (Array size = 3)</param>
        /// <param name="mask">Mask image</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void SetA(int[] nValue, NPPImage_8uC1 mask, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.MemSet.nppiSet_32s_AC4MR_Ctx(nValue, _devPtrRoi, _pitch, _sizeRoi, mask.DevicePointerRoi, mask.Pitch, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiSet_32s_AC4MR_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }
        #endregion

        #region Add
        ///// <summary>
        ///// Image addition, scale by 2^(-nScaleFactor), then clamp to saturated value.
        ///// </summary>
        ///// <param name="src2">2nd source image</param>
        ///// <param name="dest">Destination image</param>
        ///// <param name="nScaleFactor">scaling factor</param>
        //public void Add(NPPImage_32sC4 src2, NPPImage_32sC4 dest, int nScaleFactor)
        //{
        //	status = NPPNativeMethods_Ctx.NPPi.Add.nppiAdd_32s_C4RSfs_Ctx(_devPtrRoi, _pitch, src2.DevicePointerRoi, src2.Pitch, dest.DevicePointerRoi, dest.Pitch, _sizeRoi, nScaleFactor, nppStreamCtx);
        //	Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiAdd_32s_C4RSfs_Ctx", status));
        //	NPPException.CheckNppStatus(status, this);
        //}
        ///// <summary>
        ///// In place image addition, scale by 2^(-nScaleFactor), then clamp to saturated value.
        ///// </summary>
        ///// <param name="src2">2nd source image</param>
        ///// <param name="nScaleFactor">scaling factor</param>
        //public void Add(NPPImage_32sC4 src2, int nScaleFactor)
        //{
        //	status = NPPNativeMethods_Ctx.NPPi.Add.nppiAdd_32s_C4IRSfs_Ctx(src2.DevicePointerRoi, src2.Pitch, _devPtrRoi, _pitch, _sizeRoi, nScaleFactor, nppStreamCtx);
        //	Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiAdd_32s_C4IRSfs_Ctx", status));
        //	NPPException.CheckNppStatus(status, this);
        //}

        ///// <summary>
        ///// Add constant to image, scale by 2^(-nScaleFactor), then clamp to saturated value.
        ///// </summary>
        ///// <param name="nConstant">Values to add</param>
        ///// <param name="dest">Destination image</param>
        ///// <param name="nScaleFactor">scaling factor</param>
        //public void Add(int[] nConstant, NPPImage_32sC4 dest, int nScaleFactor)
        //{
        //	status = NPPNativeMethods_Ctx.NPPi.AddConst.nppiAddC_32s_C4RSfs_Ctx(_devPtrRoi, _pitch, nConstant, dest.DevicePointerRoi, dest.Pitch, _sizeRoi, nScaleFactor, nppStreamCtx);
        //	Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiAddC_32s_C4RSfs_Ctx", status));
        //	NPPException.CheckNppStatus(status, this);
        //}
        ///// <summary>
        ///// Add constant to image, scale by 2^(-nScaleFactor), then clamp to saturated value. Inplace.
        ///// </summary>
        ///// <param name="nConstant">Values to add</param>
        ///// <param name="nScaleFactor">scaling factor</param>
        //public void Add(int[] nConstant, int nScaleFactor)
        //{
        //	status = NPPNativeMethods_Ctx.NPPi.AddConst.nppiAddC_32s_C4IRSfs_Ctx(nConstant, _devPtrRoi, _pitch, _sizeRoi, nScaleFactor, nppStreamCtx);
        //	Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiAddC_32s_C4IRSfs_Ctx", status));
        //	NPPException.CheckNppStatus(status, this);
        //}

        ///// <summary>
        ///// Image addition, scale by 2^(-nScaleFactor), then clamp to saturated value. Unmodified Alpha.
        ///// </summary>
        ///// <param name="src2">2nd source image</param>
        ///// <param name="dest">Destination image</param>
        ///// <param name="nScaleFactor">scaling factor</param>
        //public void AddA(NPPImage_32sC4 src2, NPPImage_32sC4 dest, int nScaleFactor)
        //{
        //	status = NPPNativeMethods_Ctx.NPPi.Add.nppiAdd_32s_AC4RSfs_Ctx(_devPtrRoi, _pitch, src2.DevicePointerRoi, src2.Pitch, dest.DevicePointerRoi, dest.Pitch, _sizeRoi, nScaleFactor, nppStreamCtx);
        //	Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiAdd_32s_AC4RSfs_Ctx", status));
        //	NPPException.CheckNppStatus(status, this);
        //}
        ///// <summary>
        ///// In place image addition, scale by 2^(-nScaleFactor), then clamp to saturated value. Unmodified Alpha.
        ///// </summary>
        ///// <param name="src2">2nd source image</param>
        ///// <param name="nScaleFactor">scaling factor</param>
        //public void AddA(NPPImage_32sC4 src2, int nScaleFactor)
        //{
        //	status = NPPNativeMethods_Ctx.NPPi.Add.nppiAdd_32s_AC4IRSfs_Ctx(src2.DevicePointerRoi, src2.Pitch, _devPtrRoi, _pitch, _sizeRoi, nScaleFactor, nppStreamCtx);
        //	Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiAdd_32s_AC4IRSfs_Ctx", status));
        //	NPPException.CheckNppStatus(status, this);
        //}

        ///// <summary>
        ///// Add constant to image, scale by 2^(-nScaleFactor), then clamp to saturated value. Unmodified Alpha.
        ///// </summary>
        ///// <param name="nConstant">Values to add</param>
        ///// <param name="dest">Destination image</param>
        ///// <param name="nScaleFactor">scaling factor</param>
        //public void AddA(int[] nConstant, NPPImage_32sC4 dest, int nScaleFactor)
        //{
        //	status = NPPNativeMethods_Ctx.NPPi.AddConst.nppiAddC_32s_AC4RSfs_Ctx(_devPtrRoi, _pitch, nConstant, dest.DevicePointerRoi, dest.Pitch, _sizeRoi, nScaleFactor, nppStreamCtx);
        //	Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiAddC_32s_AC4RSfs_Ctx", status));
        //	NPPException.CheckNppStatus(status, this);
        //}
        ///// <summary>
        ///// Add constant to image, scale by 2^(-nScaleFactor), then clamp to saturated value. Inplace. Unmodified Alpha.
        ///// </summary>
        ///// <param name="nConstant">Values to add</param>
        ///// <param name="nScaleFactor">scaling factor</param>
        //public void AddA(int[] nConstant, int nScaleFactor)
        //{
        //	status = NPPNativeMethods_Ctx.NPPi.AddConst.nppiAddC_32s_AC4IRSfs_Ctx(nConstant, _devPtrRoi, _pitch, _sizeRoi, nScaleFactor, nppStreamCtx);
        //	Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiAddC_32s_AC4IRSfs_Ctx", status));
        //	NPPException.CheckNppStatus(status, this);
        //}
        #endregion

        #region Logical
        /// <summary>
        /// image bit shift by constant (left).
        /// </summary>
        /// <param name="nConstant">Constant (Array length = 4)</param>
        /// <param name="dest">Destination image</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void LShiftC(uint[] nConstant, NPPImage_32sC4 dest, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.LeftShiftConst.nppiLShiftC_32s_C4R_Ctx(_devPtrRoi, _pitch, nConstant, dest.DevicePointerRoi, dest.Pitch, _sizeRoi, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiLShiftC_32s_C4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }
        /// <summary>
        /// image bit shift by constant (left), inplace.
        /// </summary>
        /// <param name="nConstant">Constant (Array length = 4)</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void LShiftC(uint[] nConstant, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.LeftShiftConst.nppiLShiftC_32s_C4IR_Ctx(nConstant, _devPtrRoi, _pitch, _sizeRoi, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiLShiftC_32s_C4IR_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }
        /// <summary>
        /// image bit shift by constant (left). Unchanged Alpha.
        /// </summary>
        /// <param name="nConstant">Constant (Array length = 4)</param>
        /// <param name="dest">Destination image</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void LShiftCA(uint[] nConstant, NPPImage_32sC4 dest, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.LeftShiftConst.nppiLShiftC_32s_AC4R_Ctx(_devPtrRoi, _pitch, nConstant, dest.DevicePointerRoi, dest.Pitch, _sizeRoi, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiLShiftC_32s_AC4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }
        /// <summary>
        /// image bit shift by constant (left), inplace. Unchanged Alpha.
        /// </summary>
        /// <param name="nConstant">Constant (Array length = 4)</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void LShiftCA(uint[] nConstant, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.LeftShiftConst.nppiLShiftC_32s_AC4IR_Ctx(nConstant, _devPtrRoi, _pitch, _sizeRoi, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiLShiftC_32s_AC4IR_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }

        /// <summary>
        /// image bit shift by constant (right).
        /// </summary>
        /// <param name="nConstant">Constant (Array length = 4)</param>
        /// <param name="dest">Destination image</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void RShiftC(uint[] nConstant, NPPImage_32sC4 dest, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.RightShiftConst.nppiRShiftC_32s_C4R_Ctx(_devPtrRoi, _pitch, nConstant, dest.DevicePointerRoi, dest.Pitch, _sizeRoi, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiRShiftC_32s_C4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }
        /// <summary>
        /// image bit shift by constant (right), inplace.
        /// </summary>
        /// <param name="nConstant">Constant (Array length = 4)</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void RShiftC(uint[] nConstant, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.RightShiftConst.nppiRShiftC_32s_C4IR_Ctx(nConstant, _devPtrRoi, _pitch, _sizeRoi, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiRShiftC_32s_C4IR_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }
        /// <summary>
        /// image bit shift by constant (right). Unchanged Alpha.
        /// </summary>
        /// <param name="nConstant">Constant (Array length = 4)</param>
        /// <param name="dest">Destination image</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void RShiftCA(uint[] nConstant, NPPImage_32sC4 dest, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.RightShiftConst.nppiRShiftC_32s_AC4R_Ctx(_devPtrRoi, _pitch, nConstant, dest.DevicePointerRoi, dest.Pitch, _sizeRoi, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiRShiftC_32s_AC4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }
        /// <summary>
        /// image bit shift by constant (right), inplace. Unchanged Alpha.
        /// </summary>
        /// <param name="nConstant">Constant (Array length = 4)</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void RShiftCA(uint[] nConstant, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.RightShiftConst.nppiRShiftC_32s_AC4IR_Ctx(nConstant, _devPtrRoi, _pitch, _sizeRoi, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiRShiftC_32s_AC4IR_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }

        /// <summary>
        /// Image logical and.
        /// </summary>
        /// <param name="src2">2nd source image</param>
        /// <param name="dest">Destination image</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void And(NPPImage_32sC4 src2, NPPImage_32sC4 dest, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.And.nppiAnd_32s_C4R_Ctx(_devPtrRoi, _pitch, src2.DevicePointerRoi, src2.Pitch, dest.DevicePointerRoi, dest.Pitch, _sizeRoi, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiAnd_32s_C4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }
        /// <summary>
        /// In place image logical and.
        /// </summary>
        /// <param name="src2">2nd source image</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void And(NPPImage_32sC4 src2, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.And.nppiAnd_32s_C4IR_Ctx(src2.DevicePointerRoi, src2.Pitch, _devPtrRoi, _pitch, _sizeRoi, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiAnd_32s_C4IR_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }

        /// <summary>
        /// Image logical and with constant.
        /// </summary>
        /// <param name="nConstant">Value (Array length = 4)</param>
        /// <param name="dest">Destination image</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void And(int[] nConstant, NPPImage_32sC4 dest, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.AndConst.nppiAndC_32s_C4R_Ctx(_devPtrRoi, _pitch, nConstant, dest.DevicePointerRoi, dest.Pitch, _sizeRoi, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiAndC_32s_C4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }
        /// <summary>
        /// In place image logical and with constant.
        /// </summary>
        /// <param name="nConstant">Value (Array length = 4)</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void And(int[] nConstant, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.AndConst.nppiAndC_32s_C4IR_Ctx(nConstant, _devPtrRoi, _pitch, _sizeRoi, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiAndC_32s_C4IR_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }

        /// <summary>
        /// Image logical and. Unchanged Alpha.
        /// </summary>
        /// <param name="src2">2nd source image</param>
        /// <param name="dest">Destination image</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void AndA(NPPImage_32sC4 src2, NPPImage_32sC4 dest, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.And.nppiAnd_32s_AC4R_Ctx(_devPtrRoi, _pitch, src2.DevicePointerRoi, src2.Pitch, dest.DevicePointerRoi, dest.Pitch, _sizeRoi, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiAnd_32s_AC4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }
        /// <summary>
        /// In place image logical and. Unchanged Alpha.
        /// </summary>
        /// <param name="src2">2nd source image</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void AndA(NPPImage_32sC4 src2, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.And.nppiAnd_32s_AC4IR_Ctx(src2.DevicePointerRoi, src2.Pitch, _devPtrRoi, _pitch, _sizeRoi, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiAnd_32s_AC4IR_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }

        /// <summary>
        /// Image logical and with constant. Unchanged Alpha.
        /// </summary>
        /// <param name="nConstant">Value (Array length = 4)</param>
        /// <param name="dest">Destination image</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void AndA(int[] nConstant, NPPImage_32sC4 dest, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.AndConst.nppiAndC_32s_AC4R_Ctx(_devPtrRoi, _pitch, nConstant, dest.DevicePointerRoi, dest.Pitch, _sizeRoi, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiAndC_32s_AC4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }
        /// <summary>
        /// In place image logical and with constant. Unchanged Alpha.
        /// </summary>
        /// <param name="nConstant">Value (Array length = 4)</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void AndA(int[] nConstant, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.AndConst.nppiAndC_32s_AC4IR_Ctx(nConstant, _devPtrRoi, _pitch, _sizeRoi, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiAndC_32s_AC4IR_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }

        /// <summary>
        /// Image logical Or.
        /// </summary>
        /// <param name="src2">2nd source image</param>
        /// <param name="dest">Destination image</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void Or(NPPImage_32sC4 src2, NPPImage_32sC4 dest, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.Or.nppiOr_32s_C4R_Ctx(_devPtrRoi, _pitch, src2.DevicePointerRoi, src2.Pitch, dest.DevicePointerRoi, dest.Pitch, _sizeRoi, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiOr_32s_C4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }
        /// <summary>
        /// In place image logical Or.
        /// </summary>
        /// <param name="src2">2nd source image</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void Or(NPPImage_32sC4 src2, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.Or.nppiOr_32s_C4IR_Ctx(src2.DevicePointerRoi, src2.Pitch, _devPtrRoi, _pitch, _sizeRoi, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiOr_32s_C4IR_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }

        /// <summary>
        /// Image logical Or with constant.
        /// </summary>
        /// <param name="nConstant">Value (Array length = 4)</param>
        /// <param name="dest">Destination image</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void Or(int[] nConstant, NPPImage_32sC4 dest, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.OrConst.nppiOrC_32s_C4R_Ctx(_devPtrRoi, _pitch, nConstant, dest.DevicePointerRoi, dest.Pitch, _sizeRoi, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiOrC_32s_C4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }
        /// <summary>
        /// In place image logical Or with constant.
        /// </summary>
        /// <param name="nConstant">Value (Array length = 4)</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void Or(int[] nConstant, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.OrConst.nppiOrC_32s_C4IR_Ctx(nConstant, _devPtrRoi, _pitch, _sizeRoi, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiOrC_32s_C4IR_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }

        /// <summary>
        /// Image logical Or. Unchanged Alpha.
        /// </summary>
        /// <param name="src2">2nd source image</param>
        /// <param name="dest">Destination image</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void OrA(NPPImage_32sC4 src2, NPPImage_32sC4 dest, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.Or.nppiOr_32s_AC4R_Ctx(_devPtrRoi, _pitch, src2.DevicePointerRoi, src2.Pitch, dest.DevicePointerRoi, dest.Pitch, _sizeRoi, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiOr_32s_AC4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }
        /// <summary>
        /// In place image logical Or. Unchanged Alpha.
        /// </summary>
        /// <param name="src2">2nd source image</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void OrA(NPPImage_32sC4 src2, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.Or.nppiOr_32s_AC4IR_Ctx(src2.DevicePointerRoi, src2.Pitch, _devPtrRoi, _pitch, _sizeRoi, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiOr_32s_AC4IR_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }

        /// <summary>
        /// Image logical Or with constant. Unchanged Alpha.
        /// </summary>
        /// <param name="nConstant">Value (Array length = 4)</param>
        /// <param name="dest">Destination image</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void OrA(int[] nConstant, NPPImage_32sC4 dest, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.OrConst.nppiOrC_32s_AC4R_Ctx(_devPtrRoi, _pitch, nConstant, dest.DevicePointerRoi, dest.Pitch, _sizeRoi, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiOrC_32s_AC4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }
        /// <summary>
        /// In place image logical Or with constant. Unchanged Alpha.
        /// </summary>
        /// <param name="nConstant">Value (Array length = 4)</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void OrA(int[] nConstant, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.OrConst.nppiOrC_32s_AC4IR_Ctx(nConstant, _devPtrRoi, _pitch, _sizeRoi, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiOrC_32s_AC4IR_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }

        /// <summary>
        /// Image logical Xor.
        /// </summary>
        /// <param name="src2">2nd source image</param>
        /// <param name="dest">Destination image</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void Xor(NPPImage_32sC4 src2, NPPImage_32sC4 dest, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.Xor.nppiXor_32s_C4R_Ctx(_devPtrRoi, _pitch, src2.DevicePointerRoi, src2.Pitch, dest.DevicePointerRoi, dest.Pitch, _sizeRoi, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiXor_32s_C4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }
        /// <summary>
        /// In place image logical Xor.
        /// </summary>
        /// <param name="src2">2nd source image</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void Xor(NPPImage_32sC4 src2, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.Xor.nppiXor_32s_C4IR_Ctx(src2.DevicePointerRoi, src2.Pitch, _devPtrRoi, _pitch, _sizeRoi, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiXor_32s_C4IR_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }

        /// <summary>
        /// Image logical Xor with constant.
        /// </summary>
        /// <param name="nConstant">Value (Array length = 4)</param>
        /// <param name="dest">Destination image</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void Xor(int[] nConstant, NPPImage_32sC4 dest, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.XorConst.nppiXorC_32s_C4R_Ctx(_devPtrRoi, _pitch, nConstant, dest.DevicePointerRoi, dest.Pitch, _sizeRoi, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiXorC_32s_C4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }
        /// <summary>
        /// In place image logical Xor with constant.
        /// </summary>
        /// <param name="nConstant">Value (Array length = 4)</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void Xor(int[] nConstant, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.XorConst.nppiXorC_32s_C4IR_Ctx(nConstant, _devPtrRoi, _pitch, _sizeRoi, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiXorC_32s_C4IR_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }

        /// <summary>
        /// Image logical Xor. Unchanged Alpha.
        /// </summary>
        /// <param name="src2">2nd source image</param>
        /// <param name="dest">Destination image</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void XorA(NPPImage_32sC4 src2, NPPImage_32sC4 dest, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.Xor.nppiXor_32s_AC4R_Ctx(_devPtrRoi, _pitch, src2.DevicePointerRoi, src2.Pitch, dest.DevicePointerRoi, dest.Pitch, _sizeRoi, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiXor_32s_AC4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }
        /// <summary>
        /// In place image logical Xor. Unchanged Alpha.
        /// </summary>
        /// <param name="src2">2nd source image</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void XorA(NPPImage_32sC4 src2, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.Xor.nppiXor_32s_AC4IR_Ctx(src2.DevicePointerRoi, src2.Pitch, _devPtrRoi, _pitch, _sizeRoi, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiXor_32s_AC4IR_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }

        /// <summary>
        /// Image logical Xor with constant. Unchanged Alpha.
        /// </summary>
        /// <param name="nConstant">Value (Array length = 4)</param>
        /// <param name="dest">Destination image</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void XorA(int[] nConstant, NPPImage_32sC4 dest, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.XorConst.nppiXorC_32s_AC4R_Ctx(_devPtrRoi, _pitch, nConstant, dest.DevicePointerRoi, dest.Pitch, _sizeRoi, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiXorC_32s_AC4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }
        /// <summary>
        /// In place image logical Xor with constant. Unchanged Alpha.
        /// </summary>
        /// <param name="nConstant">Value (Array length = 4)</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void XorA(int[] nConstant, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.XorConst.nppiXorC_32s_AC4IR_Ctx(nConstant, _devPtrRoi, _pitch, _sizeRoi, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiXorC_32s_AC4IR_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }
        #endregion

        #region Sub
        /// <summary>
        /// Image subtraction, scale by 2^(-nScaleFactor), then clamp to saturated value.
        /// </summary>
        /// <param name="src2">2nd source image</param>
        /// <param name="dest">Destination image</param>
        /// <param name="nScaleFactor">scaling factor</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void Sub(NPPImage_32sC4 src2, NPPImage_32sC4 dest, int nScaleFactor, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.Sub.nppiSub_32s_C4RSfs_Ctx(_devPtrRoi, _pitch, src2.DevicePointerRoi, src2.Pitch, dest.DevicePointerRoi, dest.Pitch, _sizeRoi, nScaleFactor, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiSub_32s_C4RSfs_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }
        /// <summary>
        /// In place image subtraction, scale by 2^(-nScaleFactor), then clamp to saturated value.
        /// </summary>
        /// <param name="src2">2nd source image</param>
        /// <param name="nScaleFactor">scaling factor</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void Sub(NPPImage_32sC4 src2, int nScaleFactor, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.Sub.nppiSub_32s_C4IRSfs_Ctx(src2.DevicePointerRoi, src2.Pitch, _devPtrRoi, _pitch, _sizeRoi, nScaleFactor, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiSub_32s_C4IRSfs_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }

        ///// <summary>
        ///// Subtract constant to image, scale by 2^(-nScaleFactor), then clamp to saturated value.
        ///// </summary>
        ///// <param name="nConstant">Value to subtract</param>
        ///// <param name="dest">Destination image</param>
        ///// <param name="nScaleFactor">scaling factor</param>
        //public void Sub(int[] nConstant, NPPImage_32sC4 dest, int nScaleFactor)
        //{
        //	status = NPPNativeMethods_Ctx.NPPi.SubConst.nppiSubC_32s_C4RSfs_Ctx(_devPtrRoi, _pitch, nConstant, dest.DevicePointerRoi, dest.Pitch, _sizeRoi, nScaleFactor, nppStreamCtx);
        //	Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiSubC_32s_C4RSfs_Ctx", status));
        //	NPPException.CheckNppStatus(status, this);
        //}
        ///// <summary>
        ///// Subtract constant to image, scale by 2^(-nScaleFactor), then clamp to saturated value. Inplace.
        ///// </summary>
        ///// <param name="nConstant">Value to subtract</param>
        ///// <param name="nScaleFactor">scaling factor</param>
        //public void Sub(int[] nConstant, int nScaleFactor)
        //{
        //	status = NPPNativeMethods_Ctx.NPPi.SubConst.nppiSubC_32s_C4IRSfs_Ctx(nConstant, _devPtrRoi, _pitch, _sizeRoi, nScaleFactor, nppStreamCtx);
        //	Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiSubC_32s_C4IRSfs_Ctx", status));
        //	NPPException.CheckNppStatus(status, this);
        //}

        ///// <summary>
        ///// Image subtraction, scale by 2^(-nScaleFactor), then clamp to saturated value. Unchanged Alpha.
        ///// </summary>
        ///// <param name="src2">2nd source image</param>
        ///// <param name="dest">Destination image</param>
        ///// <param name="nScaleFactor">scaling factor</param>
        //public void SubA(NPPImage_32sC4 src2, NPPImage_32sC4 dest, int nScaleFactor)
        //{
        //	status = NPPNativeMethods_Ctx.NPPi.Sub.nppiSub_32s_AC4RSfs_Ctx(_devPtrRoi, _pitch, src2.DevicePointerRoi, src2.Pitch, dest.DevicePointerRoi, dest.Pitch, _sizeRoi, nScaleFactor, nppStreamCtx);
        //	Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiSub_32s_AC4RSfs_Ctx", status));
        //	NPPException.CheckNppStatus(status, this);
        //}
        ///// <summary>
        ///// In place image subtraction, scale by 2^(-nScaleFactor), then clamp to saturated value. Unchanged Alpha.
        ///// </summary>
        ///// <param name="src2">2nd source image</param>
        ///// <param name="nScaleFactor">scaling factor</param>
        //public void SubA(NPPImage_32sC4 src2, int nScaleFactor)
        //{
        //	status = NPPNativeMethods_Ctx.NPPi.Sub.nppiSub_32s_AC4IRSfs_Ctx(src2.DevicePointerRoi, src2.Pitch, _devPtrRoi, _pitch, _sizeRoi, nScaleFactor, nppStreamCtx);
        //	Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiSub_32s_AC4IRSfs_Ctx", status));
        //	NPPException.CheckNppStatus(status, this);
        //}

        ///// <summary>
        ///// Subtract constant to image, scale by 2^(-nScaleFactor), then clamp to saturated value. Unchanged Alpha.
        ///// </summary>
        ///// <param name="nConstant">Value to subtract</param>
        ///// <param name="dest">Destination image</param>
        ///// <param name="nScaleFactor">scaling factor</param>
        //public void SubA(int[] nConstant, NPPImage_32sC4 dest, int nScaleFactor)
        //{
        //	status = NPPNativeMethods_Ctx.NPPi.SubConst.nppiSubC_32s_AC4RSfs_Ctx(_devPtrRoi, _pitch, nConstant, dest.DevicePointerRoi, dest.Pitch, _sizeRoi, nScaleFactor, nppStreamCtx);
        //	Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiSubC_32s_AC4RSfs_Ctx", status));
        //	NPPException.CheckNppStatus(status, this);
        //}
        ///// <summary>
        ///// Subtract constant to image, scale by 2^(-nScaleFactor), then clamp to saturated value. Inplace. Unchanged Alpha.
        ///// </summary>
        ///// <param name="nConstant">Value to subtract</param>
        ///// <param name="nScaleFactor">scaling factor</param>
        //public void SubA(int[] nConstant, int nScaleFactor)
        //{
        //	status = NPPNativeMethods_Ctx.NPPi.SubConst.nppiSubC_32s_AC4IRSfs_Ctx(nConstant, _devPtrRoi, _pitch, _sizeRoi, nScaleFactor, nppStreamCtx);
        //	Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiSubC_32s_AC4IRSfs_Ctx", status));
        //	NPPException.CheckNppStatus(status, this);
        //}
        #endregion

        #region Mul
        ///// <summary>
        ///// Image multiplication, scale by 2^(-nScaleFactor), then clamp to saturated value.
        ///// </summary>
        ///// <param name="src2">2nd source image</param>
        ///// <param name="dest">Destination image</param>
        ///// <param name="nScaleFactor">scaling factor</param>
        //public void Mul(NPPImage_32sC4 src2, NPPImage_32sC4 dest, int nScaleFactor)
        //{
        //	status = NPPNativeMethods_Ctx.NPPi.Mul.nppiMul_32s_C4RSfs_Ctx(_devPtrRoi, _pitch, src2.DevicePointerRoi, src2.Pitch, dest.DevicePointerRoi, dest.Pitch, _sizeRoi, nScaleFactor, nppStreamCtx);
        //	Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiMul_32s_C4RSfs_Ctx", status));
        //	NPPException.CheckNppStatus(status, this);
        //}
        ///// <summary>
        ///// In place image multiplication, scale by 2^(-nScaleFactor), then clamp to saturated value.
        ///// </summary>
        ///// <param name="src2">2nd source image</param>
        ///// <param name="nScaleFactor">scaling factor</param>
        //public void Mul(NPPImage_32sC4 src2, int nScaleFactor)
        //{
        //	status = NPPNativeMethods_Ctx.NPPi.Mul.nppiMul_32s_C4IRSfs_Ctx(src2.DevicePointerRoi, src2.Pitch, _devPtrRoi, _pitch, _sizeRoi, nScaleFactor, nppStreamCtx);
        //	Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiMul_32s_C4IRSfs_Ctx", status));
        //	NPPException.CheckNppStatus(status, this);
        //}

        ///// <summary>
        ///// Multiply constant to image, scale by 2^(-nScaleFactor), then clamp to saturated value.
        ///// </summary>
        ///// <param name="nConstant">Value</param>
        ///// <param name="dest">Destination image</param>
        ///// <param name="nScaleFactor">scaling factor</param>
        //public void Mul(int[] nConstant, NPPImage_32sC4 dest, int nScaleFactor)
        //{
        //	status = NPPNativeMethods_Ctx.NPPi.MulConst.nppiMulC_32s_C4RSfs_Ctx(_devPtrRoi, _pitch, nConstant, dest.DevicePointerRoi, dest.Pitch, _sizeRoi, nScaleFactor, nppStreamCtx);
        //	Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiMulC_32s_C4RSfs_Ctx", status));
        //	NPPException.CheckNppStatus(status, this);
        //}
        ///// <summary>
        ///// Multiply constant to image, scale by 2^(-nScaleFactor), then clamp to saturated value. Inplace.
        ///// </summary>
        ///// <param name="nConstant">Value</param>
        ///// <param name="nScaleFactor">scaling factor</param>
        //public void Mul(int[] nConstant, int nScaleFactor)
        //{
        //	status = NPPNativeMethods_Ctx.NPPi.MulConst.nppiMulC_32s_C4IRSfs_Ctx(nConstant, _devPtrRoi, _pitch, _sizeRoi, nScaleFactor, nppStreamCtx);
        //	Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiMulC_32s_C4IRSfs_Ctx", status));
        //	NPPException.CheckNppStatus(status, this);
        //}


        ///// <summary>
        ///// Image multiplication, scale by 2^(-nScaleFactor), then clamp to saturated value. Unchanged Alpha.
        ///// </summary>
        ///// <param name="src2">2nd source image</param>
        ///// <param name="dest">Destination image</param>
        ///// <param name="nScaleFactor">scaling factor</param>
        //public void MulA(NPPImage_32sC4 src2, NPPImage_32sC4 dest, int nScaleFactor)
        //{
        //	status = NPPNativeMethods_Ctx.NPPi.Mul.nppiMul_32s_AC4RSfs_Ctx(_devPtrRoi, _pitch, src2.DevicePointerRoi, src2.Pitch, dest.DevicePointerRoi, dest.Pitch, _sizeRoi, nScaleFactor, nppStreamCtx);
        //	Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiMul_32s_AC4RSfs_Ctx", status));
        //	NPPException.CheckNppStatus(status, this);
        //}
        ///// <summary>
        ///// In place image multiplication, scale by 2^(-nScaleFactor), then clamp to saturated value. Unchanged Alpha.
        ///// </summary>
        ///// <param name="src2">2nd source image</param>
        ///// <param name="nScaleFactor">scaling factor</param>
        //public void MulA(NPPImage_32sC4 src2, int nScaleFactor)
        //{
        //	status = NPPNativeMethods_Ctx.NPPi.Mul.nppiMul_32s_AC4IRSfs_Ctx(src2.DevicePointerRoi, src2.Pitch, _devPtrRoi, _pitch, _sizeRoi, nScaleFactor, nppStreamCtx);
        //	Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiMul_32s_AC4IRSfs_Ctx", status));
        //	NPPException.CheckNppStatus(status, this);
        //}

        ///// <summary>
        ///// Multiply constant to image, scale by 2^(-nScaleFactor), then clamp to saturated value. Unchanged Alpha.
        ///// </summary>
        ///// <param name="nConstant">Value</param>
        ///// <param name="dest">Destination image</param>
        ///// <param name="nScaleFactor">scaling factor</param>
        //public void MulA(int[] nConstant, NPPImage_32sC4 dest, int nScaleFactor)
        //{
        //	status = NPPNativeMethods_Ctx.NPPi.MulConst.nppiMulC_32s_AC4RSfs_Ctx(_devPtrRoi, _pitch, nConstant, dest.DevicePointerRoi, dest.Pitch, _sizeRoi, nScaleFactor, nppStreamCtx);
        //	Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiMulC_32s_AC4RSfs_Ctx", status));
        //	NPPException.CheckNppStatus(status, this);
        //}
        ///// <summary>
        ///// Multiply constant to image, scale by 2^(-nScaleFactor), then clamp to saturated value. Inplace. Unchanged Alpha.
        ///// </summary>
        ///// <param name="nConstant">Value</param>
        ///// <param name="nScaleFactor">scaling factor</param>
        //public void MulA(int[] nConstant, int nScaleFactor)
        //{
        //	status = NPPNativeMethods_Ctx.NPPi.MulConst.nppiMulC_32s_AC4IRSfs_Ctx(nConstant, _devPtrRoi, _pitch, _sizeRoi, nScaleFactor, nppStreamCtx);
        //	Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiMulC_32s_AC4IRSfs_Ctx", status));
        //	NPPException.CheckNppStatus(status, this);
        //}

        #endregion

        #region Div
        ///// <summary>
        ///// Image division, scale by 2^(-nScaleFactor), then clamp to saturated value.
        ///// </summary>
        ///// <param name="src2">2nd source image</param>
        ///// <param name="dest">Destination image</param>
        ///// <param name="nScaleFactor">scaling factor</param>
        //public void Div(NPPImage_32sC4 src2, NPPImage_32sC4 dest, int nScaleFactor)
        //{
        //	status = NPPNativeMethods_Ctx.NPPi.Div.nppiDiv_32s_C4RSfs_Ctx(_devPtrRoi, _pitch, src2.DevicePointerRoi, src2.Pitch, dest.DevicePointerRoi, dest.Pitch, _sizeRoi, nScaleFactor, nppStreamCtx);
        //	Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiDiv_32s_C4RSfs_Ctx", status));
        //	NPPException.CheckNppStatus(status, this);
        //}
        ///// <summary>
        ///// In place image division, scale by 2^(-nScaleFactor), then clamp to saturated value.
        ///// </summary>
        ///// <param name="src2">2nd source image</param>
        ///// <param name="nScaleFactor">scaling factor</param>
        //public void Div(NPPImage_32sC4 src2, int nScaleFactor)
        //{
        //	status = NPPNativeMethods_Ctx.NPPi.Div.nppiDiv_32s_C4IRSfs_Ctx(src2.DevicePointerRoi, src2.Pitch, _devPtrRoi, _pitch, _sizeRoi, nScaleFactor, nppStreamCtx);
        //	Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiDiv_32s_C4IRSfs_Ctx", status));
        //	NPPException.CheckNppStatus(status, this);
        //}

        ///// <summary>
        ///// Divide constant to image, scale by 2^(-nScaleFactor), then clamp to saturated value.
        ///// </summary>
        ///// <param name="nConstant">Value</param>
        ///// <param name="dest">Destination image</param>
        ///// <param name="nScaleFactor">scaling factor</param>
        //public void Div(int[] nConstant, NPPImage_32sC4 dest, int nScaleFactor)
        //{
        //	status = NPPNativeMethods_Ctx.NPPi.DivConst.nppiDivC_32s_C4RSfs_Ctx(_devPtrRoi, _pitch, nConstant, dest.DevicePointerRoi, dest.Pitch, _sizeRoi, nScaleFactor, nppStreamCtx);
        //	Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiDivC_32s_C4RSfs_Ctx", status));
        //	NPPException.CheckNppStatus(status, this);
        //}
        ///// <summary>
        ///// Divide constant to image, scale by 2^(-nScaleFactor), then clamp to saturated value. Inplace.
        ///// </summary>
        ///// <param name="nConstant">Value</param>
        ///// <param name="nScaleFactor">scaling factor</param>
        //public void Div(int[] nConstant, int nScaleFactor)
        //{
        //	status = NPPNativeMethods_Ctx.NPPi.DivConst.nppiDivC_32s_C4IRSfs_Ctx(nConstant, _devPtrRoi, _pitch, _sizeRoi, nScaleFactor, nppStreamCtx);
        //	Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiDivC_32s_C4IRSfs_Ctx", status));
        //	NPPException.CheckNppStatus(status, this);
        //}

        ///// <summary>
        ///// Image division, scale by 2^(-nScaleFactor), then clamp to saturated value. Unchanged Alpha.
        ///// </summary>
        ///// <param name="src2">2nd source image</param>
        ///// <param name="dest">Destination image</param>
        ///// <param name="nScaleFactor">scaling factor</param>
        //public void DivA(NPPImage_32sC4 src2, NPPImage_32sC4 dest, int nScaleFactor)
        //{
        //	status = NPPNativeMethods_Ctx.NPPi.Div.nppiDiv_32s_AC4RSfs_Ctx(_devPtrRoi, _pitch, src2.DevicePointerRoi, src2.Pitch, dest.DevicePointerRoi, dest.Pitch, _sizeRoi, nScaleFactor, nppStreamCtx);
        //	Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiDiv_32s_AC4RSfs_Ctx", status));
        //	NPPException.CheckNppStatus(status, this);
        //}
        ///// <summary>
        ///// In place image division, scale by 2^(-nScaleFactor), then clamp to saturated value. Unchanged Alpha.
        ///// </summary>
        ///// <param name="src2">2nd source image</param>
        ///// <param name="nScaleFactor">scaling factor</param>
        //public void DivA(NPPImage_32sC4 src2, int nScaleFactor)
        //{
        //	status = NPPNativeMethods_Ctx.NPPi.Div.nppiDiv_32s_AC4IRSfs_Ctx(src2.DevicePointerRoi, src2.Pitch, _devPtrRoi, _pitch, _sizeRoi, nScaleFactor, nppStreamCtx);
        //	Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiDiv_32s_AC4IRSfs_Ctx", status));
        //	NPPException.CheckNppStatus(status, this);
        //}

        ///// <summary>
        ///// Divide constant to image, scale by 2^(-nScaleFactor), then clamp to saturated value. Unchanged Alpha.
        ///// </summary>
        ///// <param name="nConstant">Value</param>
        ///// <param name="dest">Destination image</param>
        ///// <param name="nScaleFactor">scaling factor</param>
        //public void DivA(int[] nConstant, NPPImage_32sC4 dest, int nScaleFactor)
        //{
        //	status = NPPNativeMethods_Ctx.NPPi.DivConst.nppiDivC_32s_AC4RSfs_Ctx(_devPtrRoi, _pitch, nConstant, dest.DevicePointerRoi, dest.Pitch, _sizeRoi, nScaleFactor, nppStreamCtx);
        //	Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiDivC_32s_AC4RSfs_Ctx", status));
        //	NPPException.CheckNppStatus(status, this);
        //}
        ///// <summary>
        ///// Divide constant to image, scale by 2^(-nScaleFactor), then clamp to saturated value. Inplace. Unchanged Alpha.
        ///// </summary>
        ///// <param name="nConstant">Value</param>
        ///// <param name="nScaleFactor">scaling factor</param>
        //public void DivA(int[] nConstant, int nScaleFactor)
        //{
        //	status = NPPNativeMethods_Ctx.NPPi.DivConst.nppiDivC_32s_AC4IRSfs_Ctx(nConstant, _devPtrRoi, _pitch, _sizeRoi, nScaleFactor, nppStreamCtx);
        //	Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiDivC_32s_AC4IRSfs_Ctx", status));
        //	NPPException.CheckNppStatus(status, this);
        //}
        #endregion

        #region Geometric Transforms

        /// <summary>
        /// Mirror image.
        /// </summary>
        /// <param name="dest">Destination image</param>
        /// <param name="flip">Specifies the axis about which the image is to be mirrored.</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void Mirror(NPPImage_32sC4 dest, NppiAxis flip, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.GeometricTransforms.nppiMirror_32s_C4R_Ctx(_devPtrRoi, _pitch, dest.DevicePointerRoi, dest.Pitch, dest.SizeRoi, flip, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiMirror_32s_C4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }

        /// <summary>
        /// Mirror image. Not affecting Alpha.
        /// </summary>
        /// <param name="dest">Destination image</param>
        /// <param name="flip">Specifies the axis about which the image is to be mirrored.</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void MirrorA(NPPImage_32sC4 dest, NppiAxis flip, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.GeometricTransforms.nppiMirror_32s_AC4R_Ctx(_devPtrRoi, _pitch, dest.DevicePointerRoi, dest.Pitch, dest.SizeRoi, flip, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiMirror_32s_AC4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }
        #endregion
        #region Affine Transformations

        /// <summary>
        /// Affine transform of an image. <para/>This
        /// function operates using given transform coefficients that can be obtained
        /// by using nppiGetAffineTransform function or set explicitly. The function
        /// operates on source and destination regions of interest. The affine warp
        /// function transforms the source image pixel coordinates (x,y) according
        /// to the following formulas:<para/>
        /// X_new = C_00 * x + C_01 * y + C_02<para/>
        /// Y_new = C_10 * x + C_11 * y + C_12<para/>
        /// The transformed part of the source image is resampled using the specified
        /// interpolation method and written to the destination ROI.
        /// The functions nppiGetAffineQuad and nppiGetAffineBound can help with 
        /// destination ROI specification.<para/>
        /// <para/>
        /// NPPI specific recommendation: <para/>
        /// The function operates using 2 types of kernels: fast and accurate. The fast
        /// method is about 4 times faster than its accurate variant,
        /// but does not perform memory access checks and requires the destination ROI
        /// to be 64 bytes aligned. Hence any destination ROI is 
        /// chunked into 3 vertical stripes: the first and the third are processed by
        /// accurate kernels and the central one is processed by the
        /// fast one.<para/>
        /// In order to get the maximum available speed of execution, the projection of
        /// destination ROI onto image addresses must be 64 bytes
        /// aligned. This is always true if the values <para/>
        /// <code>(int)((void *)(pDst + dstRoi.x))</code> and <para/>
        /// <code>(int)((void *)(pDst + dstRoi.x + dstRoi.width))</code> <para/>
        /// are multiples of 64. Another rule of thumb is to specify destination ROI in
        /// such way that left and right sides of the projected 
        /// image are separated from the ROI by at least 63 bytes from each side.
        /// However, this requires the whole ROI to be part of allocated memory. In case
        /// when the conditions above are not satisfied, the function may decrease in
        /// speed slightly and will return NPP_MISALIGNED_DST_ROI_WARNING warning.
        /// </summary>
        /// <param name="dest">Destination image</param>
        /// <param name="coeffs">Affine transform coefficients [2,3]</param>
        /// <param name="eInterpolation">Interpolation mode: can be <see cref="InterpolationMode.NearestNeighbor"/>, <see cref="InterpolationMode.Linear"/> or <see cref="InterpolationMode.Cubic"/></param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void WarpAffine(NPPImage_32sC4 dest, double[,] coeffs, InterpolationMode eInterpolation, NppStreamContext nppStreamCtx)
        {
            NppiRect rectIn = new NppiRect(_pointRoi, _sizeRoi);
            NppiRect rectOut = new NppiRect(dest.PointRoi, dest.SizeRoi);
            status = NPPNativeMethods_Ctx.NPPi.AffinTransforms.nppiWarpAffine_32s_C4R_Ctx(_devPtr, _sizeOriginal, _pitch, rectIn, dest.DevicePointer, dest.Pitch, rectOut, coeffs, eInterpolation, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiWarpAffine_32s_C4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }

        /// <summary>
        /// Affine transform of an image. Not affecting Alpha channel.<para/>This
        /// function operates using given transform coefficients that can be obtained
        /// by using nppiGetAffineTransform function or set explicitly. The function
        /// operates on source and destination regions of interest. The affine warp
        /// function transforms the source image pixel coordinates (x,y) according
        /// to the following formulas:<para/>
        /// X_new = C_00 * x + C_01 * y + C_02<para/>
        /// Y_new = C_10 * x + C_11 * y + C_12<para/>
        /// The transformed part of the source image is resampled using the specified
        /// interpolation method and written to the destination ROI.
        /// The functions nppiGetAffineQuad and nppiGetAffineBound can help with 
        /// destination ROI specification.<para/>
        /// <para/>
        /// NPPI specific recommendation: <para/>
        /// The function operates using 2 types of kernels: fast and accurate. The fast
        /// method is about 4 times faster than its accurate variant,
        /// but does not perform memory access checks and requires the destination ROI
        /// to be 64 bytes aligned. Hence any destination ROI is 
        /// chunked into 3 vertical stripes: the first and the third are processed by
        /// accurate kernels and the central one is processed by the
        /// fast one.<para/>
        /// In order to get the maximum available speed of execution, the projection of
        /// destination ROI onto image addresses must be 64 bytes
        /// aligned. This is always true if the values <para/>
        /// <code>(int)((void *)(pDst + dstRoi.x))</code> and <para/>
        /// <code>(int)((void *)(pDst + dstRoi.x + dstRoi.width))</code> <para/>
        /// are multiples of 64. Another rule of thumb is to specify destination ROI in
        /// such way that left and right sides of the projected 
        /// image are separated from the ROI by at least 63 bytes from each side.
        /// However, this requires the whole ROI to be part of allocated memory. In case
        /// when the conditions above are not satisfied, the function may decrease in
        /// speed slightly and will return NPP_MISALIGNED_DST_ROI_WARNING warning.
        /// </summary>
        /// <param name="dest">Destination image</param>
        /// <param name="coeffs">Affine transform coefficients [2,3]</param>
        /// <param name="eInterpolation">Interpolation mode: can be <see cref="InterpolationMode.NearestNeighbor"/>, <see cref="InterpolationMode.Linear"/> or <see cref="InterpolationMode.Cubic"/></param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void WarpAffineA(NPPImage_32sC4 dest, double[,] coeffs, InterpolationMode eInterpolation, NppStreamContext nppStreamCtx)
        {
            NppiRect rectIn = new NppiRect(_pointRoi, _sizeRoi);
            NppiRect rectOut = new NppiRect(dest.PointRoi, dest.SizeRoi);
            status = NPPNativeMethods_Ctx.NPPi.AffinTransforms.nppiWarpAffine_32s_AC4R_Ctx(_devPtr, _sizeOriginal, _pitch, rectIn, dest.DevicePointer, dest.Pitch, rectOut, coeffs, eInterpolation, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiWarpAffine_32s_AC4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }

        /// <summary>
        /// Inverse affine transform of an image.<para/>
        /// This function operates using given transform coefficients that can be
        /// obtained by using nppiGetAffineTransform function or set explicitly. Thus
        /// there is no need to invert coefficients in your application before calling
        /// WarpAffineBack. The function operates on source and destination regions of
        /// interest.<para/>
        /// The affine warp function transforms the source image pixel coordinates
        /// (x,y) according to the following formulas:<para/>
        /// X_new = C_00 * x + C_01 * y + C_02<para/>
        /// Y_new = C_10 * x + C_11 * y + C_12<para/>
        /// The transformed part of the source image is resampled using the specified
        /// interpolation method and written to the destination ROI.
        /// The functions nppiGetAffineQuad and nppiGetAffineBound can help with
        /// destination ROI specification.<para/><para/>
        /// NPPI specific recommendation: <para/>
        /// The function operates using 2 types of kernels: fast and accurate. The fast
        /// method is about 4 times faster than its accurate variant,
        /// but doesn't perform memory access checks and requires the destination ROI
        /// to be 64 bytes aligned. Hence any destination ROI is 
        /// chunked into 3 vertical stripes: the first and the third are processed by
        /// accurate kernels and the central one is processed by the fast one.
        /// In order to get the maximum available speed of execution, the projection of
        /// destination ROI onto image addresses must be 64 bytes aligned. This is
        /// always true if the values <para/>
        /// <code>(int)((void *)(pDst + dstRoi.x))</code> and <para/>
        /// <code>(int)((void *)(pDst + dstRoi.x + dstRoi.width))</code> <para/>
        /// are multiples of 64. Another rule of thumb is to specify destination ROI in
        /// such way that left and right sides of the projected image are separated from
        /// the ROI by at least 63 bytes from each side. However, this requires the
        /// whole ROI to be part of allocated memory. In case when the conditions above
        /// are not satisfied, the function may decrease in speed slightly and will
        /// return NPP_MISALIGNED_DST_ROI_WARNING warning.
        /// </summary>
        /// <param name="dest">Destination image</param>
        /// <param name="coeffs">Affine transform coefficients [2,3]</param>
        /// <param name="eInterpolation">Interpolation mode: can be <see cref="InterpolationMode.NearestNeighbor"/>, <see cref="InterpolationMode.Linear"/> or <see cref="InterpolationMode.Cubic"/></param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void WarpAffineBack(NPPImage_32sC4 dest, double[,] coeffs, InterpolationMode eInterpolation, NppStreamContext nppStreamCtx)
        {
            NppiRect rectIn = new NppiRect(_pointRoi, _sizeRoi);
            NppiRect rectOut = new NppiRect(dest.PointRoi, dest.SizeRoi);
            status = NPPNativeMethods_Ctx.NPPi.AffinTransforms.nppiWarpAffineBack_32s_C4R_Ctx(_devPtr, _sizeOriginal, _pitch, rectIn, dest.DevicePointer, dest.Pitch, rectOut, coeffs, eInterpolation, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiWarpAffineBack_32s_C4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }

        /// <summary>
        /// Inverse affine transform of an image. Not affecting Alpha channel.<para/>
        /// This function operates using given transform coefficients that can be
        /// obtained by using nppiGetAffineTransform function or set explicitly. Thus
        /// there is no need to invert coefficients in your application before calling
        /// WarpAffineBack. The function operates on source and destination regions of
        /// interest.<para/>
        /// The affine warp function transforms the source image pixel coordinates
        /// (x,y) according to the following formulas:<para/>
        /// X_new = C_00 * x + C_01 * y + C_02<para/>
        /// Y_new = C_10 * x + C_11 * y + C_12<para/>
        /// The transformed part of the source image is resampled using the specified
        /// interpolation method and written to the destination ROI.
        /// The functions nppiGetAffineQuad and nppiGetAffineBound can help with
        /// destination ROI specification.<para/><para/>
        /// NPPI specific recommendation: <para/>
        /// The function operates using 2 types of kernels: fast and accurate. The fast
        /// method is about 4 times faster than its accurate variant,
        /// but doesn't perform memory access checks and requires the destination ROI
        /// to be 64 bytes aligned. Hence any destination ROI is 
        /// chunked into 3 vertical stripes: the first and the third are processed by
        /// accurate kernels and the central one is processed by the fast one.
        /// In order to get the maximum available speed of execution, the projection of
        /// destination ROI onto image addresses must be 64 bytes aligned. This is
        /// always true if the values <para/>
        /// <code>(int)((void *)(pDst + dstRoi.x))</code> and <para/>
        /// <code>(int)((void *)(pDst + dstRoi.x + dstRoi.width))</code> <para/>
        /// are multiples of 64. Another rule of thumb is to specify destination ROI in
        /// such way that left and right sides of the projected image are separated from
        /// the ROI by at least 63 bytes from each side. However, this requires the
        /// whole ROI to be part of allocated memory. In case when the conditions above
        /// are not satisfied, the function may decrease in speed slightly and will
        /// return NPP_MISALIGNED_DST_ROI_WARNING warning.
        /// </summary>
        /// <param name="dest">Destination image</param>
        /// <param name="coeffs">Affine transform coefficients [2,3]</param>
        /// <param name="eInterpolation">Interpolation mode: can be <see cref="InterpolationMode.NearestNeighbor"/>, <see cref="InterpolationMode.Linear"/> or <see cref="InterpolationMode.Cubic"/></param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void WarpAffineBackA(NPPImage_32sC4 dest, double[,] coeffs, InterpolationMode eInterpolation, NppStreamContext nppStreamCtx)
        {
            NppiRect rectIn = new NppiRect(_pointRoi, _sizeRoi);
            NppiRect rectOut = new NppiRect(dest.PointRoi, dest.SizeRoi);
            status = NPPNativeMethods_Ctx.NPPi.AffinTransforms.nppiWarpAffineBack_32s_AC4R_Ctx(_devPtr, _sizeOriginal, _pitch, rectIn, dest.DevicePointer, dest.Pitch, rectOut, coeffs, eInterpolation, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiWarpAffineBack_32s_AC4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }

        /// <summary>
        /// Affine transform of an image. <para/>This
        /// function performs affine warping of a the specified quadrangle in the
        /// source image to the specified quadrangle in the destination image. The
        /// function nppiWarpAffineQuad uses the same formulas for pixel mapping as in
        /// nppiWarpAffine function. The transform coefficients are computed internally.
        /// The transformed part of the source image is resampled using the specified
        /// eInterpolation method and written to the destination ROI.<para/>
        /// NPPI specific recommendation: <para/>
        /// The function operates using 2 types of kernels: fast and accurate. The fast
        /// method is about 4 times faster than its accurate variant,
        /// but doesn't perform memory access checks and requires the destination ROI
        /// to be 64 bytes aligned. Hence any destination ROI is 
        /// chunked into 3 vertical stripes: the first and the third are processed by
        /// accurate kernels and the central one is processed by the fast one.
        /// In order to get the maximum available speed of execution, the projection of
        /// destination ROI onto image addresses must be 64 bytes aligned. This is
        /// always true if the values <para/>
        /// <code>(int)((void *)(pDst + dstRoi.x))</code> and <para/>
        /// <code>(int)((void *)(pDst + dstRoi.x + dstRoi.width))</code> <para/>
        /// are multiples of 64. Another rule of thumb is to specify destination ROI in
        /// such way that left and right sides of the projected image are separated from
        /// the ROI by at least 63 bytes from each side. However, this requires the
        /// whole ROI to be part of allocated memory. In case when the conditions above
        /// are not satisfied, the function may decrease in speed slightly and will
        /// return NPP_MISALIGNED_DST_ROI_WARNING warning.
        /// </summary>
        /// <param name="srcQuad">Source quadrangle [4,2]</param>
        /// <param name="dest">Destination image</param>
        /// <param name="dstQuad">Destination quadrangle [4,2]</param>
        /// <param name="eInterpolation">Interpolation mode: can be <see cref="InterpolationMode.NearestNeighbor"/>, <see cref="InterpolationMode.Linear"/> or <see cref="InterpolationMode.Cubic"/></param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void WarpAffineQuad(double[,] srcQuad, NPPImage_32sC4 dest, double[,] dstQuad, InterpolationMode eInterpolation, NppStreamContext nppStreamCtx)
        {
            NppiRect rectIn = new NppiRect(_pointRoi, _sizeRoi);
            NppiRect rectOut = new NppiRect(dest.PointRoi, dest.SizeRoi);
            status = NPPNativeMethods_Ctx.NPPi.AffinTransforms.nppiWarpAffineQuad_32s_C4R_Ctx(_devPtr, _sizeOriginal, _pitch, rectIn, srcQuad, dest.DevicePointer, dest.Pitch, rectOut, dstQuad, eInterpolation, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiWarpAffineQuad_32s_C4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }

        /// <summary>
        /// Affine transform of an image. Not affecting Alpha channel. <para/>This
        /// function performs affine warping of a the specified quadrangle in the
        /// source image to the specified quadrangle in the destination image. The
        /// function nppiWarpAffineQuad uses the same formulas for pixel mapping as in
        /// nppiWarpAffine function. The transform coefficients are computed internally.
        /// The transformed part of the source image is resampled using the specified
        /// eInterpolation method and written to the destination ROI.<para/>
        /// NPPI specific recommendation: <para/>
        /// The function operates using 2 types of kernels: fast and accurate. The fast
        /// method is about 4 times faster than its accurate variant,
        /// but doesn't perform memory access checks and requires the destination ROI
        /// to be 64 bytes aligned. Hence any destination ROI is 
        /// chunked into 3 vertical stripes: the first and the third are processed by
        /// accurate kernels and the central one is processed by the fast one.
        /// In order to get the maximum available speed of execution, the projection of
        /// destination ROI onto image addresses must be 64 bytes aligned. This is
        /// always true if the values <para/>
        /// <code>(int)((void *)(pDst + dstRoi.x))</code> and <para/>
        /// <code>(int)((void *)(pDst + dstRoi.x + dstRoi.width))</code> <para/>
        /// are multiples of 64. Another rule of thumb is to specify destination ROI in
        /// such way that left and right sides of the projected image are separated from
        /// the ROI by at least 63 bytes from each side. However, this requires the
        /// whole ROI to be part of allocated memory. In case when the conditions above
        /// are not satisfied, the function may decrease in speed slightly and will
        /// return NPP_MISALIGNED_DST_ROI_WARNING warning.
        /// </summary>
        /// <param name="srcQuad">Source quadrangle [4,2]</param>
        /// <param name="dest">Destination image</param>
        /// <param name="dstQuad">Destination quadrangle [4,2]</param>
        /// <param name="eInterpolation">Interpolation mode: can be <see cref="InterpolationMode.NearestNeighbor"/>, <see cref="InterpolationMode.Linear"/> or <see cref="InterpolationMode.Cubic"/></param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void WarpAffineQuadA(double[,] srcQuad, NPPImage_32sC4 dest, double[,] dstQuad, InterpolationMode eInterpolation, NppStreamContext nppStreamCtx)
        {
            NppiRect rectIn = new NppiRect(_pointRoi, _sizeRoi);
            NppiRect rectOut = new NppiRect(dest.PointRoi, dest.SizeRoi);
            status = NPPNativeMethods_Ctx.NPPi.AffinTransforms.nppiWarpAffineQuad_32s_AC4R_Ctx(_devPtr, _sizeOriginal, _pitch, rectIn, srcQuad, dest.DevicePointer, dest.Pitch, rectOut, dstQuad, eInterpolation, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiWarpAffineQuad_32s_AC4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }

        /// <summary>
        /// Affine transform of an image. <para/>This
        /// function operates using given transform coefficients that can be obtained
        /// by using nppiGetAffineTransform function or set explicitly. The function
        /// operates on source and destination regions of interest. The affine warp
        /// function transforms the source image pixel coordinates (x,y) according
        /// to the following formulas:<para/>
        /// X_new = C_00 * x + C_01 * y + C_02<para/>
        /// Y_new = C_10 * x + C_11 * y + C_12<para/>
        /// The transformed part of the source image is resampled using the specified
        /// interpolation method and written to the destination ROI.
        /// The functions nppiGetAffineQuad and nppiGetAffineBound can help with 
        /// destination ROI specification.<para/>
        /// <para/>
        /// NPPI specific recommendation: <para/>
        /// The function operates using 2 types of kernels: fast and accurate. The fast
        /// method is about 4 times faster than its accurate variant,
        /// but does not perform memory access checks and requires the destination ROI
        /// to be 64 bytes aligned. Hence any destination ROI is 
        /// chunked into 3 vertical stripes: the first and the third are processed by
        /// accurate kernels and the central one is processed by the
        /// fast one.<para/>
        /// In order to get the maximum available speed of execution, the projection of
        /// destination ROI onto image addresses must be 64 bytes
        /// aligned. This is always true if the values <para/>
        /// <code>(int)((void *)(pDst + dstRoi.x))</code> and <para/>
        /// <code>(int)((void *)(pDst + dstRoi.x + dstRoi.width))</code> <para/>
        /// are multiples of 64. Another rule of thumb is to specify destination ROI in
        /// such way that left and right sides of the projected 
        /// image are separated from the ROI by at least 63 bytes from each side.
        /// However, this requires the whole ROI to be part of allocated memory. In case
        /// when the conditions above are not satisfied, the function may decrease in
        /// speed slightly and will return NPP_MISALIGNED_DST_ROI_WARNING warning.
        /// </summary>
        /// <param name="src0">Source image (Channel 0)</param>
        /// <param name="src1">Source image (Channel 1)</param>
        /// <param name="src2">Source image (Channel 2)</param>
        /// <param name="dest0">Destination image (Channel 0)</param>
        /// <param name="dest1">Destination image (Channel 1)</param>
        /// <param name="dest2">Destination image (Channel 2)</param>
        /// <param name="coeffs">Affine transform coefficients [2,3]</param>
        /// <param name="eInterpolation">Interpolation mode: can be <see cref="InterpolationMode.NearestNeighbor"/>, <see cref="InterpolationMode.Linear"/> or <see cref="InterpolationMode.Cubic"/></param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public static void WarpAffine(NPPImage_32sC1 src0, NPPImage_32sC1 src1, NPPImage_32sC1 src2, NPPImage_32sC1 dest0, NPPImage_32sC1 dest1, NPPImage_32sC1 dest2, double[,] coeffs, InterpolationMode eInterpolation, NppStreamContext nppStreamCtx)
        {
            NppiRect rectIn = new NppiRect(src0.PointRoi, src0.SizeRoi);
            NppiRect rectOut = new NppiRect(dest0.PointRoi, dest0.SizeRoi);

            CUdeviceptr[] src = new CUdeviceptr[] { src0.DevicePointer, src1.DevicePointer, src2.DevicePointer };
            CUdeviceptr[] dst = new CUdeviceptr[] { dest0.DevicePointer, dest1.DevicePointer, dest2.DevicePointer };

            NppStatus status = NPPNativeMethods_Ctx.NPPi.AffinTransforms.nppiWarpAffine_32s_P4R_Ctx(src, src0.Size, src0.Pitch, rectIn, dst, dest0.Pitch, rectOut, coeffs, eInterpolation, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiWarpAffine_32s_P4R_Ctx", status));
            NPPException.CheckNppStatus(status, null);
        }

        /// <summary>
        /// Inverse affine transform of an image.<para/>
        /// This function operates using given transform coefficients that can be
        /// obtained by using nppiGetAffineTransform function or set explicitly. Thus
        /// there is no need to invert coefficients in your application before calling
        /// WarpAffineBack. The function operates on source and destination regions of
        /// interest.<para/>
        /// The affine warp function transforms the source image pixel coordinates
        /// (x,y) according to the following formulas:<para/>
        /// X_new = C_00 * x + C_01 * y + C_02<para/>
        /// Y_new = C_10 * x + C_11 * y + C_12<para/>
        /// The transformed part of the source image is resampled using the specified
        /// interpolation method and written to the destination ROI.
        /// The functions nppiGetAffineQuad and nppiGetAffineBound can help with
        /// destination ROI specification.<para/><para/>
        /// NPPI specific recommendation: <para/>
        /// The function operates using 2 types of kernels: fast and accurate. The fast
        /// method is about 4 times faster than its accurate variant,
        /// but doesn't perform memory access checks and requires the destination ROI
        /// to be 64 bytes aligned. Hence any destination ROI is 
        /// chunked into 3 vertical stripes: the first and the third are processed by
        /// accurate kernels and the central one is processed by the fast one.
        /// In order to get the maximum available speed of execution, the projection of
        /// destination ROI onto image addresses must be 64 bytes aligned. This is
        /// always true if the values <para/>
        /// <code>(int)((void *)(pDst + dstRoi.x))</code> and <para/>
        /// <code>(int)((void *)(pDst + dstRoi.x + dstRoi.width))</code> <para/>
        /// are multiples of 64. Another rule of thumb is to specify destination ROI in
        /// such way that left and right sides of the projected image are separated from
        /// the ROI by at least 63 bytes from each side. However, this requires the
        /// whole ROI to be part of allocated memory. In case when the conditions above
        /// are not satisfied, the function may decrease in speed slightly and will
        /// return NPP_MISALIGNED_DST_ROI_WARNING warning.
        /// </summary>
        /// <param name="src0">Source image (Channel 0)</param>
        /// <param name="src1">Source image (Channel 1)</param>
        /// <param name="src2">Source image (Channel 2)</param>
        /// <param name="dest0">Destination image (Channel 0)</param>
        /// <param name="dest1">Destination image (Channel 1)</param>
        /// <param name="dest2">Destination image (Channel 2)</param>
        /// <param name="coeffs">Affine transform coefficients [2,3]</param>
        /// <param name="eInterpolation">Interpolation mode: can be <see cref="InterpolationMode.NearestNeighbor"/>, <see cref="InterpolationMode.Linear"/> or <see cref="InterpolationMode.Cubic"/></param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public static void WarpAffineBack(NPPImage_32sC1 src0, NPPImage_32sC1 src1, NPPImage_32sC1 src2, NPPImage_32sC1 dest0, NPPImage_32sC1 dest1, NPPImage_32sC1 dest2, double[,] coeffs, InterpolationMode eInterpolation, NppStreamContext nppStreamCtx)
        {
            NppiRect rectIn = new NppiRect(src0.PointRoi, src0.SizeRoi);
            NppiRect rectOut = new NppiRect(dest0.PointRoi, dest0.SizeRoi);

            CUdeviceptr[] src = new CUdeviceptr[] { src0.DevicePointer, src1.DevicePointer, src2.DevicePointer };
            CUdeviceptr[] dst = new CUdeviceptr[] { dest0.DevicePointer, dest1.DevicePointer, dest2.DevicePointer };

            NppStatus status = NPPNativeMethods_Ctx.NPPi.AffinTransforms.nppiWarpAffineBack_32s_P4R_Ctx(src, src0.Size, src0.Pitch, rectIn, dst, dest0.Pitch, rectOut, coeffs, eInterpolation, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiWarpAffineBack_32s_P4R_Ctx", status));
            NPPException.CheckNppStatus(status, null);
        }

        /// <summary>
        /// Affine transform of an image. <para/>This
        /// function performs affine warping of a the specified quadrangle in the
        /// source image to the specified quadrangle in the destination image. The
        /// function nppiWarpAffineQuad uses the same formulas for pixel mapping as in
        /// nppiWarpAffine function. The transform coefficients are computed internally.
        /// The transformed part of the source image is resampled using the specified
        /// eInterpolation method and written to the destination ROI.<para/>
        /// NPPI specific recommendation: <para/>
        /// The function operates using 2 types of kernels: fast and accurate. The fast
        /// method is about 4 times faster than its accurate variant,
        /// but doesn't perform memory access checks and requires the destination ROI
        /// to be 64 bytes aligned. Hence any destination ROI is 
        /// chunked into 3 vertical stripes: the first and the third are processed by
        /// accurate kernels and the central one is processed by the fast one.
        /// In order to get the maximum available speed of execution, the projection of
        /// destination ROI onto image addresses must be 64 bytes aligned. This is
        /// always true if the values <para/>
        /// <code>(int)((void *)(pDst + dstRoi.x))</code> and <para/>
        /// <code>(int)((void *)(pDst + dstRoi.x + dstRoi.width))</code> <para/>
        /// are multiples of 64. Another rule of thumb is to specify destination ROI in
        /// such way that left and right sides of the projected image are separated from
        /// the ROI by at least 63 bytes from each side. However, this requires the
        /// whole ROI to be part of allocated memory. In case when the conditions above
        /// are not satisfied, the function may decrease in speed slightly and will
        /// return NPP_MISALIGNED_DST_ROI_WARNING warning.
        /// </summary>
        /// <param name="src0">Source image (Channel 0)</param>
        /// <param name="src1">Source image (Channel 1)</param>
        /// <param name="src2">Source image (Channel 2)</param>
        /// <param name="srcQuad">Source quadrangle [4,2]</param>
        /// <param name="dest0">Destination image (Channel 0)</param>
        /// <param name="dest1">Destination image (Channel 1)</param>
        /// <param name="dest2">Destination image (Channel 2)</param>
        /// <param name="dstQuad">Destination quadrangle [4,2]</param>
        /// <param name="eInterpolation">Interpolation mode: can be <see cref="InterpolationMode.NearestNeighbor"/>, <see cref="InterpolationMode.Linear"/> or <see cref="InterpolationMode.Cubic"/></param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public static void WarpAffineQuad(NPPImage_32sC1 src0, NPPImage_32sC1 src1, NPPImage_32sC1 src2, double[,] srcQuad, NPPImage_32sC1 dest0, NPPImage_32sC1 dest1, NPPImage_32sC1 dest2, double[,] dstQuad, InterpolationMode eInterpolation, NppStreamContext nppStreamCtx)
        {
            NppiRect rectIn = new NppiRect(src0.PointRoi, src0.SizeRoi);
            NppiRect rectOut = new NppiRect(dest0.PointRoi, dest0.SizeRoi);

            CUdeviceptr[] src = new CUdeviceptr[] { src0.DevicePointer, src1.DevicePointer, src2.DevicePointer };
            CUdeviceptr[] dst = new CUdeviceptr[] { dest0.DevicePointer, dest1.DevicePointer, dest2.DevicePointer };

            NppStatus status = NPPNativeMethods_Ctx.NPPi.AffinTransforms.nppiWarpAffineQuad_32s_P4R_Ctx(src, src0.Size, src0.Pitch, rectIn, srcQuad, dst, dest0.Pitch, rectOut, dstQuad, eInterpolation, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiWarpAffineQuad_32s_P4R_Ctx", status));
            NPPException.CheckNppStatus(status, null);
        }
        #endregion
        #region Perspective Transformations

        /// <summary>
        /// Perspective transform of an image.<para/>
        /// This function operates using given transform coefficients that 
        /// can be obtained by using nppiGetPerspectiveTransform function or set
        /// explicitly. The function operates on source and destination regions 
        /// of interest. The perspective warp function transforms the source image
        /// pixel coordinates (x,y) according to the following formulas:<para/>
        /// X_new = (C_00 * x + C_01 * y + C_02) / (C_20 * x + C_21 * y + C_22)<para/>
        /// Y_new = (C_10 * x + C_11 * y + C_12) / (C_20 * x + C_21 * y + C_22)<para/>
        /// The transformed part of the source image is resampled using the specified
        /// interpolation method and written to the destination ROI.
        /// The functions nppiGetPerspectiveQuad and nppiGetPerspectiveBound can help
        /// with destination ROI specification.<para/>
        /// NPPI specific recommendation: <para/>
        /// The function operates using 2 types of kernels: fast and accurate. The fast
        /// method is about 4 times faster than its accurate variant,
        /// but doesn't perform memory access checks and requires the destination ROI
        /// to be 64 bytes aligned. Hence any destination ROI is 
        /// chunked into 3 vertical stripes: the first and the third are processed by
        /// accurate kernels and the central one is processed by the fast one.
        /// In order to get the maximum available speed of execution, the projection of
        /// destination ROI onto image addresses must be 64 bytes aligned. This is
        /// always true if the values <para/>
        /// <code>(int)((void *)(pDst + dstRoi.x))</code> and <para/>
        /// <code>(int)((void *)(pDst + dstRoi.x + dstRoi.width))</code> <para/>
        /// are multiples of 64. Another rule of thumb is to specify destination ROI in
        /// such way that left and right sides of the projected image are separated from
        /// the ROI by at least 63 bytes from each side. However, this requires the
        /// whole ROI to be part of allocated memory. In case when the conditions above
        /// are not satisfied, the function may decrease in speed slightly and will
        /// return NPP_MISALIGNED_DST_ROI_WARNING warning.
        /// </summary>
        /// <param name="dest">Destination image</param>
        /// <param name="coeffs">Perspective transform coefficients [3,3]</param>
        /// <param name="eInterpolation">Interpolation mode: can be <see cref="InterpolationMode.NearestNeighbor"/>, <see cref="InterpolationMode.Linear"/> or <see cref="InterpolationMode.Cubic"/></param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void WarpPerspective(NPPImage_32sC4 dest, double[,] coeffs, InterpolationMode eInterpolation, NppStreamContext nppStreamCtx)
        {
            NppiRect rectIn = new NppiRect(_pointRoi, _sizeRoi);
            NppiRect rectOut = new NppiRect(dest.PointRoi, dest.SizeRoi);
            status = NPPNativeMethods_Ctx.NPPi.PerspectiveTransforms.nppiWarpPerspective_32s_C4R_Ctx(_devPtr, _sizeOriginal, _pitch, rectIn, dest.DevicePointer, dest.Pitch, rectOut, coeffs, eInterpolation, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiWarpPerspective_32s_C4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }

        /// <summary>
        /// Perspective transform of an image. Not affecting Alpha channel.<para/>
        /// This function operates using given transform coefficients that 
        /// can be obtained by using nppiGetPerspectiveTransform function or set
        /// explicitly. The function operates on source and destination regions 
        /// of interest. The perspective warp function transforms the source image
        /// pixel coordinates (x,y) according to the following formulas:<para/>
        /// X_new = (C_00 * x + C_01 * y + C_02) / (C_20 * x + C_21 * y + C_22)<para/>
        /// Y_new = (C_10 * x + C_11 * y + C_12) / (C_20 * x + C_21 * y + C_22)<para/>
        /// The transformed part of the source image is resampled using the specified
        /// interpolation method and written to the destination ROI.
        /// The functions nppiGetPerspectiveQuad and nppiGetPerspectiveBound can help
        /// with destination ROI specification.<para/>
        /// NPPI specific recommendation: <para/>
        /// The function operates using 2 types of kernels: fast and accurate. The fast
        /// method is about 4 times faster than its accurate variant,
        /// but doesn't perform memory access checks and requires the destination ROI
        /// to be 64 bytes aligned. Hence any destination ROI is 
        /// chunked into 3 vertical stripes: the first and the third are processed by
        /// accurate kernels and the central one is processed by the fast one.
        /// In order to get the maximum available speed of execution, the projection of
        /// destination ROI onto image addresses must be 64 bytes aligned. This is
        /// always true if the values <para/>
        /// <code>(int)((void *)(pDst + dstRoi.x))</code> and <para/>
        /// <code>(int)((void *)(pDst + dstRoi.x + dstRoi.width))</code> <para/>
        /// are multiples of 64. Another rule of thumb is to specify destination ROI in
        /// such way that left and right sides of the projected image are separated from
        /// the ROI by at least 63 bytes from each side. However, this requires the
        /// whole ROI to be part of allocated memory. In case when the conditions above
        /// are not satisfied, the function may decrease in speed slightly and will
        /// return NPP_MISALIGNED_DST_ROI_WARNING warning.
        /// </summary>
        /// <param name="dest">Destination image</param>
        /// <param name="coeffs">Perspective transform coefficients [3,3]</param>
        /// <param name="eInterpolation">Interpolation mode: can be <see cref="InterpolationMode.NearestNeighbor"/>, <see cref="InterpolationMode.Linear"/> or <see cref="InterpolationMode.Cubic"/></param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void WarpPerspectiveA(NPPImage_32sC4 dest, double[,] coeffs, InterpolationMode eInterpolation, NppStreamContext nppStreamCtx)
        {
            NppiRect rectIn = new NppiRect(_pointRoi, _sizeRoi);
            NppiRect rectOut = new NppiRect(dest.PointRoi, dest.SizeRoi);
            status = NPPNativeMethods_Ctx.NPPi.PerspectiveTransforms.nppiWarpPerspective_32s_AC4R_Ctx(_devPtr, _sizeOriginal, _pitch, rectIn, dest.DevicePointer, dest.Pitch, rectOut, coeffs, eInterpolation, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiWarpPerspective_32s_AC4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }

        /// <summary>
        /// Inverse perspective transform of an image. <para/>
        /// This function operates using given transform coefficients that 
        /// can be obtained by using nppiGetPerspectiveTransform function or set
        /// explicitly. Thus there is no need to invert coefficients in your application 
        /// before calling WarpPerspectiveBack. The function operates on source and
        /// destination regions of interest. The perspective warp function transforms the source image
        /// pixel coordinates (x,y) according to the following formulas:<para/>
        /// X_new = (C_00 * x + C_01 * y + C_02) / (C_20 * x + C_21 * y + C_22)<para/>
        /// Y_new = (C_10 * x + C_11 * y + C_12) / (C_20 * x + C_21 * y + C_22)<para/>
        /// The transformed part of the source image is resampled using the specified
        /// interpolation method and written to the destination ROI.
        /// The functions nppiGetPerspectiveQuad and nppiGetPerspectiveBound can help
        /// with destination ROI specification.<para/>
        /// NPPI specific recommendation: <para/>
        /// The function operates using 2 types of kernels: fast and accurate. The fast
        /// method is about 4 times faster than its accurate variant,
        /// but doesn't perform memory access checks and requires the destination ROI
        /// to be 64 bytes aligned. Hence any destination ROI is 
        /// chunked into 3 vertical stripes: the first and the third are processed by
        /// accurate kernels and the central one is processed by the fast one.
        /// In order to get the maximum available speed of execution, the projection of
        /// destination ROI onto image addresses must be 64 bytes aligned. This is
        /// always true if the values <para/>
        /// <code>(int)((void *)(pDst + dstRoi.x))</code> and <para/>
        /// <code>(int)((void *)(pDst + dstRoi.x + dstRoi.width))</code> <para/>
        /// are multiples of 64. Another rule of thumb is to specify destination ROI in
        /// such way that left and right sides of the projected image are separated from
        /// the ROI by at least 63 bytes from each side. However, this requires the
        /// whole ROI to be part of allocated memory. In case when the conditions above
        /// are not satisfied, the function may decrease in speed slightly and will
        /// return NPP_MISALIGNED_DST_ROI_WARNING warning.
        /// </summary>
        /// <param name="dest">Destination image</param>
        /// <param name="coeffs">Perspective transform coefficients [3,3]</param>
        /// <param name="eInterpolation">Interpolation mode: can be <see cref="InterpolationMode.NearestNeighbor"/>, <see cref="InterpolationMode.Linear"/> or <see cref="InterpolationMode.Cubic"/></param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void WarpPerspectiveBack(NPPImage_32sC4 dest, double[,] coeffs, InterpolationMode eInterpolation, NppStreamContext nppStreamCtx)
        {
            NppiRect rectIn = new NppiRect(_pointRoi, _sizeRoi);
            NppiRect rectOut = new NppiRect(dest.PointRoi, dest.SizeRoi);
            status = NPPNativeMethods_Ctx.NPPi.PerspectiveTransforms.nppiWarpPerspectiveBack_32s_C4R_Ctx(_devPtr, _sizeOriginal, _pitch, rectIn, dest.DevicePointer, dest.Pitch, rectOut, coeffs, eInterpolation, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiWarpPerspectiveBack_32s_C4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }

        /// <summary>
        /// Inverse perspective transform of an image. Not affecting Alpha channel. <para/>
        /// This function operates using given transform coefficients that 
        /// can be obtained by using nppiGetPerspectiveTransform function or set
        /// explicitly. Thus there is no need to invert coefficients in your application 
        /// before calling WarpPerspectiveBack. The function operates on source and
        /// destination regions of interest. The perspective warp function transforms the source image
        /// pixel coordinates (x,y) according to the following formulas:<para/>
        /// X_new = (C_00 * x + C_01 * y + C_02) / (C_20 * x + C_21 * y + C_22)<para/>
        /// Y_new = (C_10 * x + C_11 * y + C_12) / (C_20 * x + C_21 * y + C_22)<para/>
        /// The transformed part of the source image is resampled using the specified
        /// interpolation method and written to the destination ROI.
        /// The functions nppiGetPerspectiveQuad and nppiGetPerspectiveBound can help
        /// with destination ROI specification.<para/>
        /// NPPI specific recommendation: <para/>
        /// The function operates using 2 types of kernels: fast and accurate. The fast
        /// method is about 4 times faster than its accurate variant,
        /// but doesn't perform memory access checks and requires the destination ROI
        /// to be 64 bytes aligned. Hence any destination ROI is 
        /// chunked into 3 vertical stripes: the first and the third are processed by
        /// accurate kernels and the central one is processed by the fast one.
        /// In order to get the maximum available speed of execution, the projection of
        /// destination ROI onto image addresses must be 64 bytes aligned. This is
        /// always true if the values <para/>
        /// <code>(int)((void *)(pDst + dstRoi.x))</code> and <para/>
        /// <code>(int)((void *)(pDst + dstRoi.x + dstRoi.width))</code> <para/>
        /// are multiples of 64. Another rule of thumb is to specify destination ROI in
        /// such way that left and right sides of the projected image are separated from
        /// the ROI by at least 63 bytes from each side. However, this requires the
        /// whole ROI to be part of allocated memory. In case when the conditions above
        /// are not satisfied, the function may decrease in speed slightly and will
        /// return NPP_MISALIGNED_DST_ROI_WARNING warning.
        /// </summary>
        /// <param name="dest">Destination image</param>
        /// <param name="coeffs">Perspective transform coefficients [3,3]</param>
        /// <param name="eInterpolation">Interpolation mode: can be <see cref="InterpolationMode.NearestNeighbor"/>, <see cref="InterpolationMode.Linear"/> or <see cref="InterpolationMode.Cubic"/></param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void WarpPerspectiveBackA(NPPImage_32sC4 dest, double[,] coeffs, InterpolationMode eInterpolation, NppStreamContext nppStreamCtx)
        {
            NppiRect rectIn = new NppiRect(_pointRoi, _sizeRoi);
            NppiRect rectOut = new NppiRect(dest.PointRoi, dest.SizeRoi);
            status = NPPNativeMethods_Ctx.NPPi.PerspectiveTransforms.nppiWarpPerspectiveBack_32s_AC4R_Ctx(_devPtr, _sizeOriginal, _pitch, rectIn, dest.DevicePointer, dest.Pitch, rectOut, coeffs, eInterpolation, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiWarpPerspectiveBack_32s_AC4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }

        /// <summary>
        /// Perspective transform of an image.<para/>
        /// This function performs perspective warping of a the specified
        /// quadrangle in the source image to the specified quadrangle in the
        /// destination image. The function nppiWarpPerspectiveQuad uses the same
        /// formulas for pixel mapping as in nppiWarpPerspective function. The
        /// transform coefficients are computed internally.
        /// The transformed part of the source image is resampled using the specified
        /// interpolation method and written to the destination ROI.<para/>
        /// NPPI specific recommendation: <para/>
        /// The function operates using 2 types of kernels: fast and accurate. The fast
        /// method is about 4 times faster than its accurate variant,
        /// but doesn't perform memory access checks and requires the destination ROI
        /// to be 64 bytes aligned. Hence any destination ROI is 
        /// chunked into 3 vertical stripes: the first and the third are processed by
        /// accurate kernels and the central one is processed by the fast one.
        /// In order to get the maximum available speed of execution, the projection of
        /// destination ROI onto image addresses must be 64 bytes aligned. This is
        /// always true if the values <para/>
        /// <code>(int)((void *)(pDst + dstRoi.x))</code> and <para/>
        /// <code>(int)((void *)(pDst + dstRoi.x + dstRoi.width))</code> <para/>
        /// are multiples of 64. Another rule of thumb is to specify destination ROI in
        /// such way that left and right sides of the projected image are separated from
        /// the ROI by at least 63 bytes from each side. However, this requires the
        /// whole ROI to be part of allocated memory. In case when the conditions above
        /// are not satisfied, the function may decrease in speed slightly and will
        /// return NPP_MISALIGNED_DST_ROI_WARNING warning.
        /// </summary>
        /// <param name="srcQuad">Source quadrangle [4,2]</param>
        /// <param name="dest">Destination image</param>
        /// <param name="destQuad">Destination quadrangle [4,2]</param>
        /// <param name="eInterpolation">Interpolation mode: can be <see cref="InterpolationMode.NearestNeighbor"/>, <see cref="InterpolationMode.Linear"/> or <see cref="InterpolationMode.Cubic"/></param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void WarpPerspectiveQuad(double[,] srcQuad, NPPImage_32sC4 dest, double[,] destQuad, InterpolationMode eInterpolation, NppStreamContext nppStreamCtx)
        {
            NppiRect rectIn = new NppiRect(_pointRoi, _sizeRoi);
            NppiRect rectOut = new NppiRect(dest.PointRoi, dest.SizeRoi);
            status = NPPNativeMethods_Ctx.NPPi.PerspectiveTransforms.nppiWarpPerspectiveQuad_32s_C4R_Ctx(_devPtr, _sizeOriginal, _pitch, rectIn, srcQuad, dest.DevicePointer, dest.Pitch, rectOut, destQuad, eInterpolation, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiWarpPerspectiveQuad_32s_C4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }

        /// <summary>
        /// Perspective transform of an image. Not affecting Alpha channel.<para/>
        /// This function performs perspective warping of a the specified
        /// quadrangle in the source image to the specified quadrangle in the
        /// destination image. The function nppiWarpPerspectiveQuad uses the same
        /// formulas for pixel mapping as in nppiWarpPerspective function. The
        /// transform coefficients are computed internally.
        /// The transformed part of the source image is resampled using the specified
        /// interpolation method and written to the destination ROI.<para/>
        /// NPPI specific recommendation: <para/>
        /// The function operates using 2 types of kernels: fast and accurate. The fast
        /// method is about 4 times faster than its accurate variant,
        /// but doesn't perform memory access checks and requires the destination ROI
        /// to be 64 bytes aligned. Hence any destination ROI is 
        /// chunked into 3 vertical stripes: the first and the third are processed by
        /// accurate kernels and the central one is processed by the fast one.
        /// In order to get the maximum available speed of execution, the projection of
        /// destination ROI onto image addresses must be 64 bytes aligned. This is
        /// always true if the values <para/>
        /// <code>(int)((void *)(pDst + dstRoi.x))</code> and <para/>
        /// <code>(int)((void *)(pDst + dstRoi.x + dstRoi.width))</code> <para/>
        /// are multiples of 64. Another rule of thumb is to specify destination ROI in
        /// such way that left and right sides of the projected image are separated from
        /// the ROI by at least 63 bytes from each side. However, this requires the
        /// whole ROI to be part of allocated memory. In case when the conditions above
        /// are not satisfied, the function may decrease in speed slightly and will
        /// return NPP_MISALIGNED_DST_ROI_WARNING warning.
        /// </summary>
        /// <param name="srcQuad">Source quadrangle [4,2]</param>
        /// <param name="dest">Destination image</param>
        /// <param name="destQuad">Destination quadrangle [4,2]</param>
        /// <param name="eInterpolation">Interpolation mode: can be <see cref="InterpolationMode.NearestNeighbor"/>, <see cref="InterpolationMode.Linear"/> or <see cref="InterpolationMode.Cubic"/></param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void WarpPerspectiveQuadA(double[,] srcQuad, NPPImage_32sC4 dest, double[,] destQuad, InterpolationMode eInterpolation, NppStreamContext nppStreamCtx)
        {
            NppiRect rectIn = new NppiRect(_pointRoi, _sizeRoi);
            NppiRect rectOut = new NppiRect(dest.PointRoi, dest.SizeRoi);
            status = NPPNativeMethods_Ctx.NPPi.PerspectiveTransforms.nppiWarpPerspectiveQuad_32s_AC4R_Ctx(_devPtr, _sizeOriginal, _pitch, rectIn, srcQuad, dest.DevicePointer, dest.Pitch, rectOut, destQuad, eInterpolation, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiWarpPerspectiveQuad_32s_AC4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }

        /// <summary>
        /// Perspective transform of an image.<para/>
        /// This function operates using given transform coefficients that 
        /// can be obtained by using nppiGetPerspectiveTransform function or set
        /// explicitly. The function operates on source and destination regions 
        /// of interest. The perspective warp function transforms the source image
        /// pixel coordinates (x,y) according to the following formulas:<para/>
        /// X_new = (C_00 * x + C_01 * y + C_02) / (C_20 * x + C_21 * y + C_22)<para/>
        /// Y_new = (C_10 * x + C_11 * y + C_12) / (C_20 * x + C_21 * y + C_22)<para/>
        /// The transformed part of the source image is resampled using the specified
        /// interpolation method and written to the destination ROI.
        /// The functions nppiGetPerspectiveQuad and nppiGetPerspectiveBound can help
        /// with destination ROI specification.<para/>
        /// NPPI specific recommendation: <para/>
        /// The function operates using 2 types of kernels: fast and accurate. The fast
        /// method is about 4 times faster than its accurate variant,
        /// but doesn't perform memory access checks and requires the destination ROI
        /// to be 64 bytes aligned. Hence any destination ROI is 
        /// chunked into 3 vertical stripes: the first and the third are processed by
        /// accurate kernels and the central one is processed by the fast one.
        /// In order to get the maximum available speed of execution, the projection of
        /// destination ROI onto image addresses must be 64 bytes aligned. This is
        /// always true if the values <para/>
        /// <code>(int)((void *)(pDst + dstRoi.x))</code> and <para/>
        /// <code>(int)((void *)(pDst + dstRoi.x + dstRoi.width))</code> <para/>
        /// are multiples of 64. Another rule of thumb is to specify destination ROI in
        /// such way that left and right sides of the projected image are separated from
        /// the ROI by at least 63 bytes from each side. However, this requires the
        /// whole ROI to be part of allocated memory. In case when the conditions above
        /// are not satisfied, the function may decrease in speed slightly and will
        /// return NPP_MISALIGNED_DST_ROI_WARNING warning.
        /// </summary>
        /// <param name="src0">Source image (Channel 0)</param>
        /// <param name="src1">Source image (Channel 1)</param>
        /// <param name="src2">Source image (Channel 2)</param>
        /// <param name="dest0">Destination image (Channel 0)</param>
        /// <param name="dest1">Destination image (Channel 1)</param>
        /// <param name="dest2">Destination image (Channel 2)</param>
        /// <param name="coeffs">Perspective transform coefficients [3,3]</param>
        /// <param name="eInterpolation">Interpolation mode: can be <see cref="InterpolationMode.NearestNeighbor"/>, <see cref="InterpolationMode.Linear"/> or <see cref="InterpolationMode.Cubic"/></param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public static void WarpPerspective(NPPImage_32sC1 src0, NPPImage_32sC1 src1, NPPImage_32sC1 src2, NPPImage_32sC1 dest0, NPPImage_32sC1 dest1, NPPImage_32sC1 dest2, double[,] coeffs, InterpolationMode eInterpolation, NppStreamContext nppStreamCtx)
        {
            NppiRect rectIn = new NppiRect(src0.PointRoi, src0.SizeRoi);
            NppiRect rectOut = new NppiRect(dest0.PointRoi, dest0.SizeRoi);

            CUdeviceptr[] src = new CUdeviceptr[] { src0.DevicePointer, src1.DevicePointer, src2.DevicePointer };
            CUdeviceptr[] dst = new CUdeviceptr[] { dest0.DevicePointer, dest1.DevicePointer, dest2.DevicePointer };

            NppStatus status = NPPNativeMethods_Ctx.NPPi.PerspectiveTransforms.nppiWarpPerspective_32s_P4R_Ctx(src, src0.Size, src0.Pitch, rectIn, dst, dest0.Pitch, rectOut, coeffs, eInterpolation, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiWarpPerspective_32s_P4R_Ctx", status));
            NPPException.CheckNppStatus(status, null);
        }

        /// <summary>
        /// Inverse perspective transform of an image. <para/>
        /// This function operates using given transform coefficients that 
        /// can be obtained by using nppiGetPerspectiveTransform function or set
        /// explicitly. Thus there is no need to invert coefficients in your application 
        /// before calling WarpPerspectiveBack. The function operates on source and
        /// destination regions of interest. The perspective warp function transforms the source image
        /// pixel coordinates (x,y) according to the following formulas:<para/>
        /// X_new = (C_00 * x + C_01 * y + C_02) / (C_20 * x + C_21 * y + C_22)<para/>
        /// Y_new = (C_10 * x + C_11 * y + C_12) / (C_20 * x + C_21 * y + C_22)<para/>
        /// The transformed part of the source image is resampled using the specified
        /// interpolation method and written to the destination ROI.
        /// The functions nppiGetPerspectiveQuad and nppiGetPerspectiveBound can help
        /// with destination ROI specification.<para/>
        /// NPPI specific recommendation: <para/>
        /// The function operates using 2 types of kernels: fast and accurate. The fast
        /// method is about 4 times faster than its accurate variant,
        /// but doesn't perform memory access checks and requires the destination ROI
        /// to be 64 bytes aligned. Hence any destination ROI is 
        /// chunked into 3 vertical stripes: the first and the third are processed by
        /// accurate kernels and the central one is processed by the fast one.
        /// In order to get the maximum available speed of execution, the projection of
        /// destination ROI onto image addresses must be 64 bytes aligned. This is
        /// always true if the values <para/>
        /// <code>(int)((void *)(pDst + dstRoi.x))</code> and <para/>
        /// <code>(int)((void *)(pDst + dstRoi.x + dstRoi.width))</code> <para/>
        /// are multiples of 64. Another rule of thumb is to specify destination ROI in
        /// such way that left and right sides of the projected image are separated from
        /// the ROI by at least 63 bytes from each side. However, this requires the
        /// whole ROI to be part of allocated memory. In case when the conditions above
        /// are not satisfied, the function may decrease in speed slightly and will
        /// return NPP_MISALIGNED_DST_ROI_WARNING warning.
        /// </summary>
        /// <param name="src0">Source image (Channel 0)</param>
        /// <param name="src1">Source image (Channel 1)</param>
        /// <param name="src2">Source image (Channel 2)</param>
        /// <param name="dest0">Destination image (Channel 0)</param>
        /// <param name="dest1">Destination image (Channel 1)</param>
        /// <param name="dest2">Destination image (Channel 2)</param>
        /// <param name="coeffs">Perspective transform coefficients [3,3]</param>
        /// <param name="eInterpolation">Interpolation mode: can be <see cref="InterpolationMode.NearestNeighbor"/>, <see cref="InterpolationMode.Linear"/> or <see cref="InterpolationMode.Cubic"/></param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public static void WarpPerspectiveBack(NPPImage_32sC1 src0, NPPImage_32sC1 src1, NPPImage_32sC1 src2, NPPImage_32sC1 dest0, NPPImage_32sC1 dest1, NPPImage_32sC1 dest2, double[,] coeffs, InterpolationMode eInterpolation, NppStreamContext nppStreamCtx)
        {
            NppiRect rectIn = new NppiRect(src0.PointRoi, src0.SizeRoi);
            NppiRect rectOut = new NppiRect(dest0.PointRoi, dest0.SizeRoi);

            CUdeviceptr[] src = new CUdeviceptr[] { src0.DevicePointer, src1.DevicePointer, src2.DevicePointer };
            CUdeviceptr[] dst = new CUdeviceptr[] { dest0.DevicePointer, dest1.DevicePointer, dest2.DevicePointer };

            NppStatus status = NPPNativeMethods_Ctx.NPPi.PerspectiveTransforms.nppiWarpPerspectiveBack_32s_P4R_Ctx(src, src0.Size, src0.Pitch, rectIn, dst, dest0.Pitch, rectOut, coeffs, eInterpolation, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiWarpPerspectiveBack_32s_P4R_Ctx", status));
            NPPException.CheckNppStatus(status, null);
        }

        /// <summary>
        /// Perspective transform of an image.<para/>
        /// This function performs perspective warping of a the specified
        /// quadrangle in the source image to the specified quadrangle in the
        /// destination image. The function nppiWarpPerspectiveQuad uses the same
        /// formulas for pixel mapping as in nppiWarpPerspective function. The
        /// transform coefficients are computed internally.
        /// The transformed part of the source image is resampled using the specified
        /// interpolation method and written to the destination ROI.<para/>
        /// NPPI specific recommendation: <para/>
        /// The function operates using 2 types of kernels: fast and accurate. The fast
        /// method is about 4 times faster than its accurate variant,
        /// but doesn't perform memory access checks and requires the destination ROI
        /// to be 64 bytes aligned. Hence any destination ROI is 
        /// chunked into 3 vertical stripes: the first and the third are processed by
        /// accurate kernels and the central one is processed by the fast one.
        /// In order to get the maximum available speed of execution, the projection of
        /// destination ROI onto image addresses must be 64 bytes aligned. This is
        /// always true if the values <para/>
        /// <code>(int)((void *)(pDst + dstRoi.x))</code> and <para/>
        /// <code>(int)((void *)(pDst + dstRoi.x + dstRoi.width))</code> <para/>
        /// are multiples of 64. Another rule of thumb is to specify destination ROI in
        /// such way that left and right sides of the projected image are separated from
        /// the ROI by at least 63 bytes from each side. However, this requires the
        /// whole ROI to be part of allocated memory. In case when the conditions above
        /// are not satisfied, the function may decrease in speed slightly and will
        /// return NPP_MISALIGNED_DST_ROI_WARNING warning.
        /// </summary>
        /// <param name="src0">Source image (Channel 0)</param>
        /// <param name="src1">Source image (Channel 1)</param>
        /// <param name="src2">Source image (Channel 2)</param>
        /// <param name="srcQuad">Source quadrangle [4,2]</param>
        /// <param name="dest0">Destination image (Channel 0)</param>
        /// <param name="dest1">Destination image (Channel 1)</param>
        /// <param name="dest2">Destination image (Channel 2)</param>
        /// <param name="destQuad">Destination quadrangle [4,2]</param>
        /// <param name="eInterpolation">Interpolation mode: can be <see cref="InterpolationMode.NearestNeighbor"/>, <see cref="InterpolationMode.Linear"/> or <see cref="InterpolationMode.Cubic"/></param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public static void WarpPerspectiveQuad(NPPImage_32sC1 src0, NPPImage_32sC1 src1, NPPImage_32sC1 src2, double[,] srcQuad, NPPImage_32sC1 dest0, NPPImage_32sC1 dest1, NPPImage_32sC1 dest2, double[,] destQuad, InterpolationMode eInterpolation, NppStreamContext nppStreamCtx)
        {
            NppiRect rectIn = new NppiRect(src0.PointRoi, src0.SizeRoi);
            NppiRect rectOut = new NppiRect(dest0.PointRoi, dest0.SizeRoi);

            CUdeviceptr[] src = new CUdeviceptr[] { src0.DevicePointer, src1.DevicePointer, src2.DevicePointer };
            CUdeviceptr[] dst = new CUdeviceptr[] { dest0.DevicePointer, dest1.DevicePointer, dest2.DevicePointer };

            NppStatus status = NPPNativeMethods_Ctx.NPPi.PerspectiveTransforms.nppiWarpPerspectiveQuad_32s_P4R_Ctx(src, src0.Size, src0.Pitch, rectIn, srcQuad, dst, dest0.Pitch, rectOut, destQuad, eInterpolation, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiWarpPerspectiveQuad_32s_P4R_Ctx", status));
            NPPException.CheckNppStatus(status, null);
        }
        #endregion

        #region Alpha Composition

        /// <summary>
        /// Four 8-bit unsigned char channel image composition using image alpha values (0 - max channel pixel value).
        /// </summary>
        /// <param name="src2">2nd source image</param>
        /// <param name="dest">Destination image</param>
        /// <param name="nppAlphaOp">alpha compositing operation</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void AlphaComp(NPPImage_32sC4 src2, NPPImage_32sC4 dest, NppiAlphaOp nppAlphaOp, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.AlphaComp.nppiAlphaComp_32s_AC4R_Ctx(_devPtrRoi, _pitch, src2.DevicePointerRoi, src2.Pitch, dest.DevicePointerRoi, dest.Pitch, _sizeRoi, nppAlphaOp, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiAlphaComp_32s_AC4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }

        #endregion



        #region DotProduct
        /// <summary>
        /// Device scratch buffer size (in bytes) for nppiDotProd_32s64f_C4R.
        /// </summary>
        /// <returns></returns>
        public SizeT DotProdGetBufferHostSize(NppStreamContext nppStreamCtx)
        {
            SizeT bufferSize = 0;
            status = NPPNativeMethods_Ctx.NPPi.DotProd.nppiDotProdGetBufferHostSize_32s64f_C4R_Ctx(_sizeRoi, ref bufferSize, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiDotProdGetBufferHostSize_32s64f_C4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
            return bufferSize;
        }

        /// <summary>
        /// Four-channel 32-bit unsigned image DotProd.
        /// </summary>
        /// <param name="src2">2nd source image</param>
        /// <param name="pDp">Pointer to the computed dot product of the two images. (4 * sizeof(double))</param>
        /// <param name="buffer">Allocated device memory with size of at <see cref="DotProdGetBufferHostSize()"/></param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void DotProduct(NPPImage_32sC4 src2, CudaDeviceVariable<double> pDp, CudaDeviceVariable<byte> buffer, NppStreamContext nppStreamCtx)
        {
            SizeT bufferSize = DotProdGetBufferHostSize(nppStreamCtx);
            if (bufferSize > buffer.Size) throw new NPPException("Provided buffer is too small.");

            status = NPPNativeMethods_Ctx.NPPi.DotProd.nppiDotProd_32s64f_C4R_Ctx(_devPtrRoi, _pitch, src2.DevicePointerRoi, src2.Pitch, _sizeRoi, pDp.DevicePointer, buffer.DevicePointer, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiDotProd_32s64f_C4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }

        /// <summary>
        /// Four-channel 32-bit unsigned image DotProd. Buffer is internally allocated and freed.
        /// </summary>
        /// <param name="src2">2nd source image</param>
        /// <param name="pDp">Pointer to the computed dot product of the two images. (4 * sizeof(double))</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void DotProduct(NPPImage_32sC4 src2, CudaDeviceVariable<double> pDp, NppStreamContext nppStreamCtx)
        {
            SizeT bufferSize = DotProdGetBufferHostSize(nppStreamCtx);
            CudaDeviceVariable<byte> buffer = new CudaDeviceVariable<byte>(bufferSize);

            status = NPPNativeMethods_Ctx.NPPi.DotProd.nppiDotProd_32s64f_C4R_Ctx(_devPtrRoi, _pitch, src2.DevicePointerRoi, src2.Pitch, _sizeRoi, pDp.DevicePointer, buffer.DevicePointer, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiDotProd_32s64f_C4R_Ctx", status));
            buffer.Dispose();
            NPPException.CheckNppStatus(status, this);
        }



        /// <summary>
        /// Device scratch buffer size (in bytes) for nppiDotProd_32s64f_C4R. Ignoring alpha channel.
        /// </summary>
        /// <returns></returns>
        public SizeT ADotProdGetBufferHostSize(NppStreamContext nppStreamCtx)
        {
            SizeT bufferSize = 0;
            status = NPPNativeMethods_Ctx.NPPi.DotProd.nppiDotProdGetBufferHostSize_32s64f_AC4R_Ctx(_sizeRoi, ref bufferSize, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiDotProdGetBufferHostSize_32s64f_AC4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
            return bufferSize;
        }

        /// <summary>
        /// Four-channel 32-bit unsigned image DotProd. Ignoring alpha channel.
        /// </summary>
        /// <param name="src2">2nd source image</param>
        /// <param name="pDp">Pointer to the computed dot product of the two images. (3 * sizeof(double))</param>
        /// <param name="buffer">Allocated device memory with size of at <see cref="ADotProdGetBufferHostSize()"/></param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void ADotProduct(NPPImage_32sC4 src2, CudaDeviceVariable<double> pDp, CudaDeviceVariable<byte> buffer, NppStreamContext nppStreamCtx)
        {
            SizeT bufferSize = DotProdGetBufferHostSize(nppStreamCtx);
            if (bufferSize > buffer.Size) throw new NPPException("Provided buffer is too small.");

            status = NPPNativeMethods_Ctx.NPPi.DotProd.nppiDotProd_32s64f_AC4R_Ctx(_devPtrRoi, _pitch, src2.DevicePointerRoi, src2.Pitch, _sizeRoi, pDp.DevicePointer, buffer.DevicePointer, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiDotProd_32s64f_AC4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }

        /// <summary>
        /// Four-channel 32-bit unsigned image DotProd. Buffer is internally allocated and freed. Ignoring alpha channel.
        /// </summary>
        /// <param name="src2">2nd source image</param>
        /// <param name="pDp">Pointer to the computed dot product of the two images. (3 * sizeof(double))</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void ADotProduct(NPPImage_32sC4 src2, CudaDeviceVariable<double> pDp, NppStreamContext nppStreamCtx)
        {
            SizeT bufferSize = DotProdGetBufferHostSize(nppStreamCtx);
            CudaDeviceVariable<byte> buffer = new CudaDeviceVariable<byte>(bufferSize);

            status = NPPNativeMethods_Ctx.NPPi.DotProd.nppiDotProd_32s64f_AC4R_Ctx(_devPtrRoi, _pitch, src2.DevicePointerRoi, src2.Pitch, _sizeRoi, pDp.DevicePointer, buffer.DevicePointer, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiDotProd_32s64f_AC4R_Ctx", status));
            buffer.Dispose();
            NPPException.CheckNppStatus(status, this);
        }
        #endregion

        #region Copy

        /// <summary>
        /// Copy image and pad borders with a constant, user-specifiable color. Not affecting Alpha channel.
        /// </summary>
        /// <param name="dst">Destination image. The image ROI defines the destination region, i.e. the region that gets filled with data from
        /// the source image (inner part) and constant border color (outer part).</param>
        /// <param name="nTopBorderHeight">Height (in pixels) of the top border. The height of the border at the bottom of
        /// the destination ROI is implicitly defined by the size of the source ROI: nBottomBorderHeight =
        /// oDstSizeROI.height - nTopBorderHeight - oSrcSizeROI.height.</param>
        /// <param name="nLeftBorderWidth">Width (in pixels) of the left border. The width of the border at the right side of
        /// the destination ROI is implicitly defined by the size of the source ROI: nRightBorderWidth =
        /// oDstSizeROI.width - nLeftBorderWidth - oSrcSizeROI.width.</param>
        /// <param name="nValue">The pixel value to be set for border pixels.</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void CopyConstBorderA(NPPImage_32sC4 dst, int nTopBorderHeight, int nLeftBorderWidth, int[] nValue, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.CopyConstBorder.nppiCopyConstBorder_32s_AC4R_Ctx(_devPtrRoi, _pitch, _sizeRoi, dst.DevicePointerRoi, dst.Pitch, dst.SizeRoi, nTopBorderHeight, nLeftBorderWidth, nValue, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiCopyConstBorder_32s_AC4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }

        /// <summary>
        /// image copy with nearest source image pixel color. Not affecting Alpha.
        /// </summary>
        /// <param name="dst">Destination-Image</param>
        /// <param name="nTopBorderHeight">Height (in pixels) of the top border. The height of the border at the bottom of
        /// the destination ROI is implicitly defined by the size of the source ROI: nBottomBorderHeight =
        /// oDstSizeROI.height - nTopBorderHeight - oSrcSizeROI.height.</param>
        /// <param name="nLeftBorderWidth">Width (in pixels) of the left border. The width of the border at the right side of
        /// <param name="nppStreamCtx">NPP stream context.</param>
        /// the destination ROI is implicitly defined by the size of the source ROI: nRightBorderWidth =
        /// oDstSizeROI.width - nLeftBorderWidth - oSrcSizeROI.width.</param>
        public void CopyReplicateBorderA(NPPImage_32sC4 dst, int nTopBorderHeight, int nLeftBorderWidth, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.CopyReplicateBorder.nppiCopyReplicateBorder_32s_AC4R_Ctx(_devPtrRoi, _pitch, _sizeRoi, dst.DevicePointerRoi, dst.Pitch, dst.SizeRoi, nTopBorderHeight, nLeftBorderWidth, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiCopyReplicateBorder_32s_AC4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }
        /// <summary>
        /// image copy with the borders wrapped by replication of source image pixel colors. Not affecting Alpha.
        /// </summary>
        /// <param name="dst">Destination-Image</param>
        /// <param name="nTopBorderHeight">Height (in pixels) of the top border. The height of the border at the bottom of
        /// the destination ROI is implicitly defined by the size of the source ROI: nBottomBorderHeight =
        /// oDstSizeROI.height - nTopBorderHeight - oSrcSizeROI.height.</param>
        /// <param name="nLeftBorderWidth">Width (in pixels) of the left border. The width of the border at the right side of
        /// <param name="nppStreamCtx">NPP stream context.</param>
        /// the destination ROI is implicitly defined by the size of the source ROI: nRightBorderWidth =
        /// oDstSizeROI.width - nLeftBorderWidth - oSrcSizeROI.width.</param>
        public void CopyWrapBorderA(NPPImage_32sC4 dst, int nTopBorderHeight, int nLeftBorderWidth, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.CopyWrapBorder.nppiCopyWrapBorder_32s_AC4R_Ctx(_devPtrRoi, _pitch, _sizeRoi, dst.DevicePointerRoi, dst.Pitch, dst.SizeRoi, nTopBorderHeight, nLeftBorderWidth, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiCopyWrapBorder_32s_AC4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }
        /// <summary>
        /// linearly interpolated source image subpixel coordinate color copy. Not affecting Alpha.
        /// </summary>
        /// <param name="dst">Destination-Image</param>
        /// <param name="nDx">Fractional part of source image X coordinate.</param>
        /// <param name="nDy">Fractional part of source image Y coordinate.</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void CopySubpixA(NPPImage_32sC4 dst, float nDx, float nDy, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.CopySubpix.nppiCopySubpix_32s_AC4R_Ctx(_devPtrRoi, _pitch, dst.DevicePointerRoi, dst.Pitch, _sizeRoi, nDx, nDy, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiCopySubpix_32s_AC4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }
        /// <summary>
        /// Copy image and pad borders with a constant, user-specifiable color.
        /// </summary>
        /// <param name="dst">Destination image. The image ROI defines the destination region, i.e. the region that gets filled with data from
        /// the source image (inner part) and constant border color (outer part).</param>
        /// <param name="nTopBorderHeight">Height (in pixels) of the top border. The height of the border at the bottom of
        /// the destination ROI is implicitly defined by the size of the source ROI: nBottomBorderHeight =
        /// oDstSizeROI.height - nTopBorderHeight - oSrcSizeROI.height.</param>
        /// <param name="nLeftBorderWidth">Width (in pixels) of the left border. The width of the border at the right side of
        /// the destination ROI is implicitly defined by the size of the source ROI: nRightBorderWidth =
        /// oDstSizeROI.width - nLeftBorderWidth - oSrcSizeROI.width.</param>
        /// <param name="nValue">The pixel value to be set for border pixels.</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void Copy(NPPImage_32sC4 dst, int nTopBorderHeight, int nLeftBorderWidth, int[] nValue, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.CopyConstBorder.nppiCopyConstBorder_32s_C4R_Ctx(_devPtrRoi, _pitch, _sizeRoi, dst.DevicePointerRoi, dst.Pitch, dst.SizeRoi, nTopBorderHeight, nLeftBorderWidth, nValue, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiCopyConstBorder_32s_C4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }

        /// <summary>
        /// image copy with nearest source image pixel color.
        /// </summary>
        /// <param name="dst">Destination-Image</param>
        /// <param name="nTopBorderHeight">Height (in pixels) of the top border. The height of the border at the bottom of
        /// the destination ROI is implicitly defined by the size of the source ROI: nBottomBorderHeight =
        /// oDstSizeROI.height - nTopBorderHeight - oSrcSizeROI.height.</param>
        /// <param name="nLeftBorderWidth">Width (in pixels) of the left border. The width of the border at the right side of
        /// <param name="nppStreamCtx">NPP stream context.</param>
        /// the destination ROI is implicitly defined by the size of the source ROI: nRightBorderWidth =
        /// oDstSizeROI.width - nLeftBorderWidth - oSrcSizeROI.width.</param>
        public void CopyReplicateBorder(NPPImage_32sC4 dst, int nTopBorderHeight, int nLeftBorderWidth, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.CopyReplicateBorder.nppiCopyReplicateBorder_32s_C4R_Ctx(_devPtrRoi, _pitch, _sizeRoi, dst.DevicePointerRoi, dst.Pitch, dst.SizeRoi, nTopBorderHeight, nLeftBorderWidth, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiCopyReplicateBorder_32s_C4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }
        /// <summary>
        /// image copy with the borders wrapped by replication of source image pixel colors.
        /// </summary>
        /// <param name="dst">Destination-Image</param>
        /// <param name="nTopBorderHeight">Height (in pixels) of the top border. The height of the border at the bottom of
        /// the destination ROI is implicitly defined by the size of the source ROI: nBottomBorderHeight =
        /// oDstSizeROI.height - nTopBorderHeight - oSrcSizeROI.height.</param>
        /// <param name="nLeftBorderWidth">Width (in pixels) of the left border. The width of the border at the right side of
        /// <param name="nppStreamCtx">NPP stream context.</param>
        /// the destination ROI is implicitly defined by the size of the source ROI: nRightBorderWidth =
        /// oDstSizeROI.width - nLeftBorderWidth - oSrcSizeROI.width.</param>
        public void CopyWrapBorder(NPPImage_32sC4 dst, int nTopBorderHeight, int nLeftBorderWidth, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.CopyWrapBorder.nppiCopyWrapBorder_32s_C4R_Ctx(_devPtrRoi, _pitch, _sizeRoi, dst.DevicePointerRoi, dst.Pitch, dst.SizeRoi, nTopBorderHeight, nLeftBorderWidth, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiCopyWrapBorder_32s_C4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }
        /// <summary>
        /// linearly interpolated source image subpixel coordinate color copy.
        /// </summary>
        /// <param name="dst">Destination-Image</param>
        /// <param name="nDx">Fractional part of source image X coordinate.</param>
        /// <param name="nDy">Fractional part of source image Y coordinate.</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void CopySubpix(NPPImage_32sC4 dst, float nDx, float nDy, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.CopySubpix.nppiCopySubpix_32s_C4R_Ctx(_devPtrRoi, _pitch, dst.DevicePointerRoi, dst.Pitch, _sizeRoi, nDx, nDy, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiCopySubpix_32s_C4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }
        #endregion

        #region MirrorNew


        /// <summary>
        /// Mirror image inplace. Not affecting Alpha.
        /// </summary>
        /// <param name="flip">Specifies the axis about which the image is to be mirrored.</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void MirrorA(NppiAxis flip, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.GeometricTransforms.nppiMirror_32s_AC4IR_Ctx(_devPtrRoi, _pitch, _sizeRoi, flip, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiMirror_32s_AC4IR_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }

        /// <summary>
        /// Mirror image.
        /// </summary>
        /// <param name="flip">Specifies the axis about which the image is to be mirrored.</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void Mirror(NppiAxis flip, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.GeometricTransforms.nppiMirror_32s_C4IR_Ctx(_devPtrRoi, _pitch, _sizeRoi, flip, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiMirror_32s_C4IR_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }
        #endregion

        #region SwapChannel
        /// <summary>
        /// Swap channels. Not affecting Alpha
        /// </summary>
        /// <param name="dest">Destination image</param>
        /// <param name="aDstOrder">Integer array describing how channel values are permutated. The n-th entry of the array contains the number of the channel that is stored in the n-th channel of
        /// <param name="nppStreamCtx">NPP stream context.</param>
        /// the output image. E.g. Given an RGBA image, aDstOrder = [2,1,0] converts this to BGRA
        /// channel order. In the AC4R case, the alpha channel is always assumed to be channel 3.
        /// </param>
        public void SwapChannelsA(NPPImage_32sC4 dest, int[] aDstOrder, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.SwapChannel.nppiSwapChannels_32s_AC4R_Ctx(_devPtrRoi, _pitch, dest.DevicePointerRoi, dest.Pitch, _sizeRoi, aDstOrder, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiSwapChannels_32s_AC4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }

        /// <summary>
        /// Swap channels.
        /// </summary>
        /// <param name="dest">Destination image</param>
        /// <param name="aDstOrder">Host memory integer array describing how channel values are permutated. The n-th entry
        /// <param name="nppStreamCtx">NPP stream context.</param>
        /// of the array contains the number of the channel that is stored in the n-th channel of
        /// the output image. <para/>E.g. Given an RGBA image, aDstOrder = [2,1,0] converts this to a 3 channel BGR
        /// channel order.</param>
        public void SwapChannels(NPPImage_32sC3 dest, int[] aDstOrder, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.SwapChannel.nppiSwapChannels_32s_C4C3R_Ctx(_devPtrRoi, _pitch, dest.DevicePointerRoi, dest.Pitch, _sizeRoi, aDstOrder, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiSwapChannels_32s_C4C3R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }

        /// <summary>
        /// Swap channels, in-place.
        /// </summary>
        /// <param name="aDstOrder">Integer array describing how channel values are permutated. The n-th entry of the array
        /// <param name="nppStreamCtx">NPP stream context.</param>
        /// contains the number of the channel that is stored in the n-th channel of the output image. E.g.
        /// Given an RGBA image, aDstOrder = [3,2,1,0] converts this to ABGR channel order.</param>
        public void SwapChannels(int[] aDstOrder, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.SwapChannel.nppiSwapChannels_32s_C4IR_Ctx(_devPtrRoi, _pitch, _sizeRoi, aDstOrder, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiSwapChannels_32s_C4IR_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }

        /// <summary>
        /// Swap channels.
        /// </summary>
        /// <param name="dest">Destination image</param>
        /// <param name="aDstOrder">Integer array describing how channel values are permutated. The n-th entry of the array
        /// <param name="nppStreamCtx">NPP stream context.</param>
        /// contains the number of the channel that is stored in the n-th channel of the output image. E.g.
        /// Given an RGBA image, aDstOrder = [3,2,1,0] converts this to ABGR channel order.</param>
        public void SwapChannels(NPPImage_32sC4 dest, int[] aDstOrder, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.SwapChannel.nppiSwapChannels_32s_C4R_Ctx(_devPtrRoi, _pitch, dest.DevicePointerRoi, dest.Pitch, _sizeRoi, aDstOrder, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiSwapChannels_32s_C4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }
        #endregion

        #region Filter


        /// <summary>
        /// convolution filter. Not affecting Alpha.
        /// </summary>
        /// <param name="dst">Destination-Image</param>
        /// <param name="pKernel">Pointer to the start address of the kernel coefficient array.<para/>
        /// Coefficients are expected to be stored in reverse order.</param>
        /// <param name="oKernelSize">Width and Height of the rectangular kernel.</param>
        /// <param name="oAnchor">X and Y offsets of the kernel origin frame of reference</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void FilterA(NPPImage_32sC4 dst, CudaDeviceVariable<float> pKernel, NppiSize oKernelSize, NppiPoint oAnchor, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.Convolution.nppiFilter32f_32s_AC4R_Ctx(_devPtrRoi, _pitch, dst.DevicePointerRoi, dst.Pitch, _sizeRoi, pKernel.DevicePointer, oKernelSize, oAnchor, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiFilter32f_32s_AC4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }

        /// <summary>
        /// convolution filter.
        /// </summary>
        /// <param name="dst">Destination-Image</param>
        /// <param name="pKernel">Pointer to the start address of the kernel coefficient array.<para/>
        /// Coefficients are expected to be stored in reverse order.</param>
        /// <param name="oKernelSize">Width and Height of the rectangular kernel.</param>
        /// <param name="oAnchor">X and Y offsets of the kernel origin frame of reference</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void Filter(NPPImage_32sC4 dst, CudaDeviceVariable<float> pKernel, NppiSize oKernelSize, NppiPoint oAnchor, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.Convolution.nppiFilter32f_32s_C4R_Ctx(_devPtrRoi, _pitch, dst.DevicePointerRoi, dst.Pitch, _sizeRoi, pKernel.DevicePointer, oKernelSize, oAnchor, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiFilter32f_32s_C4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }
        #endregion

        #region Scale


        /// <summary>
        /// image conversion. Not affecting Alpha.
        /// </summary>
        /// <param name="dst">Destination-Image</param>
        /// <param name="hint">algorithm performance or accuracy selector, currently ignored</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void ScaleA(NPPImage_8uC4 dst, NppHintAlgorithm hint, NppStreamContext nppStreamCtx)
        {
            NppiRect srcRect = new NppiRect(_pointRoi, _sizeRoi);
            status = NPPNativeMethods_Ctx.NPPi.Scale.nppiScale_32s8u_AC4R_Ctx(_devPtrRoi, _pitch, dst.DevicePointerRoi, dst.Pitch, _sizeRoi, hint, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiScale_32s8u_AC4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }

        /// <summary>
        /// image conversion.
        /// </summary>
        /// <param name="dst">Destination-Image</param>
        /// <param name="hint">algorithm performance or accuracy selector, currently ignored</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void Scale(NPPImage_8uC4 dst, NppHintAlgorithm hint, NppStreamContext nppStreamCtx)
        {
            NppiRect srcRect = new NppiRect(_pointRoi, _sizeRoi);
            status = NPPNativeMethods_Ctx.NPPi.Scale.nppiScale_32s8u_C4R_Ctx(_devPtrRoi, _pitch, dst.DevicePointerRoi, dst.Pitch, _sizeRoi, hint, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiScale_32s8u_C4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }
        #endregion

        #region Transpose
        /// <summary>
        /// image transpose
        /// </summary>
        /// <param name="dest">Destination image</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void Transpose(NPPImage_32sC4 dest, NppStreamContext nppStreamCtx)
        {
            status = NPPNativeMethods_Ctx.NPPi.Transpose.nppiTranspose_32s_C4R_Ctx(_devPtrRoi, _pitch, dest.DevicePointerRoi, dest.Pitch, _sizeRoi, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiTranspose_32s_C4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }
        #endregion

        #region MaxError
        /// <summary>
        /// image maximum error. User buffer is internally allocated and freed.
        /// </summary>
        /// <param name="src2">2nd source image</param>
        /// <param name="pError">Pointer to the computed error.</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void MaxError(NPPImage_32sC4 src2, CudaDeviceVariable<double> pError, NppStreamContext nppStreamCtx)
        {
            SizeT bufferSize = MaxErrorGetBufferHostSize(nppStreamCtx);
            CudaDeviceVariable<byte> buffer = new CudaDeviceVariable<byte>(bufferSize);
            status = NPPNativeMethods_Ctx.NPPi.MaximumError.nppiMaximumError_32s_C4R_Ctx(_devPtrRoi, _pitch, src2.DevicePointerRoi, src2.Pitch, _sizeRoi, pError.DevicePointer, buffer.DevicePointer, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiMaximumError_32s_C4R_Ctx", status));
            buffer.Dispose();
            NPPException.CheckNppStatus(status, this);
        }

        /// <summary>
        /// image maximum error.
        /// </summary>
        /// <param name="src2">2nd source image</param>
        /// <param name="pError">Pointer to the computed error.</param>
        /// <param name="buffer">Pointer to the user-allocated scratch buffer required for the MaxError operation.</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void MaxError(NPPImage_32sC4 src2, CudaDeviceVariable<double> pError, CudaDeviceVariable<byte> buffer, NppStreamContext nppStreamCtx)
        {
            SizeT bufferSize = MaxErrorGetBufferHostSize(nppStreamCtx);
            if (bufferSize > buffer.Size) throw new NPPException("Provided buffer is too small.");

            status = NPPNativeMethods_Ctx.NPPi.MaximumError.nppiMaximumError_32s_C4R_Ctx(_devPtrRoi, _pitch, src2.DevicePointerRoi, src2.Pitch, _sizeRoi, pError.DevicePointer, buffer.DevicePointer, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiMaximumError_32s_C4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }
        /// <summary>
        /// Device scratch buffer size (in bytes) for MaxError.
        /// </summary>
        /// <returns></returns>
        public SizeT MaxErrorGetBufferHostSize(NppStreamContext nppStreamCtx)
        {
            SizeT bufferSize = 0;
            status = NPPNativeMethods_Ctx.NPPi.MaximumError.nppiMaximumErrorGetBufferHostSize_32s_C4R_Ctx(_sizeRoi, ref bufferSize, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiMaximumErrorGetBufferHostSize_32s_C4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
            return bufferSize;
        }
        #endregion

        #region AverageError
        /// <summary>
        /// image average error. User buffer is internally allocated and freed.
        /// </summary>
        /// <param name="src2">2nd source image</param>
        /// <param name="pError">Pointer to the computed error.</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void AverageError(NPPImage_32sC4 src2, CudaDeviceVariable<double> pError, NppStreamContext nppStreamCtx)
        {
            SizeT bufferSize = AverageErrorGetBufferHostSize(nppStreamCtx);
            CudaDeviceVariable<byte> buffer = new CudaDeviceVariable<byte>(bufferSize);
            status = NPPNativeMethods_Ctx.NPPi.AverageError.nppiAverageError_32s_C4R_Ctx(_devPtrRoi, _pitch, src2.DevicePointerRoi, src2.Pitch, _sizeRoi, pError.DevicePointer, buffer.DevicePointer, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiAverageError_32s_C4R_Ctx", status));
            buffer.Dispose();
            NPPException.CheckNppStatus(status, this);
        }

        /// <summary>
        /// image average error.
        /// </summary>
        /// <param name="src2">2nd source image</param>
        /// <param name="pError">Pointer to the computed error.</param>
        /// <param name="buffer">Pointer to the user-allocated scratch buffer required for the AverageError operation.</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void AverageError(NPPImage_32sC4 src2, CudaDeviceVariable<double> pError, CudaDeviceVariable<byte> buffer, NppStreamContext nppStreamCtx)
        {
            SizeT bufferSize = AverageErrorGetBufferHostSize(nppStreamCtx);
            if (bufferSize > buffer.Size) throw new NPPException("Provided buffer is too small.");

            status = NPPNativeMethods_Ctx.NPPi.AverageError.nppiAverageError_32s_C4R_Ctx(_devPtrRoi, _pitch, src2.DevicePointerRoi, src2.Pitch, _sizeRoi, pError.DevicePointer, buffer.DevicePointer, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiAverageError_32s_C4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }
        /// <summary>
        /// Device scratch buffer size (in bytes) for AverageError.
        /// </summary>
        /// <returns></returns>
        public SizeT AverageErrorGetBufferHostSize(NppStreamContext nppStreamCtx)
        {
            SizeT bufferSize = 0;
            status = NPPNativeMethods_Ctx.NPPi.AverageError.nppiAverageErrorGetBufferHostSize_32s_C4R_Ctx(_sizeRoi, ref bufferSize, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiAverageErrorGetBufferHostSize_32s_C4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
            return bufferSize;
        }
        #endregion

        #region MaximumRelative_Error
        /// <summary>
        /// image maximum relative error. User buffer is internally allocated and freed.
        /// </summary>
        /// <param name="src2">2nd source image</param>
        /// <param name="pError">Pointer to the computed error.</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void MaximumRelativeError(NPPImage_32sC4 src2, CudaDeviceVariable<double> pError, NppStreamContext nppStreamCtx)
        {
            SizeT bufferSize = MaximumRelativeErrorGetBufferHostSize(nppStreamCtx);
            CudaDeviceVariable<byte> buffer = new CudaDeviceVariable<byte>(bufferSize);
            status = NPPNativeMethods_Ctx.NPPi.MaximumRelativeError.nppiMaximumRelativeError_32s_C4R_Ctx(_devPtrRoi, _pitch, src2.DevicePointerRoi, src2.Pitch, _sizeRoi, pError.DevicePointer, buffer.DevicePointer, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiMaximumRelativeError_32s_C4R_Ctx", status));
            buffer.Dispose();
            NPPException.CheckNppStatus(status, this);
        }

        /// <summary>
        /// image maximum relative error.
        /// </summary>
        /// <param name="src2">2nd source image</param>
        /// <param name="pError">Pointer to the computed error.</param>
        /// <param name="buffer">Pointer to the user-allocated scratch buffer required for the MaximumRelativeError operation.</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void MaximumRelativeError(NPPImage_32sC4 src2, CudaDeviceVariable<double> pError, CudaDeviceVariable<byte> buffer, NppStreamContext nppStreamCtx)
        {
            SizeT bufferSize = MaximumRelativeErrorGetBufferHostSize(nppStreamCtx);
            if (bufferSize > buffer.Size) throw new NPPException("Provided buffer is too small.");

            status = NPPNativeMethods_Ctx.NPPi.MaximumRelativeError.nppiMaximumRelativeError_32s_C4R_Ctx(_devPtrRoi, _pitch, src2.DevicePointerRoi, src2.Pitch, _sizeRoi, pError.DevicePointer, buffer.DevicePointer, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiMaximumRelativeError_32s_C4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }
        /// <summary>
        /// Device scratch buffer size (in bytes) for MaximumRelativeError.
        /// </summary>
        /// <returns></returns>
        public SizeT MaximumRelativeErrorGetBufferHostSize(NppStreamContext nppStreamCtx)
        {
            SizeT bufferSize = 0;
            status = NPPNativeMethods_Ctx.NPPi.MaximumRelativeError.nppiMaximumRelativeErrorGetBufferHostSize_32s_C4R_Ctx(_sizeRoi, ref bufferSize, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiMaximumRelativeErrorGetBufferHostSize_32s_C4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
            return bufferSize;
        }
        #endregion

        #region AverageRelative_Error
        /// <summary>
        /// image average relative error. User buffer is internally allocated and freed.
        /// </summary>
        /// <param name="src2">2nd source image</param>
        /// <param name="pError">Pointer to the computed error.</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void AverageRelativeError(NPPImage_32sC4 src2, CudaDeviceVariable<double> pError, NppStreamContext nppStreamCtx)
        {
            SizeT bufferSize = AverageRelativeErrorGetBufferHostSize(nppStreamCtx);
            CudaDeviceVariable<byte> buffer = new CudaDeviceVariable<byte>(bufferSize);
            status = NPPNativeMethods_Ctx.NPPi.AverageRelativeError.nppiAverageRelativeError_32s_C4R_Ctx(_devPtrRoi, _pitch, src2.DevicePointerRoi, src2.Pitch, _sizeRoi, pError.DevicePointer, buffer.DevicePointer, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiAverageRelativeError_32s_C4R_Ctx", status));
            buffer.Dispose();
            NPPException.CheckNppStatus(status, this);
        }

        /// <summary>
        /// image average relative error.
        /// </summary>
        /// <param name="src2">2nd source image</param>
        /// <param name="pError">Pointer to the computed error.</param>
        /// <param name="buffer">Pointer to the user-allocated scratch buffer required for the AverageRelativeError operation.</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void AverageRelativeError(NPPImage_32sC4 src2, CudaDeviceVariable<double> pError, CudaDeviceVariable<byte> buffer, NppStreamContext nppStreamCtx)
        {
            SizeT bufferSize = AverageRelativeErrorGetBufferHostSize(nppStreamCtx);
            if (bufferSize > buffer.Size) throw new NPPException("Provided buffer is too small.");

            status = NPPNativeMethods_Ctx.NPPi.AverageRelativeError.nppiAverageRelativeError_32s_C4R_Ctx(_devPtrRoi, _pitch, src2.DevicePointerRoi, src2.Pitch, _sizeRoi, pError.DevicePointer, buffer.DevicePointer, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiAverageRelativeError_32s_C4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }
        /// <summary>
        /// Device scratch buffer size (in bytes) for AverageRelativeError.
        /// </summary>
        /// <returns></returns>
        public SizeT AverageRelativeErrorGetBufferHostSize(NppStreamContext nppStreamCtx)
        {
            SizeT bufferSize = 0;
            status = NPPNativeMethods_Ctx.NPPi.AverageRelativeError.nppiAverageRelativeErrorGetBufferHostSize_32s_C4R_Ctx(_sizeRoi, ref bufferSize, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiAverageRelativeErrorGetBufferHostSize_32s_C4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
            return bufferSize;
        }
        #endregion

        #region FilterBorder
        /// <summary>
        /// Four channel 32-bit signed convolution filter with border control.<para/>
        /// General purpose 2D convolution filter using floating-point weights with border control.<para/>
        /// Pixels under the mask are multiplied by the respective weights in the mask
        /// and the results are summed. Before writing the result pixel the sum is scaled
        /// back via division by nDivisor. If any portion of the mask overlaps the source
        /// image boundary the requested border type operation is applied to all mask pixels
        /// which fall outside of the source image. <para/>
        /// </summary>
        /// <param name="dest">Destination image</param>
        /// <param name="pKernel">Pointer to the start address of the kernel coefficient array. Coeffcients are expected to be stored in reverse order</param>
        /// <param name="nKernelSize">Width and Height of the rectangular kernel.</param>
        /// <param name="oAnchor">X and Y offsets of the kernel origin frame of reference relative to the source pixel.</param>
        /// <param name="eBorderType">The border type operation to be applied at source image border boundaries.</param>
        /// <param name="filterArea">The area where the filter is allowed to read pixels. The point is relative to the ROI set to source image, the size is the total size starting from the filterArea point. Default value is the set ROI.</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void FilterBorder(NPPImage_32sC4 dest, CudaDeviceVariable<float> pKernel, NppiSize nKernelSize, NppiPoint oAnchor, NppiBorderType eBorderType, NppStreamContext nppStreamCtx, NppiRect filterArea = new NppiRect())
        {
            if (filterArea.Size == new NppiSize())
            {
                filterArea.Size = _sizeRoi;
            }
            status = NPPNativeMethods_Ctx.NPPi.FilterBorder32f.nppiFilterBorder32f_32s_C4R_Ctx(_devPtrRoi, _pitch, filterArea.Size, filterArea.Location, dest.DevicePointerRoi, dest.Pitch, dest.SizeRoi, pKernel.DevicePointer, nKernelSize, oAnchor, eBorderType, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiFilterBorder32f_32s_C4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }


        /// <summary>
        /// Four channel 32-bit signed convolution filter with border control, ignoring alpha channel.<para/>
        /// General purpose 2D convolution filter using floating-point weights with border control.<para/>
        /// Pixels under the mask are multiplied by the respective weights in the mask
        /// and the results are summed. Before writing the result pixel the sum is scaled
        /// back via division by nDivisor. If any portion of the mask overlaps the source
        /// image boundary the requested border type operation is applied to all mask pixels
        /// which fall outside of the source image. <para/>
        /// </summary>
        /// <param name="dest">Destination image</param>
        /// <param name="pKernel">Pointer to the start address of the kernel coefficient array. Coeffcients are expected to be stored in reverse order</param>
        /// <param name="nKernelSize">Width and Height of the rectangular kernel.</param>
        /// <param name="oAnchor">X and Y offsets of the kernel origin frame of reference relative to the source pixel.</param>
        /// <param name="eBorderType">The border type operation to be applied at source image border boundaries.</param>
        /// <param name="filterArea">The area where the filter is allowed to read pixels. The point is relative to the ROI set to source image, the size is the total size starting from the filterArea point. Default value is the set ROI.</param>
        /// <param name="nppStreamCtx">NPP stream context.</param>
        public void FilterBorderA(NPPImage_32sC4 dest, CudaDeviceVariable<float> pKernel, NppiSize nKernelSize, NppiPoint oAnchor, NppiBorderType eBorderType, NppStreamContext nppStreamCtx, NppiRect filterArea = new NppiRect())
        {
            if (filterArea.Size == new NppiSize())
            {
                filterArea.Size = _sizeRoi;
            }
            status = NPPNativeMethods_Ctx.NPPi.FilterBorder32f.nppiFilterBorder32f_32s_AC4R_Ctx(_devPtrRoi, _pitch, filterArea.Size, filterArea.Location, dest.DevicePointerRoi, dest.Pitch, dest.SizeRoi, pKernel.DevicePointer, nKernelSize, oAnchor, eBorderType, nppStreamCtx);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "nppiFilterBorder32f_32s_AC4R_Ctx", status));
            NPPException.CheckNppStatus(status, this);
        }
        #endregion

    }
}
