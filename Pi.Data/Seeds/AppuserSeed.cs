using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pi.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pi.Data.Seeds
{
    public class AppuserSeed : IEntityTypeConfiguration<Appuser>
    {
        private readonly int[] _ids;

        public AppuserSeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Appuser> builder)
        {
            builder.HasData(
                new Appuser { Id = _ids[0], Name = "Testname", SurName = "Testsurname"},
                  new Appuser { Id = _ids[1], Name = "Testname2", SurName = "Testsurname2" }

                );
        }
    }
}
