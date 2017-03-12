using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewSite.Models
{
    interface ICountryRepository
    {
        IEnumerable<Country> Countries { get; }
        IEnumerable<Country> GetCountries();
    }
}
