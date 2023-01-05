﻿using Common.Implementations;
using System.Collections.Generic;

namespace Historical.Interfaces
{
    public interface IHistorical
    {
        bool WriteModelDataToDataBase(ModelData data);

        IEnumerable<ModelData> GetAllDataFromDataBase();

        IEnumerable<ModelData> GetSelectedDataByCriteria(string criteriaName, string criteria);

        // string upit = "select *from evidencija_potrosnje where " + criteriaName + " = :unos";
        // hint: https://github.com/owlCoder/cache-memory/blob/clean-arch/src/Cache%20Memory/DataAccessObject/Implementations/Korisnici.cs

        //TODO
    }
}