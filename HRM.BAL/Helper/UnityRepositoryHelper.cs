using HRM.DATA.Interface;
using HRM.DATA.Repo;
using System;
using System.Collections.Generic;
using System.Text;
using Unity.Extension;
using Unity;



namespace HRM.BAL.Helper
{
    public class UnityRepositoryHelper : UnityContainerExtension
    {
        protected override void Initialize()
        {
           Container.RegisterType<IEmployeeRepo, EmployeeRepo>();
           
        }
    }
}
