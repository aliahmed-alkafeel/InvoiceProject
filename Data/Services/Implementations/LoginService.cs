using Data.Context;
using Data.Services.Interfaces;
using Data.UnitOfWork;
using Models.CurrentUserDetails;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Implementations
{
    public class LoginService : ILoginService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LoginService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> LoginAsync(string username, string password)
        {

            var employee = await _unitOfWork.Employees.Select()
                .FirstOrDefaultAsync(x => x.Username == username);
            if (employee == null)
                return false;
            if (employee.Password != password)
                return false;
            CurrentUser.LogIn(employee.Id);
            return true;
        }
    }
}
