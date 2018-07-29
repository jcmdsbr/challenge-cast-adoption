using SGA.Application.Domain.Dtos;
using SGA.Domain.Entities.Models;
using SGA.Domain.Entities.ValueObjects;
using System;

namespace SGA.Infra.Dapper.Maps
{
    public static class AdoptionMap
    {
        public static Func<AdoptionDto, Responsible, Cpf, Email, AdoptionDto> AdoptionDto()
        {
            return (ad, res, cpf, email) =>
            {
                res.SetCpf(cpf);

                res.SetEmail(email);

                ad.Responsible = res;

                return ad;
            };
        }
    }
}