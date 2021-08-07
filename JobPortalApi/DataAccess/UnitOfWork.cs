using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobPortalApi.Models;
using System.Data.Entity;
using JobPortalApi.BuisnessLogic.Implementation;

namespace JobPortalApi.DataAccess
{
    public class UnitOfWork : IDisposable
    {
        /// Stores the string error message
        /// </summary>
        private string errorMessage = string.Empty;

        /// <summary>
        /// Initializes a new instance of the NewJobPortalDBEntities class
        /// </summary>
        private JobPortalDbEntities JobPortalEntities = new JobPortalDbEntities();


        /// <summary>
        /// Defines variable of the Job Portal Generic Gepository of specified type class
        /// </summary>
        private DataRepository<Country> countryRepository;
        private DataRepository<State> stateRepository;
        private DataRepository<City> cityRepository;
        private DataRepository<Tbl_Registration> registerRepository;
        

        private bool disposed;

        /// <summary>
        /// Gets property on CountryRepository variable which will bind to generic class of name DataRepository 
        /// </summary>
        public DataRepository<Country> CountryRepository
        {
            get
            {
                try
                {
                    if (this.countryRepository == null)
                    {
                        this.countryRepository = new DataRepository<Country>(this.JobPortalEntities);
                    }

                    return this.countryRepository;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public DataRepository<State> StateRepository
        {
            get
            {
                if (this.stateRepository == null)
                {
                    this.stateRepository = new DataRepository<State>(this.JobPortalEntities);
                }
                return this.stateRepository;
            }
        }
        public DataRepository<City> CityRepository
        {
            get
            {
                if (this.cityRepository == null)
                {
                    this.cityRepository = new DataRepository<City>(this.JobPortalEntities);
                }
                return this.cityRepository;
            }
        }

        public DataRepository<Tbl_Registration> RegisterRepository
        {
            get
            {
                if (this.registerRepository == null)
                {
                    this.registerRepository = new DataRepository<Tbl_Registration>(this.JobPortalEntities);
                }

                return this.registerRepository;
            }
        }
        





       




            




           






            




       












       /// <summary>
        /// This Method will commit the changes to database for the permanent save
        /// </summary>
        public int Save()
        {
            return this.JobPortalEntities.SaveChanges();
        }

        /// <summary>
        /// This method will dispose the context class object after the uses of that object
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// This method will dispose the context class object after the uses of that object
        /// </summary>
        /// <param name="disposing">parameter true or false for disposing database object</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.JobPortalEntities.Dispose();
                }
            }

            this.disposed = true;
        }

    }





}