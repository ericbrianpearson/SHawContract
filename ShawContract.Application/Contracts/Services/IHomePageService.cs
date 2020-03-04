using ShawContract.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShawContract.Application.Contracts.Services
{
    public interface IHomePageService
    {
        HomePage GetHomePage();
    }
}
