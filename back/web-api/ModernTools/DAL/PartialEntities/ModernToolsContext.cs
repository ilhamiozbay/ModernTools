using DAL.Entities.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace DAL.PartialEntities
{
    public class ModernToolsContext: ModernToolsBaseContext
    {
        public ModernToolsContext()
        {

        }

        public ModernToolsContext(DbContextOptions<ModernToolsBaseContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if DEBUG
            base.OnConfiguring(optionsBuilder);
            base.OnConfiguring(optionsBuilder
                .UseLoggerFactory(ModernToolsLoggerFactory));
#endif
#if RELEASE
            base.OnConfiguring(optionsBuilder);
#endif
        }

        /* 
            Yazdığımız entity`lerin log'unun yazılması. 
            Linq `ların debug moddayken sql execution plan scriptini görmemizi sağlıyor. 
        */
        public static readonly ILoggerFactory ModernToolsLoggerFactory 
            = LoggerFactory.Create(builder =>
            {
                builder.AddFilter((category, level) =>
                    category ==
                    DbLoggerCategory.Database.Command.Name
                    && level == LogLevel.Information)
                .AddDebug();
            });

    }
}
