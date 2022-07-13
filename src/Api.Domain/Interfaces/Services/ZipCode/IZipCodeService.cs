// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.ZipCode;

namespace Api.Domain.Interfaces.Services.ZipCode
{
    public interface IZipCodeService
    {
        Task<ZipCodeDto> Get(Guid id);
        Task<ZipCodeDto> Get(string zipCode);

        Task<ZipCodeDtoCreateResult> Post(ZipCodeDtoCreate zipCode);
        Task<ZipCodeDtoUpdateResult> Put(ZipCodeDtoUpdate zipCode);
        Task<bool> Delete(Guid id);
    }
}
