// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.City;

namespace Api.Domain.Interfaces.Services.City
{
    public interface ICityService
    {
        Task<CityDto> Get(Guid id);
        Task<CityDtoFull> GetCompleteById(Guid id);
        Task<CityDtoFull> GetCompleteByIbge(int codIbge);
        Task<IEnumerable<CityDto>> GetAll();
        Task<CityDtoCreateResult> Post(CityDtoCreate city);
        Task<CityDtoUpdateResult> Put(CityDtoUpdate city);
        Task<bool> Delete(Guid id);
    }
}
