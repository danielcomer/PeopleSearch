using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSearch.ViewModel
{
    public interface IPersonSearchViewModel
    {
        string LoadingMessage { get; set; }
        bool IsLoading { get; set; }

    }
}
