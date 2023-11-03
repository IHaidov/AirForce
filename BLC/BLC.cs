﻿using Alesik.Haidov.Airforce.Core;
using Alesik.Haidov.Airforce.Interfaces;
using System.Reflection;

namespace Alesik.Haidov.Airforce.BLC
{
    public class BLC
    {
        private IDAO dao;

        public BLC(string dllPath)
        {
            var typeToCreate = FindDAOType(dllPath);

            if (typeToCreate != null)
            {
                dao = CreateDAOInstance(typeToCreate);
            }
            else
            {
                throw new InvalidOperationException("No compatible IDAO type found in assembly.");
            }
        }

        #region Handle DAO 
        private Type FindDAOType(string dllPath)
        {
            try
            {
                var assembly = Assembly.UnsafeLoadFrom(dllPath);
                foreach (var type in assembly.GetTypes())
                {
                    if (typeof(IDAO).IsAssignableTo(type))
                    {
                        return type;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load assembly or find IDAO: " + ex.Message);
                throw;
            }

            return null;
        }

        private IDAO CreateDAOInstance(Type daoType)
        {
            try
            {
                return (IDAO)Activator.CreateInstance(daoType);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to create instance of IDAO: {daoType.Name}\n{ex.Message}");
                throw;
            }
        }
        #endregion

        public IEnumerable<IAircraft> GetAllAircrafts() => dao.GetAllAircrafts();

        public IEnumerable<IAirforceBase> GetAllAirforceBases() => dao.GetAllAirforceBases();

        public IEnumerable<IAircraft> GetAircraft(string guid) => dao.GetAllAircrafts().Where(aircraft => aircraft.GUID.Equals(guid));

        public IEnumerable<IAirforceBase> GetAirforceBase(string guid) => dao.GetAllAirforceBases().Where(airbase => airbase.GUID.Equals(guid));

        public IEnumerable<IAircraft> GetAircraftByModel(string model) => dao.GetAllAircrafts().Where(aircraft => aircraft.Model.Equals(model));

        public IEnumerable<IAircraft> GetAircraft(AircraftType type) => dao.GetAllAircrafts().Where(aircraft => aircraft.Type.Equals(type));

        public IEnumerable<IAirforceBase> GetAirforceBaseByName(string name) => dao.GetAllAirforceBases().Where(airbase => airbase.Name.Equals(name));

        public void RemoveAircraft(string guid) => dao.RemoveAircraft(guid);

        public void RemoveAirforceBase(string guid) => dao.RemoveAirforceBase(guid);

        public void CreateOrUpdateAircraft(IAircraft aircraft)
        {
            if (aircraft.GUID == null)
            {
                aircraft.GUID = Guid.NewGuid().ToString();
                dao.AddNewAircraft(aircraft);
            }
            else
            {
                dao.UpdateAircraft(aircraft);
            }
        }

        public void CreateOrUpdateAirforceBase(IAirforceBase airbase)
        {
            if (airbase.GUID == null)
            {
                airbase.GUID = Guid.NewGuid().ToString();
                dao.AddNewAirforceBase(airbase);
            }
            else
            {
                dao.UpdateAircraftBase(airbase);
            }
        }

    }
}