using System;
using System.Data.Common;
using System.Linq;
using API.Controllers;
using DAL;
using API;
using DAL.Models;
using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.InMemory;

namespace TestAPI
{
    public class PlantsControllerTest
    {
        private DbContextOptions<DatabaseNeePortal2023Uas6Context> _contextOptions;
        private DatabaseNeePortal2023Uas6Context context;

        public PlantsControllerTest()
        {
            _contextOptions = new DbContextOptionsBuilder<DatabaseNeePortal2023Uas6Context>()
                .UseInMemoryDatabase("PlantsControllerTest")
                .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            context = new DatabaseNeePortal2023Uas6Context(_contextOptions);

            if (context.Database.EnsureCreated())
            {
                SubCategoryCatalogue subCategoryPV = new SubCategoryCatalogue();
                subCategoryPV.CatalogueId = "sub_cat1";
                subCategoryPV.De = "PV";
                subCategoryPV.En = "PV";
                subCategoryPV.Fr = "PV";
                subCategoryPV.It = "PV";
                context.SubCategoryCatalogues.Add(subCategoryPV);
                ProductionV productionV = new ProductionV();
                productionV.Gwh = 100;
                productionV.GwhTotal = 100;
                productionV.SubCategory = "sub_cat1";
                productionV.Year = 2020;
                context.ProductionVs.Add(productionV);
                context.SaveChanges();
            }

        }

        [Fact]
        public async void GetProductionVS()
        {
            // Run the test against one instance of the context
            var controller = new PlantsController(context);
            var result = controller.GetProductionVS().Result;
            List<ProductionVS> productionVs = result.Value.ToList();

            foreach (var productionV in productionVs)
            {
                Assert.Equal(100, productionV.Gwh);
                Assert.Equal(100, productionV.Gwh_Total);
                Assert.Equal("sub_cat1", productionV.SubCategory);
                Assert.Equal(2020, productionV.Year);
            }
        }
    }
}