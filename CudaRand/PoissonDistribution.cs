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

namespace ManagedCuda.CudaRand
{
    /// <summary>
    /// Poisson distribution
    /// </summary>
    public class PoissonDistribution : IDisposable
    {
        private bool disposed;
        private DiscreteDistribution _distributions;
        private double _lambda;
        private CurandStatus _status;

        #region Constructors
        /// <summary>
        /// Creates a new poisson distribution.<para/>
        /// Construct histogram array for poisson distribution.<para/>
        /// Construct histogram array for poisson distribution with lambda <c>lambda</c>.
        /// For lambda greater than 2000 optimization with normal distribution is used.
        /// </summary>
        /// <param name="lambda">lambda for poisson distribution</param>
        public PoissonDistribution(double lambda)
        {
            _distributions = new DiscreteDistribution();
            _lambda = lambda;
            _status = CudaRandNativeMethods.curandCreatePoissonDistribution(lambda, ref _distributions);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "curandCreatePoissonDistribution", _status));
            if (_status != CurandStatus.Success) throw new CudaRandException(_status);
        }

        /// <summary>
        /// For dispose
        /// </summary>
        ~PoissonDistribution()
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
                _status = CudaRandNativeMethods.curandDestroyDistribution(_distributions);
                Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "curandDestroyDistribution", _status));
                disposed = true;
            }
            if (!fDisposing && !disposed)
                Debug.WriteLine(String.Format("CudaRand not-disposed warning: {0}", this.GetType()));
        }
        #endregion

        /// <summary> 
        /// Generate Poisson-distributed unsigned ints.<para/>
        /// Use <c>generator</c> to generate <c>num</c> unsigned int results into the device memory at
        /// <c>outputPtr</c>.  The device memory must have been previously allocated and be
        /// large enough to hold all the results.  Launches are done with the stream
        /// set using <c>curandSetStream()</c>, or the null stream if no stream has been set.
        /// Results are 32-bit unsigned int point values with poisson distribution based on
        /// an associated poisson distribution with lambda <c>lambda</c>.
        /// </summary>
        /// <param name="generator">Generator to use</param>
        /// <param name="output">Pointer to device memory to store CUDA-generated results</param>
        public void Generate(CudaRandDevice generator, CudaDeviceVariable<uint> output)
        {
            _status = CudaRandNativeMethods.curandGeneratePoisson(generator.Generator, output.DevicePointer, output.Size, _lambda);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "curandGeneratePoisson", _status));
            if (_status != CurandStatus.Success) throw new CudaRandException(_status);
        }


        /// <summary> 
        /// Generate Poisson-distributed unsigned ints.<para/>
        /// Use <c>generator</c> to generate <c>num</c> unsigned int results into the device memory at
        /// <c>outputPtr</c>.  The device memory must have been previously allocated and be
        /// large enough to hold all the results.  Launches are done with the stream
        /// set using <c>curandSetStream()</c>, or the null stream if no stream has been set.
        /// Results are 32-bit unsigned int point values with poisson distribution based on
        /// an associated poisson distribution with lambda <c>lambda</c>.
        /// </summary>
        /// <param name="generator">Generator to use</param>
        /// <param name="output">Pointer to host memory to store CPU-generated results</param>
        public void Generate(CudaRandHost generator, uint[] output)
        {
            _status = CudaRandNativeMethods.curandGeneratePoisson(generator.Generator, output, output.Length, _lambda);
            Debug.WriteLine(String.Format("{0:G}, {1}: {2}", DateTime.Now, "curandGeneratePoisson", _status));
            if (_status != CurandStatus.Success) throw new CudaRandException(_status);
        }
    }
}
