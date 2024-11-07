using EzSchool.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

namespace EzSchool.App_Start
{
    public class Bootstrapper
    {
        public static IUnityContainer Initialize()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>(); 
            container.RegisterType<IResumeRepository, ResumeRepository>();
            RegisterTypes(container);
            return container;
        }
        public static void RegisterTypes(IUnityContainer container)
        {
            //container.RegisterType<ISchoolMgDbEntities, SchoolMgDbEntities>();
            //container.RegisterType<IResumeRepository, ResumeRepository>();
        }
    }
}