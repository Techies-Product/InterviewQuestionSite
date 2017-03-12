using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace InterviewSite.Models
{
    public class CountryRepository : ICountryRepository
    {
        public IEnumerable<Country> Countries
        {
            get
            {
                return new CountryRepository().GetCountries();
            }
        }

        public IEnumerable<Country> GetCountries()
        {
            Database db = new Database();
            DataSet ds = new DataSet();
            db.RunProcedure("GetCountries", null, out ds);
            return ds.Tables[0].AsEnumerable()
                .Select(r => new Country
                {
                    Id = r.Field<int>("id"),
                    CountryName = r.Field<string>("name")
                }).ToList();
        }
    }
}