﻿// Copyright (c) 2023, Michael Kunz and Artic Imaging SARL. All rights reserved.
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


using System;
using System.Diagnostics;
using ManagedCuda.BasicTypes;

namespace ManagedCuda.CudaFFT
{
    /// <summary>
    /// Creates a 1D FFT plan configuration for a specified signal size and data
    /// type. The <c>batch</c> input parameter tells CUFFT how many 1D
    /// transforms to configure.
    /// </summary>
    public class CudaFFTPlan1D : IDisposable
    {
        private cufftHandle _handle;
        private cufftResult res;
        private bool disposed;
        private int _nx;
        private cufftType _type;
        private int _batch;

        #region Contructors
        /// <summary>
        /// Creates a new 1D FFT plan (old API)
        /// </summary>
        /// <param name="nx">The transform size (e.g., 256 for a 256-point FFT)</param>
        /// <param name="type">The transform data type (e.g., C2C for complex to complex)</param>
        /// <param name="batch">Number of transforms of size nx</param>
        public CudaFFTPlan1D(int nx, cufftType type, int batch)
        {
            _handle = new cufftHandle();
            _nx = nx;
            _type = type;
            _batch = batch;
            res = CudaFFTNativeMethods.cufftPlan1d(ref _handle, nx, type, batch);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "cufftPlan1d", res));
            if (res != cufftResult.Success)
                throw new CudaFFTException(res);
        }

        /// <summary>
		/// Creates a new 1D FFT plan (old API)
        /// </summary>
        /// <param name="nx">The transform size (e.g., 256 for a 256-point FFT)</param>
        /// <param name="type">The transform data type (e.g., C2C for complex to complex)</param>
        /// <param name="batch">Number of transforms of size nx</param>
        /// <param name="stream">A valid CUDA stream created with cudaStreamCreate() (or 0 for the default stream)</param>
        public CudaFFTPlan1D(int nx, cufftType type, int batch, CUstream stream)
            : this(nx, type, batch)
        {
            SetStream(stream);
        }

        /// <summary>
        /// Creates a new 1D FFT plan (new API)
        /// </summary>
        /// <param name="handle">cufftHandle object</param>
        /// <param name="nx">The transform size (e.g., 256 for a 256-point FFT)</param>
        /// <param name="type">The transform data type (e.g., C2C for complex to complex)</param>
        /// <param name="batch">Number of transforms of size nx</param>
        /// <param name="size"></param>
        public CudaFFTPlan1D(cufftHandle handle, int nx, cufftType type, int batch, ref SizeT size)
        {
            _handle = handle;
            _nx = nx;
            _type = type;
            _batch = batch;
            res = CudaFFTNativeMethods.cufftMakePlan1d(_handle, nx, type, batch, ref size);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "cufftMakePlan1d", res));
            if (res != cufftResult.Success)
                throw new CudaFFTException(res);
        }

        /// <summary>
        /// Creates a new 1D FFT plan (new API)
        /// </summary>
        /// <param name="handle">cufftHandle object</param>
        /// <param name="nx">The transform size (e.g., 256 for a 256-point FFT)</param>
        /// <param name="type">The transform data type (e.g., C2C for complex to complex)</param>
        /// <param name="batch">Number of transforms of size nx</param>
        public CudaFFTPlan1D(cufftHandle handle, int nx, cufftType type, int batch)
        {
            SizeT size = new SizeT();
            _handle = handle;
            _nx = nx;
            _type = type;
            _batch = batch;
            res = CudaFFTNativeMethods.cufftMakePlan1d(_handle, nx, type, batch, ref size);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "cufftMakePlan1d", res));
            if (res != cufftResult.Success)
                throw new CudaFFTException(res);
        }

        /// <summary>
        /// Creates a new 1D FFT plan (new API)
        /// </summary>
        /// <param name="handle">cufftHandle object</param>
        /// <param name="nx">The transform size (e.g., 256 for a 256-point FFT)</param>
        /// <param name="type">The transform data type (e.g., C2C for complex to complex)</param>
        /// <param name="batch">Number of transforms of size nx</param>
        /// <param name="stream">A valid CUDA stream created with cudaStreamCreate() (or 0 for the default stream)</param>
        public CudaFFTPlan1D(cufftHandle handle, int nx, cufftType type, int batch, CUstream stream)
            : this(handle, nx, type, batch)
        {
            SetStream(stream);
        }




        /// <summary>
        /// Creates a new 1D FFT plan (new API)
        /// </summary>
        /// <param name="handle">cufftHandle object</param>
        /// <param name="nx">The transform size (e.g., 256 for a 256-point FFT)</param>
        /// <param name="type">The transform data type (e.g., C2C for complex to complex)</param>
        /// <param name="batch">Number of transforms of size nx</param>
        /// <param name="stream">A valid CUDA stream created with cudaStreamCreate() (or 0 for the default stream)</param>
        /// <param name="size"></param>
        public CudaFFTPlan1D(cufftHandle handle, int nx, cufftType type, int batch, CUstream stream, ref SizeT size)
            : this(handle, nx, type, batch, ref size)
        {
            SetStream(stream);
        }



        /// <summary>
        /// Creates a new 1D FFT plan (new API)
        /// </summary>
        /// <param name="handle">cufftHandle object</param>
        /// <param name="nx">The transform size (e.g., 256 for a 256-point FFT)</param>
        /// <param name="type">The transform data type (e.g., C2C for complex to complex)</param>
        /// <param name="batch">Number of transforms of size nx</param>
        /// <param name="autoAllocate">indicates that the caller intends to allocate and manage
        /// work areas for plans that have been generated.</param>
        public CudaFFTPlan1D(cufftHandle handle, int nx, cufftType type, int batch, bool autoAllocate)
            : this(handle, nx, type, batch)
        {
            SetAutoAllocation(autoAllocate);
        }

        /// <summary>
        /// Creates a new 1D FFT plan (new API)
        /// </summary>
        /// <param name="handle">cufftHandle object</param>
        /// <param name="nx">The transform size (e.g., 256 for a 256-point FFT)</param>
        /// <param name="type">The transform data type (e.g., C2C for complex to complex)</param>
        /// <param name="batch">Number of transforms of size nx</param>
        /// <param name="size"></param>
        /// <param name="autoAllocate">indicates that the caller intends to allocate and manage
        /// work areas for plans that have been generated.</param>
        public CudaFFTPlan1D(cufftHandle handle, int nx, cufftType type, int batch, ref SizeT size, bool autoAllocate)
            : this(handle, nx, type, batch, ref size)
        {
            SetAutoAllocation(autoAllocate);
        }

        /// <summary>
        /// Creates a new 1D FFT plan (new API)
        /// </summary>
        /// <param name="handle">cufftHandle object</param>
        /// <param name="nx">The transform size (e.g., 256 for a 256-point FFT)</param>
        /// <param name="type">The transform data type (e.g., C2C for complex to complex)</param>
        /// <param name="batch">Number of transforms of size nx</param>
        /// <param name="stream">A valid CUDA stream created with cudaStreamCreate() (or 0 for the default stream)</param>
        /// <param name="autoAllocate">indicates that the caller intends to allocate and manage
        /// work areas for plans that have been generated.</param>
        public CudaFFTPlan1D(cufftHandle handle, int nx, cufftType type, int batch, CUstream stream, bool autoAllocate)
            : this(handle, nx, type, batch)
        {
            SetStream(stream);
            SetAutoAllocation(autoAllocate);
        }



        /// <summary>
        /// Creates a new 1D FFT plan (new API)
        /// </summary>
        /// <param name="handle">cufftHandle object</param>
        /// <param name="nx">The transform size (e.g., 256 for a 256-point FFT)</param>
        /// <param name="type">The transform data type (e.g., C2C for complex to complex)</param>
        /// <param name="batch">Number of transforms of size nx</param>
        /// <param name="stream">A valid CUDA stream created with cudaStreamCreate() (or 0 for the default stream)</param>
        /// <param name="size"></param>
        /// <param name="autoAllocate">indicates that the caller intends to allocate and manage
        /// work areas for plans that have been generated.</param>
        public CudaFFTPlan1D(cufftHandle handle, int nx, cufftType type, int batch, CUstream stream, ref SizeT size, bool autoAllocate)
            : this(handle, nx, type, batch, ref size)
        {
            SetStream(stream);
            SetAutoAllocation(autoAllocate);
        }



        /// <summary>
        /// For dispose
        /// </summary>
        ~CudaFFTPlan1D()
        {
            Dispose(false);
        }
        #endregion

        #region Dispose
        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// For IDisposable
        /// </summary>
        /// <param name="fDisposing"></param>
        protected virtual void Dispose(bool fDisposing)
        {
            if (fDisposing && !disposed)
            {
                //Ignore if failing
                res = CudaFFTNativeMethods.cufftDestroy(_handle);
                Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "cufftDestroy", res));
                disposed = true;
            }
            if (!fDisposing && !disposed)
                Debug.WriteLine(String.Format("ManagedCUDA not-disposed warning: {0}", this.GetType()));
        }
        #endregion

        #region Methods
        /// <summary>
        /// This call gives a more accurate estimate of the work area size required for a plan than
        /// cufftEstimate1d(), given the specified parameters, and taking into account any plan
        /// settings that may have been made.
        /// </summary>
        /// <returns></returns>
        public SizeT GetSize()
        {
            SizeT size = new SizeT();
            res = CudaFFTNativeMethods.cufftGetSize1d(_handle, _nx, _type, _batch, ref size);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "cufftGetSize1d", res));
            if (res != cufftResult.Success)
                throw new CudaFFTException(res);
            return size;
        }

        /// <summary>
        /// During plan execution, CUFFT requires a work area for temporary storage of
        /// intermediate results. This call returns an estimate for the size of the work area required,
        /// given the specified parameters, and assuming default plan settings. Note that changing
        /// some plan settings, such as compatibility mode, may alter the size required for the work
        /// area.
        /// </summary>
        /// <param name="nx">The transform size (e.g. 256 for a 256-point FFT)</param>
        /// <param name="type">The transform data type (e.g., CUFFT_C2C for single
        /// precision complex to complex)</param>
        /// <param name="batch">Number of transforms of size nx</param>
        /// <returns></returns>
        public static SizeT EstimateSize(int nx, cufftType type, int batch)
        {
            SizeT size = new SizeT();
            cufftResult res = CudaFFTNativeMethods.cufftEstimate1d(nx, type, batch, ref size);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "cufftEstimate1d", res));
            if (res != cufftResult.Success)
                throw new CudaFFTException(res);
            return size;
        }

        /// <summary>
        /// Once plan generation has been done, either with the original API or the extensible API,
        /// this call returns the actual size of the work area required to support the plan. Callers
        /// who choose to manage work area allocation within their application must use this call
        /// after plan generation, and after any cufftSet*() calls subsequent to plan generation, if
        /// those calls might alter the required work space size.
        /// </summary>
        /// <returns></returns>
        public SizeT GetActualSize()
        {
            SizeT size = new SizeT();
            res = CudaFFTNativeMethods.cufftGetSize(_handle, ref size);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "cufftGetSize", res));
            if (res != cufftResult.Success)
                throw new CudaFFTException(res);
            return size;
        }

        /// <summary>
        /// SetWorkArea() overrides the work area pointer associated with a plan.
        /// If the work area was auto-allocated, CUFFT frees the auto-allocated space. The
        /// cufftExecute*() calls assume that the work area pointer is valid and that it points to
        /// a contiguous region in device memory that does not overlap with any other work area. If
        /// this is not the case, results are indeterminate.
        /// </summary>
        /// <param name="workArea"></param>
        public void SetWorkArea(CUdeviceptr workArea)
        {
            res = CudaFFTNativeMethods.cufftSetWorkArea(_handle, workArea);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "cufftSetWorkArea", res));
            if (res != cufftResult.Success)
                throw new CudaFFTException(res);
        }

        /// <summary>
        /// SetAutoAllocation() indicates that the caller intends to allocate and manage
        /// work areas for plans that have been generated. CUFFT default behavior is to allocate
        /// the work area at plan generation time. If cufftSetAutoAllocation() has been called
        /// with autoAllocate set to "false" prior to one of the cufftMakePlan*() calls, CUFFT
        /// does not allocate the work area. This is the preferred sequence for callers wishing to
        /// manage work area allocation.
        /// </summary>
        /// <param name="autoAllocate"></param>
        public void SetAutoAllocation(bool autoAllocate)
        {
            int auto = 0;
            if (autoAllocate) auto = 1;
            res = CudaFFTNativeMethods.cufftSetAutoAllocation(_handle, auto);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "cufftSetAutoAllocation", res));
            if (res != cufftResult.Success)
                throw new CudaFFTException(res);
        }

        /// <summary>
        /// Executes a CUFTT transorm as defined by the cufftType.
        /// If idata and odata are the
        /// same, this method does an in‐place transform.
        /// </summary>
        /// <param name="idata"></param>
        /// <param name="odata"></param>
        /// <param name="direction">Only unsed for transformations where direction is not implicitly given by type</param>
        public void Exec(CUdeviceptr idata, CUdeviceptr odata, TransformDirection direction)
        {
            switch (_type)
            {
                case cufftType.R2C:
                    res = CudaFFTNativeMethods.cufftExecR2C(_handle, idata, odata);
                    Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "cufftExecR2C", res));
                    break;
                case cufftType.C2R:
                    res = CudaFFTNativeMethods.cufftExecC2R(_handle, idata, odata);
                    Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "cufftExecC2R", res));
                    break;
                case cufftType.C2C:
                    res = CudaFFTNativeMethods.cufftExecC2C(_handle, idata, odata, direction);
                    Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "cufftExecC2C", res));
                    break;
                case cufftType.D2Z:
                    res = CudaFFTNativeMethods.cufftExecD2Z(_handle, idata, odata);
                    Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "cufftExecD2Z", res));
                    break;
                case cufftType.Z2D:
                    res = CudaFFTNativeMethods.cufftExecZ2D(_handle, idata, odata);
                    Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "cufftExecZ2D", res));
                    break;
                case cufftType.Z2Z:
                    res = CudaFFTNativeMethods.cufftExecZ2Z(_handle, idata, odata, direction);
                    Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "cufftExecZ2Z", res));
                    break;
                default:
                    break;
            }
            if (res != cufftResult.Success)
                throw new CudaFFTException(res);
        }

        /// <summary>
        /// Executes a CUFTT transorm as defined by the cufftType.
        /// This method does an in‐place transform.
        /// </summary>
        /// <param name="iodata"></param>
        /// <param name="direction">Only unsed for transformations where direction is not implicitly given by type</param>
        public void Exec(CUdeviceptr iodata, TransformDirection direction)
        {
            switch (_type)
            {
                case cufftType.R2C:
                    res = CudaFFTNativeMethods.cufftExecR2C(_handle, iodata, iodata);
                    Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "cufftExecR2C", res));
                    break;
                case cufftType.C2R:
                    res = CudaFFTNativeMethods.cufftExecC2R(_handle, iodata, iodata);
                    Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "cufftExecC2R", res));
                    break;
                case cufftType.C2C:
                    res = CudaFFTNativeMethods.cufftExecC2C(_handle, iodata, iodata, direction);
                    Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "cufftExecC2C", res));
                    break;
                case cufftType.D2Z:
                    res = CudaFFTNativeMethods.cufftExecD2Z(_handle, iodata, iodata);
                    Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "cufftExecD2Z", res));
                    break;
                case cufftType.Z2D:
                    res = CudaFFTNativeMethods.cufftExecZ2D(_handle, iodata, iodata);
                    Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "cufftExecZ2D", res));
                    break;
                case cufftType.Z2Z:
                    res = CudaFFTNativeMethods.cufftExecZ2Z(_handle, iodata, iodata, direction);
                    Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "cufftExecZ2Z", res));
                    break;
                default:
                    break;
            }
            if (res != cufftResult.Success)
                throw new CudaFFTException(res);
        }

        /// <summary>
        /// Executes a CUFTT transorm as defined by the cufftType.
        /// If idata and odata are the
        /// same, this method does an in‐place transform.<para/>
        /// This method is only valid for transform types where transorm direction is implicitly 
        /// given by the type (i.e. not C2C and not Z2Z)
        /// </summary>
        /// <param name="idata"></param>
        /// <param name="odata"></param>
        public void Exec(CUdeviceptr idata, CUdeviceptr odata)
        {
            switch (_type)
            {
                case cufftType.R2C:
                    res = CudaFFTNativeMethods.cufftExecR2C(_handle, idata, odata);
                    Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "cufftExecR2C", res));
                    break;
                case cufftType.C2R:
                    res = CudaFFTNativeMethods.cufftExecC2R(_handle, idata, odata);
                    Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "cufftExecC2R", res));
                    break;
                case cufftType.D2Z:
                    res = CudaFFTNativeMethods.cufftExecD2Z(_handle, idata, odata);
                    Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "cufftExecD2Z", res));
                    break;
                case cufftType.Z2D:
                    res = CudaFFTNativeMethods.cufftExecZ2D(_handle, idata, odata);
                    Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "cufftExecZ2D", res));
                    break;
                default:
                    throw new ArgumentException("For transformation not of type R2C, C2R, D2Z or Z2D, you must specify a transform direction.");
            }
            if (res != cufftResult.Success)
                throw new CudaFFTException(res);
        }

        /// <summary>
        /// Executes a CUFTT transorm as defined by the cufftType.
        /// This method does an in‐place transform.<para/>
        /// This method is only valid for transform types where transorm direction is implicitly 
        /// given by the type (i.e. not C2C and not Z2Z)
        /// </summary>
        /// <param name="iodata"></param>
        public void Exec(CUdeviceptr iodata)
        {
            switch (_type)
            {
                case cufftType.R2C:
                    res = CudaFFTNativeMethods.cufftExecR2C(_handle, iodata, iodata);
                    Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "cufftExecR2C", res));
                    break;
                case cufftType.C2R:
                    res = CudaFFTNativeMethods.cufftExecC2R(_handle, iodata, iodata);
                    Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "cufftExecC2R", res));
                    break;
                case cufftType.D2Z:
                    res = CudaFFTNativeMethods.cufftExecD2Z(_handle, iodata, iodata);
                    Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "cufftExecD2Z", res));
                    break;
                case cufftType.Z2D:
                    res = CudaFFTNativeMethods.cufftExecZ2D(_handle, iodata, iodata);
                    Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "cufftExecZ2D", res));
                    break;
                default:
                    throw new ArgumentException("For transformation not of type R2C, C2R, D2Z or Z2D, you must specify a transform direction.");
            }
            if (res != cufftResult.Success)
                throw new CudaFFTException(res);
        }

        /// <summary>
        /// Associates a CUDA stream with a CUFFT plan. All kernel launches
        /// made during plan execution are now done through the associated
        /// stream, enabling overlap with activity in other streams (for example,
        /// data copying). The association remains until the plan is destroyed or
        /// the stream is changed with another call to SetStream().
        /// </summary>
        /// <param name="stream">A valid CUDA stream created with cudaStreamCreate() (or 0 for the default stream)</param>
        public void SetStream(CUstream stream)
        {
            res = CudaFFTNativeMethods.cufftSetStream(_handle, stream);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "cufftSetStream", res));
            if (res != cufftResult.Success)
                throw new CudaFFTException(res);
        }

        ///// <summary>
        ///// configures the layout of CUFFT output in FFTW‐compatible modes.
        ///// When FFTW compatibility is desired, it can be configured for padding
        ///// only, for asymmetric complex inputs only, or to be fully compatible.
        ///// </summary>
        ///// <param name="mode">The <see cref="Compatibility"/> option to be used</param>
        //public void SetCompatibilityMode(Compatibility mode)
        //{
        //    res = CudaFFTNativeMethods.cufftSetCompatibilityMode(_handle, mode);
        //    Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "cufftSetCompatibilityMode", res));
        //    if (res != cufftResult.Success)
        //        throw new CudaFFTException(res);
        //}
        #endregion

        #region Properties
        /// <summary>
        /// The transform size (e.g., 256 for a 256-point FFT)
        /// </summary>
        public int NX
        {
            get { return _nx; }
        }

        /// <summary>
        /// The transform data type (e.g., C2C for complex to complex)
        /// </summary>
        public cufftType Type
        {
            get { return _type; }
        }

        /// <summary>
        /// Number of transforms of size NX
        /// </summary>
        public int Batch
        {
            get { return _batch; }
        }

        /// <summary>
        /// Handle
        /// </summary>
		public cufftHandle Handle
        {
            get { return _handle; }
        }
        #endregion
    }
}
