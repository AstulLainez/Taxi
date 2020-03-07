﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxi.Web.Data.Entities;

namespace Taxi.Web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<TaxiEntity> TaxiEntities { get; set; }
        public DbSet<TripEntity> TripEntities { get; set; }
        public DbSet<TripDetailEntity> TripDetailEntities { get; set; }
    }
}
